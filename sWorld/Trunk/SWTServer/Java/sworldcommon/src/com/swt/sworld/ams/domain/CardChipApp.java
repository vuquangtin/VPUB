/**
 * 
 */
package com.swt.sworld.ams.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * @author LOCVIP
 *
 */

@Entity
@Table(name = "swtgp_ams_cardchip_app")

public class CardChipApp implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -2518818880191403997L;
	
	@Id 
	@GeneratedValue
	@Column(name = "CardChipAppId", nullable = false)
	private long CardChipAppId ;
	
	@Column(name = "ChipPersoId", nullable = false)
	private long ChipPersoId ;
	
	@Column(name = "AppId", nullable = false)
	private long AppId ;
	
	@Column(name = "AppCode", length=255, nullable = false)
	private String AppCode ;
	
	@Column(name = "Data", length=255, nullable = false)
	private String Data ;
	
	@Column(name = "StartSector", length=255, nullable = false)
	private String StartSector ;
	
	@Column(name = "UserMaxSector",length=255, nullable = false)
	private String UserMaxSector ;
	
	@Column(name = "LastMemberDataUpdatedOn", length=255, nullable = false)
	private String LastMemberDataUpdatedOn ;
	
	@Column(name = "Rule", length=255, nullable = false)
	private String Rule;
	
	@Column(name = "Status", length=255)
	private Byte Status;

	/**
	 * @return the cardChipAppId
	 */
	public long getCardChipAppId() {
		return CardChipAppId;
	}

	/**
	 * @param cardChipAppId the cardChipAppId to set
	 */
	public void setCardChipAppId(long cardChipAppId) {
		CardChipAppId = cardChipAppId;
	}

	/**
	 * @return the chipPersoId
	 */
	public long getChipPersoId() {
		return ChipPersoId;
	}

	/**
	 * @param chipPersoId the chipPersoId to set
	 */
	public void setChipPersoId(long chipPersoId) {
		ChipPersoId = chipPersoId;
	}

	/**
	 * @return the appId
	 */
	public long getAppId() {
		return AppId;
	}

	/**
	 * @param appId the appId to set
	 */
	public void setAppId(long appId) {
		AppId = appId;
	}

	/**
	 * @return the appCode
	 */
	public String getAppCode() {
		return AppCode;
	}

	/**
	 * @param appCode the appCode to set
	 */
	public void setAppCode(String appCode) {
		AppCode = appCode;
	}

	/**
	 * @return the data
	 */
	public String getData() {
		return Data;
	}

	/**
	 * @param data the data to set
	 */
	public void setData(String data) {
		Data = data;
	}

	/**
	 * @return the startSector
	 */
	public String getStartSector() {
		return StartSector;
	}

	/**
	 * @param startSector the startSector to set
	 */
	public void setStartSector(String startSector) {
		StartSector = startSector;
	}

	/**
	 * @return the userMaxSector
	 */
	public String getUserMaxSector() {
		return UserMaxSector;
	}

	/**
	 * @param userMaxSector the userMaxSector to set
	 */
	public void setUserMaxSector(String userMaxSector) {
		UserMaxSector = userMaxSector;
	}

	/**
	 * @return the lastMemberDataUpdatedOn
	 */
	public String getLastMemberDataUpdatedOn() {
		return LastMemberDataUpdatedOn;
	}

	/**
	 * @param lastMemberDataUpdatedOn the lastMemberDataUpdatedOn to set
	 */
	public void setLastMemberDataUpdatedOn(String lastMemberDataUpdatedOn) {
		LastMemberDataUpdatedOn = lastMemberDataUpdatedOn;
	}

	/**
	 * @return the rule
	 */
	public String getRule() {
		return Rule;
	}

	/**
	 * @param rule the rule to set
	 */
	public void setRule(String rule) {
		Rule = rule;
	}

	/**
	 * @return the status
	 */
	public Byte getStatus() {
		return Status;
	}

	/**
	 * @param status the status to set
	 */
	public void setStatus(Byte status) {
		Status = status;
	}

}
