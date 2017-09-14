using System;
using System.Runtime.Serialization;

namespace sWorldModel.TransportData
{
    [DataContract]
    public struct TimePeriodDto
    {
        [DataMember]
        public string Start { get; set; }

        [DataMember]
        public string End { get; set; }

        #region Public methods

        public DateTime StartDate { get { return Convert.ToDateTime(Start); } }
        public DateTime EndDate { get { return Convert.ToDateTime(End); } }

        /// <summary>
        /// Lấy ra interval của period
        /// </summary>
        public TimeSpan GetDuration()
        {
            return StartDate.Subtract(EndDate);
        }

        /// <summary>
        /// Kiểm tra xem TimePeriod này có "trùng"
        /// TimePeriod kia hay không
        /// </summary>
        public bool IsSamePeriod(TimePeriodDto period)
        {
            return this.End == period.End && this.Start == period.Start;
        }

        /// <summary>
        /// Kiểm tra xem TimePeriod này có "chứa" một
        /// ngày nào đó hay không
        /// </summary>
        public bool HasInside(DateTime test)
        {
            return test >= this.StartDate && test <= this.EndDate;
        }

        /// <summary>
        /// Kiểm tra xem TimePeriod này có "chứa"
        /// TimePeriod kia hay không
        /// </summary>
        public bool HasInside(TimePeriodDto period)
        {
            return this.HasInside(period.StartDate)
                && this.HasInside(period.EndDate);
        }

        /// <summary>
        /// Kiểm tra xem TimePeriod này có "giao" với
        /// một TimePeriod khác hay không
        /// </summary>
        public bool IntersectWith(TimePeriodDto period)
        {
            return this.HasInside(period.StartDate)
                || this.HasInside(period.EndDate)
                || (period.StartDate < this.StartDate && period.EndDate > this.EndDate);
        }

        #endregion
    }
}
