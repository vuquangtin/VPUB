using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonControls.Custom
{
    public class ComboBoxItem
    {
        public string ValueMember { get; set; }

        public string DisplayMember { get; set; }

        public override string ToString()
        {
            return DisplayMember;
        }
    }
}
