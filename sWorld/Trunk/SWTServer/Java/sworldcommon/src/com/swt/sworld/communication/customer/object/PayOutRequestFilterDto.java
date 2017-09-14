package com.swt.sworld.communication.customer.object;

public class PayOutRequestFilterDto {

	private boolean FilterBySerialNumber ;
	private String SerialNumber ;

	private boolean FilterByAmount ;
	private double Amount ;
	
	private boolean FilterBystatisticPayOutDate ;
	private PayInDateStatisticsDto statisticPayOutDate;

	public String clone()
	{
		String resultSearch = "";
		if(FilterBySerialNumber)
			resultSearch += " SerialNumber = '" + SerialNumber.trim() + "'";
		
		if(resultSearch == "")
		{
			if(FilterByAmount)
			{
				resultSearch += " Amount = " + Amount;
				
				if(FilterBystatisticPayOutDate)
				{
					resultSearch += " AND STR_TO_DATE(PayOutDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayOutDate.getDateIn() +"', '%Y-%m-%d') ";
					resultSearch += " AND STR_TO_DATE(PayOutDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayOutDate.getDateOut() +"', '%Y-%m-%d') ";
				}
			}			
			else if(FilterBystatisticPayOutDate)
			{
				resultSearch += " STR_TO_DATE(PayOutDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayOutDate.getDateIn() +"', '%Y-%m-%d') ";
				resultSearch += " AND STR_TO_DATE(PayOutDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayOutDate.getDateOut() +"', '%Y-%m-%d') ";
			}
		}
		else
		{
			if(FilterByAmount)
			{
				resultSearch += " AND Amount = "+Amount;
				
				if(FilterBystatisticPayOutDate)
				{
					resultSearch += " AND STR_TO_DATE(PayOutDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayOutDate.getDateIn() +"', '%Y-%m-%d') ";
					resultSearch += " AND STR_TO_DATE(PayOutDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayOutDate.getDateOut() +"', '%Y-%m-%d') ";
				}
			}			
			else if(FilterBystatisticPayOutDate)
			{
				resultSearch += " AND STR_TO_DATE(PayOutDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayOutDate.getDateIn() +"', '%Y-%m-%d') ";
				resultSearch += " AND STR_TO_DATE(PayOutDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayOutDate.getDateOut() +"', '%Y-%m-%d') ";
			}
		}
	
		return resultSearch;
	}
}
