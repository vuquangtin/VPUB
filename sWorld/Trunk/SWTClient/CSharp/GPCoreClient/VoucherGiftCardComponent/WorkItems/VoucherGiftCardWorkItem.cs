using CommonHelper.Constants;
using sWorldModel;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.EventBroker;
using Microsoft.Practices.CompositeUI.SmartParts;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using sWorldModel.TransportData;
using VoucherGiftCardComponent.Constants;
using System.Resources;
using CommonHelper.Utils;

namespace VoucherGiftCardComponent.WorkItems
{
    public class VoucherGiftCardWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mniVoucherGift, mniVoucherGiftRule, mniVoucherGiftUpdate;

        private ToolStripSeparator separator1, separator2, separator3;

        public VoucherGiftCardWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AddCardMenuItems();
            EnableMenuItems(false);
            SmartParts.AddNew<UcRuleVoucherGift>(ComponentNames.VoucherGiftCardComponent);
            SmartParts.AddNew<UcAdminVoucherGift>(ComponentNames.VoucherGiftCardRuleComponent);
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ExtensionSiteNames.MenuVoucherGiftCard);
        }

        private void AddCardMenuItems()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<PolicySworld> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<PolicySworld>;
            ResourceManager rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;

            // Main Menu
            mniVoucherGift = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuVoucherCard));
            //bool isAddSeparator = false;

            //if (permissions.Exists(e => FunctionExtMethod.ToFunction(e.ModuleId) == Function.FUNC_CHIP_CARD_VIEW))
            //{

            // Menu drop 1
            mniVoucherGiftUpdate = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuVoucherCardConfigRule));
            Commands[VoucherGiftCardCommandNames.ShowVoucherGiftCardUpdate].AddInvoker(mniVoucherGiftUpdate, "Click");
            mniVoucherGift.DropDownItems.Add(mniVoucherGiftUpdate);

            // Menu drop 
            mniVoucherGiftRule = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuVoucherCardCreateRule));
            Commands[VoucherGiftCardCommandNames.ShowVoucherGiftCardRule].AddInvoker(mniVoucherGiftRule, "Click");
            mniVoucherGift.DropDownItems.Add(mniVoucherGiftRule);
                //isAddSeparator = true;
            //}    

            if (mniVoucherGift.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mniVoucherGift);
                UIExtensionSites.RegisterSite(ExtensionSiteNames.MenuVoucherGiftCard, mniVoucherGift);
            }
        }

        private void EnableMenuItems(bool enabled)
        {
        }
    }
}
