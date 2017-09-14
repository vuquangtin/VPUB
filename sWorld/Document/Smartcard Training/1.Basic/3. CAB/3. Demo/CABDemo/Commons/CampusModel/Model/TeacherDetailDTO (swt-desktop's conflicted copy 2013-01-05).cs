using System;
using System.Runtime.Serialization;
using System.Text;

namespace CampusModel.Model
{
    /// <summary>
    /// Giảng viên
    /// </summary>
    [DataContract]
    public class TeacherDetailDTO
    {
        #region Public properties

        /// <remarks>
        /// Mã giảng viên theo dữ liệu của nhà trường
        /// </remarks>
        [DataMember]
        public string Code { get; set; }

        /// <remarks>
        /// Thời điểm tạo dữ liệu trong database
        /// </remarks>
        [DataMember]
        public System.DateTime CreatedAt { get; set; }

        /// <remarks>
        /// Mã user tạo dữ liệu
        /// </remarks>
        [DataMember]
        public long CreatedBy { get; set; }

        /// <remarks>
        /// Bằng cấp/học vị, ví dụ: cử nhân, thạc sĩ...
        /// </remarks>
        [DataMember]
        public string Degree { get; set; }

        /// <remarks>
        /// Mã bộ môn trong database
        /// </remarks>
        [DataMember]
        public long DepartmentId { get; set; }

        /// <remarks>
        /// Tên bộ môn mà giảng viên đó công tác
        /// </remarks>
        [DataMember]
        public string DepartmentName { get; set; }

        /// <remarks>
        /// Mã khoa trong database
        /// </remarks>
        [DataMember]
        public long FacultyId { get; set; }

        /// <remarks>
        /// Tên khoa mà giảng viên đó công tác
        /// </remarks>
        [DataMember]
        public string FacultyName { get; set; }

        /// <remarks>
        /// Tên của giảng viên
        /// </remarks>
        [DataMember]
        public string FirstName { get; set; }

        /// <remarks>
        /// Mã giảng viên trong database
        /// </remarks>
        [DataMember]
        public long Id { get; set; }

        /// <remarks>
        /// Cho biết giảng viên còn làm việc không
        /// </remarks>
        [DataMember]
        public bool IsWorking { get; set; }

        /// <remarks>
        /// Thời điểm dữ liệu được chỉnh sửa lần cuối
        /// </remarks>
        [DataMember]
        public System.DateTime LastModifiedAt { get; set; }

        /// <remarks>
        /// Mã user chỉnh sửa lần cuối
        /// </remarks>
        [DataMember]
        public long LastModifiedBy { get; set; }

        /// <remarks>
        /// Họ và chữ lót của giảng viên
        /// </remarks>
        [DataMember]
        public string LastName { get; set; }

        /// <remarks>
        /// Mã thông tin cá nhân trong database
        /// </remarks>
        [DataMember]
        public PersonalInfoDTO PersonalInfo { get; set; }

        /// <summary>
        /// Cho biết giảng viên đã được cấp phát thẻ
        /// có hiệu lực hay chưa
        /// </summary>
        [DataMember]
        public bool Personalized { get; set; }

        /// <remarks>
        /// Chức vụ, ví dụ: trưởng khoa, phó khoa...
        /// </remarks>
        [DataMember]
        public string Position { get; set; }

        /// <remarks>
        /// Ngạch lương
        /// </remarks>
        [DataMember]
        public double ScaleOfSalary { get; set; }

        /// <remarks>
        /// Ngày bắt đầu giảng dạy
        /// </remarks>
        [DataMember]
        public DateTime? TeachingStartDate { get; set; }

        /// <remarks>
        /// Chức danh, ví dụ: giảng viên, trợ giảng...
        /// </remarks>
        [DataMember]
        public string Title { get; set; }

        /// <remarks>
        /// Loại giảng viên
        /// </remarks>
        [DataMember]
        public string Type { get; set; }

        /// <remarks>
        /// Ngày nghỉ làm
        /// </remarks>
        [DataMember]
        public DateTime? WorkEndDate { get; set; }

        /// <remarks>
        /// Ngày bắt đầu làm việc
        /// </remarks>
        [DataMember]
        public DateTime? WorkStartDate { get; set; }

        #endregion Public properties

        #region Public methods

        public string GetFullName()
        {
            return LastName + " " + FirstName;
        }

        public string GetShortDescription()
        {
            StringBuilder sb = new StringBuilder();
            if (Title != null)
            {
                sb.Append(Title);
                sb.Append(" ");
            }
            sb.Append(LastName);
            sb.Append(" ");
            sb.Append(FirstName);
            sb.Append(" - ");
            sb.Append("Khoa: ");
            sb.Append(FacultyName);
            return sb.ToString();
        }

        #endregion Public methods
    }
}