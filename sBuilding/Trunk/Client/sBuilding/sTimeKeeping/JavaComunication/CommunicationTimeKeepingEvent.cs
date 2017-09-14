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
    /// <summary>
    ///  class CommunicationTimeKeepingEvent: CommunicationCommon
    /// </summary>
    public class CommunicationTimeKeepingEvent : CommunicationCommon
    {
        private static CommunicationTimeKeepingEvent instance = new CommunicationTimeKeepingEvent();

        public static CommunicationTimeKeepingEvent Instance
        {
            get
            {
                if (null == instance)
                {
                    instance = new CommunicationTimeKeepingEvent();
                }
                return instance;
            }
        }

        public CommunicationTimeKeepingEvent() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"timekeepingeventmgt";
        }
        /// <summary>
        /// insert Event
        /// </summary>
        /// <param name="session"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public Event insertEvent(string session, Event events)
        {
            string parameters = Utilites.Instance.Paramater(session);
            Event eventObj = PostDataToServerObject(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_EVENT, parameters, events, new Event().GetType()) as Event;
            return eventObj;

        }
        /// <summary>
        /// insert Event List
        /// </summary>
        /// <param name="session"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public int insertEventList(string session, List<Event> events)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_EVENT_LIST, parameters, events);

        }
        /// <summary>
        /// update Event
        /// </summary>
        /// <param name="session"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public int updateEvent(string session, Event events)
        {
            string parameters = Utilites.Instance.Paramater(session);
            Event eventss = PostDataToServerObject(session, TimeKeepingMethodNames.UPDATE_TIMEKEEPING_EVENT, parameters, events, new Event().GetType()) as Event;
            if (null != eventss)
                return (int)Status.SUCCESS;
            else
                return (int)Status.FAILED;
        }
        /// <summary>
        /// delete Event
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public int deleteEvent(string session, long eventId)
        {
            string parameters = Utilites.Instance.Paramater(session, eventId);
            return GetDataFromServer(session, TimeKeepingMethodNames.DELETE_TIMEKEEPING_EVENT, parameters);
        }
        /// <summary>
        /// delete Event List
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventIdList"></param>
        /// <returns></returns>
        public int deleteEventList(string session, List<long> eventIdList)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.DELETE_TIMEKEEPING_EVENT_LIST, parameters, eventIdList);
        }
        /// <summary>
        /// get Event By Id
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public Event getEventById(string session, long eventId)
        {
            string parameters = Utilites.Instance.Paramater(session, eventId);
            Event result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_EVENT_BY_EVENTID, parameters, new Event().GetType()) as Event;
            return result;
        }
        /// <summary>
        /// get Event List By SubOrgId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventFilter"></param>
        /// <param name="orgId"></param>
        /// <param name="subOrgId"></param>
        /// <returns></returns>
        public List<EventDTO> getEventListBySubOrgId(string session, EventFilter eventFilter, long orgId, long subOrgId)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId, subOrgId);
            List<EventDTO> result = PostDataToServerObject(session, TimeKeepingMethodNames.GET_TIMEKEEPING_EVENT_LIST_BY_SUBORGID, parameters, eventFilter, new List<EventDTO>().GetType()) as List<EventDTO>;
            return result;
        }
        /// <summary>
        /// get Event List By OrgId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventFilter"></param>
        /// <param name="orgId"></param>
        /// <returns></returns>
        public List<EventDTO> getEventListByOrgId(string session, EventFilter eventFilter, long orgId)
        {
            string parameters = Utilites.Instance.Paramater(session, orgId);
            List<EventDTO> result = PostDataToServerObject(session, TimeKeepingMethodNames.GET_TIMEKEEPING_EVENT_LIST_BY_ORGID, parameters, eventFilter, new List<EventDTO>().GetType()) as List<EventDTO>;
            return result;
        }
        // cac ham ket hop 

        /// <summary>
        /// get Event Member List By EventId
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public List<EventMember> getEventMemberListByEventId(string session, long eventId)
        {
            string parameters = Utilites.Instance.Paramater(session, eventId);
            List<EventMember> result = GetDataFromServer(session, TimeKeepingMethodNames.GET_TIMEKEEPING_EVENT_MEMBER_BY_EVENTID, parameters,
                new List<EventMember>().GetType()) as List<EventMember>;
            return result;
        }
        /// <summary>
        /// insert Event Member List DTO
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventMemberListDTO"></param>
        /// <returns></returns>
        public int insertEventMemberListDTO(string session, EventMemberListDTO eventMemberListDTO)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_EVENT_MEMBER_LIST_DTO, parameters, eventMemberListDTO);
        }
        /// <summary>
        /// insert List Event Member
        /// </summary>
        /// <param name="session"></param>
        /// <param name="eventMemberList"></param>
        /// <returns></returns>
        public int insertListEventMember(string session, List<EventMember> eventMemberList)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.INSERT_TIMEKEEPING_LIST_EVENT_MEMBER, parameters, eventMemberList);
        }
        /// <summary>
        /// delete list event member
        /// </summary>
        /// <param name="session"></param>
        /// <param name="listEventId"></param>
        /// <returns></returns>
        public int deleteEventMemberList(string session, List<long> listEventId)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, TimeKeepingMethodNames.DELETE_TIMEKEEPING_EVENT_MEMBER_LIST, parameters, listEventId);
        }
        /// <summary>
        /// kiem tra mot danh sach member dang ky event co bi trung event ko
        /// </summary>
        /// <param name="session"></param>
        /// <param name="listEventId"></param>
        /// <param name="eventId"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<Member> checkConflictEvent(string session, List<long> listEventId, long eventId, string date)
        {
            string parameters = Utilites.Instance.Paramater(session, eventId, date);
            List<Member> result = PostDataToServerObject(session, TimeKeepingMethodNames.CHECK_CONFLICT_EVENT, parameters, listEventId, new List<Member>().GetType()) as List<Member>;
            return result;
        }
        /// <summary>
        ///  import danh sach su kien cua mot thang
        /// </summary>
        /// <param name="session"></param>
        /// <param name="listEventImportObject"></param>
        /// <returns></returns>
        public List<EventImportObject> importEventList(string session, List<EventImportObject> listEventImportObject)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<EventImportObject> result = PostDataToServerObject(session, TimeKeepingMethodNames.IMPORT_lIST_EVENT, parameters, listEventImportObject, new List<EventImportObject>().GetType()) as List<EventImportObject>;
            return result;
        }
    }
}
