/**
 * 
 */
package com.swt.meetingregister.doman;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * @author Tenit dung để lưu trữ dữ liệu tạm
 */
@Entity
@Table(name = "meeting_register_objectSendmail")
public class ObjectSendMail {
	@Id
	@GeneratedValue
	private long id;
	private String email;
	private String barcode;
	private long orgId;
	private long partakerId;
	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	public String getEmail() {
		return email;
	}
	public void setEmail(String email) {
		this.email = email;
	}
	public String getBarcode() {
		return barcode;
	}
	public void setBarcode(String barcode) {
		this.barcode = barcode;
	}
	public long getOrgId() {
		return orgId;
	}
	public void setOrgId(long orgId) {
		this.orgId = orgId;
	}
	public long getPartakerId() {
		return partakerId;
	}
	public void setPartakerId(long partakerId) {
		this.partakerId = partakerId;
	}
	
	
}
