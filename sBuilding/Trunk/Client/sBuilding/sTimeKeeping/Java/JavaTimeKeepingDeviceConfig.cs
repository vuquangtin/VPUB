using sBuildingCommunication.Model;
using sTimeKeeping.Interface;
using sTimeKeeping.Model;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Java
{
    /// <summary>
    /// JavaTimeKeepingDeviceConfig : ITimeKeepingDeviceConfig
    /// </summary>
    public class JavaTimeKeepingDeviceConfig : ITimeKeepingDeviceConfig
    {
        private static JavaTimeKeepingDeviceConfig instance = new JavaTimeKeepingDeviceConfig();
        public static JavaTimeKeepingDeviceConfig Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaTimeKeepingDeviceConfig();
                }
                return instance;
            }
        }
        private JavaTimeKeepingDeviceConfig()
        {
        }
        public DeviceConfig InsertDeviceConfig(string session, DeviceConfig deviceConfig)
        {
            return CommunicationTimeKeepingDeviceConfig.Instance.InsertDeviceConfig(session, deviceConfig);
        }
        public DeviceConfig UpdateDeviceConfig(string session, DeviceConfig deviceConfig)
        {
            return CommunicationTimeKeepingDeviceConfig.Instance.UpdateDeviceConfig(session, deviceConfig);
        }
        public int DeleteDeviceConfig(string session, long deviceConfigId)
        {
            return CommunicationTimeKeepingDeviceConfig.Instance.DeleteDeviceConfig(session, deviceConfigId);
        }
        public DeviceConfig GetDeviceConfigById(string session, long deviceConfigId)
        {
            return CommunicationTimeKeepingDeviceConfig.Instance.GetDeviceConfigById(session, deviceConfigId);
        }

        public int InsertDeviceByOrgId(string session, long orgId, List<DeviceConfig> lstDevice)
        {
            return CommunicationTimeKeepingDeviceConfig.Instance.InsertDeviceByOrgId(session, orgId, lstDevice);

        }
        public int DeleteListDeviceConfig(string session, List<long> lstDevice)
        {
            return CommunicationTimeKeepingDeviceConfig.Instance.DeleteListDeviceConfig(session, lstDevice);
        }
        public List<DeviceDoor> GetListDeviceConfigByOrgId(string session, long orgId)
        {
            return CommunicationTimeKeepingDeviceConfig.Instance.GetListDeviceConfigByOrgId(session, orgId);
        }
        public TimeKeepingAcessDTO CheckIpDeviceForTimeKeeping(string session, string serial, string deviceconfigip)
        {
            return CommunicationTimeKeepingDeviceConfig.Instance.CheckIpDeviceForTimeKeeping(session, serial, deviceconfigip);
        }
    }
}
