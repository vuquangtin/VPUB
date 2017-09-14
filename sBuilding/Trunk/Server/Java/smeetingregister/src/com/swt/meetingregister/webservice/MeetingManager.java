/**
 * 
 */
package com.swt.meetingregister.webservice;

import java.util.Date;
import java.util.List;

import javax.ws.rs.Consumes;
import javax.ws.rs.GET;
import javax.ws.rs.POST;
import javax.ws.rs.Path;
import javax.ws.rs.Produces;
import javax.ws.rs.core.MediaType;

import com.sworld.common.ResultObject;
import com.sworld.common.Status;
import com.swt.meetingregister.common.Define;
import com.swt.meetingregister.controller.CustomMeetingController;
import com.swt.meetingregister.customobject.ObjectMail;

/**
 * @author Tenit
 *
 */
@Path(Define.MEETING_REGISTER)
@Produces(Define.APPLICATION_JSON)
public class MeetingManager {
//	@GET
//	@Path(Define.GET_LIST_MEETING_BY_DATE)
//	@Consumes(MediaType.APPLICATION_JSON)
//	public ResultObject getListMeetingByDate(){
//		ResultObject result = new ResultObject(Status.FAILED);
//		Date paraDate = new Date();
//		
//		List<Meeting> account = MeetingController.Instance.getMeetingByDateTime(paraDate);
//
//		if (account != null) {
//			result.setStatus(Status.SUCCESS);
//		} else {
//			result.setStatus(Status.FAILED);
//		}
//		result.setObj(account);
//
//		return result;
//	}
//	
//	@GET
//	@Path(Define.GET_LIST_MEETING)
//	@Consumes(MediaType.APPLICATION_JSON)
//	public ResultObject getListMeetingByBarCode(){
//		ResultObject result = new ResultObject(Status.FAILED);
//		List<Meeting> lstMeeting = MeetingController.Instance.getListMeeting();
//		if (lstMeeting != null) {
//			result.setStatus(Status.SUCCESS);
//		} else {
//			result.setStatus(Status.FAILED);
//		}
//		result.setObj(lstMeeting);
//		return result;
//	}
//	@POST
//	@Path(Define.SEND_MAIL)
//	@Consumes(MediaType.APPLICATION_JSON)
//	public ResultObject sendMail(ObjectMail obj){
//		ResultObject result = new ResultObject(Status.FAILED);
//		int kq = CustomMeetingController.Instance.sendEmail(obj);
//		if (kq > 0) {
//			result.setStatus(Status.SUCCESS);
//		} else {
//			result.setStatus(Status.FAILED);
//		}
//		return result;
//	}
}
