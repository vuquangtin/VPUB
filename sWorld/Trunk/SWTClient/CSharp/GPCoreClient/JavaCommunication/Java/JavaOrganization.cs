using JavaCommunication;
using JavaCommunication.Common;
using System;
using System.Collections.Generic;
using System.Text;
using sWorldModel.TransportData;
using sWorldModel.Filters;
using sWorldCommunication;

namespace JavaCommunication.Java
{
    public class JavaOrganization : IOrganization
    {
        private static JavaOrganization instance = new JavaOrganization();
        public static JavaOrganization Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaOrganization();
                }
                return instance;
            }
        }
        private JavaOrganization()
        {
        }

        public string GetSvk(string session)
        {
            return string.Empty;
        }

        public MasterInfoDTO GetMasterInfo(string session, string code)
        {
            return CommunicationOrg.Instance.GetMasterInfo(session, code);
        }

        public List<PartnerInfoDTO> GetPartnerInfo(string session, long masterId, string code)
        {
            return CommunicationOrg.Instance.GetPartnerInfo(session, masterId, code);
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
            return CommunicationOrg.Instance.GetMemberPersoList(session, orgId, subOrgId, filter);
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
            return CommunicationOrg.Instance.GetSubOrgList(session, orgId, filter);
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
            return CommunicationOrg.Instance.GetMemberList(session, orgId, subOrgId, filter);
        }
        #endregion

        //ORG
        public List<CmsOrgCustomerDto> GetAllOrgList(string session)
        {
            return CommunicationOrg.Instance.GetAllOrgList(session);
        }

        public List<CmsOrgCustomerDto> GetMasterList(string session)
        {
            return CommunicationOrg.Instance.GetMasterList(session);
        }

        public List<CmsOrgCustomerDto> GetPartnerList(string session, long masterId, OrgFilterDto filter)
        {
            return CommunicationOrg.Instance.GetPartnerList(session, masterId, filter);
        }

        public int InsertPartnerOfMaster(string session, long masterId, List<long> partnerIdList)
        {
            return CommunicationOrg.Instance.InsertPartnerOfMaster(session, masterId, partnerIdList);
        }

        public int InsertOrgAcquirer(string session, long masterId, List<long> partnerIdList)
        {
            return CommunicationOrg.Instance.InsertOrgAcquirer(session, masterId, partnerIdList);
        }

        public List<CmsOrgCustomerDto> GetPartnerAcquirerList(string session, string masterCode, OrgFilterDto filter)
        {
            return CommunicationOrg.Instance.GetPartnerAcquirerList(session, masterCode, filter);
        }

        public int DeletePartnerOfMaster(string session, long masterId, List<long> partnerIdList)
        {
            return CommunicationOrg.Instance.DeletePartnerOfMaster(session, masterId, partnerIdList);
        }

        public int DeleteOrgAcquirer(string session, string masterCode, List<long> partnerIdList)
        {
            return CommunicationOrg.Instance.DeleteOrgAcquirer(session, masterCode, partnerIdList);
        }

        public List<OrgCustomerDto> GetOrgList(string session, OrgFilterDto filter)
        {
            return CommunicationOrg.Instance.GetOrgList(session, filter);
        }

        public Organization GetOrgById(string session, long OrgId)
        {
            return CommunicationOrg.Instance.GetOrgById(session, OrgId);
        }

        public int AddOrg(string session, Organization org)
        {
            return CommunicationOrg.Instance.AddOrg(session, org);
        }

        public int UpdateOrg(string session, Organization org)
        {
            return CommunicationOrg.Instance.UpdateOrg(session, org);

        }

        public int RemoveOrg(string session, long OrgId)
        {
            return CommunicationOrg.Instance.RemoveOrg(session, OrgId);
        }
        //SUBORG
        public List<SubOrganization> GetSubOrgList(String session, long orgId, OrgFilterDto filter)
        {
            return CommunicationOrg.Instance.GetSubOrgList(session, orgId, filter);
        }

        public SubOrganization GetSubOrgById(string session, long subOrgId)
        {
            return CommunicationOrg.Instance.GetSubOrgById(session, subOrgId);
        }

        public int AddSubOrg(string session, SubOrganization subOrg)
        {
            return CommunicationOrg.Instance.AddSubOrg(session, subOrg);
        }

        public int UpdateSubOrg(string session, SubOrganization subOrg)
        {
            return CommunicationOrg.Instance.UpdateSubOrg(session, subOrg);
        }

        public int RemoveSubOrg(string session, long subOrgId)
        {
            return CommunicationOrg.Instance.RemoveSubOrg(session, subOrgId);
        }

        //MEMBER
        public List<Member> ImportMemberData(string session, List<Member> MemberList)
        {
            return CommunicationOrg.Instance.ImportMemberData(session, MemberList);
        }

        public Member GetMemberById(string session, long memberId)
        {
            return CommunicationOrg.Instance.GetMemberById(session, memberId);
        }

        public Member AddMember(string session, Member member)
        {
            return CommunicationOrg.Instance.AddMember(session, member);
        }

        public int UpdateMember(string session, Member member)
        {
            return CommunicationOrg.Instance.UpdateMember(session, member);
        }

        public int RemoveMember(string session, long memberId)
        {
            return CommunicationOrg.Instance.RemoveMember(session, memberId);
        }

        public List<MemberRelativeDto> GetMemberRelativeList(string session, long memberId)
        {
            return CommunicationOrg.Instance.GetMemberRelativeList(session, memberId);
        }

        public MemberRelativeDto GetMemberRelativeById(string session, long memberRelativeId)
        {
            return CommunicationOrg.Instance.GetMemberRelativeById(session, memberRelativeId);
        }

        public int AddMemberRelative(string session, MemberRelativeDto memberRelative)
        {
            return CommunicationOrg.Instance.AddMemberRelative(session, memberRelative);

        }

        public int UpdateMemberRelative(string session, MemberRelativeDto memberRelative)
        {
            return CommunicationOrg.Instance.UpdateMemberRelative(session, memberRelative);
        }

        public int RemoveMemberRelative(string session, long memberRelativeId)
        {
            return CommunicationOrg.Instance.RemoveMemberRelative(session, memberRelativeId);
        }

        public List<Member> GetMemberListBySubOrg(string session, long subOrgId)
        {
            return CommunicationOrg.Instance.GetMemberListBySubOrg(session, subOrgId);
        }
        public Member GetMemberByCode(string session, long orgId, String code)
        {
            return CommunicationOrg.Instance.GetMemberByCode(session, orgId, code);
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
        public List<Member> getMemberForPerPage(string session, long selectrdOrg,
            long parentSelectedOrg, MemberFilter filter, int start, int length)
        {
            return CommunicationOrg.Instance.getMemberForPerPage(session, selectrdOrg, parentSelectedOrg, filter, start, length);
        }

        /// <summary>
        /// getTotalMember
        /// </summary>
        /// <param name="session"></param>
        /// <param name="selectrdOrg"></param>
        /// <param name="parentSelectedOrg"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public TotalMemberDTO getTotalMember(string session, long selectrdOrg, long parentSelectedOrg, MemberFilter filter)
        {
            return CommunicationOrg.Instance.getTotalMember(session, selectrdOrg, parentSelectedOrg, filter);
        }

        /// <summary>
        /// Lấy danh sách org
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgFilter">Điều kiện lọc org</param>
        /// <returns>Danh sách org theo điệu kiện lọc</returns>
        public List<OrgCustomerDto> GetListSubOrg(string session, OrgFilterDto orgFilter) {
            return CommunicationOrg.Instance.GetListSubOrg(session, orgFilter);
        }

        /// <summary>
        /// Lấy danh sách thành viên theo org
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="currentSelectedID">id org đang chọn</param>
        /// <param name="parentOrgID">id org cha của org đang chọn</param>
        /// <returns>Danh sách thành viên</returns>
        public List<Member> GetListMemberBySubOrgID(string session, long currentSelectedID, long parentOrgID) {
            return CommunicationOrg.Instance.GetListMemberBySubOrgID(session, currentSelectedID, parentOrgID);
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
            return CommunicationOrg.Instance.MoveSubOrg(session, subOrgIdLeft, subOrgIdRight, listMemberIDLeftRight);
        }
    }
}
