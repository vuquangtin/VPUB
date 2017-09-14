using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sExcelExportComponent.ClientModel.Enums
{
  public class WidthA4Percent 
    {
        public static int size8 = 8;
        public static int size9 = 9;
        public static int size13 = 13;
        public static int size40 = 40;
        public static int size20 = 20;

        private int pagesize;

       public WidthA4Percent(int pagesize)
        {
           this.pagesize = pagesize;
        }

        public int SetWidth(int enumpercent)
        {
            return pagesize * enumpercent / 100;
        }

        public int GetWidth8()
        {
            return SetWidth(size8);
        }

        public int GetWidth9()
        {
            return SetWidth(size9);
        }

        public int GetWidth13()
        {
            return SetWidth(size13);
        }
    }
}
