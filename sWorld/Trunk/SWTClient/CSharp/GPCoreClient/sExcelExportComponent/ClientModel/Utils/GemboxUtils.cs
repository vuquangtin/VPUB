using ClientModel.Controls.Commons;
using ClientModel.Enums;
using ClientModel.Model;
using GemBox.Spreadsheet;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ClientModel.Utils
{
    public class GemboxUtils
    {
        private CellStyle styleHeader { set; get; }
        private CellStyle styleTitle { set; get; }
        private CellStyle styleContentNone { set; get; }
        private CellStyle styleContentBackgroud { set; get; }
        private ConfigExportFileModel configExportFile;

        private int rowHeader = 0;
        private int rowStart = 0;
        private int rowContent = 0;
        private int rowTitle = 0;
        private int colCountws = -1;

        //custom before print
        private bool Portrait = false;
        double TopMargin, LeftMargin, BottomMargin, RightMargin, HeaderMargin, FooterMargin = 0.0;
        //

        //
        private string Fontcolor = "#000000";
        //

        private ExcelWorksheet ws = null;
        private ExcelFile ef = null;

        private CommonDataGridView dgvSoucre;
        private DataTable DtSoucre;

        private static GemboxUtils instance = new GemboxUtils();
        public static GemboxUtils Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GemboxUtils();
                }
                return instance;
            }
        }

        private GemboxUtils()
        {
            this.Fontcolor = "#244062";
            this.rowHeader = 0;
        }

        #region ĐANG SỬ DỤNG:  Xuất file excel quan trọng
        /// <summary>
        /// CREATE FILE EXPORT
        /// 1.1 TẠO FILE XUẤT DỮ LIỆU (dữ liệu dgv, tên file cần xuất, tạo file, custom style, tựa đề dữ liệu)
        /// </summary>
        /// <param name="dgvSoucre"></param>
        /// <param name="config"></param>
        public void ExportDataGridToFile(CommonDataGridView dgvSoucre, ConfigExportFileModel config)
        {
            configExportFile = config == null ? new ConfigExportFileModel() : config;
            this.dgvSoucre = dgvSoucre;
            rowTitle = rowContent = rowStart = rowTitle = 0;

            ef = new ExcelFile();
            ws = ef.Worksheets.Add(config.SheetName);

            //Create style
            styleTitle = SetStyleTitle();
            styleContentNone = SetStyleContent(false, HorizontalAlignmentStyle.General);
            styleContentBackgroud = SetStyleContent(true, HorizontalAlignmentStyle.General);

            //Title
            //rowTitle = 15;
            //add them cot STT
            //AddCellHeader(ws, rowTitle, 0, "STT");
            for (int colIndex = 0, colContent = 0; colIndex < dgvSoucre.ColumnCount; colIndex++)
            {
                if (dgvSoucre.Columns[colIndex].Visible == false)
                    continue;
                ws.Rows[rowTitle].Height = config.GetRowHeightHeader();

                //dgvSoucre.Columns[colIndex].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                AddCellHeader(ws, rowTitle, colContent, dgvSoucre.Columns[colIndex].HeaderText);
                colContent++;
            }

            //Header
            //AddHeader(configExportFile.HeaderText);
        }

        /// <summary>
        /// CREATE FILE EXPORT
        /// 1. ĐANG SỬ DỤNG : TẠO FILE XUẤT DỮ LIỆU (dữ liệu dgv, tên file cần xuất, tạo file, custom style, tựa đề dữ liệu, xác định vị trí bắt đầu xuất dgv)
        /// </summary>
        /// <param name="dgvSoucre"></param>
        /// <param name="config"></param>
        /// <param name="rowStartRecord"></param>
        public void ExportDataGridToFileCustom(CommonDataGridView dgvSoucre, ConfigExportFileModel config, int rowStartRecord)
        {
            configExportFile = config == null ? new ConfigExportFileModel() : config;
            this.dgvSoucre = dgvSoucre;
            rowTitle = rowContent = rowStart = rowTitle = 0;

            ef = new ExcelFile();

            ws = ef.Worksheets.ActiveWorksheet;

            ws = ef.Worksheets.Add(config.SheetName);

            //print A4
            //21 : 29.7
            ws.PrintOptions.PaperSize = 9;

            // Print options:
            var printOptions = ws.PrintOptions;
            printOptions.PrintGridlines = true;
            printOptions.PrintHeadings = false;
            printOptions.PrintPagesInRows = false;
            printOptions.HorizontalCentered = true;
            printOptions.Portrait = Portrait;//in dọc không

            printOptions.LeftMargin = LeftMargin;
            printOptions.RightMargin = RightMargin;
            printOptions.TopMargin = TopMargin;
            printOptions.BottomMargin = BottomMargin;

            printOptions.HeaderMargin = HeaderMargin;
            printOptions.FooterMargin = FooterMargin;
            //

            styleTitle = SetStyleTitle();
            styleTitle.WrapText = true;

            styleContentNone = SetStyleContent(false, HorizontalAlignmentStyle.General);
            styleContentBackgroud = SetStyleContent(true, HorizontalAlignmentStyle.General);

            //Title
            rowTitle = rowStartRecord;
            //add them cot STT
            //AddCellHeader(ws, rowTitle, 0, "STT");
            for (int colIndex = 0, colContent = 0; colIndex < dgvSoucre.ColumnCount; colIndex++)
            {
                if (dgvSoucre.Columns[colIndex].Visible == false)
                    continue;
                ws.Rows[rowTitle].Height = config.GetRowHeightHeader();

                //dgvSoucre.Columns[colIndex].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                AddCellHeader(ws, rowTitle, colContent, dgvSoucre.Columns[colIndex].HeaderText.ToUpper());
                colContent++;
            }

            //fix 20/03/2017 : dữ liệu có thể xuống dòng
            try
            {
                colCountws = ws.CalculateMaxUsedColumns() - 1;
            }
            catch (Exception ex) { }
            //end

            //Header
            //AddHeader(configExportFile.HeaderText);
        }

        /// <summary>
        /// ADD DATA DGV in FILE EXPORT
        /// 2: ĐANG SỬ DỤNG: XUẤT DỮ LIỆU LẤY DỮ LIỆU TỪ BẢNG DGV
        /// </summary>
        /// <param name="rowCount"></param>
        public void ExportDataGridToFile(int rowCount)
        {
            rowContent = rowContent == 0 ? rowTitle + 1 : rowContent;
            for (int rowIndex = rowStart; rowIndex < rowCount; rowIndex++)
            {
                ws.Rows[rowContent].Height = configExportFile.GetRowHeightContent();

                //Them cot STT
                // ExcelCell cellSTT = ws.Cells[rowContent, 0];
                //cellSTT.Style = configExportFile.ShowBackgroundContent && rowIndex % 2 != 0 ? styleContentBackgroud : styleContentNone;
                //cellSTT.Value = rowIndex + 1;

                for (int colIndex = 0, colContent = 0; colIndex < dgvSoucre.ColumnCount; colIndex++)
                {
                    if (dgvSoucre.Columns[colIndex].Visible == false)
                        continue;

                    ExcelCell cell = ws.Cells[rowContent, colContent];

                    string cellFormat = string.IsNullOrEmpty(dgvSoucre.Columns[colIndex].DefaultCellStyle.Format) ? string.Empty : dgvSoucre.Columns[colIndex].DefaultCellStyle.Format.Substring(0, 1);
                    SetContentAlignmentStyle(dgvSoucre.Columns[colIndex].DefaultCellStyle.Alignment);
                    cell.Style = configExportFile.ShowBackgroundContent && rowIndex % 2 != 0 ? styleContentBackgroud : styleContentNone;

                    //fix 20/03/2017 : dữ liệu có thể xuống dòng : cột cuối Wraptext
                    if (colContent == colCountws)
                    {
                        cell.Style.WrapText = true;
                    }
                    //end

                    var value = dgvSoucre.Rows[rowIndex].Cells[colIndex].Value;

                    if (value != null && !string.IsNullOrEmpty(value.ToString()))
                    {
                        switch (cellFormat)
                        {
                            case "C":
                                cell.Value = Convert.ToDecimal(value);
                                cell.Style.NumberFormat = configExportFile.CurrecyFormat;
                                break;
                            case "N":
                                cell.Value = Convert.ToDecimal(value);
                                cell.Style.NumberFormat = configExportFile.NumberFormat;
                                break;
                            case "d":
                            case "D":
                                cell.Value = Convert.ToDateTime(value);
                                cell.Style.NumberFormat = configExportFile.ShortDateFormat;
                                break;
                            case "f":
                            case "F":
                            case "g":
                            case "G":
                                cell.Value = Convert.ToDateTime(value);
                                cell.Style.NumberFormat = configExportFile.LongDateFormat;
                                break;
                            case "":
                                if (value.ToString().ToLower() == "false")
                                    value = "Không";
                                else if (value.ToString().ToLower() == "true")
                                    value = "Có";
                                else if (value.ToString().ToLower() == "không")
                                    value = "Không";
                                else if (value.ToString().ToLower() == "có")
                                    value = "Có";
                                else
                                    value = value.ToString();

                                cell.Value = value.ToString();
                                cell.Style.NumberFormat = "@";

                                break;
                            default:
                                cell.Value = value.ToString();
                                break;
                        }
                    }
                    colContent++;
                }
                rowContent++;
            }
            rowStart = rowCount;
        }

        /// <summary>
        /// 3. SAVE FILE:
        /// </summary>
        public void Save()
        {
            string strExtension = Path.GetExtension(configExportFile.FilePath);

            if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Xls.GetExtension())))
            {
                ef.SaveXls(configExportFile.FilePath);
                return;
            }
            if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Xlsx.GetExtension())))
            {
                ef.SaveXlsx(configExportFile.FilePath);
                return;
            }
            if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Ods.GetExtension())))
            {
                ef.SaveOds(configExportFile.FilePath);
                return;
            }
        }
        public void AddTemplateHeader()
        {
            SetColor("#000000");
            int maxUsedColumns = (ws.CalculateMaxUsedColumns() - 1);
            int haflfCol = (maxUsedColumns / 2 - 1);
            int haflfColPlus = haflfCol + 1;

            ExcelCell cell = ws.Cells[rowHeader, 0];
            var cr1 = ws.Cells.GetSubrangeAbsolute(rowHeader, 0, rowHeader, haflfCol);
            cr1.Merged = true;
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Center, 10, ExcelFont.NormalWeight);
            cell.Value = "UỶ BAN NHÂN DÂN";

            cell = ws.Cells[rowHeader, haflfColPlus];
            var cr12 = ws.Cells.GetSubrangeAbsolute(rowHeader, haflfColPlus, rowHeader, maxUsedColumns);
            cr12.Merged = true;
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Center, 10, ExcelFont.BoldWeight);
            cell.Value = "CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM";

            rowHeader++;
            cell = ws.Cells[rowHeader, 0];
            var cr21 = ws.Cells.GetSubrangeAbsolute(rowHeader, 0, rowHeader, haflfCol);
            cr21.Merged = true;
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Center, 10, ExcelFont.NormalWeight);
            cell.Value = "THÀNH PHỐ HỒ CHÍ MINH";

            cell = ws.Cells[rowHeader, haflfColPlus];
            var cr2 = ws.Cells.GetSubrangeAbsolute(rowHeader, haflfColPlus, rowHeader, maxUsedColumns);
            cr2.Merged = true;
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Center, 10, ExcelFont.BoldWeight);
            cell.Value = "Độc lập - Tự do - Hạnh Phúc";

            rowHeader++;
            cell = ws.Cells[rowHeader, 0];
            var cr3 = ws.Cells.GetSubrangeAbsolute(rowHeader, 0, rowHeader, haflfCol);
            cr3.Merged = true;
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Center, 10, ExcelFont.BoldWeight);
            cell.Value = "VĂN PHÒNG UỶ BAN THÀNH PHỐ";

            cell = ws.Cells[rowHeader, haflfColPlus];
            var cr31 = ws.Cells.GetSubrangeAbsolute(rowHeader, haflfColPlus, rowHeader, maxUsedColumns);
            cr31.Merged = true;
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Center, 10, ExcelFont.BoldWeight);

            rowHeader++;
            cell = ws.Cells[rowHeader, 0];
            var cr4 = ws.Cells.GetSubrangeAbsolute(rowHeader, 0, rowHeader, maxUsedColumns);
            cr4.Merged = true;
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Center, 10, ExcelFont.NormalWeight);

            SetColor("#244062");
            rowHeader++;

        }

        /// <summary>
        /// 4. ADD HEADER
        /// </summary>
        /// <param name="headerText"></param>
        public void AddHeader(string headerText)
        {
            ExcelCell cell = ws.Cells[rowHeader, 0];
            var cr = ws.Cells.GetSubrangeAbsolute(rowHeader, 0, rowHeader, ws.CalculateMaxUsedColumns() - 1);
            cr.Merged = true;
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Center, 15, ExcelFont.BoldWeight);
            cell.Value = headerText.ToUpper();
            ws.Rows[rowHeader].Height = 30 * 20;

            //cell = ws.Cells[1, 0];
            //var cr1 = ws.Cells.GetSubrangeAbsolute(rowHeader + 1, 0, rowHeader + 1, ws.CalculateMaxUsedColumns() - 1);
            //cr1.Merged = true;
            //cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Left, 10);
            //cell.Value = string.Format("Ngày xuất dữ liệu: {0}", DateTime.Now.ToString(DataGeneralFormat.DateFullyNonPlaceHolderFormat));

            //cell = ws.Cells[2, 0];
            //var cr2 = ws.Cells.GetSubrangeAbsolute(rowHeader + 2, 0, rowHeader + 2, ws.CalculateMaxUsedColumns() - 1);
            //cr2.Merged = true;

            rowHeader++;
            cell = ws.Cells[rowHeader, 0];
            var cr2 = ws.Cells.GetSubrangeAbsolute(rowHeader, 0, rowHeader, ws.CalculateMaxUsedColumns() - 1);
            cr2.Merged = true;

            rowHeader = 0;
        }


        #region FIX SIZE COLUMN
        /// <summary>
        /// AUTOFIX OF GEMBOX
        /// </summary>
        public void AutoFix()
        {
            int columnCount = ws.CalculateMaxUsedColumns();
            for (int colIndex = 0; colIndex < columnCount; colIndex++)
                ws.Columns[colIndex].AutoFit();
            // ws.Columns[colIndex].AutoFitAdvanced(1, ws.Rows[1], ws.Rows[ws.Rows.Count - 1]);
            //ws.Columns[colIndex].AutoFitAdvanced(configPage.AutoFixScaling, ws.Rows[0], ws.Rows[ws.Rows.Count - 1]);

        }

        /// <summary>
        /// FIX SIZE BASED ON SIZE COL 
        /// fix theo kích thước cua du lieu
        /// </summary>
        public void AutoFixA4()
        {
            int columnCount = ws.CalculateMaxUsedColumns();
            for (int colIndex = 0; colIndex < columnCount; colIndex++)
                ws.Columns[colIndex].AutoFitAdvanced(1, ws.Rows[1], ws.Rows[ws.Rows.Count - 1]);
        }

        /// <summary>
        /// AUTO FIX a colINDEX
        /// fix auto cột nào đó
        /// </summary>
        /// <param name="index"></param>
        public void AutoFixColIndex(int index)
        {
            int columnCount = ws.CalculateMaxUsedColumns();
            for (int colIndex = 0; colIndex < columnCount; colIndex++)
            {
                if (colIndex == index)
                    ws.Columns[colIndex].AutoFit();
            }
        }

        /// <summary>
        /// FIX SIZE BASED ON SIZE OF COLINDEX
        /// fix kích thước ô theo dữ liệu của ô nào đó
        /// </summary>
        /// <param name="index"></param>
        public void AutoFitAdvancedColIndex(int index)
        {
            int columnCount = ws.CalculateMaxUsedColumns();
            for (int colIndex = 0; colIndex < columnCount; colIndex++)
            {
                if (colIndex == index)
                    ws.Columns[colIndex].AutoFitAdvanced(1, ws.Rows[1], ws.Rows[ws.Rows.Count - 1]);
            }
        }

        /// <summary>
        /// FIX SIZE OF COLEND
        /// kích thước ô tên người tham dự cho phù họp voi giấy A4
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        public void AutoFixWidthColIndexEnd(int index, int size)
        {
            int widthUse = 0;
            int columnCount = ws.CalculateMaxUsedColumns();
            for (int colIndex = 0; colIndex < columnCount; colIndex++)
            {
                if (colIndex != index)
                    widthUse += ws.Columns[colIndex].Width;
            }
            if ((size - widthUse) > 0)
                for (int colIndex = 0; colIndex < columnCount; colIndex++)
                {
                    if (colIndex == index)
                        ws.Columns[colIndex].Width = size - widthUse;
                }
        }

        /// <summary>
        /// SET SIZE COLINDEX
        /// Set kích thước cụ thể cho 1 một cột
        /// </summary>
        /// <param name="index"></param>
        /// <param name="size"></param>
        public void SetWidthColIndex(int index, int size)
        {
            int columnCount = ws.CalculateMaxUsedColumns();
            for (int colIndex = 0; colIndex < columnCount; colIndex++)
            {
                if (colIndex == index)
                    ws.Columns[colIndex].Width = size;
            }
        }

        #endregion

        /// <summary>
        ///  SET PORTRAIT
        ///  Có in dọc hay không
        /// </summary>
        /// <param name="portrait"></param>
        public void SetPortrait(bool portrait)
        {
            Portrait = portrait;
        }

        /// <summary>
        /// SET MARGIN
        /// </summary>
        /// <param name="TopMargin"></param>
        /// <param name="LeftMargin"></param>
        /// <param name="BottomMargin"></param>
        /// <param name="RightMargin"></param>
        /// <param name="HeaderMargin"></param>
        /// <param name="FooterMargin"></param>
        public void SetMarginPrintOption(double TopMargin, double LeftMargin, double BottomMargin, double RightMargin, double HeaderMargin, double FooterMargin)
        {
            this.TopMargin = TopMargin;
            this.LeftMargin = LeftMargin;
            this.BottomMargin = BottomMargin;
            this.RightMargin = RightMargin;
            this.HeaderMargin = HeaderMargin;
            this.FooterMargin = FooterMargin;
        }

        #endregion

        /// <summary>
        /// SetContentAlignmentStyle
        /// </summary>
        /// <param name="contentAlignment"></param>
        private void SetContentAlignmentStyle(DataGridViewContentAlignment contentAlignment)
        {
            switch (contentAlignment)
            {
                case DataGridViewContentAlignment.TopLeft:
                case DataGridViewContentAlignment.MiddleLeft:
                case DataGridViewContentAlignment.BottomLeft:
                    styleContentNone.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                    styleContentBackgroud.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                    break;
                case DataGridViewContentAlignment.TopRight:
                case DataGridViewContentAlignment.MiddleRight:
                case DataGridViewContentAlignment.BottomRight:
                    styleContentNone.HorizontalAlignment = HorizontalAlignmentStyle.Right;
                    styleContentBackgroud.HorizontalAlignment = HorizontalAlignmentStyle.Right;
                    break;
                case DataGridViewContentAlignment.TopCenter:
                case DataGridViewContentAlignment.MiddleCenter:
                case DataGridViewContentAlignment.BottomCenter:
                    styleContentNone.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    styleContentBackgroud.HorizontalAlignment = HorizontalAlignmentStyle.Center;
                    break;
                case DataGridViewContentAlignment.NotSet:
                    styleContentNone.HorizontalAlignment = HorizontalAlignmentStyle.General;
                    styleContentBackgroud.HorizontalAlignment = HorizontalAlignmentStyle.General;
                    break;
            }
        }
        public void SetColor(String color)
        {
            this.Fontcolor = color; ;
        }

        /// <summary>
        /// SetStyleHeader
        /// </summary>
        /// <param name="horizontalAlignment"></param>
        /// <param name="fontSize"></param>
        /// <returns></returns>
        private CellStyle SetStyleHeader(HorizontalAlignmentStyle horizontalAlignment, int fontSize, int weight)//, String color)
        {
            CellStyle style = new CellStyle();

            style.Font.Name = configExportFile.FontName;
            style.Font.Size = fontSize * 20;
            //style.Font.Weight = ExcelFont.BoldWeight;
            // style.Font.Color = System.Drawing.ColorTranslator.FromHtml("#244062");

            style.Font.Weight = weight;
            style.Font.Color = System.Drawing.ColorTranslator.FromHtml(this.Fontcolor);
            
            //Set Backgroud color
            style.FillPattern.SetSolid(Color.White);
            //set VerticalAlignment
            style.VerticalAlignment = VerticalAlignmentStyle.Center;
            style.HorizontalAlignment = horizontalAlignment;
            //style.HorizontalAlignment = HorizontalAlignmentStyle.Center;
            return style;
        }

        /// <summary>
        /// SetStyleTitle
        /// </summary>
        /// <returns></returns>
        private CellStyle SetStyleTitle()
        {
            CellStyle style = new CellStyle();

            style.Font.Name = configExportFile.FontName;
            style.Font.Size = configExportFile.GetFontSizeHeader();
            style.Font.Weight = ExcelFont.BoldWeight;
            style.Font.Color = configExportFile.FontColorHeader;
            //Create border
            style.Borders.SetBorders(MultipleBorders.Top, Color.Black, LineStyle.Thin);
            style.Borders.SetBorders(MultipleBorders.Left, Color.Black, LineStyle.Thin);
            style.Borders.SetBorders(MultipleBorders.Right, Color.Black, LineStyle.Thin);
            style.Borders.SetBorders(MultipleBorders.Bottom, Color.Black, LineStyle.Thin);
            //Set Backgroud color
            style.FillPattern.SetSolid(configExportFile.BackgroundColorHeader);
            //set VerticalAlignment
            style.VerticalAlignment = VerticalAlignmentStyle.Center;

            return style;
        }

        /// <summary>
        /// SetStyleContent
        /// </summary>
        /// <param name="isRowBackgroud"></param>
        /// <param name="horizontalAlignment"></param>
        /// <returns></returns>
        private CellStyle SetStyleContent(bool isRowBackgroud, HorizontalAlignmentStyle horizontalAlignment)
        {
            CellStyle style = new CellStyle();

            style.Font.Name = configExportFile.FontName;
            style.Font.Size = configExportFile.GetFontSizeContent();
            style.Font.Color = configExportFile.FontColorContent;
            //Create border
            style.Borders.SetBorders(MultipleBorders.Top, Color.Black, LineStyle.Thin);
            style.Borders.SetBorders(MultipleBorders.Left, Color.Black, LineStyle.Thin);
            style.Borders.SetBorders(MultipleBorders.Right, Color.Black, LineStyle.Thin);
            style.Borders.SetBorders(MultipleBorders.Bottom, Color.Black, LineStyle.Thin);
            if (isRowBackgroud)
            {
                style.FillPattern.SetSolid(configExportFile.BackgroundColorContent);
            }
            // set VerticalAlignment
            style.VerticalAlignment = VerticalAlignmentStyle.Center;
            style.HorizontalAlignment = horizontalAlignment;

            return style;
        }

        /// <summary>
        /// AddCellHeader
        /// </summary>
        /// <param name="ws"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private ExcelCell AddCellHeader(ExcelWorksheet ws, int row, int col, object value)
        {
            ExcelCell cell = ws.Cells[row, col];

            cell.Style = styleTitle;
            // cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Center, 15);
            cell.Value = value;
            cell.Style.HorizontalAlignment = HorizontalAlignmentStyle.Center;

            return cell;
        }

        /// <summary>
        /// CHECK VALUE IS NUMBER
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsNumber(Type value)
        {
            return value == typeof(sbyte)
                    || value == typeof(byte)
                    || value == typeof(short)
                    || value == typeof(ushort)
                    || value == typeof(int)
                    || value == typeof(uint)
                    || value == typeof(long)
                    || value == typeof(ulong)
                    || value == typeof(float)
                    || value == typeof(double)
                    || value == typeof(decimal);
        }

        #region CHƯA SỬ DỤNG: Export excel datatable
        /// <summary>
        /// ExportDataTableToFile
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="config"></param>
        public void ExportDataTableToFile(DataTable dt, ConfigExportFileModel config)
        {
            configExportFile = config == null ? new ConfigExportFileModel() : config;
            DtSoucre = dt;

            rowTitle = rowContent = rowStart = rowTitle = 0;

            ef = new ExcelFile();
            ws = ef.Worksheets.Add(config.SheetName);

            //Create style
            styleTitle = SetStyleTitle();
            styleContentNone = SetStyleContent(false, HorizontalAlignmentStyle.General);
            styleContentBackgroud = SetStyleContent(true, HorizontalAlignmentStyle.General);

            //Title
            rowTitle = 3;
            for (int colIndex = 0; colIndex < DtSoucre.Columns.Count; colIndex++)
            {
                ws.Rows[rowTitle].Height = config.GetRowHeightHeader();
                AddCellHeader(ws, rowTitle, colIndex, DtSoucre.Columns[colIndex].ColumnName);

                //vp edit etown
                //string tenCot = "";
                //switch(colIndex)
                //{
                //    case 0 :
                //        tenCot = "STT";
                //        break;
                //    case 1:
                //        tenCot = "Họ";
                //        break;
                //    case 2:
                //        tenCot = "Tên";
                //        break;
                //    case 3:
                //        tenCot = "Phòng ban";
                //        break;
                //    case 4:
                //        tenCot = "Loại xe";
                //        break;
                //    case 5:
                //        tenCot = "Loại đăng ký";
                //        break;
                //    case 6:
                //        tenCot = "Thời gian";
                //        break;
                //    case 7:
                //        tenCot = "Biển số xe";
                //        break;
                //    case 8:
                //        tenCot = "Hiệu xe";
                //        break;
                //    case 9:
                //        tenCot = "Màu sơn";
                //        break;
                //}
                //AddCellHeader(ws, rowTitle, colIndex, tenCot);   
            }

            //Header
            AddHeader(configExportFile.HeaderText);
        }

        /// <summary>
        /// ExportDataTableToFile
        /// </summary>
        /// <param name="dtData"></param>
        public void ExportDataTableToFile(DataTable dtData)
        {
            rowContent = rowContent == 0 ? rowTitle + 1 : rowContent;
            for (int rowIndex = 0; rowIndex < dtData.Rows.Count; rowIndex++)
            {
                ws.Rows[rowContent].Height = configExportFile.GetRowHeightContent();
                for (int colIndex = 0; colIndex < dtData.Columns.Count; colIndex++)
                {
                    ExcelCell cell = ws.Cells[rowContent, colIndex];
                    cell.Style = configExportFile.ShowBackgroundContent && rowIndex % 2 != 0 ? styleContentBackgroud : styleContentNone;
                    Type typeData = dtData.Columns[colIndex].DataType;
                    var value = dtData.Rows[rowIndex][colIndex];
                    if (value != null)
                    {
                        if (IsNumber(typeData))
                        {
                            cell.Value = Convert.ToDecimal(value);
                            cell.Style.NumberFormat = configExportFile.NumberFormat;
                            continue;
                        }
                        if (typeData == typeof(string))
                        {
                            cell.Value = value.ToString();
                            cell.Style.NumberFormat = "@";
                            continue;
                        }
                        else
                        {
                            cell.Value = value.ToString();
                            cell.Style.NumberFormat = "@";
                            continue;
                        }
                    }
                }
                rowContent++;
            }
            rowStart += dtData.Rows.Count;
        }
        #endregion

        #region CHƯA SỬ DỤNG: CUSTOM STYLE 

        /// <summary>
        /// AddCellCustom
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        public void AddCellCustom(int row, int col, string value)
        {
            ExcelCell cell = ws.Cells[row, col];
            //cach 1
            //cell.Value = value.ToUpper();

            var cr1 = ws.Cells.GetSubrangeAbsolute(row, 0, row, ws.CalculateMaxUsedColumns() - 1);
            cr1.Merged = true;
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Left, 10, ExcelFont.NormalWeight);
            cell.Value = value.ToUpper();
        }

        /// <summary>
        /// AddFooter
        /// </summary>
        public void AddFooter()
        {
            ExcelCell cell = ws.Cells[rowStart + 5, 2];
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Right, 10, ExcelFont.BoldWeight);
            cell.Value = string.Format("NGƯỜI GIAO");

            cell = ws.Cells[rowStart + 5, ws.CalculateMaxUsedColumns() - 2];
            cell.Style = SetStyleHeader(HorizontalAlignmentStyle.Right, 10, ExcelFont.BoldWeight);
            cell.Value = string.Format("NGƯỜI NHẬN");
        }
        #endregion

    }
}
