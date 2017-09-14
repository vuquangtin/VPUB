/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
/**
 * @author LOCVIP
 *
 */

/*
 * Table này thêm vào dựa vào code của anh Dũng
 */

public class PersonalizationDto implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 5596128331951735209L;

	
	private long ChipPersoId;
	private long PSMemberId;
	private long CardChipId;
	private String SerialNumber;
	private String PersoDate;
	private String ExpirationDate;
	private String Notes;
	private String CreatedBy;
	private String CreatedOn;
	private String ModifiedBy;
	private String ModifiedOn;
	private String Temp1;
	private int Status;
	
	public PersonalizationDto(long ChipPersoId, long PSMemberId, long CardChipId, String SerialNumber,
			String PersoDate, String ExpirationDate, String Notes, String CreatedBy,
			String CreatedOn, String ModifiedBy, String ModifiedOn, String Temp1, int Status) {
		this.setChipPersoId(ChipPersoId);
		this.PSMemberId = PSMemberId;
		this.CardChipId = CardChipId;
		this.SerialNumber= SerialNumber;
		this.PersoDate = PersoDate;
		this.ExpirationDate= ExpirationDate;
		this.Notes= Notes;
		this.CreatedBy = CreatedBy;
		this.CreatedOn = CreatedOn;
		this.ModifiedBy = ModifiedBy;
		this.ModifiedOn= ModifiedOn;
		this.Temp1 = Temp1;
		this.Status =Status;
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
		return Status;
	}

	/**
	 * @param status the status to set
	 */
	public void setStatus(int status) {
		Status = status;
	}

	/**
	 * @return the pSMemberId
	 */
	public long getPSMemberId() {
		return PSMemberId;
	}

	/**
	 * @param pSMemberId the pSMemberId to set
	 */
	public void setPSMemberId(long pSMemberId) {
		PSMemberId = pSMemberId;
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

}
