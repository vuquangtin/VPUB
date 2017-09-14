using sWorldModel.Filters;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldCommunication.Interface
{
    public interface IeCash
    {
        #region begin payin

     

        /// <summary>
        /// Kiểm tra tính hiệu lực của thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="serialNumber">Serial number của thẻ</param>
        /// <param name="dataPayIn">Dữ liệu nạp tiền sector 11</param>
        /// <param name="dataPayOut"> Dữ liệu trừ tiền sector 12</param>
        /// <returns> Kết quả trả về gồm:
        ///     0: Normal,
        ///     1: Locked
        ///     2: Canceled,
        ///     3: Expired,
        ///     4: Broken,
        ///     5: Lost
        ///     6: LockMoneyCard
        /// </returns>
        int ValidateCard(string session, string serialNumber, string dataPayIn, string dataPayOut,string code);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        List<GroupItemConfig> getGroupItemByConfig(string session,long Orgcode);
        /// <summary>
        /// Yêu cầu thực hiện nạp tiền vào thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="serialNumber">Serial number của thẻ</param>
        /// <param name="IpAddress">Địa chỉ Ip của máy trạm giao dịch</param>
        /// <param name="amount">Số tiền muốn nạp vào thẻ</param>
        /// <param name="code">Mã chứng thực số tiền sector 11</param>
        /// <returns> Kết quả trả về PayInDto gồm các field sau:
        ///     Id
        ///     KeyB
        ///     DataWriteToCard
        ///     VerificationCode
        ///     Status 
        /// </returns>
        PayInDto GetDataPayInWriteToCard(string session,PayInDto payinDto,int cardtype );

        /// <summary>
        /// Cập nhật trạng thái Log nạp tiền
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="payInId">Id của Log nạp tiền</param>
        /// <param name="field">Chưa biết sử dụng làm gi? (Hỏi anh Nam)</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL
        /// </returns>
        int UpdateStatusPayIn(string session, PayInDto payinDto, string field);

        /// <summary>
        /// Yêu cầu thực hiện trừ tiền vào thẻ
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="memberId">Id của Member</param>
        /// <param name="serialNumber">Serial number của thẻ</param>
        /// <param name="IpAddress">Địa chỉ Ip của máy trạm giao dịch</param>
        /// <param name="amount">Số tiền muốn trừ</param>
        /// <param name="code">Mã chứng thực số tiền của sector 11(suy nghĩ thêm về vấn đề này)</param>
        /// <returns>Dữ liệu để thực hiện trừ tiền vào thẻ</returns>
        List<PayOutDto> GetDataPayOutWriteToCard(string session, List<PayOutDto> payOutDto, int cardtype);

        /// <summary>
        /// Cập nhật trạng thái Log trừ tiền
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <param name="payInId">Id của Log trừ tiền</param>
        /// <param name="field">Chưa biết sử dụng làm gi? (Hỏi anh Nam)</param>
        /// <returns>Tình trạng kết quả
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL
        /// </returns>
        int UpdateStatusPayOut(string session, List<PayOutDto> payOutId, string field);

        ///// <summary>
        ///// Đồng bộ dữ liệu số tiền trên thẻ với trong hệ thống
        ///// </summary>
        ///// <param name="session">Mã session của user đã đăng nhập</param>
        ///// <param name="memberId">Id của Member</param>
        ///// <param name="serialNumber">Serial number của thẻ</param>
        ///// <returns>
        ///// TH1: Log yêu cầu nạp tiền và Log nạp tiền thành công trùng khớp => kết quả Null
        ///// TH2: Log yêu cầu nạp tiền lớn hơn Log nạp tiền thành công
        /////     - Chưa ghi Log nạp tiền thành công => Ghi Log nạp tiền thành công và trả kết quả new PayInDto()
        /////     - Chưa ghi Log nạp tiền thành công và ghi tiền vào thẻ => trả kết quả là dữ liệu nạp tiền vào thẻ
        /////     - Client gửi yêu cầu cập nhật lại Log nạp tiền thành công
        ///// </returns>
        //PayInDto SynsDataPayInToCard(string session, long memberId, string serialNumber, long amount, string payInDate);

        ///// <summary>
        ///// Gửi danh sách payInList cần đồng bộ hóa lên Server
        ///// </summary>
        ///// <param name="session">Mã session của user đã đăng nhập</param>
        ///// <param name="payInList"></param>
        ///// <returns></returns>
        //int SynsDataPayInToServer(string session, List<PayInDto> payInList);

        /// <summary>
        ///  hàm này để lấy tất cả danh sách các lượt nạp tiền nếu truyền vào payinRequestId = 0; 
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="Amount"></param>
        /// <param name="payinDate"></param>
        /// <returns></returns>
        List<PayInStatisticDto> GetPayInRequestFilterByPayInRequestId(string session, long payinRequestId, StatisticTouUpFilter filter);
        /// <summary>
        /// hàm này để lấy tất cả danh sách các lượt trừ tiền nếu truyền vào payoutRequestId = 0; 
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="Amount"></param>
        /// <param name="payinDate"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<PayOutStatisticDto> GetPayOutRequestFilterByPayOutRequestId(string session, long payinRequestId, StatisticDeductFilter filter);
        #endregion end payin

        #region CardConfig
        List<Config_card> GetConfigFilterListByConfigId(string session, long ecashconfigId,EcashConfigFilterDto filter); 
        /// <summary>
        /// Danh sách tất cả cấu hình giao dich
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <returns>List danh sách cấu hình giao dich
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL
        /// </returns>
        List<Config_card> GetAllEcashConfig(string session);
        // các hàm thêm xóa sưa
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashconfigId"></param>
        /// <returns></returns>
        Config_card GetEcashConfigById(string session, long ecashconfigId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashconfig"></param>
        /// <returns></returns>
        Config_card InsertEcashConfig(string session, Config_card ecashconfig);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashconfig"></param>
        /// <returns></returns>
        Config_card UpdateEcashConfig(string session, Config_card ecashconfig);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashconfigId"></param>
        /// <returns></returns>
        int RemoveEcashConfig(string session, long ecashconfigId);    
        

        #endregion end Card Config

        #region Group Item
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashconfig"></param>
        /// <returns></returns>
        GroupDto InsertGroupItem(string session, GroupDto ecashgroup);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashconfig"></param>
        /// <returns></returns>
        GroupDto UpdateGroupItem(string session, GroupDto ecashgroup);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashconfigId"></param>
        /// <returns></returns>
        int DeleteGroupItem(string session, long ecashgroupId);
        /// <summary>
        /// Danh sách tất cả Group
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <returns>List danh sách cấu hình giao dich
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL
        /// </returns>
        List<GroupDto> GetAllGroupItem(string session);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashgroupId"></param>
        /// <returns></returns>
        GroupDto GetGroupItemByGroupItemId(string session, long ecashgroupId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        List<GroupDto> GetGroupItemFilterListByGroupId(string session, long orgId, GroupItemFilterDto filter);

        #endregion end Group Item

        #region begin  Item
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashconfig"></param>
        /// <returns></returns>
        ItemDto InsertItem(string session, ItemDto ecashitem);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashconfig"></param>
        /// <returns></returns>
        ItemDto UpdateItem(string session, ItemDto ecashitem);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashconfigId"></param>
        /// <returns></returns>
        int DeleteItem(string session, long ecashitemId);
        /// <summary>
        /// Danh sách tất cả Group
        /// </summary>
        /// <param name="session">Mã session của user đã đăng nhập</param>
        /// <returns>List danh sách cấu hình giao dich
        /// 0: SUCCESS,
        /// 1: FAILED,
        /// 2: CANCEL
        /// </returns>
        List<ItemDto> GetAllItem(string session);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashitemId"></param>
        /// <returns></returns>
        ItemDto GetItemByItemId(string session, long ecashitemId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashgroupId"></param>
        /// <returns></returns>
        List<ItemDto> GetItemByGroupItemId(string session, long ecashgroupId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ecashgroupId"></param>
        /// <returns></returns>
        List<ItemDto> GetItemFilterListByGroupId(string session, long ecashgroupId, ItemFilterDto filter);
         #endregion end  Item

    
        //  ItemDto Insert(string p, ItemDto AddOrUpdateItem);

       // GroupDto InsertEcashCo(string p, GroupDto AddOrUpdateGroup);

     
    }

}
