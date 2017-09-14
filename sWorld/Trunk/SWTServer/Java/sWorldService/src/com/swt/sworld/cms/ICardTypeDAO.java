package com.swt.sworld.cms;

import java.util.List;

import com.swt.sworld.cms.domain.CardType;
import com.swt.sworld.communication.customer.object.CardTypeDTO;


public interface ICardTypeDAO {
	CardType getByOrgId(String id, long orgid);
	List<CardType> getByOrgId(long orgid);
	List<CardTypeDTO> getCardTypeDTOByOrgId(long orgid);
	CardType getById(long id);
	CardType getById(long id, String prix);
	CardType getbyprefix(String prefix);
	
}
