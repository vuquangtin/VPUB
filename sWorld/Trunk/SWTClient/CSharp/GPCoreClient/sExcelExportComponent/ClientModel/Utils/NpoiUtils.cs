using System;
using System.Text;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using System.Diagnostics;
using System.Windows.Forms;
using NPOI.HSSF.Util;

namespace ClientModel.Utils
{
    public class NpoiUtils
    {
        private HSSFWorkbook hssfworkbook;
        private const string SheetName = "Sheet 1";
        private const string NumericFormat = "N2";

        private IFont HeaderFont = null;
        private IFont BodyFont = null;

        public NpoiUtils() { }

        public void CreateExcelFile(DataGridView dgv, string filePath)
        {
            hssfworkbook = new HSSFWorkbook();

            InitHeaderFont();
            InitBodyFont();

            ISheet sheet = hssfworkbook.CreateSheet(SheetName);

            // Header
            for (int dgvColIndex = 0, excelColIndex = 0; dgvColIndex < dgv.ColumnCount; dgvColIndex++, excelColIndex++)
            {
                if (!dgv.Columns[dgvColIndex].Visible)
                {
                    excelColIndex--;
                    continue;
                }

                if (dgvColIndex == 0)
                    AddHeaderValue(sheet, 0, excelColIndex, dgv.Columns[dgvColIndex].HeaderText);
                else
                    AddHeaderValue(sheet, 0, excelColIndex, dgv.Columns[dgvColIndex].HeaderText, true);
            }

            // Body
            for (int dgvRowIndex = 0, excelRowIndex = 1; dgvRowIndex < dgv.RowCount; dgvRowIndex++, excelRowIndex++)
            {
                for (int dgvColIndex = 0, excelColIndex = 0; dgvColIndex < dgv.ColumnCount; dgvColIndex++, excelColIndex++)
                {
                    if (!dgv.Columns[dgvColIndex].Visible)
                    {
                        excelColIndex--;
                        continue;
                    }

                    string cellStyle = dgv.Columns[dgvColIndex].DefaultCellStyle == null ? string.Empty : dgv.Columns[dgvColIndex].DefaultCellStyle.Format;
                    object cellValue = dgv.Rows[dgvRowIndex].Cells[dgvColIndex].Value;

                    //row item
                    if (string.IsNullOrEmpty(cellStyle))
                    {
                        if (dgvColIndex == 0)
                            AddCellValue(sheet, excelRowIndex, excelColIndex, cellValue == null ? string.Empty : cellValue.ToString());
                        else
                            AddCellValue(sheet, excelRowIndex, excelColIndex, cellValue == null ? string.Empty : cellValue.ToString(), true);
                    }
                    if (cellStyle.Equals(NumericFormat))
                    {
                        if (dgvColIndex == 0)
                            AddCellValue(sheet, excelRowIndex, excelColIndex, cellValue == null ? 0 : Convert.ToDouble(cellValue.ToString()));
                        else
                            AddCellValue(sheet, excelRowIndex, excelColIndex, cellValue == null ? 0 : Convert.ToDouble(cellValue.ToString()), true);
                    }
                }
            }

            for (int colIndex = 0; colIndex < dgv.ColumnCount; colIndex++)
            {
                sheet.AutoSizeColumn(colIndex);
            }

            WriteToFile(filePath);
        }

        private void InitHeaderFont()
        {
            HeaderFont = hssfworkbook.CreateFont();
            HeaderFont.FontHeightInPoints = 10;
            HeaderFont.FontName = "Tahoma";
            HeaderFont.Boldweight = (short)FontBoldWeight.BOLD;
        }

        private void InitBodyFont()
        {
            BodyFont = hssfworkbook.CreateFont();
            BodyFont.FontHeightInPoints = 10;
            BodyFont.FontName = "Tahoma";
            BodyFont.Boldweight = (short)FontBoldWeight.NORMAL;
        }

        private void WriteToFile(string filePath)
        {
            if (!filePath.EndsWith(".xls", StringComparison.CurrentCultureIgnoreCase))
            {
                filePath += ".xls";
            }

            //Write the stream data of workbook to the root directory
            FileStream file = new FileStream(filePath, FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }

        private void AddHeaderValue(ISheet sheet, int row, int col, string value, bool isRowCreated = false)
        {
            ICell cell = null;
            if (isRowCreated)
                cell = sheet.GetRow(row).CreateCell(col);
            else
                cell = sheet.CreateRow(row).CreateCell(col);

            cell.SetCellValue(value);

            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;


           // style.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.BLUE_GREY.index;
            //style.FillPattern = FillPatternType.SOLID_FOREGROUND;

            style.SetFont(HeaderFont);
            cell.CellStyle = style;
        }

        private void AddCellValue(ISheet sheet, int row, int col, string value, bool isRowCreated = false)
        {
            ICell cell = null;
            if (isRowCreated)
                cell = sheet.GetRow(row).CreateCell(col);
            else
                cell = sheet.CreateRow(row).CreateCell(col);

            cell.SetCellValue(value);

            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            style.SetFont(BodyFont);
            cell.CellStyle = style;
        }

        private void AddCellValue(ISheet sheet, int row, int col, double value, bool isRowCreated = false)
        {
            ICell cell = null;
            if (isRowCreated)
                cell = sheet.GetRow(row).CreateCell(col);
            else
                cell = sheet.CreateRow(row).CreateCell(col);

            cell.SetCellValue(value);

            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            style.SetFont(BodyFont);
            cell.CellStyle = style;
        }

        private void AddCellValue(ISheet sheet, int row, int col, DateTime value, bool isRowCreated = false)
        {
            ICell cell = null;
            if (isRowCreated)
                cell = sheet.GetRow(row).CreateCell(col);
            else
                cell = sheet.CreateRow(row).CreateCell(col);

            cell.SetCellValue(value);

            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            style.SetFont(BodyFont);
            cell.CellStyle = style;
        }

        private void AddCellValue(ISheet sheet, int row, int col, bool value, bool isRowCreated = false)
        {
            ICell cell = null;
            if (isRowCreated)
                cell = sheet.GetRow(row).CreateCell(col);
            else
                cell = sheet.CreateRow(row).CreateCell(col);

            cell.SetCellValue(value);

            ICellStyle style = hssfworkbook.CreateCellStyle();
            style.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            style.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            style.SetFont(BodyFont);
            cell.CellStyle = style;
        }

        private void AddCellFormula(ISheet sheet, int row, int col, string formula)
        {
            ICell cell = sheet.CreateRow(row).CreateCell(col);
            cell.CellFormula = formula;
            cell.CellStyle.SetFont(BodyFont);
        }

    }
}