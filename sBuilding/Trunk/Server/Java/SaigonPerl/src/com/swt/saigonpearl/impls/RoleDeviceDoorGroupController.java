package com.swt.saigonpearl.impls;

import java.util.List;

import com.swt.saigonpearl.IDeviceDoorGroup;
import com.swt.saigonpearl.IDeviceDoorGroupDeviceDoor;
import com.swt.saigonpearl.IRoleChipPersonalization;
import com.swt.saigonpearl.IRoleDeviceDoorGroup;
import com.swt.saigonpearl.domain.DeviceDoorGroup;
import com.swt.saigonpearl.domain.DeviceDoorGroupDeviceDoor;
import com.swt.saigonpearl.domain.PersonalizationDevice;
import com.swt.saigonpearl.domain.RoleChipPersonalization;
import com.swt.saigonpearl.domain.RoleDeviceDoorGroup;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.customer.object.DeviceDoorGroupPostToServer;

public class RoleDeviceDoorGroupController {

	public static final RoleDeviceDoorGroupController Instance = new RoleDeviceDoorGroupController();
	IRoleDeviceDoorGroup roleDeviceDoorGroupDAO = new RoleDeviceDoorGroupDAO();
	IDeviceDoorGroup deviceDoorGroupDAO = new DeviceDoorGroupDAO();
	IRoleChipPersonalization roleChipPersonalizationDAO = new RoleChipPersonalizationDAO();
	IDeviceDoorGroupDeviceDoor deviceDoorGroupDeviceDoorDAO = new DeviceDoorGroupDeviceDoorDAO();

	public RoleDeviceDoorGroup insert(RoleDeviceDoorGroup roleDeviceDoorGroup) {
		return roleDeviceDoorGroupDAO.insert(roleDeviceDoorGroup);
	}

	public RoleDeviceDoorGroup update(RoleDeviceDoorGroup roleDeviceDoorGroup) {
		return roleDeviceDoorGroupDAO.update(roleDeviceDoorGroup);
	}

	public int delete(long roleDeviceDoorGroupId) {
		return roleDeviceDoorGroupDAO.delete(roleDeviceDoorGroupId);
	}

	public List<RoleDeviceDoorGroup> getRoleDeviceDoorGroups() {
		return roleDeviceDoorGroupDAO.getRoleDeviceDoorGroups();
	}

	public RoleDeviceDoorGroup getRoleDeviceDoorGroupById(long roleDeviceDoorGroupId) {
		return roleDeviceDoorGroupDAO.getRoleDeviceDoorGroupById(roleDeviceDoorGroupId);
	}

	

	/**
	 * insert mot doi tuong devicedoorgroup theo role id,lay danh sach
	 * roledevicedoorgroup theo roleid kiem tra neu da co thi se khong add
	 * 
	 * @param roleId
	 * @param deviceDoorGroup
	 * @return
	 */
	public int insertRoleDeviceDoorGroupByRoleId(long roleId, DeviceDoorGroupPostToServer deviceDoorGroupId) {
		int count = 0;
		List<Long> listIdUnCheck = deviceDoorGroupId.getLstIdGroupBeforeCheck();
		List<Long> listIdCheck = deviceDoorGroupId.getLstIdGroupAfterCheck();
		//delete all Id use uncheck
		for (long idGroupDevice : listIdUnCheck) {
			roleDeviceDoorGroupDAO.deleteRoleDeviceDoorGroup(roleId, idGroupDevice);
		}
		//set lai cac object role devicedoorgroup nguoi dung moi add vao
		for (long idGroupDevice : listIdCheck) {
			RoleDeviceDoorGroup roleDeviceDoorGroup = new RoleDeviceDoorGroup();
			roleDeviceDoorGroup.setRoleId(roleId);
			roleDeviceDoorGroup.setDeviceDoorGroupId(idGroupDevice);
			try {
				RoleDeviceDoorGroup objectResult = insert(roleDeviceDoorGroup);
				if (null != objectResult) {
					//insert thanh cong thi gan vao bang map giua nguoi va device
					setRoleDeviceDoorGroupObject(objectResult);
				}
			} catch (Exception e) {
				// if insert khong thanh cong thi tang bien count
				count++;
			}
		}
		if (count > 0) {
			return ErrorCode.FALSED;
		}
		return ErrorCode.SUCCESS;
	}

	/**
	 * Get list Device door group by roleId if DeviceDoorGroup in 
	 * RoleDeviceDoorGroup, Set true value
	 * 
	 * @param roleId
	 * @return
	 */
	public List<DeviceDoorGroup> getRoleDeviceDoorGroupByRoleId(long roleId) {

		List<RoleDeviceDoorGroup> listRoleDeviceDoorGroup = roleDeviceDoorGroupDAO.getDeviceDoorGroupByRoleId(roleId);
		List<DeviceDoorGroup> listDeviceDoorGroup = deviceDoorGroupDAO.getDeviceDoorGroup();
		if (null != listDeviceDoorGroup) {
			for (DeviceDoorGroup deviceDoorGroup : listDeviceDoorGroup) {
				if (null != listRoleDeviceDoorGroup) {
					for (RoleDeviceDoorGroup roleDeviceDoorGroup : listRoleDeviceDoorGroup) {
						if (deviceDoorGroup.getDeviceDoorGroupId() == roleDeviceDoorGroup.getDeviceDoorGroupId()) {
							deviceDoorGroup.setAddGroupMember(true);
						}
					}
				}
			}

		}
		return listDeviceDoorGroup;
	}

	public List<RoleDeviceDoorGroup> getRoleDeviceDoorGroupByGroupId(long groupId) {
		return roleDeviceDoorGroupDAO.getDeviceDoorGroupByGroupId(groupId);
	}

	/**
	 * Ham nay dung de luu xuong database nguoi nao duoc vao cua nao
	 * 
	 * @param roleId
	 *            lay danh sach cac nguoi thuoc id nay
	 * @param deviceDoorGroupId
	 *            lay danh sach cac thiet bi thuoc nhom thiet bi nay
	 * @return
	 */
	public void setRoleDeviceDoorGroupObject(RoleDeviceDoorGroup roleDeviceDoorGroup) {

		// day la list nguoi thuoc role
		List<RoleChipPersonalization> lstRoleChipPersonalization = RoleChipPersonalizationController.Instance
				.getRoleChipPersonalizationsByRoleId1(roleDeviceDoorGroup.getRoleId());
		// day la list device thuoc group device
		List<DeviceDoorGroupDeviceDoor> lstDeviceDoorGroupDeviceDoor = deviceDoorGroupDeviceDoorDAO
				.getListDeviceDoorGroupDeviceDoorByGroupId(roleDeviceDoorGroup.getDeviceDoorGroupId());
		// duyet list nguoi thuoc role
		if (null != lstRoleChipPersonalization) {
			for (RoleChipPersonalization roleChipPersonalization : lstRoleChipPersonalization) {
				
				long memberId = roleChipPersonalization.getMemberId();
				String serialNumber = roleChipPersonalization.getSerialNumber();
				if (null != lstDeviceDoorGroupDeviceDoor) {

					for (DeviceDoorGroupDeviceDoor deviceDoorGroupDeviceDoor : lstDeviceDoorGroupDeviceDoor) {
						PersonalizationDevice personalizationDevice = new PersonalizationDevice();
						personalizationDevice.setMemberId(memberId); // memberId
						personalizationDevice.setSerialNumber(serialNumber);// serialNumber//day la 2 tham so chung
						personalizationDevice.setDeviceId(deviceDoorGroupDeviceDoor.getDeviceDoorId()); // id
						personalizationDevice.setDeviceIp(deviceDoorGroupDeviceDoor.getIp()); // ip
						//set 2 thuoc tinh ben duoi de do tam thoi chua su dung
						personalizationDevice.setRoleId(roleDeviceDoorGroup.getRoleId());
						personalizationDevice.setDeviceDoorGroupId(roleDeviceDoorGroup.getDeviceDoorGroupId());
						PersonalizationDeviceController.Instance.insert(personalizationDevice);
					}
				}
			}
		}

	}

	
}
