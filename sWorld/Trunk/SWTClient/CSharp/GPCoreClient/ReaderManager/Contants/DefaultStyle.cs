using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ReaderManager.Contants
{
    public class DefaultStyle
    {
        public static Color TitleBackColor = Color.FromArgb(3, 111, 192);
        public static Color TitleForeColor = Color.WhiteSmoke;
        public static Font TitleFont = new Font("Tahoma", 9.25f);

        public static Color ActiveTabBackColor = Color.White;
        public static Color ActiveTabForeColor = Color.Black;
        public static Font ActiveTabFont = new Font("Tahoma", 9.25f);

        public static Color InactiveTabBackColor = SystemColors.Control;
        public static Color InactiveTabForeColor = SystemColors.ControlText;
        public static Font InactiveTabFont = new Font("Tahoma", 9.25f);

        public static Color PanelBackColor = SystemColors.Control;
        public static Color PanelForeColor = SystemColors.ControlText;
        public static Font PanelFont = new Font("Tahoma", 9.25f);

        public static Font TooltipFont = new Font("Tahoma", 8.25f);

        public static Font NotificationFont = new Font("Tahoma", 12.25f, FontStyle.Bold);
        public static Color NotificationSucceedColor = Color.FromArgb(0, 128, 0);    // Green
        public static Color NotificationFailedColor = Color.FromArgb(255, 0, 0);     // Red
        public static Color NotificationWarningColor = Color.FromArgb(0, 128, 128);     // Teal

    }
}
