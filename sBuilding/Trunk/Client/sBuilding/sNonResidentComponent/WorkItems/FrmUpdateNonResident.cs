using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using CommonHelper.Utils;
using CommonControls;
using CommonHelper.Constants;
using System.Resources;
using System.ServiceModel;
using sWorldModel.Exceptions;
using JavaCommunication;
using sNonResidentComponent.Factory;
using sNonResidenComponent.WorkItems;
using sMeetingComponent.Model;
using sNonResidentComponent.Model.CustomObj.Statistic;
using sMeetingComponent.Constants;

namespace sNonResidentComponent.WorkItems
{
    public partial class FrmUpdateNonResident : CommonControls.Custom.CommonDialog
    {
        #region Properties
        private const string ORG_NAME_WORK_CONTACT = "-";

        bool isUpdateInfo = false;
        // User control này thông báo tin nhắn tự động tắt theo thời gian
        private UsrNotification usrNotification = null;
        private ConfigTime configTime;
        private Timer timer = null;
        private int time = 0;

        private NonResidentObj originalNonResident { get; set; }
        private NonResident AddOrUpdateNonResident;
        private NonResident nonResident;
        private DataTable dtbMeetingList;
        private DataTable dtbOrgList;
        private EventMeeting eventMeeting;

        private BackgroundWorker bgwUpdateNonResident;
        private BackgroundWorker bgwUpdateInfoNonResident;
        private BackgroundWorker bgwLoadMeetingList;
        public long meetingId = 0;

        private ResourceManager rm;
        public DialogPostAction PostAction { get; private set; }
        private NonResidentComponentWorkItem workItem;
        [ServiceDependency]
        public NonResidentComponentWorkItem WorkItem
        {
            set { workItem = value; }
        }

        private ILocalStorageService storageService;

        [ServiceDependency]
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
            set { storageService = value; }
        }
        #endregion

        #region Contructors
        public FrmUpdateNonResident(NonResidentObj originalNonResident, bool isupdate)
        {
            this.isUpdateInfo = isupdate;
            this.originalNonResident = originalNonResident;
            this.meetingId = originalNonResident.nonResident.meetingId;
            InitializeComponent();
            InitDataTableOrgList();
            InitDataTableMeetingList();

            RegisterEvent();

            #region usrNotification
            configTime = new ConfigTime();
            time = configTime.SetTime();

            usrNotification = new UsrNotification();
            usrNotification.Anchor = AnchorStyles.None;
            usrNotification.Visible = false;
            pnlParent.Controls.Add(usrNotification);
            usrNotification.Location = new Point(
                pnlParent.ClientSize.Width / 2 - usrNotification.Width / 2,
                pnlParent.ClientSize.Height / 2 - usrNotification.Height / 2);
            usrNotification.BringToFront();
            #endregion

        }
        /// <summary>
        /// RegisterEvent
        /// </summary>
        private void RegisterEvent()
        {
            CreateBackgroundWorkerEvent();
            btnConfirm.Click += OnButtonbtnOutPutClicked;
            //btnUpdateInfo.Click += btnUpdate_clicked;
            btnCancel.Click += OnButtonExitClicked;
            Load += OnFormLoad;

            tbxIdentityCard.KeyPress += tbxIdentityCard_KeyPress;
            tbxPhoneNumber.KeyPress += tbxPhoneNumber_KeyPress;
        }
        /// <summary>
        /// OnFormLoad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFormLoad(object sender, EventArgs e)
        {
            //    CustomTypeDate();
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
            this.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, this.Name);

            SetLanguages();
            LoadInfoNonResident(originalNonResident);
            LoadMeetingList();
            UpdateInfo(isUpdateInfo);
            SetupFontSizeDataGridView();
            KeyPreview = true;
        }
        /// <summary>
        /// SetupFontSizeDataGridView
        /// </summary>
        private void SetupFontSizeDataGridView()
        {
            // Font size data
            dgvMeetingList.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            dgvOrgList.DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Tahoma", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            // Font size header
            dgvMeetingList.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Tahoma", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };

            dgvOrgList.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Tahoma", 10.125F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
        }
        /// <summary>
        /// UpdateInfo
        /// </summary>
        /// <param name="isUpdate"></param>
        private void UpdateInfo(bool isUpdate)
        {
            //this.btnUpdateInfo.Enabled = isUpdate;
            //this.btnUpdateInfo.Visible = isUpdate;
            //this.btnConfirm.Enabled = !isUpdate;

            this.tbxFullName.Enabled =
                this.tbxCompany.Enabled =
                tbxPosition.Enabled =
                tbxIdentityCard.Enabled =
                tbxPhoneNumber.Enabled =
                rbtfemale.Enabled =
                rbtmale.Enabled = isUpdate;

        }
        /// <summary>
        /// CreateBackgroundWorkerEvent
        /// </summary>
        private void CreateBackgroundWorkerEvent()
        {
            //5:GET Lấy thông tin cuộc họp khách vãng lai tham dự họp
            bgwLoadMeetingList = new BackgroundWorker();
            bgwLoadMeetingList.WorkerSupportsCancellation = true;
            bgwLoadMeetingList.DoWork += OnLoadMeetingWorkerDoWork;
            bgwLoadMeetingList.RunWorkerCompleted += OnLoadMeetingWorkerCompleted;

            //6:UPDATE Cập nhật thời gian ra về
            bgwUpdateNonResident = new BackgroundWorker();
            bgwUpdateNonResident.WorkerSupportsCancellation = true;
            bgwUpdateNonResident.DoWork += OnLoadUpdateNonResidentWorkerDoWork;
            bgwUpdateNonResident.RunWorkerCompleted += OnLoadUpdateNonResidentRunWorkerCompleted;

            //7:UPDATE Cập nhật thông tin khách vãng lai
            bgwUpdateInfoNonResident = new BackgroundWorker();
            bgwUpdateInfoNonResident.WorkerSupportsCancellation = true;
            bgwUpdateInfoNonResident.DoWork += OnLoadUpdateInfoNonResidentWorkerDoWork;
            bgwUpdateInfoNonResident.RunWorkerCompleted += OnLoadUpdateInfoNonResidentRunWorkerCompleted;
        }
        #endregion

        #region Set Languages
        /// <summary>
        /// SetLanguages
        /// </summary>
        private void SetLanguages()
        {
            btnCancel.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnCancel.Name);
            //  btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnConfirm.Name);
            //btnUpdateInfo.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnUpdateInfo.Name);
            colMeetingDate.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colMeetingDate.Name);
            colMeetingName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colMeetingName.Name);
            colNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colNo.Name);
            colOrg.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colOrg.Name);
            colOrgName.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colOrgName.Name);
            colOrgNo.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colOrgNo.Name);
            colTimeStart.HeaderText = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, colTimeStart.Name);
            lblPassport.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblPassport.Name);
            lblCompany.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblCompany.Name);
            lblFullName.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblFullName.Name);
            lblGender.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblGender.Name);
            lblImageNonresident.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblImageNonresident.Name);
            lblImagenonresidentIdentitycard.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblImagenonresidentIdentitycard.Name);
            lblInfoNonResident.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblInfoNonResident.Name);
            lblMeetingInformation.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblMeetingInformation.Name);

            //chỉnh ngôn ngữ khi cập nhật thông tin, hoặc ra về khác nhau
            if (isUpdateInfo)
            {
                lblMessageExit.Text = MessageValidate.GetMessage(rm, "lblguideEnterUpdateInfoNonresident");
                btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnUpdateInfo.Name);
            }
            else
            {
                lblMessageExit.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblMessageExit.Name);
                btnConfirm.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, btnConfirm.Name);
            }

            lblPhoneNumber.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblPhoneNumber.Name);
            lblPosition.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblPosition.Name);
            lblReason.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, lblReason.Name);
            rbtfemale.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, rbtfemale.Name);
            rbtmale.Text = ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, rbtmale.Name);
        }
        #endregion

        #region Setting timer
        private void StartTimer()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Interval = time;
            timer.Tick += timer_Tick;
            timer.Start();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Close();
        }
        #endregion

        #region Set DataGridView Meeting
        /// <summary>
        /// InitDataTableMeetingList
        /// </summary>
        private void InitDataTableMeetingList()
        {
            dtbMeetingList = new DataTable();

            dtbMeetingList.Columns.Add(colNo.DataPropertyName);
            dtbMeetingList.Columns.Add(colOrg.DataPropertyName);
            dtbMeetingList.Columns.Add(colMeetingName.DataPropertyName);
            dtbMeetingList.Columns.Add(colMeetingDate.DataPropertyName);
            dtbMeetingList.Columns.Add(colTimeStart.DataPropertyName);

            dgvMeetingList.DataSource = dtbMeetingList;
        }
        #endregion

        #region Set DataGridView Org
        /// <summary>
        /// InitDataTableOrgList
        /// </summary>
        private void InitDataTableOrgList()
        {
            dtbOrgList = new DataTable();

            dtbOrgList.Columns.Add(colOrgNo.DataPropertyName);
            dtbOrgList.Columns.Add(colOrgName.DataPropertyName);

            dgvOrgList.DataSource = dtbOrgList;
        }
        #endregion

        #region Events
        /// <summary>
        /// show info nonresident
        /// </summary>
        /// <param name="originalNonResident"></param>
        private void LoadInfoNonResident(NonResidentObj originalNonResident)
        {
            if (originalNonResident != null)
            {
                nonResident = originalNonResident.nonResident;
                tbxFullName.Text = originalNonResident.nonResident.name;
                tbxCompany.Text = originalNonResident.nonResident.nonResidentOrganization;
                tbxPosition.Text = originalNonResident.nonResident.nonResidentPosition;
                //giới tính
                rbtmale.Checked = originalNonResident.nonResident.gender;
                rbtfemale.Checked = !originalNonResident.nonResident.gender;
                tbxIdentityCard.Text = originalNonResident.nonResident.identityCard;
                tbxPhoneNumber.Text = originalNonResident.nonResident.phonenumber;
                tbxReason.Text = originalNonResident.nonResident.note;

                if (originalNonResident.nonResident.meetingId == -1)
                {
                    // Lien he cong tac
                    DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(originalNonResident.nonResident.inputTime)).ToLocalTime();
                    int noNumber = 1;
                    // DataGridView Meeting
                    DataRow rowMeeting = dtbMeetingList.NewRow();
                    rowMeeting.BeginEdit();

                    // Add một dòng mới vào DataTable
                    rowMeeting[colNo.DataPropertyName] = noNumber;
                    rowMeeting[colOrg.DataPropertyName] = ORG_NAME_WORK_CONTACT;
                    rowMeeting[colMeetingName.DataPropertyName] = originalNonResident.nonResident.meetingName;
                    rowMeeting[colMeetingDate.DataPropertyName] = startDate.ToString("dd'/'MM'/'yyyy");
                    rowMeeting[colTimeStart.DataPropertyName] = startDate.ToString("HH:mm");

                    rowMeeting.EndEdit();
                    dtbMeetingList.Rows.Add(rowMeeting);

                    // DataGridView Org
                    DataRow row = dtbOrgList.NewRow();
                    row.BeginEdit();

                    // Add một dòng mới vào DataTable
                    row[colOrgNo.DataPropertyName] = noNumber;
                    row[colOrgName.DataPropertyName] = originalNonResident.nonResident.orgName;

                    row.EndEdit();
                    dtbOrgList.Rows.Add(row);
                }

                #region image
                Image imageResult = sNonResidentComponent.Properties.Resources.noimage;
                if (originalNonResident.dataImageFace != null)
                {
                    if (!originalNonResident.dataImageFace.Equals(""))
                    {

                        imageResult = Base64ToImage(originalNonResident.dataImageFace);

                    }

                }
                picMember.Image = imageResult;
                picMember.SizeMode = PictureBoxSizeMode.StretchImage;
                //hình cmnd
                Image imageResultIdentityCard = Properties.Resources.noimage;
                if (originalNonResident.dataImageIdentityCard != null)
                {
                    if (!originalNonResident.dataImageIdentityCard.Equals(""))
                    {
                        imageResultIdentityCard = Base64ToImage(originalNonResident.dataImageIdentityCard);
                    }
                }
                picMemberIdentityCard.Image = imageResultIdentityCard;
                picMemberIdentityCard.SizeMode = PictureBoxSizeMode.StretchImage;
                #endregion

            }
            else
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "smsErrorOveriewInfoCard"))));
                StartTimer();
            }
        }
        /// <summary>
        /// load info meeting 
        /// </summary>
        /// <param name="evenMeeting"></param>
        private void LoadDataMeeting(EventMeeting evenMeeting)
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            DateTime startDate = start.AddMilliseconds(Convert.ToUInt64(evenMeeting.startTime)).ToLocalTime();
            int noNumber = 1;

            DataRow row = dtbMeetingList.NewRow();
            row.BeginEdit();

            // Add một dòng mới vào DataTable
            row[colNo.DataPropertyName] = noNumber;
            row[colOrg.DataPropertyName] = originalNonResident.nonResident.orgName;
            row[colMeetingName.DataPropertyName] = originalNonResident.nonResident.meetingName;
            row[colMeetingDate.DataPropertyName] = startDate.ToString("dd'/'MM'/'yyyy");
            row[colTimeStart.DataPropertyName] = startDate.ToString("HH:mm");

            row.EndEdit();
            dtbMeetingList.Rows.Add(row);
        }

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
        /// LoadMeetingList
        /// </summary>
        private void LoadMeetingList()
        {
            if (!bgwLoadMeetingList.IsBusy)
            {
                bgwLoadMeetingList.RunWorkerAsync();
            }
        }

        private void OnButtonbtnOutPutClicked(object sender, EventArgs e)
        {
            PutIn();
        }
        /// <summary>
        /// click btn putin
        /// </summary>
        private void PutIn()
        {
            //nếu cập nhật thì gọi cập nhật thông tin
            if (isUpdateInfo)
            {
                if (!bgwUpdateInfoNonResident.IsBusy)
                {
                    AddOrUpdateNonResident = ToEntity();
                    bgwUpdateInfoNonResident.RunWorkerAsync();
                }
                //if (!bgwUpdateNonResident.IsBusy)
                //{
                //    AddOrUpdateNonResident = ToEntity();
                //    bgwUpdateInfoNonResident.RunWorkerAsync();
                //}
            }
            else
            {
                //hoặc cho ra về
                if (!bgwUpdateNonResident.IsBusy)
                {
                    AddOrUpdateNonResident = ToEntity();
                    bgwUpdateNonResident.RunWorkerAsync();
                }
            }
        }

        //private void btnUpdate_clicked(object sender, EventArgs e)
        //{
        //    if (!bgwUpdateNonResident.IsBusy)
        //    {
        //        AddOrUpdateNonResident = ToEntity();
        //        bgwUpdateInfoNonResident.RunWorkerAsync();
        //    }
        //}

        private void OnButtonExitClicked(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// toentity
        /// </summary>
        /// <returns></returns>
        private NonResident ToEntity()
        {
            DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            NonResident nonResidentItem = new NonResident();
            nonResidentItem = nonResident;

            if (isUpdateInfo)
            {
                nonResidentItem.name = this.tbxFullName.Text;
                nonResidentItem.identityCard = this.tbxIdentityCard.Text;
                nonResidentItem.phonenumber = this.tbxPhoneNumber.Text;

                nonResidentItem.nonResidentOrganization = this.tbxCompany.Text;
                nonResidentItem.nonResidentPosition = this.tbxPosition.Text;


                nonResidentItem.gender = this.rbtmale.Checked;

                try
                {
                    DateTime dtOutPutStr = start.AddMilliseconds(Convert.ToUInt64(nonResident.outputTime)).ToLocalTime();
                    nonResidentItem.outputTime = dtOutPutStr.ToString("yyyy-MM-dd HH:mm:ss");
                }
                catch (Exception e)
                {
                    nonResidentItem.outputTime = nonResident.outputTime;
                }


            }
            else
            {
                DateTime dateTime = DateTime.Now;
                String dtOutPutStr = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                nonResidentItem.outputTime = dtOutPutStr;
            }
            try
            {
                DateTime inputTime = start.AddMilliseconds(Convert.ToUInt64(nonResident.inputTime)).ToLocalTime();
                nonResidentItem.inputTime = inputTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception e)
            {
                nonResidentItem.inputTime = nonResident.inputTime;
            }
            nonResidentItem.note = tbxReason.Text;

            return nonResidentItem;
        }
        /// <summary>
        /// keypress : only make-a-textbox-that-only-accepts-numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxIdentityCard_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }
        /// <summary>
        /// keypress : only make-a-textbox-that-only-accepts-numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }
        /// <summary>
        /// register key f10 key escape
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (msg.WParam.ToInt32() == (int)Keys.F10)
            {
                PutIn();

            }
            if (msg.WParam.ToInt32() == (int)Keys.Escape)
            {
                Close();
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            return false;
        }


        #endregion

        #region Background Worker
        /// <summary>
        /// OnLoadMeetingWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadMeetingWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = eventMeeting = MeetingEventFactory.Instance.GetChannel().getEventMeetingById(StorageService.CurrentSessionId, meetingId);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }

        }

        /// <summary>
        /// OnLoadMeetingWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadMeetingWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                return;
            }
            if (e.Result == null)
            {
                return;
            }
            else
            {
                LoadDataMeeting(eventMeeting);
            }
        }

        /// <summary>
        /// update timeout of nonresident
        ///OnLoadUpdateNonResidentWorkerDoWork
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadUpdateNonResidentWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = (int)Status.SUCCESS == NonResidentFactory.Instance.GetChannel().updateNonResidentBySerialnumberAndDateTime(storageService.CurrentSessionId, AddOrUpdateNonResident);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }

        /// <summary>
        /// OnLoadUpdateNonResidentRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadUpdateNonResidentRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bool checkout = (bool)e.Result;
            if (e.Cancelled)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsErrorUpdateTimeNonResidentRetry"))));
                return;
            }
            if (checkout)
            {
                //Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "smsSuccessUpdateNonResident"))));
                PostAction = DialogPostAction.SUCCESS;
                UsrAddNonResident.getStatus(1);
                this.Close();
            }
            else
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsErrorUpdateTimeNonResidentRetry"))));
                return;
            }
        }

        /// <summary>
        /// update  info nonresident
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadUpdateInfoNonResidentWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = NonResidentFactory.Instance.GetChannel().updateInfoNonResident(storageService.CurrentSessionId, AddOrUpdateNonResident);
            }
            catch (TimeoutException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "TimeOutExceptionMessage"));
            }
            catch (FaultException<WcfServiceFault> ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, ErrorCodes.GetErrorMessage(ex.Detail.Code));
            }
            catch (FaultException ex)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "FaultExceptionMessage")
                        + Environment.NewLine + Environment.NewLine
                        + ex.Message);
            }
            catch (CommunicationException)
            {
                MessageBoxManager.ShowErrorMessageBox(this, MessageValidate.GetMessage(rm, "CommunicationExceptionMessage"));
            }
        }


        /// <summary>
        /// OnLoadUpdateInfoNonResidentRunWorkerCompleted
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLoadUpdateInfoNonResidentRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsErrorUpdateInfoNonResidentRetry"))));
                return;
            }
            if (e.Result != null)
            {
                // Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Succeed, MessageValidate.GetMessage(rm, "smsSuccessUpdateInfoNonResident"))));
                PostAction = DialogPostAction.SUCCESS;
                UsrAddNonResident.getStatus(2);
                this.Close();
            }
            else
            {
                Invoke(new Action(() => usrNotification.ShowMessage(NotificationType.Failed, MessageValidate.GetMessage(rm, "SmsErrorUpdateInfoNonResidentRetry"))));
                return;
            }
        }
        #endregion

    }
}
