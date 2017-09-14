using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sExcelExportComponent.CommonControlsOld.Custom
{
  
        public class CommonDataGridView : DataGridView
        {
            public CommonDataGridView()
            {
                this.AllowUserToAddRows = false;
                this.AllowUserToDeleteRows = false;
                this.AllowUserToOrderColumns = true;
                this.AllowUserToResizeColumns = true;
                this.AllowUserToResizeRows = false;
                this.AutoGenerateColumns = false;
                this.BackgroundColor = System.Drawing.Color.White;
                this.BorderStyle = BorderStyle.None;
                this.Margin = new Padding(3, 3, 3, 3);
                this.ReadOnly = true;
                this.RowHeadersVisible = false;
                this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.ColumnHeadersHeight = 26;
            }
        }
    

}
