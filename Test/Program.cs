using System;
using Cache;
using Entity;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "sun",
                LastName = "cheng"
            };
            var result = CacheProvider.RedisDefault.Set(CacheKeys.DefaultKey, model);
        }
    }
}
