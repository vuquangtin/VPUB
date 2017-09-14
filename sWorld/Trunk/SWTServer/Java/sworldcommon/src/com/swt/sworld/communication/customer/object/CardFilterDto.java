/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class CardFilterDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 299626745901102991L;
	
	private boolean FilterByPhysicalStatus ;
	private int PhysicalStatus ;

	private boolean FilterByPersoStatus ;
	private boolean Personalized ;

	private boolean FilterByCardType ;
	private int CardType ;
	
	private int Start ;
	private int Count ;
	/**
	 * @return the filterByPhysicalStatus
	 */
	public boolean isFilterByPhysicalStatus() {
		return FilterByPhysicalStatus;
	}
	/**
	 * @param filterByPhysicalStatus the filterByPhysicalStatus to set
	 */
	public void setFilterByPhysicalStatus(boolean filterByPhysicalStatus) {
		FilterByPhysicalStatus = filterByPhysicalStatus;
	}
	/**
	 * @return the physicalStatus
	 */
	public int getPhysicalStatus() {
		return PhysicalStatus;
	}
	/**
	 * @param physicalStatus the physicalStatus to set
	 */
	public void setPhysicalStatus(int physicalStatus) {
		PhysicalStatus = physicalStatus;
	}
	/**
	 * @return the filterByPersoStatus
	 */
	public boolean isFilterByPersoStatus() {
		return FilterByPersoStatus;
	}
	/**
	 * @param filterByPersoStatus the filterByPersoStatus to set
	 */
	public void setFilterByPersoStatus(boolean filterByPersoStatus) {
		FilterByPersoStatus = filterByPersoStatus;
	}
	/**
	 * @return the personalized
	 */
	public boolean isPersonalized() {
		return Personalized;
	}
	/**
	 * @param personalized the personalized to set
	 */
	public void setPersonalized(boolean personalized) {
		Personalized = personalized;
	}
	/**
	 * @return the filterByCardType
	 */
	public boolean isFilterByCardType() {
		return FilterByCardType;
	}
	/**
	 * @param filterByCardType the filterByCardType to set
	 */
	public void setFilterByCardType(boolean filterByCardType) {
		FilterByCardType = filterByCardType;
	}
	/**
	 * @return the cardType
	 */
	public int getCardType() {
		return CardType;
	}
	/**
	 * @param cardType the cardType to set
	 */
	public void setCardType(int cardType) {
		CardType = cardType;
	}
	/**
	 * @return the start
	 */
	public int getStart() {
		return Start;
	}
	/**
	 * @param start the start to set
	 */
	public void setStart(int start) {
		Start = start;
	}
	/**
	 * @return the count
	 */
	public int getCount() {
		return Count;
	}
	/**
	 * @param count the count to set
	 */
	public void setCount(int count) {
		Count = count;
	}
	public String clone()
	{
		String resultSearch = "";
		if(FilterByPhysicalStatus)
			resultSearch += " AND PhysicalStatus = " + PhysicalStatus;
		
		if(resultSearch == "")
		{
			if(FilterByPersoStatus)
				resultSearch += " AND LogicalStatus = " + Personalized ;
		}
		else
		{
			if(FilterByPersoStatus)
				resultSearch += " AND LogicalStatus = " + Personalized ;
		}
		
		if(resultSearch == "")
		{
			if(FilterByPersoStatus)
				resultSearch += " AND LogicalStatus = " + Personalized ;
		}
		else
		{
			if(FilterByPersoStatus)
				resultSearch += " AND LogicalStatus = " + Personalized ;
		}
		
		if(resultSearch == "")
		{
			if(CardType != 0)
				resultSearch += " AND TypeCard = " + CardType ;
		}
		else
		{
			if(CardType != 0)
			resultSearch += " AND TypeCard = " + CardType ;
		}
		return resultSearch;
	}
	
	
}
