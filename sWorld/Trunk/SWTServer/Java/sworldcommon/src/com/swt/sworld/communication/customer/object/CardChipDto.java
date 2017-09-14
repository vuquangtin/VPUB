/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class CardChipDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -6608724169483471788L;
	
	private long CardChipId ;
	private long OrgMasterId ;
	private long OrgPartnerId ;
	private String SerialNumberHex ;
	private int TypeCard ;
	private String TypeCrypto ;
	private int LogicalStatus ;
     private int PhysicalStatus ;
     private boolean Personalized ;
     private String CreateOn;
	/**
	 * @return the cardChipId
	 */
	public long getCardChipId() {
		return CardChipId;
	}
	/**
	 * @param cardChipId the cardChipId to set
	 */
	public void setCardChipId(long cardChipId) {
		CardChipId = cardChipId;
	}
	/**
	 * @return the orgMasterId
	 */
	public long getOrgMasterId() {
		return OrgMasterId;
	}
	/**
	 * @param orgMasterId the orgMasterId to set
	 */
	public void setOrgMasterId(long orgMasterId) {
		OrgMasterId = orgMasterId;
	}
	/**
	 * @return the orgPartnerId
	 */
	public long getOrgPartnerId() {
		return OrgPartnerId;
	}
	/**
	 * @param orgPartnerId the orgPartnerId to set
	 */
	public void setOrgPartnerId(long orgPartnerId) {
		OrgPartnerId = orgPartnerId;
	}
	/**
	 * @return the serialNumberHex
	 */
	public String getSerialNumberHex() {
		return SerialNumberHex;
	}
	/**
	 * @param serialNumberHex the serialNumberHex to set
	 */
	public void setSerialNumberHex(String serialNumberHex) {
		SerialNumberHex = serialNumberHex;
	}
	/**
	 * @return the typeCard
	 */
	public int getTypeCard() {
		return TypeCard;
	}
	/**
	 * @param typeCard the typeCard to set
	 */
	public void setTypeCard(int typeCard) {
		TypeCard = typeCard;
	}
	/**
	 * @return the typeCrypto
	 */
	public String getTypeCrypto() {
		return TypeCrypto;
	}
	/**
	 * @param typeCrypto the typeCrypto to set
	 */
	public void setTypeCrypto(String typeCrypto) {
		TypeCrypto = typeCrypto;
	}
	/**
	 * @return the logicalStatus
	 */
	public int getLogicalStatus() {
		return LogicalStatus;
	}
	/**
	 * @param logicalStatus the logicalStatus to set
	 */
	public void setLogicalStatus(int logicalStatus) {
		LogicalStatus = logicalStatus;
	}
	/**
	 * @return the physicalStatus
	 */
	public int getPhysicalStatus() {
		return PhysicalStatus;
	}
	/**
	 * @param physicalStatus the physicalStatus to set
	 */
	public void setPhysicalStatus(int physicalStatus) {
		PhysicalStatus = physicalStatus;
	}
	/**
	 * @return the personalized
	 */
	public boolean isPersonalized() {
		return Personalized;
	}
	/**
	 * @param personalized the personalized to set
	 */
	public void setPersonalized(boolean personalized) {
		Personalized = personalized;
	}
	/**
	 * @return the createOn
	 */
	public String getCreateOn() {
		return CreateOn;
	}
	/**
	 * @param createOn the createOn to set
	 */
	public void setCreateOn(String createOn) {
		CreateOn = createOn;
	}

}
