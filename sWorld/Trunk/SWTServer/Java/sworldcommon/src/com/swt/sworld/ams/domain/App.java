/**
 * 
 */
package com.swt.sworld.ams.domain;

import java.io.Serializable;

import javax.persistence.*;

/**
 * @author LOCVIP
 *
 */

@Entity
@Table(name = "swtgp_ams_app")

public class App implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 8656940562963683299L;
	
	@Id 
	@GeneratedValue
	@Column(name = "Id", nullable = false)
	private long Id;
	
	@Column(name = "AppCode")
	private String AppCode ;
	
	@Column(name = "NameApp",length=45)
	private String NameApp;
	
	@Column(name = "Alias")
	private byte Alias;
	
	@Column(name = "Description",length=255)
	private String Description;
	
	@Column(name = "ModulesName",length=45)
	private String ModulesName ;
	
	@Column(name = "CountModule")
	private int CountModule;
	
	@Column(name = "StatusApp")
	private boolean StatusApp;

	

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
	 * @return the appCode
	 */
	public String getAppCode() {
		return AppCode;
	}

	/**
	 * @param appCode the appCode to set
	 */
	public void setAppCode(String appCode) {
		AppCode = appCode;
	}

	/**
	 * @return the modulesName
	 */
	public String getModulesName() {
		return ModulesName;
	}

	/**
	 * @param modulesName the modulesName to set
	 */
	public void setModulesName(String modulesName) {
		ModulesName = modulesName;
	}

	/**
	 * @return the countModule
	 */
	public int getCountModule() {
		return CountModule;
	}

	/**
	 * @param countModule the countModule to set
	 */
	public void setCountModule(int countModule) {
		CountModule = countModule;
	}

	

	/**
	 * @return the alias
	 */
	public byte getAlias() {
		return Alias;
	}

	/**
	 * @param alias the alias to set
	 */
	public void setAlias(byte alias) {
		Alias = alias;
	}

	/**
	 * @return the nameApp
	 */
	public String getNameApp() {
		return NameApp;
	}

	/**
	 * @param nameApp the nameApp to set
	 */
	public void setNameApp(String nameApp) {
		NameApp = nameApp;
	}

	/**
	 * @return the statusApp
	 */
	public boolean getStatusApp() {
		return StatusApp;
	}

	/**
	 * @param statusApp the statusApp to set
	 */
	public void setStatusApp(boolean statusApp) {
		StatusApp = statusApp;
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

}
