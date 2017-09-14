/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class GroupSync implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1626197826717494455L;
	private long Id;
	private String Name;
	private long OrgId;
	private String Description;
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
	 * @return the name
	 */
	public String getName() {
		return Name;
	}
	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		Name = name;
	}
	/**
	 * @return the orgId
	 */
	public long getOrgId() {
		return OrgId;
	}
	/**
	 * @param orgId the orgId to set
	 */
	public void setOrgId(long orgId) {
		OrgId = orgId;
	}
	/**
	 * @return the description
	 */
	public String getDescription() {
		return Description;
	}
	/**
	 * @param description the description to set
	 */
	public void setDescription(String description) {
		Description = description;
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
