package com.swt.saigonpearl.domain;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;


@Entity
@Table(name = "swtgp_sbuilding_manager_costs")
public class ManagerCosts {

	@Id
	@GeneratedValue
	@Column(name = "Id", nullable = false)
	private long Id;
	
	@Column(name = "SubOrgId", nullable = false)
	private long SubOrgId;
	
	@Column(name = "SubOrgCode")
	private String SubOrgCode;
	
	@Column(name = "NameHeadApartment", length = 50)
	private String NameHeadApartment;
	
	@Column(name = "PayManager")
	private double PayManager;
	
	@Column(name = "PayWater")
	private double PayWater;
	
	@Column(name = "DayPay", length = 50)
	private String DayPay;
	
	@Column(name = "ManagerCostOld", length = 50)
	private double ManagerCostOld;
	
	@Column(name = "SumMoney")
	private double SumMoney;

	@Column(name = "Active")
	private Boolean Active;
	
	@Column(name = "CreatedBy", length=20)
	private String CreatedBy;
	
	@Column(name = "CreatedDate", length=20)
	private String CreatedDate;
	
	@Column(name = "ModifiedBy", length=20)
	private String ModifiedBy;
	
	@Column(name = "ModifieDate", length=20)
	private String ModifieDate;
	
	@Column(name = "Status")
	private int Status;

	public long getId() {
		return Id;
	}

	public void setId(long id) {
		Id = id;
	}
	

	public String getSubOrgCode() {
		return SubOrgCode;
	}

	public void setSubOrgCode(String subOrgCode) {
		SubOrgCode = subOrgCode;
	}

	public long getSubOrgId() {
		return SubOrgId;
	}

	public void setSubOrgId(long subOrgId) {
		SubOrgId = subOrgId;
	}

	public String getNameHeadApartment() {
		return NameHeadApartment;
	}

	public void setNameHeadApartment(String nameHeadApartment) {
		NameHeadApartment = nameHeadApartment;
	}

	public double getPayManager() {
		return PayManager;
	}

	public void setPayManager(double payManager) {
		PayManager = payManager;
	}

	public double getPayWater() {
		return PayWater;
	}

	public void setPayWater(double payWater) {
		PayWater = payWater;
	}

	public String getDayPay() {
		return DayPay;
	}

	public void setDayPay(String dayPay) {
		DayPay = dayPay;
	}

	

	public double getManagerCostOld() {
		return ManagerCostOld;
	}

	public void setManagerCostOld(double managerCostOld) {
		ManagerCostOld = managerCostOld;
	}

	public double getSumMoney() {
		return SumMoney;
	}

	public void setSumMoney(double sumMoney) {
		SumMoney = sumMoney;
	}


	public Boolean getActive() {
		return Active;
	}

	public void setActive(Boolean active) {
		Active = active;
	}

	public String getCreatedBy() {
		return CreatedBy;
	}

	public void setCreatedBy(String createdBy) {
		CreatedBy = createdBy;
	}

	public String getCreatedDate() {
		return CreatedDate;
	}

	public void setCreatedDate(String createdDate) {
		CreatedDate = createdDate;
	}

	public String getModifiedBy() {
		return ModifiedBy;
	}

	public void setModifiedBy(String modifiedBy) {
		ModifiedBy = modifiedBy;
	}

	public String getModifieDate() {
		return ModifieDate;
	}

	public void setModifieDate(String modifieDate) {
		ModifieDate = modifieDate;
	}

	public int getStatus() {
		return Status;
	}

	public void setStatus(int status) {
		Status = status;
	}

	
		
}
