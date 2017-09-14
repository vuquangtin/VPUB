/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;


public class PSChipPersonalizationDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -6224853587599181239L;

	private long ChipPersoId;

	private long PsMemberId;

	private long CardChipId;

	private String SerialNumber;

	private String Data;

	private String PersoDate;

	private String ExpirationDate;

	private String Notes;

	private String CreatedBy;

	private String CreatedOn;

	private String ModifiedBy;

	private String ModifiedOn;

	private String Temp1;

	private int Status;

	/**
	 * @return the chipPersoId
	 */
	public long getChipPersoId() {
		return ChipPersoId;
	}

	/**
	 * @param chipPersoId
	 *            the chipPersoId to set
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
	 * @param psMemberId
	 *            the psMemberId to set
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
	 * @param cardChipId
	 *            the cardChipId to set
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
	 * @param serialNumber
	 *            the serialNumber to set
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
	 * @param data
	 *            the data to set
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
	 * @param persoDate
	 *            the persoDate to set
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
	 * @param expirationDate
	 *            the expirationDate to set
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
	 * @param notes
	 *            the notes to set
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
	 * @param createdBy
	 *            the createdBy to set
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
	 * @param createdOn
	 *            the createdOn to set
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
	 * @param modifiedBy
	 *            the modifiedBy to set
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
	 * @param modifiedOn
	 *            the modifiedOn to set
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
	 * @param temp1
	 *            the temp1 to set
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
	 * @param status
	 *            the status to set
	 */
	public void setStatus(int status) {
		Status = status;
	}

}
