/**
 * 
 */
package com.swt.sworld.ps.domain;

import javax.persistence.*;

/**
 * @author LOCVIP
 *
 */

@Entity
@Table(name = "swt_ps_personalization")
public class Personalization {
	
	@Id @GeneratedValue
	@Column(name = "Id")
	@PrimaryKeyJoinColumn
	private int Id;
	
	@Column(name = "CardId")
	private int CardId;
	
	@Column(name = "CardType")
	private int CardType;
	
	@Column(name = "MemberId", nullable = false)
	private int MemberId;
	
	@Column(name = "PersoDate", columnDefinition="DATE", nullable = false)
	private String PersoDate;
	
	@Column(name = "ExpirationDate", columnDefinition="DATE")
	private String ExpirationDate;
	
	@Column(name = "Notes", columnDefinition="TEXT")
	private String Notes;
	
	@Column(name = "Status", nullable = false)
	private int Status;

	/**
	 * @return the id
	 */
	public int getId() {
		return Id;
	}

	/**
	 * @param id the id to set
	 */
	public void setId(int id) {
		Id = id;
	}

	/**
	 * @return the cardId
	 */
	public int getCardId() {
		return CardId;
	}

	/**
	 * @param cardId the cardId to set
	 */
	public void setCardId(int cardId) {
		CardId = cardId;
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
	 * @return the memberId
	 */
	public int getMemberId() {
		return MemberId;
	}

	/**
	 * @param memberId the memberId to set
	 */
	public void setMemberId(int memberId) {
		MemberId = memberId;
	}

	/**
	 * @return the persoDate
	 */
	public String getPersoDate() {
		return PersoDate;
	}

	/**
	 * @param persoDate the persoDate to set
	 */
	public void setPersoDate(String persoDate) {
		PersoDate = persoDate;
	}

	/**
	 * @return the expirationDate
	 */
	public String getExpirationDate() {
		return ExpirationDate;
	}

	/**
	 * @param expirationDate the expirationDate to set
	 */
	public void setExpirationDate(String expirationDate) {
		ExpirationDate = expirationDate;
	}

	/**
	 * @return the notes
	 */
	public String getNotes() {
		return Notes;
	}

	/**
	 * @param notes the notes to set
	 */
	public void setNotes(String notes) {
		Notes = notes;
	}

	/**
	 * @return the status
	 */
	public int getStatus() {
		return Status;
	}

	/**
	 * @param status the status to set
	 */
	public void setStatus(int status) {
		Status = status;
	}

}
