using CommonControls.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace CardMgtComponent.WorkItems
{
    public sealed partial class FrmConfirmChangeStatus : CommonControls.Custom.CommonDialog
    {
        private static FrmConfirmChangeStatus instance = null;

        private ResourceManager rm;

        public const byte Normal = 0;
        public const byte Cancel = 1;
        public const byte Lock = 2;
        public const byte UnLock = 3;
        public static int Extend=4;
        public const byte Broken = 5;
        public const byte UnBroken = 6;
        public const byte Lost = 7;
        public const byte UnLost = 8;  

        private FrmConfirmChangeStatus()
        {
            InitializeComponent();
        }

        public static FrmConfirmChangeStatus GetInstance(byte actionType, ResourceManager rm)
        {
            if (instance == null)
            {
                instance = new FrmConfirmChangeStatus();
            }
            instance.UpdateView(actionType,rm);
            instance.tbxReason.Text = string.Empty;
            return instance;
        }

        public string Reason
        {
            get
            {
                return tbxReason.Text.Trim();
            }
        }

        private void UpdateView(byte actionType, ResourceManager rm)
        {
            switch(actionType)
            {
                case Lock:
                    lblConfimMessage.Text = "Bạn có chắc muốn khóa (các) lượt phát hành này không?";
                    break;
                case UnLock:
                    lblConfimMessage.Text = "Bạn có chắc muốn mở khóa (các) lượt phát hành này không?";
                    break;
                case Cancel:
                    lblConfimMessage.Text = "Bạn có chắc muốn hủy (các) lượt phát hành này không?";
                    break;
                //case Extend:
                //    lblConfimMessage.Text = "Bạn có chắc muốn khóa (các) lượt phát hành này không?";
                //    break;
                case Broken:
                    lblConfimMessage.Text = "Bạn có chắc muốn đánh dấu thẻ hư?";
                    break;
                case UnBroken:
                    lblConfimMessage.Text = "Bạn có chắc muốn hủy đánh dấu thẻ hư?";
                    break;
                case Lost:
                    lblConfimMessage.Text = "Bạn có chắc muốn đánh dấu mất thẻ?";
                    break;
                case UnLost:
                    lblConfimMessage.Text = "Bạn có chắc muốn hủy đánh dấu mất thẻ?";
                    break;

                default:
                    throw new ArgumentException("Action type is invalid!");
            }
        }
    }
}
