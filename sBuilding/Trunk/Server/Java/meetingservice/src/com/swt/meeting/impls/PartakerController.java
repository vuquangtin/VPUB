/**
 * 
 */
package com.swt.meeting.impls;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.apache.commons.io.FilenameUtils;

import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.Image;
import com.itextpdf.text.PageSize;
import com.itextpdf.text.Phrase;
import com.itextpdf.text.Rectangle;
import com.itextpdf.text.pdf.BaseFont;
import com.itextpdf.text.pdf.ColumnText;
import com.itextpdf.text.pdf.PdfContentByte;
import com.itextpdf.text.pdf.PdfReader;
import com.itextpdf.text.pdf.PdfStamper;
import com.swt.meeting.domain.AttendMeeting;
import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.MeetingInvitation;
import com.swt.meeting.domain.OrganizationMeeting;
import com.swt.meeting.domain.Partaker;
import com.swt.meeting.lib.tm.Constant;

import util.GenQRCode;

/**
 * @author TaiMai
 *
 * 
 */
public class PartakerController {
	/**
	 * Instance of PartakerController
	 */
	public static final PartakerController Instance = new PartakerController();
	// public static String PATH_SAVE = "/usr/tomcat-sworld/imagebarcode/";
	// public static String PATH_SAVE = "/";
	private PartakerDAO rDAO = new PartakerDAO();

	public String getPathImage() {
		// String PATH_SAVE = "/";
		String PATH_SAVE = System.getProperty("catalina.home");
		File file = new File(PATH_SAVE + "/imagebarcode/");
		if (!file.exists()) {
			file.mkdirs();
		}

		System.out.println(file.getPath());
		return file.getPath();
	}

	public String getPathPDFFile() {
		// String PATH_SAVE = "/";
		String PATH_SAVE = System.getProperty("catalina.home");
		File file = new File(PATH_SAVE + "/lettertemplate/");
		if (!file.exists()) {
			file.mkdirs();
		}

		System.out.println(file.getPath());
		return file.getPath();
	}

	/**
	 * insert Partaker
	 * 
	 * @param Partaker
	 * @return Partaker
	 * @throws Exception
	 */
	public Partaker insert(Partaker partaker, long meetingId) throws Exception {
		saveImage(partaker.getBarcode());
		Meeting meeting = MeetingController.Instance.getMeetingById(meetingId);
		OrganizationMeeting orgMeeting = OrganizationMeetingController.Instance
				.getOrganizationMeetingById(partaker.getOrgId());
		if (orgMeeting != null) {
			partaker.setOrgname(orgMeeting.getName());
		}
		//check if exist letter was create from NSS
		if (!createLetterExit(partaker.getBarcode(), meeting)) {
			createLetter(partaker.getBarcode(), meeting);
		}
		if (meeting != null) {
			meeting.setNumber(meeting.getNumber() + 1);
			MeetingController.Instance.update(meeting);
		}
		partaker = rDAO.insert(partaker);
		// 24/04/2017 them attendmeeting de thong ke
		AttendMeeting attendMeeting = new AttendMeeting();

		SimpleDateFormat sdf = new SimpleDateFormat(Constant.FORMAT_DATE_DEFAULT);
		attendMeeting.setInputTime(sdf.parse(Constant.DATE_DEFAULT));
		attendMeeting.setOutputTime(sdf.parse(Constant.DATE_DEFAULT));

		attendMeeting.setInvited(true);
		attendMeeting.setMeetingBarcode(partaker.getBarcode());
		attendMeeting.setMeetingId(meeting.getId());
		attendMeeting.setMeetingName(meeting.getName());
		attendMeeting.setNote(meeting.getNote());

		attendMeeting.setOrganizationAttendId(partaker.getOrgId());
		attendMeeting.setOrganizationAttendName(partaker.getOrgname());

		attendMeeting.setOrganizationMeetingId(meeting.getOrganizationMeetingId());
		attendMeeting.setOrganizationMeetingName(meeting.getOrganizationMeetingName());

		attendMeeting.setPartakerId(partaker.getId());
		attendMeeting.setPartakerName(partaker.getName());
		attendMeeting.setPersonNotBarcodeId(0);
		attendMeeting.setStatus(false);

		AttendMeetingController.Instance.insert(attendMeeting);

		return partaker;
	}

	/**
	 * update Partaker
	 * 
	 * @param Partaker
	 * @return Partaker
	 */
	public Partaker update(Partaker partaker) {
		return rDAO.update(partaker);
	}

	/**
	 * delete Partaker
	 * 
	 * @param PartakerId
	 * @return int
	 */
	public int delete(long partakerId, long meetingId) {
		Meeting meeting = MeetingController.Instance.getMeetingById(meetingId);
		if (meeting != null) {
			meeting.setNumber(meeting.getNumber() - 1);
			MeetingController.Instance.update(meeting);
		}
		// 24/04/2017 xoa attendmeeting de thong ke
		AttendMeetingController.Instance.deleteByPartakerId(partakerId);
		return rDAO.delete(partakerId);
	}

	/**
	 * getPartakerById
	 * 
	 * @param PartakerId
	 * @return Partaker
	 */
	public Partaker getPartakerById(long partakerId) {
		return rDAO.getPartakerById(partakerId);
	}

	/**
	 * getAllPartaker
	 * 
	 * @param
	 * @return List<Partaker>
	 */
	public List<Partaker> getAllPartaker() {
		return rDAO.getAllPartaker();
	}

	/**
	 * 24/12/2016 lay danh sach nguoi tham du cua cuoc hop da duoc moi truoc
	 * 
	 * @return
	 */
	public List<Partaker> getPartakerByMeetingId(long meetingId) {
		return rDAO.getPartakerByMeetingId(meetingId);
	}

	public List<Partaker> getPartakerByOrgPartakerId(long orgPartakerId) {
		return rDAO.getPartakerByOrgPartakerId(orgPartakerId);
	}

	public List<Partaker> getPartakerRegisterByMeetingId(long meetingId) {
		List<Partaker> lstPartaker = new ArrayList<Partaker>();
		List<MeetingInvitation> lstInvite = MeetingInvitationController.Instance.getInvitationByMeetingId(meetingId);
		if (lstInvite != null) {
			for (MeetingInvitation obj : lstInvite) {
				Partaker partaker = getPartakerByBarcode(obj.getMeetingBarCode());
				if (partaker != null) {
					lstPartaker.add(partaker);
				}
			}
		}
		return lstPartaker;
	}

	/**
	 * Get list partaker by barcode
	 * 
	 * @param orgPartakerId
	 * @return
	 */
	public Partaker getPartakerByBarcode(String barcode) {
		return rDAO.getPartakerByBarcode(barcode);
	}

	/**
	 * Create image QR code
	 * 
	 * @param barcode
	 * @return
	 * @throws Exception
	 */
	public String saveImage(String barcode) throws Exception {
		// String path = PATH_SAVE + barcode + ".png";
		String path = getPathImage() + "/" + barcode + ".png";
		// size image 68x68
		int size = 68;
		GenQRCode.genQRCode(barcode, path, size);
		System.out.println("Done");
		return path;
	}

	/**
	 * Create pdf file to send mail
	 * 
	 * @param QRCode QRcode for every partaker
	 * @param meeting
	 */
	private void createLetter(String QRCode, Meeting meeting) {
		try {
			System.out.println("function create letter");
			// String PATH_SAVE = System.getProperty("catalina.home");
			String PATH_SAVE = getPathPDFFile();
			File file = new File(PATH_SAVE);
			//font vietnam
			File fontFile = new File(file + "/vuTimes.ttf");
			//template pdf file
			PdfReader pdfReader = new PdfReader(file + "/thumoihop.pdf");
			System.out.println("Font file" + fontFile.getAbsolutePath());

			//file output
			PdfStamper pdfStamper = new PdfStamper(pdfReader, new FileOutputStream(file + "/" + QRCode + ".pdf"));
			String path = getPathImage() + "/" + QRCode + ".png";
			Image image = Image.getInstance(path);
			System.out.println("path image barcode");
			System.out.println(file.getAbsolutePath());

			// put content under+
			PdfContentByte content = pdfStamper.getUnderContent(1);
			Rectangle rc = PageSize.A4;
			float width = rc.getWidth();
			float height = rc.getHeight();
			System.out.println(width);
			System.out.println(height);
			// put content over
			content = pdfStamper.getOverContent(1);
			image.setAbsolutePosition((width / 2) - 220, (height / 2) - 40);
			content.addImage(image);
			// Text over the existing page
			BaseFont bf = BaseFont.createFont(fontFile.getAbsolutePath(), BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
			content.beginText();
			content.setFontAndSize(bf, 15);
			Font helvetica8BoldBlue = new Font(bf, 15);
			// create a column object
			ColumnText ct = new ColumnText(content);
			ColumnText ct1 = new ColumnText(content);
			ColumnText ct2 = new ColumnText(content);
			// define the text to print in the column
			Date date = meeting.getStartTime();
			DateFormat df = new SimpleDateFormat("MM/dd/yyyy HH:mm:ss");
			String reportDate = df.format(date);
			Phrase myText = new Phrase(meeting.getName(), helvetica8BoldBlue);
			Phrase IDMeeting = new Phrase(meeting.getMeetingInvitationName(), helvetica8BoldBlue);
			Phrase time = new Phrase(reportDate, helvetica8BoldBlue);
			ct.setSimpleColumn(myText, (width / 2) - 175, (height / 2) + 240, (height - 290), 0, 20,
					Element.ALIGN_LEFT);
			ct1.setSimpleColumn(IDMeeting, (width / 2) - 175, (height / 2) + 272, (height - 290), 0, 20,
					Element.ALIGN_LEFT);
			ct2.setSimpleColumn(time, (width / 2) - 175, (height / 2) + 257, (height - 290), 0, 20, Element.ALIGN_LEFT);
			ct.go();
			ct1.go();
			ct2.go();
			content.endText();
			System.out.println("Done createLetter");

			pdfStamper.close();

		} catch (IOException e) {
			e.printStackTrace();
		} catch (DocumentException e) {
			e.printStackTrace();
		}

	}
/**
 * Add pdf file from template pdf of NSS
 * @param QRCode
 * @param meeting
 * @return
 */
	private boolean createLetterExit(String QRCode, Meeting meeting) {
		try {
			System.out.println("function create letter exit");
			// String PATH_SAVE = System.getProperty("catalina.home");
			String PATH_SAVE = getPathPDFFile();
			List<File> listFile = MeetingInvitationLCTController.Instance.getPathFiles(meeting.getMeetingCode(),
					meeting.getStartTime());
			if(null == listFile){
				System.out.println("no file attach");
				return false;
			}
			for (File file : listFile) {
				if (FilenameUtils.isExtension(file.getName(), "pdf")) {
					File fontFile = new File(file + "/vuTimes.ttf");
					PdfReader pdfReader = new PdfReader(file.toString());
					System.out.println("Font file" + fontFile.getAbsolutePath());

					PdfStamper pdfStamper = new PdfStamper(pdfReader,
							new FileOutputStream(PATH_SAVE + "/" + QRCode + ".pdf"));
					String path = getPathImage() + "/" + QRCode + ".png";
					Image image = Image.getInstance(path);
					System.out.println("path image barcode");
					System.out.println(file.getAbsolutePath());

					// put content under+
					PdfContentByte content = pdfStamper.getUnderContent(1);
					// image.setAbsolutePosition(100f, 150f);
					// content.addImage(image);
					Rectangle rc = PageSize.A4;
					float width = rc.getWidth();
					float height = rc.getHeight();
					System.out.println(width);
					System.out.println(height);
					// put content over
					content = pdfStamper.getOverContent(1);
					image.setAbsolutePosition(1, height - 65);
					content.addImage(image);

					// Text over the existing page
					BaseFont bf = BaseFont.createFont(BaseFont.HELVETICA, BaseFont.WINANSI, BaseFont.EMBEDDED);
					content.beginText();
					content.setFontAndSize(bf, 18);
					content.endText();
					System.out.println("Done createLetterExit");

					pdfStamper.close();
					return true;

				}
			}
		} catch (IOException e) {
			e.printStackTrace();
		} catch (DocumentException e) {
			e.printStackTrace();
		}
		return false;
	}
}
