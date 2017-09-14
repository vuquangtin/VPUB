/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class ItemFilterDto implements Serializable {

	/**
	 * @author Hoang Ha
	 * 
	 */
	private static final long serialVersionUID = -8074841126453621779L;

	private boolean FilterByName ;
	private String Name ;

	private boolean FilterByPrice ;
	private double Price ;
	
	private boolean FilterBystatisticItemDate ;
	private PayInDateStatisticsDto statisticItemDate;

	public String clone()
	{
		String resultSearch = "";
		if(FilterByName)
			resultSearch += " Name LIKE '%"+Name+"%'";
		
		if(resultSearch == "")
		{
			if(FilterByPrice)
			{
				resultSearch += " Price = "+Price;
				
				if(FilterBystatisticItemDate)
				{
					resultSearch += " AND STR_TO_DATE(StartDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticItemDate.getDateIn() +"', '%Y-%m-%d') ";
					resultSearch += " AND STR_TO_DATE(EndDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticItemDate.getDateOut() +"', '%Y-%m-%d') ";
				}
			}			
			else if(FilterBystatisticItemDate)
			{
				resultSearch += " STR_TO_DATE(StartDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticItemDate.getDateIn() +"', '%Y-%m-%d') ";
				resultSearch += " AND STR_TO_DATE(EndDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticItemDate.getDateOut() +"', '%Y-%m-%d') ";
			}
		}
		else
		{
			if(FilterByPrice)
			{
				resultSearch += " AND Price = "+Price;
				
				if(FilterBystatisticItemDate)
				{					
					resultSearch += " AND STR_TO_DATE(StartDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticItemDate.getDateIn() +"', '%Y-%m-%d') ";
					resultSearch += " AND STR_TO_DATE(EndDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticItemDate.getDateOut() +"', '%Y-%m-%d') ";
				}
			}			
			else if(FilterBystatisticItemDate)
			{
				resultSearch += " AND STR_TO_DATE(StartDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticItemDate.getDateIn() +"', '%Y-%m-%d') ";
				resultSearch += " AND STR_TO_DATE(EndDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticItemDate.getDateOut() +"', '%Y-%m-%d') ";
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

	public boolean isFilterByPrice() {
		return FilterByPrice;
	}

	public void setFilterByPrice(boolean filterByPrice) {
		FilterByPrice = filterByPrice;
	}

	public double getPrice() {
		return Price;
	}

	public void setPrice(double price) {
		Price = price;
	}

	public boolean isFilterBystatisticItemDate() {
		return FilterBystatisticItemDate;
	}

	public void setFilterBystatisticItemDate(boolean filterBystatisticItemDate) {
		FilterBystatisticItemDate = filterBystatisticItemDate;
	}

	public PayInDateStatisticsDto getStatisticItemDate() {
		return statisticItemDate;
	}

	public void setStatisticItemDate(PayInDateStatisticsDto statisticItemDate) {
		this.statisticItemDate = statisticItemDate;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}	
}
