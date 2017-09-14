using sBuildingCommunication.Model;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Interface
{
    /// <summary>
    /// interface ITimeKeepingDeviceConfig
    /// </summary>
    public interface ITimeKeepingDeviceConfig
    {
        /// <summary>
        /// Insert DeviceConfig
        /// </summary>
        /// <param name="session"></param>
        /// <param name="deviceConfig"></param>
        /// <returns></returns>
        DeviceConfig InsertDeviceConfig(string session, DeviceConfig deviceConfig);
        /// <summary>
        /// Update DeviceConfig
        /// </summary>
        /// <param name="session"></param>
        /// <param name="deviceConfig"></param>
        /// <returns></returns>
        DeviceConfig UpdateDeviceConfig(string session, DeviceConfig deviceConfig);
        /// <summary>
        /// Delete DeviceConfig
        /// </summary>
        /// <param name="session"></param>
        /// <param name="deviceConfigId"></param>
        /// <returns></returns>
        int DeleteDeviceConfig(string session, long deviceConfigId);
        /// <summary>
        /// Get Device Config By Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="deviceConfigId"></param>
        /// <returns></returns>
        DeviceConfig GetDeviceConfigById(string session, long deviceConfigId);
        /// <summary>
        /// Insert Device By OrgId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <param name="lstDevice"></param>
        /// <returns></returns>
        int InsertDeviceByOrgId(string session, long orgId, List<DeviceConfig> lstDevice);
        /// <summary>
        /// Delete List DeviceConfig
        /// </summary>
        /// <param name="session"></param>
        /// <param name="lstIdDevice"></param>
        /// <returns></returns>
        int DeleteListDeviceConfig(string session, List<long> lstIdDevice);
        /// <summary>
        /// Get ListDeviceConfig By OrgId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        List<DeviceDoor> GetListDeviceConfigByOrgId(string session, long orgId);
        /// <summary>
        /// Check Ip Device For TimeKeeping
        /// </summary>
        /// <param name="session"></param>
        /// <param name="serial"></param>
        /// <param name="deviceconfigip"></param>
        /// <returns></returns>
        TimeKeepingAcessDTO CheckIpDeviceForTimeKeeping(string session, string serial, string deviceconfigip);
    }
}
