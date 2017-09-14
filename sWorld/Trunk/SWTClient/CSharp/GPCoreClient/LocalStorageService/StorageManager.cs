using System;
using Microsoft.Practices.CompositeUI;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using sWorldModel;
using sWorldModel.Model;
using System.Collections.Generic;
using System.Resources;

namespace LocalStorageService
{
    [Service(typeof(ILocalStorageService))]
    public class StorageManager : ILocalStorageService
    {
        private const string USER_NAME_ALIAS = "USER_NAME";
        private const string SESSION_ID_ALIAS = "SESSION_ID";
        private const string LAST_LOGIN_TIME_ALIAS = "LAST_LOGIN_TIME_ALIAS";
        private const string LANGUAGES = "LANGUAGES";

        private readonly TimeSpan DEFAULT_CACHING_DURATION = new TimeSpan(0, 10, 0);
        private ICacheManager cache = CacheFactory.GetCacheManager();

        #region Special values

        public string CurrentSessionId
        {
            get
            {
                return (string)GetSpecialObject(SESSION_ID_ALIAS);
            }
            set
            {
                StoreSpecialObject(SESSION_ID_ALIAS, value);
            }
        }

        public ResourceManager Languages
        {
            get
            {
                return (ResourceManager)GetSpecialObject(LANGUAGES);
            }
            set
            {
                StoreSpecialObject(LANGUAGES, value);
            }
        }

        public string CurrentUserName
        {
            get
            {
                return (string)GetSpecialObject(USER_NAME_ALIAS);
            }
            set
            {
                StoreSpecialObject(USER_NAME_ALIAS, value);
            }
        }

        public DateTime? LastLoginTime
        {
            get
            {
                return (DateTime?)GetSpecialObject(LAST_LOGIN_TIME_ALIAS);
            }
            set
            {
                StoreSpecialObject(LAST_LOGIN_TIME_ALIAS, value);
            }
        }

        private object GetSpecialObject(string alias)
        {
            if (cache.Contains(alias))
            {
                return (string)cache.GetData(alias);
            }
            return null;
        }

        private void StoreSpecialObject(string alias, object value)
        {
            if (cache.Contains(alias))
            {
                if (value != null && !cache[alias].Equals(value))
                {
                    cache.Add(alias, value, CacheItemPriority.High, null);
                }
            }
            else
            {
                cache.Add(alias, value);
            }
        }

        #endregion

        #region Common values

        public string StoreObject(object obj)
        {
            return StoreObject(obj, DEFAULT_CACHING_DURATION);
        }

        public void StoreObject(string alias, object obj)
        {
            StoreObject(alias, obj, DEFAULT_CACHING_DURATION);
        }

        public string StoreObject(object obj, TimeSpan duration)
        {
            string alias = GenerateId();
            StoreObject(alias, obj, DEFAULT_CACHING_DURATION);
            return alias;
        }

        public void StoreObject(string alias, object obj, TimeSpan duration)
        {
            SlidingTime objSlidingTime = new SlidingTime(duration);
            cache.Add(alias, obj, CacheItemPriority.Normal, null, objSlidingTime);
        }

        public string StoreObjectPermanently(object obj)
        {
            string alias = GenerateId();
            StoreObjectPermanently(alias, obj);
            return alias;
        }

        public void StoreObjectPermanently(string alias, object obj)
        {
            cache.Add(alias, obj);
        }

        public bool HasContains(string alias)
        {
            return cache.Contains(alias);
        }

        public void ClearObject(string alias)
        {
            if (cache.Contains(alias))
            {
                cache.Remove(alias);
            }
        }

        public object GetObject(string alias)
        {
            if (cache.Contains(alias))
            {
                return cache.GetData(alias);
            }
            return null;
        }

        #endregion

        private string GenerateId()
        {
            return Environment.TickCount.ToString();
        }

        public void ClearAll()
        {
            cache.Flush();
        }
    }
}