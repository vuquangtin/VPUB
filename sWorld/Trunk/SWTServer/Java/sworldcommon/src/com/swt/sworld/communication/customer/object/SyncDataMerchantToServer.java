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
public class SyncDataMerchantToServer implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8624980704388420860L;
	
	private String merchant_unix;
	private String merchant_ip;
	
	private List<SyncDataTransaction> list_tran_udpated;

	/**
	 * @return the merchant_unix
	 */
	public String getMerchant_unix() {
		return merchant_unix;
	}

	/**
	 * @param merchant_unix the merchant_unix to set
	 */
	public void setMerchant_unix(String merchant_unix) {
		this.merchant_unix = merchant_unix;
	}

	/**
	 * @return the merchant_ip
	 */
	public String getMerchant_ip() {
		return merchant_ip;
	}

	/**
	 * @param merchant_ip the merchant_ip to set
	 */
	public void setMerchant_ip(String merchant_ip) {
		this.merchant_ip = merchant_ip;
	}

	/**
	 * @return the list_tran_udpated
	 */
	public List<SyncDataTransaction> getList_tran_udpated() {
		return list_tran_udpated;
	}

	/**
	 * @param list_tran_udpated the list_tran_udpated to set
	 */
	public void setList_tran_udpated(List<SyncDataTransaction> list_tran_udpated) {
		this.list_tran_udpated = list_tran_udpated;
	}
	

}
