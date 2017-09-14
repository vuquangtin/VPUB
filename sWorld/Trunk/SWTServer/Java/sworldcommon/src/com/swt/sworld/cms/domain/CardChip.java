/**
 * 
 */
package com.swt.sworld.cms.domain;

import java.io.Serializable;

import javax.persistence.*;

/**
 * @author LOCVIP
 *
 */

@Entity
@Table(name = "swtgp_cms_cardchip")

public class CardChip  implements Serializable{
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -3939903726683004407L;


	@Id 
	@GeneratedValue
	@Column(name = "CardChipId", nullable= false)
	private long CardChipId;
	
	@Column(name = "OrgMasterId")
	private long OrgMasterId ;
	
	@Column(name = "OrgPartnerId")
	private long OrgPartnerId ;
	
	@Column(name = "OrgMasterCode", length = 10)
	private String OrgMasterCode;
	
	@Column(name = "OrgPartnerCode", length = 10)
	private String OrgPartnerCode;
	
	@Column(name = "SerialNumberHex", length =100, nullable = false)
	private String SerialNumberHex;
	
	@Column(name = "licensemaster", length =1024, nullable = false)
	private String licensemaster;
	
	@Column(name = "licensepartner", length =1024)
	private String licensepartner;
	
	@Column(name = "headerposision")
	private int headerposision;
	  
	@Column(name = "TypeCard")
	private int TypeCard ;
	
	@Column(name = "TypeCrypto", length =50)
	private String TypeCrypto ;
	
	@Column(name = "CreatedOn", length =20)
	private String CreatedOn ;
	
	@Column(name = "CreatedBy", length =20)
	private String CreatedBy ;
	
	@Column(name = "ModifyBy", length =20)
	private String ModifyBy ;
	
	@Column(name = "ModifyOn", length =20)
	private String ModifyOn ; 
	
	@Column(name = "LogicalStatus")
	private int LogicalStatus;
	
	@Column(name = "PhysicalStatus")
	private int PhysicalStatus;
	
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
	 * @return the createdOn
	 */
	public String getCreatedOn() {
		return CreatedOn;
	}

	/**
	 * @param createdOn the createdOn to set
	 */
	public void setCreatedOn(String createdOn) {
		CreatedOn = createdOn;
	}

	/**
	 * @return the createdBy
	 */
	public String getCreatedBy() {
		return CreatedBy;
	}

	/**
	 * @param createdBy the createdBy to set
	 */
	public void setCreatedBy(String createdBy) {
		CreatedBy = createdBy;
	}

	/**
	 * @return the modifyBy
	 */
	public String getModifyBy() {
		return ModifyBy;
	}

	/**
	 * @param modifyBy the modifyBy to set
	 */
	public void setModifyBy(String modifyBy) {
		ModifyBy = modifyBy;
	}

	/**
	 * @return the modifyOn
	 */
	public String getModifyOn() {
		return ModifyOn;
	}

	/**
	 * @param modifyOn the modifyOn to set
	 */
	public void setModifyOn(String modifyOn) {
		ModifyOn = modifyOn;
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

	public String getLicensemaster() {
		return licensemaster;
	}

	public void setLicensemaster(String licensemaster) {
		this.licensemaster = licensemaster;
	}

	public String getLicensepartner() {
		return licensepartner;
	}

	public void setLicensepartner(String licensepartner) {
		this.licensepartner = licensepartner;
	}

	public int getHeaderposision() {
		return headerposision;
	}

	public void setHeaderposision(int headerposision) {
		this.headerposision = headerposision;
	}

	/**
	 * @return the orgMasterCode
	 */
	public String getOrgMasterCode() {
		return OrgMasterCode;
	}

	/**
	 * @param orgMasterCode the orgMasterCode to set
	 */
	public void setOrgMasterCode(String orgMasterCode) {
		OrgMasterCode = orgMasterCode;
	}

	/**
	 * @return the orgPartnerCode
	 */
	public String getOrgPartnerCode() {
		return OrgPartnerCode;
	}

	/**
	 * @param orgPartnerCode the orgPartnerCode to set
	 */
	public void setOrgPartnerCode(String orgPartnerCode) {
		OrgPartnerCode = orgPartnerCode;
	}

	
}
