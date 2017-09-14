/**
 * 
 */
package com.swt.meeting.customObject;

import java.io.Serializable;
import java.util.List;

import com.swt.meeting.domain.Partaker;

/**
 * @author TaiMai
 *
 * 
 */
public class DetailInfo implements Serializable {
	private static final long serialVersionUID = 18456516451L;
	/**
	 * version1
	 */
	// private Meeting meeting;
	// // private OrganizationMeeting organizationMeeting;// don vi to chuc
	// private OrganizationMeeting organizationAttend; // don vi duoc moi
	// private List<Partaker> partakers;// danh sach nguoi duoc moi trong
	// barcode
	// // da quet
	// // private Room room;
	//
	// public Meeting getMeeting() {
	// return meeting;
	// }
	//
	// public void setMeeting(Meeting meeting) {
	// this.meeting = meeting;
	// }
	//
	// public OrganizationMeeting getOrganizationAttend() {
	// return organizationAttend;
	// }
	//
	// public void setOrganizationAttend(OrganizationMeeting organizationAttend)
	// {
	// this.organizationAttend = organizationAttend;
	// }
	//
	// public List<Partaker> getPartakers() {
	// return partakers;
	// }
	//
	// public void setPartakers(List<Partaker> partakers) {
	// this.partakers = partakers;
	// }

	/**
	 * version 1
	 */

	private DetailInfoOnlyPerson detailInfoOnlyPerson;
	// danh sach khach duoc moi
	private List<Partaker> partakers;

	public DetailInfoOnlyPerson getDetailInfoOnlyPerson() {
		return detailInfoOnlyPerson;
	}

	public void setDetailInfoOnlyPerson(DetailInfoOnlyPerson detailInfoOnlyPerson) {
		this.detailInfoOnlyPerson = detailInfoOnlyPerson;
	}

	public List<Partaker> getPartakers() {
		return partakers;
	}

	public void setPartakers(List<Partaker> partakers) {
		this.partakers = partakers;
	}

	public static long getSerialversionuid() {
		return serialVersionUID;
	}

}
