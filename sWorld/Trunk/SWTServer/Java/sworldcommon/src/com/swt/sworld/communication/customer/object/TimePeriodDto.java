/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class TimePeriodDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -3094993505428022520L;
	
	private String Start ;
    private String End ;
	/**
	 * @return the start
	 */
	public String getStart() {
		return Start;
	}
	/**
	 * @param start the start to set
	 */
	public void setStart(String start) {
		Start = start;
	}
	/**
	 * @return the end
	 */
	public String getEnd() {
		return End;
	}
	/**
	 * @param end the end to set
	 */
	public void setEnd(String end) {
		End = end;
	}

}
