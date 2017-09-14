package com.swt.nonresident;

import java.util.Date;
import java.util.List;

import com.swt.meeting.domain.NonResident;
import com.swt.nonresident.customObject.NonResidentObj;
import com.swt.nonresident.customObject.NonResidentStatisticDetailObj;
import com.swt.nonresident.customObject.NonResidentStatisticObj;

/**
 * INonResident interface
 * 
 * @author TaiMai
 *
 */
public interface INonResident {
	/**
	 * insert nonresident
	 * 
	 * @param nonResident
	 * @return NonResident
	 */
	public NonResident insert(NonResident nonResident);

	/**
	 * update nonresident
	 * 
	 * @param nonResident
	 * @return NonResident
	 */
	public NonResident update(NonResident nonResident);

	/**
	 * kiem tra the co ton tai khong
	 * 
	 * @param serialnumber
	 * @return NonResident
	 */
	public NonResidentObj checkInOutNonResidentBySerialNumberAndDateime(String serialnumber);

	/**
	 * update outputTime va huy the
	 * 
	 * @param serialnumber
	 * @param date
	 * @return boolean
	 */
	public boolean updateOutputTimeNonResident(String serialnumber, Date date);

	/**
	 * get nonresident by serial number
	 * 
	 * @param serialnumber
	 * @return NonResident
	 */
	public NonResident getNonResidentBySerialNumber(String serialnumber);

	/**
	 * tong so luong cac co quan ma co nguoi vao tu ngay den ngay
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	public long sumNonResidentStatisticByDate(Date fromDate, Date toDate);

	/**
	 * thong ke so luong khach vang lai tu ngay den ngay theo co quan nguoi do
	 * den
	 * 
	 * @param start
	 * @param end
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	public NonResidentStatisticObj getListNonResidentStatisticByDate(int start, int end, Date fromDate, Date toDate);

	/**
	 * thong ke chi tiet mot co quan co bao nhieu nguoi da vao tu ngay den ngay
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	public List<NonResidentObj> getListNonResidentByOrgIdAndDate(int start, int end, Date fromDate, Date toDate,
			long orgId);

	/**
	 * thong ke chi tiet tat ca co quan co nhung nguoi nao da vao tu ngay den
	 * ngay
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	public NonResidentStatisticDetailObj getListNonResidentByDate(int start, int end, Date fromDate, Date toDate);

	/**
	 * thong ke chi tiet tat ca co quan co nhung nguoi nao da vao tu ngay den
	 * ngay co loc theo co quan
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	public NonResidentStatisticDetailObj getListNonResidentByDate(int start, int end, Date fromDate, Date toDate,
			long orgId);

	/**
	 * thong ke chi tiet theo co quan va theo nguoi hoac suborg trong co quan do
	 * 
	 * @param start
	 * @param end
	 * @param fromDate
	 * @param toDate
	 * @param orgId
	 * @param memOrSubOrgId
	 * @param isPeople
	 * @return
	 */
	public NonResidentStatisticDetailObj getListNonResidentByDate(int start, int end, Date fromDate, Date toDate,
			long orgId, long memOrSubOrgId, int isPeople);
	
	/**
	 * tong so luong thong ke co quan co bao nhieu nguoi da vao tu ngay den
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	public long sumListNonResidentByDate(Date fromDate, Date toDate);

	/**
	 * tong so luong thong ke co quan co bao nhieu nguoi da vao tu ngay den
	 * 
	 * @param fromDate
	 * @param toDated
	 * @return long
	 */
	public long sumListNonResidentByDate(Date fromDate, Date toDate, long orgId);

	/**
	 * luu hinh anh chup mat khach vao
	 * 
	 * @param imageId
	 * @param _Image
	 * @return long
	 */
	public long insertImageFace(long imageId, String _Image);

	/**
	 * lay hinh anh chup mat khach vao
	 * 
	 * @param imageId
	 * @return String
	 */

	public String getImageFace(long imageId);

	/**
	 * luu hinh anh chup mat khach vao
	 * 
	 * @param imageId
	 * @param _Image
	 * @return long
	 */
	public long insertImageIdentityCard(long imageId, String _Image);

	/**
	 * lay hinh anh chup mat khach vao
	 * 
	 * @param imageId
	 * @return String
	 */

	public String getImageIdentityCard(long imageId);

}
