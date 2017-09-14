package com.swt.timekeeping.impls;

import java.util.ArrayList;
import java.util.List;
import com.swt.sworld.device.domain.DeviceDoor;
import com.swt.sworld.device.impls.DeviceDoorDAO;
import com.swt.sworld.device.IDeviceDoor;
import com.swt.sworld.common.errors.ErrorCode;
import com.swt.sworld.ps.domain.ChipPersonalization;
import com.swt.sworld.ps.domain.Member;
import com.swt.sworld.ps.impl.ChipPersonalizationController;
import com.swt.sworld.ps.impl.MemberController;
import com.swt.timekeeping.customer.object.TimeKeepingAcessDTO;
import com.swt.timekeeping.domain.DeviceConfig;

/**
 * TimeKeepingDeviceConfigController
 * 
 * @author TrangPig
 * 
 */
public class TimeKeepingDeviceConfigController {
	/**
	 * Instance of TimeKeepingDeviceConfigController
	 */
	public static final TimeKeepingDeviceConfigController Instance = new TimeKeepingDeviceConfigController();

	private TimeKeepingDeviceConfigDAO tcDAO = new TimeKeepingDeviceConfigDAO();
	private IDeviceDoor deviceDoorDAO = new DeviceDoorDAO();

	/**
	 * insert TimeKeepingDeviceConfig
	 * 
	 * @param timeKeepingConfig
	 * @return TimeKeepingDeviceConfig
	 */
	public DeviceConfig insert(DeviceConfig deviceConfig) {
		return tcDAO.insert(deviceConfig);
	}

	/**
	 * update TimeKeepingDeviceConfig
	 * 
	 * @param timeKeepingConfig
	 * @return TimeKeepingDeviceConfig
	 */
	public DeviceConfig update(DeviceConfig timeKeepingConfig) {
		return tcDAO.update(timeKeepingConfig);
	}

	/**
	 * delete TimeKeepingDeviceConfig
	 * 
	 * @param timeKeepingConfigId
	 * @return int
	 */
	public int delete(long timeKeepingConfigId) {
		return tcDAO.delete(timeKeepingConfigId);
	}

	/**
	 * getTimeKeepingConfigById
	 * 
	 * @param timeKeepingConfigId
	 * @return TimeKeepingDeviceConfig
	 */
	public DeviceConfig getTimeKeepingConfigById(long timeKeepingConfigId) {
		return tcDAO.getTimeKeepingConfigById(timeKeepingConfigId);
	}

	/**
	 * Kiem tra xem thiet bi da duoc add vao to chuc chua
	 * 
	 * @param lstDeviceConfig
	 * @param deviceId
	 * @return
	 */
	public boolean checkHasContain(List<DeviceConfig> lstDeviceConfig, long deviceId) {
		// duyet list to chuc chuan bi insert
		for (DeviceConfig obj : lstDeviceConfig) {
			if (obj.getDeviceDoorId() == deviceId)
				return true;
		}
		return false;
	}

	public int insertDeviceConfigByOrgId(long orgId, List<DeviceConfig> lstDeviceConfig) {
		int count = 0;
		// lay danh sach cac deviceConfig da duoc add duoi database
		List<DeviceConfig> lstDeviceConfigExit = tcDAO.getListDeviceConfigByOrgId(orgId);
		// xoa tat ca de add danh sach moi
		if (null != lstDeviceConfigExit) {
			for (DeviceConfig deviceConfig : lstDeviceConfigExit) {
				try {
					tcDAO.delete(deviceConfig.getDeviceConfigId());
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		}
		if (null != lstDeviceConfig) {

			for (DeviceConfig obj : lstDeviceConfig) {
				// set orgId vao tung object
				obj.setOrgId(orgId);
				DeviceConfig result = insert(obj);
				//new add thanh cong tang bien count de kiem tra success hoac false;
				if (null != result) {
					count++;
				}
			}
		}
		if (count > 0) {
			return ErrorCode.SUCCESS;
		}
		return ErrorCode.FALSED;
	}

	/**
	 * Lay ve danh sach cac deviceDoor thuoc org
	 * 
	 * @param orgId
	 * @return
	 */
	public List<DeviceDoor> getListDeviceConfigByOrgId(long orgId) {
		// lay danh sach cac thiet bi
		List<DeviceDoor> listDeviceDoor = deviceDoorDAO.getDeviceDoorList();
		// lay danh sach cac thiet bi co cau hinh cham cong thuoc to chuc
		List<DeviceConfig> listDeviceConfig = tcDAO.getListDeviceConfigByOrgId(orgId);
		// gom 2 list thanh 1 list
		for (DeviceDoor deviceDoor : listDeviceDoor) {
			for (DeviceConfig deviceConfig : listDeviceConfig) {
				if (deviceDoor.getId() == deviceConfig.getDeviceDoorId()) {
					deviceDoor.setDeviceTimekeeping(true);
				}
			}
		}
		return listDeviceDoor;
	}

	public int deleteListDeviceConfig(List<Long> lstIdDeviceConfig) {
		// khoi tao list result
		List<Long> lstResult = new ArrayList<Long>();
		if (null != lstIdDeviceConfig) {
			for (long idDeviceConfig : lstIdDeviceConfig) {
				try {
					tcDAO.delete(idDeviceConfig);
				} catch (Exception e) {
					// neu add that bai thi add vao
					lstResult.add(idDeviceConfig);
				}
			}
		}
		// neu list co bao nhieu phan tu thi se co bay nhieu phan tu add that
		// bai
		if (lstResult.size() > 0) {
			return ErrorCode.FALSED;
		}
		// nguoc lai xem nhu add thanh cong
		return ErrorCode.SUCCESS;
	}

	public TimeKeepingAcessDTO checkIpDeviceForTimeKeeping(String serial, String deviceConfigIp) {
		TimeKeepingAcessDTO result = null;
		List<DeviceConfig> configList = tcDAO.getTimeKeepingConfigByIp(deviceConfigIp);
		if (null != configList && configList.size() != 0) {
			result = new TimeKeepingAcessDTO();
			ChipPersonalization chipper = ChipPersonalizationController.Instance.getBySerial(serial);
			if (null != chipper) {
				Member member = MemberController.Instance.getMemberById(chipper.getPsMemberId());
				if (null != member)
					result.setMemberId(member.getId());
				result.setDeviceDoorId(configList.get(0).getDeviceDoorId());
			}
		}
		return result;
	}
}
