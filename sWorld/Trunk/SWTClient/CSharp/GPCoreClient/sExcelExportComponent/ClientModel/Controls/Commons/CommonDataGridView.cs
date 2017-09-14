using ClientModel.Utils;
using ExcelLibrary.SpreadSheet;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace ClientModel.Controls.Commons
{
    public class CommonDataGridView : DataGridView
    {
        private NpoiUtils npoiUtils = null;

        public CommonDataGridView()
        {
            this.ReadOnly = true;
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.AllowUserToOrderColumns = true;
            this.AllowUserToResizeColumns = true;
            this.AllowUserToResizeRows = false;
            this.RowHeadersVisible = false;

            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;//other

            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.BackgroundColor = Color.White;
            this.AutoGenerateColumns = false;

        }

        public void ExportToExcelUsingExcelLibrary(string filePath)
        {
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Sheet 1");
            workbook.Worksheets.Add(worksheet);

            // Generate header
            for (ushort i = 0, j = 0; i < this.Columns.Count; i++)
            {
                DataGridViewColumn dcol = this.Columns[i];
                if (dcol.Visible)
                {
                    worksheet.Cells[0, j] = new Cell(dcol.HeaderText);
                    worksheet.Cells.ColumnWidth[0, j] = 5000;
                    ++j;
                }
            }

            // Export rows data
            for (ushort i = 0; i < this.Rows.Count; i++)
            {
                DataGridViewRow drow = this.Rows[i];
                for (ushort j = 0, k = 0; j < drow.Cells.Count; j++)
                {
                    DataGridViewCell dcel = drow.Cells[j];
                    if (dcel.Visible)
                    {
                        if ((dcel is DataGridViewImageCell) || (dcel is DataGridViewComboBoxCell) || (dcel is DataGridViewButtonCell))
                        {
                            worksheet.Cells[i + 1, k++] = new Cell("N/A");
                        }
                        else if (dcel is DataGridViewCheckBoxCell)
                        {
                            DataGridViewCheckBoxCell cbxcel = dcel as DataGridViewCheckBoxCell;
                            worksheet.Cells[i + 1, k++] = new Cell(cbxcel.Selected.ToString());
                        }
                        else
                        {
                            worksheet.Cells[i + 1, k++] = new Cell(dcel.Value == null ? string.Empty : dcel.Value.ToString());
                        }
                    }
                }
            }

            // Fix issue 102 of Excel Library
            // https://code.google.com/p/excellibrary/issues/detail?id=102
            if (this.Rows.Count < 150)
            {
                for (ushort i = (ushort)this.Rows.Count; i < 150; i++)
                {
                    for (ushort j = 0; j < 10; j++)
                    {
                        worksheet.Cells[i + 1, j] = new Cell(string.Empty);
                    }
                }
            }

            // Write data to file
            workbook.Save(filePath);
        }

        public void ExportToExcelUsingNpoi(string filePath)
        {
            if (npoiUtils == null)
            {
                npoiUtils = new NpoiUtils();
            }

            npoiUtils.CreateExcelFile(this, filePath);
        }

       
    }
}