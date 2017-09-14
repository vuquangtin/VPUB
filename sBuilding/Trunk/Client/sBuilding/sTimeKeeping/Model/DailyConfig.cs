using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Model
{
    public class DailyConfig
    {
        public long id { get; set; }
        public long orgId { get; set; }
        public string date { get; set; }
        public string jsonTimeConfig { get; set; }
    }
}
