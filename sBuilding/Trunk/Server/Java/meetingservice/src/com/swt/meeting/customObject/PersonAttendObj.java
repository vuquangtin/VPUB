package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.List;
/**
 * 
 * @author TaiMai
 * dung de gui qua client
 * them sum de clien phan trang
 */
public class PersonAttendObj implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private List<PersonAttend> personAttends;
	private long sum;

	public List<PersonAttend> getPersonAttends() {
		return personAttends;
	}

	public void setPersonAttends(List<PersonAttend> personAttends) {
		this.personAttends = personAttends;
	}

	public long getSum() {
		return sum;
	}

	public void setSum(long sum) {
		this.sum = sum;
	}

}
