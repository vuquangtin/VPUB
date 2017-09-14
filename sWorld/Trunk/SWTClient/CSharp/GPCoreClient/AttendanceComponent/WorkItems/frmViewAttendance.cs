using CommonControls;
using CommonHelper.Constants;
using CommonHelper.Utils;
using JavaCommunication.Factory;
using Microsoft.Practices.CompositeUI;
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
using CommonHelper.Utils;

namespace AttendanceComponent.WorkItems
{
    public partial class frmViewAttendance : CommonControls.Custom.CommonDialog
    {
        #region Properties

        private long attendanceId;
        private BackgroundWorker bgwLoadAttendance;
        private Attendance attendance;
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

        public frmViewAttendance(long attendanceId)
        {
            InitializeComponent();
            this.attendanceId = attendanceId;

            bgwLoadAttendance = new BackgroundWorker();
            bgwLoadAttendance.WorkerSupportsCancellation = true;
            bgwLoadAttendance.DoWork += bgwLoadAttendance_DoWork;
            bgwLoadAttendance.RunWorkerCompleted += bgwLoadAttendance_Completed;
        }

        protected override void OnLoad(EventArgs e)
        {
            LoadAttendance();

            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }

        private void LoadAttendance() 
        {
            if (!bgwLoadAttendance.IsBusy)
            {
                bgwLoadAttendance.RunWorkerAsync();
            }
        }

        private void bgwLoadAttendance_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                attendance = AttendanceFoctory.Instance.GetChannel().GetAttendanceById(StorageService.CurrentSessionId, attendanceId);
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
        private void bgwLoadAttendance_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            ToAttendanceModel();
        }

        private void ToAttendanceModel() 
        {
            if (attendance != null) 
            {
                Member member = LoadMember(attendance.MemberId);
                SubOrganization subOrg = GetSubOrg(member.SubOrgId);
                tbxSerialNumber.Text = attendance.SerialNumber;
                tbxMemberCode.Text = member.Code;
                txtFullName.Text = member.GetFullName();
                tbxSubOrgName.Text = subOrg.orgcode;
                tbxPosition.Text = member.Position;

                lbDateTimeIn.Text = string.Format("Thời gian vào: {0}", attendance.DateIn);
                lbDateTimeOut.Text = string.Format("Thời gian ra: {0}", attendance.DateOut);

                picAttendanceIn.Image = string.IsNullOrEmpty(attendance.ImgIn)
                        ? global::AttendanceComponent.Properties.Resources.NoImage
                        : ImageUtils.Base64ToImage(attendance.ImgIn);

                picAttendanceOut.Image = string.IsNullOrEmpty(attendance.ImgOut)
                        ? global::AttendanceComponent.Properties.Resources.NoImage
                        : ImageUtils.Base64ToImage(attendance.ImgOut);
            }
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

        private SubOrganization GetSubOrg(long subOrgId)
        {
            SubOrganization subOrg = new SubOrganization();
            try
            {
                subOrg = OrganizationFactory.Instance.GetChannel().GetSubOrgById(StorageService.CurrentSessionId, subOrgId);
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
            return subOrg;
        }
    }
}
