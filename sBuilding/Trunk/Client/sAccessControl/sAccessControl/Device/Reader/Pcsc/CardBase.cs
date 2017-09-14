using System;
using System.Threading;

namespace sAccessControl.Device.Reader.Pcsc
{
    public delegate void CardInsertedEventHandler();
    public delegate void CardRemovedEventHandler();
    public delegate void ReaderUnpluggedEventHandler();
    public delegate void ReaderPluggedEventHandler();

    abstract public class CardBase : ICard
    {
        protected const uint INFINITE = 0xFFFFFFFF;
        protected const uint WAIT_TIME = 250;

        protected bool th_flag = true;
        protected Thread th_detectCard = null;

        public event CardInsertedEventHandler CardInserted;
        public event CardRemovedEventHandler CardRemoved;
        public event ReaderUnpluggedEventHandler ReaderUnplugged;

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

        protected void HandleCardInserted()
        {
            if (CardInserted != null)
                CardInserted();
        }

        protected void HandleCardRemoved()
        {
            if (CardRemoved != null)
                CardRemoved();
        }

        protected void HandleReaderUnplugged()
        {
            if (ReaderUnplugged != null)
                ReaderUnplugged();
        }

        abstract public string[] ListReaders();
        abstract public void Connect(string readerAlias, SHARE_MODE ShareMode, PROTOCOL PreferredProtocols);
        abstract public void Disconnect(DISCONNECT Disposition);

        abstract public APDUResponse Transmit(APDUCommand ApduCmd);
        abstract public void BeginTransaction();
        abstract public void EndTransaction(DISCONNECT Disposition);
        abstract public byte[] GetAttribute(UInt32 AttribId);

        abstract protected void RunCardDetection(object readerAlias);
    }
}
