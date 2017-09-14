using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sWorldCommunication
{
   public interface ITimeKeeping
    {
        List<DoorOut> GetDoorOutListByYear(string session, String year);
        List<DoorOut> GetDoorOutListByMonth(string session, String year, String month);
        List<DoorOut> GetDoorOutListByDay(string session, String date, String serial, String deviceId);

    }
}
