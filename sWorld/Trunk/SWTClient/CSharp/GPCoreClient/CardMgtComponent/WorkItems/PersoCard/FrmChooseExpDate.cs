using CommonControls.Custom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CardChipMgtComponent.WorkItems
{
    public partial class FrmChooseExpDate : CommonControls.Custom.CommonDialog
    {
        public FrmChooseExpDate()
        {
            InitializeComponent();
            dtpExpDate.MinDate = DateTime.Now.AddDays(1);
        }

        public DateTime SelectedDate
        {
            get
            {
                return dtpExpDate.Value.Date;
            }
        }
    }
}
