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
public class DataToWriteCardDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8977628840408857208L;
	
	private List<KeyDTO> KEY ;
	private String Data ;// lam theo object DataForReadCard
	private String LicenseServer ;
	private String Split;
	
//	public DataToWriteCardDTO(List<KeyDTO> KEY, Member MemberData, byte Status,String LicenseServer)
//	{
//		this.KEY =KEY;
//		this.MemberData = MemberData;
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
	/**
	 * @return the split
	 */
	public String getSplit() {
		return Split;
	}
	/**
	 * @param split the split to set
	 */
	public void setSplit(String split) {
		Split = split;
	}
	/**
	 * @return the data
	 */
	public String getData() {
		return Data;
	}
	/**
	 * @param data the data to set
	 */
	public void setData(String data) {
		Data = data;
	}

}
