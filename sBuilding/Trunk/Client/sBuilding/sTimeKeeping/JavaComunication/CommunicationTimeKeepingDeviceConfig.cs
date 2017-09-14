using JavaCommunication;
using JavaCommunication.Common;
using sTimeKeeping.Constants;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Model
{
    public class CommunicationTimeKeepingDeviceConfig : CommunicationCommon
    {
        private static CommunicationTimeKeepingDeviceConfig instance = new CommunicationTimeKeepingDeviceConfig();

        public static CommunicationTimeKeepingDeviceConfig Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationTimeKeepingDeviceConfig();
                }
                return instance;
            }
        }

        public CommunicationTimeKeepingDeviceConfig() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"timekeepingconfigmgt";
        }

        public DeviceConfig InsertDeviceConfig(string session, DeviceConfig deviceConfig)
        {
            string parameters = Utilites.Instance.Paramater(session);
            DeviceConfig result = PostDataToServerObject(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_DEVICE_CONFIG, parameters, deviceConfig, new DeviceConfig().GetType()) as DeviceConfig;
            return result;
        }
        public DeviceConfig UpdateDeviceConfig(string session, DeviceConfig deviceConfig)
        {
            string parameters = Utilites.Instance.Paramater(session);
            DeviceConfig result = PostDataToServerObject(session, TimeKeepingMethodNames.UPDATE_TIMEKEEPING_DEVICE_CONFIG, parameters, deviceConfig, new DeviceConfig().GetType()) as DeviceConfig;
            return result;
        }
        public int DeleteDeviceConfig(string session, long deviceConfigId)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceConfigId);
            return GetDataFromServer(session, TimeKeepingMethodNames.DELETE_TIMEKEEPING_DEVICE_CONFIG, parameters);
        }
        public DeviceConfig GetDeviceConfigById(string session, long deviceConfigId)
        {
            string parameters = Utilites.Instance.Paramater(session, deviceConfigId);
            DeviceConfig result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_DEVICE_CONFIG_BY_DECONFIGID, parameters, new DeviceConfig().GetType()) as DeviceConfig;
            return result;
        }

        public int InsertDeviceByOrgId(string session, long orgId, List<DeviceConfig> lstDeviceDoor)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            return PostDataFromServer(session, TimeKeepingMethodNames.INSERT_DEVICE_CONFIG_BY_ORG_ID, parameters, lstDeviceDoor);

        }

        public int DeleteListDeviceConfig(string session, List<long> lstDeviceDoor)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.DELETE_LIST_DEVICE_CONFIG, parameters, lstDeviceDoor);
        }
        public List<DeviceDoor> GetListDeviceConfigByOrgId(string session, long orgId)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            List<DeviceDoor> result = GetDataFromServer(session, TimeKeepingMethodNames.GET_LIST_DEVICECONFIG_BY_ORG_ID, parameters, new List<DeviceDoor>().GetType()) as List<DeviceDoor>;
            return result;
        }

        public TimeKeepingAcessDTO CheckIpDeviceForTimeKeeping(string session, string serial, string deviceconfigip)
        {
            string parameters = Utilites.Instance.Paramater(session, serial, deviceconfigip);
            TimeKeepingAcessDTO result = GetDataFromServer(session, TimeKeepingMethodNames.CHECK_DEVICE_IP_CONFIG, parameters, new TimeKeepingAcessDTO().GetType()) as TimeKeepingAcessDTO;
            return result;
        }
    }
}

