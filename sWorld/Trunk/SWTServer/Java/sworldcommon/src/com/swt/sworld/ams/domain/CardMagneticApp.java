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
@Table(name = "swtgp_ams_cardmagnetic_app")

public class CardMagneticApp implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 8636626398083889777L;
	
	@Id 
	@GeneratedValue
	@Column(name = "CardMagniteId", nullable = false)
	private long CardMagniteId ;
	
	@Column(name = "AppId", columnDefinition="VARCHAR(255)", nullable = false)
	private long AppId ;
	
	@Column(name = "AppCode", columnDefinition="VARCHAR(255)", nullable = false)
	private String AppCode ;
	
	@Column(name = "MagneticPersoId", columnDefinition="VARCHAR(255)", nullable = false)
	private long MagneticPersoId ;
	
	@Column(name = "Rule", columnDefinition="VARCHAR(255)", nullable = false)
	private String Rule ;
	
	@Column(name = "Status", columnDefinition="VARCHAR(255)")
	private Byte Status ;

	/**
	 * @return the cardMagniteId
	 */
	public long getCardMagniteId() {
		return CardMagniteId;
	}

	/**
	 * @param cardMagniteId the cardMagniteId to set
	 */
	public void setCardMagniteId(long cardMagniteId) {
		CardMagniteId = cardMagniteId;
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
	 * @return the magneticPersoId
	 */
	public long getMagneticPersoId() {
		return MagneticPersoId;
	}

	/**
	 * @param magneticPersoId the magneticPersoId to set
	 */
	public void setMagneticPersoId(long magneticPersoId) {
		MagneticPersoId = magneticPersoId;
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
