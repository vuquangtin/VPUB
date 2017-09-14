package com.swt.sworld.cms.domain;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;



@Entity
@Table(name = "swtgp_cms_partners")
public class PartnersOfMaster implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 8290555800364030149L;

	@Id
	@GeneratedValue
	@Column(name = "id")
	private long id;
	
	@Column(name = "masterid")
	private long masterid;
	
	@Column(name = "issuer")
	private String issuer;
	
	@Column(name = "partnerid")
	private long partnerid;
	
	@Column(name = "partnercode")
	private String partnercode;

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public long getMasterid() {
		return masterid;
	}

	public void setMasterid(long masterid) {
		this.masterid = masterid;
	}

	public String getPartnercode() {
		return partnercode;
	}

	public void setPartnercode(String partnercode) {
		this.partnercode = partnercode;
	}


	public String getIssuer() {
		return issuer;
	}

	public void setIssuer(String issuer) {
		this.issuer = issuer;
	}

	public long getPartnerid() {
		return partnerid;
	}

	public void setPartnerid(long partnerid) {
		this.partnerid = partnerid;
	}

	
}
