using CommonControls.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PersoMgtComponent.WorkItems
{
    public sealed partial class FrmConfirmChangeStatus : CommonControls.Custom.CommonDialog
    {
        private static FrmConfirmChangeStatus instance = null;

        public const byte Lock = 1;
        public const byte Unlock = 2;
        public const byte Cancel = 3;

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
                    lblConfimMessage.Text = "Bạn có chắc muốn khóa (các) lượt phát hành này không?";
                    break;
                case Unlock:
                    lblConfimMessage.Text = "Bạn có chắc muốn mở khóa (các) lượt phát hành này không?";
                    break;
                case Cancel:
                    lblConfimMessage.Text = "Bạn có chắc muốn hủy (các) lượt phát hành này không?";
                    break;
                default:
                    throw new ArgumentException("Action type is invalid!");
            }
        }
    }
}
