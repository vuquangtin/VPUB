using AttendanceComponent.WorkItems;
using CommonControls;
using CommonControls.Custom;
using CommonHelper.Config;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using SMSGaywate;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace SystemMgtComponent.WorkItems
{
    public partial class frmSendSmsToContact : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private long[] MemberIdList;
        private bool IsSendSMSToMemberContact = false;
        private ResourceManager rm;

        private AttendanceWorkItem workItem;
        [ServiceDependency]
        public AttendanceWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService
        {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        public frmSendSmsToContact(long[] memberIdList)
        {
            InitializeComponent();
            MemberIdList = memberIdList;

            btnSendSMS.Click += btnSendSMS_Click;
        }

        #region Form Event's

        protected override void OnFormClosing(FormClosingEventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            LoadContactList();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private void btnSendSMS_Click(object sender, EventArgs e)
        {
            string phoneList = GetContactCheckedList();
            foreach (long memberId in MemberIdList)
            {
                Member member = LoadMember(memberId);
                if (IsSendSMSToMemberContact)
                    phoneList += "," + new String(member.PhoneNo.Where(Char.IsDigit).ToArray());
            }
            if (VHTSmsService.Instance.SendSmsToListPhone(phoneList, tbxSmsContent.Text.Trim())) 
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessSMSSuccess(rm, MessageValidate.SMS), MessageValidate.GetErrorTitle(rm));
            }
        }

        #endregion

        #region Event's Support

        private void LoadContactList()
        {
            lstContact.Items.Add(new ComboBoxItem
            {
                ValueMember = "True",
                DisplayMember = "Phụ Huynh",
            });

            string contactList = GroupSettings.Instance.MemberContact;
            if (contactList.Length > 0) 
            {
                String[] result = contactList.Split(',');
                foreach (String contact in result)
                {
                    string[] item = contact.Split('-');
                    if (item.Length > 0)
                    {
                        lstContact.Items.Add(new ComboBoxItem
                        {
                            ValueMember = new String(item.LastOrDefault().Where(Char.IsDigit).ToArray()),
                            DisplayMember = item.FirstOrDefault(),
                        });
                    }
                }
            }
        }

        private string GetContactCheckedList()
        {
            StringBuilder builder = new StringBuilder();
            foreach (object it in lstContact.CheckedItems)
            {
                ComboBoxItem item = it as ComboBoxItem;
                if(item.ValueMember.Equals("True"))
                {
                    IsSendSMSToMemberContact= true;
                    continue;
                }
                builder.AppendFormat("," + item.ValueMember);
            }

            return builder.ToString().Remove(0,1);
        }

        private Member LoadMember(long memberId)
        {
            Member member = new Member();
            if (memberId > 0)
            {
                try
                {
                    member = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, memberId);
                }
                catch (TimeoutException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.TimeOutExceptionMessage);
                    this.Hide();
                }
                catch (FaultException<WcfServiceFault> ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    this.Hide();
                }
                catch (FaultException ex)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.FaultExceptionMessage
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    this.Hide();
                }
                catch (CommunicationException)
                {
                    MessageBoxManager.ShowErrorMessageBox(this, CommonMessages.CommunicationExceptionMessage);
                    this.Hide();
                }
            }
            return member;
        }

        #endregion
    }
}
