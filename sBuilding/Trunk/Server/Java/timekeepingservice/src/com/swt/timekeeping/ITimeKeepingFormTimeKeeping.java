package com.swt.timekeeping;

import java.util.List;

import com.swt.timekeeping.customer.object.ChipPersonalizationCustom;
import com.swt.timekeeping.customer.object.MemberCustom;

/**
 * Interface TimeKeepingTest
 * 
 * @author minh.nguyen
 *
 */
public interface ITimeKeepingFormTimeKeeping {

	/**
	 * Method get list ChipPersonalizationCustom
	 * 
	 * @return
	 */
	public List<ChipPersonalizationCustom> getListChipPersonalizationCustom();

	/**
	 * Method get list MemberCustom
	 * 
	 * @return
	 */
	public List<MemberCustom> getListMemberCustom();
}
