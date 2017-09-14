using System.Collections.Generic;
using ExcelLibrary.SpreadSheet;
using CryptoHelper.Hashing;
using System;
using System.Linq;
using CommonHelper.Utils;
using System.Reflection;
using System.Text;
using sWorldModel.TransportData;

namespace SystemMgtComponent.WorkItems.ApartmentIntegratingExcel
{
    public class ExcelReader
    {
        public static List<ManagerCostApartment> SelectManagerCostList(
            string filePath,long SubOrgId, int colSubOrgCodeIndex, int colNameHeadApartmentdIndex,
            int colPayManagerIndex, int colPayWaterIndex, int colDayPayIndex, int colManagerCostOldIndex,
            int colSumMoneyIndex, int firstRowIndex, out bool isOk)
        {
            isOk = true;
            List<ManagerCostApartment> result = new List<ManagerCostApartment>();
            XXHashUnsafe hashEngine = new XXHashUnsafe();

            // open xls file
            Workbook book;
            book = Workbook.Load(filePath);
            Worksheet sheet = book.Worksheets[0];

            // traverse rows by Index
            for (int rowIndex = firstRowIndex; rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                Row row = sheet.Cells.GetRow(rowIndex);
                ManagerCostApartment managerCost = new ManagerCostApartment();
                // Ma can ho
                string code = row.GetCell(colSubOrgCodeIndex).StringValue;
                if (string.IsNullOrEmpty(code))
                {
                    break;
                }

                managerCost.SubOrgId = SubOrgId;
                managerCost.SubOrgCode = code.Trim();
                managerCost.NameHeadApartment = row.GetCell(colNameHeadApartmentdIndex).StringValue;
                managerCost.ManagerCostOld = StringUtils.IsNumber(row.GetCell(colManagerCostOldIndex).StringValue) ? 0: Convert.ToDouble(row.GetCell(colManagerCostOldIndex).StringValue);
                managerCost.PayManager = StringUtils.IsNumber(row.GetCell(colPayManagerIndex).StringValue) ? 0 : Convert.ToDouble(row.GetCell(colPayManagerIndex).StringValue);
                managerCost.PayWater = StringUtils.IsNumber(row.GetCell(colPayWaterIndex).StringValue) ? 0 : Convert.ToDouble(row.GetCell(colPayWaterIndex).StringValue);
                managerCost.DayPay = row.GetCell(colDayPayIndex).StringValue;
                managerCost.SumMoney = StringUtils.IsNumber(row.GetCell(colSumMoneyIndex).StringValue) ? 0 : Convert.ToDouble(row.GetCell(colSumMoneyIndex).StringValue);

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
                result.Add(managerCost);
            }
            return result;
        }
    }
}