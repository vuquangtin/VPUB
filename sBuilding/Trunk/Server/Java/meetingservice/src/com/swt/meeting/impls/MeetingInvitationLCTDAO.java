package com.swt.meeting.impls;

import java.io.File;
import java.io.IOException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Date;
import java.util.List;

import org.apache.commons.io.FileUtils;
import org.apache.tomcat.util.codec.binary.Base64;

import com.nhn.utilities.HibernateUtil;
import com.swt.meeting.IMeetingInvitationLCT;
import com.swt.meeting.customObject.FileLCT;
import com.swt.meeting.customObject.MeetingInvitationLCT;
import com.swt.meeting.customObject.PartakerLCT;
import com.swt.meeting.domain.KeyOrgMeeting;
import com.swt.meeting.domain.Meeting;
import com.swt.meeting.domain.MeetingInvitation;
import com.swt.meeting.domain.OrganizationMeeting;
import com.swt.meeting.domain.Partaker;
import com.swt.meeting.domain.Room;
import com.swt.meeting.lib.tm.CommonFunction;
import com.swt.meeting.lib.tm.Constant;

public class MeetingInvitationLCTDAO implements IMeetingInvitationLCT {
	private static final String PATH_SAVE_FILE_LCT = "/file_lct";
	private static final String DATE_FORMAT = "yyyy/MM";

	@Override
	@SuppressWarnings("unchecked")
	public MeetingInvitationLCT add(MeetingInvitationLCT meetingInvitationLCT) {
		// kiem tra thu moi da ton tai trong he thong chua
		Meeting meeting = MeetingController.Instance.getMeetingByMeetingCodeActive(meetingInvitationLCT.getMeetingInvitationId());
		if (meeting != null) {
			return null;
		}
		String sql = "";
		// them cuoc hop
		meeting = new Meeting();
		// set ma thu moi
		meeting.setMeetingCode(meetingInvitationLCT.getMeetingInvitationId());
		meeting.setMeetingInvitationName(meetingInvitationLCT.getMeetingInvitationName());
		meeting.setMeetingCodeStatus(true);

		// set don vi to chuc cuoc hop. (set cung la don vi to chuc la VPUB)
		OrganizationMeeting organizationMeeting = OrganizationMeetingController.Instance
				.getOrganizationMeetingById(Constant.ID_ORG_VPUB);

		meeting.setOrganizationMeetingId(organizationMeeting.getId());
		meeting.setOrganizationMeetingName(organizationMeeting.getName());

		meeting.setName(meetingInvitationLCT.getMeetingName());

		// ben kia khong gui phong hop, nen kiem tra null
		// kiem tra phong hop da ton tai trong he thong chua?
		if (!(meetingInvitationLCT.getRoomId() == -1 || meetingInvitationLCT.getRoomName().isEmpty()
				|| "".equals(meetingInvitationLCT.getRoomName()))) {
			Room roomCheck = RoomController.Instance.getRoomByName(meetingInvitationLCT.getRoomName());

			if (roomCheck != null) {
				meeting.setRoomId(roomCheck.getId());
				meeting.setRoomName(roomCheck.getName());
			} else {
				// neu phong chua co thi them moi vao he thong
				Room roomNew = new Room();
				roomNew.setName(meetingInvitationLCT.getRoomName());
				roomNew.setReferenceId(meetingInvitationLCT.getRoomId());
				roomNew = RoomController.Instance.insert(roomNew);

				meeting.setRoomId(roomNew.getId());
				meeting.setRoomName(roomNew.getName());
			}

		} else {
			meeting.setRoomId(0);
			meeting.setRoomName("");
		}

		List<PartakerLCT> partakerLCTs = meetingInvitationLCT.getListPartaker();
		// set so luong to chuc
		meeting.setNumber(0); // set bang khong de khi nao co nguoi dang ky thi
								// tang them
		// them thoi gian cho cuoc hop
		meeting.setStartTime(meetingInvitationLCT.getStartTime());
		meeting.setEndTime(meetingInvitationLCT.getEndTime());
		meeting.setDescription(meetingInvitationLCT.getDescription());
		meeting = MeetingController.Instance.insert(meeting);

		// startTime
		Date startTime = meeting.getStartTime();

		for (PartakerLCT partakerLCT : partakerLCTs) {
			try {

				// lay thong tin nguoi trong thu moi
				long orgIdLCT = partakerLCT.getOrgId();
				String orgNameLCT = partakerLCT.getOrgName();
				String orgCode = partakerLCT.getOrgCode();

				String key = partakerLCT.getKey();

				// neu org id = -1 => them to chuc moi vao he thong
				OrganizationMeeting orgAttendMeeting = null;
				if (orgIdLCT == -1) {
					if (!(orgNameLCT.isEmpty() || "".equals(orgNameLCT))) {
						// kiem tra theo ten
						List<OrganizationMeeting> listOrg = OrganizationMeetingController.Instance.getByName(orgNameLCT,
								Constant.ORG_OTHER);
						if (listOrg.size() > 0) {
							// neu nhieu gia tri => lay gia tri dau tien
							orgAttendMeeting = listOrg.get(0);
						} else {
							// khong co => them org vao he thong smeeting
							OrganizationMeeting organizationMeetingNew = new OrganizationMeeting();
							organizationMeetingNew.setName(orgNameLCT);
							organizationMeetingNew.setReferenceId(orgIdLCT);
							organizationMeetingNew.setCode(orgCode);
							organizationMeetingNew.setTypeOrg(Constant.ORG_OTHER);
							orgAttendMeeting = OrganizationMeetingController.Instance.insert(organizationMeetingNew);
						}
					} else {
						CommonFunction.INSTANCE.setTable(new OrganizationMeeting());
						orgAttendMeeting = (OrganizationMeeting) CommonFunction.INSTANCE.getById(0);
					}
				} else {

					// neu orgid != 1 => kiem tra to chuc da co trong he thong
					// hay
					// chua
					sql = "FROM OrganizationMeeting " + " WHERE referenceId =" + orgIdLCT + " AND meeting = "
							+ Constant.ORG_OTHER;
					List<OrganizationMeeting> organizationMeetingCheck = (List<OrganizationMeeting>) CommonFunction.INSTANCE
							.getByQuery(sql);
					// kiem tra to chuc da co trong he thong chua
					if (organizationMeetingCheck.size() == 0) {
						OrganizationMeeting organizationMeetingNew = new OrganizationMeeting();
						organizationMeetingNew.setName(orgNameLCT);
						organizationMeetingNew.setReferenceId(orgIdLCT);
						organizationMeetingNew.setCode(orgCode);
						organizationMeetingNew.setTypeOrg(Constant.ORG_OTHER);
						orgAttendMeeting = OrganizationMeetingController.Instance.insert(organizationMeetingNew);
					} else {
						orgAttendMeeting = organizationMeetingCheck.get(0);
					}
				}

				// them key
				long partakerId = 0;
				KeyOrgMeeting keyOrgMeeting = new KeyOrgMeeting();
				keyOrgMeeting.setMeetingId(meeting.getId());
				keyOrgMeeting.setOrgAttendId(orgAttendMeeting.getId());
				keyOrgMeeting.setKey(key);
				keyOrgMeeting.setPartakerId(partakerId);// moi to chuc =>
				// partakerId
				// = 0
				HibernateUtil.insertObject(keyOrgMeeting);
			} catch (Exception e) {
				System.out.println(e.getMessage() + "----------------------");
			}
		}

		// save file
		List<FileLCT> listFileLCT = meetingInvitationLCT.getListFile();
		if (listFileLCT != null) {
			for (FileLCT fileLCT : listFileLCT) {
				saveFile(meetingInvitationLCT.getMeetingInvitationId(), startTime, fileLCT);
			}
		}
		return meetingInvitationLCT;
	}

	@Override
	@SuppressWarnings("unchecked")
	public MeetingInvitationLCT edit(MeetingInvitationLCT meetingInvitationLCT) {
		// hien tai chi cho pheo sua cuoc hop
		Meeting meeting = MeetingController.Instance
				.getMeetingByMeetingCodeActive(meetingInvitationLCT.getMeetingInvitationId());
		if (meeting == null) {
			return null;
		}

		// old start date
		Date startTime = meeting.getStartTime();

		meeting.setName(meetingInvitationLCT.getMeetingName());
		meeting.setDescription(meetingInvitationLCT.getDescription());
		meeting.setStartTime(meetingInvitationLCT.getStartTime());
		meeting.setEndTime(meetingInvitationLCT.getEndTime());

		meeting.setMeetingInvitationName(meetingInvitationLCT.getMeetingInvitationName());
		// ben kia khong gui phong hop, nen kiem tra null
		// kiem tra phong hop da ton tai trong he thong chua?
		if (!(meetingInvitationLCT.getRoomId() == -1 || meetingInvitationLCT.getRoomName().isEmpty()
				|| "".equals(meetingInvitationLCT.getRoomName()))) {
			Room roomCheck = RoomController.Instance.getRoomByName(meetingInvitationLCT.getRoomName());

			if (roomCheck != null) {
				meeting.setRoomId(roomCheck.getId());
				meeting.setRoomName(roomCheck.getName());
			} else {
				// neu phong chua co thi them moi vao he thong
				Room roomNew = new Room();
				roomNew.setName(meetingInvitationLCT.getRoomName());
				roomNew.setReferenceId(meetingInvitationLCT.getRoomId());
				roomNew = RoomController.Instance.insert(roomNew);

				meeting.setRoomId(roomNew.getId());
				meeting.setRoomName(roomNew.getName());
			}

		} else {
			meeting.setRoomId(0);
			meeting.setRoomName("");
		}

		// xoa nhung key ko con trong danh sach moi

		String sql = "FROM KeyOrgMeeting WHERE meetingId = '" + meeting.getId() + "'";
		List<KeyOrgMeeting> oldKeys = (List<KeyOrgMeeting>) CommonFunction.INSTANCE.getByQuery(sql);
		KeyOrgMeeting keyDelete = null;
		boolean isDelete = true;
		CommonFunction.INSTANCE.setTable(new KeyOrgMeeting());
		for (KeyOrgMeeting keyOrgMeeting : oldKeys) {
			for (PartakerLCT partakerLCT : meetingInvitationLCT.getListPartaker()) {
				keyDelete = keyOrgMeeting;
				if (keyOrgMeeting.getKey().equals(partakerLCT.getKey())) {
					isDelete = false;
					break;
				}
			}
			if (isDelete) {
				CommonFunction.INSTANCE.delete(keyDelete.getId());

				// xoa nhung nguoi da duoc dang ky bang key nay
				sql = "FROM MeetingInvitation " + " WHERE meetingId = " + keyDelete.getMeetingId()
						+ " AND organizationAttendId = " + keyDelete.getOrgAttendId();
				List<MeetingInvitation> meetingInvitations = (List<MeetingInvitation>) CommonFunction.INSTANCE
						.getByQuery(sql);
				if (meetingInvitations != null) {
					for (MeetingInvitation meetingInvitation : meetingInvitations) {
						Partaker partaker = PartakerController.Instance
								.getPartakerByBarcode(meetingInvitation.getMeetingBarCode());
						PartakerController.Instance.delete(partaker.getId(), meetingInvitation.getMeetingId());
					}
				}
			}
			isDelete = true;
		}

		// sua danh sach tham du
		for (PartakerLCT partakerLCT : meetingInvitationLCT.getListPartaker()) {
			// lay thong tin nguoi trong thu moi
			long orgIdLCT = partakerLCT.getOrgId();
			String orgNameLCT = partakerLCT.getOrgName();
			// String partakerName = partakerLCT.getPartakerName();
			// String partakerPosition = partakerLCT.getPartakerPosition();
			// String email = partakerLCT.getEmail();
			String key = partakerLCT.getKey();

			// ben kia khong gui du lieu qua nen de " "
			String orgCode = partakerLCT.getOrgCode();
			// kiem tra key da co trong he thong chua
			sql = "FROM KeyOrgMeeting WHERE key = '" + partakerLCT.getKey() + "'";
			List<KeyOrgMeeting> keyOrgMeetings = (List<KeyOrgMeeting>) CommonFunction.INSTANCE.getByQuery(sql);
			if (keyOrgMeetings.size() == 0) {
				try {
					// key khong da ton tai => insert moi vao
					// neu org id = -1 => them to chuc moi vao he thong
					OrganizationMeeting orgAttendMeeting = null;
					if (orgIdLCT == -1) {
						if (!(orgNameLCT.isEmpty() || "".equals(orgNameLCT))) {
							// kiem tra theo ten
							List<OrganizationMeeting> listOrg = OrganizationMeetingController.Instance
									.getByName(orgNameLCT, Constant.ORG_OTHER);
							if (listOrg.size() > 0) {
								// neu nhieu gia tri => lay gia tri dau tien
								orgAttendMeeting = listOrg.get(0);
							} else {
								// khong co => them org vao he thong smeeting
								OrganizationMeeting organizationMeetingNew = new OrganizationMeeting();
								organizationMeetingNew.setName(orgNameLCT);
								organizationMeetingNew.setReferenceId(orgIdLCT);
								organizationMeetingNew.setCode(orgCode);
								organizationMeetingNew.setTypeOrg(Constant.ORG_OTHER);
								orgAttendMeeting = OrganizationMeetingController.Instance
										.insert(organizationMeetingNew);
							}
						} else {
							CommonFunction.INSTANCE.setTable(new OrganizationMeeting());
							orgAttendMeeting = (OrganizationMeeting) CommonFunction.INSTANCE.getById(0);
						}
					} else {

						// neu orgid != 1 => kiem tra to chuc da co trong he
						// thong
						// hay
						// chua
						sql = "FROM OrganizationMeeting " + " WHERE referenceId =" + orgIdLCT + " AND meeting = "
								+ Constant.ORG_OTHER;
						List<OrganizationMeeting> organizationMeetingCheck = (List<OrganizationMeeting>) CommonFunction.INSTANCE
								.getByQuery(sql);
						// kiem tra to chuc da co trong he thong chua
						if (organizationMeetingCheck.size() == 0) {
							OrganizationMeeting organizationMeetingNew = new OrganizationMeeting();
							organizationMeetingNew.setName(orgNameLCT);
							organizationMeetingNew.setReferenceId(orgIdLCT);
							organizationMeetingNew.setCode(orgCode);
							organizationMeetingNew.setTypeOrg(Constant.ORG_OTHER);
							orgAttendMeeting = OrganizationMeetingController.Instance.insert(organizationMeetingNew);
						} else {
							orgAttendMeeting = organizationMeetingCheck.get(0);
						}
					}

					// them key
					long partakerId = 0;
					KeyOrgMeeting keyOrgMeeting = new KeyOrgMeeting();
					keyOrgMeeting.setMeetingId(meeting.getId());
					keyOrgMeeting.setOrgAttendId(orgAttendMeeting.getId());
					keyOrgMeeting.setKey(key);
					keyOrgMeeting.setPartakerId(partakerId);// moi to chuc =>
					// partakerId
					// = 0
					HibernateUtil.insertObject(keyOrgMeeting);
				} catch (Exception e) {
					System.out.println(e.getMessage());
				}
			}

		}

		HibernateUtil.updateObject(meeting);

		// delete file
		deleteFile(meetingInvitationLCT.getMeetingInvitationId(), startTime);

		// new start time
		startTime = meeting.getStartTime();
		// save file
		List<FileLCT> listFileLCT = meetingInvitationLCT.getListFile();
		if (listFileLCT != null) {
			for (FileLCT fileLCT : listFileLCT) {
				saveFile(meetingInvitationLCT.getMeetingInvitationId(), startTime, fileLCT);
			}
		}
		return meetingInvitationLCT;

	}

	@Override
	public int delete(long idMeetingInvitationLCT) {
		Meeting meeting = MeetingController.Instance.getMeetingByMeetingCodeActive(idMeetingInvitationLCT);
		if (meeting == null) {

			return 0;
		}
		deleteFile(idMeetingInvitationLCT, meeting.getStartTime());
		return MeetingController.Instance.updateNeocoreStatus(idMeetingInvitationLCT);
	}

	@Override
	public FileLCT saveFile(long meetingInvitationId, Date startTime, FileLCT fileLCT) {
		String data = fileLCT.getData();
		if (data == null || data.equals("")) {
			return null;
		}
		try {
			byte[] bitFile = Base64.decodeBase64(data);
			String tomcatDir = System.getProperty("catalina.home");
			File file = new File(tomcatDir + PATH_SAVE_FILE_LCT);
			if (!file.exists()) {
				file.mkdir();
			}

			SimpleDateFormat sdf = new SimpleDateFormat(DATE_FORMAT);
			String dateformat = sdf.format(startTime);
			File fileImg = new File(tomcatDir + PATH_SAVE_FILE_LCT + "//" + dateformat + "//" + meetingInvitationId
					+ "//" + fileLCT.getFileName());
			FileUtils.writeByteArrayToFile(fileImg, bitFile);
			return fileLCT;
		} catch (IOException e1) {
			e1.printStackTrace();
		}
		return null;
	}

	@Override
	public void deleteFile(long meetingInvitationId, Date startTime) {
		String tomcatDir = System.getProperty("catalina.home");
		SimpleDateFormat sdf = new SimpleDateFormat(DATE_FORMAT);
		String dateformat = sdf.format(startTime);
		File folder = new File(tomcatDir + PATH_SAVE_FILE_LCT + "//" + dateformat + "//" + meetingInvitationId);
		try {
			FileUtils.deleteDirectory(folder);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	@Override
	public List<File> getPathFiles(long meetingCode, Date startDate) {
		String tomcatDir = System.getProperty("catalina.home");
		SimpleDateFormat sdf = new SimpleDateFormat(DATE_FORMAT);
		String dateformat = sdf.format(startDate);
		File folder = new File(tomcatDir + PATH_SAVE_FILE_LCT + "//" + dateformat + "//" + meetingCode);
		File[] list = folder.listFiles();
		if(list != null){
			return new ArrayList<File>(Arrays.asList(list));
		}else{
			return null;
		}
	}

}
