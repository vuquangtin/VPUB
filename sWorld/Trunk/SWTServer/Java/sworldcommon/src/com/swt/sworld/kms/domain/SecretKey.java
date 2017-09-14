/**
 * 
 */
package com.swt.sworld.kms.domain;

import java.io.Serializable;

import javax.persistence.*;

/**
 * @author LOCVIP
 *
 */

@Entity
@Table(name = "swtgp_kms_secret_key")

public class SecretKey implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 6732926110688880787L;

	@Id 
	@GeneratedValue
	@Column(name = "Id")
	private long SecretKeyId ;
	
	@Column(name = "HsmId", nullable = false)
	private long HsmId ;
	
	@Column(name = "Alias")
	private long Alias;
	
	@Column(name = "Name", length = 255)
	private String Name ;
	
	@Column(name = "KeyValue", length=1024)
	private String KeyValue ;
	
	@Column(name = "PriKeyLicense", length=1024)
	private String PriKeyLicense ;
	
	@Column(name = "PubKeyLicense", length=1024)
	private String PubKeyLicense ;
	
	@Column(name = "PriKeyServer", length=1024)
	private String PriKeyServer ;
	
	@Column(name = "PubKeyServer", length=1024)
	private String PubKeyServer ;
	
	@Column(name = "KeyBHM", length=1024)
	private String KeyBHM ;
	
	@Column(name = "KeyADM", length=1024)
	private String KeyADM ;
	
	@Column(name = "KeyBDM", length=1024)
	private String KeyBDM ;
	
	@Column(name = "Owner", length = 255)
	private int owner;
	
	@Column(name = "Description")
	private String Description ;
	
	
	@Column(name = "Status")
	private Boolean Status ;

	/**
	 * @return the secretKeyId
	 */
	public long getSecretKeyId() {
		return SecretKeyId;
	}

	/**
	 * @param secretKeyId the secretKeyId to set
	 */
	public void setSecretKeyId(long secretKeyId) {
		SecretKeyId = secretKeyId;
	}

	/**
	 * @return the hsmId
	 */
	public long getHsmId() {
		return HsmId;
	}

	/**
	 * @param hsmId the hsmId to set
	 */
	public void setHsmId(long hsmId) {
		HsmId = hsmId;
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
	public Boolean getStatus() {
		return Status;
	}

	/**
	 * @param status the status to set
	 */
	public void setStatus(Boolean status) {
		Status = status;
	}
	
	public int getOwner() {
		return owner;
	}

	public void setOwner(int owner) {
		this.owner = owner;
	}

	public String getKeyBHM() {
		return KeyBHM;
	}

	public void setKeyBHM(String keyBHM) {
		KeyBHM = keyBHM;
	}

	public String getPriKeyLicense() {
		return PriKeyLicense;
	}

	public void setPriKeyLicense(String priKeyLicense) {
		PriKeyLicense = priKeyLicense;
	}

	public String getPubKeyLicense() {
		return PubKeyLicense;
	}

	public void setPubKeyLicense(String pubKeyLicense) {
		PubKeyLicense = pubKeyLicense;
	}

	public String getPriKeyServer() {
		return PriKeyServer;
	}

	public void setPriKeyServer(String priKeyServer) {
		PriKeyServer = priKeyServer;
	}

	public String getPubKeyServer() {
		return PubKeyServer;
	}

	public void setPubKeyServer(String pubKeyServer) {
		PubKeyServer = pubKeyServer;
	}

	public String getKeyADM() {
		return KeyADM;
	}

	public void setKeyADM(String keyADM) {
		KeyADM = keyADM;
	}

	public String getKeyBDM() {
		return KeyBDM;
	}

	public void setKeyBDM(String keyBDM) {
		KeyBDM = keyBDM;
	}

	public long getAlias() {
		return Alias;
	}

	public void setAlias(long alias) {
		Alias = alias;
	}

	public String getKeyValue() {
		return KeyValue;
	}

	public void setKeyValue(String keyValue) {
		KeyValue = keyValue;
	}

}
