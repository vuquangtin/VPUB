/**
 * 
 */
package com.meeting.services;

import javax.ws.rs.Consumes;
import javax.ws.rs.CookieParam;
import javax.ws.rs.GET;
import javax.ws.rs.Path;
import javax.ws.rs.PathParam;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import com.meeting.common.MeetingDefines;
import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.swt.meeting.customObject.DetailInfo;
import com.swt.meeting.customObject.DetailInfoOrgOther;
import com.swt.meeting.impls.DetailInfoBarcodeController;

/**
 * @author TaiMai
 *
 * 
 */
@Path(MeetingDefines.DETAIL_INFO_MANAGER)
@Produces(MeetingDefines.APPLICATION_JSON)
public class SMeetingDetailInfoManager {
	// lay detail information bang barcode
	// datil information gom : meeting, OrganizationMeeting, List<Partaker>
	@GET
	@Path(MeetingDefines.GET_DETAIL_INFO_BY_BARCODE + "/{token}/{meetingbarcode}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getDetailInfoByBarcode(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("meetingbarcode") String meetingBarcode) {

		ResultObject result = new ResultObject(Status.FAILED);
//		boolean flag = TokenManager.getInstance().checkTokenSession(session, token);
		boolean flag = true;
		if (flag) {
			try {
				/**
				 * version 1
				 
				DetailInfo detailInfo = new DetailInfo();
				String temp = meetingBarcode.split("\r\n")[0];

				MeetingInvitation meetingInvitation = MeetingInvitationController.Instance
						.getMeetingInvitationByBarcode(temp);

				Meeting meeting = MeetingController.Instance.getMeetingById(meetingInvitation.getMeetingid());

				// Danh sach tat ca nhung nguoi tham du trong cuoc hop
				// them danh sach nguoi tham du cho nhung cuoc hop da co san
				Gson gson = new Gson();
				String listNonResident = meeting.getListNonResident();
				if (listNonResident == null || listNonResident.isEmpty() || "".equals(listNonResident)) {
					List<Partaker> sumPartaker = PartakerController.Instance.getPartakerByMeetingId(meeting.getId());
					meeting.setListNonResident(gson.toJson(sumPartaker));
				}

				detailInfo.setMeeting(meeting);

				// don vi duoc moi
				OrganizationMeeting organizationAttend = OrganizationMeetingController.Instance
						.getOrganizationMeetingById(meetingInvitation.getOrganizationAttendId());
				detailInfo.setOrganizationAttend(organizationAttend);

				// danh sach nguoi duoc moi trong barcode
				ArrayList<ListMeeting> list = (ArrayList<ListMeeting>) ListMeetingController.Instance
						.getListMeetingByMeetingInvitationId(meetingInvitation.getId(), organizationAttend.getId());
				List<Partaker> partakers = new ArrayList<>();
				for (ListMeeting listMeeting : list) {
					long partakerId = listMeeting.getPartakerId();
					Partaker partaker = PartakerController.Instance.getPartakerById(partakerId);
					partakers.add(partaker);
				}

				detailInfo.setPartakers(partakers);

				if (detailInfo.getMeeting() != null) {
					result.setStatus(Status.SUCCESS);
					result.setObj(detailInfo);
				} else {
					result.setStatus(Status.FAILED);
				}
				
				 * version 1
				 */
				
				//version 2
				String temp = meetingBarcode.split("\r\n")[0];
				DetailInfo detailInfo = DetailInfoBarcodeController.Instance.getDetailInfoPartakerAttend(temp);
				if (detailInfo != null) {
					result.setStatus(Status.SUCCESS);
					result.setObj(detailInfo);
				} else {
					result.setStatus(Status.FAILED);
				}
				//version 2
			} catch (Exception e) {
			}
		}
		return result;
	}
	// lay detail information bang barcode
	// datil information gom : meeting, OrganizationMeeting, List<Partaker>
	@GET
	@Path(MeetingDefines.GET_DETAIL_INFO_BY_BARCODE_ORG_OHTER + "/{token}/{meetingbarcode}")
	@Consumes(MediaType.APPLICATION_JSON)
	public ResultObject getDetailInfoByBarcodeOrgOther(@CookieParam("sessionid") String session,
			@PathParam("token") String token, @PathParam("meetingbarcode") String meetingBarcode) {
		
		ResultObject result = new ResultObject(Status.FAILED);
		boolean flag = true;
		if (flag) {
			try {
				String temp = meetingBarcode.split("\r\n")[0];
				DetailInfoOrgOther detailInfo = DetailInfoBarcodeController.Instance.getDetailInfoOrgOther(temp);
				if (detailInfo != null) {
					result.setStatus(Status.SUCCESS);
					result.setObj(detailInfo);
				} else {
					result.setStatus(Status.FAILED);
				}
			} catch (Exception e) {
			}
		}
		return result;
	}
}
