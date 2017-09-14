using sWorldModel.Filters;
using sWorldModel.MethodData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;

namespace sWorldCommunication
{
    public interface IMemberData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="data"></param>
        /// <returns></returns>


        List<MemberDataImportFromExcelDto> SendDataToServerForImportMemberData(string session, MemberDataImportExcelDTO data);


    }
}
