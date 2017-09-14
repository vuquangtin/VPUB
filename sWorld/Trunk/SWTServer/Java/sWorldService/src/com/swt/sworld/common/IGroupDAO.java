package com.swt.sworld.common;

import java.util.List;

import com.swt.sworld.common.domain.GroupSworld;

public interface IGroupDAO {
	
	List<GroupSworld> getGroupList();
	
	GroupSworld getById(long groupid);
	
	GroupSworld addGroup(GroupSworld groupcustommer);
	
	GroupSworld updateGroup(GroupSworld groupcustommer);
	
	int deleteGroup(long groupid);

}
