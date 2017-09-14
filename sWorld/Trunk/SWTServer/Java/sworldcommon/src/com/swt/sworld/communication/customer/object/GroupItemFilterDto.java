/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class GroupItemFilterDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -8074841126453621779L;
	
	private boolean FilterByName ;
	private String Name ;
	
	public String clone()
	{
		String resultSearch = "";
		if(FilterByName)
			resultSearch += " Name title LIKE '%"+Name+"%'";
		return resultSearch;
	}

	public boolean isFilterByName() {
		return FilterByName;
	}

	public void setFilterByName(boolean filterByName) {
		FilterByName = filterByName;
	}

	public String getName() {
		return Name;
	}

	public void setName(String name) {
		Name = name;
	}
	
}
