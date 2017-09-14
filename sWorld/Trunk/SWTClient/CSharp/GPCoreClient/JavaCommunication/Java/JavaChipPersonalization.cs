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
using JavaCommunication.Common;
using sWorldCommunication;

namespace JavaCommunication.Java
{
    public class JavaChipPersonalization : IChipPersonalization
    {
        private static JavaChipPersonalization instance = new JavaChipPersonalization();
        public static JavaChipPersonalization Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaChipPersonalization();
                }
                return instance;
            }
        }
        private JavaChipPersonalization()
        {
        }

        #region Application

        public List<App> GetAppDataList(string session, long orgId, long subOrgId)
        {
            return new List<App>();
        }

        #endregion

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
            return CommunicationChipPersonalization.Instance.GetKeyForReadCard(session, serialNumber, cardType, list);
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
        public DataToWriteCardDTO CheckAndGetPersonData(string session, long memberId, string serialNumber, int cardType, byte sectorStart, string issuer)
        {
            return CommunicationChipPersonalization.Instance.CheckAndGetPersoData(session, memberId, serialNumber, cardType, sectorStart, issuer);
        }

        public DataToWriteCardDTO CheckAndGetAppDataToClearCard(string session, string serialNumber, int cardType, byte sectorStart, byte sectorStop, string issuer)
        {
            return CommunicationChipPersonalization.Instance.CheckAndGetAppDataToClearCard(session, serialNumber, cardType, sectorStart, sectorStop, issuer);
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
            return CommunicationChipPersonalization.Instance.GetDataToReadCard(session, serialNumber, cardType, memberData);
        }

        /// <summary>
        /// Tiến hành cá thể hóa (cấp phát thẻ)
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="teacherId"></param>
        /// <param name="serialNumberHex"></param>
        public int PersoCardChip(string session, long memberId, string serialNumberHex)
        {
            return CommunicationChipPersonalization.Instance.PersoCardChip(session, memberId, serialNumberHex);
        }

        /// <summary>
        /// Lấy thông tin member và app để cập nhật cho thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public DataToWriteCardDTO GetDataToUpdateCard(string session, string serialNumber, byte sectorStart, String issuer)
        {
            return CommunicationChipPersonalization.Instance.GetDataToUpdateCard(session, serialNumber, sectorStart, issuer);
        }

        /// <summary>
        /// Cập nhật ứng dụng cho thành viên (chủ thẻ)
        /// </summary>
        /// <param name="sessionId"></param>
        /// <param name="serialNumber"></param>
        /// <param name="lastUpdateDate"></param>
        public int UpdateMemberAppOfPerso(string session, string serialNumber, string lastUpdateDate)
        {
            return CommunicationChipPersonalization.Instance.UpdateMemberAppOfPerso(session, serialNumber, lastUpdateDate);
        }

        /// <summary>
        /// Xóa thông tin Member và app của thẻ
        /// </summary>
        /// <param name="session"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public int ClearCardData(string session, string serialNumber)
        {
            return CommunicationChipPersonalization.Instance.ClearCardData(session, serialNumber);
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
            return CommunicationChipPersonalization.Instance.CancelPersoes(session, ChipPersoIds, cancelReason);
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
            return CommunicationChipPersonalization.Instance.LockPersoes(session, ChipPersoIds, lockReason);
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
            return CommunicationChipPersonalization.Instance.UnLockPersoes(session, ChipPersoIds, unlockReason);
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
            return CommunicationChipPersonalization.Instance.ExtendPerso(session, ChipPersoIds, expirationDate);
        }
        #endregion

        public List<MemberCustomerDTO> GetChangeStatus(string session, byte status, string Reason, List<long> ChipPersoIds)
        {
            return CommunicationChipPersonalization.Instance.GetChangeStatus(session, status, Reason, ChipPersoIds);
        }
    }
}
