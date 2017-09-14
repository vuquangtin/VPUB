using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication
{
    public interface IKey
    {
        string GetSvk(string session);

        /// <summary>
        /// ham lay thong tin master
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="code">de xac dinh Master</param>
        /// <returns>MasterInfoDto</returns>
        MasterInfo GetMasterInfo(string session, string code);

        /// <summary>
        /// lay thong tin cua partner
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="masterId">Id cua master</param>
        /// <param name="code">de xac dinh partner cua Master</param>
        /// <returns>List<PartnerInfoDto></returns>
        List<PartnerInfo> GetPartnerInfo(string session, long masterId, string code);
    }
}
