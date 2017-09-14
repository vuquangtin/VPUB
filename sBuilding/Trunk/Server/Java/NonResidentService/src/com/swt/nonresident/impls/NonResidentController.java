package com.swt.nonresident.impls;

import java.util.Date;
import java.util.List;

import com.swt.meeting.domain.NonResident;
import com.swt.nonresident.customObject.NonResidentObj;
import com.swt.nonresident.customObject.NonResidentStatisticDetailObj;
import com.swt.nonresident.customObject.NonResidentStatisticObj;

/**
 * ListMeetingController
 * 
 * @author TaiMai
 * 
 */
public class NonResidentController {
	/**
	 * Instance of ListMeetingController
	 */
	public static final NonResidentController Instance = new NonResidentController();

	private NonResidentDAO nrDAO = new NonResidentDAO();

	/**
	 * insert nonresident
	 * 
	 * @param nonResident
	 * @return NonResident
	 */
	public NonResident insert(NonResident nonResident) {
		return nrDAO.insert(nonResident);
	}

	/**
	 * update nonresident
	 * 
	 * @param nonResident
	 * @return NonResident
	 */
	public NonResident update(NonResident nonResident) {
		return nrDAO.update(nonResident);
	}

	/**
	 * kiem tra the co ton tai khong
	 * 
	 * @param serialnumber
	 * @return NonResident
	 */
	public NonResidentObj checkInOutNonResidentBySerialNumberAndDateime(String serialnumberm) {
		return nrDAO.checkInOutNonResidentBySerialNumberAndDateime(serialnumberm);
	}

	/**
	 * get nonresident by serial number
	 * 
	 * @param serialnumber
	 * @return NonResident
	 */
	public NonResident getNonResidentBySerialNumber(String serialnumber) {
		return nrDAO.getNonResidentBySerialNumber(serialnumber);
	}

	/**
	 * update outputTime va huy the
	 * 
	 * @param serialnumber
	 * @param date
	 * @return boolean
	 */
	public boolean updateOutputTimeNonResident(String serialnumber, Date date) {
		return nrDAO.updateOutputTimeNonResident(serialnumber, date);
	}

	/**
	 * thong ke so luong khach vang lai tu ngay den ngay theo co quan nguoi do
	 * den
	 * 
	 * @param start
	 * @param end
	 * @param fromDate
	 * @param toDated
	 * @return NonResidentstatisticObj
	 */
	public NonResidentStatisticObj getListNonResidentStatisticByDate(int start, int end, Date fromDate, Date toDate) {
		return nrDAO.getListNonResidentStatisticByDate(start, end, fromDate, toDate);
	}

	// get list nonresident by date
	public List<NonResidentObj> getListNonResidenByOrgIdAndDate(int start, int end, Date fromDate, Date toDate,
			long orgId) {
		return nrDAO.getListNonResidentByOrgIdAndDate(start, end, fromDate, toDate, orgId);
	}

	/**
	 * thong ke chi tiet tat ca co quan co bao nhieu nguoi da vao tu ngay den
	 * ngay
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	public NonResidentStatisticDetailObj getListNonResidentByDate(int start, int end, Date fromDate, Date toDate) {
		return nrDAO.getListNonResidentByDate(start, end, fromDate, toDate);
	}

	/**
	 * thong ke chi tiet tat ca co quan co bao nhieu nguoi da vao tu ngay den
	 * ngay
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	public NonResidentStatisticDetailObj getListNonResidentByDate(int start, int end, Date fromDate, Date toDate,
			long orgId, long memOrSubOrgId, int isPeople) {
		if (orgId == -1) {
			return nrDAO.getListNonResidentByDate(start, end, fromDate, toDate);
		} else if (memOrSubOrgId == -1) {
			return nrDAO.getListNonResidentByDate(start, end, fromDate, toDate, orgId);
		} else {
			return nrDAO.getListNonResidentByDate(start, end, fromDate, toDate, orgId, memOrSubOrgId, isPeople);
		}
	}

	/**
	 * luu hinh anh chup mat khach vao
	 * 
	 * @param imageId
	 * @param _Image
	 * @return long
	 */
	public long insertImageFace(long imageId, String _Image) {
		return nrDAO.insertImageFace(imageId, _Image);
	}

	/**
	 * lay hinh anh chup mat khach vao
	 * 
	 * @param imageId
	 * @return String
	 */

	public String getImageFace(long imageId) {
		return nrDAO.getImageFace(imageId);
	}

	/**
	 * luu hinh anh chup mat khach vao
	 * 
	 * @param imageId
	 * @param _Image
	 * @return long
	 */
	public long insertImageIdentityCard(long imageId, String _Image) {
		return nrDAO.insertImageIdentityCard(imageId, _Image);
	}

	/**
	 * lay hinh anh chup mat khach vao
	 * 
	 * @param imageId
	 * @return String
	 */

	public String getImageIdentityCard(long imageId) {
		return nrDAO.getImageIdentityCard(imageId);
	}
}
