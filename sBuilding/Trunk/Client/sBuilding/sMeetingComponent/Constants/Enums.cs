using CommonHelper.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sMeetingComponent.Constants
{
    public class Enums
    {
        //public static int TAKE = 3;
        public static int TAKE = LocalSettings.Instance.RecordsPerPage;
        public static string JOURNALIST = "Nhà Báo";

    }
}
