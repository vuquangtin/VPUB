using ReaderLibrary;
using ReaderManager.Pcsc;
using System;
using System.Threading;
using System.Linq;
using ReaderManager.Contants;
using CommonHelper.Constants;
public delegate void CardInsertedEventHandler(short tagType, byte[] serialNumber);

abstract public class CardBase : ICard
{
    protected const uint INFINITE = 0xFFFFFFFF;
    protected const uint WAIT_TIME = 250;

    protected bool th_flag = true;
    protected Thread th_detectCard = null;

    public event CardInsertedEventHandler CardInserted = null;
    public event EventHandler CardRemoved = null;
    public event EventHandler ReaderUnplugged = null;

    ~CardBase()
    {
        StopCardEvents();
    }

    public void StartCardEvents(string readerAlias)
    {
        if (th_detectCard == null)
        {
            th_flag = true;

            th_detectCard = new Thread(new ParameterizedThreadStart(RunCardDetection));
            th_detectCard.Start(readerAlias);
        }
    }

    public void StopCardEvents()
    {
        if (th_detectCard != null)
        {
            int
                nTimeOut = 10,
                nCount = 0;
            bool m_bStop = false;
            th_flag = false;

            do
            {
                if (nCount > nTimeOut)
                {
                    th_detectCard.Abort();
                    break;
                }

                if (th_detectCard.ThreadState == ThreadState.Aborted)
                    m_bStop = true;

                if (th_detectCard.ThreadState == ThreadState.Stopped)
                    m_bStop = true;

                Thread.Sleep(200);
                ++nCount;           // Manage time out
            }
            while (!m_bStop);

            th_detectCard = null;
        }
    }

    public void RaiseCardInsertedEvent(byte[] atr, string readerAlias)
    {
        // Connect to card
        try
        {
            Connect(readerAlias, SHARE_MODE.SHARED, PROTOCOL.T0_OR_T1);
        }
        catch (ScException)
        {
            return;
        }

        // Get serial number of card
        APDUCommand cmdGetUid = new APDUCommand(0xFF, 0xCA, 0x00, 0x00, null, 0x04);
        APDUResponse response;
        try
        {
            response = Transmit(cmdGetUid);
        }
        catch (ScException)
        {
            return;
        }

        if (response.Status == 0x9000)
        {
            // Get tag type from ATR data
            short tagType = ReadShort(atr, 13);

            // Raise event
            if (CardInserted != null)
            {
                CardInserted(tagType, response.Data);
            }
        }
    }

    private static short ReadShort(byte[] data, int offset)
    {
        if (data.Take(6).ToArray().SequenceEqual(ART.DESFIRE_EV))
            return (short)CARD_TYPE.DESFIRE_CARD;
        else
            return (short)(((data[offset] << 8)) | ((data[offset + 1] & 0xff)));
    }

    public void RaiseReaderRemovedEvent()
    {
        if (CardRemoved != null)
        {
            CardRemoved(this, EventArgs.Empty);
        }
    }

    public void RaiseReaderUnpluggedEvent()
    {
        if (ReaderUnplugged != null)
        {
            ReaderUnplugged(this, EventArgs.Empty);
        }
    }

    abstract public string[] ListReaders();
    abstract public void Connect(string readerAlias, SHARE_MODE ShareMode, PROTOCOL PreferredProtocols);
    abstract public void Disconnect(DISCONNECT Disposition);

    abstract public APDUResponse Transmit(APDUCommand ApduCmd);
    abstract public APDUResponse TransmitDesFire(APDUCommand ApduCmd);
    abstract public void BeginTransaction();
    abstract public void EndTransaction(DISCONNECT Disposition);
    abstract public byte[] GetAttribute(UInt32 AttribId);

    abstract protected void RunCardDetection(object readerAlias);
}