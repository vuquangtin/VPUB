using System.Collections.Generic;
using sWorldModel.Integrating;
using CryptoHelper.Hashing;
using System;
using System.Data;
using System.Windows.Forms;
using CommonControls.Custom;
using System.Linq;
using CommonHelper.Utils;
using GemBox.Spreadsheet;
using System.Text;
using sTimeKeeping.Model;
using System.IO;
using ClientModel.Enums;


namespace sTimeKeeping.WorkItems.EventIntegratingExcel
{
    /// <summary>
    /// class EventExcelReader
    /// </summary>
    public class EventExcelReader
    {

        /// <summary>
        /// get values cell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static string GetValuesCell(ExcelRow row, int index)
        {
            // kiem tra row.Cells[index].Value != null
            if (row.Cells[index].Value != null)
                return row.Cells[index].Value.ToString();
            else
                return "";
        }

        /// <summary>
        /// trang.vo: Select AllEvent of Excel
        /// </summary>
        /// <returns></returns>
        public static List<EventImportObject> SelectAllEventList(
            string filePath, long orgId, long subOrgId, int colEventNameIndex, int colDateIndex,
            int colHourBeginIndex, int colHourKeepingIndex, int colDescriptionIndex, int colMemberNameIndex,
            int colMemberCodeIndex, int firstRowIndex, out bool isOk)
        {
            // tao bien
            isOk = true;
            List<EventImportObject> result = new List<EventImportObject>();
            XXHashUnsafe hashEngine = new XXHashUnsafe();
            ExcelFile ef = new ExcelFile();
            string strExtension = Path.GetExtension(filePath);

            // load file excel duoi .Xls
            if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Xls.GetExtension())))
            {
                ef.LoadXls(filePath);
            }

            // load file excel duoi .Xlsx
            if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Xlsx.GetExtension())))
            {
                ef.LoadXlsx(filePath, XlsxOptions.None);
            }

            // load file excel duoi .Ods
            if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Ods.GetExtension())))
            {
                ef.LoadOds(filePath, OdsOptions.None);
            }

            // tao bien ExcelWorksheet sheet
            ExcelWorksheet sheet = ef.Worksheets[0];

            // traverse rows by Index
            for (int rowIndex = firstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                ExcelRow row = sheet.Rows[rowIndex];
                EventImportObject eventCus = new EventImportObject();

                // Event name
                string eventName = GetValuesCell(row, colEventNameIndex);

                // kiem tra null
                if (eventName == null)
                {
                    continue;
                }

                eventName = eventName.Trim();

                // kiem tra Length == 0
                if (eventName.Length == 0)
                {
                    continue;
                }

                // tao doi tuong
                eventCus = new EventImportObject
                {
                    OrgId = orgId,
                    SubOrgId = subOrgId,
                    EventName = (colEventNameIndex == -1) ? "" : GetValuesCell(row, colEventNameIndex),
                    Date = (colDateIndex == -1) ? "" : GetValuesCell(row, colDateIndex),
                    HourBegin = (colHourBeginIndex == -1) ? "" : GetValuesCell(row, colHourBeginIndex),
                    HourKeeping = (colHourKeepingIndex == -1) ? 0 : Convert.ToInt32(GetValuesCell(row, colHourKeepingIndex)),
                    Description = (colDescriptionIndex == -1) ? "" : GetValuesCell(row, colDescriptionIndex),
                    MemberCode = (colMemberCodeIndex == -1) ? "" : GetValuesCell(row, colMemberCodeIndex),
                    MemberName = (colMemberNameIndex == -1) ? "" : GetValuesCell(row, colMemberNameIndex)
                };

                // get gia tri memberCode tu file excel
                string memberCode = GetValuesCell(row, colMemberCodeIndex);

                // kiem tra ma thanh vien
                if (memberCode == null)
                {
                    isOk = false;
                    break;
                }
                else
                {
                    isOk = true;
                }

                // add eventCus vao list
                result.Add(eventCus);
            }
            return result;
        }
    }
}
