/**
 * 
 */
package com.swt.sworld.common.impls;

import java.util.ArrayList;
import java.util.List;

import com.swt.sworld.common.domain.GroupSworld;
import com.swt.sworld.common.domain.PolicySworld;
import com.swt.sworld.common.domain.UserSworld;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.communication.customer.object.GroupCustomerDto;
import com.swt.sworld.communication.customer.object.GroupFilterDto;
import com.swt.sworld.communication.customer.object.MethodResultDto;

/**
 * @author Administrator
 *
 */
public class GroupController {
	
	public static final GroupController Instance = new GroupController();
	
	private String methodDelete = "DELETE_GROUP";
	private GroupDAOImpl GROUPDAO = new GroupDAOImpl();
	private UserDAOImpl USERDAO = new UserDAOImpl();
	private GroupController() {

	}
	
	public List<GroupSworld> getGroupList(GroupFilterDto filter)
	{
		List<GroupSworld> groupSworld = GROUPDAO.getGroupList();
		return groupSworld;
	}
	
	public GroupCustomerDto getGroupByGroupId(long groupid)
	{
		GroupCustomerDto groupfunction = new GroupCustomerDto();
		
		GroupSworld groupSworld = GROUPDAO.getById(groupid);
		
		List<PolicySworld> lstpolicy = PolicyController.Instance.getAllByGroupId(groupid);
		
		groupfunction.setId(groupid);
		groupfunction.setName(groupSworld.getName());
		groupfunction.setDescription(groupSworld.getDescription());
		groupfunction.setPolicySworlds(lstpolicy);
		return groupfunction;
	}
	
	public GroupSworld getByGroupId(long groupId)
	{
		return GROUPDAO.getById(groupId);
	}
	
	public GroupCustomerDto addGroup(GroupCustomerDto custommer)
	{
		GroupCustomerDto groupCustommer = custommer;
		GroupSworld groupSworld = new GroupSworld();
		groupSworld.setName(custommer.getName());
		groupSworld.setDescription(custommer.getDescription());
		GroupSworld groupNew = GROUPDAO.addGroup(groupSworld);
		List<PolicySworld> lstpol = custommer.getPolicySworlds();
		if(lstpol != null)
		{
			for (PolicySworld policydto : lstpol) {
				PolicySworld policySworld = new PolicySworld();
				policySworld.setGroupId((int) groupNew.getId());
				policySworld.setAppId(policydto.getAppId());
				policySworld.setModuleId(policydto.getModuleId());
				policySworld.setDescriptions(policydto.getDescriptions());
				policySworld.setModified(policydto.getModified());
				policySworld.setInserted(policydto.getInserted());
				policySworld.setDeleted(policydto.getDeleted());
				policySworld.setViewer(policydto.getViewer());

				PolicyController.Instance.add(policySworld);
			}
		}
		else
		{
			groupCustommer = new GroupCustomerDto(groupNew.getId(), groupSworld.getName(), groupSworld.getDescription(), lstpol);
		}
		return groupCustommer;
	}
	
	public GroupCustomerDto updateGroup(GroupCustomerDto custommer)
	{
		GroupSworld groupSworld = new GroupSworld();
		groupSworld.setId(custommer.getId());
		groupSworld.setName(custommer.getName());
		groupSworld.setDescription(custommer.getDescription());
		groupSworld = GROUPDAO.updateGroup(groupSworld);
		
		List<PolicySworld> lstpol = PolicyController.Instance.getAllByGroupId(custommer.getId());
		for (PolicySworld policy : lstpol) {
			PolicyController.Instance.removePolicy(policy.getId());
		}
		for (PolicySworld policydto : custommer.getPolicySworlds()) {
			policydto.setGroupId(groupSworld.getId());
			
			PolicyController.Instance.update(policydto);
		}
		
		GroupCustomerDto groupCustommer = new GroupCustomerDto(groupSworld.getId(), groupSworld.getName(), groupSworld.getDescription(), lstpol);
		
		return groupCustommer;
	}
	
	public List<MethodResultDto> removeGroup(long groupid)
	{
		List<MethodResultDto> lstMethod = new ArrayList<MethodResultDto>();
		int kq=0;
		List<UserSworld> lstuser = USERDAO.getUser(groupid);
		if(lstuser == null)
		{
			kq =GROUPDAO.deleteGroup(groupid);
		}
		else
		{
			for (UserSworld userSworld : lstuser) {
				USERDAO.deleteUser(userSworld, userSworld.getId());
			}
			kq =GROUPDAO.deleteGroup(groupid);
		}
		boolean result = false;
		
		if(kq == ErrorCode.UNKNOW)
		{
			String subject = String.valueOf(groupid);
			String Detail = String.valueOf(ErrorCode.GROUP_NOT_FOUND);
			MethodResultDto method = new MethodResultDto(subject, methodDelete, result, Detail);
			lstMethod.add(method);
		}
		else
		{
			String subject = String.valueOf(groupid);
			result = true;
			String Detail = String.valueOf(1000);
			MethodResultDto method = new MethodResultDto(subject, methodDelete, result, Detail);
			lstMethod.add(method);
		}
		return lstMethod;
	}

}
