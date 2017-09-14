package com.meeting.common;

import javax.ws.rs.core.MediaType;

/**
 * MeetingDefines
 * 
 * @author TaiMai
 * 
 */
public class MeetingDefines {
	public static final String APPLICATION_JSON = MediaType.APPLICATION_JSON + "; charset=utf-8";

	// public static final String SMEETING_MANAGER = "/smeetingmg"; khong dung
	// den

	/* start room */
	public static final String ROOM_MANAGER = "/roommg";
	public static final String INSERT_ROOM = "/insertroom";
	public static final String UPDATE_ROOM = "/updateroom";
	public static final String DELETE_ROOM = "/deleteroom";
	public static final String GET_ALL_ROOM = "/getallroom";
	public static final String GET_ROOM_BY_ID = "/getroombyid";
	/* end room */

	/* start AttendMeeting */
	public static final String ATTEND_MEETING_MANAGER = "/attendmeetingmg";
	public static final String INSERT_ATTEND_MEETING = "/insertattendmeeting";
	public static final String INSERT_ATTEND_MEETING_NONRESIDENT = "/insertattendmeetingnonresident";
	public static final String INSERT_ATTEND_MEETING_ADD = "/insertattendmeetingadd";
	public static final String UPDATE_ATTEND_MEETING = "/updateattendmeeting";
	public static final String DELETE_ATTEND_MEETING = "/deleteattendmeeting";
	public static final String GET_ALL_ATTEND_MEETING = "/getallattendmeeting";
	public static final String GET_ATTEND_MEETING_BY_ID = "/getattendmeetingbyid";

	public static final String CHECKINOUT_ATTEND_MEETING_BY_BARCODE = "/checkinoutattendmeeting";
	public static final String UPDATE_ATTEND_MEETING_BY_BARCODE = "/updateattendmeeting";
	
	/* end AttendMeeting */

	/* start statistic */
	public static final String GET_ATTEND_MEETING_STATISTIC_OBJ_BY_MEETING_ID = "/getattendmeetingstatisticobjbymeetingid";
	public static final String GET_ATTEND_MEETING_STATISTIC_OBJ_BY_DATE = "/getattendmeetingstatisticobjbydate";
	public static final String GET_ATTEND_MEETING_STATISTIC_OBJ_BY_MEETING_ID_AND_DATE = "/getattendmeetingstatisticobjbymeetingidanddate";
	public static final String GET_ATTEND_MEETING_STATISTIC_DETAIL_BY_DATE = "/getattendmeetingstatisticdetailbydate";
	public static final String GET_ATTEND_MEETING_STATISTIC_DETAIL_BY_ORGANIZATION_MEETING_ID_AND_MEETING_ID = "/getattendmeetingstatisticdetailbyorganizationmeetingidandmeetingid";
	public static final String GET_ATTEND_MEETING_STATISTIC_BY_DATE = "/getattendmeetingstatisticbydate";

	/* end statistic */

	/* start Meeting */
	public static final String MEETING_MANAGER = "/meetingmg";
	public static final String INSERT_MEETING = "/insertmeeting";
	public static final String UPDATE_MEETING = "/updatemeeting";
	public static final String DELETE_MEETING = "/deletemeeting";
	public static final String GET_ALL_MEETING = "/getallmeeting";
	public static final String GET_MEETING_BY_ID = "/getmeetingbyid";
	public static final String GET_MEETING_BY_DATE = "/getmeetingbydate";
	public static final String SEND_MAIL = "/sendmail";
	public static final String REGISTER_EMAIL = "/registeremail";
	public static final String GET_EMAIL_CONFIG = "/getemailconfig";
	public static final String GET_LIST_MEETING_BY_DATE = "/getlistMeetingByDate";
	public static final String GET_LIST_PARTAKER_BY_MEETING_ID = "/getlistPartakerByIdMeeting";

	// service giong ben snonresident
	public static final String UPDATE_MEETING_SAME_SNONRESIDENT = "/updatemeetingsamesnonresident";
	public static final String GET_MEETING_BY_DATE_AND_ORGANIZATION_MEETING_ID_AND_MEETING_NAME = "/getmeetingbyorganizationmeetingidandmeetingname";
	
	public static final String GET_DETAIL_MEETING_BY_MEETINGCODE =  "/getdetailmeetingbymeetingcode";
	/* end Meeting */

	/* start Meeting obj */

	// public static final String GET_MEETING_OBJ_BY_DATE =
	// "/getmeetingobjbydate";
	// public static final String GET_ALL_MEETING_OBJ = "/getallmeetingobj";
	// public static final String GET_MEETING_OBJ_BY_DATE_TIME =
	// "/getmeetingobjbydatetime";
	// public static final String GET_MEETING_OBJ_BY_SERIAL_NUMBER_AND_DATE_TIME
	// = "/getmeetingobjbyserialnumberanddatetime";

	/* end Meeting obj */

	/* start MeetingInvitation */
	public static final String MEETING_INVITATION_MANAGER = "/meetinginvitationmg";
	public static final String INSERT_MEETING_INVITATION = "/insertmeetinginvitation";
	public static final String UPDATE_MEETING_INVITATION = "/updatemeetinginvitation";
	public static final String DELETE_MEETING_INVITATION = "/deletemeetinginvitation";
	public static final String GET_ALL_MEETING_INVITATION = "/getallmeetinginvitation";
	public static final String GET_MEETING_INVITATION_BY_ID = "/getmeetinginvitationbyid";
	/* end MeetingInvitation */

	/* start OrganizationMeeting */
	public static final String ORGANIZATION_MEETING_MANAGER = "/organizationmeetingmg";
	public static final String INSERT_ORGANIZATION_MEETING = "/insertorganizationmeeting";
	public static final String UPDATE_ORGANIZATION_MEETING = "/updateorganizationmeeting";
	public static final String DELETE_ORGANIZATION_MEETING = "/deleteorganizationmeeting";
	public static final String GET_ALL_ORGANIZATION_MEETING = "/getallorganizationmeeting";
	public static final String GET_ALL_ORGANIZATION_MEETING_ASC = "/getallorganizationmeetingasc";
	public static final String GET_ALL_ORG_PARTAKER = "/getallorgPartaker";
	public static final String GET_ORGANIZATION_MEETING_BY_ID = "/getorganizationmeetingbyid";
	/* end OrganoztionMeeting */

	/* start Partaker */
	public static final String PARTAKER_MANAGER = "/partakermg";
	public static final String INSERT_PARTAKER = "/insertpartaker";
	public static final String INSERT_PARTAKER_STRING = "/insertpartakerstring";
	public static final String UPDATE_PARTAKER = "/updatepartaker";
	public static final String UPDATE_PARTAKER_STRING = "/updatepartakerstring";
	public static final String DELETE_PARTAKER = "/deletepartaker";
	public static final String GET_ALL_PARTAKER = "/getallpartaker";
	public static final String GET_PARTAKER_BY_ID = "/getpartakerbyid";
	public static final String GET_DETAIL_MEETING = "/getdetailmeeting";
	public static final String GET_LIST_PARTAKER_BY_ORG_AND_MEETINGID = "/getlistpartakerbyorgandmeetingid";
	/* end Partaker */

	/* start ListMeeting */
	public static final String LIST_MEETING_MANAGER = "/listmeetingmg";
	public static final String INSERT_LIST_MEETING = "/insertlistmeeting";
	public static final String UPDATE_LIST_MEETING = "/updatelistmeeting";
	public static final String DELETE_LIST_MEETING = "/deletelistmeeting";
	public static final String GET_ALL_LIST_MEETING = "/getalllistmeeting";
	public static final String GET_LIST_MEETING_BY_ID = "/getlistmeetingbyid";
	/* end ListMeeting */

	/* start detail infomation */
	public static final String DETAIL_INFO_MANAGER = "/detailinfomg";
	public static final String GET_DETAIL_INFO_BY_BARCODE = "/getdetailinfobybarcode";
	public static final String GET_DETAIL_INFO_BY_BARCODE_ORG_OHTER = "/getdetailinfobybarcodeorgother";
	/* end detail infomation */

	/* start attend meeting obj */
	public static final String ATTEND_MEETING_OBJ_MANAGER = "/attendmeetingobjmg";
	public static final String INSERT_ATTEND_MEETING_OBJ = "/insertattendmeetingobj";
	/* end attend meeting obj */

	/* start attend meeting journalist obj */
	public static final String INSERT_ATTEND_MEETING_JOURNALIST_OBJ = "/insertattendmeetingjournalistobj";

	/* end attend meeting journalist obj */

	/* Journalist manager */
	public static final String JOURNALIST_MANAGER = "/journalistmng";
	public static final String GET_JOURNALIST_OBJ = "/getjournalist";
	public static final String GET_JOURNALIST_OBJ_BY_SERIAL_NUMBER_AND_DATE_TIME = "/getjournalistobjbyserialanddate";
	public static final String CHECKOUT_JOURNALIST = "/checkoutjournalist";
	public static final String CHECK_IS_DATE_EXPIRATED = "/checkisdateexpirated";
	// public static final String CHECKOUT_JOURNALIST = "/checkoutjournalist";

	// public static final String STATISTIC_JOURNALIST_BY_DATE =
	// "/staticjournalistbydate";
	public static final String STATISTIC_JOURNALIST_BY_MEETINGID = "/staticjournalistbymeetingid";
	
	//thong ke nha bao
	public static final String GET_JOURNALIST_ATTEND_MEETING_STATISTIC_OBJ_BY_DATE = "/getjournalistattendmeetingstatisticobjbydate";
	public static final String GET_JOURNALIST_ATTEND_MEETING_STATISTIC_OBJ_BY_MEETING_ID = "/getjournalistattendmeetingstatisticobjbymeetingid";
	public static final String GET_JOURNALIST_ATTEND_MEETING_STATISTIC_DETAIL_BY_ORGANIZATION_MEETING_ID_AND_MEETING_ID = "/getjournalistattendmeetingstatisticdetailbyorganizationmeetingidandmeetingid";

	/**
	 * service tuong tac voi QLVP
	 */

	public static final String MEETING_LCT_MANAGER = "/meetinglctmg";
	public static final String ADD_MEETING_LCT = "/addmeetinglct";
	public static final String EDIT_MEETING_LCT = "/editmeetinglct";
	public static final String DELETE_MEETING_LCT = "/deletemeetinglct";
	public static final String CHANGE_TIME_MEETING_LCT = "/changetimemeetinglct";
	public static final String POSTPONED_MEETING_LCT = "/postponedmeetinglct";
	

	public static final String SAVE_FILE_INVITATION_LCT = "/savefileinvitationlct";
	public static final String ADD_MEETING_INVITATION_LCT = "/addmeetinginvitationlct";
	public static final String EDIT_MEETING_INVITATION_LCT = "/editmeetinginvitationlct";
	public static final String DELETE_MEETING_INVITATION_LCT = "/deletemeetinginvitationlct";

	/**
	 * @author My.nguyen 
	 * */
	public static final String INSERT_ORGANIZATION_MEETING_LCT = "/insertorganizationmeetinglct";
	public static final String UPDATE_ORGANIZATION_MEETING_LCT = "/updateorganizationmeetinglct";
	public static final String DELETE_ORGANIZATION_MEETING_LCT = "/deleteorganizationmeetinglct";
	public static final String ORGANIZATION_MEETING_LCT_MANAGER = "/organizationmeetinglctmg";
	
	
	/**
	 * service thong ke lien he
	 */
	public static final String SMEETING_CONTACT_STATISTIC_MANAGER = "/smeetingcontactstatisticmg";
	public static final String INSERT_SMEETING_CONTACT_STATISTIC = "/insertsmeetingcontact";
	public static final String SMEETING_CONTACT_STATISTIC_BY_DATE = "/smeetingcontactstatisticbydate";
	public static final String SMEETING_CONTACT_STATISTIC_BY_DATE_AND_ORG_ID = "/smeetingcontactstatisticbydateandorgid";
	

}
