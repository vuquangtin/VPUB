using sWorldModel.Integrating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sWorldModel.TransportData
{
    [DataContract]
    public class ManagerCostApartment : IntegratingTable
    {

        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public long SubOrgId { get; set; }

        [DataMember]
        public String SubOrgCode { get; set; }

        [DataMember]
        public String NameHeadApartment { get; set; }

        [DataMember]
        public double PayManager { get; set; }

        [DataMember]
        public double PayWater { get; set; }

        [DataMember]
        public String DayPay { get; set; }

        [DataMember]
        public double ManagerCostOld { get; set; }

        [DataMember]
        public double SumMoney { get; set; }

        [DataMember]
        public Boolean? Active { get; set; }

        [DataMember]
        public String CreatedBy { get; set; }

        [DataMember]
        public String CreatedDate { get; set; }

        [DataMember]
        public String ModifiedBy { get; set; }

        [DataMember]
        public String ModifieDate { get; set; }

        [DataMember]
        public int Status { get; set; }
    }
}
