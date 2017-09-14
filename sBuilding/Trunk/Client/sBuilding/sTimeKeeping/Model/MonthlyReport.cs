using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace sTimeKeeping.Model
{
    [DataContract]
    public class MonthlyReport
    {
        [DataMember]
    public long id{get; set; }
        [DataMember]
	public long orgId{get; set; }
        [DataMember]
	public long subOrgId{get; set; }
        [DataMember]
	public long memberId{get; set; }
        [DataMember]
    public int year { get; set; }
        [DataMember]
	public int month{get; set; }
        [DataMember]
	public int day1{get; set; }
        [DataMember]
	public int day2{get; set; }
        [DataMember]
	public int day3{get; set; }
        [DataMember]
	public int day4{get; set; }
        [DataMember]
	public int day5{get; set; }
        [DataMember]
	public int day6{get; set; }
        [DataMember]
	public int day7{get; set; }
        [DataMember]
	public int day8{get; set; }
        [DataMember]
	public int day9{get; set; }
        [DataMember]
	public int day10{get; set; }
        [DataMember]
	public int day11{get; set; }
        [DataMember]
	public int day12{get; set; }
        [DataMember]
	public int day13{get; set; }
        [DataMember]
	public int day14{get; set; }
        [DataMember]
	public int day15{get; set; }
        [DataMember]
	public int day16{get; set; }
        [DataMember]
	public int day17{get; set; }
        [DataMember]
	public int day18{get; set; }
        [DataMember]
	public int day19{get; set; }
        [DataMember]
	public int day20{get; set; }
        [DataMember]
	public int day21{get; set; }
        [DataMember]
	public int day22{get; set; }
        [DataMember]
	public int day23{get; set; }
        [DataMember]
	public int day24{get; set; }
        [DataMember]
	public int day25{get; set; }
        [DataMember]
	public int day26{get; set; }
        [DataMember]
	public int day27{get; set; }
        [DataMember]
	public int day28{get; set; }
        [DataMember]
	public int day29{get; set; }
        [DataMember]
	public int day30{get; set; }
        [DataMember]
	public int day31{get; set; }
    }
}
