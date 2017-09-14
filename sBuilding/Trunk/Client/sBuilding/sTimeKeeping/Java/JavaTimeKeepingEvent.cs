using sTimeKeeping.Interface;
using sTimeKeeping.Model;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sTimeKeeping.Java
{
    /// <summary>
    /// class JavaTimeKeepingEvent : ITimeKeepingEvent
    /// </summary>
    public class JavaTimeKeepingEvent : ITimeKeepingEvent
    {
        private static JavaTimeKeepingEvent instance = new JavaTimeKeepingEvent();
        public static JavaTimeKeepingEvent Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JavaTimeKeepingEvent();
                }
                return instance;
            }
        }
        private JavaTimeKeepingEvent()
        {
        }
        public Event insertEvent(string session, Event events)
        {
            return CommunicationTimeKeepingEvent.Instance.insertEvent(session, events);
        }
        public int insertEventList(string session, List<Event> events)
        {
            return CommunicationTimeKeepingEvent.Instance.insertEventList(session, events);
        }
        public int updateEvent(string session, Event events)
        {
            return CommunicationTimeKeepingEvent.Instance.updateEvent(session, events);
        }
        public int deleteEvent(string session, long eventId)
        {
            return CommunicationTimeKeepingEvent.Instance.deleteEvent(session, eventId);
        }
        public int deleteEventList(string session, List<long> eventIdList)
        {
            return CommunicationTimeKeepingEvent.Instance.deleteEventList(session, eventIdList);
        }
        public Event getEventById(string session, long eventId)
        {
            return CommunicationTimeKeepingEvent.Instance.getEventById(session, eventId);
        }
        public List<EventDTO> getEventListBySubOrgId(string session, EventFilter eventFilter, long orgId, long subOrgId)
        {
            return CommunicationTimeKeepingEvent.Instance.getEventListBySubOrgId(session, eventFilter, orgId, subOrgId);
        }
        public List<EventDTO> getEventListByOrgId(string session, EventFilter eventFilter, long orgId)
        {
            return CommunicationTimeKeepingEvent.Instance.getEventListByOrgId(session, eventFilter, orgId);
        }

        public List<EventMember> getEventMemberListByEventId(string session, long eventId)
        {
            return CommunicationTimeKeepingEvent.Instance.getEventMemberListByEventId(session, eventId);
        }

        public int insertEventMemberListDTO(string session, EventMemberListDTO eventMemberListDTO)
        {
            return CommunicationTimeKeepingEvent.Instance.insertEventMemberListDTO(session, eventMemberListDTO);
        }

        public int insertListEventMember(string session, List<EventMember> eventMemberList)
        {
            return CommunicationTimeKeepingEvent.Instance.insertListEventMember(session, eventMemberList);
        }

        public int deleteEventMemberList(string session, List<long> listEventId)
        {
            return CommunicationTimeKeepingEvent.Instance.deleteEventMemberList(session, listEventId);
        }

        public List<Member> checkConflictEvent(string session, List<long> listEventId, long eventId, string date)
        {
            return CommunicationTimeKeepingEvent.Instance.checkConflictEvent(session, listEventId, eventId, date);
        }

        //ham import danh sach su kien cua mot thang
        public List<EventImportObject> importEventList(string session, List<EventImportObject> listEventImportObject)
        {
            return CommunicationTimeKeepingEvent.Instance.importEventList(session, listEventImportObject);
        }
    }
}
