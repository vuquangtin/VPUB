package com.swt.saigonpearl.impls;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

import com.swt.saigonpearl.IDeviceDoorGroupDeviceDoor;
import com.swt.saigonpearl.IRoleDeviceDoorGroup;
import com.swt.saigonpearl.domain.DeviceDoorGroupDeviceDoor;
import com.swt.saigonpearl.domain.PersonalizationDevice;
import com.swt.saigonpearl.domain.RoleChipPersonalization;
import com.swt.saigonpearl.domain.RoleDeviceDoorGroup;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.customer.object.DeviceDoorCustom;
import com.swt.sworld.customer.object.DeviceDoorGroupDeviceDoorDTO;
import com.swt.sworld.device.IDeviceDoor;
import com.swt.sworld.device.domain.DeviceDoor;
import com.swt.sworld.device.impls.DeviceDoorDAO;

public class DeviceDoorGroupDeviceDoorController {
	public static final DeviceDoorGroupDeviceDoorController Instance = new DeviceDoorGroupDeviceDoorController();
	IDeviceDoorGroupDeviceDoor deviceDoorGroupDeviceDoorDAO = new DeviceDoorGroupDeviceDoorDAO();
	IRoleDeviceDoorGroup roleDeviceDoorGroup = new RoleDeviceDoorGroupDAO();
	IDeviceDoor deviceDoorDAO = new DeviceDoorDAO();
	List<RoleDeviceDoorGroup> lstRoleDeviceDoorGroup;

	public DeviceDoorGroupDeviceDoor insert(DeviceDoorGroupDeviceDoor deviceDoorGroupDeviceDoor) {
		return deviceDoorGroupDeviceDoorDAO.insert(deviceDoorGroupDeviceDoor);
	}

	public int delete(long deviceDoorGroupDeviceDoorId) {
		return deviceDoorGroupDeviceDoorDAO.delete(deviceDoorGroupDeviceDoorId);
	}

	/**
	 * Lay danh sach cac thiet bi theo nhom
	 * 
	 * @param deviceDoorGroupId
	 * @return
	 */
	public List<DeviceDoor> getListDeviceDoorGroupDeviceDoorByGroupId(long deviceDoorGroupId) {
		List<DeviceDoor> listDeviceDoor = deviceDoorDAO.getDeviceDoorList();
		List<DeviceDoorGroupDeviceDoor> listDeviceDoorGroupDeviceDoor = deviceDoorGroupDeviceDoorDAO
				.getListDeviceDoorGroupDeviceDoorByGroupId(deviceDoorGroupId);
		if (null != listDeviceDoor) {
			for (DeviceDoor deviceDoor : listDeviceDoor) {
				if (null != listDeviceDoorGroupDeviceDoor) {
					for (DeviceDoorGroupDeviceDoor deviceDoorGroupDeviceDoor : listDeviceDoorGroupDeviceDoor) {
						if (deviceDoor.getId() == deviceDoorGroupDeviceDoor.getDeviceDoorId()) {
							// hien thi dau check tren man hinh client
							deviceDoor.setDeviceOfGroup(true);
						}
					}
				}
			}
		}
		return listDeviceDoor;
	}

	/**
	 * Kiem tra xem da insert chua
	 * 
	 * @param getDeviceDoorGroupDeviceDoor
	 * @param deviceDoorGroupDeviceDoorDTO
	 * @return
	 */
	public boolean checkHasContains(List<DeviceDoorGroupDeviceDoor> getDeviceDoorGroupDeviceDoor,
			DeviceDoorGroupDeviceDoorDTO deviceDoorGroupDeviceDoorDTO) {
		for (DeviceDoorGroupDeviceDoor deviceDoorGroupDeviceDoor : getDeviceDoorGroupDeviceDoor) {
			if (deviceDoorGroupDeviceDoor.getDeviceDoorId() == deviceDoorGroupDeviceDoorDTO.getDeviceDoorId()) {
				return true;
			}
		}
		return false;
	}

	/**
	 * insert mot danh sach cac devicedoorgroupdevicedoor theo groupid gom cac
	 * thiet bi theo nhom
	 * 
	 * @param deviceDoorGroupId
	 * @param deviceDoorGroupDeviceDoorDTOs
	 * @return
	 */
	public int insertListDeviceDoorGroupDeviceDoor(long deviceDoorGroupId, DeviceDoorCustom deviceDoorCustom) {
		// get list RoleDeviceDoorGroup for insert
		lstRoleDeviceDoorGroup = roleDeviceDoorGroup.getDeviceDoorGroupByGroupId(deviceDoorGroupId);
		int count = 0;
		//delte device user uncheck
		deleteDeviceDoorGroupDeviceDoor(deviceDoorCustom.getDeviceBeforeSelect(),deviceDoorGroupId);
		if (deviceDoorCustom.getDeviceAfterSelect() != null) {
			for (DeviceDoorGroupDeviceDoorDTO obj : deviceDoorCustom.getDeviceAfterSelect()) {

				DeviceDoorGroupDeviceDoor deviceDoorGroupDeviceDoor = new DeviceDoorGroupDeviceDoor();
				deviceDoorGroupDeviceDoor.setDeviceDoorGroupId(deviceDoorGroupId);
				deviceDoorGroupDeviceDoor.setDeviceDoorId(obj.getDeviceDoorId());
				deviceDoorGroupDeviceDoor.setDeviceDoordesription(obj.getDeviceDoordesription());
				deviceDoorGroupDeviceDoor.setDeviceDoorName(obj.getDeviceDoorName());
				deviceDoorGroupDeviceDoor.setIp(obj.getIp());
				try {
					DeviceDoorGroupDeviceDoor deviceDoor = deviceDoorGroupDeviceDoorDAO
							.insert(deviceDoorGroupDeviceDoor);
					// after insert device in group success
					if (null != lstRoleDeviceDoorGroup && lstRoleDeviceDoorGroup.size() > 0) {
						insertPersionalDeivice(lstRoleDeviceDoorGroup, deviceDoor);
					}

				} catch (Exception e) {
					count++;
				}
			}
		}
		if (count > 0)
			return ErrorCode.FALSED;
		return ErrorCode.SUCCESS;

	}

	/**
	 * delete recore in table devicedoorgroupdevicedoor
	 * @param deviceId
	 * @param groupId
	 */
	private void deleteDeviceDoorGroupDeviceDoor(List<Long> deviceId, long groupId) {
		for (int i = 0; i < deviceId.size(); i++) {
			deviceDoorGroupDeviceDoorDAO.deleteDevice(deviceId.get(i), groupId);
		}
	}

	/**
	 * ham nay duoc goi sau khi insert 1 thiet bi thanh cong vao group neu group
	 * do co cap quyen ra vao cho nhom nguoi
	 * 
	 * @param lstRoleDeviceDoorGroup
	 * @param deviceDoorGroup
	 */
	private void insertPersionalDeivice(List<RoleDeviceDoorGroup> lstRoleDeviceDoorGroup,
			DeviceDoorGroupDeviceDoor deviceDoorGroup) {

		Set<RoleChipPersonalization> setRoleChip = null;
		for (RoleDeviceDoorGroup roleDeviceDoorGroup : lstRoleDeviceDoorGroup) {
			// Lay danh sach tat ca cac nguoi thuoc role co cau hinh voi group
			// nay
			List<RoleChipPersonalization> lstRoleChip = RoleChipPersonalizationController.Instance
					.getRoleChipPersonalizationsByRoleId1(roleDeviceDoorGroup.getRoleId());
			lstRoleChip.addAll(lstRoleChip);
			// chuyen thanh set de loai bo cac phan tu trung nhau
			setRoleChip = new HashSet<RoleChipPersonalization>(lstRoleChip);
		}
		for (RoleChipPersonalization roleChipPersonalization : setRoleChip) {
			PersonalizationDevice personalizationDevice = new PersonalizationDevice();
			personalizationDevice.setDeviceDoorGroupId(deviceDoorGroup.getDeviceDoorGroupId());
			personalizationDevice.setRoleId(roleChipPersonalization.getRoleId());
			personalizationDevice.setSerialNumber(roleChipPersonalization.getSerialNumber());
			personalizationDevice.setMemberId(roleChipPersonalization.getMemberId());
			personalizationDevice.setDeviceId(deviceDoorGroup.getDeviceDoorId());
			personalizationDevice.setDeviceIp(deviceDoorGroup.getIp());
			PersonalizationDeviceController.Instance.insert(personalizationDevice);
		}
	}

	/**
	 * xoa cac doi tuong devicedoorgroupdevicedoor
	 * 
	 * @param lstDeviceDoorGroupDeviceDoorId
	 * @return
	 */
	public List<Long> deleteListDeviceDoorGroupDeviceDoor(List<Long> lstDeviceDoorGroupDeviceDoorId) {

		List<Long> lstDeviceDoorGroupDeviceDoor = new ArrayList<Long>();
		if (lstDeviceDoorGroupDeviceDoorId != null) {
			for (long deviceDoorGroupDeviceDoorId : lstDeviceDoorGroupDeviceDoorId) {
				try {
					deviceDoorGroupDeviceDoorDAO.delete(deviceDoorGroupDeviceDoorId);
				} catch (Exception e) {
					lstDeviceDoorGroupDeviceDoor.add(deviceDoorGroupDeviceDoorId);
				}
			}
		}
		return lstDeviceDoorGroupDeviceDoor;
	}

}
