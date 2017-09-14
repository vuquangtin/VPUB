/**
 * 
 */
package com.swt.sworld.ams.impls;
import com.swt.sworld.ams.domain.CardChipApp;

/**
 * @author Administrator
 *
 */
public class CardChipAppController {
	
	public static final CardChipAppController Instance = new CardChipAppController();
	
	private CardChipAppDAOImpl CARDCHIPDAO= new CardChipAppDAOImpl();
	private CardChipApp cardChipApp = null;
	private CardChipAppController() {
		
	}
	
	public void insertCardChipApp(long chipPersoId, long appId, String appCode,String data,String startSector,String userMaxSector,String lastMemberDataUpdatedOn,String rule,Byte status)
	{
		cardChipApp.setChipPersoId(chipPersoId);
		cardChipApp.setAppId(appId);
		cardChipApp.setAppCode(appCode);
		cardChipApp.setData(data);
		cardChipApp.setStartSector(startSector);
		cardChipApp.setUserMaxSector(userMaxSector);
		cardChipApp.setLastMemberDataUpdatedOn(lastMemberDataUpdatedOn);
		cardChipApp.setRule(rule);
		cardChipApp.setStatus(status);
		
		CARDCHIPDAO.insert(cardChipApp);
	}
	
	public void updateCardChipApp(long cardChipAppId,long chipPersoId, long appId, String appCode,
			String data, String startSector, String userMaxSector,
			String lastMemberDataUpdatedOn, String rule, Byte status)
	{
		cardChipApp.setCardChipAppId(cardChipAppId);
		cardChipApp.setChipPersoId(chipPersoId);
		cardChipApp.setAppId(appId);
		cardChipApp.setAppCode(appCode);
		cardChipApp.setData(data);
		cardChipApp.setStartSector(startSector);
		cardChipApp.setUserMaxSector(userMaxSector);
		cardChipApp.setLastMemberDataUpdatedOn(lastMemberDataUpdatedOn);
		cardChipApp.setRule(rule);
		cardChipApp.setStatus(status);
		
		CARDCHIPDAO.update(cardChipApp);
	}
	
	public void deleteCardChipApp(long cardChipAppId)
	{
		CARDCHIPDAO.delete(cardChipAppId);
	}
	
	public CardChipApp GetCardChipApp(long cardchipAppId)
	{
		return CARDCHIPDAO.getCardChipAppByID(cardchipAppId);
	}

}
