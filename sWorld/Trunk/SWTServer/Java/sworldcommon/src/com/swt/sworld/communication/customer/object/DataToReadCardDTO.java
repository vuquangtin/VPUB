/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
import java.util.List;

/**
 * @author Administrator
 *
 */
public class DataToReadCardDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1587170594295352143L;
	
	private List<KeyDTO> KEY ;
	private byte Status ;
	private String LicenseServer ;
	
//	public DataToReadCardDTO(List<KeyDTO> KEY ,byte Status , String LicenseServer)
//	{
//		this.KEY = KEY;
//		this.Status = Status;
//		this.LicenseServer = LicenseServer;
//	}
	
	/**
	 * @return the kEY
	 */
	public List<KeyDTO> getKEY() {
		return KEY;
	}
	/**
	 * @param kEY the kEY to set
	 */
	public void setKEY(List<KeyDTO> kEY) {
		KEY = kEY;
	}
	/**
	 * @return the status
	 */
	public byte getStatus() {
		return Status;
	}
	/**
	 * @param status the status to set
	 */
	public void setStatus(byte status) {
		Status = status;
	}
	/**
	 * @return the licenseServer
	 */
	public String getLicenseServer() {
		return LicenseServer;
	}
	/**
	 * @param licenseServer the licenseServer to set
	 */
	public void setLicenseServer(String licenseServer) {
		LicenseServer = licenseServer;
	}

}
