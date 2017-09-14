using sTimeKeeping.Model;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Interface
{
    /// <summary>
    /// interface ITimeKeepingEvent
    /// </summary>
    public interface ITimeKeepingEvent
    {
        /// <summary>
        /// insert Event
        /// </summary>
        /// <param name="session"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        Event insertEvent(string session, Event events);
        /// <summary>
        /// insert EventList
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventList"></param>
        /// <returns></returns>
        int insertEventList(string session, List<Event> eventList);
        /// <summary>
        /// update Event
        /// </summary>
        /// <param name="session"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        int updateEvent(string session, Event events);
        /// <summary>
        /// delete Event
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        int deleteEvent(string session, long eventId);
        /// <summary>
        /// delete Event List
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventIdList"></param>
        /// <returns></returns>
        int deleteEventList(string session, List<long> eventIdList);
        /// <summary>
        /// get Event By Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        Event getEventById(string session, long eventId);
        /// <summary>
        /// get Event List By SubOrgId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventFilter"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <returns></returns>
        List<EventDTO> getEventListBySubOrgId(string session, EventFilter eventFilter, long orgId, long subOrgId);
        /// <summary>
        /// get EventList By OrgId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventFilter"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        List<EventDTO> getEventListByOrgId(string session, EventFilter eventFilter, long orgId);
        /// <summary>
        /// load danh sach member cho 1 event
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        List<EventMember> getEventMemberListByEventId(string session, long eventId);
        /// <summary>
        /// insert EventMemberListDTO
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventMemberListDTO"></param>
        /// <returns></returns>
        int insertEventMemberListDTO(string session, EventMemberListDTO eventMemberListDTO);
        /// <summary>
        /// insert List Event Member
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventMemberList"></param>
        /// <returns></returns>
        int insertListEventMember(string session, List<EventMember> eventMemberList);
        /// <summary>
        /// delete list event member
        /// </summary>
        /// <param name="session"></param>
        /// <param name="listEventId"></param>
        /// <returns></returns>
        int deleteEventMemberList(string session, List<long> listEventId);
        /// <summary>
        ///  kiem tra mot danh sach member dang ky event co bi trung event ko
        /// </summary>
        /// <param name="session"></param>
        /// <param name="listEventId"></param>
        /// <param name="eventId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        List<Member> checkConflictEvent(string session, List<long> listEventId, long eventId, string date);
        /// <summary>
        /// import danh sach su kien cua mot thang
        /// </summary>
        /// <param name="session"></param>
        /// <param name="listDayOffImportObject"></param>
        /// <returns></returns>
        List<EventImportObject> importEventList(string session, List<EventImportObject> listDayOffImportObject);
    }
}
