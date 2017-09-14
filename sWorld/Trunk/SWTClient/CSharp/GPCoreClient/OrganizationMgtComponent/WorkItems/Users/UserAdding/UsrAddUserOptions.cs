using System;
using System.Windows.Forms;
using CommonControls.Custom;
using CommonControls;
using System.Resources;
using Microsoft.Practices.CompositeUI;
using sWorldModel;
using CommonHelper.Constants;
using CommonHelper.Utils;

namespace SystemMgtComponent.WorkItems.UserAdding
{
    public partial class UsrAddUserOptions : CommonUserControl, IUserAddingDialog
    {
        private DialogPostAction chosenAction = DialogPostAction.NONE;
        public DialogPostAction PostAction
        {
            get { return chosenAction; }
        }

        public Button AcceptButton
        {
            get { return btnCreateNew; }
        }

        public Button CancelButton
        {
            get { return btnCancel; }
        }

        private bool isCreateNew;
        public object[] ReturnData
        {
            get { return new object[] { isCreateNew }; }
        }
        private ResourceManager rm;

        private WorkItem rootWorkItem;
        private ILocalStorageService storageService;

        [ServiceDependency]
        public WorkItem RootWorkItem
        {
            set { rootWorkItem = value; }
        }

        public ILocalStorageService StorageService
        {
            get
            {
                if (storageService == null)
                {
                    storageService = rootWorkItem.Services.Get<ILocalStorageService>();
                }
                return storageService;
            }
        }

        public event EventHandler StepCompleted;

        public UsrAddUserOptions()
        {
            InitializeComponent();
        }

        private void OnButtonCancelClicked(object sender, EventArgs e)
        {
            chosenAction = DialogPostAction.CANCEL;
            if (StepCompleted != null)
            {
                StepCompleted(this, EventArgs.Empty);
            }
        }

        private void OnButtonCreateNewClicked(object sender, EventArgs e)
        {
            isCreateNew = true;
            chosenAction = DialogPostAction.NEXT;
            if (StepCompleted != null)
            {
                StepCompleted(this, EventArgs.Empty);
            }
        }

        private void OnButtonUseExistingClicked(object sender, EventArgs e)
        {
            isCreateNew = false;
            chosenAction = DialogPostAction.NEXT;
            if (StepCompleted != null)
            {
                StepCompleted(this, EventArgs.Empty);
            }
        }

        private void UsrAddUserOptions_Load(object sender, EventArgs e)
        {
            rm = StorageService.GetObject(CacheKeyNames.Languages) as ResourceManager;
            ResoucreLanguagesUtils.Instance.SetResoucreLanguages(this.Controls, rm);
        }
    }
}
