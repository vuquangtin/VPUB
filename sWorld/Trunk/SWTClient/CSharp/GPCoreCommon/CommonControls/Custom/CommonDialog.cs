using System.Drawing;
using System.Windows.Forms;

namespace CommonControls.Custom
{
    public class CommonDialog : Form
    {
        public CommonDialog()
        {
            InitializeComponent();

            this.BackColor = DefaultStyle.PanelBackColor;
            this.ForeColor = DefaultStyle.PanelForeColor;
            this.Font = DefaultStyle.PanelFont;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomDialog
            // 
            //this.ClientSize = new System.Drawing.Size(292, 273);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }
    }
}
