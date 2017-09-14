
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldModel.Filters;
using sWorldModel.Model;

namespace sWorldCommunication
{
    public interface IOrganization
    {
        #region mater
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <returns></returns>
        string GetSvk(string session);

        /// <summary>
        /// Lấy thông tin Master
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="code">Mã xác thực</param>
        /// <returns>Thông tin của tổ chức</returns>
        MasterInfoDTO GetMasterInfo(string session, string code);

        /// <summary>
        /// Lấy thông tin Partner
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="masterId">Id của Master</param>
        /// <param name="code">Mã xác thực</param>
        /// <returns>Thông tin Partner</returns>
        List<PartnerInfoDTO> GetPartnerInfo(string session, long masterId, string code);
        #endregion

        #region Perso Managerment (Danh sách lượt phát hành thẻ)

        /// <summary>
        /// Lấy danh sách thành viên đã được cá thẻ hóa
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgId">Id của tổ chức phát hành</param>
        /// <param name="subOrgId">Id của tổ chức con</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách thành viên đã được cá thẻ hóa</returns>
        List<MemberCustomerDTO> GetMemberPersoList(string session, long orgId, long subOrgId, PersoChipFilter filter);

        /// <summary>
        /// Lấy danh sách tổ chức con
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgId">Id của tổ chức</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách tổ chức con</returns>
        List<SubOrgCustomerDTO> GetSubOrgList(string session, long orgId, SubOrgFilterDto filter);

        #endregion

        #region ORG

        /// <summary>
        /// Lấy danh sách tất cả tổ chức
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <returns>Danh sách tất cả tổ chức</returns>
        List<CmsOrgCustomerDto> GetAllOrgList(string session);

        /// <summary>
        /// Lấy danh sách Master
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <returns>Danh sách Master</returns>
        List<CmsOrgCustomerDto> GetMasterList(string session);

        /// <summary>
        /// Lấy danh sách Partner
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="masterId">Id của Master</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách Partner</returns>
        List<CmsOrgCustomerDto> GetPartnerList(string session, long masterId, OrgFilterDto filter);

        /// <summary>
        /// Lấy danh sách tổ chức chấp nhận thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="masterCode">Mã xác thực của Master</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách tổ chức chấp nhận thẻ</returns>
        List<CmsOrgCustomerDto> GetPartnerAcquirerList(string session, string masterCode, OrgFilterDto filter);

        /// <summary>
        /// Thêm danh sách liên kết phát hành thẻ cho tổ chức được chọn
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="masterId">Id của Master</param>
        /// <param name="partnerIdList">Danh sách Id của Partner cần liên kết phát hành thẻ</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int InsertPartnerOfMaster(string session,long masterId, List<long> partnerIdList);

        /// <summary>
        /// Thêm danh sách chấp nhận thẻ cho tổ chức được chọn
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="masterId">Id của Master</param>
        /// <param name="partnerIdList">Danh sách Id của Partner cần chấp nhận thẻ</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int InsertOrgAcquirer(string session, long masterId, List<long> partnerIdList);

        /// <summary>
        /// Xóa danh sách liên kết phát hành thẻ< cho tổ chức được chọn
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="masterId">Id của Master</param>
        /// <param name="partnerIdList">Danh sách Id của Partner cần liên kết phát hành thẻ</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int DeletePartnerOfMaster(string session, long masterId, List<long> partnerIdList);

        /// <summary>
        /// Xóa danh sách chấp nhận thẻ cho tổ chức được chọn
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="masterCode">Mã xác thực</param>
        /// <param name="partnerIdList">Danh sách Id của Partner cần chấp nhận thẻ</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int DeleteOrgAcquirer(string session, string masterCode, List<long> partnerIdList);

        /// <summary>
        /// Lấy danh sách tổ chức
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách tổ chức</returns>
        List<OrgCustomerDto> GetOrgList(string session, OrgFilterDto filter);

        /// <summary>
        /// Lấy thông tin của tổ chức
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgId">Id của tổ chức</param>
        /// <returns>Thông tin của tổ chức</returns>
        Organization GetOrgById(string session, long OrgId);

        /// <summary>
        /// Thêm thông tin của tổ chức
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="org">Thông tin của tổ chức</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int AddOrg(string session, Organization org);

        /// <summary>
        /// Cập nhật thông tin của tổ chức
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="org">Thông tin của tổ chức</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int UpdateOrg(string session, Organization org);

        /// <summary>
        /// Xóa thông tin của tổ chức
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgId">Id của tổ chức</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int RemoveOrg(string session, long orgId);

        #endregion

        #region SUBORG

        /// <summary>
        /// Lấy danh sách tổ chức con
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgId">Id của tổ chức</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách tổ chức con</returns>
        List<SubOrganization> GetSubOrgList(String session, long orgId, OrgFilterDto filter);

        /// <summary>
        /// Lấy thông tin của tổ chức con
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="subOrgId">Id của tổ chức con</param>
        /// <returns>Thông tin của tổ chức con</returns>
        SubOrganization GetSubOrgById(string session, long subOrgId);

        /// <summary>
        /// Thêm thông tin của tổ chức con
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="subOrg">Thông tin của tổ chức con</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int AddSubOrg(string session, SubOrganization subOrg);

        /// <summary>
        /// Cập nhật thông tin của tổ chức con
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="subOrg">Thông tin của tổ chức con</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int UpdateSubOrg(string session, SubOrganization subOrg);

        /// <summary>
        /// Xóa thông tin của tổ chức con
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="subOrgId">Id của tổ chức con</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int RemoveSubOrg(string session, long subOrgId);

        #endregion

        #region MEMBER

        /// <summary>
        /// Lấy danh sách thành viên
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgId">Id của tổ chức</param>
        /// <param name="subOrgId">Id của tổ chức con</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>Danh sách thành viên</returns>
        List<MemberCustomerDTO> GetMemberList(string session, long orgId, long subOrgId, MemberFilter filter);

        List<Member> GetMemberListBySubOrg(string session,long subOrgId);

        /// <summary>
        /// Lấy thông tin của thành viên
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="memberId">Id của thành viên</param>
        /// <returns>Thông tin của thành viên</returns>
        Member GetMemberById(string session, long memberId);

        /// <summary>
        /// Thêm thông tin của thành viên
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="member">Thông tin của thành viên</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        Member AddMember(string session, Member member);

        /// <summary>
        /// Cập nhật thông tin của thành viên
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="member">Thông tin của thành viên</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int UpdateMember(string session, Member member);

        /// <summary>
        /// Xóa thông tin của thành viên
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="memberId">Id của thành viên</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int RemoveMember(string session, long memberId);

        /// <summary>
        /// Thêm danh sách thành viên vào hệ thống
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="MemberList">Danh sách thành viên</param>
        /// <returns>Danh sách thành viên không thêm được vào hệ thống</returns>
        List<Member> ImportMemberData(string session, List<Member> MemberList);

        /// <summary>
        /// Lấy danh sách người liên hệ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="memberId">Id của Member</param> 
        /// <returns>Danh sách người liên hệ</returns>
        List<MemberRelativeDto> GetMemberRelativeList(string session, long memberId);
        
        /// <summary>
        /// Lấy thông tin của người liên hệ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="memberRelativeId">Id của Member Relative</param>
        /// <returns>Thông tin người liên hệ</returns>
        MemberRelativeDto GetMemberRelativeById(string session, long memberRelativeId);

        /// <summary>
        /// Thêm thông tin người liên hệ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="memberRelative">Thông tin người liên hệ</param>
        /// <returns>Thông tin người liên hệ</returns>
        int AddMemberRelative(string session, MemberRelativeDto memberRelative);

        /// <summary>
        /// Cập nhật thông tin người liên hệ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="memberRelative">Thông tin người liên hệ</param>
        /// <returns>Thông tin người liên hệ</returns>
        int UpdateMemberRelative(string session, MemberRelativeDto memberRelative);

        /// <summary>
        /// Xóa thông tin của người liên hệ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="memberRelativeId">Id của Member Relative</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int RemoveMemberRelative(string session, long memberRelativeId);

        /// <summary>
        /// lấy thông tin member by orgid và code
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgId">mã tổ chức</param>
        /// <param name="code">mã nhân viên</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        Member GetMemberByCode(string session, long orgId, String code);

        /// <summary>
        /// lấy thông tin danh sách member cho từng page 
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="selectrdOrg">mã org đang chọn</param>
        /// <param name="parentSelectedOrg">mã parent org đang chọn (nếu = -1: đang chọn org, nếu # -1 đang chọn suborg)</param>
        /// <param name="filter">MemberFilter</param>
        /// <param name="start">chỉ số bắt đầu page</param>
        /// <param name="length">só lượng member cần lấy cho page</param>
        /// <returns> ListMember </returns>
        List<Member> getMemberForPerPage(string session, long selectrdOrg,
            long parentSelectedOrg, MemberFilter filter, int start, int length);

        /// <summary>
        /// get total member
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="selectrdOrg">mã org đang chọn</param>
        /// <param name="parentSelectedOrg">mã parent org đang chọn (nếu = -1: đang chọn org, nếu # -1 đang chọn suborg)</param>
        /// <param name="filter">MemberFilter</param>
        /// <returns>total of member</returns>
        TotalMemberDTO getTotalMember(string session, long selectrdOrg,
            long parentSelectedOrg, MemberFilter filter);

        #endregion

        #region MOVE SUBORG
        /// <summary>
        /// Lấy danh sách org
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgFilter">Điều kiện lọc org</param>
        /// <returns>Danh sách org theo điệu kiện lọc</returns>
        List<OrgCustomerDto> GetListSubOrg(string session, OrgFilterDto orgFilter);

        /// <summary>
        /// Lấy danh sách thành viên theo org
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="currentSelectedID">id org đang chọn</param>
        /// <param name="parentOrgID">id org cha của org đang chọn</param>
        /// <returns>Danh sách thành viên</returns>
        List<Member> GetListMemberBySubOrgID(string session, long currentSelectedID, long parentOrgID);

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
        int MoveSubOrg(string session, long subOrgIdLeft, long subOrgIdRight, List<MoveMemberSubOrg> listMemberIDLeftRight);
        #endregion
    }
}
