using CardChipMgtComponent.Constants;
using CommonHelper.Constants;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using sWorldModel.TransportData;
using System.Resources;
using CommonHelper.Utils;

namespace CardChipMgtComponent.WorkItems
{
    public class CardWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mniCard,mniCardPerso, mnuListPerso, mniStatisticCards, mniListCards,  mniClearCardData, mniReadCardData, mniUpdateCardHeader;

        private ToolStripSeparator separator1, separator2, separator3;

        public CardWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AddCardMenuItems();
            EnableMenuItems(false);
            SmartParts.AddNew<UsrCardMgtMain>(ComponentNames.CardMgtComponent);
            SmartParts.AddNew<UsrCardStatistics>(ComponentNames.CardStatisticsComponent);
            SmartParts.AddNew<UsrPersoMgtMain>(ComponentNames.PersoMgtComponent);
            SmartParts.AddNew<UsrMemberMgtMain>(ComponentNames.PersoMemberMgtComponent);
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ExtensionSiteNames.MenuCardChip);
        }

        private void AddCardMenuItems()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<PolicySworld> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<PolicySworld>;
            ResourceManager rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;

            mniCard = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuCardChip));
            bool isAddSeparator = false;
            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_CHIP_MEMBER_PERSO_VIEW))
            {
                mniCardPerso = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuCardPerso));
                Commands[MemberCommandNames.ShowMemberMgtMain].AddInvoker(mniCardPerso, "Click");
                mniCard.DropDownItems.Add(mniCardPerso);
                isAddSeparator = true;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_CHIP_PERSO_VIEW))
            {
                mnuListPerso = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuCardPersoManager));
                Commands[PersoCommandNames.ShowPersoMgtMain].AddInvoker(mnuListPerso, "Click");
                mniCard.DropDownItems.Add(mnuListPerso);
                isAddSeparator = true;
            }
            if (isAddSeparator)
            {
                separator1 = new ToolStripSeparator();
                mniCard.DropDownItems.Add(separator1);
                isAddSeparator = false;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_CHIP_CARD_VIEW))
            {
                mniListCards = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuCardManager));
                Commands[CardCommandNames.ShowCardMgtMain].AddInvoker(mniListCards, "Click");
                mniCard.DropDownItems.Add(mniListCards);
                isAddSeparator = true;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_CHIP_CARD_STATISTICS_VIEW))
            {
                mniStatisticCards = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuCardStatistics));
                Commands[CardCommandNames.ShowCardStatistics].AddInvoker(mniStatisticCards, "Click");
                mniCard.DropDownItems.Add(mniStatisticCards);
                isAddSeparator = true;
            }

            if (isAddSeparator)
            {
                separator2 = new ToolStripSeparator();
                mniCard.DropDownItems.Add(separator2);
                isAddSeparator = false;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_CHIP_TOOLKIT_READ_DATA))
            {
                mniReadCardData = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuReadCard), null, mniReadCardData_Clicked);
                mniCard.DropDownItems.Add(mniReadCardData);
                isAddSeparator = true;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_CHIP_TOOLKIT_UPDATE_DATA))
            {
                mniUpdateCardHeader = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuUpdateCard), null, mniUpdateCardData_Clicked);
                mniCard.DropDownItems.Add(mniUpdateCardHeader);
                isAddSeparator = true;
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_CHIP_TOOLKIT_CLEAR_DATA))
            {
                mniClearCardData = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuClearCard), null, mniClearCardData_Clicked);
                mniCard.DropDownItems.Add(mniClearCardData);
                isAddSeparator = true;
            }

            if (mniCard.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mniCard);
                UIExtensionSites.RegisterSite(ExtensionSiteNames.MenuCardChip, mniCard);
            }
        }

        private void EnableMenuItems(bool enabled)
        {
        }

        [EventSubscription(CardEventTopicNames.CardMgtMainShown)]
        public void OnCardListShown(object sender, EventArgs e)
        {
            EnableMenuItems(true);
        }

        [EventSubscription(CardEventTopicNames.CardMgtMainHide)]
        public void OnCardListHide(object sender, EventArgs e)
        {
            EnableMenuItems(false);
        }

        private void mniClearCardData_Clicked(object sender, EventArgs e)
        {
            FrmClearCardData dialog = new FrmClearCardData();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }

        private void mniReadCardData_Clicked(object sender, EventArgs e)
        {
            FrmReadCardData dialog = new FrmReadCardData();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }

        private void mniUpdateCardData_Clicked(object sender, EventArgs e)
        {
            FrmUpdateCardData dialog = new FrmUpdateCardData();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }
    }
}
