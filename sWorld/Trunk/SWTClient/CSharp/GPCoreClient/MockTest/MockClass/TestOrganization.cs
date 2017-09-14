using MockTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using MockTest.MockClass;
using sWorldCommunication;
using sWorldModel.Filters;

namespace MockTest.MockClass
{
    public class TestOrganization : IOrganization
    {
        private static TestOrganization instance = new TestOrganization();
        public static TestOrganization Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TestOrganization();
                }
                return instance;
            }
        }
        private TestOrganization()
        {
        }

        public string GetSvk(string session)
        {
            return string.Empty;
        }

        public MasterInfoDTO GetMasterInfo(string session, string code)
        {
            if (string.IsNullOrEmpty(code))
                return new MasterInfoDTO();
            if (code.Equals(SystemCode.MasterCode))
                return new MasterInfoDTO();
            return HardCode.Instance.GetMasterInfoDto(code);
        }

        public List<PartnerInfoDTO> GetPartnerInfo(string session, long masterId, string code)
        {
            if (string.IsNullOrEmpty(code))
                return new List<PartnerInfoDTO>();
            if (code.Equals(SystemCode.PartnerCode))
                return new List<PartnerInfoDTO>();
            return HardCode.Instance.GetPartnerInfoDto(code);
            //return null;
        }

        public ResultCheckCardDTO CheckAndGetMasterDataToImportCard(string session, long id, string aa, int card, byte st, byte top)
        {
            return null;
        }

        #region Perso Managerment (Danh sách lượt phát hành thẻ)
        /// <summary>
        /// Lấy thông tin các thành viên của partner đã được cấp thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"> partnerId</param>
        /// <param name="subOrgId"></param>
        /// <param name="filter">de loc danh sach theo tieu chi</param>
        /// <returns>List<Personalization></returns>
        public List<MemberCustomerDTO> GetMemberPersoList(string session, long orgId, long subOrgId, PersoChipFilter filter)
        {
            return HardCode.Instance.GetMemberPersoChipList(orgId, subOrgId);
        }

        /// <summary>
        /// lay danh sách các sub org of partner
        /// </summary>
        /// <param name="session"> session cua hệ thống</param>
        /// <param name="orgId">Id cua partner</param>
        /// <param name="filter"> </param>
        /// <returns></returns>
        public List<SubOrgCustomerDTO> GetSubOrgList(string session, long orgId, SubOrgFilterDto filter)
        {
            return HardCode.Instance.GetSubOrgList(orgId);
        }

        /// <summary>
        /// Lấy danh sách thành viên của một SubOrg chưa được cấp phát thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <param name="subOrgId"> Id cua SubOrg cần lấy thông tin thành viên</param>
        /// <param name="filter">tiêu chí lọc thành viên</param>
        /// <returns></returns>
        public List<MemberCustomerDTO> GetMemberList(string session, long orgId, long subOrgId, MemberFilter filter)
        {
            return HardCode.Instance.GetMemberChipList(orgId, subOrgId);
        }
        #endregion

        public List<CmsOrgCustomerDto> GetAllOrgList(string session) 
        {
            return null;
        }

        public List<CmsOrgCustomerDto> GetMasterList(string session)
        {
            return null;
        }

        public List<CmsOrgCustomerDto> GetPartnerList(string session, long masterId, OrgFilterDto filter)
        {
            return null;
        }

        public int InsertPartnerOfMaster(string session, long masterId, List<long> partnerIdList)
        {
            return 0;
        }

        public int InsertOrgAcquirer(string session, long masterId, List<long> partnerIdList)
        {
            return 0;
        }

        public List<CmsOrgCustomerDto> GetPartnerAcquirerList(string session, string masterCode, OrgFilterDto filter)
        {
            return null;
        }

        public int DeletePartnerOfMaster(string session, long masterId, List<long> partnerIdList)
        {
            return 0;
        }

        public int DeleteOrgAcquirer(string session, string masterCode, List<long> partnerIdList)
        {
            return 0;
        }

        public List<OrgCustomerDto> GetOrgList(string session, OrgFilterDto filter)
        {
            return HardCode.Instance.GetOrgList();
        }

        public Organization GetOrgById(string session, long OrgId)
        {
            return null;

        }

        public int AddOrg(string session, Organization org)
        {
            return (int)Status.SUCCESS;
        }

        public int UpdateOrg(string session, Organization org)
        {
            return (int)Status.SUCCESS;

        }

        public int RemoveOrg(string session, long OrgId)
        {
            return (int)Status.SUCCESS;

        }

        public List<SubOrganization> GetSubOrgList(String session, long orgId, OrgFilterDto filter)
        {
            return new List<SubOrganization>();
        }

        public SubOrganization GetSubOrgById(string session, long subOrgId) 
        {
            return new SubOrganization();
        }

        public int AddSubOrg(string session, SubOrganization subOrg)
        {
            return (int)Status.SUCCESS;
        }

        public int UpdateSubOrg(string session, SubOrganization subOrg)
        {
            return (int)Status.SUCCESS;

        }

        public int RemoveSubOrg(string session, long subOrgId)
        {
            return (int)Status.SUCCESS;

        }

        #region MEMBER

        /// <summary>
        /// Lấy về thông tin của org dựa vào id
        /// </summary>
        /// <param name="sessionId">Mã session của user đang đăng nhập</param>
        /// <param name="groupId">Mã của org cần lấy thông tin</param>
        /// <returns>Thông tin của org </returns>
        public Member GetMemberById(string session, long memberId)
        {
            return new Member();
        }

        /// <summary>
        /// Thêm một tổ chức mới vào hệ thống.
        /// </summary>
        /// <param name="session"></param>
        /// <param name="group">Thông tin của tổ chức cần tạo</param>
        /// <returns></returns>
        public MemberCustomerDto AddMember(string session, MemberCustomerDto member)
        {
            return new MemberCustomerDto();
        }

        /// <summary>
        /// Cập nhật thông tin tổ chức
        /// </summary>
        /// <param name="session"></param>
        /// <param name="org">thông tin org</param>
        /// <returns></returns>
        public int UpdateMember(string session, MemberCustomerDto member)
        {
            return (int)Status.SUCCESS;
        }

        /// <summary>
        /// Xóa tổ chức
        /// </summary>
        /// <param name="session"></param>
        /// <param name="org">thông tin org</param>
        /// <returns></returns>
        public int RemoveMember(string session, long memberId)
        {
            return (int)Status.SUCCESS;
        }

        #endregion

        public List<MemberCustomerDto> ImportMemberData(string session, List<MemberCustomerDto> MemberList)
        {
            for (int i = 0; i < 1000000; i++)
            {
            }
            return new List<MemberCustomerDto>();
        }

        public List<MemberRelativeDto> GetMemberRelativeList(string session, long memberId)
        {
            return new List<MemberRelativeDto>();
        }

        public MemberRelativeDto GetMemberRelativeById(string session, long memberRelativeId)
        {
            return new MemberRelativeDto();
        }

        public int AddMemberRelative(string session, MemberRelativeDto memberRelative)
        {
            return 0;

        }

        public int UpdateMemberRelative(string session, MemberRelativeDto memberRelative)
        {
            return 0;
        }

        public int RemoveMemberRelative(string session, long memberRelativeId)
        {
            return 0;
        }
    }
}
