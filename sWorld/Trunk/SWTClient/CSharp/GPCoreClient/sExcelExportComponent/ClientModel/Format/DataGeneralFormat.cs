using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace sExcelExportComponent.ClientModel.Format
{
    public class DataGeneralFormat
    {
        public static readonly CultureInfo VietnameseCultureInfo = new CultureInfo("vi-VN");

        public const string CurrencyFormat = "{0:n0}";

        public const string DateTimeFullyFormat = @"{0:HH:mm:ss dd/MM/yyyy}";
        public const string DateFullyFormat = @"{0:dd/MM/yyyy}";
        public const string TimeFullyFormat = @"{0:HH:mm:ss}";

        public const string DateTimeFullyNonPlaceHolderFormat = @"HH:mm:ss dd/MM/yyyy";
        public const string DateFullyNonPlaceHolderFormat = @"dd/MM/yyyy";
        public const string TimeFullyNonPlaceHolderFormat = @"HH:mm:ss";
    }
}
