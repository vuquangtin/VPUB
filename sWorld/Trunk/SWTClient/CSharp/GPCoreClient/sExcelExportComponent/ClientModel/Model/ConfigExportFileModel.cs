using sExcelExportComponent.ClientModel.Format;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientModel.Model
{
    public class ConfigExportFileModel
    {
        private int NumberDefault = 20;

        public string FilePath { get; set; }

        public string HeaderText { get; set; }
        public string SheetName { get; set; }
        public string FontName { get; set; }
        private int FontSizeHeader { get; set; }
        private int FontSizeContent { get; set; }

        private int RowHeightHeader { get; set; }
        private int RowHeightContent { get; set; }

        public int SizePageA4Width { get; set; }
        public int SizePageA4Height { get; set; }

        public bool ShowBackgroundContent { get; set; }
        public Color BackgroundColorHeader { get; set; }
        public Color FontColorHeader { get; set; }

        public Color BackgroundColorContent { get; set; }
        public Color FontColorContent { get; set; }

        public string ShortDateFormat { get; set; }
        public string LongDateFormat { get; set; }
        public string NumberFormat { get; set; }
        public string CurrecyFormat { get; set; }

        public float AutoFixScaling { get; set; }

        public ConfigExportFileModel()
        {
            HeaderText = string.Empty;
            SheetName = "Sheet 1";
            FontName = "Tahoma";
            FontSizeHeader = 10 * NumberDefault; //size * SoCodinh = size goc
            FontSizeContent = 10 * NumberDefault;//size * SoCodinh = size goc

            RowHeightHeader = 30 * 20;
            RowHeightContent = 20 * 20;

            SizePageA4Width = 21000;
            SizePageA4Height = 29700;

            ShowBackgroundContent = true;
            BackgroundColorHeader = System.Drawing.ColorTranslator.FromHtml("#244062");
            FontColorHeader = Color.White;

            BackgroundColorContent = System.Drawing.ColorTranslator.FromHtml("#dce6f1");
            FontColorContent = Color.Black;

            ShortDateFormat = DataGeneralFormat.DateFullyNonPlaceHolderFormat;
            LongDateFormat = DataGeneralFormat.DateTimeFullyNonPlaceHolderFormat;
            NumberFormat = "0";
            CurrecyFormat = "0";

            AutoFixScaling = 1.3f;
        }
        public float GetAutoFixScaling()
        {
            return AutoFixScaling;
        }

        public int GetFontSizeHeader()
        {
            return FontSizeHeader;
        }

        public int GetFontSizeContent()
        {
            return FontSizeContent;
        }

        public int SetFontSizeHeader(int size)
        {
            return FontSizeHeader = size * 20;
        }

        public int SetFontSizeContent(int size)
        {
            return FontSizeContent = size * 20;
        }

        public int GetRowHeightHeader()
        {
            return RowHeightHeader;
        }

        public int GetRowHeightContent()
        {
            return RowHeightContent;
        }

        public int SetRowHeightHeader(int size)
        {
            return RowHeightHeader = size * 20;
        }

        public int SetRowHeightContent(int size)
        {
            return RowHeightContent = size * 20;
        }

        public int GetSizePageA4Width()
        {
            return SizePageA4Width;
        }

        public int SetSizePageA4Width(int size)
        {
            return SizePageA4Width = size ;
        }

        public int GetSizePageA4Height()
        {
            return SizePageA4Height;
        }

        public int SetSizePageA4Height(int size)
        {
            return SizePageA4Height = size;
        }
    }
}
