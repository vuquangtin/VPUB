package com.swt.timekeeping.domain;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.NamedNativeQueries;
import javax.persistence.NamedNativeQuery;
import javax.persistence.Table;

/**
 * TimeKeepingShift
 * @author TrangPig
 *
 */
@Entity
@Table(name = "swtgp_timekeeping_shift")

@NamedNativeQueries({
	@NamedNativeQuery(name = "getShift", query = "Call GetShift(:dateBegin, :dateEnd, :listMemberId, :orgId, :subOrgId)", resultClass = Shift.class) })

public class Shift implements Serializable{

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue
	@Column(name = "id", nullable = false)
	private long Id;
	
	@Column(name = "orgid", nullable = false)
	private long orgId;
	
	@Column(name = "suborgid", nullable = false)
	private long subOrgId;
	
	@Column(name = "datein", nullable = false)
	private Date dateIn;
	
	@Column(name = "devicedoorid", nullable = false)
	private long deviceDoorId;
	
	@Column(name = "devicedoorip", nullable = false)
	private String deviceDoorIp;
	
	@Column(name = "imagein", columnDefinition="Text")
	private String imageIn;
	
	@Column(name = "memberid", nullable = false)
	private long memberId;
	
	@Column(name = "serialnumber", nullable = false)
	private String serialNumber;
	

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public long getOrgId() {
		return orgId;
	}

	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}

	public long getSubOrgId() {
		return subOrgId;
	}

	public void setSubOrgId(long subOrgId) {
		this.subOrgId = subOrgId;
	}

	public Date getDateIn() {
		return dateIn;
	}

	public void setDateIn(Date dateIn) {
		this.dateIn = dateIn;
	}

	public long getDeviceDoorId() {
		return deviceDoorId;
	}

	public void setDeviceDoorId(long deviceDoorId) {
		this.deviceDoorId = deviceDoorId;
	}


	public String getDeviceDoorIp() {
		return deviceDoorIp;
	}

	public void setDeviceDoorIp(String deviceDoorIp) {
		this.deviceDoorIp = deviceDoorIp;
	}

	public String getImageIn() {
		return imageIn;
	}

	public void setImageIn(String imageIn) {
		this.imageIn = imageIn;
	}

	public long getMemberId() {
		return memberId;
	}

	public void setMemberId(long memberId) {
		this.memberId = memberId;
	}

	public String getSerialNumber() {
		return serialNumber;
	}

	public void setSerialNumber(String serialNumber) {
		this.serialNumber = serialNumber;
	}

}
