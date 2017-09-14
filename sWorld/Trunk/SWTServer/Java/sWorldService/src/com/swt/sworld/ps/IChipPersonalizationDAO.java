/**
 * 
 */
package com.swt.sworld.ps;

import java.util.List;

import com.swt.sworld.communication.customer.object.PersoChipFilter;
import com.swt.sworld.ps.domain.ChipPersonalization;



/**
 * @author Administrator
 *
 */
public interface IChipPersonalizationDAO {
	
	 int update(long memberId, String serialNumber);
	 int getPersoIdByCardChipId(byte[] serialNumber);
	 long getPersoIdByCardChipId(String serialnumer);
	 
	 long updateStatus(long chipersoid, String resion, int status);
	 
	 List<ChipPersonalization> getChipPersoByMemberId(long memberid);
	 
//	 long cancelPersoByChipPersoId(long chipersoid, String cancelreason);
	 
//	 long lockPersoByChipPersoId(long chipersoid, String lockreason);
	 
//	 long unlockPersoByChipPersoId(long chipersoid, String unlockreason);
	 
	 long extendPersoByChipPersoId(long chipersoid, String expirationDate);
	 
	 ChipPersonalization getChipPersoforPersoCus(long memid, PersoChipFilter filter);
	 
	 ChipPersonalization getChipPersoforPersoCusMember(long memid);
	 
	 ChipPersonalization getMemberByIdAndSerial(long memberid, String serial);
	 
	 int ClearCardData(String serial);
	 
	 ChipPersonalization persoCardChip(ChipPersonalization chipper);
	 
	 ChipPersonalization getCardChipBySerial(String serial);
	 
	 int update(String serial, String lastupdateDate, String NameUpdate);
	 int update(ChipPersonalization chipper);
	 
	 ChipPersonalization getChippersoByCardchipid(long cardchipid);
	 
	 
	 ChipPersonalization getPsMemberIdByChipPersoId(long chipperso);
	 
	 List<ChipPersonalization> getall(long valueId);
	 
	 ChipPersonalization getBySerial(String serial);
	 
	 int deletePerso(long chipperso);
	 
	 ChipPersonalization getByMemberIdAndSerialNumber(long memberId, String serialNumber);	 	 
}
