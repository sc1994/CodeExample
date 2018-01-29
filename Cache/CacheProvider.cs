using Utilities;
#pragma warning disable 649

namespace Cache
{
    /// <summary>
    /// cache 持久化链接
    /// </summary>
    public class CacheProvider
    {
        #region Redis
        private static RedisCache _redisDefault;
        public static RedisCache RedisDefault
        {
            get
            {
                if (_redisDefault == null)
                {
                    return new RedisCache(ConnectHelper.CacheDefault, 2);
                }
                return _redisDefault;
            }
        }

        private static RedisCache _redisDefault1;
        /// <summary>
        /// 默认的redis
        /// </summary>
        public static RedisCache RedisDefault1
        {
            get
            {
                if (_redisDefault1 == null)
                {
                    return new RedisCache(ConnectHelper.CacheDefault, 2);
                }
                return _redisDefault1;
            }
        }
        #endregion
    }
}
