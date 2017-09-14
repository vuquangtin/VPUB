using CommonControls;
using System;
using System.Windows.Forms;

namespace UserMgtComponent.WorkItems.UserAdding
{
    interface IUserAddingDialog
    {
        DialogPostAction PostAction { get; }

        Button AcceptButton { get; }

        Button CancelButton { get; }

        object[] ReturnData { get; }

        event EventHandler StepCompleted;
    }
}