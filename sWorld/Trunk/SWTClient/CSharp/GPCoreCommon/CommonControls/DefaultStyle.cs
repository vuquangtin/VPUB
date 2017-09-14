using System.Drawing;

namespace CommonControls
{
    public static class DefaultStyle
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
    }
}