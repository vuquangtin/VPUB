/**
 * 
 */
package com.swt.sworld.ps.domain;

import java.io.Serializable;

import javax.persistence.*;

/**
 * @author sangdb
 *
 */

@Entity
@Table(name = "swtgp_ps_chip_personalization")

public class ChipPersonalization implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 5903726026959957841L;

	@Id 
	@GeneratedValue
	@Column(name = "ChipPersoId")
	private long ChipPersoId;
	
	@Column(name = "PsMemberId", nullable = false)
    private long PsMemberId ;
    
	@Column(name = "CardChipId", nullable = false)
    private long CardChipId ;
	
	@Column(name = "SerialNumber", length=255)
    private String SerialNumber ;
	
	@Column(name = "Data", length=255)
    private String Data ;
	
	@Column(name = "PersoDate", length=20, nullable = false)
    private String PersoDate ;
	
	@Column(name = "ExpirationDate", length=20)
    private String ExpirationDate ;
	
	@Column(name = "Notes")
    private String Notes ;
	
	@Column(name = "CreatedBy", length=255)
    private String CreatedBy ;
	
	@Column(name = "CreatedOn", length=20)
    private String CreatedOn ;
	
	@Column(name = "ModifiedBy", length=255)
    private String ModifiedBy ;
	
	@Column(name = "ModifiedOn", length=255 , nullable = false)
    private String ModifiedOn ;
	
	@Column(name = "Temp1", length=255)
	private String Temp1 ;
	
	@Column(name = "Active", columnDefinition="int default 0")
    private int Active ;

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
	 * @return the psMemberId
	 */
	public long getPsMemberId() {
		return PsMemberId;
	}

	/**
	 * @param psMemberId the psMemberId to set
	 */
	public void setPsMemberId(long psMemberId) {
		PsMemberId = psMemberId;
	}

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
	 * @return the persoDate
	 */
	public String getPersoDate() {
		return PersoDate;
	}

	/**
	 * @param persoDate the persoDate to set
	 */
	public void setPersoDate(String persoDate) {
		PersoDate = persoDate;
	}

	/**
	 * @return the expirationDate
	 */
	public String getExpirationDate() {
		return ExpirationDate;
	}

	/**
	 * @param expirationDate the expirationDate to set
	 */
	public void setExpirationDate(String expirationDate) {
		ExpirationDate = expirationDate;
	}

	/**
	 * @return the notes
	 */
	public String getNotes() {
		return Notes;
	}

	/**
	 * @param notes the notes to set
	 */
	public void setNotes(String notes) {
		Notes = notes;
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
	 * @return the temp1
	 */
	public String getTemp1() {
		return Temp1;
	}

	/**
	 * @param temp1 the temp1 to set
	 */
	public void setTemp1(String temp1) {
		Temp1 = temp1;
	}

	/**
	 * @return the status
	 */
	public int getStatus() {
		return Active;
	}

	/**
	 * @param status the status to set
	 */
	public void setStatus(int active) {
		Active = active;
	}
}

	
	