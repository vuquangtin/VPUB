package com.swt.meeting.impls;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import com.swt.meeting.IJournaList;
import com.swt.meeting.lib.tm.Constant;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.ChipPersonalizationController;
import com.swt.sworld.ps.impl.MemberController;

public class JournaListDAO implements IJournaList {

	/**
	 * chuyen sang su dung doi tuong member ben sworld
	 */

	@Override
	public Member getJournalistBySerial(String serialNumber) {
		ChipPersonalization chipPersonalization = ChipPersonalizationController.Instance.getBySerial(serialNumber);
		
		if (chipPersonalization == null) {
			return null;
		}
		
		Member result = MemberController.Instance.getMemberById(chipPersonalization.getPsMemberId());
		if (result != null) {
			if (Constant.TITLE_JOURNALIST.equalsIgnoreCase(result.getTitle())) {
				return result;
			}
		}
		return null;
	}

	public int isDateExpirated(String serialNumber){
		ChipPersonalization chipPersonalization = ChipPersonalizationController.Instance.getBySerial(serialNumber);
		
		// parse String date to date
		SimpleDateFormat sdf = new SimpleDateFormat("dd-MM-yyyy HH:mm:ss");
		try {
			String strDateCheck = chipPersonalization.getExpirationDate() + " 23:59:59";
			Calendar calNow = Calendar.getInstance();
			Calendar calCheck = Calendar.getInstance();
			calCheck.setTime(sdf.parse(strDateCheck));
			if(calNow.getTime().getTime() > calCheck.getTime().getTime()){
				return 1;
			}
		} catch (ParseException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return 0;
	}
}
