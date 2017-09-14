/**
 * 
 */
package com.swt.sworld.ps.domain;

import java.util.Dictionary;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Table;


/**
 * @author LOCVIP
 *
 */

/*
 * Table này thêm vào dựa vào code của anh dũng
 */

@Entity
@Table(name = "swt_ps_dataforupdatecard")
public class DataForUpdateCard {
	
	@Column(name = "MemberData", columnDefinition="VARCHAR(45)")
	private Byte[] MemberData;
	
	@Column(name = "ListAppSectorKeyB")
	private Dictionary<Byte,Byte[]> ListAppSectorKeyB;

	public Byte[] getMemberData() {
		return MemberData;
	}

	public void setMemberData(Byte[] memberData) {
		MemberData = memberData;
	}

	public Dictionary<Byte, Byte[]> getListAppSectorKeyB() {
		return ListAppSectorKeyB;
	}

	public void setListAppSectorKeyB(Dictionary<Byte, Byte[]> listAppSectorKeyB) {
		ListAppSectorKeyB = listAppSectorKeyB;
	}
	
}
