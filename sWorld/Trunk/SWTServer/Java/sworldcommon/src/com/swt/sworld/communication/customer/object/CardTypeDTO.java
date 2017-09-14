/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;


public class CardTypeDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -4272939002937929216L;

	private long CardTypeID;
	private String Prefix;
	private String CardTypeName;
	private String CardLow;
	private String CardHigh;
	private int PinLength;

	public CardTypeDTO(long id, String prefix,  String name, String low, String high, int pin)
	{
		this.CardTypeID = id;
		this.Prefix = prefix;
		this.CardTypeName = name;
		this.CardLow = low;
		this.CardHigh = high;
		this.PinLength = pin;
	}
	/**
	 * @return the cardTypeID
	 */
	public long getCardTypeID() {
		return CardTypeID;
	}

	/**
	 * @param cardTypeID
	 *            the cardTypeID to set
	 */
	public void setCardTypeID(int cardTypeID) {
		CardTypeID = cardTypeID;
	}

	/**
	 * @return the prefix
	 */
	public String getPrefix() {
		return Prefix;
	}

	/**
	 * @param prefix
	 *            the prefix to set
	 */
	public void setPrefix(String prefix) {
		Prefix = prefix;
	}

	/**
	 * @return the cardTypeName
	 */
	public String getCardTypeName() {
		return CardTypeName;
	}

	/**
	 * @param cardTypeName
	 *            the cardTypeName to set
	 */
	public void setCardTypeName(String cardTypeName) {
		CardTypeName = cardTypeName;
	}

	/**
	 * @return the cardLow
	 */
	public String getCardLow() {
		return CardLow;
	}

	/**
	 * @param cardLow
	 *            the cardLow to set
	 */
	public void setCardLow(String cardLow) {
		CardLow = cardLow;
	}

	/**
	 * @return the cardHigh
	 */
	public String getCardHigh() {
		return CardHigh;
	}

	/**
	 * @param cardHigh
	 *            the cardHigh to set
	 */
	public void setCardHigh(String cardHigh) {
		CardHigh = cardHigh;
	}

	/**
	 * @return the pinLength
	 */
	public int getPinLength() {
		return PinLength;
	}

	/**
	 * @param pinLength
	 *            the pinLength to set
	 */
	public void setPinLength(int pinLength) {
		PinLength = pinLength;
	}
}
