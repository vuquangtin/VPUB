using CommonControls.Custom;
using CommonHelper.Constants;
using CommonHelper.Utils;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using System;
using System.Collections.Specialized;
using System.Resources;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CommonControls;

namespace CardChipMgtComponent.WorkItems
{
    public sealed partial class FrmShowMemberData : CommonDialog
    {
        private static FrmShowMemberData instance;
        public ResourceManager rm { get; set; }

        private FrmShowMemberData()
        {
            InitializeComponent();
            btnClose.Click += btnClose_Click;
        }

        public static FrmShowMemberData Instance
        {
            get
            {
                if (instance == null || instance.IsDisposed)
                {
                    instance = new FrmShowMemberData();
                }
                else
                {
                    instance.ResetAllFields();
                }
                return instance;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = MessageValidate.GetMessage(rm, this.Name);
        }
        public String CardDataJson
        {
            set
            {
                try { 
                    JObject memberObj = JObject.Parse(value);
                    txtMember.Clear();
                    string orgName = (string)memberObj["ON"];
                    if (null != orgName && "" != orgName)
                        txtMember.AppendText(MessageValidate.GetMessage(rm, "show_orgname") + orgName + Environment.NewLine);

                    string memberCode = (string)memberObj["M"];
                    if (null != memberCode && "" != memberCode)
                        txtMember.AppendText(MessageValidate.GetMessage(rm, "show_member_code") + memberCode + Environment.NewLine);

                    string memberName = (string)memberObj["N"];
                    if (null != memberName && "" != memberName)
                        txtMember.AppendText(MessageValidate.GetMessage(rm, "show_membername") + memberName + Environment.NewLine);

                    string cmnd = (string)memberObj["C"];
                    if (null != cmnd && "" != cmnd)
                        txtMember.AppendText(MessageValidate.GetMessage(rm, "show_cmnd") + cmnd + Environment.NewLine);

                    string birthday = (string)memberObj["B"];
                    if (null != birthday && "" != birthday)
                        txtMember.AppendText(MessageValidate.GetMessage(rm, "show_birthday") + birthday + Environment.NewLine);

                    string position = (string)memberObj["P"];
                    if (null != position && "" != position)
                        txtMember.AppendText(MessageValidate.GetMessage(rm, "show_position") + position + Environment.NewLine);

                    string tel = (string)memberObj["T"];
                    if (null != tel && "" != tel)
                        txtMember.AppendText(MessageValidate.GetMessage(rm, "show_tel") + tel);
                }
                catch(Exception e)
                {
                    txtMember.AppendText("Thẻ chưa được ghi thông tin");
                }


            }
        }
        /*
        public StringCollection CardData
        {
            set
            {
                StringBuilder sb = new StringBuilder();
                int count = value.Count;

                tbxMemberCode.Text = value[0];
                tbxFullName.Text = value[1];
                tbxSubOrgName.Text = value[2];
                tbxPosition.Text = value[3];
                tbxPhoneNo.Text = value[4];
                tbxEmail.Text = value[5];
                //tbxEmail.Text = value[6];

                this.TopLevel = true;
            }
        }
         * */

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
            //lblDataOnCard.Text = string.Empty;
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
