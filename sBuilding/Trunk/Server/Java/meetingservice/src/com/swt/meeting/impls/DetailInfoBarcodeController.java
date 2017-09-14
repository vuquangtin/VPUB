package com.swt.meeting.impls;

import com.swt.meeting.customObject.DetailInfo;
import com.swt.meeting.customObject.DetailInfoOrgOther;
import com.swt.meeting.customObject.NumberObj;

public class DetailInfoBarcodeController {

	public static final DetailInfoBarcodeController Instance = new DetailInfoBarcodeController();

	private DetailInfoBarcodeDAO diDAO = new DetailInfoBarcodeDAO();

	private DetailInfoBarcodeController() {

	}

	public DetailInfo getDetailInfoPartakerAttend(String barcode) {
		return diDAO.getDetailInfoPartakerAttend(barcode);
	}

	public NumberObj checkBarcode(String barcode) {
		return diDAO.checkBarcode(barcode);
	}

	// barcode cua to chuc duoc them vao
	public DetailInfoOrgOther getDetailInfoOrgOther(String barcode){
		return diDAO.getDetailInfoOrgOther(barcode);
	}
}
