package com.swt.saigonpearl.domain;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;


/**
 * @author Cong thanh
 * 
 */
@Entity
@Table(name = "swtgp_sbuilding_config_apartment")
public class ConfigApartment {

	@Id
	@GeneratedValue
	@Column(name = "Id", nullable = false)
	private long Id;
	
	
	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}

	public String getNumberMonthPay() {
		return NumberMonthPay;
	}

	public void setNumberMonthPay(String numberMonthPay) {
		NumberMonthPay = numberMonthPay;
	}

	public int getStatus() {
		return Status;
	}

	public void setStatus(int status) {
		Status = status;
	}

	@Column(name = "NumberMonthPay", length = 50)
	private String NumberMonthPay;
	
	/*
	 * <summary> 0: Successful 1: Processing  </summary>
	 */
	@Column(name = "Status")
	private int Status;
}
