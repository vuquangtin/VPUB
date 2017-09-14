using CommonHelper.Constants;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CardMagneticMgtComponent.Constants;
using sWorldModel.TransportData;
using CardMagneticMgtComponent.WorkItems;

namespace CardMagneticMgtComponent.WorkItems
{
    public class CardMagneticWorkItem : WorkItem
    {

        private IWorkspace mainWorkspace;

        // menu items
        private ToolStripMenuItem mniCardMagnetic, mniCardMagneticManager, mniListCardMagnetic, mniCardMagneticMgt, mniListCardMagneticPerso, mniCardMagneticStatistics;
        private ToolStripSeparator separator1, separator2, separator3;

        public CardMagneticWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AddCardMenuItems();     // created menu items
            EnableMenuItems(false);

            SmartParts.AddNew<UsrCardMagneticPersoMgt>(ComponentNames.CardMagneticMgtComponent);
            SmartParts.AddNew<UsrListCardMagneticPerso>(ComponentNames.ListCardMagneticMgtPersoComponent);
            SmartParts.AddNew<UsrListCardMagnetic>(ComponentNames.ListCardMagneticMgtComponent);
            SmartParts.AddNew<UsrCardMagneticStatistics>(ComponentNames.CardStatisticsComponent);
        }

        protected override void OnDisposed()

        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ExtensionSiteNames.MenuCardMagnetic);
        }

        /// <summary>
        /// create menu items
        /// </summary>
        private void AddCardMenuItems()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<PolicySworld> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<PolicySworld>;

            // create item for magnetic card
            mniCardMagnetic = new ToolStripMenuItem(MenuNames.MenuCardMagnetic);

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MAGNETIC_CARD_VIEW))
            {
                mniCardMagneticMgt = new ToolStripMenuItem(MenuNames.MenuCardPerso);
                Commands[CardMagneticCommandNames.ShowCardMagneticMgtMain].AddInvoker(mniCardMagneticMgt, "Click");
                mniCardMagnetic.DropDownItems.Add(mniCardMagneticMgt);
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MAGNETIC_CARD_VIEW))
            {


                mniListCardMagneticPerso = new ToolStripMenuItem(MenuNames.MenuCardPersoManager);
                Commands[CardMagneticCommandNames.ShowCardListMagneticMgt].AddInvoker(mniListCardMagneticPerso, "Click");
                mniCardMagnetic.DropDownItems.Add(mniListCardMagneticPerso);

                separator1 = new ToolStripSeparator();
                mniCardMagnetic.DropDownItems.Add(separator1);
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MAGNETIC_CARD_VIEW))
            {
                mniCardMagneticManager = new ToolStripMenuItem(MenuNames.MenuCardManager);
                Commands[CardMagneticCommandNames.ShowCardListMagnetic].AddInvoker(mniCardMagneticManager, "Click");
                mniCardMagnetic.DropDownItems.Add(mniCardMagneticManager);

                if (separator1 == null)
                {
                    separator1 = new ToolStripSeparator();
                    mniCardMagnetic.DropDownItems.Add(separator1);
                }
            }

            if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_MAGNETIC_CARD_VIEW))
            {
                if (separator1 == null)
                {
                    separator1 = new ToolStripSeparator();
                    mniCardMagnetic.DropDownItems.Add(separator1);
                }

                mniCardMagneticStatistics = new ToolStripMenuItem(MenuNames.MenuCardStatistics);
                Commands[CardMagneticCommandNames.CardMagneticStatistics].AddInvoker(mniCardMagneticStatistics, "Click");
                mniCardMagnetic.DropDownItems.Add(mniCardMagneticStatistics);
            }

            if (mniCardMagnetic.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mniCardMagnetic);
                UIExtensionSites.RegisterSite(ExtensionSiteNames.MenuCardMagnetic, mniCardMagnetic);
            }

        }

        /// <summary>
        /// ????
        /// </summary>
        /// <param name="enabled"></param>
        private void EnableMenuItems(bool enabled)
        {
            ///TODO: implement
        }

        [EventSubscription(CardMagneticEventTopicNames.CardMagneticMgtMainShown)]
        public void OnCardMagneticMgtMainShown(object sender, EventArgs e)
        {
            EnableMenuItems(true);
        }

        [EventSubscription(CardMagneticEventTopicNames.CardMagneticStatisticsShown)]
        public void OnCardMagneticStatisticsShown(object sender, EventArgs e)
        {
            EnableMenuItems(true);
        }
    }
}
