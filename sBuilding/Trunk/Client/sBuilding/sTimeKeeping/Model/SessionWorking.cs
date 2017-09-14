using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
   
    public class SessionWorking
    {
        public SessionWorking()
        {
            isCheckSession = 1 ; // default value
            hoursBegin = 0; // default value
            minuteBegin = 0; // default value
            hoursEnd = 24; // default value
            minuteEnd = 0; // default value
        }
        public int isCheckSession { get; set; }
        
        public int hoursBegin { get; set; }
       
        public int minuteBegin { get; set; }
      
        public int hoursEnd { get; set; }
       
        public int minuteEnd { get; set; }

    }
}
