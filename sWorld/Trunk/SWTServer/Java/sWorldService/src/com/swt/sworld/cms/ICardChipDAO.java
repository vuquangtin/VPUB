/**
 * 
 */
package com.swt.sworld.cms;
import java.util.List;

import com.swt.sworld.cms.domain.CardChip;
import com.swt.sworld.communication.customer.object.CardFilterDto;

/**
 * @author Administrator
 *
 */
public interface ICardChipDAO {
	
	CardChip getCardChipBySerial(String serialnumberhex);
	CardChip getCardChipBySerialCardType(String serialnumberhex, int cardtype);
	CardChip getCardChipBySerial(long masterid, String serialnumberhex);
	CardChip getCardChipBySerialCardType(long masterid, String serialnumberhex, int cardtype);
	CardChip getCardChipBySerialAndPartnerId(long partnerid, String serialnumberhex);
	long insertCardChip(CardChip cardchip);
	int updateCardChip(CardChip cardchip);
	int deleteCardChip(CardChip cardchip);
	
	CardChip getCardChipById(long cardchipid);
	
	long markBrokenCardByCardChipId(long cardchipid);
	
	long unmarkBrokenCardByCardChipId(long cardchipid);
	
	long markLostCardByCardChipId(long cardchipid);
	
	long unmarkLostCardByCardChipId(long cardchipid);
	
	CardChip getLogicAndPhyByCardId(long cardchipid);
	
	List<CardChip> getAll(long orgid,long suborgid,CardFilterDto filter);
	
	List<CardChip> getAllCardChip();
	
	List<CardChip> getCardChipByPhysical(int physicalstatus,long masterid, long orgpartnerid);
	
	List<CardChip> getAllCardChipByOrgPartnerId(long masterid,long partnerid);
	
	List<CardChip> getCardChipByPartnerId(long masterId, long partnerId);
	
	List<CardChip> getCardChipByMasterId(long masterId);
	
	List<CardChip> getCardChipListExport();
	
	List<CardChip> getCardChipListByOrg(long orgId);
	
	long getCardChipIdBySerialNumber(String serial);
	
}
