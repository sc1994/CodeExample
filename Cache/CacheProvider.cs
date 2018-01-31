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
        #endregion
    }
}
