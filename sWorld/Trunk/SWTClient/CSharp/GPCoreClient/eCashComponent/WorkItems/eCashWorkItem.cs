using CommonHelper.Constants;
using CommonHelper.Utils;
using eCashComponent.Contants;
using eCashComponent.WorkItems.Config;
using eCashComponent.WorkItems.TopUp;
using eCashComponentWorkItems.GroupItem;
using eCashComponent.WorkItems.Statistics;
//using eCashComponentWorkItems.Config;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.CompositeUI.SmartParts;
using sWorldModel;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using eCashComponent.WorkItems.StatisticsPayOut;
using eCashComponent.WorkItems.PayOut;


namespace HomeComponent.WorkItems
{
    public class eCashWorkItem : WorkItem
    {
        private IWorkspace mainWorkspace;

        private ToolStripMenuItem mnieCash, mniCardConfig, mniGroupItem, mniPayIn, mniStatisticTopUp, mniPayOut, mniStatisticDeduct;

        private ToolStripSeparator separator1, separator2, separator3;

        public eCashWorkItem(IWorkspace mainWorkspace)
        {
            this.mainWorkspace = mainWorkspace;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            AddeCashMenuItems();
            EnableMenuItems(false);
            SmartParts.AddNew<UsrConfig>(ComponentNames.ECashComponentConfig);
            SmartParts.AddNew<UsrGroupItem>(ComponentNames.ECashComponentConfigGroupItem);
            SmartParts.AddNew<UsrTopUpStattistics>(ComponentNames.ECashComponentTopUpStastistic);
            SmartParts.AddNew<UsrPayOutStatistics>(ComponentNames.ECashComponentDeductStastistic);
         
        }

        protected override void OnDisposed()
        {
            base.OnDisposed();
            UIExtensionSites.UnregisterSite(ExtensionSiteNames.MenueCash);
        }

        private void AddeCashMenuItems()
        {
            ILocalStorageService storageService = Services.Get<ILocalStorageService>();
            List<PolicySworld> permissions = storageService.GetObject(CacheKeyNames.CurrentUserPermissions) as List<PolicySworld>;
            ResourceManager rm = storageService.GetObject(CacheKeyNames.Languages) as ResourceManager;

            mnieCash = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MeneCash));
            //Config
            mniCardConfig = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuEcashConfig));
            Commands[ECashCommandNames.ShowEcashConfig].AddInvoker(mniCardConfig, "Click");
            mnieCash.DropDownItems.Add(mniCardConfig);
            //end Config
            //Group item
            mniGroupItem = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuEcashGroupItem));
            Commands[ECashCommandNames.ShowEcashGroupItem].AddInvoker(mniGroupItem, "Click");
            mnieCash.DropDownItems.Add(mniGroupItem);
            //end group item

            separator1 = new ToolStripSeparator();
            mnieCash.DropDownItems.Add(separator1);
         
            //Top up
            mniPayIn = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuPayIn), null, mniPayIn_Clicked);
            mnieCash.DropDownItems.Add(mniPayIn);

            //end top up
            
            // Statistic TopUp
            mniStatisticTopUp = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuEcashStatisticTopUp));
            Commands[ECashCommandNames.ShowEcashStatisticTopUp].AddInvoker(mniStatisticTopUp, "Click");
            mnieCash.DropDownItems.Add(mniStatisticTopUp);
            //end Statistic TopUp

            separator2 = new ToolStripSeparator();
            mnieCash.DropDownItems.Add(separator2);

            //  deduct
            mniPayOut = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuEcashDeDuct), null, mniPayOut_Clicked);
            mnieCash.DropDownItems.Add(mniPayOut);
            // end deduct

             // Statistic deduct
            mniStatisticDeduct = new ToolStripMenuItem(ResoucreLanguagesUtils.Instance.GetResoucreLanguages(rm, MenuNames.MenuEcashStatisticDeduct));
            Commands[ECashCommandNames.ShowEcashPayOut].AddInvoker(mniStatisticDeduct, "Click");
            mnieCash.DropDownItems.Add(mniStatisticDeduct);
            //end Statistic deduct

            if (mnieCash.DropDownItems.Count > 0)
            {
                UIExtensionSites[ExtensionSiteNames.MainMenu].Add(mnieCash);
                UIExtensionSites.RegisterSite(ExtensionSiteNames.MenuCardChip, mnieCash);
            }
        }

        private void EnableMenuItems(bool enabled)
        {
        }

        private void mniPayIn_Clicked(object sender, EventArgs e)
        {
            FrmPayIn dialog = new FrmPayIn();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }
        private void mniPayOut_Clicked(object sender, EventArgs e)
        {
            DeductPayOut dialog = new DeductPayOut();
            SmartParts.Add(dialog);
            dialog.ShowDialog();
            SmartParts.Remove(dialog);
            dialog.Dispose();
        }
    }
}
