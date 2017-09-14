package com.swt.sworld.hsm.domain;


import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Table;

/**
 * @author loc.le
 * 
 */

@Entity
@Table(name = "swtgp_hsm")
public class Hsm implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -2969000792982808421L;
	
	@Id
	@GeneratedValue
	@Column(name = "HsmId",  nullable = false)
	private long HsmId;

	@Column(name = "NameAlgorithm", length = 255)
	private String NameAlgorithm;

	@Column(name = "Formatvalue", length = 500)
	private String Formatvalue;

	@Column(name = "Values", length = 500)
	private String Values;

	@Column(name = "Description")
	private String Description;

	@Column(name = "Status", columnDefinition = "int default 0")
	private int Status;

	/**
	 * @return the hsmId
	 */
	public long getHsmId() {
		return HsmId;
	}

	/**
	 * @param hsmId
	 *            the hsmId to set
	 */
	public void setHsmId(long hsmId) {
		HsmId = hsmId;
	}

	/**
	 * @return the nameAlgorithm
	 */
	public String getNameAlgorithm() {
		return NameAlgorithm;
	}

	/**
	 * @param nameAlgorithm
	 *            the nameAlgorithm to set
	 */
	public void setNameAlgorithm(String nameAlgorithm) {
		NameAlgorithm = nameAlgorithm;
	}

	/**
	 * @return the formatvalue
	 */
	public String getFormatvalue() {
		return Formatvalue;
	}

	/**
	 * @param formatvalue
	 *            the formatvalue to set
	 */
	public void setFormatvalue(String formatvalue) {
		Formatvalue = formatvalue;
	}

	/**
	 * @return the values
	 */
	public String getValues() {
		return Values;
	}

	/**
	 * @param values
	 *            the values to set
	 */
	public void setValues(String values) {
		Values = values;
	}

	/**
	 * @return the description
	 */
	public String getDescription() {
		return Description;
	}

	/**
	 * @param description
	 *            the description to set
	 */
	public void setDescription(String description) {
		Description = description;
	}

	/**
	 * @return the status
	 */
	public int getStatus() {
		return Status;
	}

	/**
	 * @param status
	 *            the status to set
	 */
	public void setStatus(int status) {
		Status = status;
	}

}
