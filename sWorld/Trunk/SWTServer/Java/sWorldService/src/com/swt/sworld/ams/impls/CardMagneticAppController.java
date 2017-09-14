/**
 * 
 */
package com.swt.sworld.ams.impls;
import com.swt.sworld.ams.domain.CardMagneticApp;

/**
 * @author Administrator
 *
 */
public class CardMagneticAppController {
	
	public static final CardMagneticAppController Instance = new CardMagneticAppController();
	
	private CardMagneticAppDAOImpl CARDMAGNETICDAO= new CardMagneticAppDAOImpl();
	private CardMagneticApp cma = null;
	private CardMagneticAppController() {
		
	}
	
	public void insertCardMagneticApp(long appId, String appCode, long magneticPersoId, String rule, Byte status)
	{
		cma.setAppId(appId);
		cma.setAppCode(appCode);
		cma.setMagneticPersoId(magneticPersoId);
		cma.setRule(rule);
		cma.setStatus(status);
		
		CARDMAGNETICDAO.insert(cma);
	}
	
	public void updateCardMagneticApp(long cardMagniteId,long appId, String appCode, long magneticPersoId, String rule, Byte status)
	{
		cma.setCardMagniteId(cardMagniteId);
		cma.setAppId(appId);
		cma.setAppCode(appCode);
		cma.setMagneticPersoId(magneticPersoId);
		cma.setRule(rule);
		cma.setStatus(status);
		
		CARDMAGNETICDAO.update(cma);
	}
	
	public void deleteCardMagneticApp(long cardMagniteId)
	{
		CARDMAGNETICDAO.delete(cardMagniteId);
	}

}
