package com.swt.meeting.impls;

import java.io.File;
import java.io.UnsupportedEncodingException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.List;
import java.util.Properties;

import javax.activation.DataHandler;
import javax.activation.DataSource;
import javax.activation.FileDataSource;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Multipart;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeBodyPart;
import javax.mail.internet.MimeMessage;
import javax.mail.internet.MimeMultipart;
import javax.mail.internet.MimeUtility;

import com.swt.meeting.customObject.MeetingObjManager;
import com.swt.meeting.customObject.ObjectMail;
import com.swt.meeting.domain.EmailConfig;
import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.Partaker;

/**
 * MeetingController
 * 
 * @author TaiMai
 * 
 */
public class MeetingController {
	/**
	 * Instance of MeetingController
	 */
	public static final MeetingController Instance = new MeetingController();

	private MeetingDAO mDAO = new MeetingDAO();
	//path of pdf not edit
	public String PATH_SAVE = PartakerController.Instance.getPathPDFFile();

	// public static String PATH_SAVE = "/";

	//
	/**
	 * insert Meeting
	 * 
	 * @param meeting
	 * @return Meeting
	 */
	public Meeting insert(Meeting meeting) {
		return mDAO.insert(meeting);
	}

	/**
	 * update Meeting
	 * 
	 * @param meeting
	 * @return Meeting
	 */
	public Meeting update(Meeting meeting) {
		return mDAO.update(meeting);
	}

	/**
	 * delete Meeting
	 * 
	 * @param meetingId
	 * @return int
	 */
	public int delete(long meetingId) {
		return mDAO.delete(meetingId);
	}

	/**
	 * getMeetingById
	 * 
	 * @param meetingId
	 * @return Meeting
	 */
	public Meeting getMeetingById(long meetingId) {
		return mDAO.getMeetingById(meetingId);
	}

	/**
	 * Getmeetingbymeetingcode
	 * 
	 * @param meetingcode
	 * @return
	 */
	public List<Meeting> getMeetingByMeetingCode(long meetingcode) {
		return mDAO.getMeetingByMeetingCode(meetingcode);
	}

	/**
	 * @author my.nguyen getMeetingByDate
	 * 
	 * @param meetingDate
	 * @return List<Meeting>
	 */
	public List<Meeting> getMeetingByDateTime(Date meetingDate) {
		return mDAO.getMeetingByDateTime(meetingDate);
	}

	// sua doi cuoc hop theo neocoreId
	public int edit(Meeting meeting) {
		return mDAO.edit(meeting);
	}

	// sua lai tinh trang khi ben kia xoa cuoc hop theo neocoreId
	public int updateNeocoreStatus(long neocoreId) {
		return mDAO.updateNeocoreStatus(neocoreId);
	}

	public List<Meeting> getListMeeting() {
		return mDAO.getListMeeting();
	}

	// start giong service ben snonresident
	/**
	 * 30/11/2016 lay danh sach cuoc hop tu ngay den ngay va ten to chuc cuoc
	 * hop va ten cuoc hop
	 * 
	 * @param start
	 * @param end
	 * @param fromTime
	 * @param toTime
	 * @param organizationMeetingId
	 * @param meetingName
	 */
	public MeetingObjManager getMeetingByDateAndOrgIdAndMeetingName(int start, int limit, Date fromDate, Date toDate,
			long organizationMeetingId, String meetingName) {
		return mDAO.getMeetingByDateAndOrgIdAndMeetingName(start, limit, fromDate, toDate, organizationMeetingId,
				meetingName);
	}

	/**
	 * 13/12/2016 tong so cuoc hop tu ngay den ngay va ten to chuc cuoc hop va
	 * ten cuoc hop
	 * 
	 * @param start
	 * @param end
	 * @param fromTime
	 * @param toTime
	 * @param organizationMeetingId
	 * @param meetingName
	 */
	public long sumMeetingByDateAndOrgIdAndMeetingName(Date fromDate, Date toDate, long organizationMeetingId,
			String meetingName) {
		return mDAO.sumMeetingByDateAndOrgIdAndMeetingName(fromDate, toDate, organizationMeetingId, meetingName);
	}

	// tang so luong nguoi vao tuy theo loai
	public void increasePersonAttend(long meetingId, int personAttendType) {
		mDAO.increasePersonAttend(meetingId, personAttendType);
	}

	// -----------------------
	// end giong service ben snonresident
	public int sendEmail(ObjectMail obj) throws UnsupportedEncodingException {
		// ObjectMail objectMail = readAppConfig();
		List<Partaker> lstPartaker = MeetingInvitationController.Instance
				.getInvitationByOrgAndMeetingId(obj.getOrgPartaker(), obj.getMeetingId());
		Meeting meeting = MeetingController.Instance.getMeetingById(obj.getMeetingId());
		if (null != lstPartaker && meeting != null) {
			for (Partaker objSend : lstPartaker) {
				sendEmailPartaker(objSend, obj, meeting);
			}
		}
		return 0;
	}

	/**
	 * Send email for every partaker
	 * 
	 * @param partaker
	 * @param obj
	 * @param meeting
	 * @throws UnsupportedEncodingException
	 */
	private void sendEmailPartaker(Partaker partaker, ObjectMail obj, Meeting meeting)
			throws UnsupportedEncodingException {
		EmailConfig emailConfig = getEmailConfig();
		String emailStr = emailConfig.getEmail();
		String[] nameEmail = emailStr.split("@");
		if (emailConfig != null) {
			final String email = nameEmail[0];
			final String password = emailConfig.getPassWord();

			Properties props = new Properties();
			props.put("mail.smtp.host", emailConfig.getSmtp());
			props.put("mail.smtp.auth", "true");
			props.put("mail.smtp.port", emailConfig.getPort());

			Session session = Session.getDefaultInstance(props, new javax.mail.Authenticator() {
				protected PasswordAuthentication getPasswordAuthentication() {
					return new PasswordAuthentication(email, password);
				}
			});

			try {
				//
				//// System.out.println("Done");
				MimeMessage message = new MimeMessage(session);
				message.setFrom(new InternetAddress(emailConfig.getEmail(), emailConfig.getUser(), "utf-8"));
				message.setRecipients(Message.RecipientType.TO, InternetAddress.parse(partaker.getEmail()));
				message.setSubject(MimeUtility.encodeText(emailConfig.getTitle(), "UTF-8", "Q"), "utf-8");
				message.setHeader("Content-Type", "multipart/mixed;charset=UTF-8");
				MimeBodyPart messageBodyPart = new MimeBodyPart();
				String strContent = emailConfig.getContent();
				Date date = meeting.getStartTime();
				DateFormat df = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");
				String reportDate = df.format(date);

				strContent = strContent.replace("#name#", meeting.getName());
				strContent = strContent.replace("#time#", reportDate);
				strContent = strContent.replace("#number#", meeting.getMeetingCode() + "");
				messageBodyPart.setHeader("Content-Type", "multipart/mixed;charset=UTF-8");
				messageBodyPart.setText(strContent, "UTF-8");
				// Create a multipar message
				Multipart multipart = new MimeMultipart();

				// Set text message part
				multipart.addBodyPart(messageBodyPart);

				String fileAttachment = PATH_SAVE + "/" + partaker.getBarcode() + ".pdf";
				File file = new File(fileAttachment);
				if (file.exists()) {
					file.getAbsolutePath();
					// Part two is attachment
					messageBodyPart = new MimeBodyPart();
					DataSource source = new FileDataSource(fileAttachment);
					messageBodyPart.setDataHandler(new DataHandler(source));
					messageBodyPart.setFileName(partaker.getBarcode() + ".pdf");
					multipart.addBodyPart(messageBodyPart);

					// Send the complete message parts
					message.setContent(multipart);
					Transport.send(message);
					// partaker.setIsSenmail(true);
					// PartakerController.Instance.update(partaker);
					// file.delete();
					System.out.println("Done");
				}
			} catch (MessagingException e) {
				throw new RuntimeException(e);
			}
		}
	}

	/**
	 * Get email config from database
	 * 
	 * @return
	 */
	public EmailConfig getEmailConfig() {
		return mDAO.getEmailConfig();
	}

	/**
	 * Insert email config to database
	 * 
	 * @param emailConfig
	 * @return
	 */
	public EmailConfig insertEmailConfig(EmailConfig emailConfig) {
		try {
			return mDAO.insertEmailConfig(emailConfig);
		} catch (Exception e) {
			return null;
		}
	}

	
	/**
	 * get meeting by meetingCode and status = true
	 * @param meetingcode
	 * @return
	 */
	public Meeting getMeetingByMeetingCodeActive(long meetingcode){
		return mDAO.getMeetingByMeetingCodeActive(meetingcode);
	}
}
