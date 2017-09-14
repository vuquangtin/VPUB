using System.Collections.Generic;
using ExcelLibrary.SpreadSheet;
using sWorldModel.Integrating;
using CryptoHelper.Hashing;
using sWorldModel.TransportData;
using System;
using System.Data;
using System.Windows.Forms;
using CommonControls.Custom;
using System.Linq;
using CommonHelper.Utils;
using System.Text;
using GemBox.Spreadsheet;
using System.IO;
using ClientModel.Enums;

namespace SystemMgtComponent.WorkItems.IntegratingExcel
{
    public class ExcelReader
    {
        /// <summary>
        /// my.nguyen
        /// get list member from all styles file excel .xlsx .xls
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <param name="colCodeIndex"></param>
        /// <param name="colFirstNameIndex"></param>
        /// <param name="colLastNameIndex"></param>
        /// <param name="colBirthDateIndex"></param>
        /// <param name="colCompanynameIndex"></param>
        /// <param name="colGenderIndex"></param>
        /// <param name="colDegreeIndex"></param>
        /// <param name="colPositionIndex"></param>
        /// <param name="colPermanentAddressIndex"></param>
        /// <param name="colTemporaryAddressIndex"></param>
        /// <param name="ColPhoneNoIndex"></param>
        /// <param name="colEmailIndex"></param>
        /// <param name="colNationalityIndex"></param>
        /// <param name="colContactNameIndex"></param>
        /// <param name="colContactPhoneIndex"></param>
        /// <param name="colContactEmailIndex"></param>
        /// <param name="colContactAddressIndex"></param>
        /// <param name="colIdentityCardIndex"></param>
        /// <param name="colIdentityCardDateIndex"></param>
        /// <param name="colIdentityCardIssueIndex"></param>
        /// <param name="firstRowIndex"></param>
        /// <param name="isOk"></param>
        /// <returns></returns>
        public static List<sWorldModel.TransportData.Member> SelectAllMemberListFORALLSTYLESFILEEXCEL(
               string filePath, long orgId, long subOrgId, int colCodeIndex, int colFirstNameIndex,
               int colLastNameIndex, int colBirthDateIndex, int colCompanynameIndex, int colGenderIndex,
               int colDegreeIndex, int colPositionIndex, int colPermanentAddressIndex,
               int colTemporaryAddressIndex, int ColPhoneNoIndex, int colEmailIndex, int colNationalityIndex,
               int colContactNameIndex, int colContactPhoneIndex, int colContactEmailIndex, int colContactAddressIndex,
               int colIdentityCardIndex, int colIdentityCardDateIndex, int colIdentityCardIssueIndex,
               int firstRowIndex, string Title, out bool isOk)
        {
            isOk = true;
            List<sWorldModel.TransportData.Member> result = new List<sWorldModel.TransportData.Member>();
            XXHashUnsafe hashEngine = new XXHashUnsafe();

            // open xls file
            //    SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            //    ExcelFile ef = ExcelFile.Load(filePath);

            ExcelFile ef = new ExcelFile();
            string strExtension = Path.GetExtension(filePath);

            if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Xls.GetExtension())))
            {
                ef.LoadXls(filePath);
            }
            if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Xlsx.GetExtension())))
            {
                ef.LoadXlsx(filePath, XlsxOptions.None);
            }
            if (strExtension.Equals(string.Format(".{0}", SupportedExportFileType.Ods.GetExtension())))
            {
                ef.LoadOds(filePath, OdsOptions.None);
            }

            ExcelWorksheet sheet = ef.Worksheets[0];

            //    foreach (ExcelRow row in sheet.Rows)
            //    {
            //        foreach (ExcelCell cell in row.AllocatedCells)
            //        {
            //            if (cell.ValueType != CellValueType.Null)
            //            { }
            //        }
            //    }

            // traverse rows by Index
            var usedRange = sheet.GetUsedCellRange(true);
            int lastUsedRow = usedRange.LastRowIndex;
            int lastUsedRowv2 = sheet.Rows.Count - 1;

            for (int rowIndex = firstRowIndex; rowIndex <= lastUsedRow; rowIndex++)
            {
                ExcelRow row = sheet.Rows[rowIndex];
                sWorldModel.TransportData.Member memberCus = new sWorldModel.TransportData.Member();

                //        // Member code
                //        string code = null;
                //        try
                //        {
                //            code = row.Cells[colCodeIndex].StringValue;
                //        }
                //        catch (Exception x)
                //        {
                //            code = null;
                //        }
                //        if (code == null)
                //        {
                //            continue;
                //        }
                //        code = code.Trim();
                //        if (code.Length == 0)
                //        {
                //            continue;
                //        }

                memberCus = new sWorldModel.TransportData.Member
                {
                    OrgId = orgId,
                    SubOrgId = subOrgId,
                    Code = (colCodeIndex == -1) ? "" : GetValuesCell(row, colCodeIndex),

                    Title = Title,

                    FirstName = (colLastNameIndex == -1) ? "" : GetValuesCell(row, colLastNameIndex),
                    LastName = (colFirstNameIndex == -1) ? "" : GetValuesCell(row, colFirstNameIndex),
                    BirthDate = (colBirthDateIndex == -1) ? "" : GetValuesCell(row, colBirthDateIndex),
                    Companyname = (colCompanynameIndex == -1) ? "" : GetValuesCell(row, colCompanynameIndex),
                    Gender = (colGenderIndex == -1) ? 2 : (GetValuesCell(row, colGenderIndex).Equals("Nam") ? 1 : 2),
                    Degree = (colDegreeIndex == -1) ? "" : GetValuesCell(row, colDegreeIndex),
                    Position = (colPositionIndex == -1) ? "" : GetValuesCell(row, colPositionIndex),
                    PermanentAddress = (colPermanentAddressIndex == -1) ? "" : GetValuesCell(row, colPermanentAddressIndex),
                    TemporaryAddress = (colTemporaryAddressIndex == -1) ? "" : GetValuesCell(row, colTemporaryAddressIndex),
                    PhoneNo = (ColPhoneNoIndex == -1) ? "" : GetValuesCell(row, ColPhoneNoIndex),
                    Email = (colEmailIndex == -1) ? "" : GetValuesCell(row, colEmailIndex),
                    Nationality = (colNationalityIndex == -1) ? "" : GetValuesCell(row, colNationalityIndex),

                    IdentityCard = (colIdentityCardIndex == -1) ? "" : GetValuesCell(row, colIdentityCardIndex),
                    IdentityCardIssueDate = (colIdentityCardDateIndex == -1) ? "" : GetValuesCell(row, colIdentityCardDateIndex),
                    IdentityCardIssue = (colIdentityCardIssueIndex == -1) ? "" : GetValuesCell(row, colIdentityCardIssueIndex),
                    ContactName = (colContactNameIndex == -1) ? "" : GetValuesCell(row, colContactNameIndex),
                    ContactPhone = (colContactPhoneIndex == -1) ? "" : GetValuesCell(row, colContactPhoneIndex),
                    ContactEmail = (colContactEmailIndex == -1) ? "" : GetValuesCell(row, colContactEmailIndex),
                    ContactAddress = (colContactAddressIndex == -1) ? "" : GetValuesCell(row, colContactAddressIndex),
                };

                result.Add(memberCus);
            }
            return result;

        }
        /// <summary>
        /// get values cell
        /// </summary>
        /// <param name="row"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        private static string GetValuesCell(ExcelRow row, int index)
        {
            //    if (row.Cells[index].Value != null)
            //        return row.Cells[index].StringValue;

            if (row.Cells[index].Value != null)
                return row.Cells[index].Value.ToString();
            else
                return "";
        }

        /// <summary>
        /// not useing
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <param name="colCodeIndex"></param>
        /// <param name="colFirstNameIndex"></param>
        /// <param name="colLastNameIndex"></param>
        /// <param name="colBirthDateIndex"></param>
        /// <param name="colCompanynameIndex"></param>
        /// <param name="colGenderIndex"></param>
        /// <param name="colDegreeIndex"></param>
        /// <param name="colPositionIndex"></param>
        /// <param name="colPermanentAddressIndex"></param>
        /// <param name="colTemporaryAddressIndex"></param>
        /// <param name="ColPhoneNoIndex"></param>
        /// <param name="colEmailIndex"></param>
        /// <param name="colNationalityIndex"></param>
        /// <param name="colContactNameIndex"></param>
        /// <param name="colContactPhoneIndex"></param>
        /// <param name="colContactEmailIndex"></param>
        /// <param name="colContactAddressIndex"></param>
        /// <param name="colIdentityCardIndex"></param>
        /// <param name="colIdentityCardDateIndex"></param>
        /// <param name="colIdentityCardIssueIndex"></param>
        /// <param name="firstRowIndex"></param>
        /// <param name="isOk"></param>
        /// <returns></returns>
        public static List<sWorldModel.TransportData.Member> SelectAllMemberList(
          string filePath, long orgId, long subOrgId, int colCodeIndex, int colFirstNameIndex,
          int colLastNameIndex, int colBirthDateIndex, int colCompanynameIndex, int colGenderIndex,
          int colDegreeIndex, int colPositionIndex, int colPermanentAddressIndex,
          int colTemporaryAddressIndex, int ColPhoneNoIndex, int colEmailIndex, int colNationalityIndex,
          int colContactNameIndex, int colContactPhoneIndex, int colContactEmailIndex, int colContactAddressIndex,
          int colIdentityCardIndex, int colIdentityCardDateIndex, int colIdentityCardIssueIndex,
          int firstRowIndex, string Title, out bool isOk)
        {
            isOk = true;
            List<sWorldModel.TransportData.Member> result = new List<sWorldModel.TransportData.Member>();
            XXHashUnsafe hashEngine = new XXHashUnsafe();

            Workbook book;
            book = Workbook.Load(filePath);
            Worksheet sheet = book.Worksheets[0];
            // traverse rows by Index
            for (int rowIndex = firstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                Row row = sheet.Cells.GetRow(rowIndex);
                sWorldModel.TransportData.Member memberCus = new sWorldModel.TransportData.Member();
                // Member code
                string code = row.GetCell(colCodeIndex).StringValue;
                if (code == null)
                {
                    continue;
                }
                code = code.Trim();
                if (code.Length == 0)
                {
                    continue;
                }

                memberCus = new sWorldModel.TransportData.Member
                {
                    OrgId = orgId,
                    SubOrgId = subOrgId,
                    Code = row.GetCell(colCodeIndex).StringValue,

                    Title = Title,

                    FirstName = row.GetCell(colLastNameIndex).StringValue,
                    LastName = row.GetCell(colFirstNameIndex).StringValue,
                    BirthDate = row.GetCell(colBirthDateIndex).StringValue,
                    Companyname = row.GetCell(colCompanynameIndex).StringValue,
                    Gender = row.GetCell(colGenderIndex).StringValue.Equals("Nam") ? 1 : 2,
                    Degree = row.GetCell(colDegreeIndex).StringValue,
                    Position = row.GetCell(colPositionIndex).StringValue,
                    PermanentAddress = row.GetCell(colPermanentAddressIndex).StringValue,
                    TemporaryAddress = row.GetCell(colTemporaryAddressIndex).StringValue,
                    PhoneNo = row.GetCell(ColPhoneNoIndex).StringValue,
                    Email = row.GetCell(colEmailIndex).StringValue,
                    Nationality = row.GetCell(colNationalityIndex).StringValue,

                    IdentityCard = row.GetCell(colIdentityCardIndex).StringValue,
                    IdentityCardIssueDate = row.GetCell(colIdentityCardDateIndex).StringValue,
                    IdentityCardIssue = row.GetCell(colIdentityCardIssueIndex).StringValue,
                    ContactName = row.GetCell(colContactNameIndex).StringValue,
                    ContactPhone = row.GetCell(colContactPhoneIndex).StringValue,
                    ContactEmail = row.GetCell(colContactEmailIndex).StringValue,
                    ContactAddress = row.GetCell(colContactAddressIndex).StringValue,
                };
                //try
                //{
                //    DateTime date = memberCus.objMem.BirthDate.ToDateFormatString();
                //    isOk = true;
                //}
                //catch (Exception ex)
                //{
                //    isOk = false;
                //    break;
                //}
                result.Add(memberCus);
            }
            return result;
        }

    }
}
