package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

public class ConfigCardFilterDto implements Serializable {

	private static final long serialVersionUID = -8074841126453621779L;
	
	private boolean FilterByName ;
	private String Name ;

	private boolean FilterByAmount ;
	private double Amount ;
	
	private boolean FilterBystatisticPayInDate ;
	private PayInDateStatisticsDto statisticPayInDate;

	public String clone()
	{
		String resultSearch = "";
		if(FilterByName)
			resultSearch += " Name LIKE '%"+Name+"%'";
		
		if(resultSearch == "")
		{
			if(FilterByAmount)
			{
				resultSearch += " Amount = "+Amount;
				
				if(FilterBystatisticPayInDate)
				{
					resultSearch += " AND STR_TO_DATE(StartDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%Y-%m-%d') ";
					resultSearch += " AND STR_TO_DATE(EndDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%Y-%m-%d') ";
				}
			}			
			else if(FilterBystatisticPayInDate)
			{
				resultSearch += " STR_TO_DATE(StartDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%Y-%m-%d') ";
				resultSearch += " AND STR_TO_DATE(EndDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%Y-%m-%d') ";
			}
		}
		else
		{
			if(FilterByAmount)
			{
				resultSearch += " AND Amount = "+Amount;
				
				if(FilterBystatisticPayInDate)
				{
					resultSearch += " AND STR_TO_DATE(StartDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%Y-%m-%d') ";
					resultSearch += " AND STR_TO_DATE(EndDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%Y-%m-%d') ";
				}
			}			
			else if(FilterBystatisticPayInDate)
			{
				resultSearch += " AND STR_TO_DATE(StartDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%Y-%m-%d') ";
				resultSearch += " AND STR_TO_DATE(EndDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%Y-%m-%d') ";
			}
		}
	
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

	public boolean isFilterByAmount() {
		return FilterByAmount;
	}

	public void setFilterByAmount(boolean filterByAmount) {
		FilterByAmount = filterByAmount;
	}

	public double getAmount() {
		return Amount;
	}

	public void setAmount(double amount) {
		Amount = amount;
	}

	public boolean isFilterBystatisticPayInDate() {
		return FilterBystatisticPayInDate;
	}

	public void setFilterBystatisticPayInDate(boolean filterBystatisticPayInDate) {
		FilterBystatisticPayInDate = filterBystatisticPayInDate;
	}

	public PayInDateStatisticsDto getStatisticPayInDate() {
		return statisticPayInDate;
	}

	public void setStatisticPayInDate(PayInDateStatisticsDto statisticPayInDate) {
		this.statisticPayInDate = statisticPayInDate;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}
	
}
