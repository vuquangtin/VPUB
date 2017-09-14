/**
 * 
 */
package com.swt.sworld.utilites;

import java.io.Serializable;

/**
 * @author Administrator
 * 
 */
public class SworldConst implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -2586492923823597566L;
	// card magnetic
	// physical
	public static final int Normal = 1;
	public static final int Broken = 2;
	public static final int Lost = 3;
	public static final int Lock = 4;
	public static final int Cancel = 5;
	public static final int Expired = 6;

	// logical
	public static final int Printed = 7;
	public static final int NoPrinted = 8;
	public static final int Actived = 9;
	public static final int DeActived = 10;

	/**
	 * eCash
	 */
	public static final int LockMoneyCard = 11;
	public static final int DeleteStatus = 12;
	
	
	// card chip
	public static final int unbroken = 7;
	public static final int unlost = 8;
	public static final int unlock = 9;
	// public static final int extend = 10;

	public static final int NOTCARDSYSTEM = -1;
	public static final int NORMAL = 0;
	public static final int LOCK = 1;
	public static final int CANCEL = 2;
	public static final int EXTEND = 3;
	public static final int MARKBROKEN = 4;
	public static final int MARKLOST = 5;
	public static final int PERSO = 6;
	public static final int NOT_PERSO = 7;

	public static final int RSA = 1;
	public static final int AES = 2;
	public static final int SWT = 1;

	// Card MF 1K chip NXP
	public static final int MF_1K = 1;

	// Card MF 1K chip Trung QuÃ¡Â»â€˜c
	public static final int MF_1K_CN = -120;
	// Card MF 4K chip NXP
	public static final int MF_4K = 2;

	public static final String PRE_SERVER = "ADADAD";
	public static final String NAME_SERVER = "DADADA";

	public static final int CARD_HAS_MASTER_READED_ONLY = 100;
	public static final int CARD_HAS_MASTER_WRITED_ONLY = 101;
	public static final int CARD_HAS_MASTER_PARTNER_READED = 102;
	public static final int CARD_HAS_MASTER_PARTNER_WRITE = 103;
	public static final int CARD_HAS_DATA_READY = 103;
	public static final int LOG = 1102;

	
	public static final String NOTMASTER = "NOTMASTER";
	public static final String CARDMAGNETIC = "MagneticPersonalization";
	public static final String CARDCHIP = "ChipPersonalization";
	
	public static final String AUTO_ADD_DEFAULT_ORG = "auto_add_default_suborg";
	public static final String TRUE ="true";
	public static final String KEY_ACTIVE = "key_active";
	public static final String KEY_A_SECOR_VALUE = "key_a_sactor_active";
	public static final String KEY_B_SECOR_VALUE = "key_b_sactor_active";
	public static final String KEY_VALUE1_SECTOR = "key_value1_sector";
	public static final String ORG_CENTRAL = "Trụ sở chính ";
	public static final String DURATION_CHIP_CARD = "chip_card_duration";
	public static final String FORMAT_CARD_DATA = "format_card_data";
	public static final String TOTAL_MONTHLY_DEBT = "total_monthly_debt";
	public static final String COUNT_HASH_PASSWORD = "count_hash_password";
	public static final String SPLITER =",";
	
	//value of status sAttendance
	public static final int Process = 1;
	public static final int Success = 2;
	
	
}
