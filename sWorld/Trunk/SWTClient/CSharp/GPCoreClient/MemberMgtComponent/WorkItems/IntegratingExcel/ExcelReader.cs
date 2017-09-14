using System.Collections.Generic;
using ExcelLibrary.SpreadSheet;
using sWorldModel.Integrating;
using CryptoHelper.Hashing;
using sWorldModel.TransportData;
using System;
using System.Data;
using System.Windows.Forms;
using CommonControls.Custom;

namespace MemberMgtComponent.WorkItems.IntegratingExcel
{
    public class ExcelReader
    {
        public static List<Member> SelectAllMemberList(
            string filePath, long orgId, long subOrgId, int colCodeIndex, int colFirstNameIndex,
            int colLastNameIndex, int colBirthDateIndex, int colCompanynameIndex, int colGenderIndex,
            int colDegreeIndex, int colPositionIndex, int colPermanentAddressIndex,
            int colTemporaryAddressIndex, int ColPhoneNoIndex, int colEmailIndex, int colNationalityIndex,
            int firstRowIndex)
        {
            List<Member> result = new List<Member>();
            XXHashUnsafe hashEngine = new XXHashUnsafe();

            // open xls file
            Workbook book;
            book = Workbook.Load(filePath);
            Worksheet sheet = book.Worksheets[0];

            // traverse rows by Index
            for (int rowIndex = firstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                Row row = sheet.Cells.GetRow(rowIndex);

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

                Member member = new Member
                {
                    OrgId = orgId,
                    SubOrgId = subOrgId,
                    Code = row.GetCell(colCodeIndex).StringValue,
                    FirstName = row.GetCell(colLastNameIndex).StringValue,
                    LastName = row.GetCell(colFirstNameIndex).StringValue,
                    BirthDate = row.GetCell(colBirthDateIndex).StringValue,
                    Companyname = row.GetCell(colCompanynameIndex).StringValue,
                    Gender = Convert.ToInt32( row.GetCell(colGenderIndex)),
                    Degree = row.GetCell(colDegreeIndex).StringValue,
                    Position = row.GetCell(colPositionIndex).StringValue,
                    PermanentAddress = row.GetCell(colPermanentAddressIndex).StringValue,
                    TemporaryAddress = row.GetCell(colTemporaryAddressIndex).StringValue,
                    PhoneNo = row.GetCell(ColPhoneNoIndex).StringValue,
                    Email = row.GetCell(colEmailIndex).StringValue,
                    Nationality = row.GetCell(colNationalityIndex).StringValue,
                };
                result.Add(member);
            }

            return result;
        }

    }
}
