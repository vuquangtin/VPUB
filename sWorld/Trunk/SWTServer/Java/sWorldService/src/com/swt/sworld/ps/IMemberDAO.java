/**
 * 
 */
package com.swt.sworld.ps;
import java.util.List;

import com.swt.sworld.cms.domain.SubOrganization;
import com.swt.sworld.communication.customer.object.MemberFilter;
import com.swt.sworld.communication.customer.object.PersoChipFilter;
import com.swt.sworld.ps.domain.Member;

/**
 * @author Administrator
 *
 */
public interface IMemberDAO {
	
	//dung de cau hinh thoi gian cho tung nguoi theo to chuc
	List<Member> getByOrgId(long orgId);
	////20170603 BUG 705 thêm filter để lọc dữ liệu Ten Nguyen Start
	List<Member> getBySubOrgId(long orgId,MemberFilter memberFilter);
////20170603 BUG 705 thêm filter để lọc dữ liệu Ten Nguyen End
	List<Member> getByOrgId(long OrgId,PersoChipFilter filter);
	
	List<Member> getMemberBySubOrgAndPersoChipFilter(long subOrgId,PersoChipFilter filter);
	
	List<Member> getByOrgIdMember(long OrgId,MemberFilter filter);
	List<Member> getMemberByOrgAndSub(long orgId, long subOrgId,PersoChipFilter filter);
	List<Member> getMemberByOrgAndSubMember(long orgId, long subOrgId,MemberFilter filter);
	List<Long> getListMemberIdByOrgAndSub(long orgId, long subOrgId, PersoChipFilter filter);
	List<Member> getMemberBySubOrgId(long subOrgId);
	Member getMembeByMemberid(long memberid);
	Member getMemberByCode(long orgid,String code);
	int insertMember(Member mem);
	int updateMember(Member mem);
	int deleteMember(long memid);
	Member getMemberByInfo(String activecode, String birthday, String location,
			int sex, String telephone, String username, String deviceid);
	long getMemberIdByCode(String token);
	
	List<Member> getAllMember();
	
	Member getMemberByNameAndPhone(String fullName, String phone);
	
	Member getMemberByPhone(String phone);
	
	List<Member> getAlListMemberFilter(long OrgId, String area, int gender, String search);
	
	boolean hasInSubOrg(long suborgId);
	
	//////10052017 thong ke Trang Vo Start
	
	List<Member> getMemberBytotalCount(List<SubOrganization> subOrgId, MemberFilter filter, int start, int length);
	
	List<Member> getByOrgIdBytotalCount(long orgId, MemberFilter filter, int start, int length);
	
	long getTotalMemberByOrgId(long selectrdOrg, MemberFilter filter);
	
	long getTotalMemberByListSubOrg(long selectrdOrg, List<SubOrganization> subOrgId, MemberFilter filter);
	
	List<Member> getAllMemberNotJournalist(long orgId, MemberFilter filter, String title);
	
	//////10052017 thong ke Trang Vo End
}
