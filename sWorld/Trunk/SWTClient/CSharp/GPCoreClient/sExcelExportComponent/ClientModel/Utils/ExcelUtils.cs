using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientModel.Utils
{
    public static class ExcelUtils
    {
        /// <summary>
        /// Lấy về tên của cột excel dựa vào số index (one-based)
        /// </summary>
        /// <param name="colIndex"></param>
        /// <returns></returns>
        public static string GetExcelColumnName(int colIndex)
        {
            int dividend = colIndex;
            string columnName = String.Empty;
            int modulo;

            while (dividend > 0)
            {
                modulo = (dividend - 1) % 26;
                columnName = Convert.ToChar(65 + modulo).ToString() + columnName;
                dividend = (int)((dividend - modulo) / 26);
            }

            return columnName;
        }

        /// <summary>
        /// Lấy về con số index (one-based) dựa vào tên cột excel
        /// </summary>
        /// <param name="colName"></param>
        /// <returns></returns>
        public static int GetExcelColumnIndex(string colName)
        {
            int number = 0;
            int pow = 1;

            for (int i = colName.Length - 1; i >= 0; i--)
            {
                number += (colName[i] - 'A' + 1) * pow;
                pow *= 26;
            }

            return number;
        }

        /// <summary>
        /// Sinh ra dãy tên cột excel bắt đầu từ cột A
        /// </summary>
        /// <param name="numCols"></param>
        /// <returns></returns>
        public static string[] GenerateColumnCaptions(int numCols)
        {
            string[] items = new string[numCols];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = GetExcelColumnName(i + 1);
            }
            return items;
        }

        public static void WriteToExcel(string filePath, List<Dictionary<string, string>> data)
        {
        }
    }
}
