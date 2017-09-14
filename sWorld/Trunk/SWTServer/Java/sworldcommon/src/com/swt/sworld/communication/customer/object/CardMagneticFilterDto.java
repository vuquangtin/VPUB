/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

/**
 * @author Administrator
 *
 */
public class CardMagneticFilterDto implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -2667982519441398808L;
	
	private boolean FilterByOrgMaster ;
	private long OrgMasterId ;
	
	private boolean FilterByOrgPartner ;
	private long OrgPartnerId ;
	
	private boolean FilterByCardType ;
	private String Prefix ;
	
	private boolean FilterByCardStatus ;
	private int CardStatus ;
	
	private boolean FilterByCardPhysicalStatus ;
	private int CardPhysicalStatus ;
	
	private boolean FilterByPersoDate ;
	private TimePeriodDto PersoDatePeriod ;
	
	private boolean FilterByMemberName ;
	private String MemberName ;
	
	private boolean FilterByPhoneNumber;
	private String PhoneNumber;
	
	private boolean FilterByCardPrintedStatus ;
	private int CardPrintedStatus ;
	public String clone()
	{
		String resultSearch = "";
		if(FilterByOrgMaster)
			resultSearch += " AND OrgMasterId = " + OrgMasterId;
		
			if(FilterByOrgPartner)
				resultSearch += " AND OrgPartnerId = " + OrgPartnerId ;
		
			if(FilterByCardType)
				resultSearch += " AND PrefixCard = '" + Prefix + "'" ;
		
			if(isFilterByCardStatus())
			resultSearch += " AND Status = " + getCardStatus() ;
		
			if(FilterByCardPhysicalStatus)
			resultSearch += " AND PhysicalStatus = " + CardPhysicalStatus ;
		
			if(FilterByMemberName)
			resultSearch += " AND FullName LIKE '%"+MemberName+"%'" ;
			
			 if(FilterByPersoDate)
			   {
			    resultSearch += " AND STR_TO_DATE(StartDate, '%d/%m/%Y') >= STR_TO_DATE('"+ PersoDatePeriod.getStart() +"', '%d/%m/%Y') ";
			    resultSearch += " AND STR_TO_DATE(StartDate, '%d/%m/%Y') <= STR_TO_DATE('"+ PersoDatePeriod.getEnd() +"', '%d/%m/%Y')";
			   }
			
			if(FilterByPhoneNumber)
				resultSearch += " AND PhoneNumber LIKE '%"+PhoneNumber+"%'" ;
			
			if(FilterByCardPrintedStatus)
				resultSearch += " AND PrintedStatus = " + CardPrintedStatus ;
		return resultSearch;
	}
	
	public String cloneCardTypeAnd()
	{
		String resultSearch = "";
			if(FilterByCardType)
				resultSearch += " AND Prefix = '" + Prefix + "'" ;
		
			if(isFilterByCardStatus())
			resultSearch += " AND LogicalStatus = " + getCardStatus() ;
		return resultSearch;
	}
	
	public String cloneMagneticPerso()
	{
		//chi co filter theo 5 loai ben perso cua the tu
		String resultSearch = "";
		if(FilterByCardType)
			resultSearch += " AND Prefix = '" + Prefix + "'" ;
	
		if(isFilterByCardStatus())
		resultSearch += " AND Status = " + getCardStatus() ;
		
		if(FilterByMemberName)
			resultSearch += " AND FullName LIKE '%"+MemberName+"%'" ;
			
			 if(FilterByPersoDate)
			   {
			    resultSearch += " AND STR_TO_DATE(PersoDate, '%d/%m/%Y') >= STR_TO_DATE('"+ PersoDatePeriod.getStart() +"', '%d/%m/%Y') ";
			    resultSearch += " AND STR_TO_DATE(PersoDate, '%d/%m/%Y') <= STR_TO_DATE('"+ PersoDatePeriod.getEnd() +"', '%d/%m/%Y')";
			   }
			
			if(FilterByPhoneNumber)
				resultSearch += " AND PhoneNumber LIKE '%"+PhoneNumber+"%'" ;
		return resultSearch;
	}
	
	
	/**
	 * @return the filterByOrgMaster
	 */
	public boolean isFilterByOrgMaster() {
		return FilterByOrgMaster;
	}
	/**
	 * @param filterByOrgMaster the filterByOrgMaster to set
	 */
	public void setFilterByOrgMaster(boolean filterByOrgMaster) {
		FilterByOrgMaster = filterByOrgMaster;
	}
	/**
	 * @return the orgMasterId
	 */
	public long getOrgMasterId() {
		return OrgMasterId;
	}
	/**
	 * @param orgMasterId the orgMasterId to set
	 */
	public void setOrgMasterId(long orgMasterId) {
		OrgMasterId = orgMasterId;
	}
	/**
	 * @return the filterByOrgPartner
	 */
	public boolean isFilterByOrgPartner() {
		return FilterByOrgPartner;
	}
	/**
	 * @param filterByOrgPartner the filterByOrgPartner to set
	 */
	public void setFilterByOrgPartner(boolean filterByOrgPartner) {
		FilterByOrgPartner = filterByOrgPartner;
	}
	/**
	 * @return the orgPartnerId
	 */
	public long isOrgPartnerId() {
		return OrgPartnerId;
	}
	/**
	 * @param orgPartnerId the orgPartnerId to set
	 */
	public void setOrgPartnerId(long orgPartnerId) {
		OrgPartnerId = orgPartnerId;
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
	 * @return the prefix
	 */
	public String getPrefix() {
		return Prefix;
	}
	/**
	 * @param prefix the prefix to set
	 */
	public void setPrefix(String prefix) {
		Prefix = prefix;
	}
	/**
	 * @return the filterByCardPhysicalStatus
	 */
	public boolean isFilterByCardPhysicalStatus() {
		return FilterByCardPhysicalStatus;
	}
	/**
	 * @param filterByCardPhysicalStatus the filterByCardPhysicalStatus to set
	 */
	public void setFilterByCardPhysicalStatus(boolean filterByCardPhysicalStatus) {
		FilterByCardPhysicalStatus = filterByCardPhysicalStatus;
	}
	/**
	 * @return the cardPhysicalStatus
	 */
	public int getCardPhysicalStatus() {
		return CardPhysicalStatus;
	}
	/**
	 * @param cardPhysicalStatus the cardPhysicalStatus to set
	 */
	public void setCardPhysicalStatus(int cardPhysicalStatus) {
		CardPhysicalStatus = cardPhysicalStatus;
	}
	/**
	 * @return the filterByPersoDate
	 */
	public boolean isFilterByPersoDate() {
		return FilterByPersoDate;
	}
	/**
	 * @param filterByPersoDate the filterByPersoDate to set
	 */
	public void setFilterByPersoDate(boolean filterByPersoDate) {
		FilterByPersoDate = filterByPersoDate;
	}
	/**
	 * @return the persoDatePeriod
	 */
	public TimePeriodDto getPersoDatePeriod() {
		return PersoDatePeriod;
	}
	/**
	 * @param persoDatePeriod the persoDatePeriod to set
	 */
	public void setPersoDatePeriod(TimePeriodDto persoDatePeriod) {
		PersoDatePeriod = persoDatePeriod;
	}
	/**
	 * @return the filterByMemberName
	 */
	public boolean isFilterByMemberName() {
		return FilterByMemberName;
	}
	/**
	 * @param filterByMemberName the filterByMemberName to set
	 */
	public void setFilterByMemberName(boolean filterByMemberName) {
		FilterByMemberName = filterByMemberName;
	}
	/**
	 * @return the memberName
	 */
	public String getMemberName() {
		return MemberName;
	}
	/**
	 * @param memberName the memberName to set
	 */
	public void setMemberName(String memberName) {
		MemberName = memberName;
	}

	/**
	 * @return the filterByPhoneNumber
	 */
	public boolean isFilterByPhoneNumber() {
		return FilterByPhoneNumber;
	}

	/**
	 * @param filterByPhoneNumber the filterByPhoneNumber to set
	 */
	public void setFilterByPhoneNumber(boolean filterByPhoneNumber) {
		FilterByPhoneNumber = filterByPhoneNumber;
	}

	/**
	 * @return the phoneNumber
	 */
	public String getPhoneNumber() {
		return PhoneNumber;
	}

	/**
	 * @param phoneNumber the phoneNumber to set
	 */
	public void setPhoneNumber(String phoneNumber) {
		PhoneNumber = phoneNumber;
	}

	/**
	 * @return the filterByCardPrintedStatus
	 */
	public boolean isFilterByCardPrintedStatus() {
		return FilterByCardPrintedStatus;
	}

	/**
	 * @param filterByCardPrintedStatus the filterByCardPrintedStatus to set
	 */
	public void setFilterByCardPrintedStatus(boolean filterByCardPrintedStatus) {
		FilterByCardPrintedStatus = filterByCardPrintedStatus;
	}

	/**
	 * @return the cardPrintedStatus
	 */
	public int getCardPrintedStatus() {
		return CardPrintedStatus;
	}

	/**
	 * @param cardPrintedStatus the cardPrintedStatus to set
	 */
	public void setCardPrintedStatus(int cardPrintedStatus) {
		CardPrintedStatus = cardPrintedStatus;
	}

	/**
	 * @return the filterByCardStatus
	 */
	public boolean isFilterByCardStatus() {
		return FilterByCardStatus;
	}

	/**
	 * @param filterByCardStatus the filterByCardStatus to set
	 */
	public void setFilterByCardStatus(boolean filterByCardStatus) {
		FilterByCardStatus = filterByCardStatus;
	}

	/**
	 * @return the cardStatus
	 */
	public int getCardStatus() {
		return CardStatus;
	}

	/**
	 * @param cardStatus the cardStatus to set
	 */
	public void setCardStatus(int cardStatus) {
		CardStatus = cardStatus;
	}

}
