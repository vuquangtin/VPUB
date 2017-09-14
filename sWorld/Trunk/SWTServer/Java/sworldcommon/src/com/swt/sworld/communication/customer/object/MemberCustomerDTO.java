/**
 * 
 */
package com.swt.sworld.communication.customer.object;

import java.io.Serializable;

import com.swt.sworld.ps.domain.Member;


/**
 * @author Administrator
 *
 */
public class MemberCustomerDTO implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -3746375195990688689L;
	
	private Member  Member;
	private PersoCardCustomerDTO PersoCard ;
	//private MemberRelatives Relative;
	
	public MemberCustomerDTO(Member member, PersoCardCustomerDTO PersoCard)
	{
		this.Member = member;
		this.PersoCard = PersoCard;
	}
	
	public MemberCustomerDTO(Member member)
	{
		this.setMember(member);
	}

	
	/**
	 * @return the persoCard
	 */
	public PersoCardCustomerDTO getPersoCard() {
		return PersoCard;
	}

	/**
	 * @param persoCard the persoCard to set
	 */
	public void setPersoCard(PersoCardCustomerDTO persoCard) {
		PersoCard = persoCard;
	}

	/**
	 * @return the member
	 */
	public Member getMember() {
		return Member;
	}

	/**
	 * @param member the member to set
	 */
	public void setMember(Member member) {
		Member = member;
	}

//	/**
//	 * @return the relative
//	 */
//	public MemberRelatives getRelative() {
//		return Relative;
//	}

//	/**
//	 * @param relative the relative to set
//	 */
//	public void setRelative(MemberRelatives relative) {
//		Relative = relative;
//	}

	

}
