package com.swt.sworld.common.errors;

import java.io.Serializable;

/**
 * @author Hoang Ha
 * 
 */
public class ErrorMessegages  implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -2586492923823597566L;
	
	/**
	 * eCash
	 */
	public static final String MESSAGE_PAYIN_TOTALMONEYCARD_TOTALMONEYREQUESTDB_lOCKMONEYCARD = "Tổng số tiền nạp ghi trên thẻ lớn hơn tổng số tiền nạp ở Log Request trên database";
	public static final String MESSAGE_PAYIN_TOTALMONEYREQUESTDB_TOTALMONEYSUCCESSDB_lOCKMONEYCARD = "Tổng số tiền nạp ở Log Request và Log Request Success không khớp với nhau";
	public static final String MESSAGE_PAYIN_PAYINDATECARD_PAYINDATEREQUESTDB_lOCKMONEYCARD = "Ngày nạp tiền gần nhất ghi trên thẻ và ngày nạp tiền gần nhất ghi ở Log Request trên database không khớp với nhau";
	
	public static final String MESSAGE_PAYOUT_TOTALMONEYCARD_TOTALMONEYREQUESTDB_lOCKMONEYCARD = "Tổng số tiền chi tiêu ghi trên thẻ nhỏ hơn tổng số tiền chi tiêu ở Log Request trên database";
	public static final String MESSAGE_PAYOUT_TOTALPAYINMONEYCARD_TOTALPAYOUTMONEYCARD_lOCKMONEYCARD = "Tổng số tiền hiện tại trên thẻ không đủ để thực hiện giao dịch";
	public static final String MESSAGE_PAYOUT_TOTALMONEYREQUESTDB_TOTALMONEYSUCCESSDB_lOCKMONEYCARD = "Tổng số tiền chi tiêu ở Log Request và Log Request Success có không khớp với nhau";
	public static final String MESSAGE_PAYOUT_PAYOUTDATECARD_PAYOUTDATEREQUESTDB_lOCKMONEYCARD = "Ngày chi tiêu gần nhất ghi trên thẻ và ngày chi tiêu gần nhất ghi ở Log Request trên database không khớp với nhau";
	
	
}
