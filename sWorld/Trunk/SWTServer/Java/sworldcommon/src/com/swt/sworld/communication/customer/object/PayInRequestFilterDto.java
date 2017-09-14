package com.swt.sworld.communication.customer.object;


public class PayInRequestFilterDto {

	private boolean FilterBySerialNumber ;
	private String SerialNumber ;

	private boolean FilterByAmount ;
	private double Amount ;
	
	private boolean FilterBystatisticPayInDate ;
	private PayInDateStatisticsDto statisticPayInDate;

	public String clone()
	{
		String resultSearch = "";
		if(FilterBySerialNumber)
			resultSearch += " SerialNumber = '" + SerialNumber + "'";
		
		if(resultSearch == "")
		{
			if(FilterByAmount)
			{
				resultSearch += " Amount = "+Amount;
				
				if(FilterBystatisticPayInDate)
				{
					//resultSearch += " AND date_format(str_to_date(PayInDate,'%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s') >= date_format(str_to_date('"+statisticPayInDate.getDateIn()+"','%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s')";
					//resultSearch += " AND date_format(str_to_date(PayInDate,'%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s') <= date_format(str_to_date('"+statisticPayInDate.getDateOut()+"','%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s')";
					
					//resultSearch += " AND STR_TO_DATE(PayInDate,'%d-%m-%Y') BETWEEN STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%d-%m-%Y') ";
					//resultSearch += " AND STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%d-%m-%Y') ";

					resultSearch += " AND STR_TO_DATE(PayInDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%Y-%m-%d') ";
					resultSearch += " AND STR_TO_DATE(PayInDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%Y-%m-%d') ";
				}
			}			
			else if(FilterBystatisticPayInDate)
			{
				//resultSearch += " date_format(str_to_date(PayInDate,'%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s') >= date_format(str_to_date('"+statisticPayInDate.getDateIn()+"','%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s')";
				//resultSearch += " AND date_format(str_to_date(PayInDate,'%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s') <= date_format(str_to_date('"+statisticPayInDate.getDateOut()+"','%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s')";
				
				//resultSearch += " STR_TO_DATE(PayInDate,'%d-%m-%Y') BETWEEN STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%d-%m-%Y') ";
				//resultSearch += " AND STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%d-%m-%Y') ";
				
				resultSearch += " STR_TO_DATE(PayInDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%Y-%m-%d') ";
				resultSearch += " AND STR_TO_DATE(PayInDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%Y-%m-%d') ";
			}
		}
		else
		{
			if(FilterByAmount)
			{
				resultSearch += " AND Amount = "+Amount;
				
				if(FilterBystatisticPayInDate)
				{
					//resultSearch += " AND date_format(str_to_date(PayInDate,'%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s') >= date_format(str_to_date('"+statisticPayInDate.getDateIn()+"','%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s')";
					//resultSearch += " AND date_format(str_to_date(PayInDate,'%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s') <= date_format(str_to_date('"+statisticPayInDate.getDateOut()+"','%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s')";
					
					//resultSearch += " AND STR_TO_DATE(PayInDate,'%d-%m-%Y') BETWEEN STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%d-%m-%Y') ";
					//resultSearch += " AND STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%d-%m-%Y') ";
					
					resultSearch += " AND STR_TO_DATE(PayInDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%Y-%m-%d') ";
					resultSearch += " AND STR_TO_DATE(PayInDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%Y-%m-%d') ";
				}
			}			
			else if(FilterBystatisticPayInDate)
			{
				//resultSearch += " AND date_format(str_to_date(PayInDate,'%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s') >= date_format(str_to_date('"+statisticPayInDate.getDateIn()+"','%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s')";
				//resultSearch += " AND date_format(str_to_date(PayInDate,'%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s') <= date_format(str_to_date('"+statisticPayInDate.getDateOut()+"','%d-%m-%Y  %H:%m:%s'), '%Y-%m-%d %H:%m:%s')";

				//resultSearch += " AND STR_TO_DATE(PayInDate,'%d-%m-%Y') BETWEEN STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%d-%m-%Y') ";
				//resultSearch += " AND STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%d-%m-%Y') ";
				
				resultSearch += " AND STR_TO_DATE(PayInDate, '%d-%m-%Y') >= STR_TO_DATE('"+ statisticPayInDate.getDateIn() +"', '%Y-%m-%d') ";
				resultSearch += " AND STR_TO_DATE(PayInDate, '%d-%m-%Y') <= STR_TO_DATE('"+ statisticPayInDate.getDateOut() +"', '%Y-%m-%d') ";
			}
		}
	
		return resultSearch;
	}

	public boolean isFilterBySerialNumber() {
		return FilterBySerialNumber;
	}

	public void setFilterBySerialNumber(boolean filterBySerialNumber) {
		FilterBySerialNumber = filterBySerialNumber;
	}

	public String getSerialNumber() {
		return SerialNumber;
	}

	public void setSerialNumber(String serialNumber) {
		SerialNumber = serialNumber;
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
	
}
