/**
 * 
 */
package com.swt.sworld.customer.object;

import java.util.List;

/**
 * @author Tenit
 *
 */
public class DeviceDoorGroupPostToServer {
	private List<Long> lstIdGroupBeforeCheck;
	private List<Long> lstIdGroupAfterCheck;

	public List<Long> getLstIdGroupBeforeCheck() {
		return lstIdGroupBeforeCheck;
	}

	public void setLstIdGroupBeforeCheck(List<Long> lstIdGroupBeforeCheck) {
		this.lstIdGroupBeforeCheck = lstIdGroupBeforeCheck;
	}

	public List<Long> getLstIdGroupAfterCheck() {
		return lstIdGroupAfterCheck;
	}

	public void setLstIdGroupAfterCheck(List<Long> lstIdGroupAfterCheck) {
		this.lstIdGroupAfterCheck = lstIdGroupAfterCheck;
	}

}
