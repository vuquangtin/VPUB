/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

import com.swt.sworld.ps.domain.MagneticPersonalization;
import com.swt.sworld.ps.domain.Member;

/**
 * @author Administrator
 *
 */
public class MemberMagneticPersoDTO implements Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = -7528769461889686992L;
	
	private Member member;

	private MagneticPersonalization PersoCardMagnetic;

	public MemberMagneticPersoDTO(Member member, MagneticPersonalization persion)
	{
		this.member = member;
		this.PersoCardMagnetic = persion;
	}
	/**
	 * @return the member
	 */
	public Member getMember() {
		return member;
	}

	/**
	 * @param member the member to set
	 */
	public void setMember(Member member) {
		this.member = member;
	}

	/**
	 * @return the persoCardMagnetic
	 */
	public MagneticPersonalization getPersoCardMagnetic() {
		return PersoCardMagnetic;
	}

	/**
	 * @param persoCardMagnetic the persoCardMagnetic to set
	 */
	public void setPersoCardMagnetic(MagneticPersonalization persoCardMagnetic) {
		PersoCardMagnetic = persoCardMagnetic;
	}
	
	

}
