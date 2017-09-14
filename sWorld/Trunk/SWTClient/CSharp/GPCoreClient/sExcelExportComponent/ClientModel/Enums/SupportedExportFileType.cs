using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientModel.Enums
{
          public enum SupportedExportFileType : byte
        {
            Xls = 1,
            Xlsx = 2,
            Ods = 4,
            Pdf = 5,
            Doc = 6,
            Docx = 7,
        }

        public static class SupportedExportFileTypeExt
        {
            private static List<SupportedExportFileType> fileTypes = null;
            private static readonly object lob = new object();

            public static List<SupportedExportFileType> GetSupportedExportFileTypeList()
            {
                if (fileTypes == null)
                {
                    lock (lob)
                    {
                        if (fileTypes == null)
                        {
                            fileTypes = Enum.GetValues(typeof(SupportedExportFileType)).Cast<SupportedExportFileType>().ToList();
                            fileTypes.Sort((x, y) => { return string.Compare(x.GetName(), y.GetName()); });
                        }
                    }
                }
                // Clone chứ không trả về reference đến instance gốc
                return fileTypes.ToList();
            }

            public static List<SupportedExportFileType> GetSupportedSpreadsheetFileTypeList()
            {
                var result = new List<SupportedExportFileType>
            {
                SupportedExportFileType.Xls,
                SupportedExportFileType.Xlsx,
                SupportedExportFileType.Ods,
            };
                result.Sort((x, y) => x.GetName().CompareTo(y.GetName()));
                return result;
            }

            public static string GetName(this SupportedExportFileType fileType)
            {
                switch (fileType)
                {
                    case SupportedExportFileType.Doc:
                        return "Microsoft Word 97 - 2003 (*.doc)";
                    case SupportedExportFileType.Docx:
                        return "Microsoft Word (*.docx)";
                    case SupportedExportFileType.Ods:
                        return "OpenDocument Spreadsheet (*.ods)";
                    case SupportedExportFileType.Pdf:
                        return "Portable Document Format (*.pdf)";
                    case SupportedExportFileType.Xls:
                        return "Microsoft Excel 97 - 2003 (*.xls)";
                    case SupportedExportFileType.Xlsx:
                        return "Microsoft Excel (*.xlsx)";
                    default:
                        return string.Empty;
                }
            }

            public static string GetFormat(this SupportedExportFileType fileType)
            {
                switch (fileType)
                {
                    case SupportedExportFileType.Doc:
                        return "Microsoft Word 97 - 2003 (*.doc)|*.doc";
                    case SupportedExportFileType.Docx:
                        return "Microsoft Word (*docx)|*.docx";
                    case SupportedExportFileType.Ods:
                        return "OpenDocument Spreadsheet (*.ods)|*.ods";
                    case SupportedExportFileType.Pdf:
                        return "Portable Document Format (*.pdf)|*.pdf";
                    case SupportedExportFileType.Xls:
                        return "Microsoft Excel 97 - 2003 (*.xls)|*.xls";
                    case SupportedExportFileType.Xlsx:
                        return "Microsoft Excel (*.xlsx)|*.xlsx";
                    default:
                        return string.Empty;
                }
            }

            public static string GetExtension(this SupportedExportFileType fileType)
            {
                switch (fileType)
                {
                    case SupportedExportFileType.Doc:
                        return "doc";
                    case SupportedExportFileType.Docx:
                        return "docx";
                    case SupportedExportFileType.Ods:
                        return "ods";
                    case SupportedExportFileType.Pdf:
                        return "pdf";
                    case SupportedExportFileType.Xls:
                        return "xls";
                    case SupportedExportFileType.Xlsx:
                        return "xlsx";
                    default:
                        return string.Empty;
                }
            }
        }
    
}
