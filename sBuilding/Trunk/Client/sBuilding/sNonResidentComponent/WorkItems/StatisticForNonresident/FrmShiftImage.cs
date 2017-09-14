using Microsoft.Practices.CompositeUI;
using sNonResidenComponent.WorkItems;
using sWorldModel;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sNonResidentComponent.WorkItems.StatisticForNonresident
{
    public partial class FrmShiftImage : CommonControls.Custom.CommonDialog
    {
        private NonResidentComponentWorkItem workItem;
        [ServiceDependency]
        public NonResidentComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private string imageFace;
        private string imageIdentityCard;
        private System.Windows.Forms.Timer timer = null;

        private ILocalStorageService storageService;
        public ILocalStorageService StorageService
        {
            get
            {
                if (storageService == null)
                {
                    storageService = workItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }
        /// <summary>
        /// FrmShiftImage
        /// </summary>
        /// <param name="imageFace"></param>
        /// <param name="imageIdentityCard"></param>
        public FrmShiftImage(string imageFace, string imageIdentityCard)
        {
            InitializeComponent();
            this.imageFace = imageFace;
            this.imageIdentityCard = imageIdentityCard;
            string timerStr = "";
            int timerInt = 3000;

            try
            {
                timerStr = ConfigurationManager.AppSettings["timer"];
            }
            catch (Exception ex)
            {
            }
            if (null == timerStr || "" == timerStr)
            {
                timerInt = 3000;
            }
            else
            {
                timerInt = Convert.ToInt32(timerStr);
            }
            //  timerInt = timerInt * 2;
            //thời gian hình tự tắt
            timer = new System.Windows.Forms.Timer();
            timer.Interval = timerInt;
            timer.Tick += timer_Tick;
            timer.Start();
        }
        /// <summary>
        /// timer_Tick
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.Visible = false;
            timer.Stop();
        }
        /// <summary>
        /// ShowImage
        /// </summary>
        public void ShowImage()
        {
            Image imageResult = sNonResidentComponent.Properties.Resources.noimage;
            if (imageFace != null)
            {
                if (!imageFace.Equals(""))
                {
                    imageResult = Base64ToImage(imageFace);
                }
            }
            picMember.Image = imageResult;
            picMember.SizeMode = PictureBoxSizeMode.StretchImage;
            panel2.Controls.Add(picMember);
            //hình cmnd
            Image imageResultIdentityCard = sNonResidentComponent.Properties.Resources.noimage;
            if (imageIdentityCard != null)
            {
                if (!imageIdentityCard.Equals(""))
                {
                    imageResultIdentityCard = Base64ToImage(imageIdentityCard);
                }
            }
            picMemberIdentityCard.Image = imageResultIdentityCard;
            picMemberIdentityCard.SizeMode = PictureBoxSizeMode.StretchImage;
            panel3.Controls.Add(picMemberIdentityCard);
        }
        /// <summary>
        /// Base64ToImage
        /// </summary>
        /// <param name="base64String"></param>
        /// <returns></returns>
        private Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new System.IO.MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        private void FrmShiftImage_Load(object sender, EventArgs e)
        {
            ShowImage();
        }
    }
}
