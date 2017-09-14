/**
 * 
 */
package com.swt.sworld.ams;
import com.swt.sworld.ams.domain.CardMagneticApp;

/**
 * @author Administrator
 *
 */
public interface ICardMagneticApp {
	
	int insert(CardMagneticApp cma);
	int update(CardMagneticApp cma);
	int delete(long cardMagniteId);
	CardMagneticApp getCardMagneticAppByID(long cardMagniteId);

}
