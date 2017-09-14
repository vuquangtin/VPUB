using System.Drawing;
using System.Windows.Forms;

namespace CommonControls.Custom
{
    public class CommonUserControl : UserControl
    {
        public CommonUserControl()
        {
            this.Font = DefaultStyle.PanelFont;
            this.Padding = new Padding(5, 5, 5, 5);
            this.BackColor = DefaultStyle.PanelBackColor;
        }
    }
}
