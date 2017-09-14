using System.Collections.Generic;
using ExcelLibrary.SpreadSheet;
using CryptoHelper.Hashing;
using System;
using System.Linq;
using CommonHelper.Utils;
using System.Reflection;
using System.Text;
using sWorldModel.TransportData;

namespace SystemMgtComponent.WorkItems.CardIntegratingExcel
{
    public class ExcelReader
    {
        public static List<CardChipDto> SelectCardChipList(
            string filePath,int OrgMaserId, int OrgMasterCode, int HeaderPosion,
            int CardType, int Serial, int TypeEncript, int LicenseMaster,
            int PhysicalStatus, int firstRowIndex, out bool isOk)
        {
            isOk = true;
            List<CardChipDto> result = new List<CardChipDto>();
            XXHashUnsafe hashEngine = new XXHashUnsafe();

            // open xls file
            Workbook book;
            book = Workbook.Load(filePath);
            Worksheet sheet = book.Worksheets[0];

            // traverse rows by Index
            for (int rowIndex = firstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                Row row = sheet.Cells.GetRow(rowIndex);
                CardChipDto cardChipDto = new CardChipDto();

                cardChipDto.OrgMasterId = Convert.ToInt64(row.GetCell(OrgMaserId).StringValue); 
                cardChipDto.OrgMasterCode = row.GetCell(OrgMasterCode).StringValue;
                cardChipDto.headerposision = Convert.ToInt32(row.GetCell(HeaderPosion).StringValue);
                cardChipDto.TypeCard = Convert.ToInt32(row.GetCell(CardType).StringValue);
                cardChipDto.SerialNumberHex = row.GetCell(Serial).StringValue;
                cardChipDto.TypeCrypto = row.GetCell(TypeEncript).StringValue;
                cardChipDto.licensemaster = row.GetCell(LicenseMaster).StringValue;
                cardChipDto.PhysicalStatus = Convert.ToInt32(row.GetCell(PhysicalStatus).StringValue);

                result.Add(cardChipDto);
            }
            return result;
        }
    }
}