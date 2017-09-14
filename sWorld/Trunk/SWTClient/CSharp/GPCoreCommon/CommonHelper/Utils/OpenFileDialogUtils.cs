using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CommonHelper.Utils
{
    public class OpenFileDialogUtils
    {

        public static Image SelectImageDialog()
        {
            Image img = null;
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                DialogResult result = fileDialog.ShowDialog();
                fileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
                if (result == DialogResult.OK)
                {
                    img = new Bitmap(fileDialog.FileName);
                }
                return img;
            }
            catch (Exception ex) 
            {
                return img;
            }
        }
    }
}
