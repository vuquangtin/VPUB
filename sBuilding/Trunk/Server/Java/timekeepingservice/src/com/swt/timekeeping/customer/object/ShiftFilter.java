package com.swt.timekeeping.customer.object;

import java.io.Serializable;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
/**
 * ShiftFilter class
 * @author TrangPig
 *
 */
public class ShiftFilter implements Serializable {

	private static final long serialVersionUID = 1L;

	private boolean filterBySerialNumber;
	private String serialNumber;

	private boolean filterByMemberId;
	private long memberId;
	
	private boolean filterByDeviceDoorId;
	private long deviceDoorId;
	
	private boolean filterByDeviceDoorIp;
	private String deviceDoorIp;
	
	private boolean filterByDateIn;
	private Date dateIn;
	
	/**
	 * Hàm clone ra lenh sql de thuc hien cac thao tac
	 */
	public String clone()
	{
		String resultSearch = "";
		if(filterBySerialNumber)
			resultSearch += " serialNumber LIKE '%"+serialNumber+"%'";

	
		if(resultSearch == "")
		{
			if(filterByMemberId)
				resultSearch += "memberId LIKE '%"+memberId+"%'" ;
		}
		else
		{
			if(filterByMemberId)
				resultSearch += " AND memberId LIKE '%"+memberId+"%'";
		}
		
		if(resultSearch == "")
		{
			if(filterByDeviceDoorId)
			resultSearch += "deviceDoorId LIKE '"+deviceDoorId+"'" ;
		}
		else
		{
			if(filterByDeviceDoorId)
			resultSearch += " AND deviceDoorId LIKE '"+deviceDoorId+"'" ;
		}
		if(resultSearch == "")
		{
			if(filterByDeviceDoorIp)
			resultSearch += "deviceDoorIp LIKE '"+deviceDoorIp+"'" ;
		}
		else
		{
			if(filterByDeviceDoorIp)
			resultSearch += " AND deviceDoorIp LIKE '"+deviceDoorIp+"'" ;
		}
		if(filterByDateIn) resultSearch = cloneByDate(resultSearch);
		return resultSearch;
	}
	
	/**
	 * Hàm clone với dateIn nhận vào là ngày
	 */
	@SuppressWarnings({ "deprecation" })
	public String cloneByDate(String result){
		if(result == "")
		{
			if(filterByDateIn){
				DateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
				dateIn.setHours(00);
				dateIn.setMinutes(00);
				dateIn.setSeconds(00);
				result += "dateIn BETWEEN '"+formatter.format(dateIn) + "'";
				dateIn.setHours(23);
				dateIn.setMinutes(59);
				dateIn.setSeconds(59);
				result += " AND '"+formatter.format(dateIn) +"'";
			}
		}
		else
		{
			if(filterByDateIn){
				DateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
				dateIn.setHours(00);
				dateIn.setMinutes(00);
				dateIn.setSeconds(00);
				result += " AND dateIn BETWEEN '"+formatter.format(dateIn)+"'";
				dateIn.setHours(23);
				dateIn.setMinutes(59);
				dateIn.setSeconds(59);
				result += " AND '"+formatter.format(dateIn) +"'";
			}
		}
		return result;
	}
	
	/**
	 * Hàm clone với dateIn nhận vào là tháng và năm
	 */
	@SuppressWarnings("deprecation")
	public String cloneByMonth(String result){
		result = clone();
		if(result == "")
		{
			if(filterByDateIn){
				result += " WHERE YEAR(datein) = '"+dateIn.getYear()+ "' AND MONTH(datein) = '"+ dateIn.getMonth() +"'";
			}
		}
		else
		{
			if(filterByDateIn){
				result += " AND  WHERE YEAR(datein) = '"+dateIn.getYear()+"' AND MONTH(datein) = '"+ dateIn.getMonth() +"'";
			}
		}
		return result;
	}
	
	/**
	 * Hàm clone với dateIn nhận vào là năm
	 */
	@SuppressWarnings("deprecation")
	public String cloneByYear(String result){
		result = clone();
		if(result == "")
		{
			if(filterByDateIn){
				result += " WHERE YEAR(datein) = '"+dateIn.getYear()+ "'";
			}
		}
		else
		{
			if(filterByDateIn){
				result += " AND  WHERE YEAR(datein) = '"+dateIn.getYear()+"'";
			}
		}
		return result;
	}
	
	/**
	 * @return the filterBySerialNumber
	 */
	public boolean isFilterBySerialNumber() {
		return filterBySerialNumber;
	}

	/**
	 * @param filterBySerialNumber the filterBySerialNumber to set
	 */
	public void setFilterBySerialNumber(boolean filterBySerialNumber) {
		this.filterBySerialNumber = filterBySerialNumber;
	}

	/**
	 * @return the serialNumber
	 */
	public String getSerialNumber() {
		return serialNumber;
	}

	/**
	 * @param serialNumber the serialNumber to set
	 */
	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}

	/**
	 * @return the filterByMemberId
	 */
	public boolean isFilterByDeviceDoorName() {
		return filterByDeviceDoorId;
	}

	/**
	 * @param filterByMemberId the filterByMemberId to set
	 */
	public void setFilterByDeviceDoorName(boolean filterByDeviceDoorId) {
		this.filterByDeviceDoorId = filterByDeviceDoorId;
	}

	public boolean isFilterByMemberId() {
		return filterByMemberId;
	}

	public void setFilterByMemberId(boolean filterByMemberId) {
		this.filterByMemberId = filterByMemberId;
	}

	public long getMemberId() {
		return memberId;
	}

	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}

	public boolean isFilterByDeviceDoorId() {
		return filterByDeviceDoorId;
	}

	public void setFilterByDeviceDoorId(boolean filterByDeviceDoorId) {
		this.filterByDeviceDoorId = filterByDeviceDoorId;
	}

	public long getDeviceDoorId() {
		return deviceDoorId;
	}

	public void setDeviceDoorId(long deviceDoorId) {
		this.deviceDoorId = deviceDoorId;
	}

	public boolean isFilterByDeviceDoorIp() {
		return filterByDeviceDoorIp;
	}

	public void setFilterByDeviceDoorIp(boolean filterByDeviceDoorIp) {
		this.filterByDeviceDoorIp = filterByDeviceDoorIp;
	}

	public String getDeviceDoorIp() {
		return deviceDoorIp;
	}

	public void setDeviceDoorIp(String deviceDoorIp) {
		this.deviceDoorIp = deviceDoorIp;
	}

	public boolean isFilterByDateIn() {
		return filterByDateIn;
	}

	public void setFilterByDateIn(boolean filterByDateIn) {
		this.filterByDateIn = filterByDateIn;
	}

	public Date getDateIn() {
		return dateIn;
	}

	public void setDateIn(Date dateIn) {
		this.dateIn = dateIn;
	}

	

}
