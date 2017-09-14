using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderManager.Enum;

namespace ReaderManager.Model
{
    // Object License cho các hàm liên quan Licehse trong các hiện thực của Interface IReader
    // tại 1 thời điểm chỉ có 1 license
    public class LicenseReader
    {
        public const int SWT = 1;
        public const int PARTNER = 2;
        public const int OTHER = 3;
        private ACTION_MODE mode;
        public ACTION_MODE Mode
        {
            set { this.mode = value; }
            get { return this.mode; }
        }
        public LicenseReader(int currentLicense, byte start, byte stop)
        {
            this.currentLicense = currentLicense;
            this.start = start;
            this.stop = stop;
        }
        public int currentLicense { get; set; }
        public byte start { get; set; }

        public byte stop { get; set; }

       
    }

}
