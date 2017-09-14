using System.Drawing;
using System.Windows.Forms;

namespace CommonControls.Custom
{
    public class TitleLabel : Label
    {
        public TitleLabel()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Paint += CustomLabel_Paint;

            this.Font = DefaultStyle.TitleFont;
            this.ForeColor = DefaultStyle.TitleForeColor;
            this.BackColor = DefaultStyle.TitleBackColor;
        }

        private void CustomLabel_Paint(object sender, PaintEventArgs e)
        {
            this.Text = this.Text.ToUpper();
            this.TextAlign = ContentAlignment.MiddleCenter;
        }
    }
}