/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.util.Dictionary;


/**
 * @author LOCVIP
 *
 */

public class DataForPersoCard {
	private byte[] HeaderKeyB;
	private String MemberAppMetaData;
	private byte[] MemberData;
	private Dictionary<Byte, KeyUpdateSetDto> AppSectorKeyUpdateSets;
	/**
	 * @return the headerKeyB
	 */
	public byte[] getHeaderKeyB() {
		return HeaderKeyB;
	}
	/**
	 * @param headerKeyB the headerKeyB to set
	 */
	public void setHeaderKeyB(byte[] headerKeyB) {
		HeaderKeyB = headerKeyB;
	}
	/**
	 * @return the memberAppMetaData
	 */
	public String getMemberAppMetaData() {
		return MemberAppMetaData;
	}
	/**
	 * @param memberAppMetaData the memberAppMetaData to set
	 */
	public void setMemberAppMetaData(String memberAppMetaData) {
		MemberAppMetaData = memberAppMetaData;
	}
	/**
	 * @return the memberData
	 */
	public byte[] getMemberData() {
		return MemberData;
	}
	/**
	 * @param memberData the memberData to set
	 */
	public void setMemberData(byte[] memberData) {
		MemberData = memberData;
	}
	/**
	 * @return the appSectorKeyUpdateSets
	 */
	public Dictionary<Byte, KeyUpdateSetDto> getAppSectorKeyUpdateSets() {
		return AppSectorKeyUpdateSets;
	}
	/**
	 * @param appSectorKeyUpdateSets the appSectorKeyUpdateSets to set
	 */
	public void setAppSectorKeyUpdateSets(Dictionary<Byte, KeyUpdateSetDto> appSectorKeyUpdateSets) {
		AppSectorKeyUpdateSets = appSectorKeyUpdateSets;
	}


}
