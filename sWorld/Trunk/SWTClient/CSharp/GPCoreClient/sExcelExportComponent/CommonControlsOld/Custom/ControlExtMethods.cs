using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExcelLibrary.SpreadSheet;
using System;
using System.Windows.Forms;
namespace sExcelExportComponent.CommonControlsOld.Custom
{
  
        public static class ControlExtMethods
        {
            public static void ExportToExcel(this CommonDataGridView grid, string filePath)
            {
                Workbook workbook = new Workbook();
                Worksheet worksheet = new Worksheet("Sheet 1");
                workbook.Worksheets.Add(worksheet);

                // Generate header
                for (int i = 0, j = 0; i < grid.Columns.Count; i++)
                {
                    DataGridViewColumn dcol = grid.Columns[i];

                    if (dcol.Visible)
                    {
                        worksheet.Cells[0, j++] = new Cell(dcol.HeaderText);
                    }
                }

                // Export rows data
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    DataGridViewRow drow = grid.Rows[i];
                    for (int j = 0, k = 0; j < drow.Cells.Count; j++)
                    {
                        DataGridViewCell dcel = drow.Cells[j];
                        if (dcel.Visible)
                        {
                            worksheet.Cells[i + 1, k++] = new Cell(dcel.Value == null ? string.Empty : dcel.Value.ToString());

                        }
                    }
                }

                // Fix issue 102 of ExcelLibrary
                if (grid.Rows.Count < 150)
                {
                    for (int i = grid.Rows.Count; i < 150; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            worksheet.Cells[i + 1, j] = new Cell(string.Empty);
                        }
                    }
                }

                // Write data to file
                workbook.Save(filePath);
            }

            /// <summary>
            /// save co path mac dinh
            /// </summary>
            /// <param name="description"></param>
            /// <param name="filter"></param>
            /// <param name="filename"></param>
            /// <returns></returns>
            public static string ShowSaveFileDialog(string description, string filename, string filter)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = description;
                dialog.ValidateNames = true;
                dialog.OverwritePrompt = true;
                dialog.InitialDirectory = "";
                dialog.Filter = filter;
                dialog.FileName = filename;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
                return null;
            }

        }
    }


