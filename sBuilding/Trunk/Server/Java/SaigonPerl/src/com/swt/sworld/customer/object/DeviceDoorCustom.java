/**
 * 
 */
package com.swt.sworld.customer.object;

import java.util.List;

/**
 * @author Tenit
 *
 */
public class DeviceDoorCustom {
	private List<Long> deviceBeforeSelect;
    private List<DeviceDoorGroupDeviceDoorDTO> deviceAfterSelect;
	public List<Long> getDeviceBeforeSelect() {
		return deviceBeforeSelect;
	}
	public void setDeviceBeforeSelect(List<Long> deviceBeforeSelect) {
		this.deviceBeforeSelect = deviceBeforeSelect;
	}
	public List<DeviceDoorGroupDeviceDoorDTO> getDeviceAfterSelect() {
		return deviceAfterSelect;
	}
	public void setDeviceAfterSelect(List<DeviceDoorGroupDeviceDoorDTO> deviceAfterSelect) {
		this.deviceAfterSelect = deviceAfterSelect;
	}
    
    
}
