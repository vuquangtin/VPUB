using sWorldModel.Filters;
using sWorldModel.MethodData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;

namespace sWorldCommunication
{
    public interface IChipPersonalization
    {

        #region Perso Card

        /// <summary>
        /// Lấy danh sách keyB của sector để đọc thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="serialnumbex">Serial number của thẻ</param>
        /// <param name="cardType">Loại thẻ</param>
        /// <param name="list">Danh sách sector cần lấy keyB</param>
        /// <returns>Thông tin của keyB của sector cần đọc thẻ</returns>
        DataToReadCardDTO GetKeyForReadCard(string session, string serialNumber, int cardType, List<int> list);

        /// <summary>
        /// Lấy thông tin dữ liệu cần ghi vào thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="memberId">Id của Master</param>
        /// <param name="serialNumber">Serial number của thẻ</param>
        /// <param name="cardType">Loại thẻ</param>
        /// <param name="sectorStart">Sector bắt đầu ghi ứng dụng</param>
        /// <param name="AppIds">Danh sách Id cần ghi ứng dụng</param>
        /// <returns>Thông tin dữ liệu cần ghi vào thẻ</returns>
        DataToWriteCardDTO CheckAndGetPersonData(string session, long memberId, string serialNumber, int cardType, byte sectorStart, string issuer);

        /// <summary>
        /// Lấy danh sách KeyB để xóa dữ liệu trên thẻ và xóa lượt phát hành thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="serialNumber">Serial number của thẻ</param>
        /// <param name="cardType">Loại thẻ</param>
        /// <param name="sectorStart">Sector bắt đầu xóa dữ liệu</param>
        /// <param name="sectorStop">Sector kết thúc xóa dữ liệu</param>
        /// <returns>Thông tin xóa dữ liệu trên thẻ</returns>
        DataToWriteCardDTO CheckAndGetAppDataToClearCard(string session, string serialNumber, int cardType, byte sectorStart, byte sectorStop, string issuer);

        /// <summary>
        /// Lấy thông tin dữ liệu của thẻ 
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="serialNumber">Serial number của thẻ</param>
        /// <param name="cardType">Loại thẻ</param>
        /// <param name="memberData">chuỗi dữ liệu đã được ghi vào thẻ</param>
        /// <returns>Thông tin dữ liệu của thẻ</returns>
        DataForReadCard GetDataToReadCard(string session, string serialNumber, int cardType, string memberData);

        /// <summary>
        /// Lưu thông tin lượt phát hành
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="memberId">Id của thành viên</param>
        /// <param name="serialNumberHex">Serial number của thẻ</param>
        /// <param name="AppIds">Danh sách Id của ứng dụng</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int PersoCardChip(string session, long memberId, string serialNumberHex);

        /// <summary>
        /// Lấy thông tin dữ liệu cần cập nhật vào thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="serialNumber">Serial number của thẻ</param>
        /// <param name="sectorStart"></param>
        /// <returns>Thông tin dữ liệu cần cập nhật vào thẻ</returns>
        DataToWriteCardDTO GetDataToUpdateCard(string session, string serialNumber, byte sectorStart, string issuer);

        /// <summary>
        /// Cập nhật thông tin lượt phát hành
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="serialNumber">Serial number của thẻ</param>
        /// <param name="lastUpdateDate">Ngày cập nhật lượt phát hành</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int UpdateMemberAppOfPerso(string session, string serialNumber, string lastUpdateDate);

        /// <summary>
        /// Xóa lượt phát hành của thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="serialNumber">Serial number của thẻ</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL,
        /// 3: OKIE
        /// </returns>
        int ClearCardData(string session, string serialNumber);

        #endregion

        #region Perso Status

        /// <summary>
        /// Cập nhật tình trạng hủy của lượt phát hành
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="ChipPersoIds">Danh sách Id của lượt phát hành</param>
        /// <param name="cancelReason">Ghi chú</param>
        /// <returns></returns>
        List<MethodResultDto> CancelPersoes(string session, long[] ChipPersoIds, string cancelReason);

        /// <summary>
        /// Cập nhật tình trạng khóa của lượt phát hành
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="ChipPersoIds">Danh sách Id của lượt phát hành</param>
        /// <param name="lockReason">Ghi chú</param>
        /// <returns>Danh sách kết quả đã được xử lý</returns>
        List<MethodResultDto> LockPersoes(string session, long[] ChipPersoIds, string lockReason);

        /// <summary>
        /// Cập nhật tình trạng mở khóa của lượt phát hành
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="ChipPersoIds">Danh sách Id của lượt phát hành</param>
        /// <param name="unlockReason">Ghi chú</param>
        /// <returns>Danh sách kết quả đã được xử lý</returns>
        List<MethodResultDto> UnLockPersoes(string session, long[] ChipPersoIds, string unlockReason);

        /// <summary>
        /// Cập nhật ngày hết hạn của lượt phát hành
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="ChipPersoIds">Danh sách Id của lượt phát hành</param>
        /// <param name="expirationDate">Ghi chú</param>
        /// <returns>Danh sách kết quả đã được xử lý</returns>
        List<MethodResultDto> ExtendPerso(string session, long[] ChipPersoIds, string expirationDate);

        /// <summary>
        /// Cập nhật tình trạng của lượt phát hành
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="status">Tình trạng lượt phát hành</param>
        /// <param name="Reason">Ghi chú</param>
        /// <param name="ChipPersoIds">Danh sách Id của lượt phát hành</param>
        /// <returns>Danh sách lượt phát hành</returns>
        List<MemberCustomerDTO> GetChangeStatus(string session, byte status, string Reason, List<long> ChipPersoIds);
               

        #endregion

    }
}
