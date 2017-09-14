using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CommonControls.Custom
{
    public class PasswordMeterLabel : Label
    {
        private int score = 0;

        [Browsable(true)]
        [Description("Set password strength"), Category("Custom Properties")]
        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                if (score != value)
                {
                    score = value;
                    this.Invalidate();
                }
            }
        }

        public PasswordMeterLabel()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Paint += PasswordMeterLabel_Paint;
        }

        /// <summary>
        /// Do project này không reference đến CommonHelper nên biến score
        /// không thể đặt là PasswordScore được. Do đó, khi class PasswordScore
        /// thay đổi, nhớ kiểm tra lại hàm này xem có thích hợp với các giá trị
        /// mới hay không.
        /// </summary>
        private void PasswordMeterLabel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            SolidBrush p = null;
            int width = (this.Width / 5) * Score;  //5 là giá trị của VeryStrong

            switch (Score)
            {
                case 1: //VeryWeek
                    p = new SolidBrush(Color.FromArgb(100, 192, 0, 0));
                    break;
                case 2: //Weak
                    p = new SolidBrush(Color.FromArgb(100, 192, 0, 0));
                    break;
                case 3: //Medium
                    p = new SolidBrush(Color.FromArgb(100, 255, 128, 0));
                    break;
                case 4: //Strong
                    p = new SolidBrush(Color.FromArgb(100, 0, 192, 0));
                    break;
                case 5: //VeryStrong
                    p = new SolidBrush(Color.FromArgb(100, 0, 128, 0));
                    break;
                default:
                    g.Clear(this.BackColor);
                    return;
            }
            g.FillRectangle(p, new Rectangle(0, 0, width, this.Height));
        }
    }
}