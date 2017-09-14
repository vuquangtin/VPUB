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
@Table(name = "swtgp_integratinglog")

public class IntegratingLog implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = -4025949207602527153L;

	@Id @GeneratedValue
	@Column(name = "Id")
	@PrimaryKeyJoinColumn
	private long Id;
	
	@Column(name = "ChangedTable", columnDefinition="VARCHAR(255)", nullable = false)
	private String ChangedTable;
	
	@Column(name = "Changes", columnDefinition="TEXT", nullable = false)
	private String Changes;
	
	@Column(name = "Result", columnDefinition="TINY", nullable = false)
	private Boolean Result;
	
	@Column(name = "Reason", columnDefinition="VARCHAR(255)", nullable = false)
	private String Reason;
	
	@Column(name = "ChangedType", columnDefinition="CHAR(255)", nullable = false)
	private String ChangedType;
	
	@Column(name = "ChangedOn", columnDefinition="DATETIME", nullable = false)
	private String ChangedOn;
	
	@Column(name = "ChangedBy", columnDefinition="VARCHAR(255)", nullable = false)
	private String ChangedBy;
    
    

	

	/**
	 * @return the changedTable
	 */
	public String getChangedTable() {
		return ChangedTable;
	}

	/**
	 * @param changedTable the changedTable to set
	 */
	public void setChangedTable(String changedTable) {
		ChangedTable = changedTable;
	}

	/**
	 * @return the changes
	 */
	public String getChanges() {
		return Changes;
	}

	/**
	 * @param changes the changes to set
	 */
	public void setChanges(String changes) {
		Changes = changes;
	}

	

	/**
	 * @return the reason
	 */
	public String getReason() {
		return Reason;
	}

	/**
	 * @param reason the reason to set
	 */
	public void setReason(String reason) {
		Reason = reason;
	}

	/**
	 * @return the changedType
	 */
	public String getChangedType() {
		return ChangedType;
	}

	/**
	 * @param changedType the changedType to set
	 */
	public void setChangedType(String changedType) {
		ChangedType = changedType;
	}

	/**
	 * @return the changedOn
	 */
	public String getChangedOn() {
		return ChangedOn;
	}

	/**
	 * @param changedOn the changedOn to set
	 */
	public void setChangedOn(String changedOn) {
		ChangedOn = changedOn;
	}

	/**
	 * @return the changedBy
	 */
	public String getChangedBy() {
		return ChangedBy;
	}

	/**
	 * @param changedBy the changedBy to set
	 */
	public void setChangedBy(String changedBy) {
		ChangedBy = changedBy;
	}

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
	 * @return the result
	 */
	public Boolean getResult() {
		return Result;
	}

	/**
	 * @param result the result to set
	 */
	public void setResult(Boolean result) {
		Result = result;
	}
	
}
