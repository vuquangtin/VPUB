using ReaderManager.Pcsc;
//using ReaderManager.Icdrec;
using ReaderManager.Hf;
using ReaderManager.MCR02;
using ParkingProcessComponent.Device.Reader.Hf;
using ReaderManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using CommonHelper.Config;
using ReaderLibrary;

namespace ReaderManager
{
    /// <summary>
    /// using to save real device
    /// </summary>
    public class Devices
    {
        public Devices(string name, ReaderType type, IReader obj)
        {
            this.Name = name;
            this.Type = type;
            this.Reader = obj;
        }
        public string Name { get; set; }
        public ReaderType Type { get; set; }
        public IReader Reader { get; set; }
    }
    
    public class ReaderFactory
    {
        private static ReaderFactory instance = null;
        private static readonly object lob = new object();
        private List<Devices> devices = new List<Devices>();
        

        #region Properties
        public List<string> ListType;

        public IReader reader { get; set; }
        #endregion



        public ReaderFactory() { }


        public static ReaderFactory GetInstance()
        {
            if (instance == null)
            {
                lock (lob)
                {
                    if (instance == null)
                    {
                        instance = new ReaderFactory();
                    }
                }
            }
            return instance;
        }

       /// <summary>
       /// get real device by name
       /// </summary>
       /// <param name="reader"></param>
       /// <returns></returns>
        public IReader GetReader(string reader)
        {
            foreach (Devices device in devices)
            {
                if (device.Name.Equals(reader))
                {
                    return device.Reader;
                }
            }
            return null;
        }
       

        // find and connect real reader to get UID
        public void ScanReader(int index, string readerName)
        {

            // TODO IMPLEMENT
            //if (index == ListType.IndexOf(ReaderTypeExt.GetName(ReaderType.PCSC)))
            //{
            //    pcscReader.ConnectToReader((pcscReader.FindAllCardReader())[0]);
            //}
            //if (index == ListType.IndexOf(ReaderTypeExt.GetName(ReaderType.ICDREC)))
            //{
            //    icdrecReader.ConnectReader();
            //}

        }

        /// <summary>
        ///  disconnect reader
        /// </summary>
        public void DisconnectReader()
        {
            //TODO implement
        }

        // list all card reader  
        public List<String> FindAllCardReader()
        {
            List<string> ListTmp = new List<string>();
            IReader obj = null;
            devices.Clear();
            foreach (ReaderType type in ReaderTypeExt.GetReaderTypeList())
            {
                switch (type)
                {
                    case ReaderType.PCSC:
                        obj = new PcscReader();
                        break;
                    case ReaderType.HF:
                        obj = new HfReader();
                        break;
                    //case ReaderType.ICDREC:
                    //    obj = new IcdrecReader();
                    //    break;
                    case ReaderType.MCR02:
                        obj = new MCR02Reader();
                        break;
                    default:
                        obj = null;
                        break;
                }
                if (null != obj &&  null != obj.FindAllCardReader())
                {
                    foreach (String name in obj.FindAllCardReader())
                    {
                        ListTmp.Add(name);
                        devices.Add(new Devices(name,type, obj));
                    }
                }
            }
            return ListTmp;
        }



    }



}