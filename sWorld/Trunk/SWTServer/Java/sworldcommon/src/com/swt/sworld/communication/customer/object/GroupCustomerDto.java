/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;
import java.util.List;

import com.swt.sworld.common.domain.PolicySworld;

/**
 * @author Administrator
 *
 */
public class GroupCustomerDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1662836811202504156L;
	
	private long Id ;
	private String Name ;
	private String Description ;
	private List<PolicySworld> PolicySworlds ;
	
	public GroupCustomerDto(long Id, String Name, String Description,
			List<PolicySworld> policySworlds)
	{
		this.Id= Id;
		this.Name = Name;
		this.Description = Description;
		this.setPolicySworlds(policySworlds);
	}
	

	public GroupCustomerDto() {
		// TODO Auto-generated constructor stub
	}

	/**
	 * @return the id
	 */
	public long getId() {
		return Id;
	}
	/**
	 * @param id the id to set
	 */
	public void setId(long id) {
		Id = id;
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
	 * @return the policySworlds
	 */
	public List<PolicySworld> getPolicySworlds() {
		return PolicySworlds;
	}


	/**
	 * @param policySworlds the policySworlds to set
	 */
	public void setPolicySworlds(List<PolicySworld> policySworlds) {
		PolicySworlds = policySworlds;
	}


//	/**
//	 * @return the policies
//	 */
//	public List<PolicySworld> getPolicies() {
//		return PolicySworlds;
//	}
//
//
//	/**
//	 * @param policySworlds the policies to set
//	 */
//	public void setPolicies(List<PolicySworld> policySworlds) {
//		PolicySworlds = policySworlds;
//	}

}
