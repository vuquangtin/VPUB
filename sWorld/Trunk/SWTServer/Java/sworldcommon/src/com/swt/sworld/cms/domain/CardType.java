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
@Table(name = "swtgp_cms_cardtype")

public class CardType implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -5055921352795995654L;

	@Id
	@GeneratedValue
	@Column(name = "CardTypeID")
	private long CardTypeID;
	
	@Column(name = "OrgId")
	private long OrgId ;
	
	@Column(name = "OrgCode", length = 10 , nullable = false)
	private String OrgCode ;
	
	@Column(name = "Prefix", length = 10 , nullable = false)
	private String Prefix ;
	
	
	@Column(name = "CardTypeName", length = 20)
	private String CardTypeName;
	
	@Column(name = "CardLow", length = 23)
	private String CardLow ;
	
	@Column(name = "CardHigh",  length = 23)
	private String CardHigh ;
	
	@Column(name = "PinLength")
	private int PinLength;
	
	@Column(name = "CreatedBy",  length = 45)
	private String CreatedBy;
	
	@Column(name = "CreateOn",length = 45)
	private String CreateOn;
	
	@Column(name = "ModifiedBy", length = 45)
	private String ModifiedBy;
	
	@Column(name = "ModifiedOn", length = 45)
	private String ModifiedOn;
	
	@Column(name = "Status")
	private Boolean Status ;

	/**
	 * @return the cardTypeID
	 */
	public long getCardTypeID() {
		return CardTypeID;
	}

	/**
	 * @param cardTypeID the cardTypeID to set
	 */
	public void setCardTypeID(long cardTypeID) {
		CardTypeID = cardTypeID;
	}

	/**
	 * @return the orgId
	 */
	public long getOrgId() {
		return OrgId;
	}

	/**
	 * @param orgId the orgId to set
	 */
	public void setOrgId(long orgId) {
		OrgId = orgId;
	}

	/**
	 * @return the orgCode
	 */
	public String getOrgCode() {
		return OrgCode;
	}

	/**
	 * @param orgCode the orgCode to set
	 */
	public void setOrgCode(String orgCode) {
		OrgCode = orgCode;
	}

	/**
	 * @return the prefix
	 */
	public String getPrefix() {
		return Prefix;
	}

	/**
	 * @param prefix the prefix to set
	 */
	public void setPrefix(String prefix) {
		Prefix = prefix;
	}

	

	/**
	 * @return the cardTypeName
	 */
	public String getCardTypeName() {
		return CardTypeName;
	}

	/**
	 * @param cardTypeName the cardTypeName to set
	 */
	public void setCardTypeName(String cardTypeName) {
		CardTypeName = cardTypeName;
	}

	/**
	 * @return the cardLow
	 */
	public String getCardLow() {
		return CardLow;
	}

	/**
	 * @param cardLow the cardLow to set
	 */
	public void setCardLow(String cardLow) {
		CardLow = cardLow;
	}

	/**
	 * @return the cardHigh
	 */
	public String getCardHigh() {
		return CardHigh;
	}

	/**
	 * @param cardHigh the cardHigh to set
	 */
	public void setCardHigh(String cardHigh) {
		CardHigh = cardHigh;
	}

	/**
	 * @return the pinLength
	 */
	public int getPinLength() {
		return PinLength;
	}

	/**
	 * @param pinLength the pinLength to set
	 */
	public void setPinLength(int pinLength) {
		PinLength = pinLength;
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

	/**
	 * @return the modifiedBy
	 */
	public String getModifiedBy() {
		return ModifiedBy;
	}

	/**
	 * @param modifiedBy the modifiedBy to set
	 */
	public void setModifiedBy(String modifiedBy) {
		ModifiedBy = modifiedBy;
	}

	/**
	 * @return the modifiedOn
	 */
	public String getModifiedOn() {
		return ModifiedOn;
	}

	/**
	 * @param modifiedOn the modifiedOn to set
	 */
	public void setModifiedOn(String modifiedOn) {
		ModifiedOn = modifiedOn;
	}

	/**
	 * @return the status
	 */
	public Boolean getStatus() {
		return Status;
	}

	/**
	 * @param status the status to set
	 */
	public void setStatus(Boolean status) {
		Status = status;
	}

	

}
