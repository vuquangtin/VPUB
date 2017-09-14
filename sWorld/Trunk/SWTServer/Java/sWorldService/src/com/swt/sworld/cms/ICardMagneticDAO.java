/**
 * 
 */
package com.swt.sworld.cms;
import java.util.List;

import com.swt.sworld.cms.domain.CardMagnetic;
import com.swt.sworld.communication.customer.object.CardMagneticFilterDto;

/**
 * @author Administrator
 *
 */
public interface ICardMagneticDAO {
	
	CardMagnetic getLogicAndPhyByCardId(long cardmagneid);
	List<Long> getCardMagneticIdByMasterIdAndPartnerId(long masterid, long partnerid);
	int saveInforDefault(CardMagnetic cardm);
	
	List<CardMagnetic> getListCardByLogicalStatus(long masterid, long partnerid, int logicalstatus);
	List<CardMagnetic> getListCardByPhysicalStatus(long masterid, long partnerid, int physicalstatus);
	List<CardMagnetic> getListCardByLogicalAndPhysicalStatus(long masterid, long partnerid, int logicalstatus, int physicalstatus);
	
	long UpdateCardMagnetic(CardMagnetic card);
	
	CardMagnetic getLogicAndPhysicalBySerialNumber(String serialcard);
	
	List<CardMagnetic> getTotalRecordByorgidandsuborgid(long orgid,long suborgid);
	
	long totalRecord(long masterid, long partnerid, String prefix);
	
	List<Long> getCardMagneticIdByMasterId(long masterid);
	
	//List<CardMagnetic> statismagnetic(long masterid, long partnerid, String prefix,  int status);
	int statismagnetic(long masterid, long partnerid, String prefix, String nameStatus, int status);
	
	List<Long> getMemberPersoByfilter(long masterid, long partnerid, CardMagneticFilterDto filter);
	
	List<CardMagnetic> getall(long orgid, long partnerid, CardMagneticFilterDto filter);
	
	CardMagnetic UpdateStatus(long cardid, int status, String reason, String fieldupdate);
	
	List<CardMagnetic> getALLCardMagnetic();
	
	List<CardMagnetic> getCardMagneticByPartnerId(long masterId, long partnerId);
	
	List<CardMagnetic> getCardMagneticByMasterPartnerId(long masterId, long partnerId);
	
	CardMagnetic getCardBySerial(String serial);
}
