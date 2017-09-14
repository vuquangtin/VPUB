/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

public class SubOrgFilterDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -4044370452816426040L;

	private String ListParamsType;
	private String ListParamsValue;
	private String Status;
	
	public String clone()
	{
		String resultSearch = "";
		if(ListParamsType != "")
			resultSearch += " Status = '" + ListParamsType + "'";
		
		if(resultSearch == "")
		{
			if(ListParamsValue != "")
				resultSearch += " GroupId = " + ListParamsValue + "'";
		}
		else
		{
			if(Status != "")
				resultSearch += " AND GroupId = " + Status + "'";
		}
		return resultSearch;
	}

	/**
	 * @return the listParamsType
	 */
	public String getListParamsType() {
		return ListParamsType;
	}

	/**
	 * @param listParamsType
	 *            the listParamsType to set
	 */
	public void setListParamsType(String listParamsType) {
		ListParamsType = listParamsType;
	}

	/**
	 * @return the listParamsValue
	 */
	public String getListParamsValue() {
		return ListParamsValue;
	}

	/**
	 * @param listParamsValue
	 *            the listParamsValue to set
	 */
	public void setListParamsValue(String listParamsValue) {
		ListParamsValue = listParamsValue;
	}

	/**
	 * @return the status
	 */
	public String getStatus() {
		return Status;
	}

	/**
	 * @param status
	 *            the status to set
	 */
	public void setStatus(String status) {
		Status = status;
	}

}
