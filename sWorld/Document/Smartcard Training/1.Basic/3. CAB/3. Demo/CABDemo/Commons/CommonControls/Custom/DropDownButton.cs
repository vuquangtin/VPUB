using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommonControls.Custom
{
    public partial class DropDownButton : Button
    {
        int currentScreenHeight;
        Point popupMenuLocation;

        public DropDownButton()
        {
            InitializeComponent();

            this.TextAlign = ContentAlignment.MiddleLeft;
            this.ImageAlign = ContentAlignment.MiddleRight;
            //this.Image = global::CommonControls.Properties.Resources.ArrowDown1_16x16;
            this.Font = new System.Drawing.Font("Tahoma", (float)9.75);

            currentScreenHeight = Screen.FromControl(this).Bounds.Height;
            this.Click += new EventHandler(ClickedEventHandler);
        }

        public void AddItem(string text, EventHandler itemClicked_Handler)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Text = text;
            item.Click += itemClicked_Handler;
            popupMenu.Items.Add(item);
        }

        private void ClickedEventHandler(object sender, EventArgs e)
        {
            bool isEnoughSpace = currentScreenHeight - this.Parent.PointToScreen(this.Location).Y 
                - this.Height > popupMenu.Height;

            if (isEnoughSpace)
            {
                popupMenuLocation = this.Parent.PointToScreen(new Point(this.Left, this.Bottom));
            }
            else
            {
                popupMenuLocation = this.Parent.PointToScreen(new Point(this.Left, this.Top - popupMenu.Height));
            }

            popupMenu.Show(popupMenuLocation);
        }
    }
}
