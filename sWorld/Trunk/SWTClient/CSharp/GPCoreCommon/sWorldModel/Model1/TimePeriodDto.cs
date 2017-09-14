using System;
using System.Runtime.Serialization;

namespace sWorldModel.Model
{
    [DataContract]
    public struct TimePeriodDto
    {
        [DataMember]
        public string Start { get; set; }

        [DataMember]
        public string End { get; set; }

        #region Public methods

        /// <summary>
        /// Lấy ra interval của period
        /// </summary>
        //public TimeSpan GetDuration()
        //{
        //    return Start.Subtract(End);
        //}

        ///// <summary>
        ///// Kiểm tra xem TimePeriod này có "trùng"
        ///// TimePeriod kia hay không
        ///// </summary>
        //public bool IsSamePeriod(TimePeriodDto period)
        //{
        //    return this.End == period.End && this.Start == period.Start;
        //}

        ///// <summary>
        ///// Kiểm tra xem TimePeriod này có "chứa" một
        ///// ngày nào đó hay không
        ///// </summary>
        //public bool HasInside(DateTime test)
        //{
        //    return test >= this.Start && test <= this.End;
        //}

        ///// <summary>
        ///// Kiểm tra xem TimePeriod này có "chứa"
        ///// TimePeriod kia hay không
        ///// </summary>
        //public bool HasInside(TimePeriodDto period)
        //{
        //    return this.HasInside(period.Start)
        //        && this.HasInside(period.End);
        //}

        ///// <summary>
        ///// Kiểm tra xem TimePeriod này có "giao" với
        ///// một TimePeriod khác hay không
        ///// </summary>
        //public bool IntersectWith(TimePeriodDto period)
        //{
        //    return this.HasInside(period.Start)
        //        || this.HasInside(period.End)
        //        || (period.Start < this.Start && period.End > this.End);
        //}

        #endregion
    }
}
