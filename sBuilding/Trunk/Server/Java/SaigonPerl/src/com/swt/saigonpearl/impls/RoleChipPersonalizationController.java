package com.swt.saigonpearl.impls;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import com.swt.saigonpearl.IDeviceDoorGroupDeviceDoor;
import com.swt.saigonpearl.IRoleChipPersonalization;
import com.swt.saigonpearl.domain.DeviceDoorGroupDeviceDoor;
import com.swt.saigonpearl.domain.PersonalizationDevice;
import com.swt.saigonpearl.domain.RoleChipPersonalization;
import com.swt.saigonpearl.domain.RoleChipPersonalizationCustomDTO;
import com.swt.saigonpearl.domain.RoleDeviceDoorGroup;
import com.swt.sworld.customer.object.RoleChipPersonalizationDTO;
import com.swt.sworld.ps.IMemberDAO;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.ChipPersonalizationDAOImpl;
import com.swt.sworld.ps.impl.MemberDAOImpl;

;

public class RoleChipPersonalizationController {

	public static final RoleChipPersonalizationController Instance = new RoleChipPersonalizationController();
	IRoleChipPersonalization roleChipPersonalizationDAO = new RoleChipPersonalizationDAO();
	IMemberDAO memberDAO = new MemberDAOImpl();
	IDeviceDoorGroupDeviceDoor deviceDoorGroupDeviceDoor = new DeviceDoorGroupDeviceDoorDAO();
	private ChipPersonalizationDAOImpl CHIPPERSODAO = new ChipPersonalizationDAOImpl();

	public RoleChipPersonalization insert(RoleChipPersonalization roleChipPersonalization) {
		return roleChipPersonalizationDAO.insert(roleChipPersonalization);
	}

	public RoleChipPersonalization update(RoleChipPersonalization roleChipPersonalization) {
		return roleChipPersonalizationDAO.update(roleChipPersonalization);
	}

	public int delete(long roleChipPersonalizationId) {
		return roleChipPersonalizationDAO.delete(roleChipPersonalizationId);
	}

	public List<RoleChipPersonalization> getRoleChipPersonalizations() {
		return roleChipPersonalizationDAO.getRoleChipPersonalizations();
	}

	public RoleChipPersonalization getRoleChipPersonalizationById(long roleChipPersonalizationId) {
		return roleChipPersonalizationDAO.getRoleChipPersonalizationById(roleChipPersonalizationId);
	}

	/**
	 * lay danh sach nguoi dung thuoc roleid tra ve show len cho nguoi dung xem
	 * 
	 * @param roleId
	 * @return
	 */
	public List<RoleChipPersonalizationCustomDTO> getRoleChipPersonalizationsByRoleId(long roleId) {

		List<RoleChipPersonalization> lstRoleChipPersionnal = roleChipPersonalizationDAO
				.getRoleChipPersonalizationsByRoleId(roleId);
		List<RoleChipPersonalizationCustomDTO> lstRoleChipPersonalizationDTO = new ArrayList<RoleChipPersonalizationCustomDTO>();
		for (RoleChipPersonalization roleChipPersonalization : lstRoleChipPersionnal) {
			RoleChipPersonalizationCustomDTO roleChipPersonalizationCustomDTO = new RoleChipPersonalizationCustomDTO();
			roleChipPersonalizationCustomDTO
					.setRoleChipPersonalizationId(roleChipPersonalization.getRoleChipPersonalizationId());
			Member member = memberDAO.getMembeByMemberid(roleChipPersonalization.getMemberId());
			roleChipPersonalizationCustomDTO.setMember(member);
			lstRoleChipPersonalizationDTO.add(roleChipPersonalizationCustomDTO);
		}
		return lstRoleChipPersonalizationDTO;
	}

	public List<RoleChipPersonalization> getRoleChipPersonalizationsByRoleId1(long roleId) {

		List<RoleChipPersonalization> lstRoleChipPersionnal = roleChipPersonalizationDAO
				.getRoleChipPersonalizationsByRoleId(roleId);
		return lstRoleChipPersionnal;
	}

	/**
	 * Add list member in group
	 * 
	 * @param roleId
	 * @param roleChipPersonalizationDTOs
	 * @return
	 */
	public List<RoleChipPersonalization> insertRoleChipPersonalizationsByRoleId(long roleId,
			List<RoleChipPersonalizationDTO> roleChipPersonalizationDTOs) {
		// get list RoleDeviceDoorGroup
		List<RoleDeviceDoorGroup> lstGroupId = roleChipPersonalizationDAO.getListGroupByRoleId(roleId);
		boolean groupExists = lstGroupId.size() > 0;
		List<RoleChipPersonalization> roleChipPersonalizations = new ArrayList<RoleChipPersonalization>();

		if (roleChipPersonalizationDTOs != null) {
			for (RoleChipPersonalizationDTO obj : roleChipPersonalizationDTOs) {
				RoleChipPersonalization roleChipPersonalization = new RoleChipPersonalization();
				roleChipPersonalization.setMemberId(obj.getMemberId());
				roleChipPersonalization.setSerialNumber(obj.getSerialNumber());
				roleChipPersonalization.setRoleId(roleId);
				try {
					RoleChipPersonalization roleChip = insert(roleChipPersonalization);
					// after insert success and this role have config
					// accesscontrol
					if (null != roleChip && groupExists) {
						// insert
						insertPersionnalDevice(lstGroupId, roleChipPersonalization);
					}
				} catch (Exception e) {
					roleChipPersonalizations.add(roleChipPersonalization);
				}
			}
		}
		return roleChipPersonalizations;
	}

	/**
	 * insert to table PersonalizationDevice
	 * @param lstGroupId
	 * @param roleChipPersonalization
	 */
	private void insertPersionnalDevice(List<RoleDeviceDoorGroup> lstGroupId,
			RoleChipPersonalization roleChipPersonalization) {
		//init
		Set<DeviceDoorGroupDeviceDoor> setDeviceDoorGroupDeviceDoor = null;
		for (RoleDeviceDoorGroup obj : lstGroupId) {
			List<DeviceDoorGroupDeviceDoor> lsDevice = deviceDoorGroupDeviceDoor
					.getListDeviceDoorGroupDeviceDoorByGroupId(obj.getDeviceDoorGroupId());
			lsDevice.addAll(lsDevice);
			//convert to Collection Set remove element duplicate 
			setDeviceDoorGroupDeviceDoor = new HashSet<DeviceDoorGroupDeviceDoor>(lsDevice);
		}
		for (DeviceDoorGroupDeviceDoor deviceDoorGroupDeviceDoor : setDeviceDoorGroupDeviceDoor) {
			//set feild for insert
			PersonalizationDevice personalizationDevice = new PersonalizationDevice();
			personalizationDevice.setDeviceId(deviceDoorGroupDeviceDoor.getDeviceDoorId());
			personalizationDevice.setDeviceIp(deviceDoorGroupDeviceDoor.getIp());
			personalizationDevice.setMemberId(roleChipPersonalization.getMemberId());
			personalizationDevice.setSerialNumber(roleChipPersonalization.getSerialNumber());
			personalizationDevice.setRoleId(roleChipPersonalization.getRoleId());
			personalizationDevice.setDeviceDoorGroupId(deviceDoorGroupDeviceDoor.getDeviceDoorGroupId());
			PersonalizationDeviceController.Instance.insert(personalizationDevice);
		}

	}

	public List<Long> deleteListRoleChipPersonalization(List<Long> lstRoleChipId) {

		List<Long> lstIdRoleChip = new ArrayList<Long>();
		if (lstRoleChipId != null) {
			for (long roleChipId : lstRoleChipId) {
				try {
					roleChipPersonalizationDAO.delete(roleChipId);
				} catch (Exception e) {
					lstIdRoleChip.add(roleChipId);
				}
			}
		}
		return lstIdRoleChip;
	}

	/**
	 * Get list member not exit in table roleChip
	 * 
	 * @param listSubOrgId
	 * @param groupId
	 * @return
	 */
	public List<RoleChipPersonalizationCustomDTO> getListMemberByListSubOrgId(List<Long> listSubOrgId, long groupId) {
		List<Member> listMember = new ArrayList<Member>();
		List<RoleChipPersonalizationCustomDTO> listRoleChipPersonalizationCustomDTO = new ArrayList<RoleChipPersonalizationCustomDTO>();
		//
		if (listSubOrgId.size() > 0) {
			for (long subOrgId : listSubOrgId) {
				List<Member> listMemberObj = new ArrayList<Member>();

				// lay tat ca member thuoc suborg
				listMemberObj = roleChipPersonalizationDAO.getListMember(groupId, subOrgId);
				if (listMemberObj.size() > 0) {
					listMember.addAll(listMemberObj);
				}
			}
			for (Member member : listMember) {
				ChipPersonalization chipPersonalization = CHIPPERSODAO.getChipPersoforPersoCusMember(member.getId());
				RoleChipPersonalizationCustomDTO roleChipPersonalizationCustomDTO = new RoleChipPersonalizationCustomDTO();
				if (null != chipPersonalization) {
					roleChipPersonalizationCustomDTO.setMember(member);
					roleChipPersonalizationCustomDTO.setSerialNumber(chipPersonalization.getSerialNumber());
					listRoleChipPersonalizationCustomDTO.add(roleChipPersonalizationCustomDTO);
				}
			}
		}

		return listRoleChipPersonalizationCustomDTO;
	}
}
