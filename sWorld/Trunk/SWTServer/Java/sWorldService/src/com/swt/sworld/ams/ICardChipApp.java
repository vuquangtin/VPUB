/**
 * 
 */
package com.swt.sworld.ams;

import java.util.List;

import com.swt.sworld.ams.domain.CardChipApp;

/**
 * @author Administrator
 *
 */
public interface ICardChipApp {
	
	int updateMemberAppOfPerso(byte[] serialNumberHex, String lastDateUpdate);
	
//	void insert(long ChipPersoId, long AppId, String AppCode,String Data,String StartSector,String UserMaxSector,String LastMemberDataUpdatedOn,String Rule,Byte Status);
//	void update(long CardChipAppId,long ChipPersoId,long AppId, String AppCode,String Data,String StartSector,String UserMaxSector,String LastMemberDataUpdatedOn,String Rule,Byte Status);
//	void delete(long CardChipAppId);
	
	int insert(CardChipApp cca);
	void update(CardChipApp cca);
	void delete(long cardChipAppId);
	void deleteBySerial(long chipPerso);
	CardChipApp getBySerial(long chipPerso);
	CardChipApp getCardChipAppByID(long cardChipAppId);
	
	List<CardChipApp> getByChipperso(long chipPerso);
}
