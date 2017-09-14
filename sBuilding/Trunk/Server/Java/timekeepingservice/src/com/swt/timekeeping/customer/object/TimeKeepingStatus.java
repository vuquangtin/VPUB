package com.swt.timekeeping.customer.object;

/**
 * 
 * @author Admin
 *
 */
public enum TimeKeepingStatus {
	NGAY_NGHI_TRONG_TUAN(0), 
	NGAY_LE(1), 
	VANG_CA_NGAY_PHEP(2), 
	VANG_CA_NGAY_KO_PHEP(3), 
	VANG_NUA_NGAY_PHEP(4),
	VANG_NUA_NGAY_KO_PHEP(5),
	DI_TRE_VE_SOM(6),
	LAM_VIEC_DUNG_GIO(7);
	
	private int value;

	private TimeKeepingStatus(int value) {
		this.value = value;
	}
	public int getValue(){
		return this.value;
	}
}


