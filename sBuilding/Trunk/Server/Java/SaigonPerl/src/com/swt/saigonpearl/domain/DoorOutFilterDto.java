/**
 * 
 */
package com.swt.saigonpearl.domain;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class DoorOutFilterDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -3356408496276569642L;
	
	private boolean FilterBySerialNumber;
	private String SerialNumber;

	private boolean FilterByMemberId;
	private long MemberId;
	
	private boolean FilterByDateIn;
	private String DateIn;
	
	private boolean FilterByDateOut;
	private String DateOut;
	
	private long DeviceDoorId;
	
	private int Start;
	
	private int Count;
	
	public String clone()
	{
		String resultSearch = "";
		if(FilterBySerialNumber)
			resultSearch += " SerialNumber LIKE '%"+SerialNumber+"%'";
		
		if(resultSearch == "")
		{
			resultSearch += "DeviceDoorId LIKE '"+DeviceDoorId+"'" ;
		}
		else
		{
			resultSearch += " AND DeviceDoorId LIKE '"+DeviceDoorId+"'" ;
		}
		
		if(resultSearch == "")
		{
			if(FilterByDateIn)
				resultSearch += "DateIn LIKE '%"+DateIn+"%'" ;
		}
		else
		{
			if(FilterByDateIn)
				resultSearch += " AND DateIn LIKE '%"+DateIn+"%'";
		}
		
		if(resultSearch == "")
		{
			if(FilterByDateOut)
				resultSearch += "DateIn DateOut '%"+DateOut+"%'" ;
		}
		else
		{
			if(FilterByDateOut)
				resultSearch += " AND DateOut LIKE '%"+DateOut+"%'";
		}
		
		
		//chua lam filter theo start va count
		return resultSearch;
	}
	
	/**
	 * @return the filterBySerialNumber
	 */
	public boolean isFilterBySerialNumber() {
		return FilterBySerialNumber;
	}

	/**
	 * @param filterBySerialNumber the filterBySerialNumber to set
	 */
	public void setFilterBySerialNumber(boolean filterBySerialNumber) {
		FilterBySerialNumber = filterBySerialNumber;
	}

	/**
	 * @return the serialNumber
	 */
	public String getSerialNumber() {
		return SerialNumber;
	}

	/**
	 * @param serialNumber the serialNumber to set
	 */
	public void setSerialNumber(String serialNumber) {
		SerialNumber = serialNumber;
	}

	/**
	 * @return the filterByMemberId
	 */
	public boolean isFilterByMemberId() {
		return FilterByMemberId;
	}

	/**
	 * @param filterByMemberId the filterByMemberId to set
	 */
	public void setFilterByMemberId(boolean filterByMemberId) {
		FilterByMemberId = filterByMemberId;
	}

	/**
	 * @return the memberName
	 */
	public long getMemberId() {
		return MemberId;
	}

	/**
	 * @param memberName the memberName to set
	 */
	public void setMemberId(long memberId) {
		MemberId = memberId;
	}

	/**
	 * @return the filterByDateIn
	 */
	public boolean isFilterByDateIn() {
		return FilterByDateIn;
	}

	/**
	 * @param filterByDateIn the filterByDateIn to set
	 */
	public void setFilterByDateIn(boolean filterByDateIn) {
		FilterByDateIn = filterByDateIn;
	}

	/**
	 * @return the dateIn
	 */
	public String getDateIn() {
		return DateIn;
	}

	/**
	 * @param dateIn the dateIn to set
	 */
	public void setDateIn(String dateIn) {
		DateIn = dateIn;
	}

	/**
	 * @return the filterByDateOut
	 */
	public boolean isFilterByDateOut() {
		return FilterByDateOut;
	}

	/**
	 * @param filterByDateOut the filterByDateOut to set
	 */
	public void setFilterByDateOut(boolean filterByDateOut) {
		FilterByDateOut = filterByDateOut;
	}

	public long getDeviceDoorId() {
		return DeviceDoorId;
	}

	public void setDeviceDoorId(long deviceDoorId) {
		DeviceDoorId = deviceDoorId;
	}

	/**
	 * @return the dateOut
	 */
	public String getDateOut() {
		return DateOut;
	}

	/**
	 * @param dateOut the dateOut to set
	 */
	public void setDateOut(String dateOut) {
		DateOut = dateOut;
	}

	/**
	 * @return the start
	 */
	public int getStart() {
		return Start;
	}

	/**
	 * @param start the start to set
	 */
	public void setStart(int start) {
		Start = start;
	}

	/**
	 * @return the count
	 */
	public int getCount() {
		return Count;
	}

	/**
	 * @param count the count to set
	 */
	public void setCount(int count) {
		Count = count;
	}

}