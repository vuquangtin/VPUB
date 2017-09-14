package com.nonresident.common;

import javax.ws.rs.core.MediaType;

/**
 * MeetingDefines
 * 
 * @author TaiMai
 * 
 */
public class NonResidentDefines {
	public static final String APPLICATION_JSON = MediaType.APPLICATION_JSON + "; charset=utf-8";

	
	
	// quan ly doi tuong NonResident
	public static final String NON_RESIDENT_MANAGER = "nonresidentmg";
	public static final String NON_RESIDENT_ORGANIZATION_MANAGER = "nonresidentorgmg";
	public static final String NON_RESIDENT_SUB_ORGANIZATION_MANAGER = "nonresidentsuborgmg";
	public static final String NON_RESIDENT_MEMBER_MAP_MANAGER = "nonresidentmemmapmg";

	public static final String INSERT_NONRESIDENT = "insertnonresident";
	public static final String UPDATE_NONRESIDENT = "updatenonresident";
	public static final String UPDATE_NONRESIDENT_BY_SERIALNUMBER_DATETIME = "updatenonresidentbyserialnumberanddatetime";
	public static final String GET_NON_RESIDENT_BY_SERIALNUMBER = "getnonresidentbyserialnumber";
	public static final String CHECK_INOUT_NONRESIDENT_BY_SERIALNUMBER = "checkinoutnonresidentbyserialnumber";

	// NonResidentOrganization
	public static final String INSERT_NON_RES_ORG = "insertnonresorg";
	public static final String UPDATE_NON_RES_ORG = "updatenonresorg";
	public static final String DELETE_NON_RES_ORG = "deletenonresorg";
	public static final String GET_NON_RES_ORG = "getnonresorg";
	public static final String GET_LIST_ALL_NON_RES_ORG = "getlistallnonresorg";
	
	// NonResidentSubOrganization
	public static final String INSERT_NON_RES_SUB_ORG = "insertnonressubsorg";
	public static final String UPDATE_NON_RES_SUB_ORG = "updatenonressubsorg";
	public static final String DELETE_NON_RES_SUB_ORG = "deletenonressubsorg";
	public static final String GET_NON_RES_SUB_ORG = "getnonressubsorg";
	public static final String GET_LIST_ALL_NON_RES_SUB_ORG = "getlistallnonressubsorg";
	
	// NonResidentMemberMap
	public static final String INSERT_NON_RES_MEMBER_MAP = "insertnonresmemmap";
	public static final String UPDATE_NON_RES_MEMBER_MAP = "updatenonresmemmap";
	public static final String DELETE_NON_RES_MEMBER_MAP = "deletenonresmemmap";
	public static final String GET_NON_RES_MEMBER_MAP = "getnonresmemmap";
	public static final String GET_LIST_ALL_NON_RES_MEMBER_MAP = "getlistallnonresmemmap";
	
	// thong ke NonResident
	public static final String NON_RESIDENT_STATSTIC_MANAGER = "nonresidentstatisticmg";
	public static final String GET_LIST_NON_RESIDENT_STATISTIC_BY_DATE = "getlistnonresidentstatisticbydate";
	public static final String GET_LIST_NON_RESIDENT_BY_ORGID_AND_DATE = "getlistnonresidentbyorgidanddate";
	public static final String GET_LIST_NON_RESIDENT_BY_DATE = "getlistnonresidentbydate";
	public static final String GET_LIST_NON_RESIDENT_BY_DATE_ORGID = "getlistnonresidentbydateandorgid";

	// meeting
	public static final String NON_RESIDENT_MEETING_MANAGER = "nonresidentmeetingmg";
	public static final String INSERT_NON_RESIDENT_MEETING = "insertnonresidentmeeting";
	public static final String UPDATE_NON_RESIDENT_MEETING = "updatenonresidentmeeting";
	public static final String DELETE_NON_RESIDENT_MEETING = "deletenonresidentmeeting";
	public static final String GET_NON_RESIDENT_MEETING_BY_ID = "getnonresidentmeetingbyid";
	public static final String GET_NON_RESIDENT_MEETING_BY_ORGANIZATION_MEETING_ID = "getnonresidentmeetingbyorganizationmeetingid";
	public static final String GET_NON_RESIDENT_MEETING_BY_DATE = "getnonresidentmeetingbydate";
	public static final String GET_NON_RESIDENT_MEETING_BY_DATE_AND_ORGANIZATION_MEETING_ID_AND_MEETING_NAME = "getnonresidentmeetingbyorganizationmeetingidandmeetingname";
	

}
