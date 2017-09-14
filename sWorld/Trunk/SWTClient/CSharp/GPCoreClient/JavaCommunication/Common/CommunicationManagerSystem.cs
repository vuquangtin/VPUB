using sWorldModel.Filters;
using sWorldModel.Model;
using sWorldModel.TransportData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JavaCommunication.Common
{
    public class CommunicationManagerSystem : CommunicationCommon
    {
        private static CommunicationManagerSystem instance = new CommunicationManagerSystem();
        public static CommunicationManagerSystem Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CommunicationManagerSystem();
                }
                return instance;
            }
        }
        public CommunicationManagerSystem() { }

        protected override void BaseURL()
        {
            base.BaseURL();
            _baseUrl += @"other";
        }

        public List<GroupDto> GetGroupList(string session, GroupFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<GroupDto> result = PostDataToServerObject(session, MethodNames.GET_GROUP_LIST, parameters, filter, new List<GroupDto>().GetType()) as List<GroupDto>;

            if (null == result) throw new Exception();

            return result;
        }

        public GroupCustomerDto GetGroupById(string session, long groupId)
        {
            string parameters = Utilites.Instance.Paramater(session, groupId);
            GroupCustomerDto result = GetDataFromServer(session, MethodNames.GET_GROUP_BY_ID, parameters, new GroupCustomerDto().GetType()) as GroupCustomerDto;

            if (null == result) throw new Exception();

            return result;
        }

        public GroupCustomerDto AddGroup(string session, GroupCustomerDto group)
        {
            string parameters = Utilites.Instance.Paramater(session);
            GroupCustomerDto result = PostDataToServerObject(session, MethodNames.ADD_GROUP, parameters, group, new GroupCustomerDto().GetType()) as GroupCustomerDto;

            if (null == result) throw new Exception();

            return result;
        }

        public int UpdateGroup(string session, GroupCustomerDto group)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.UPDATE_GROUP, parameters, group);
        }

        public List<MethodResultDto> RemoveGroups(string session, long groupId)
        {
            string parameters = Utilites.Instance.Paramater(session, groupId);
            List<MethodResultDto> result = GetDataFromServer(session, MethodNames.REMOVE_GROUPS, parameters, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;

            if (null == result) throw new Exception();

            return result;
        }

        public List<UserSworld> GetUserList(string session, UserFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<UserSworld> result = PostDataToServerObject(session, MethodNames.GET_USER_LIST, parameters, filter, new List<UserSworld>().GetType()) as List<UserSworld>;

            if (null == result) throw new Exception();

            return result; 
        }

        public UserSworld GetUserById(string session, long userId)
        {
            string parameters = Utilites.Instance.Paramater(session, userId);
            UserSworld result = GetDataFromServer(session, MethodNames.GET_USER_BY_ID, parameters, new UserSworld().GetType()) as UserSworld;

            if (null == result) throw new Exception();

            return result;
        }
        public UserSworld AddUser(string session, UserSworld user)
        {
            string parameters = Utilites.Instance.Paramater(session);
            UserSworld result = PostDataToServerObject(session, MethodNames.ADD_USER, parameters, user, new UserSworld().GetType()) as UserSworld;
            return result;
        }

        public int UpdateUser(string session, UserSworld userNew)
        {
            string parameters = Utilites.Instance.Paramater(session);
            return PostDataFromServer(session, MethodNames.UPDATE_USER, parameters, userNew);
        }

        public int ChangeUserGroup(string session, long userId, long newGroupId)
        {
            string parameters = Utilites.Instance.Paramater(session, userId, newGroupId);
            return GetDataFromServer(session, MethodNames.CHANGE_USER_GROUP, parameters);
        }

        public int ChangePassword(string session, string oldPassword, string newPassword)
        {
            string parameters = Utilites.Instance.Paramater(session, oldPassword, newPassword);
            return GetDataFromServer(session, MethodNames.CHANGE_PASSWORD, parameters);
        }

        public int ResetPassword(string session, long userId, string newPassword)
        {
            string parameters = Utilites.Instance.Paramater(session, userId, newPassword);
            return GetDataFromServer(session, MethodNames.RESET_PASSWORD, parameters);
        }

        public List<MethodResultDto> LockUsers(string session, long[] userIds)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.LOCK_USERS, parameters, userIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;

            if (null == result) throw new Exception();

            return result;
        }

        public List<MethodResultDto> UnLockUsers(string session, long[] userIds)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.UNLOCK_USERS, parameters, userIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;

            if (null == result) throw new Exception();

            return result;
        }

        public List<MethodResultDto> RemoveUsers(string session, long[] userIds)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<MethodResultDto> result = PostDataToServerObject(session, MethodNames.REMOVE_USERS, parameters, userIds, new List<MethodResultDto>().GetType()) as List<MethodResultDto>;

            if (null == result) throw new Exception();

            return result;
        }

        public List<LoginHistoryDTO> GetLoginHistoryList(string session, LoginHistoryFilterDto filter)
        {
            string parameters = Utilites.Instance.Paramater(session);
            List<LoginHistoryDTO> result = PostDataToServerObject(session, MethodNames.GET_lOGIN_HISTORY_LIST, parameters, filter, new List<LoginHistoryDTO>().GetType()) as List<LoginHistoryDTO>;

            if (null == result) throw new Exception();

            return result;
        }

        public List<PolicySworld> GetPermissionList(string session, long userId)
        {
            string parameters = Utilites.Instance.Paramater(session, userId);
            List<PolicySworld> result = GetDataFromServer(session, MethodNames.GET_PERMISSION_LIST, parameters, new List<PolicySworld>().GetType()) as List<PolicySworld>;
            return result;
        }
    }
}
