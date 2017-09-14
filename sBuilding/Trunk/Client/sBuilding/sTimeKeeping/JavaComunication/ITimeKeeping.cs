using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.JavaComunication
{
    public interface ITimeKeeping
    {
        List<Shift> GetDoorOutListByYear(string session, String year);
        List<Shift> GetDoorOutListByMonth(string session, String year, String month);
        List<Shift> GetDoorOutListByDay(string session, String date, String serial, String deviceId);

    }
}
