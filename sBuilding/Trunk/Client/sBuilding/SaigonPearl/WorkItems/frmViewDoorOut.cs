using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using sWorldModel.Exceptions;
using sWorldModel.TransportData;
using System;
using System.ComponentModel;
using System.Resources;
using System.ServiceModel;

namespace sAccessComponent.WorkItems {
    public partial class frmViewDoorOut : CommonControls.Custom.CommonDialog {
        #region Properties

        private long doorOutId;
        private BackgroundWorker bgwLoadDoorOut;
        private DoorOut doorOut;
        private ResourceManager rm;

        private AccessComponentWorkItem workItem;
        [ServiceDependency]
        public AccessComponentWorkItem WorkItem {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;
        [ServiceDependency]
        public ILocalStorageService StorageService {
            get { return storageService; }
            set { storageService = value; }
        }

        #endregion

        public frmViewDoorOut(long attendanceId) {
            InitializeComponent();
            this.doorOutId = attendanceId;

            bgwLoadDoorOut = new BackgroundWorker();
            bgwLoadDoorOut.WorkerSupportsCancellation = true;
            bgwLoadDoorOut.DoWork += bgwLoaddoorOut_DoWork;
            bgwLoadDoorOut.RunWorkerCompleted += bgwLoaddoorOut_Completed;
        }

        protected override void OnLoad(EventArgs e) {
            LoaddoorOut();

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);

            // Set Language
            SetLanguage();
        }

        #region Set Language
        private void SetLanguage() {
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);
            this.lblTitleIO.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblTitleIO.Name);
            this.lblNoteIO.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblNoteIO.Name);
            this.lblInfoMemberIO.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblInfoMemberIO.Name);
            this.lblCardId.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblCardId.Name);
            this.lblMemberId.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblMemberId.Name);
            this.lblFullName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblFullName.Name);
            this.lblApartment.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblApartment.Name);
            this.lblPosition.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblPosition.Name);
            this.lblInfoImageIO.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblInfoImageIO.Name);
            this.lblDateTimeIn.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblDateTimeIn.Name);
            this.lblDateTimeOut.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.lblDateTimeOut.Name);
            this.btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.btnCancel.Name);
        }
        #endregion

        private void LoaddoorOut() {
            if (!bgwLoadDoorOut.IsBusy) {
                bgwLoadDoorOut.RunWorkerAsync();
            }
        }

        private void bgwLoaddoorOut_DoWork(object sender, DoWorkEventArgs e) {
            try {
                doorOut = AccessFactory.Instance.GetChannel().GetDoorOutById(StorageService.CurrentSessionId, doorOutId);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                this.Hide();
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                this.Hide();
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                this.Hide();
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                this.Hide();
            }
        }
        private void bgwLoaddoorOut_Completed(object sender, RunWorkerCompletedEventArgs e) {
            if (e.Cancelled) {
                return;
            }
            ToDoorOutModel();
        }

        private void ToDoorOutModel() {
            if (doorOut != null) {
                Member member = LoadMember(doorOut.MemberId);
                SubOrganization subOrg = GetSubOrg(member.SubOrgId);
                tbxSerialNumber.Text = doorOut.SerialNumber;
                tbxMemberCode.Text = member.Code;
                txtFullName.Text = member.GetFullName();
                tbxSubOrgName.Text = subOrg.names;
                tbxPosition.Text = member.Position;

                lblDateTimeIn.Text = string.Format("Thời gian vào: {0}", doorOut.DateIn);
                lblDateTimeOut.Text = string.Format("Thời gian ra: {0}", doorOut.DateOut);

                picAttendanceIn.Image = string.IsNullOrEmpty(doorOut.ImageIn)
                         ? global::sAccessComponent.Properties.Resources.NoImage
                         : ImageUtils.Base64ToImage(doorOut.ImageIn);

                picAttendanceOut.Image = string.IsNullOrEmpty(doorOut.ImageOut)
                        ? global::sAccessComponent.Properties.Resources.NoImage
                        : ImageUtils.Base64ToImage(doorOut.ImageOut);
            }
        }

        private Member LoadMember(long memberId) {
            Member member = new Member();
            if (memberId > 0) {
                try {
                    member = OrganizationFactory.Instance.GetChannel().GetMemberById(StorageService.CurrentSessionId, memberId);
                } catch (TimeoutException) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                    this.Hide();
                } catch (FaultException<WcfServiceFault> ex) {
                    MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                    this.Hide();
                } catch (FaultException ex) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                            + Environment.NewLine + Environment.NewLine
                            + ex.Message);
                    this.Hide();
                } catch (CommunicationException) {
                    MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                    this.Hide();
                }
            }
            return member;
        }

        private SubOrganization GetSubOrg(long subOrgId) {
            SubOrganization subOrg = new SubOrganization();
            try {
                subOrg = OrganizationFactory.Instance.GetChannel().GetSubOrgById(StorageService.CurrentSessionId, subOrgId);
            } catch (TimeoutException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
                this.Hide();
            } catch (FaultException<WcfServiceFault> ex) {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
                this.Hide();
            } catch (FaultException ex) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
                this.Hide();
            } catch (CommunicationException) {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
                this.Hide();
            }
            return subOrg;
        }
    }
}
