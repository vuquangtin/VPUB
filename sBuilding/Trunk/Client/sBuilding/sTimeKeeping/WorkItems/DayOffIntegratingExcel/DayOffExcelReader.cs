using ClientModel.Enums;
using CryptoHelper.Hashing;
using GemBox.Spreadsheet;
using sTimeKeeping.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace sTimeKeeping.WorkItems.DayOffIntegratingExcel
{
    /// <summary>
    ///  class DayOffExcelReader
    /// </summary>
    public class DayOffExcelReader
    {
        /// <summary>
        /// get values cell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static string GetValuesCell(ExcelRow row, int index)
        {
            if (row.Cells[index].Value != null)
                return row.Cells[index].Value.ToString();
            else
                return "";
        }

        /// <summary>
        /// Select All DayOff of excel
        /// </summary>
        /// <returns></returns>
        public static List<DayOffImportObject> SelectAllDayOffList(
            string filePath, long orgId, long subOrgId, int colMemberCodeIndex, int colMemberNameIndex,
            int colDateIndex, int colTypeDayOffIndex, int colNoteIndex, int firstRowIndex, out bool isOk)
        {
            isOk = true;
            //tao bien
            List<DayOffImportObject> result = new List<DayOffImportObject>();
            try
            {
                XXHashUnsafe hashEngine = new XXHashUnsafe();

                ExcelFile ef = new ExcelFile();
                string strExtension = Path.GetExtension(filePath);

                // load file .Xls
                if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Xls.GetExtension())))
                {
                    ef.LoadXls(filePath);
                }

                // load file .Xlsx
                if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Xlsx.GetExtension())))
                {
                    ef.LoadXlsx(filePath, XlsxOptions.None);
                }

                // load file .Ods
                if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Ods.GetExtension())))
                {
                    ef.LoadOds(filePath, OdsOptions.None);
                }

                ExcelWorksheet sheet = ef.Worksheets[0];

                // traverse rows by Index
                for (int rowIndex = firstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
                {
                    ExcelRow row = sheet.Rows[rowIndex];
                    DayOffImportObject dayoffCus = new DayOffImportObject();
                    // Event name
                    string eventName = GetValuesCell(row, colMemberCodeIndex);
                    if (eventName == null)
                    {
                        continue;
                    }

                    eventName = eventName.Trim();
                    if (eventName.Length == 0)
                    {
                        continue;
                    }
                    // create doi tuong
                    dayoffCus = new DayOffImportObject
                    {
                        OrgId = orgId,
                        SubOrgId = subOrgId,
                        MemberCode = (colMemberCodeIndex == -1) ? "" : GetValuesCell(row, colMemberCodeIndex),
                        MemberName = (colMemberNameIndex == -1) ? "" : GetValuesCell(row, colMemberNameIndex),
                        DateOff = (colDateIndex == -1) ? "" : GetValuesCell(row, colDateIndex),
                        TypeDayOff = (colTypeDayOffIndex == -1) ? 0 : Convert.ToInt32(GetValuesCell(row, colTypeDayOffIndex))

                        // Bo cot ly do xin nghi
                        //Note = (colNoteIndex == -1) ? "" : GetValuesCell(row, colNoteIndex)
                    };
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

                    // add vao list
                    result.Add(dayoffCus);
                }

            }
            catch (Exception e)
            {

            }
            return result;
        }
    }
}
