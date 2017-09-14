using ExcelLibrary.SpreadSheet;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MemberMgtComponent
{
    public class DataManagerFileExcel
    {
        private Workbook workbook;
        private string filePath;

        private static DataManagerFileExcel instance = new DataManagerFileExcel();
        public static DataManagerFileExcel Instance
        {
            get {
                if (instance == null){
                    instance = new DataManagerFileExcel();
                }
                return instance;
            }
        }
        private DataManagerFileExcel()
        {
        }

        public string[] LoadSheetNames(string path)
        {
            string[] result = null;

            if (OpenWorkbook(path))
            {
                result = new string[workbook.Worksheets.Count];
                for (int i = 0; i < workbook.Worksheets.Count; i++)
                {
                    result[i] = workbook.Worksheets[i].Name;
                }
            }

            return result;
        }

        public List<MemberDataImportFromExcelDto> LoadBookImportDataExcel(string path, int sheetIndex, int titleRowIndex, int phoneColIndex, int firstNameColIndex, int lastNameColIndex, int companyColIndex, int genderColIndex, int nationalityColIndex, int birthdayColIndex, int permanentAddressColIndex, int temporaryAdressColIndex, int emailColIndex, int degreeColIndex, int positionColIndex)
        {
            if (!OpenWorkbook(path))
            {
                return null;
            }
            List<MemberDataImportFromExcelDto> MemberDataExcelDtos = new List<MemberDataImportFromExcelDto>();

            if (sheetIndex < 0)
            {
                for (int i = 0; i < workbook.Worksheets.Count; i++)
                {
                    MemberDataExcelDtos.AddRange(LoadSheetData(i, titleRowIndex, phoneColIndex, firstNameColIndex, lastNameColIndex, companyColIndex,  genderColIndex,  nationalityColIndex, birthdayColIndex, permanentAddressColIndex, temporaryAdressColIndex,  emailColIndex,  degreeColIndex,  positionColIndex));
                }
            }
            else
            {
                MemberDataExcelDtos.AddRange(LoadSheetData(sheetIndex, titleRowIndex, phoneColIndex, firstNameColIndex, lastNameColIndex, companyColIndex, genderColIndex, nationalityColIndex, birthdayColIndex, permanentAddressColIndex, temporaryAdressColIndex, emailColIndex, degreeColIndex, positionColIndex));
            }

            return MemberDataExcelDtos;
        }


        private List<MemberDataImportFromExcelDto> LoadSheetData(int sheetIndex, int titleRowIndex, int phoneColIndex, int firstNameColIndex, int lastNameColIndex, int birthdayColIndex, int companyColIndex, int genderColIndex, int nationalityColIndex, int permanentAddressColIndex, int temporaryAdressColIndex, int emailColIndex, int degreeColIndex, int positionColIndex)
        {
            List<MemberDataImportFromExcelDto> result = new List<MemberDataImportFromExcelDto>();
            CellCollection cellsOfSheet = workbook.Worksheets[sheetIndex].Cells;
            Row currentRow;

            if (firstNameColIndex == lastNameColIndex)
            {
                string phoneNumber, fullName, companyName, birthday, gender, nationality, email, permanentyAddress, temporaryAddress, degree, position ;

                for (int i = titleRowIndex + 1; i <= cellsOfSheet.LastRowIndex; i++)
                {
                    if (!cellsOfSheet.Rows.ContainsKey(i))
                    {
                        continue;
                    }
                    currentRow = cellsOfSheet.Rows[i];

                    fullName = currentRow.GetCell(firstNameColIndex).StringValue;
                    if (string.IsNullOrEmpty(fullName))
                    {
                        continue;
                    }
                    phoneNumber = currentRow.GetCell(phoneColIndex).StringValue;
                    companyName = currentRow.GetCell(companyColIndex).StringValue;
                    birthday = currentRow.GetCell(birthdayColIndex).StringValue;
                    gender = currentRow.GetCell(genderColIndex).StringValue;
                    nationality = currentRow.GetCell(nationalityColIndex).StringValue;
                    email = currentRow.GetCell(emailColIndex).StringValue;
                    permanentyAddress = currentRow.GetCell(permanentAddressColIndex).StringValue;
                    temporaryAddress = currentRow.GetCell(temporaryAdressColIndex).StringValue;
                    degree = currentRow.GetCell(genderColIndex).StringValue;
                    position = currentRow.GetCell(positionColIndex).StringValue;

                    MemberDataImportFromExcelDto c = new MemberDataImportFromExcelDto();
                    c.FullName = fullName;
                    c.PhoneNumber = phoneNumber;
                    c.CompanyName = companyName;
                    c.RowIndex = i;
                    c.SheetName = workbook.Worksheets[sheetIndex].Name;
                    c.Birthday = birthday;
                    c.Email = email;
                    c.Gender = gender;
                    c.Postion = position;
                    c.Degree = degree;
                    c.Nationality = nationality;
                    c.TemporaryAddress = temporaryAddress;
                    c.PermanentAddress = permanentyAddress;
                    result.Add(c);
                }
            }
            else
            {
                string phoneNumber, firstName, lastName, fullName, companyName, birthday, gender, nationality, email, permanentyAddress, temporaryAddress, degree, position;

                for (int i = titleRowIndex + 1; i <= cellsOfSheet.LastRowIndex; i++)
                {
                    currentRow = cellsOfSheet.Rows[i];

                    firstName = currentRow.GetCell(firstNameColIndex).StringValue;
                    lastName = currentRow.GetCell(lastNameColIndex).StringValue;
                    if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                    {
                        continue;
                    }
                    fullName = (lastName == null ? lastName = string.Empty : lastName) + " " + (firstName == null ? firstName = string.Empty : firstName);
                    phoneNumber = currentRow.GetCell(phoneColIndex).StringValue;
                    companyName = currentRow.GetCell(companyColIndex).StringValue;
                    birthday = currentRow.GetCell(birthdayColIndex).StringValue;
                    gender = currentRow.GetCell(genderColIndex).StringValue;
                    nationality = currentRow.GetCell(nationalityColIndex).StringValue;
                    email = currentRow.GetCell(emailColIndex).StringValue;
                    permanentyAddress = currentRow.GetCell(permanentAddressColIndex).StringValue;
                    temporaryAddress = currentRow.GetCell(temporaryAdressColIndex).StringValue;
                    degree = currentRow.GetCell(genderColIndex).StringValue;
                    position = currentRow.GetCell(positionColIndex).StringValue;

                    MemberDataImportFromExcelDto c = new MemberDataImportFromExcelDto();
                    c.FullName = fullName;
                    c.PhoneNumber = phoneNumber;
                    c.CompanyName = companyName;
                    c.RowIndex = i;
                    c.SheetName = workbook.Worksheets[sheetIndex].Name;
                    c.Birthday = birthday;
                    c.Email = email;
                    c.Gender = gender;
                    c.Postion = position;
                    c.Degree = degree;
                    c.Nationality = nationality;
                    c.TemporaryAddress = temporaryAddress;
                    c.PermanentAddress = permanentyAddress;
                    result.Add(c);
                }
            }

            return result;
        }

        public List<MemberDataExcelDto> LoadBookData(string path, int sheetIndex, int titleRowIndex, int phoneColIndex, int firstNameColIndex, int lastNameColIndex, int companyColIndex, int expiredTimeColIndex)
        {
            if (!OpenWorkbook(path))
            {
                return null;
            }
            List<MemberDataExcelDto> MemberDataExcelDtos = new List<MemberDataExcelDto>();

            if (sheetIndex < 0)
            {
                for (int i = 0; i < workbook.Worksheets.Count; i++)
                {
                    MemberDataExcelDtos.AddRange(LoadSheetData(i, titleRowIndex, phoneColIndex, firstNameColIndex, lastNameColIndex, companyColIndex, expiredTimeColIndex));
                }
            }
            else
            {
                MemberDataExcelDtos.AddRange(LoadSheetData(sheetIndex, titleRowIndex, phoneColIndex, firstNameColIndex, lastNameColIndex, companyColIndex, expiredTimeColIndex));
            }

            return MemberDataExcelDtos;
        }

        private List<MemberDataExcelDto> LoadSheetData(int sheetIndex, int titleRowIndex, int phoneColIndex, int firstNameColIndex, int lastNameColIndex, int companyColIndex, int expiredTimeColIndex)
        {
            List<MemberDataExcelDto> result = new List<MemberDataExcelDto>();
            CellCollection cellsOfSheet = workbook.Worksheets[sheetIndex].Cells;
            Row currentRow;

            if (firstNameColIndex == lastNameColIndex)
            {
                string phoneNumber, fullName, companyName, expiredTime;

                for (int i = titleRowIndex + 1; i <= cellsOfSheet.LastRowIndex; i++)
                {
                    if (!cellsOfSheet.Rows.ContainsKey(i))
                    {
                        continue;
                    }
                    currentRow = cellsOfSheet.Rows[i];

                    fullName = currentRow.GetCell(firstNameColIndex).StringValue;
                    if (string.IsNullOrEmpty(fullName))
                    {
                        continue;
                    }
                    phoneNumber = currentRow.GetCell(phoneColIndex).StringValue;
                    companyName = currentRow.GetCell(companyColIndex).StringValue;
                    expiredTime = currentRow.GetCell(expiredTimeColIndex).StringValue;

                    MemberDataExcelDto c = new MemberDataExcelDto();
                    c.FullName = fullName;
                    c.PhoneNumber = phoneNumber;
                    c.CompanyName = companyName;
                    c.RowIndex = i;
                    c.SheetName = workbook.Worksheets[sheetIndex].Name;
                    c.ExpiredTime = expiredTime;
                    result.Add(c);
                }
            }
            else
            {
                string phoneNumber, firstName, lastName, fullName, companyName, expiredTime;

                for (int i = titleRowIndex + 1; i <= cellsOfSheet.LastRowIndex; i++)
                {
                    currentRow = cellsOfSheet.Rows[i];

                    firstName = currentRow.GetCell(firstNameColIndex).StringValue;
                    lastName = currentRow.GetCell(lastNameColIndex).StringValue;
                    if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
                    {
                        continue;
                    }
                    fullName = (lastName == null ? lastName = string.Empty : lastName) + " " + (firstName == null ? firstName = string.Empty : firstName);
                    phoneNumber = currentRow.GetCell(phoneColIndex).StringValue;
                    companyName = currentRow.GetCell(companyColIndex).StringValue;
                    expiredTime = currentRow.GetCell(expiredTimeColIndex).StringValue;

                    MemberDataExcelDto c = new MemberDataExcelDto();
                    c.FullName = fullName;
                    c.PhoneNumber = phoneNumber;
                    c.CompanyName = companyName;
                    c.RowIndex = i;
                    c.SheetName = workbook.Worksheets[sheetIndex].Name;
                    c.ExpiredTime = expiredTime;
                    result.Add(c);
                }
            }

            return result;
        }

        private bool OpenWorkbook(string path)
        {
            if (filePath != null && filePath.Equals(path))
            {
                return true;
            }

            try
            {
                workbook = Workbook.Load(path);
                return true;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Không mở được tập tin Excel!" + Environment.NewLine + Environment.NewLine + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không mở được tập tin Excel!" + Environment.NewLine + Environment.NewLine + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }
    }
}
