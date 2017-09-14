package com.swt.nonresident;

import java.util.List;

import com.swt.nonresident.customObject.NonResidentMemberMapCustom;
import com.swt.nonresident.domain.NonResidentMemberMap;

/**
 * Service quan ly member cho khach vang lai
 * 
 * @author MINH's Macbook Pro
 *
 */
public interface INonResidentMemberMap {
	/**
	 * Them member
	 * 
	 * @param nonResMemMap
	 * @return
	 */
	public NonResidentMemberMap insert(NonResidentMemberMap nonResMemMap);
	
	/**
	 * Sua member
	 * 
	 * @param nonResMemMap
	 * @return
	 */
	public NonResidentMemberMap update(NonResidentMemberMap nonResMemMap);
	
	/**
	 * Xoa member
	 * 
	 * @param nonMemMapId
	 * @return
	 */
	public int delete(long nonMemMapId);
	
	/**
	 * Lay member
	 * 
	 * @param nonMemMapId
	 * @return
	 */
	public NonResidentMemberMap get(long nonMemMapId);
	
	/**
	 * Lay tat ca cac danh sach member cua khach vang lai theo nonOrgId
	 * 
	 * @param nonOrgId
	 * @return
	 */
	public List<NonResidentMemberMapCustom> getListAllMemMap(long nonOrgId);
}
