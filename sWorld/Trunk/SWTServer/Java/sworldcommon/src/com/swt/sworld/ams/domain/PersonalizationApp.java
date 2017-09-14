/**
 * 
 */
package com.swt.sworld.ams.domain;

import javax.persistence.*;

/**
 * @author LOCVIP
 *
 */

@Entity
@Table(name = "swt_ams_personalization_app")

public class PersonalizationApp {
	
	@Id 
	@GeneratedValue
	@Column(name = "Id")
	private long Id;
	
	@Column(name = "PersoId", nullable = false)
	private long PersoId;
	
	@Column(name = "AppId", nullable = false)
	private long AppId;
	
	@Column(name = "AppMasterKeyId")
	private int AppMasterKeyId;
	
	@Column(name = "StartSectorNumber", nullable = false)
	private int StartSectorNumber;
	
	@Column(name = "MaxSectorUsed", nullable = false)
	private int MaxSectorUsed;
	
	@Column(name = "LastMemberDataUpdatedOn", nullable = false)
	private String LastMemberDataUpdatedOn;

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
	 * @return the persoId
	 */
	public long getPersoId() {
		return PersoId;
	}

	/**
	 * @param persoId the persoId to set
	 */
	public void setPersoId(long persoId) {
		PersoId = persoId;
	}

	/**
	 * @return the appMasterKeyId
	 */
	public int getAppMasterKeyId() {
		return AppMasterKeyId;
	}

	/**
	 * @param appMasterKeyId the appMasterKeyId to set
	 */
	public void setAppMasterKeyId(int appMasterKeyId) {
		AppMasterKeyId = appMasterKeyId;
	}

	/**
	 * @return the startSectorNumber
	 */
	public int getStartSectorNumber() {
		return StartSectorNumber;
	}

	/**
	 * @param startSectorNumber the startSectorNumber to set
	 */
	public void setStartSectorNumber(int startSectorNumber) {
		StartSectorNumber = startSectorNumber;
	}

	/**
	 * @return the maxSectorUsed
	 */
	public int getMaxSectorUsed() {
		return MaxSectorUsed;
	}

	/**
	 * @param maxSectorUsed the maxSectorUsed to set
	 */
	public void setMaxSectorUsed(int maxSectorUsed) {
		MaxSectorUsed = maxSectorUsed;
	}

	/**
	 * @return the lastMemberDataUpdatedOn
	 */
	public String getLastMemberDataUpdatedOn() {
		return LastMemberDataUpdatedOn;
	}

	/**
	 * @param lastMemberDataUpdatedOn the lastMemberDataUpdatedOn to set
	 */
	public void setLastMemberDataUpdatedOn(String lastMemberDataUpdatedOn) {
		LastMemberDataUpdatedOn = lastMemberDataUpdatedOn;
	}

}
