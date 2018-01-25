using StackExchange.Redis;
using Utilities;

namespace Cache
{
    public class RedisCache
    {
        private readonly ConnectionMultiplexer _redis;
        public RedisCache(string connString)
        {
            _redis = ConnectionMultiplexer.Connect(connString);
        }

        public T Get<T>(string key)
        {
            using (_redis)
            {
                var db = _redis.GetDatabase();
                return db.StringGet(key).ToString().JsonToObject<T>();
            }
        }

        public bool Set<T>(string key, T value)
        {
            using (_redis)
            {
                var db = _redis.GetDatabase();
                return db.StringSet(key, value.ToJson());
            }
        }
    }
}
