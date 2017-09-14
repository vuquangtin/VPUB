using System;
using System.Windows.Forms;

namespace CommonControls.Custom
{
    public class CommonTextBox : TextBox
    {
        public CommonTextBox()
        {
            this.Enter += CustomTextBox_Enter;
        }

        private void CustomTextBox_Enter(object sender, EventArgs e)
        {
            this.SelectAll();
        }
    }
}
