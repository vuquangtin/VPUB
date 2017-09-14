using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Windows.Forms;
using PersoMgtComponent.Constants;
using System.Collections.Generic;
using sWorldModel;
using sWorldModel.Model;

namespace PersoMgtComponent.WorkItems
{
    public class PersoWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mnuPerso, mnuListPerso, mnuLockPerso, mnuUnLockPerso, mnuRemovePerso, mnuExtendPerso, mniMarkBroken, mniUnMarkBroken, mniMarkLost, mniUnMarkLost;
        private ToolStripSeparator separator1, separator2;

        public PersoWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AddPersoMenuItems();
            EnableMenuItems(false);
            SmartParts.AddNew<UsrPersoMgtMain>(ComponentNames.PersoMgtComponent);
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ExtensionSiteNames.PersoMenu);
        }

        private void AddPersoMenuItems()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<Function> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<Function>;

            mnuPerso = new ToolStripMenuItem("Lượt Phát Hành");

            if (permissions.Exists(e => e == Function.FUNC_PERSO_VIEW))
            {
                mnuListPerso = new ToolStripMenuItem("Danh Sách Lượt Phát Hành");
                Commands[PersoCommandNames.ShowPersoMgtMain].AddInvoker(mnuListPerso, "Click");
                mnuPerso.DropDownItems.Add(mnuListPerso);
            }

            if (permissions.Exists(e => e == Function.FUNC_PERSO_CHANGE_STATUS))
            {
                separator1 = new ToolStripSeparator();
                mnuPerso.DropDownItems.Add(separator1);

                mnuLockPerso = new ToolStripMenuItem("Khóa Lượt Phát Hành...");
                Commands[PersoCommandNames.LockPerso].AddInvoker(mnuLockPerso, "Click");
                mnuPerso.DropDownItems.Add(mnuLockPerso);

                mnuUnLockPerso = new ToolStripMenuItem("Mở Khóa Lượt Phát Hành...");
                Commands[PersoCommandNames.UnLockPerso].AddInvoker(mnuUnLockPerso, "Click");
                mnuPerso.DropDownItems.Add(mnuUnLockPerso);

                mnuRemovePerso = new ToolStripMenuItem("Hủy Lượt Phát Hành...");
                Commands[PersoCommandNames.CancelPerso].AddInvoker(mnuRemovePerso, "Click");
                mnuPerso.DropDownItems.Add(mnuRemovePerso);
            }
            if (permissions.Exists(e => e == Function.FUNC_PERSO_EXTEND))
            {
                if (separator1 == null)
                {
                    separator1 = new ToolStripSeparator();
                    mnuPerso.DropDownItems.Add(separator1);
                }

                mnuExtendPerso = new ToolStripMenuItem("Gia Hạn Lượt Phát Hành...");
                Commands[PersoCommandNames.ExtendPerso].AddInvoker(mnuExtendPerso, "Click");
                mnuPerso.DropDownItems.Add(mnuExtendPerso);
            }
            if (permissions.Exists(e => e == Function.FUNC_CARD_CHANGE_STATUS))
            {
                if (separator2 == null)
                {
                    separator2 = new ToolStripSeparator();
                    mnuPerso.DropDownItems.Add(separator2);
                }

                mniMarkBroken = new ToolStripMenuItem("Đánh Dấu Thẻ Bị Hư...");
                Commands[PersoCommandNames.MarkBroken].AddInvoker(mniMarkBroken, "Click");
                mnuPerso.DropDownItems.Add(mniMarkBroken);

                mniUnMarkBroken = new ToolStripMenuItem("Hủy Đánh Dấu Thẻ Bị Hư...");
                Commands[PersoCommandNames.UnMarkBroken].AddInvoker(mniUnMarkBroken, "Click");
                mnuPerso.DropDownItems.Add(mniUnMarkBroken);

                mniMarkLost = new ToolStripMenuItem("Đánh Dấu Thẻ Bị Mất...");
                Commands[PersoCommandNames.MarkLost].AddInvoker(mniMarkLost, "Click");
                mnuPerso.DropDownItems.Add(mniMarkLost);

                mniUnMarkLost = new ToolStripMenuItem("Hủy Đánh Dấu Thẻ Bị Mất...");
                Commands[PersoCommandNames.UnMarkLost].AddInvoker(mniUnMarkLost, "Click");
                mnuPerso.DropDownItems.Add(mniUnMarkLost);
            }

            if (mnuPerso.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mnuPerso);
                UIExtensionSites.RegisterSite(ExtensionSiteNames.PersoMenu, mnuPerso);
            }
        }

        private void EnableMenuItems(bool enabled)
        {
            if (mnuLockPerso != null)
            {
                mnuLockPerso.Enabled = enabled;
            }
            if (mnuUnLockPerso != null)
            {
                mnuUnLockPerso.Enabled = enabled;
            }
            if (mnuRemovePerso != null)
            {
                mnuRemovePerso.Enabled = enabled;
            }
            if (mnuExtendPerso != null)
            {
                mnuExtendPerso.Enabled = enabled;
            }
        }

        [EventSubscription(PersoEventTopicNames.PersoListShown)]
        public void OnTeacherListShown(object sender, EventArgs e)
        {
            EnableMenuItems(true);
        }

        [EventSubscription(PersoEventTopicNames.PersoListHide)]
        public void OnPersoListHide(object sender, EventArgs e)
        {
            EnableMenuItems(false);
        }
    }
}
