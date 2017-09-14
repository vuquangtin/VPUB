using sMeetingComponent.Model;
using sMeetingComponent.Model.CustomObj;
using sMeetingComponent.Model.CustomObj.PersonHaveBarcode;
using sMeetingComponent.Model.CustomObj.PersonNotBarcode;
using System;
using System.Collections.Generic;

namespace sMeetingComponent.Interface
{
    public interface  IAttendMeeting
    {
        NumberObj checkInOutEventAttendMeeting(string session, String barcode);
        int insertEventAttendMeeting(string session, List<EventAttendMeeting> eventAttendMeeting);
        int insertAttendMeetingNotBarcode(string session, PersonNotBarcodeObj personNotBarcodeObj);
        int insertEventAttendMeetingEnterprise(string session, List<NonResident> listNoresident);
    }
}
