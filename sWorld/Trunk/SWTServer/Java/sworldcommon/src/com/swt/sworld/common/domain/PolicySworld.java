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
@Table(name ="swtgp_policy")
public class PolicySworld implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 4838531153472079630L;

	@Id
	@GeneratedValue
	@Column(name = "Id")
	private long Id;
	
	@Column(name = "GroupId")
	private long GroupId;
	
	@Column(name = "AppId")
	private long AppId;
	
	@Column(name = "ModuleId")
	private long ModuleId;
	
	@Column(name = "Descriptions")
	private String Descriptions;
	
	@Column(name = "Modified", columnDefinition = "int default 0")
	private int  Modified;
	
	@Column(name = "Inserted",  columnDefinition = "int default 0")
	private int Inserted;
	
	@Column(name = "Deleted",  columnDefinition = "int default 0")
	private int Deleted;
	
	@Column(name = "Viewer",  columnDefinition = "int default 0")
	private int Viewer;

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
	 * @return the groupId
	 */
	public long getGroupId() {
		return GroupId;
	}

	/**
	 * @param groupId the groupId to set
	 */
	public void setGroupId(long groupId) {
		GroupId = groupId;
	}

	/**
	 * @return the appId
	 */
	public long getAppId() {
		return AppId;
	}

	/**
	 * @param appId the appId to set
	 */
	public void setAppId(long appId) {
		AppId = appId;
	}

	/**
	 * @return the moduleId
	 */
	public long getModuleId() {
		return ModuleId;
	}

	/**
	 * @param moduleId the moduleId to set
	 */
	public void setModuleId(long moduleId) {
		ModuleId = moduleId;
	}

	/**
	 * @return the descriptions
	 */
	public String getDescriptions() {
		return Descriptions;
	}

	/**
	 * @param descriptions the descriptions to set
	 */
	public void setDescriptions(String descriptions) {
		Descriptions = descriptions;
	}

	/**
	 * @return the modified
	 */
	public int getModified() {
		return Modified;
	}

	/**
	 * @param modified the modified to set
	 */
	public void setModified(int modified) {
		Modified = modified;
	}

	/**
	 * @return the inserted
	 */
	public int getInserted() {
		return Inserted;
	}

	/**
	 * @param inserted the inserted to set
	 */
	public void setInserted(int inserted) {
		Inserted = inserted;
	}

	/**
	 * @return the deleted
	 */
	public int getDeleted() {
		return Deleted;
	}

	/**
	 * @param deleted the deleted to set
	 */
	public void setDeleted(int deleted) {
		Deleted = deleted;
	}

	/**
	 * @return the viewer
	 */
	public int getViewer() {
		return Viewer;
	}

	/**
	 * @param viewer the viewer to set
	 */
	public void setViewer(int viewer) {
		Viewer = viewer;
	}


	
}
