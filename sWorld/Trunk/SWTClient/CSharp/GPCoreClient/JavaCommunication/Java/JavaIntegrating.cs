using JavaCommunication;
using sWorldModel.Filters;
using sWorldModel.Integrating;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldCommunication;

namespace JavaCommunication.Java
{
    public class JavaIntegrating : IIntegrating
    {
        private static JavaIntegrating instance = new JavaIntegrating();
        public static JavaIntegrating Instance
        {
            get {
                if (instance == null){
                    instance = new JavaIntegrating();
                }
                return instance;
            }
        }
        private JavaIntegrating()
        {
        }

        public void IntegrateDepartments(string session, List<ALL_BO_MON> data)
        {
        }

        public void IntegrateFaculties(string session, List<ALL_KHOA> data)
        {
        }

        public void IntegratePositions(string session, List<ALL_CHUC_VU> data)
        {
        }

        public void IntegrateScales(string session, List<ALL_NGACH> data)
        {
        }

        public void IntegrateTeachers(string session, List<ALL_CBCNV> data)
        {
        }

        //public List<IntegratingLogDto> GetIntegratingLogList(string session, IntegratingLogFilterDto filter, int skip, int take, out int totalRecords)
        //{
        //    totalRecords = 0;
        //    return new List<IntegratingLogDto>();
        //}
    }
}
