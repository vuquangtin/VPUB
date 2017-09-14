using System;
using System.Windows.Forms;

namespace CommonControls.Custom
{
    public class CommonToolStrip : ToolStrip
    {
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem btnShowIconOnly;
        private ToolStripMenuItem btnShowTextOnly;
        private ToolStripMenuItem btnShowIconAndText;

        public CommonToolStrip()
        {
            this.btnShowIconOnly = new ToolStripMenuItem();
            this.btnShowIconOnly.Name = "btnShowIconOnly";
            this.btnShowIconOnly.Size = new System.Drawing.Size(231, 22);
            this.btnShowIconOnly.Text = "Chỉ Hiện Biểu Tượng";
            this.btnShowIconOnly.Checked = true;

            this.btnShowTextOnly = new ToolStripMenuItem();
            this.btnShowTextOnly.Name = "btnShowTextOnly";
            this.btnShowTextOnly.Size = new System.Drawing.Size(231, 22);
            this.btnShowTextOnly.Text = "Chỉ Hiện Tiêu Đề";

            this.btnShowIconAndText = new ToolStripMenuItem();
            this.btnShowIconAndText.Name = "btnShowIconAndText";
            this.btnShowIconAndText.Size = new System.Drawing.Size(231, 22);
            this.btnShowIconAndText.Text = "Hiện Biểu Tượng Và Tiêu Đề";

            this.contextMenu = new ContextMenuStrip();
            this.contextMenu.SuspendLayout();
            this.contextMenu.Items.AddRange(new ToolStripItem[] {
            this.btnShowIconOnly,
            this.btnShowTextOnly,
            this.btnShowIconAndText});
            this.contextMenu.Name = "contextMenuStrip1";
            this.contextMenu.Size = new System.Drawing.Size(232, 92);
            this.contextMenu.ResumeLayout(false);

            this.MouseClick += CustomToolStrip_MouseClick;
            this.btnShowIconOnly.Click += btnShowIconOnly_Click;
            this.btnShowTextOnly.Click += btnShowTextOnly_Click;
            this.btnShowIconAndText.Click += btnShowIconAndText_Click;
        }

        public CommonToolStrip(ToolStripItemDisplayStyle style) : base()
        {
            ChangeDisplayStyle(style);
        }

        private void CustomToolStrip_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(this, e.Location);
            }
        }

        private void btnShowIconOnly_Click(object sender, EventArgs e)
        {
            btnShowIconOnly.Checked = true;
            btnShowTextOnly.Checked = false;
            btnShowIconAndText.Checked = false;
            ChangeDisplayStyle(ToolStripItemDisplayStyle.Image);
        }

        private void btnShowTextOnly_Click(object sender, EventArgs e)
        {
            btnShowIconOnly.Checked = false;
            btnShowTextOnly.Checked = true;
            btnShowIconAndText.Checked = false;
            ChangeDisplayStyle(ToolStripItemDisplayStyle.Text);
        }

        private void btnShowIconAndText_Click(object sender, EventArgs e)
        {
            btnShowIconOnly.Checked = false;
            btnShowTextOnly.Checked = false;
            btnShowIconAndText.Checked = true;
            ChangeDisplayStyle(ToolStripItemDisplayStyle.ImageAndText);
        }

        private void ChangeDisplayStyle(ToolStripItemDisplayStyle style)
        {
            foreach (ToolStripItem item in Items)
            {
                item.DisplayStyle = style;
            }
            switch(style)
            {
                case ToolStripItemDisplayStyle.Image:
                    btnShowIconOnly.Checked = true;
                    break;
                case ToolStripItemDisplayStyle.ImageAndText:
                    btnShowIconAndText.Checked = true;
                    break;
                case ToolStripItemDisplayStyle.None:
                    break;
                case ToolStripItemDisplayStyle.Text:
                    btnShowTextOnly.Checked = true;
                    break;
                default:
                    break;
            }
        }
    }
}