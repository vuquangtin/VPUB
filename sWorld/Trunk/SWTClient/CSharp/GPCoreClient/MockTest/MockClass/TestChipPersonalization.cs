using MockTest.Data;
using sWorldModel.Filters;
using sWorldModel.MethodData;
using sWorldModel.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using sWorldModel.TransportData;
using sWorldCommunication;

namespace MockTest.MockClass
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

        #region Perso Card

        /// <summary>
        /// Lấy danh sách KeyA để đọc thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <param name="serialNumber"></param>
        /// <param name="cardType"></param>
        /// <param name="list">Danh sách qui định các Master, Partner, Header, Data ghi vào sector nào
        /// list == null => gửi keyA của header
        /// list.count > 0 => gửi về danh sách keyA để đọc Data
        /// </param>
        /// <returns></returns>
        public DataToReadCardDTO GetKeyForReadCard(string session, string serialNumber, int cardType, List<int> list) 
        {
            if (list != null && list.Count() > 0)
                return HardCode.Instance.GetKeyForWriteCard(list);
            else
                return null;
        }

        /// <summary>
        /// Lấy thông tin member - app và cặp key để ghi vào thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <param name="memberId"></param>
        /// <param name="serialNumber"></param>
        /// <param name="cardType"></param>
        /// <param name="list">Danh sách qui định Master, Partner, Header, Data được ghi từ sector nào</param>
        /// <returns></returns>
        public DataToWriteCardDTO CheckAndGetAppDataToPersoCard(string session, long memberId, string serialNumber, int cardType, byte sectorStart, List<long> AppIds)
        {
            return HardCode.Instance.CheckAndGetAppDataToPersoCard(sectorStart);
        }

        public DataToWriteCardDTO CheckAndGetAppDataToClearCard(string session, string serialNumber, int cardType, byte sectorStart, byte sectorStop) 
        {
            return HardCode.Instance.CheckAndGetAppDataToClearCard(sectorStart, sectorStop);
        }

        /// <summary>
        /// Lấy thông tin member và app để đọc thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <param name="serialNumber"></param>
        /// <param name="cardType"></param>
        /// <param name="memberData">mảng byte data của thẻ</param>
        /// <returns></returns>
        public DataForReadCard GetDataToReadCard(string session, string serialNumber, int cardType, string memberData)
        {
            return new DataForReadCard();
        }

        /// <summary>
        /// Tiến hành cá thể hóa (cấp phát thẻ)
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="teacherId"></param>
        /// <param name="serialNumberHex"></param>
        public int PersoCardChip(string session, long memberId, string serialNumberHex, List<long> AppIds)
        {
            return (int)Status.SUCCESS;
        }

        /// <summary>
        /// Lấy thông tin member và app để cập nhật cho thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public DataToWriteCardDTO GetDataToUpdateCard(string session, string serialNumber, byte sectorStart)
        {
            return HardCode.Instance.GetDataToUpdateCard(sectorStart);
        }

        /// <summary>
        /// Cập nhật ứng dụng cho thành viên (chủ thẻ)
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="serialNumber"></param>
        /// <param name="lastUpdateDate"></param>
        public int UpdateMemberAppOfPerso(string session, string serialNumber, string lastUpdateDate)
        {
            return (int)Status.SUCCESS;
        }

        /// <summary>
        /// Xóa thông tin Member và app của thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public int ClearCardData(string session, string serialNumber)
        {
            return (int)Status.SUCCESS;
        }

        #endregion

       

        #region Perso Status
        /// <summary>
        /// Hủy lượt phát hành cho danh sách thành viên
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ChipPersoIds">Id của thành viên (List)</param>
        /// <param name="cancelReason">Lý do hủy lượt phát hành</param>
        /// <returns></returns>
        public List<MethodResultDto> CancelPersoes(string session, long[] ChipPersoIds, string cancelReason)
        {
            return new List<MethodResultDto>();
        }

        /// <summary>
        /// Khóa lượt phát hành cho danh sách thành viên
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ChipPersoIds">Id của thành viên (List)</param>
        /// <param name="lockReason">Lý do khóa lượt phát hành</param>
        /// <returns></returns>
        public List<MethodResultDto> LockPersoes(string session, long[] ChipPersoIds, string lockReason)
        {
            return new List<MethodResultDto>();
        }

        /// <summary>
        /// Mở khóa lượt phát hành cho danh sách thành viên
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ChipPersoIds">Id của thành viên (List)</param>
        /// <param name="unlockReason">Lý do mở khóa lượt phát hành</param>
        /// <returns></returns>
        public List<MethodResultDto> UnLockPersoes(string session, long[] ChipPersoIds, string unlockReason)
        {
            return new List<MethodResultDto>();
        }

        /// <summary>
        /// Gia hạn lượt phát hành cho danh sách thành viên
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ChipPersoIds">Id của thành viên (List)</param>
        /// <param name="expirationDate">Ngày gia hạn</param>
        /// <returns></returns>
        public List<MethodResultDto> ExtendPerso(string session, long[] ChipPersoIds, string expirationDate)
        {
            return new List<MethodResultDto>();
        }
        #endregion

        public List<MemberCustomerDTO> GetChangeStatus(string session, byte status, string Reason, List<long> ChipPersoIds) 
        {
            //TODO: implement
            return null;
        }
    }
}
