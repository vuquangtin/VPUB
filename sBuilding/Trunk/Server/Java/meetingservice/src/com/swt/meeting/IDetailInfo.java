/**
 * 
 */
package com.swt.meeting;

import com.swt.meeting.customObject.DetailInfo;
import com.swt.meeting.customObject.DetailInfoOrgOther;
import com.swt.meeting.customObject.NumberObj;

/**
 * @author TaiMai
 *
 * 
 */
public interface IDetailInfo {
	/**
	 du lieu de client view
	 * get DetaiInfo
	 * 
	 * @param barcode
	 * @return DetaiInfo
	 */

	public DetailInfo getDetailInfoPartakerAttend(String barcode);

	/**
	 * kiem tra barcode
	 * @param barcode
	 * @return
	 */
	public NumberObj checkBarcode(String barcode);

	/**
	 * barcode cua to chuc duoc them vao
	 * @param barcode
	 * @return
	 */
	public DetailInfoOrgOther getDetailInfoOrgOther(String barcode);
}
