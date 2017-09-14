using sWorldModel.Filters;
using sWorldModel.Integrating;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldCommunication
{
    /// <summary>
    /// interface chưa được sử dụng
    /// Mục đích: import data từ file access
    /// </summary>
    public interface IIntegrating
    {
        void IntegrateDepartments(string session, List<ALL_BO_MON> data);

        void IntegrateFaculties(string session, List<ALL_KHOA> data);

        void IntegratePositions(string session, List<ALL_CHUC_VU> data);

        void IntegrateScales(string session, List<ALL_NGACH> data);

        void IntegrateTeachers(string session, List<ALL_CBCNV> data);

        //List<IntegratingLogDto> GetIntegratingLogList(string session, IntegratingLogFilterDto filter, int skip, int take, out int totalRecords);
    }
}
