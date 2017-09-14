/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class PersoCardCustomerDTO implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = -5445452828886826707L;
	
	private long ChipPersoId ;
	private long CardChipId ;
	private String SerialNumber ;
	private String PersoDate ;
	private String ExpirationDate ;
	private int LogicalStatus ;
    private int PhysicalStatus ;
    private String Notes ;
    private int Status ;
    
	public PersoCardCustomerDTO(long ChipPersoId, long CardChipId,
			String SerialNumber, String PersoDate, String ExpirationDate,
			int LogicalStatus, int PhysicalStatus, String Notes, int Status)
    {
		
		this.ChipPersoId = ChipPersoId;
		this.CardChipId = CardChipId;
		this.SerialNumber = SerialNumber;
		this.PersoDate = PersoDate;
		this.ExpirationDate = ExpirationDate;
		this.LogicalStatus = LogicalStatus;
		this.PhysicalStatus = PhysicalStatus;
		this.Notes = Notes;
		this.Status = Status;
    	
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

}
