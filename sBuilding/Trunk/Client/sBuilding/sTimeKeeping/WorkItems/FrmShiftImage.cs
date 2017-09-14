using Microsoft.Practices.CompositeUI;
using sTimeKeeping.Factory;
using sTimeKeeping.Model;
using sWorldModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sTimeKeeping.WorkItems
{
    /// <summary>
    /// class FrmShiftImage : CommonControls.Custom.CommonDialog
    /// </summary>
    public partial class FrmShiftImage : CommonControls.Custom.CommonDialog
    {
        private long shiftId;

        /// <summary>
        /// workItem
        /// </summary>
        private TimeKeepingComponentWorkItem workItem;
        [ServiceDependency]
        public TimeKeepingComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;

        /// <summary>
        /// StorageService
        /// </summary>
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
        /// contructor FrmShiftImage
        /// </summary>
        /// <param name="shiftId"></param>
        public FrmShiftImage(long shiftId)
        {
            this.shiftId = shiftId;
            InitializeComponent();
        }

        /// <summary>
        /// Init PKB
        /// </summary>
        /// <param name="shiftId"></param>
        private void InitPKB(long shiftId)
        {
            PictureBox pkb = new PictureBox();
            pkb.Height = 300;
            pkb.Width = 400;
            pkb.Image = SetImage(shiftId);
            this.Controls.Add(pkb);
        }

        /// <summary>
        /// Set Image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private Image SetImage(long id)
        {
            Image result ;
            try
            {
                TimeKeepingImage results = TimeKeepingShiftFactory.Instance.GetChannel().getShiftImageByShiftId(StorageService.CurrentSessionId, id);
                
                //Console.WriteLine("@results hinh:   " + results.image.ToString());
                // Base64ToImage
                result = Base64ToImage(results.image);
               
            }
            catch (Exception e)
            {
                //Console.WriteLine("@results hinh:   " + e.Message.ToString()); 
                // gan result = noimage
                result = sTimeKeeping.Properties.Resources.noimage;

            }
            return result;
        }

        /// <summary>
        /// Base64 To Image
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

        /// <summary>
        /// load form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmShiftImage_Load(object sender, EventArgs e)
        {
            InitPKB(shiftId);
        }
    }
}
