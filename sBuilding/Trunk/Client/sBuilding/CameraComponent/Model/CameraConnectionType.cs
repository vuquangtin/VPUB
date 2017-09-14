using System;
using System.Collections.Generic;
using System.Linq;

namespace CameraComponent.Model
{
    public enum CameraConnectionType : int
    {
        NetworkCameraViaRtsp = 1,
        //CcdCameraViaVec800x = 2,
    }

    internal static class CameraConnectionTypeExt
    {
        public static List<CameraConnectionType> GetCameraConnectionTypeList()
        {
            var result = Enum.GetValues(typeof(CameraConnectionType)).Cast<CameraConnectionType>().ToList();
            result.Sort((x, y) => { return string.Compare(x.GetName(), y.GetName()); });
            return result;
        }

        public static string GetName(this CameraConnectionType type)
        {
            switch (type)
            {
                case CameraConnectionType.NetworkCameraViaRtsp:
                    return "Kết nối Network Camera dùng giao thức RTSP";
                //case CameraConnectionType.CcdCameraViaVec800x:
                    //return "Kết nối CCD Camera thông qua Card DVR VEC800X";
                default:
                    return string.Empty;
            }
        }
    }
}