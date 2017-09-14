using CommonHelper.Constants;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MemberMgtComponent.Constants;
using sWorldModel;
using sWorldModel.TransportData;

namespace MemberMgtComponent.WorkItems
{
    public class MemberWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mnuMember, mnuListMembers, mnuIntegrateData, mnuPersoCard, mnuIntegratingLog, mnuImportMemberData;
        private ToolStripSeparator separator1, separator2;

        public MemberWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            
            AddMemberMenuItem();
            EnableMenuItems(false);
            SmartParts.AddNew<UsrMemberMgtMain>(ComponentNames.MemberMgtComponent);
            //SmartParts.AddNew<UsrIntegratingLog>(ComponentNames.IntegratingLogComponent);
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            //UIExtensionSites.UnregisterSite(ExtensionSiteNames.MemberMenu);
        }

        private void AddMemberMenuItem()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<Function> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<Function>;

            mnuMember = new ToolStripMenuItem("Thành Viên");

            if (permissions.Exists(e => e == Function.FUNC_MEMBER_VIEW))
            {
                mnuListMembers = new ToolStripMenuItem("Danh Sách Thành Viên");
                Commands[MemberCommandNames.ShowTMemberMgtMain].AddInvoker(mnuListMembers, "Click");
                mnuMember.DropDownItems.Add(mnuListMembers);

                
                mnuImportMemberData = new ToolStripMenuItem("Nhập dữ liệu thành viên");
                Commands[MemberCommandNames.ShowImportMemberData].AddInvoker(mnuImportMemberData, "Click");
                mnuMember.DropDownItems.Add(mnuImportMemberData);
            }
            
            //SessionDto currentSession = storageService.GetObject(CacheKeyNames.CurrentSession) as SessionDto;
            //if (currentSession.IsRoot)
            //{
            //    separator1 = new ToolStripSeparator();
            //    mnuTeacher.DropDownItems.Add(separator1);

            //    mnuIntegrateData = new ToolStripMenuItem("Tích Hợp Dữ Liệu...");
            //    Commands[TeacherCommandNames.SyncTeacherData].AddInvoker(mnuIntegrateData, "Click");
            //    mnuTeacher.DropDownItems.Add(mnuIntegrateData);

            //    mnuIntegratingLog = new ToolStripMenuItem("Xem Lịch Sử Tích Hợp");
            //    Commands[TeacherCommandNames.ShowIntegratingLog].AddInvoker(mnuIntegratingLog, "Click");
            //    mnuTeacher.DropDownItems.Add(mnuIntegratingLog);
            //}
            if (permissions.Exists(e => e == Function.FUNC_PERSO_PERSO_CARD))
            {
                separator2 = new ToolStripSeparator();
                mnuMember.DropDownItems.Add(separator2);

                mnuPersoCard = new ToolStripMenuItem("Cấp Thẻ...");
                Commands[MemberCommandNames.PersoCard].AddInvoker(mnuPersoCard, "Click");
                mnuMember.DropDownItems.Add(mnuPersoCard);
            }



         
            if (mnuMember.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mnuMember);
               // UIExtensionSites.RegisterSite(ExtensionSiteNames.MemberMenu, mnuMember);
            }
        }

        private void EnableMenuItems(bool enabled)
        {
            if (mnuPersoCard != null)
            {
                mnuPersoCard.Enabled = enabled;
            }
        }

        [EventSubscription(MemberEventTopicNames.MemberListShown)]
        public void OnMemberListShown(object sender, EventArgs e)
        {
            EnableMenuItems(true);
        }

        [EventSubscription(MemberEventTopicNames.MemberListHide)]
        public void OnMemberListHide(object sender, EventArgs e)
        {
            EnableMenuItems(false);
        }
    }
}
