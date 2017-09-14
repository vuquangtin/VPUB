/**
 * 
 */
package com.swt.sworld.communication.customer.object;

/**
 * @author Administrator
 *
 */
public class MethodResultDto {
	
	private String Subject ;
	private String Action ;
	private boolean Result ;
	private String Detail ;
	
	public MethodResultDto(String Subject, String Action, boolean Result,
			String Detail)
	{
		this.Subject = Subject;
		this.Action = Action;
		this.Result = Result;
		this.Detail = Detail;
	}
	
	/**
	 * @return the subject
	 */
	public String getSubject() {
		return Subject;
	}
	/**
	 * @param subject the subject to set
	 */
	public void setSubject(String subject) {
		Subject = subject;
	}
	/**
	 * @return the result
	 */
	public boolean isResult() {
		return Result;
	}
	/**
	 * @param result the result to set
	 */
	public void setResult(boolean result) {
		Result = result;
	}
	/**
	 * @return the action
	 */
	public String getAction() {
		return Action;
	}
	/**
	 * @param action the action to set
	 */
	public void setAction(String action) {
		Action = action;
	}
	/**
	 * @return the detail
	 */
	public String getDetail() {
		return Detail;
	}
	/**
	 * @param detail the detail to set
	 */
	public void setDetail(String detail) {
		Detail = detail;
	}

}
