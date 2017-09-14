/**
 * 
 */
package com.swt.sworld.common.domain;

import java.io.Serializable;

import javax.persistence.*;

/**
 * @author sangdb
 *
 */

@Entity
@Table(name = "swtgp_config")

public class Config implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -2730136998693650283L;

	@Id 
	@GeneratedValue
	@Column(name = "Id")
	private long Id;
	
	@Column(name = "Name", length = 40, nullable = false)
	private String Name;
	
	@Column(name = "Value", length = 500, nullable = false)
	private String Value;
	
	@Column(name = "updateddate", columnDefinition="varchar(20)")
	private String updateddate;
	
	@Column(name = "status", columnDefinition="int default 0")
	private int status;
	
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

	public String getName() {
		return Name;
	}

	public void setName(String name) {
		Name = name;
	}

	public String getValue() {
		return Value;
	}

	public void setValue(String value) {
		Value = value;
	}

	public String getUpdateddate() {
		return updateddate;
	}

	public void setUpdateddate(String updateddate) {
		this.updateddate = updateddate;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}
 }
