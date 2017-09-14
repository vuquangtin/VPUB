package com.swt.nonresident.impls;

import java.util.List;

import com.swt.nonresident.customObject.NonResidentMemberMapCustom;
import com.swt.nonresident.domain.NonResidentMemberMap;

public class NonResidentMemberMapController {
	public static final NonResidentMemberMapController Instance = new NonResidentMemberMapController();
	private NonResidentMemberMapDAO nrmmDAO = new NonResidentMemberMapDAO();

	/**
	 * Them member
	 * 
	 * @param nonResMemMap
	 * @return
	 */
	public NonResidentMemberMap insert(NonResidentMemberMap nonResMemMap) {
		return nrmmDAO.insert(nonResMemMap);
	}

	/**
	 * Sua member
	 * 
	 * @param nonResMemMap
	 * @return
	 */
	public NonResidentMemberMap update(NonResidentMemberMap nonResMemMap) {
		return nrmmDAO.update(nonResMemMap);
	}

	/**
	 * Xoa member
	 * 
	 * @param nonMemMapId
	 * @return
	 */
	public int delete(long nonMemMapId) {
		return nrmmDAO.delete(nonMemMapId);
	}

	/**
	 * Lay member
	 * 
	 * @param nonMemMapId
	 * @return
	 */
	public NonResidentMemberMap get(long nonMemMapId) {
		return nrmmDAO.get(nonMemMapId);
	}

	/**
	 * Lay tat ca cac danh sach member cua khach vang lai theo nonOrgId
	 * 
	 * @param nonOrgId
	 * @return
	 */
	public List<NonResidentMemberMapCustom> getListAllMemMap(long nonOrgId) {
		return nrmmDAO.getListAllMemMap(nonOrgId);
	}
}
