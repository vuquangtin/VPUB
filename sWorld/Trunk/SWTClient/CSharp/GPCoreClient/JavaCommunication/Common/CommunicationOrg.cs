using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common {
    public class CommunicationOrg : CommunicationCommon {
        private static CommunicationOrg instance = new CommunicationOrg();
        public static CommunicationOrg Instance {
            get {
                if (instance == null) {
                    instance = new CommunicationOrg();
                }
                return instance;
            }
        }
        public CommunicationOrg() { }

        protected override void BaseURL() {
            base.BaseURL();
            _baseUrl += @"org";
        }

        #region master,parner
        public MasterInfoDTO GetMasterInfo(string session, string code) {
            string parameters = Utilites.Instance.Paramater(session, code);
            MasterInfoDTO result = GetDataFromServer(session, MethodNames.GET_MASTER_DATA_BY_KEY, parameters, new MasterInfoDTO().GetType()) as MasterInfoDTO;

            //if (null == result) throw new Exception();

            return result;
        }

        public List<PartnerInfoDTO> GetPartnerInfo(string session, long masterId, string code) {
            string parameters = Utilites.Instance.Paramater(session, masterId.ToString(), code);
            List<PartnerInfoDTO> result = GetDataFromServer(session, MethodNames.GET_PARTNER_DATA_BY_KEY, parameters, new List<PartnerInfoDTO>().GetType()) as List<PartnerInfoDTO>;
            if (null == result)
                throw new Exception();

            return result;
        }
        #endregion

        #region Customer
        public List<SubOrgCustomerDTO> GetSubOrgList(string session, long orgId, SubOrgFilterDto filter) {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            List<SubOrgCustomerDTO> result = PostDataToServerObject(session, MethodNames.GET_SUBORG_BY_ORGID, parameters, filter, new List<SubOrgCustomerDTO>().GetType()) as List<SubOrgCustomerDTO>;
            return result;
        }

        public List<MemberCustomerDTO> GetMemberPersoList(string session, long orgId, long subOrgId, PersoChipFilter filter) {
            string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId);
            List<MemberCustomerDTO> result = PostDataToServerObject(session, MethodNames.GET_MEMBER_PERSO_LIST, parameters, filter, new List<MemberCustomerDTO>().GetType()) as List<MemberCustomerDTO>;
            return result;
        }

        public List<MemberCustomerDTO> GetMemberList(string session, long orgId, long subOrgId, MemberFilter filter) {
            string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId);
            List<MemberCustomerDTO> result = PostDataToServerObject(session, MethodNames.GET_MEMBER_LIST, parameters, filter, new List<MemberCustomerDTO>().GetType()) as List<MemberCustomerDTO>;
            return result;
        }
        public List<Member> GetMemberListBySubOrg(string session, long subOrgId) {
            string parameters = Utilites.Instance.Paramater(session, subOrgId);
            List<Member> result = GetDataFromServer(session, MethodNames.GET_MEMBER_BY_SUBORGID, parameters, new List<Member>().GetType()) as List<Member>;
            return result;
        }
        public Member GetMemberByCode(string session, long orgId, String code) {
            string parameters = Utilites.Instance.Paramater(session, orgId, code);
            return GetDataFromServer(session, MethodNames.GET_MEMBER_BY_CODE, parameters, new Member().GetType()) as Member;
        }

        // Lấy danh sách tổ chức

        public List<OrgCustomerDto> GetOrgList(string session, OrgFilterDto filter) {
            string parameters = Utilites.Instance.Paramater(session);
            List<OrgCustomerDto> result = PostDataToServerObject(session, MethodNames.POST_ORG_LIST, parameters, filter, new List<OrgCustomerDto>().GetType()) as List<OrgCustomerDto>;
            return result;
        }

        //ORG
        public List<CmsOrgCustomerDto> GetAllOrgList(string session) {
            string parameters = Utilites.Instance.Paramater(session);
            List<CmsOrgCustomerDto> result = GetDataFromServer(session, MethodNames.GET_ALL_ORG_LIST, parameters, new List<CmsOrgCustomerDto>().GetType()) as List<CmsOrgCustomerDto>;
            if (null == result)
                throw new Exception();

            return result;
        }

        public List<CmsOrgCustomerDto> GetMasterList(string session) {
            string parameters = Utilites.Instance.Paramater(session);
            List<CmsOrgCustomerDto> result = GetDataFromServer(session, MethodNames.GET_MASTER_LIST, parameters, new List<CmsOrgCustomerDto>().GetType()) as List<CmsOrgCustomerDto>;
            if (null == result)
                throw new Exception();

            return result;
        }
        #endregion

        #region  PartnerAcquirer
        public List<CmsOrgCustomerDto> GetPartnerAcquirerList(string session, string masterCode, OrgFilterDto filter) {
            string parameters = Utilites.Instance.Paramater(session, masterCode);
            List<CmsOrgCustomerDto> result = PostDataToServerObject(session, MethodNames.GET_PARTNER_ACQUIRER_LIST, parameters, filter, new List<CmsOrgCustomerDto>().GetType()) as List<CmsOrgCustomerDto>;
            return result;
        }

        public int InsertOrgAcquirer(string session, long masterId, List<long> partnerIdList) {
            string parameters = Utilites.Instance.Paramater(session, masterId);
            return PostDataFromServer(session, MethodNames.INSERT_ORG_ACQUIRER, parameters, partnerIdList);
        }

        public int DeleteOrgAcquirer(string session, string masterCode, List<long> partnerIdList) {
            string parameters = Utilites.Instance.Paramater(session, masterCode);
            return PostDataFromServer(session, MethodNames.DELETE_ORG_ACQUIRER, parameters, partnerIdList);
        }
        #endregion

        #region PartnerOfMaster
        public List<CmsOrgCustomerDto> GetPartnerList(string session, long masterId, OrgFilterDto filter) {
            string parameters = Utilites.Instance.Paramater(session, masterId);
            List<CmsOrgCustomerDto> result = PostDataToServerObject(session, MethodNames.GET_PARTNER_LIST, parameters, filter, new List<CmsOrgCustomerDto>().GetType()) as List<CmsOrgCustomerDto>;
            return result;
        }

        public int InsertPartnerOfMaster(string session, long masterId, List<long> partnerIdList) {
            string parameters = Utilites.Instance.Paramater(session, masterId);
            return PostDataFromServer(session, MethodNames.INSERT_PARTNER_OF_MASTER, parameters, partnerIdList);
        }

        public int DeletePartnerOfMaster(string session, long masterId, List<long> partnerIdList) {
            string parameters = Utilites.Instance.Paramater(session, masterId);
            return PostDataFromServer(session, MethodNames.DELETE_PARTNER_OF_MASTER, parameters, partnerIdList);
        }
        #endregion

        #region Org

        public Organization GetOrgById(string session, long OrgId) {
            string parameters = Utilites.Instance.Paramater(session, OrgId);
            Organization result = GetDataFromServer(session, MethodNames.GET_ORG_BY_ID, parameters, new Organization().GetType()) as Organization;
            if (null == result)
                throw new Exception();

            return result;
        }

        public int AddOrg(string session, Organization org) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.ADD_ORG, parameters, org);
        }

        public int UpdateOrg(string session, Organization org) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.UPDATE_ORG, parameters, org);
        }

        public int RemoveOrg(string session, long OrgId) {
            string parameters = Utilites.Instance.Paramater(session, OrgId);
            return GetDataFromServer(session, MethodNames.REMOVE_ORG, parameters);
        }

        #endregion

        #region SubOrg

        public List<SubOrganization> GetSubOrgList(String session, long orgId, OrgFilterDto filter) {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            List<SubOrganization> result = PostDataToServerObject(session, MethodNames.POST_SUB_ORG_LIST, parameters, filter, new List<SubOrganization>().GetType()) as List<SubOrganization>;
            return result;
        }
        public SubOrganization GetSubOrgById(string session, long subOrgId) {
            string parameters = Utilites.Instance.Paramater(session, subOrgId);
            SubOrganization result = GetDataFromServer(session, MethodNames.GET_SUB_ORG_BY_ID, parameters, new SubOrganization().GetType()) as SubOrganization;
            if (null == result)
                throw new Exception();

            return result;
        }

        public int AddSubOrg(string session, SubOrganization subOrg) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.ADD_SUB_ORG, parameters, subOrg);
        }

        public int UpdateSubOrg(string session, SubOrganization subOrg) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.UPDATE_SUB_ORG, parameters, subOrg);
        }

        public int RemoveSubOrg(string session, long subOrgId) {
            string parameters = Utilites.Instance.Paramater(session, subOrgId);
            return GetDataFromServer(session, MethodNames.REMOVE_SUB_ORG, parameters);
        }

        #endregion

        #region Member

        public List<Member> ImportMemberData(string session, List<Member> MemberList) {
            string parameters = Utilites.Instance.Paramater(session);
            List<Member> result = PostDataToServerObject(session, MethodNames.IMPORT_MEMBER_DATA, parameters, MemberList, new List<Member>().GetType()) as List<Member>;
            if (null == result)
                throw new Exception();

            return result;
        }

        public Member GetMemberById(string session, long memberId) {
            string parameters = Utilites.Instance.Paramater(session, memberId);
            Member result = GetDataFromServer(session, MethodNames.GET_MEMBER_BY_ID, parameters, new Member().GetType()) as Member;
            if (null == result)
                throw new Exception();

            return result;
        }

        public Member AddMember(string session, Member member) {
            string parameters = Utilites.Instance.Paramater(session);
            Member result = PostDataToServerObject(session, MethodNames.ADD_MEMBER, parameters, member, new Member().GetType()) as Member;
            if (null == result)
                throw new Exception();

            return result;

        }

        public int UpdateMember(string session, Member member) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.UPDATE_MEMBER, parameters, member);
        }

        public int RemoveMember(string session, long memberId) {
            string parameters = Utilites.Instance.Paramater(session, memberId);
            return GetDataFromServer(session, MethodNames.REMOVE_MEMBER, parameters);
        }

        /// <summary>
        /// getMemberForPerPage
        /// </summary>
        /// <param name="session"></param>
        /// <param name="selectrdOrg"></param>
        /// <param name="parentSelectedOrg"></param>
        /// <param name="filter"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public List<Member> getMemberForPerPage(string session, long selectrdOrg, long parentSelectedOrg, MemberFilter filter, int start, int length) {
            string parameters = Utilites.Instance.Paramater(session, selectrdOrg, parentSelectedOrg, start, length);
            List<Member> result = PostDataToServerObject(session, MethodNames.GET_MEMBER_BY_TOTAL_COUNT, parameters, filter, new List<Member>().GetType()) as List<Member>;

            return result;
        }

        /// <summary>
        /// getTotalMember
        /// </summary>
        /// <param name="session"></param>
        /// <param name="selectrdOrg"></param>
        /// <param name="parentSelectedOrg"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public TotalMemberDTO getTotalMember(string session, long selectrdOrg, long parentSelectedOrg, MemberFilter filter) {
            string parameters = Utilites.Instance.Paramater(session, selectrdOrg, parentSelectedOrg);
            TotalMemberDTO result = PostDataToServerObject(session, MethodNames.GET_MEMBER_COUNT, parameters, filter, new TotalMemberDTO().GetType()) as TotalMemberDTO;

            return result;
        }

        #endregion

        #region Member Relative

        public List<MemberRelativeDto> GetMemberRelativeList(string session, long memberId) {
            string parameters = Utilites.Instance.Paramater(session, memberId);
            List<MemberRelativeDto> result = GetDataFromServer(session, MethodNames.GET_ALL_MEM_RELATIVE, parameters, new List<MemberRelativeDto>().GetType()) as List<MemberRelativeDto>;
            if (null == result)
                throw new Exception();

            return result;
        }

        public MemberRelativeDto GetMemberRelativeById(string session, long memberRelativeId) {
            string parameters = Utilites.Instance.Paramater(session, memberRelativeId);
            MemberRelativeDto result = GetDataFromServer(session, MethodNames.GET_MEM_RELATIVE_BY_ID, parameters, new MemberRelativeDto().GetType()) as MemberRelativeDto;
            if (null == result)
                throw new Exception();

            return result;
        }

        public int AddMemberRelative(string session, MemberRelativeDto memberRelative) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.INSERT_MEM_RELATIVE, parameters, memberRelative);
        }

        public int UpdateMemberRelative(string session, MemberRelativeDto memberRelative) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.UPDATE_MEM_RELATIVE, parameters, memberRelative);
        }

        public int RemoveMemberRelative(string session, long memberRelativeId) {
            string parameters = Utilites.Instance.Paramater(session, memberRelativeId);
            return GetDataFromServer(session, MethodNames.DELETE_MEM_RELATIVE, parameters);
        }

        #endregion

        #region Move Sub-Organization
        /// <summary>
        /// Lấy danh sách org
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgFilter">Điều kiện lọc org</param>
        /// <returns>Danh sách org theo điệu kiện lọc</returns>
        public List<OrgCustomerDto> GetListSubOrg(string session, OrgFilterDto orgFilter) {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataToServerObject(session, MethodNames.GET_LIST_SUBORG, parameters, orgFilter, new List<OrgCustomerDto>().GetType()) as List<OrgCustomerDto>;
        }

        /// <summary>
        /// Lấy danh sách thành viên theo org
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="currentSelectedID">id org đang chọn</param>
        /// <param name="parentOrgID">id org cha của org đang chọn</param>
        /// <returns>Danh sách thành viên</returns>
        public List<Member> GetListMemberBySubOrgID(string session, long currentSelectedID, long parentOrgID) {
            string parameters = Utilites.Instance.Paramater(session, currentSelectedID, parentOrgID);
            return GetDataFromServer(session, MethodNames.GET_LIST_MEMBER, parameters, new List<Member>().GetType()) as List<Member>;
        }

        /// <summary>
        /// Đổi subOrgID của mỗi thành viên
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="subOrgIdLeft"></param>
        /// <param name="listMemberLeft"></param>
        /// <param name="subOrgIdRight"></param>
        /// <param name="listMemberRight"></param>
        /// <returns>Tình trạng kết quả
        /// 0: FAILED,
        /// 1: SUCCESS
        /// </returns>
        public int MoveSubOrg(string session, long subOrgIdLeft, long subOrgIdRight, List<MoveMemberSubOrg> listMemberIDLeftRight) {
            string parameters = Utilites.Instance.Paramater(session, subOrgIdLeft, subOrgIdRight);
            return PostDataFromServer(session, MethodNames.MOVE_MEMBER_SUBORG, parameters, listMemberIDLeftRight);
        }
        #endregion
    }
}
