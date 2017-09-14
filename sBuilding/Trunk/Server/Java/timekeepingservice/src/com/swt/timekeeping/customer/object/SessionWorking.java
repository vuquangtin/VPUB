package com.swt.timekeeping.customer.object;

public class SessionWorking {
	 private int isCheckSession;
     
	 private int hoursBegin;
    
	 private int minuteBegin;
   
	 private int hoursEnd; 
    
	 private int minuteEnd;

	public SessionWorking(int isCheckSession, int hoursBegin, int minuteBegin,
			int hoursEnd, int minuteEnd) {
		super();
		this.isCheckSession = isCheckSession;
		this.hoursBegin = hoursBegin;
		this.minuteBegin = minuteBegin;
		this.hoursEnd = hoursEnd;
		this.minuteEnd = minuteEnd;
	}

	public int getIsCheckSession() {
		return isCheckSession;
	}

	public void setIsCheckSession(int isCheckSession) {
		this.isCheckSession = isCheckSession;
	}

	public int getHoursBegin() {
		return hoursBegin;
	}

	public void setHoursBegin(int hoursBegin) {
		this.hoursBegin = hoursBegin;
	}

	public int getMinuteBegin() {
		return minuteBegin;
	}

	public void setMinuteBegin(int minuteBegin) {
		this.minuteBegin = minuteBegin;
	}

	public int getHoursEnd() {
		return hoursEnd;
	}

	public void setHoursEnd(int hoursEnd) {
		this.hoursEnd = hoursEnd;
	}

	public int getMinuteEnd() {
		return minuteEnd;
	}

	public void setMinuteEnd(int minuteEnd) {
		this.minuteEnd = minuteEnd;
	} 
	 
	 
}
