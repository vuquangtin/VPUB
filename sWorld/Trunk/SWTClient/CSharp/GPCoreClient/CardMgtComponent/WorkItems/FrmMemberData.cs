using CommonControls.Custom;
using System;
using System.Collections.Specialized;
using System.Text;

namespace CardMgtComponent.WorkItems
{
    public sealed partial class FrmMemberData : CommonDialog
    {
        private static FrmMemberData instance;

        private FrmMemberData()
        {
            InitializeComponent();
            btnClose.Click += btnClose_Click;
        }

        public static FrmMemberData Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FrmMemberData();
                }
                else
                {
                    instance.ResetAllFields();
                }
                return instance;
            }
        }

        public StringCollection CardData
        {
            set
            {
                StringBuilder sb = new StringBuilder();
                int count = value.Count;
                
                // School name
                sb.Append(value[0]);
                sb.Append(Environment.NewLine);

                // Faculty name
                if (value[1].Length > 0)
                {
                    if (!value[1].StartsWith("Khoa", StringComparison.CurrentCultureIgnoreCase)
                    && !value[1].StartsWith("Phòng", StringComparison.CurrentCultureIgnoreCase))
                    {
                        value[1] = "Khoa " + value[2];
                    }
                    sb.Append(value[1]);
                    sb.Append(Environment.NewLine);
                }
                // Department name
                if (!value[1].Equals(value[2], StringComparison.CurrentCultureIgnoreCase))
                {
                    if (!value[2].StartsWith("Bộ môn", StringComparison.CurrentCultureIgnoreCase)
                    && !value[2].StartsWith("Phòng", StringComparison.CurrentCultureIgnoreCase))
                    {
                        value[2] = "Bộ Môn " + value[2];
                    }
                    sb.Append(value[2]);
                    sb.Append(Environment.NewLine);
                }

                // Title
                if (value[3].Length > 0)
                {
                    sb.Append(value[3]);
                    sb.Append(". ");
                }
                // Degree
                if (value[4].Length > 0 && !value[4].Equals(value[3]))
                {
                    sb.Append(value[4]);
                    sb.Append(". ");
                }
                // Full name
                sb.Append(value[8]);
                sb.Append(Environment.NewLine);

                // Position
                if (value[5].Length > 0)
                {
                    sb.Append(value[5]);
                    sb.Append(Environment.NewLine);
                }
                else if (value[6].Length > 0)
                {
                    sb.Append(value[6]);
                    sb.Append(Environment.NewLine);
                }
                
                // Teacher code
                if (value[7].Length > 0)
                {
                    sb.Append("SHCC: ");
                    sb.Append(value[7]);
                    sb.Append(Environment.NewLine);
                }

                lblDataOnCard.Text = sb.ToString();
                this.TopLevel = true;
            }
        }

        public string SerialNumberHex
        {
            set
            {
                lblSerialNumber.Text = string.Format("Mã Thẻ: {0}", value);
            }
        }

        public bool HideAfterCardRemoved
        {
            get
            {
                return cbxHideAfterTagRemoved.Checked;
            }
        }

        private void ResetAllFields()
        {
            lblDataOnCard.Text = string.Empty;
            lblSerialNumber.Text = "Mã Thẻ:";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void FrmMemberData_Load(object sender, EventArgs e)
        {

        }
    }
}
