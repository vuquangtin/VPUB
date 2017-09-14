using CommonHelper.Constants;
using sWorldModel;
using sWorldModel.Model;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Windows.Forms;
using UserMgtComponent.Constants;
using sWorldModel.TransportData;

namespace UserMgtComponent.WorkItems
{
    public class UserWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mnuUser, mnuListUser, mnuListLoginHistory, mnuAddUser, 
            mnuEditUser, mnuChangeGroup, mnuResetPassword, mnuLockUser, mnuUnLockUser, 
            mnuRemoveUser, mnuAddGroup, mnuEditGroup, mnuRemoveGroup;

        public UserWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            SessionDTO currentSession = storageService.GetObject(CacheKeyNames.CurrentSession) as SessionDTO;

            if (currentSession != null && currentSession.IsRoot)
            {
                AddUserMenuItems();
                EnableMenuItems(false);
                //SmartParts.AddNew<UsrUserMgtMain>(ComponentNames.UserMgtComponent);
                SmartParts.AddNew<UsrLoginHistory>(ComponentNames.LoginHistoryComponent);
            }
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            //UIExtensionSites.UnregisterSite(ExtensionSiteNames.UserMenu);
        }

        [EventSubscription(UserEventTopicNames.UserListShown)]
        public void OnUserListShown(object sender, EventArgs e)
        {
            EnableMenuItems(true);
        }

        [EventSubscription(UserEventTopicNames.UserListHide)]
        public void OnUserListHide(object sender, EventArgs e)
        {
            EnableMenuItems(false);
        }

        private void AddUserMenuItems()
        {
            InitMenuItem(ref mnuListUser, "Danh Sách Tài Khoản", UserCommandNames.ShowUserMgtMain);
            InitMenuItem(ref mnuListLoginHistory, "Lịch Sử Đăng Nhập", UserCommandNames.ShowLoginHistoryMain);
            InitMenuItem(ref mnuAddUser, "Thêm Tài Khoản...", UserCommandNames.AddUser);
            InitMenuItem(ref mnuEditUser, "Cập Nhật Thông Tin Cá Nhân...", UserCommandNames.UpdateUser);
            InitMenuItem(ref mnuChangeGroup, "Đổi Nhóm...", UserCommandNames.ChangeGroup);
            InitMenuItem(ref mnuResetPassword, "Cài Lại Mật Khẩu...", UserCommandNames.ResetPassword);
            InitMenuItem(ref mnuLockUser, "Khóa Tài Khoản...", UserCommandNames.LockUser);
            InitMenuItem(ref mnuUnLockUser, "Mở Khóa Tài Khoản...", UserCommandNames.UnLockUser);
            InitMenuItem(ref mnuRemoveUser, "Hủy Tài Khoản...", UserCommandNames.RemoveUser);
            InitMenuItem(ref mnuAddGroup, "Thêm Nhóm...", UserCommandNames.AddGroup);
            InitMenuItem(ref mnuEditGroup, "Cập Nhập Nhóm...", UserCommandNames.UpdateGroup);
            InitMenuItem(ref mnuRemoveGroup, "Hủy Nhóm...", UserCommandNames.RemoveGroup);
            InitMenuItem(ref mnuUser, "Tài Khoản", null);

            if (mnuUser.DropDownItems != null)
            {
                mnuUser.DropDownItems.Clear();
            }
            mnuUser.DropDownItems.AddRange(new ToolStripItem[]
                {
                    mnuListUser,
                    new ToolStripSeparator(),
                    mnuAddUser,
                    mnuEditUser,
                    mnuChangeGroup,
                    mnuResetPassword,
                    mnuLockUser,
                    mnuUnLockUser,
                    mnuRemoveUser,
                    new ToolStripSeparator(),
                    mnuAddGroup,
                    mnuEditGroup,
                    mnuRemoveGroup,
                    new ToolStripSeparator(),
                    mnuListLoginHistory,
                });

            UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mnuUser);
            //UIExtensionSites.RegisterSite(ExtensionSiteNames.UserMenu, mnuUser);
        }

        private void InitMenuItem(ref ToolStripMenuItem menuItem, string caption, string clickCommandName)
        {
            if (menuItem == null)
            {
                menuItem = new ToolStripMenuItem(caption);
                if (clickCommandName != null)
                {
                    Commands[clickCommandName].AddInvoker(menuItem, "Click");
                }
            }
        }

        private void EnableMenuItems(bool enabled)
        {
            mnuChangeGroup.Enabled = mnuEditUser.Enabled = mnuLockUser.Enabled = mnuResetPassword.Enabled = mnuUnLockUser.Enabled = mnuRemoveUser.Enabled = mnuEditGroup.Enabled = mnuRemoveGroup.Enabled = enabled;
        }
    }
}