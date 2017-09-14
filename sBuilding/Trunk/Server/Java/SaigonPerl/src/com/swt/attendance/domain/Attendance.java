/**
 * 
 */
package com.swt.attendance.domain;

import java.io.Serializable;

import javax.persistence.*;

/**
 * @author LOCVIP
 *
 */

@Entity
@Table(name = "swtgp_attendance")

public class Attendance implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 8656940562963683299L;
	
	@Id 
	@GeneratedValue
	@Column(name = "Id", nullable = false)
	private long Id;
	
	@Column(name = "SerialNumber")
	private String SerialNumber ;
	
	@Column(name = "MemberId")
	private long MemberId ;
	
	@Column(name = "DateIn")
	private String DateIn;
	
	@Column(name = "DateOut")
	private String DateOut;
	
	@Column(name = "ImgIn", columnDefinition="Text")
	private String ImgIn;
	
	@Column(name = "ImgOut", columnDefinition="Text")
	private String ImgOut;
	
	
	@Column(name = "Status")
	private int Status;

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
	 * @return the memberId
	 */
	public long getMemberId() {
		return MemberId;
	}

	/**
	 * @param memberId the memberId to set
	 */
	public void setMemberId(long memberId) {
		MemberId = memberId;
	}

	/**
	 * @return the dateIn
	 */
	public String getDateIn() {
		return DateIn;
	}

	/**
	 * @param dateIn the dateIn to set
	 */
	public void setDateIn(String dateIn) {
		DateIn = dateIn;
	}

	/**
	 * @return the dateOut
	 */
	public String getDateOut() {
		return DateOut;
	}

	/**
	 * @param dateOut the dateOut to set
	 */
	public void setDateOut(String dateOut) {
		DateOut = dateOut;
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

	public String getImgIn() {
		return ImgIn;
	}

	public void setImgIn(String imgIn) {
		ImgIn = imgIn;
	}

	public String getImgOut() {
		return ImgOut;
	}

	public void setImgOut(String imgOut) {
		ImgOut = imgOut;
	}

	
}
