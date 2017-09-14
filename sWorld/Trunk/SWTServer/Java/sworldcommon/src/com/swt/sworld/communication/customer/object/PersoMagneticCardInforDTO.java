package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
import java.util.List;

public class PersoMagneticCardInforDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 8373336892770997113L;
	private long masterid;
	private long partnerid;
	private String mastercode;
	private String partnercode;
	private String prefix;
	private int isdefault;
	private int count;
	private String ExpiredTime;
	private List<MemberDataExcelDto> listperso;
	private int logicalstatus;
	private int physicalstatus;
	private long SubOrgId;
	
	
	public long getMasterid() {
		return masterid;
	}
	public void setMasterid(long masterid) {
		this.masterid = masterid;
	}
	public long getPartnerid() {
		return partnerid;
	}
	public void setPartnerid(long partnerid) {
		this.partnerid = partnerid;
	}
	public String getMastercode() {
		return mastercode;
	}
	public void setMastercode(String mastercode) {
		this.mastercode = mastercode;
	}
	public String getPartnercode() {
		return partnercode;
	}
	public void setPartnercode(String partnercode) {
		this.partnercode = partnercode;
	}
	public int getIsdefault() {
		return isdefault;
	}
	public void setIsdefault(int isdefault) {
		this.isdefault = isdefault;
	}
	public int getCount() {
		return count;
	}
	public void setCount(int count) {
		this.count = count;
	}
	public String getExpiredTime() {
		return ExpiredTime;
	}
	public void setExpiredTime(String expiredTime) {
		ExpiredTime = expiredTime;
	}
	public List<MemberDataExcelDto> getListperso() {
		return listperso;
	}
	public void setListperso(List<MemberDataExcelDto> listperso) {
		this.listperso = listperso;
	}
	public String getPrefix() {
		return prefix;
	}
	public void setPrefix(String prefix) {
		this.prefix = prefix;
	}
	public int getLogicalstatus() {
		return logicalstatus;
	}
	public void setLogicalstatus(int logicalstatus) {
		this.logicalstatus = logicalstatus;
	}
	public int getPhysicalstatus() {
		return physicalstatus;
	}
	public void setPhysicalstatus(int phisicalstatus) {
		this.physicalstatus = phisicalstatus;
	}
	/**
	 * @return the subOrgId
	 */
	public long getSubOrgId() {
		return SubOrgId;
	}
	/**
	 * @param subOrgId the subOrgId to set
	 */
	public void setSubOrgId(long subOrgId) {
		SubOrgId = subOrgId;
	}
}
