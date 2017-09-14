using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReaderManager.Reader.MCR02
{
    /// <summary>
    /// Lớp xử lý câu lệnh trả về cho MCR Reader.
    /// Không bao gồm các câu lệnh tương tác với màn hình LCD do MCR02 ko có màn hinh LCD.
    /// </summary>

    public class CommandUtils
    {
        #region Properties
        //Clears LCD
        private static string CLEAR_LCD = "LCDCLR";

        //Write Text to LCD: Left;Top;Font_Type;Text
        private static string SET_LCD_CUSTOM = "LCDSET;";

        //Execute Buzzer
        private static string BUZZ_SUCCESS = "BUZZER;100;1";
        private static string BUZZ_FAIL = "BUZZER;500;2";

        //Energize Relay-1 by Delay in Ms.
        private static string RELAY1_SHORT = "ROLE1=500";
        private static string RELAY1_LONG = "ROLE1=1000";
        private static string RELAY1_CUSTOM = "ROLE1=";

        //Energize Relay-2 by Delay in Ms.
        private static string RELAY2_SHORT = "ROLE2=500";
        private static string RELAY2_LONG = "ROLE2=1000";
        private static string RELAY2_CUSTOM = "ROLE2=";

        //Relay-1 ON or OFF all the time.
        private static string RELAY1_ON = "ROLE1=ON";
        private static string RELAY1_OFF = "ROLE1=OFF";

        //Relay-2 ON or OFF all the time.
        private static string RELAY2_ON = "ROLE2=ON";
        private static string RELAY2_OFF = "ROLE2=OFF";

        private static string TSYNC_CODE = "TSYNC";

        #endregion

        //Thông báo lỗi
        public static string failBeep()
        {
            return BUZZ_FAIL + "," + getTSYNC();
        }

        //mở relay 1 trong 1 khoảng thời gian.
        public static string openRelay1ByMilisecond(int ms)
        {
            return RELAY1_CUSTOM + ms + "," + BUZZ_SUCCESS + "," + getTSYNC();
        }

        //mở relay 2 trong 1 khoảng thời gian.
        public static string openRelay2ByMilisecond(int ms)
        {
            return RELAY2_CUSTOM + ms + "," + BUZZ_SUCCESS + "," + getTSYNC();
        }

        //mở relay 1
        public static string turnOnRelay1()
        {
            return RELAY1_ON + "," + BUZZ_SUCCESS + "," + getTSYNC();
        }

        //tắt relay 1
        public static string turnOffRelay1()
        {
            return RELAY1_OFF + "," + BUZZ_SUCCESS + "," + getTSYNC();
        }

        //mở relay 1
        public static string turnOnRelay2()
        {
            return RELAY2_ON + "," + BUZZ_SUCCESS + "," + getTSYNC();
        }

        //tắt relay 1
        public static string turnOffRelay2()
        {
            return RELAY2_OFF + "," + BUZZ_SUCCESS + "," + getTSYNC();
        }

        //xóa trắng màn hình
        public static string clearLCD()
        {
            return CLEAR_LCD + "," + BUZZ_SUCCESS + "," + getTSYNC();
        }

        /// <summary>
        ///  gửi text tới đầu đọc
        /// </summary>
        /// <param name="left">Canh trái</param>
        /// <param name="top">Canh trên</param>
        /// <param name="fontName">Tên font chữ</param>
        /// <param name="text">Text cần gửi</param>
        /// <returns></returns>
        public static string setLCD(int left, int top, string fontName, string text)
        {
            return SET_LCD_CUSTOM + left + ";" + top + ";" + fontName + ";" + text + "," + BUZZ_SUCCESS + "," + getTSYNC();
        }

        //Hàm lấy Unix Time
        private static string getTSYNC()
        {
            Int32 unixTimestamp = (Int32)(DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return TSYNC_CODE + "=" + unixTimestamp.ToString();
        }
    }
}
