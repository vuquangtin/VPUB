package com.swt.sworld.communication.customer.object;

public class PayInDateStatisticsDto {
     
     private boolean FilterByDateIn ;
 	 private String DateIn ;
 	 
 	private boolean FilterByDateOut ;
	private String DateOut ;
	
	public boolean isFilterByDateIn() {
		return FilterByDateIn;
	}
	public void setFilterByDateIn(boolean filterByDateIn) {
		FilterByDateIn = filterByDateIn;
	}
	public String getDateIn() {
		return DateIn;
	}
	public void setDateIn(String dateIn) {
		DateIn = dateIn;
	}
	public boolean isFilterByDateOut() {
		return FilterByDateOut;
	}
	public void setFilterByDateOut(boolean filterByDateOut) {
		FilterByDateOut = filterByDateOut;
	}
	public String getDateOut() {
		return DateOut;
	}
	public void setDateOut(String dateOut) {
		DateOut = dateOut;
	}
	
	
}
