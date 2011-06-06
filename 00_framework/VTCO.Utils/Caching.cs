//
// Author:      Hoan.Trinh@vtc.vn
// Create Date: 2009.01.08
// Description: Cache dữ liệu, Server Cache
//
using Microsoft.Practices.EnterpriseLibrary.Caching;
namespace VTCO.Utils
{
    public class Caching
    {
        readonly static ICacheManager cache = CacheFactory.GetCacheManager();

        /// <summary>
        /// Kiểm tra tồn tại cache
        /// </summary>
        /// <param name="keyCache"></param>
        /// <returns></returns>
        public static bool ExistCache(string keyCache)
        {
            return cache.Contains(keyCache);
        }

        /// <summary>
        /// Thêm cache
        /// </summary>
        /// <param name="keyCache"></param>
        /// <param name="data"></param>
        public static void CacheAdd(string keyCache, object data)
        {
            cache.Add(keyCache, data);
        }

        /// <summary>
        /// Xóa cache
        /// </summary>
        /// <param name="keyCache"></param>
        public static void CacheRemove(string keyCache)
        {
            cache.Remove(keyCache);
        }

        /// <summary>
        /// Làm sạch bộ nhớ cache
        /// </summary>
        public static void CacheFlush()
        {
            cache.Flush();
        }

        /// <summary>
        /// Lấy dữ liệu từ cache
        /// </summary>
        /// <param name="keyCache"></param>
        /// <returns></returns>
        public static object CacheGetData(string keyCache)
        {
            return cache.GetData(keyCache);
        }
    }
}
