using sWorldModel.Filters;
using sWorldModel.MethodData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;

namespace sWorldCommunication
{
    public interface ICardChip
    {
        /// <summary>
        /// Lấy danh sách thẻ chip
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="masterId">Id của Master</param>
        /// <param name="partnerId">Id của Parner</param>
        /// <param name="filter">filter cần lọc</param>
        /// <returns>danh sách thẻ chip</returns>
        List<CardChipDto> GetCardChipList(string session, long masterId, long partnerId, CardFilterDto filter);

        /// <summary>
        /// Lấy danh sách thẻ chip
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <returns>danh sách thẻ chip</returns>
        List<CardChipDto> GetCardChipListExport(string session);
        /// <summary>
        /// Lấy danh sách thẻ chip chưa cá thể hóa bởi orgid
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="orgId">Mã tổ chức partner</param>
        /// <returns>danh sách thẻ chip</returns>
        List<CardChipDto> GetCardChipListExport(string session, long orgId);
        /// <summary>
        /// Lấy danh sách thẻ chip
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <returns>danh sách thẻ chip</returns>
        int ImportListCard(string session, String username, List<CardChipDto> lstCardChipDto);


        #region Master & Partner

        /// <summary>
        /// Lấy thông tin để ghi License Master vào thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="id">Id của Master</param>
        /// <param name="serialnumbex">Serial number của thẻ</param>
        /// <param name="cardtype">Loại thẻ</param>
        /// <param name="start">Sector bắt đầu ghi License</param>
        /// <param name="stop">Sector kết thuc ghi License</param>
        /// <returns>Dữ liệu cần ghi vào thẻ</returns>
        ResultCheckCardDTO CheckAndGetMasterDataToImportCard(string session, long id, string serialnumbex, int cardtype, byte start, byte stop);

        /// <summary>
        /// Cập nhật thông tin của thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="masterId">Id của Master</param>
        /// <param name="partnerId">Id của Partner</param>
        /// <param name="serialnumbex">Serial number của thẻ</param>
        /// <param name="cardtype">Loại thẻ</param>
        /// <param name="status"> Tình trạng quyền sử dụng thẻ
        /// 100: CARD_HAS_MASTER_READED_ONLY (chỉ được đọc)
        /// 101: CARD_HAS_MASTER_WRITED_ONLY (Chỉ được ghi)
        /// </param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int UpdateDataForCardBySerialAndMasterId(string session, long masterId, long partnerId, string serialnumber, int cardtype, int status);

        /// <summary>
        /// Lấy thông tin để ghi License Partner vào thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="id">Id của Partner</param>
        /// <param name="serialnumbex">Serial number của thẻ</param>
        /// <param name="cardtype">Loại thẻ</param>
        /// <param name="start">Sector bắt đầu ghi License</param>
        /// <param name="stop">Sector kết thuc ghi License</param>
        /// <returns>Dữ liệu cần ghi vào thẻ</returns>
        ResultCheckCardDTO CheckAndGetPartnerDataToImportCard(string session, long id, string serialnumbex, int cardtype, byte start, byte stop);

        /// <summary>
        /// Cập nhật thông tin của thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="id">Id của Partner</param>
        /// <param name="serialnumber">Serial number của thẻ</param>
        /// <param name="cardtype">Loại thẻ</param>
        /// <param name="status"> Tình trạng quyền sử dụng thẻ
        /// 103: CARD_HAS_MASTER_PARTNER_WRITE (chỉ được ghi)
        /// 102: CARD_HAS_MASTER_PARTNER_READED (Chỉ được đọc)
        /// </param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int UpdateDataForCardBySerialAndPartnerId(string session, long id, string serialnumber, int cardtype, int status);

        #endregion

        #region Card Status

        /// <summary>
        /// Cập nhật danh sách thẻ bị mất
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="CardChipIds">Id của thẻ trong hệ thống(List)</param>
        /// <returns></returns>
        List<MethodResultDto> MarkBrokenCards(string session, long[] CardChipIds);

        /// <summary>
        /// Cập nhật danh sách thẻ hủy đánh dấu hư 
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="CardChipIds">Id của thẻ trong hệ thống(List)</param>
        /// <returns></returns>
        List<MethodResultDto> MarkLostCards(string session, long[] CardChipIds);

        /// <summary>
        /// Cập nhật danh sách thẻ bị mất
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="CardChipIds">Id của thẻ trong hệ thống(List)</param>
        /// <returns></returns>
        List<MethodResultDto> UnMarkBrokenCards(string session, long[] CardChipIds);

        /// <summary>
        /// Cập nhật danh sách thẻ hủy đánh dấu mất
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="CardChipIds">Id của thẻ trong hệ thống(List)</param>
        /// <returns></returns>
        List<MethodResultDto> UnMarkLostCards(string session, long[] CardChipIds);

        #endregion

        /// <summary>
        /// Lấy thông tin thông kê tinh trạng của thẻ chip
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="masterId">Id của Master</param>
        /// <param name="partnerId">Id của Partner</param>
        /// <returns></returns>
        List<CardStatisticsData> StatisticCardChipByStatus(string session, long masterId, long partnerId);

        /// <summary>
        /// Lấy thông tin thông kê lượt phát hành thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <returns>thông tin thống kê lượt phát hành</returns>
        List<CardStatisticsData> StatisticCardChipByPersoStatus(string session);

        List<KeyDTO> GetKeyClearEmptyCard(string session, long orgId, string serialNumber, int cartType);
    }
}
