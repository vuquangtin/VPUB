/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
import java.util.List;

public class PartnerInfoDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 6326816422017918009L;
	private long masterId;
	private long partnerid;
	private String OrgShortName;
	private String Name;
	private KeyDTO key;
	private String code;
	private List<CardTypeDTO> cardtypes;

	public PartnerInfoDto(long masterid, long partnerid, String shortName,
			String name, KeyDTO key, String code, List<CardTypeDTO> cards) {
		this.setMasterId(masterid);
		this.setPartnerid(partnerid);
		this.OrgShortName = shortName;
		this.Name = name;
		this.key = key;
		this.code = code;
		this.setCardtypes(cards);
	}

	/**
	 * @return the orgShortName
	 */
	public String getOrgShortName() {
		return OrgShortName;
	}

	/**
	 * @param orgShortName
	 *            the orgShortName to set
	 */
	public void setOrgShortName(String orgShortName) {
		OrgShortName = orgShortName;
	}

	/**
	 * @return the name
	 */
	public String getName() {
		return Name;
	}

	/**
	 * @param name
	 *            the name to set
	 */
	public void setName(String name) {
		Name = name;
	}

	public long getMasterId() {
		return masterId;
	}

	public void setMasterId(long masterId) {
		this.masterId = masterId;
	}

	public long getPartnerid() {
		return partnerid;
	}

	public void setPartnerid(long partnerid) {
		this.partnerid = partnerid;
	}

	public KeyDTO getKey() {
		return key;
	}

	public void setKey(KeyDTO key) {
		this.key = key;
	}

	public String getCode() {
		return code;
	}

	public void setCode(String code) {
		this.code = code;
	}

	public List<CardTypeDTO> getCardtypes() {
		return cardtypes;
	}

	public void setCardtypes(List<CardTypeDTO> cardtypes) {
		this.cardtypes = cardtypes;
	}

	
}