/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class TransactionFilterDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 2852286762067825437L;
	
	private String sdtOrSerial ;

	private String dateBegin ;

	private String dateEnd ;
	
	public String clone()
	{
		String resultSearch = "";
		if(sdtOrSerial != null)
		{
			resultSearch += " phone_number LIKE '%"+sdtOrSerial+"%' OR serialcard_number LIKE '%"+sdtOrSerial+"%'";
		}
		
		if(resultSearch != "")
		{
			if(dateBegin != null)
			{
				resultSearch += " AND STR_TO_DATE(date_updated, '%Y-%m-%d') >= STR_TO_DATE('"+ dateBegin +"', '%Y-%m-%d') ";
			}
		}
		else
		{
			if(dateBegin != null)
			{
				resultSearch += " STR_TO_DATE(date_updated, '%Y-%m-%d') >= STR_TO_DATE('"+ dateBegin +"', '%Y-%m-%d') ";
			}
		}
		
		if(resultSearch != "")
		{
			if(dateEnd != null)
			{
				resultSearch += " AND STR_TO_DATE(date_updated, '%Y-%m-%d') <= STR_TO_DATE('"+ dateEnd +"', '%Y-%m-%d') ";
			}
		}
		else
		{
			if(dateEnd != null)
			{
				resultSearch += " STR_TO_DATE(date_updated, '%Y-%m-%d') <= STR_TO_DATE('"+ dateEnd +"', '%Y-%m-%d') ";
			}
		}
		
		
		return resultSearch;
	}

	/**
	 * @return the sdtOrSerial
	 */
	public String getSdtOrSerial() {
		return sdtOrSerial;
	}

	/**
	 * @param sdtOrSerial the sdtOrSerial to set
	 */
	public void setSdtOrSerial(String sdtOrSerial) {
		this.sdtOrSerial = sdtOrSerial;
	}

	/**
	 * @return the dateBegin
	 */
	public String getDateBegin() {
		return dateBegin;
	}

	/**
	 * @param dateBegin the dateBegin to set
	 */
	public void setDateBegin(String dateBegin) {
		this.dateBegin = dateBegin;
	}

	/**
	 * @return the dateEnd
	 */
	public String getDateEnd() {
		return dateEnd;
	}

	/**
	 * @param dateEnd the dateEnd to set
	 */
	public void setDateEnd(String dateEnd) {
		this.dateEnd = dateEnd;
	}

}
