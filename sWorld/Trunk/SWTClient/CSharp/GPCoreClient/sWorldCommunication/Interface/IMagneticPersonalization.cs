using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldModel.Filters;

namespace sWorldCommunication
{
    public interface IMagneticPersonalization
    {
        /// <summary>
        /// Lấy thông tin cho việc phát hành thẻ từ
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="masterId"></param>
        /// <param name="partnerId"></param>
        /// <param name="flag">cờ cho biết cách thức generate data như thế nào:
        /// 0 - thông tin thành viên chưa có. Yêu cầu tạo trả về phải có thông tin mặc định của chủ thẻ
        /// 1 - thông tin thành viên đã có. Không yêu cầu trả về thông tin mặc định
        /// </param>
        /// <returns></returns>
        PreGenerateData GetPreGenerateData(string session, long masterId, long partnerId, int flag);

        List<MemberDataExcelDto> SendDataToServerForGeneral(string session, PersoMagneticCardInforDTO data);
        /// <summary>
        /// Generate thẻ và mã hóa
        /// </summary>
        /// <param name="masterNumber">số của master</param>
        /// <param name="partnerNumber">số của partner</param>
        /// <param name="count">số lượng can phat hanh</param>
        /// <param name="preData">data cho việc tạo thẻ</param>
        /// <param name="personalInfoList">danh sách thành viên cần tạo thẻ (nếu không có thông tin thì bằng null)</param>
        /// <returns></returns>
      //  List<PreGenerateData> GenerateCardData(string session, string masterNumber, string partnerNumber, long count, PreGenerateData preData, List<PersoMagneticInfo> personalInfoList);

        /// <summary>
        /// Lưu thông tin vào DB
        /// </summary>
        /// <param name="cardPerDataList">danh sách thông tin của thành viên, số serial thẻ, thông tin mã hóa thẻ</param>
        /// <returns></returns>
        int SaveDataPresoCardMagnetic(string session, PersoMagneticCardInforDTO data);

        List<MemberMagneticPersoDTO> GetMemberList(string session, long subOrgId, MemberFilter filter);

     //   List<CMSCardmagneticDto> GetCardMagneticList(string session, CardMagneticFilterDto filter);

        /// <summary>
        /// lấy danh sách các sub org of partner
        /// </summary>
        /// <param name="session"> session cua hệ thống</param>
        /// <param name="orgId">Id cua partner</param>
        /// <param name="filter"> Lọc theo tổ chức</param>
        /// <returns></returns>
        List<SubOrgCustomerDTO> GetSubOrgList(string session, long orgId, SubOrgFilterDto filter);

         /// <summary>
        /// Lấy thông tin các thành viên của partner đã được cấp thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"> partnerId</param>
        /// <param name="subOrgId"></param>
        /// <param name="filter">tiêu chí lọc thẻ từ</param>
        /// <returns>List<Personalization></returns>

        List<MagneticPersonalizationDTO> GetMemberMagneticList(string session, long orgId, long subOrgId, CardMagneticFilterDto filter);

        /// <summary>
        /// Lấy danh sách trạng thái vật lý thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        List<CardStatisticsData> StatisticCardMagneticStatus(string session, long orgId, long subOrgId, string prefix);

        /// <summary>
        /// Lấy danh sách trạng thái logical của thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        List<CardStatisticsData> StatisticCardByLogicalStatus(string session, long orgId, long subOrgId, int cardType);

        List<MagneticPersonalizationDTO> GetChangeStatusMagnetic(string session, byte status, string Reason, List<long> persoIds);


        List<CardmagneticDTO> GetMagneticList(string session, long masterId, long partnerId, CardMagneticFilterDto filter);

        List<CardmagneticDTO> GetChangeStatusPhysicalMagnetic(string session, byte status, string Reason, List<long> MagneticIds);

        /// <summary>
        /// Xóa thông tin thẻ trong bảng CardChip
        /// </summary>
        /// <param name="session"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        int ClearCardEmpty(string session, string serialNumber);
       
    }
}
