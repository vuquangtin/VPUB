using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sAccessControl.Device.Reader.MCR02
{
    /// <summary>
    /// Các lệnh xử lý mở/đóng cửa
    /// </summary>
    public class CommandUtils
    {
        //Clears LCD 
        private static String LCDCLR = @"LCDCLR";
        //Write Text to LCD
        private static String LCDSET = @"LCDSET;10;20;2;{1}";
        //Execute Buzzer
        private static String BUZZER_SUCCESS = @"BUZZER;50;1";

        //Execute Buzzer
        private static String BUZZER_FAIL = @"BUZZER;50;2";

        //Alive message is sent by the Terminal periodically
        private static String ALIVE { get; set; }
        //Energize Relay-1 by Delay in Ms. 
        private static String ROLE1 = @"ROLE1={0}";
        private static String ROLE2 { get; set; }
        //Set Terminals RTC from server.
        private static String TSYNC { get; set; }


        //XX Delay in Milliseconds. The Relay is ON with XX Delay. 
        public static String OpenDoorByMilliseconds(int milliseconds)
        {
            return string.Format(BUZZER_SUCCESS + "," + ROLE1, milliseconds);
        }
        public static String OpenDoorByMilliseconds(int milliseconds, string message)
        {
            return string.Format(BUZZER_SUCCESS + "," + ROLE1 + "," + LCDCLR + "," + LCDSET, milliseconds, message);
        }

        //Relay-2 ON or OFF all the time. 
        public static String OpenDoor()
        {
            return string.Format(BUZZER_SUCCESS + ROLE1, "ON");
        }
        public static String OpenDoor(string message)
        {
            return string.Format(BUZZER_SUCCESS + "," + ROLE1 + "," + LCDCLR + "," + LCDSET, "ON", message);
        }

        //Relay-2 ON or OFF all the time. 
        public static String CloseDoor()
        {
            return string.Format(BUZZER_FAIL + "," + ROLE1, "OFF");
        }
        public static String CloseDoor(string message)
        {
            return string.Format(BUZZER_FAIL + "," + ROLE1 + "," + LCDCLR + "," + LCDSET, "OFF", message);
        }

    }
}
