using Utilities;
#pragma warning disable 649

namespace Cache
{
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
                    return new RedisCache(ConnectHelper.CacheDefault);
                }
                return _redisDefault;
            }
        }
        #endregion
    }
}
