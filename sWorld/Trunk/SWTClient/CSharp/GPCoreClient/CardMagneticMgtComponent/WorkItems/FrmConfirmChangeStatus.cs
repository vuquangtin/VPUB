using CommonControls.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardMagneticMgtComponent.WorkItems
{
    public sealed partial class FrmConfirmChangeStatus : CommonControls.Custom.CommonDialog
    {
        private static FrmConfirmChangeStatus instance = null;

        public const byte Normal = 1;
        public const byte Broken = 2;
        public const byte Lost = 3;
        public const byte Lock = 4;
        public const byte Cancel = 5;
        public const byte Expired = 6;
        public const byte Printed = 7;
        public const byte NoPrinted = 8;
        public const byte Actived = 9;
        public const byte DeActived = 10;
        //public const byte UnLock = 11;
        //public const byte UnLost = 12;
        //public const byte UnBroken = 13;

        private FrmConfirmChangeStatus()
        {
            InitializeComponent();
        }

        public static FrmConfirmChangeStatus GetInstance(byte actionType)
        {
            if (instance == null)
            {
                instance = new FrmConfirmChangeStatus();
            }
            instance.UpdateView(actionType);
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

        private void UpdateView(byte actionType)

        {
            switch(actionType)
            {
                case Lock:
                    lblConfimMessage.Text = "Bạn có chắc muốn khóa thẻ này không?";
                    break;
                //case UnLock:
                //    lblConfimMessage.Text = "Bạn có chắc muốn mở khóa này không?";
                //    break;
                case Cancel:
                    lblConfimMessage.Text = "Bạn có chắc muốn hủy (các) lượt phát hành này không?";
                    break;
                //case Extend:
                //    lblConfimMessage.Text = "Bạn có chắc muốn khóa (các) lượt phát hành này không?";
                //    break;
                case Broken:
                    lblConfimMessage.Text = "Bạn có chắc muốn đánh dấu thẻ hư?";
                    break;
                //case UnBroken:
                //    lblConfimMessage.Text = "Bạn có chắc muốn hủy đánh dấu thẻ hư?";
                //    break;
                case Lost:
                    lblConfimMessage.Text = "Bạn có chắc muốn đánh dấu mất thẻ?";
                    break;
                //case UnLost:
                //    lblConfimMessage.Text = "Bạn có chắc muốn hủy đánh dấu mất thẻ?";
                //    break;
                case Expired:
                    lblConfimMessage.Text = "Bạn có chắc muốn đánh dấu hết hạn thẻ này không?";
                    break;
                case Printed:
                    lblConfimMessage.Text = "Bạn có chắc muốn đánh dấu đã in thẻ này không?";
                    break;
                case NoPrinted:
                    lblConfimMessage.Text = "Bạn có chắc muốn đánh dấu chưa in thẻ này không?";
                    break;

                default:
                    lblConfimMessage.Text = "Bạn có chắc muốn đưa thẻ về trạng thái bình thường không?";
                    break;
                 //   throw new ArgumentException("Action type is invalid!");
            }
        }
    }
}
