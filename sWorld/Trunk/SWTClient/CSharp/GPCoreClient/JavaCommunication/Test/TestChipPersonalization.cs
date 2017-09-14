using JavaCommunication;
using sWorldModel.Filters;
using sWorldModel.MethodData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using JavaCommunication.Test;

namespace JavaCommunication.Java
{
    public class TestChipPersonalization : IChipPersonalization
    {
        private static TestChipPersonalization instance = new TestChipPersonalization();
        public static TestChipPersonalization Instance
        {
            get {
                if (instance == null){
                    instance = new TestChipPersonalization();
                }
                return instance;
            }
        }
        private TestChipPersonalization()
        {
        }

        public List<MemberChipPersoDTO> GetMemberPersoList(string session, long orgId, long subOrgId, PersoFilter filter) 
        {
            return HardCode.Instance.GetMemberChipList();
        }

        public DataForPersoCard CheckAndGetDataToPersoCard(string session, long memberId, byte[] serialNumber, byte hmkAlias, byte dmkAlias) 
        {
            return new DataForPersoCard();
        }

        public int PersoCardChip(string session, long memberId, string serialNumberHex)
        {
            return 0;
        }

        public List<MethodResultDto> CancelPersoes(string session, long[] ChipPersoIds, string cancelReason)
        {
            return new List<MethodResultDto>();
        }

        public List<FacultyDepartmentDto> GetFacultyList(string session, FacultyFilterDto filter)
        {
            return new List<FacultyDepartmentDto>();
        }

        public List<SubOrgCustomerDTO> GetSubOrgList(string session, long orgId, SubOrgFilterDto filter) 
        {
            return HardCode.Instance.GetSubOrgList();
        }

        public List<MemberChipPersoDTO> GetMemberList(string session, long orgId, long subOrgId, MemberFilter filter)
        {
            return new List<MemberChipPersoDTO>();
        }

        public List<MethodResultDto> LockPersoes(string session, long[] ChipPersoIds, string lockReason)
        {
            return new List<MethodResultDto>();
        }

        public List<MethodResultDto> UnLockPersoes(string session, long[] ChipPersoIds, string unlockReason)
        {
            return new List<MethodResultDto>();
        }

        public StringCollection ParseTeacherAppData(string session, byte[] teacherAppDataBytes)
        {
            return new StringCollection();
        }

        public DataForUpdateCard GetDataToUpdateCard(string session, byte[] serialNumber)
        {
            return new DataForUpdateCard();
        }

        public int UpdateMemberAppOfPerso(string session, byte[] serialNumber, string lastUpdateDate)
        {
            return 0;
        }

        public int ValidatePerso(string session, byte[] serialNumber)
        {
            return 0;
        }

        public List<MethodResultDto> ExtendPerso(string session, long[] ChipPersoIds, DateTime expirationDate)
        {
            return new List<MethodResultDto>();
        }
    }
}
