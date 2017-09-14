
using sMeetingComponent.Model;
using sNonResidentComponent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sNonResidentComponent.Interface
{
    public interface IRoom
    {
        List<Room> getListRoom(string session);
    }
}
