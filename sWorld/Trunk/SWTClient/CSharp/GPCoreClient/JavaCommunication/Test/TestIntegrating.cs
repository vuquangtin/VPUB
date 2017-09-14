using JavaCommunication;
using sWorldModel.Filters;
using sWorldModel.Integrating;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Java
{
    public class TestIntegrating : IIntegrating
    {
        private static TestIntegrating instance = new TestIntegrating();
        public static TestIntegrating Instance
        {
            get {
                if (instance == null){
                    instance = new TestIntegrating();
                }
                return instance;
            }
        }
        private TestIntegrating()
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

        public List<IntegratingLogDto> GetIntegratingLogList(string session, IntegratingLogFilterDto filter, int skip, int take, out int totalRecords)
        {
            totalRecords = 0;
            return new List<IntegratingLogDto>();
        }
    }
}
