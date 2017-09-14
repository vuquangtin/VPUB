package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
import java.util.List;

public class ResultCheckCardDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -7990702304840748808L;
	private byte HMK_ALIAS;
	private byte DMKA_ALIAS;
	private byte DMKB_ALIAS;
	private byte PVK_ALIAS;
	private List<KeyDTO> KEY;
	private String LicenseServer; // string has format hex
	private String License; // string has format hex
	private int Status;
	
	public byte getHMK_ALIAS() {
		return HMK_ALIAS;
	}
	public void setHMK_ALIAS(byte hMK_ALIAS) {
		HMK_ALIAS = hMK_ALIAS;
	}
	public byte getDMKA_ALIAS() {
		return DMKA_ALIAS;
	}
	public void setDMKA_ALIAS(byte dMKA_ALIAS) {
		DMKA_ALIAS = dMKA_ALIAS;
	}
	public byte getDMKB_ALIAS() {
		return DMKB_ALIAS;
	}
	public void setDMKB_ALIAS(byte dMKB_ALIAS) {
		DMKB_ALIAS = dMKB_ALIAS;
	}
	public byte getPVK_ALIAS() {
		return PVK_ALIAS;
	}
	public void setPVK_ALIAS(byte pVK_ALIAS) {
		PVK_ALIAS = pVK_ALIAS;
	}
	public List<KeyDTO> getKEY() {
		return KEY;
	}
	public void setKEY(List<KeyDTO> kEY) {
		KEY = kEY;
	}
	public String getLicenseServer() {
		return LicenseServer;
	}
	public void setLicenseServer(String licenseServer) {
		LicenseServer = licenseServer;
	}
	public String getLicense() {
		return License;
	}
	public void setLicense(String license) {
		License = license;
	}
	public int getStatus() {
		return Status;
	}
	public void setStatus(int status) {
		Status = status;
	}
}
