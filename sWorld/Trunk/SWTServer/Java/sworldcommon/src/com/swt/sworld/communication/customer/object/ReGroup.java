/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
import java.util.List;

import javax.xml.bind.annotation.XmlRootElement;

/**
 * @author Administrator
 *
 */
@XmlRootElement
public class ReGroup implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1889845939954614811L;
	private List<GroupSync> lstGroup;
	public ReGroup(){
		
	}
	/**
	 * @return the lstGroup
	 */
	public List<GroupSync> getLstGroup() {
		return lstGroup;
	}
	/**
	 * @param lstGroup the lstGroup to set
	 */
	public void setLstGroup(List<GroupSync> lstGroup) {
		this.lstGroup = lstGroup;
	}
	
}
