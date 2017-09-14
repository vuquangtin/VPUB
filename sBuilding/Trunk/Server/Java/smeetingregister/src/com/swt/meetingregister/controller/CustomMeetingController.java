/**
 * 
 */
package com.swt.meetingregister.controller;

/**
 * @author Tenit
 *
 */
public class CustomMeetingController {

//	public static final CustomMeetingController Instance = new CustomMeetingController();
////	public static String PATH_SAVE = "/usr/tomcat-sworld/imagebarcode/";
//	public static String PATH_SAVE = "/";
//	public OrgPartaker insertOrgPartaker(OrgPartaker orgPartaker) {
//		// insert orgmeeting
//		OrgPartaker orgPartakerObj = new OrgPartaker();
//		OrganizationMeeting organizationMeeting = new OrganizationMeeting();
//		organizationMeeting.setName(orgPartaker.getName());
//		organizationMeeting.setMeeting(false);
//		OrganizationMeeting result = insertOrgMeeting(organizationMeeting);
//		if (null != result) {
//			//insert bang invite
//			MeetingInvitation meetingInvitation = new MeetingInvitation();
//			String barcode = RandomStringUtils.randomNumeric(13);
//			meetingInvitation.setMeetingBarCode(barcode);
//			meetingInvitation.setMeetingId(orgPartaker.getMeetingId());
//			meetingInvitation.setOrganizationAttendId(result.getId());
//			MeetingInvitation meetingInvitationResult = MeetingInvitationController.Instance.insert(meetingInvitation);
//			if (meetingInvitationResult != null) {
//				orgPartakerObj.setMeeting(result.isMeeting());
//				orgPartakerObj.setBarcode(barcode);
//				orgPartakerObj.setMeetingId(meetingInvitationResult.getId());
//				orgPartakerObj.setName(result.getName());
//				orgPartakerObj.setOrgattendId(result.getId());
//			}
//		}
//		return orgPartakerObj;
//	}
//	private OrganizationMeeting insertOrgMeeting(OrganizationMeeting organizationMeeting) {
//		return OrganizationMeetingController.Instance.insert(organizationMeeting);
//	}
//	public String saveImage(String barcode) throws FileNotFoundException, DocumentException, URISyntaxException {
//		Document document = new Document();
//		String path = PATH_SAVE + barcode + ".pdf";
//		File file = new File(path);
//		System.out.println(file.getAbsolutePath());
//		PdfWriter writer = PdfWriter.getInstance(document, new FileOutputStream(file));
//		document.open();
//		PdfContentByte cb = writer.getDirectContent();
//		BarcodeEAN codeEAN = new BarcodeEAN();
//		codeEAN.setCodeType(Barcode.EAN13);
//		codeEAN.setCode(barcode);
//		Image imageEAN = codeEAN.createImageWithBarcode(cb, null, null);
//		imageEAN.scaleToFit(250, 700);
//		document.add(imageEAN);
//		document.close();
//
//		return path;
//	}
//
//	public int sendEmail(ObjectMail obj) {
//		// ObjectMail objectMail = readAppConfig();
//		List<Partaker> lstPartaker = PartakerController.Instance.getPartakerByOrgPartakerId(obj.getOrgPartaker());
//		if (null != lstPartaker) {
//			for (Partaker objSend : lstPartaker) {
//				sendEmailPartaker(objSend, obj);
//			}
//		}
//		return 0;
//	}
//
//	private void sendEmailPartaker(Partaker partaker, ObjectMail obj) {
//		EmailConfig emailConfig = RegisterAccountController.Instance.getEmailConfig();
//		if (emailConfig != null && !partaker.getIsSenmail()) {
//			final String email = emailConfig.getEmail();
//			final String password = emailConfig.getPassWord();
//			
//			Properties props = new Properties();
//			props.put("mail.smtp.host", "smtp.gmail.com");
//			props.put("mail.smtp.socketFactory.port", "465");
//			props.put("mail.smtp.socketFactory.class", "javax.net.ssl.SSLSocketFactory");
//			props.put("mail.smtp.auth", "true");
//			props.put("mail.smtp.port", "465");
//
//			Session session = Session.getInstance(props, new javax.mail.Authenticator() {
//				protected PasswordAuthentication getPasswordAuthentication() {
//					return new PasswordAuthentication(email, password);
//				}
//			});
//
//			try {
//				Message message = new MimeMessage(session);
//				message.setFrom(new InternetAddress(email));
//				message.setRecipients(Message.RecipientType.TO, InternetAddress.parse(partaker.getEmail()));
//				message.setSubject(obj.getSubject());
//				message.setText (obj.getContent());
//				message.setHeader("Content-Type", "multipart/mixed;charset=UTF-8");
//
//				BodyPart messageBodyPart = new MimeBodyPart();
//
//				// Now set the actual message
//				messageBodyPart.setText(obj.getContent());
//
//				// Create a multipar message
//				Multipart multipart = new MimeMultipart();
//
//				// Set text message part
//				multipart.addBodyPart(messageBodyPart);
//				String fileAttachment = PATH_SAVE + partaker.getBarcode() + ".pdf";
//				System.out.println(fileAttachment);
//				File file = new File(fileAttachment);
//				file.getAbsolutePath();
//				// Part two is attachment
//				messageBodyPart = new MimeBodyPart();
//				DataSource source = new FileDataSource(fileAttachment);
//				messageBodyPart.setDataHandler(new DataHandler(source));
//				messageBodyPart.setFileName(partaker.getBarcode() + ".pdf");
//				multipart.addBodyPart(messageBodyPart);
//
//				// Send the complete message parts
//				message.setContent(multipart);
//				Transport.send(message);
//				partaker.setIsSenmail(true);
//				PartakerController.Instance.update(partaker);
//				file.delete();
//				System.out.println("Done");
//
//			} catch (MessagingException e) {
//				throw new RuntimeException(e);
//			}
//		}
//	}
//	public void sendMailDelete(long partakerId){
//		Partaker partaker = PartakerController.Instance.getPartakerById(partakerId);
//		EmailConfig emailConfig = RegisterAccountController.Instance.getEmailConfig();
//		if (emailConfig != null && partaker!=null) {
//			final String email = emailConfig.getEmail();
//			final String password = emailConfig.getPassWord();
//			
//			Properties props = new Properties();
//			props.put("mail.smtp.host", "smtp.gmail.com");
//			props.put("mail.smtp.socketFactory.port", "465");
//			props.put("mail.smtp.socketFactory.class", "javax.net.ssl.SSLSocketFactory");
//			props.put("mail.smtp.auth", "true");
//			props.put("mail.smtp.port", "465");
//
//			Session session = Session.getInstance(props, new javax.mail.Authenticator() {
//				protected PasswordAuthentication getPasswordAuthentication() {
//					return new PasswordAuthentication(email, password);
//				}
//			});
//
//			try {
//				Message message = new MimeMessage(session);
//				message.setFrom(new InternetAddress(email));
//				message.setRecipients(Message.RecipientType.TO, InternetAddress.parse(partaker.getEmail()));
//				message.setSubject("Hủy cuộc hop");
//				message.setText("Bạn đã bị xóa khỏi cuộc họp");
//				message.setHeader("Content-Type", "multipart/mixed");
//
//				message.setContent(emailConfig.getUser(),"Bạn đã bị xóa khỏi cuộc họp này");
//				Transport.send(message);
//				partaker.setIsSenmail(true);
//				PartakerController.Instance.update(partaker);
//				System.out.println("Done");
//
//			} catch (MessagingException e) {
//				throw new RuntimeException(e);
//			}
//		}
//	}
}
