using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

namespace VTCeBank.SSO.Utils
{
    /// <summary>
    /// Author: Nguyen Ngoc Thinh
    /// </summary>
    public class CacheRepository
    {
        public static IList<T> GetObjects<T>(string key)
        {
            IList<T> list = (IList<T>)HttpContext.Current.Cache[key];
            return list;
        }

        public static void SaveObject(string key, object obj, int expireTime)
        {
            HttpContext.Current.Cache.Insert(key, obj, null, DateTime.Now.AddHours(expireTime), Cache.NoSlidingExpiration);
        }
    }
}
