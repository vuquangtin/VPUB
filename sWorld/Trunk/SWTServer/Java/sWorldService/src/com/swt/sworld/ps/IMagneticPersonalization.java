/**
 * 
 */
package com.swt.sworld.ps;
import java.util.List;

import com.swt.sworld.communication.customer.object.CardMagneticFilterDto;
import com.swt.sworld.ps.domain.MagneticPersonalization;

/**
 * @author Administrator
 *
 */
public interface IMagneticPersonalization {
	
	MagneticPersonalization getMagneticPersoByMemberId(long memid);
	MagneticPersonalization getMagneticPersoByCardMagneticId(long cardid,CardMagneticFilterDto filter);
	List<MagneticPersonalization> getall(long valueId);
	int presoCardMagnetic(MagneticPersonalization magneticperso);
	
	int saveinfo(MagneticPersonalization dto);
	
	MagneticPersonalization updateStatus(long persoid, int status, String reason, String fieldupdate);
	
	MagneticPersonalization getByPerId(long persoid);
	
	MagneticPersonalization getByFilter(long cardid);
	
	MagneticPersonalization getCardByCardId(long cardId);
	
	MagneticPersonalization getCardBySerial(String serial);
}
