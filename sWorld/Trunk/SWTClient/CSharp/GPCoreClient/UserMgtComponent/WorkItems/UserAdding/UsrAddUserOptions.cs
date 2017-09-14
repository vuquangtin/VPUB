using System;
using System.Windows.Forms;
using CommonControls.Custom;
using CommonControls;

namespace UserMgtComponent.WorkItems.UserAdding
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
    }
}
