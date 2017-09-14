/**
 * 
 */
package com.swt.sworld.common.domain;

import java.io.Serializable;

import javax.persistence.*;

/**
 * @author LOCVIP
 *
 */

@Entity
@Table(name = "swtgp_group_user")

public class GroupSworld implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -2108144329383852815L;

	@Id @GeneratedValue
	@Column(name = "Id", nullable = false)
	@PrimaryKeyJoinColumn
	private long id;
	
	@Column(name = "Name", columnDefinition="VARCHAR(255)", nullable = false)
	private String name;
	
	@Column(name = "Description", columnDefinition="TEXT")
	private String description;
	
	@Column(name = "IsAdmin", columnDefinition ="int default 0" )
	private int isAdmin;
	
	@Column(name = "Role", columnDefinition ="int default 0" )
	private int role;
	
	@Column(name = "Permission", columnDefinition="VARCHAR(500)")
	private String permission;
	
	@Column(name = "Status", columnDefinition ="int default 0" )
	private int status;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

	public int getStatus() {
		return status;
	}

	public void setStatus(int status) {
		this.status = status;
	}

	public int getIsAdmin() {
		return isAdmin;
	}

	public void setIsAdmin(int isAdmin) {
		this.isAdmin = isAdmin;
	}
	public String getPermission() {
		return permission;
	}

	public void setPermission(String permission) {
		this.permission = permission;
	}

	public int getRole() {
		return role;
	}

	public void setRole(int role) {
		this.role = role;
	}

}
