using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCashComponent.Contants
{
    class ECashCommandNames
    {
       // public const string ShowVoucheMain = @"ShowEcashMain";
       // public const string SyncData = @"SuncOrg";
        public const string AddEcashConfig = @"AddEcashConfig";
        public const string UpdateEcashConfig = @"EditEcashConfig";
        public const string RemoveEcashConfig = @"RemoveEcashConfig";

        //group item
        public const string AddEcashGroupItem = @"AddEcashGroupItem";
        public const string UpdateEcashGroupItem = @"UpdateEcashGroupItem";
        public const string RemoveEcashGroupItem = @"RemoveEcashGroupItem";

        //end group item

        //Show top up
        public const string ShowEcashTopUp = "ShowEcashTopUp";
        //end top up
        //Show config card
        public const string ShowEcashConfig = "ShowEcashConfig";
        //end config card
        //Show Gruop item
        public const string ShowEcashGroupItem = "ShowEcashGroupItem";
        //end Group Item
        //Statistic TopUp
        public const string ShowEcashStatisticTopUp = "ShowEcashStatisticTopUp";
        //End Statistic TopUp
        //Statistic TopUp
        public const string ShowEcashPayOut = "ShowEcashPayOut";
        //End Statistic TopUp
        //public const string VoucherMgtMainShown = @"VoucherMgtMainShown";
        //public const string ShowVoucherGiftCardRule = "ShowVoucherGiftCardRule";
    }
}
