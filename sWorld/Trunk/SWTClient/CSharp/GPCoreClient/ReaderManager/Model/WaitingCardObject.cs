using ReaderManager.Contants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Model
{
    public class WaitingCardObject
    {
        public WaitingCardObject() { }
        public string CurrentReaderName { get; set; }

        //chi dung cho PCSC dung co sua cua tui
        public int PCSC_WAITING_CARD {
            get { return ReaderContants.CardDetectionDelayTime; } 
        }
        
    }
}
