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
@Table(name = "swtgp_cms_acquirer")

public class Acquirer implements Serializable {
	

	/**
	 * 
	 */
	private static final long serialVersionUID = -4099432129698710818L;
	
	@Id 
	@GeneratedValue
	@Column(name = "AcquirerId", nullable = false)
	private long Id;
	
	@Column(name = "AcquierMasterCode", length =45, nullable = false)
	private String AcquierMasterCode;
	
	@Column(name = "AccessCode", length =45)
	private String AccessCode;
	
	@Column(name = "Rule", length =45)
	private String Rule ;
	
	@Column(name = "Desciption", length =255)
	private String Desciption ;
	
	@Column(name = "CreatedBy", length =45)
	private String CreatedBy ;
	
	@Column(name = "CreatedOn", length =45)
	private String CreatedOn ;
	
	@Column(name = "ModifiedBy", length =45)
	private String ModifiedBy ;
	
	@Column(name = "ModifiedOn", length =45)
	private String ModifiedOn ;
	
	@Column(name = "Status", length =45)
	private String Status;

	/**
	 * @return the id
	 */
	public long getId() {
		return Id;
	}

	/**
	 * @param id the id to set
	 */
	public void setId(long id) {
		Id = id;
	}

	/**
	 * @return the acquierMasterCode
	 */
	public String getAcquierMasterCode() {
		return AcquierMasterCode;
	}

	/**
	 * @param acquierMasterCode the acquierMasterCode to set
	 */
	public void setAcquierMasterCode(String acquierMasterCode) {
		AcquierMasterCode = acquierMasterCode;
	}

	/**
	 * @return the accessCode
	 */
	public String getAccessCode() {
		return AccessCode;
	}

	/**
	 * @param accessCode the accessCode to set
	 */
	public void setAccessCode(String accessCode) {
		AccessCode = accessCode;
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
	 * @return the desciption
	 */
	public String getDesciption() {
		return Desciption;
	}

	/**
	 * @param desciption the desciption to set
	 */
	public void setDesciption(String desciption) {
		Desciption = desciption;
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
	public String getStatus() {
		return Status;
	}

	/**
	 * @param status the status to set
	 */
	public void setStatus(String status) {
		Status = status;
	}

	

}
