package com.swt.meeting;

import com.swt.sworld.ps.domain.Member;

public interface IJournaList {
	/**
	 * lay thong tin nha bao theo serialnumber
	 * @param serialNumber
	 * @return
	 */
	public Member getJournalistBySerial(String serialNumber);
	
	/**
	 * Check the nha bao het han
	 * 
	 * @param serialNumber
	 * @return
	 */
	public int isDateExpirated(String serialNumber);
}
