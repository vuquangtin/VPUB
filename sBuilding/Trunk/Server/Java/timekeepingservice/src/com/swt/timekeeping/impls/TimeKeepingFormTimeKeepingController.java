package com.swt.timekeeping.impls;

import java.util.List;

import com.swt.timekeeping.customer.object.ChipPersonalizationCustom;
import com.swt.timekeeping.customer.object.MemberCustom;

/**
 * TimeKeeping Test Controler
 * 
 * @author minh.nguyen
 *
 */
public class TimeKeepingFormTimeKeepingController {

	/**
	 * Instance of TimeKeepingTestController
	 */
	public static final TimeKeepingFormTimeKeepingController Instance = new TimeKeepingFormTimeKeepingController();
	private TimeKeepingFormTimeKeepingDAO tDAO = new TimeKeepingFormTimeKeepingDAO();

	/**
	 * Method get list ChipPersonalizationCustom
	 * 
	 * @return
	 */
	public List<ChipPersonalizationCustom> getListChipPersonalizationCustom() {
		return tDAO.getListChipPersonalizationCustom();
	}

	/**
	 * Method get list MemberCustom
	 * 
	 * @return
	 */
	public List<MemberCustom> getListMemberCustom() {
		return tDAO.getListMemberCustom();
	}
}
