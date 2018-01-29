using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Cache;
using Entity;
using Utilities;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var http = new HttpHelper();
            //var baidu = http.HttpGet("https://www.mingdao.com/chat");

            //Console.WriteLine(baidu);
            //Console.ReadLine();
            //var model = new Person
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "sun",
            //    LastName = "cheng"
            //};
            //var result = CacheProvider.RedisDefault.Set(CacheKeys.DefaultKey, model);
            //var result = CacheProvider.RedisDefault.Get<Person>(CacheKeys.DefaultKey);
            while (true)
            {
                var hash = new List<Person>
                           {
                               new Person
                               {
                                   Id = Guid.NewGuid(),
                                   FirstName = "sun",
                                   LastName = "cheng"
                               },
                               new Person
                               {
                                   Id = Guid.NewGuid(),
                                   FirstName = "sun2",
                                   LastName = "cheng2"
                               },
                               new Person
                               {
                                   Id = Guid.NewGuid(),
                                   FirstName = "sun3",
                                   LastName = "cheng3"
                               }
                           };
                CacheProvider.RedisDefault.SetHash(CacheKeys.DefaultHashtKey, hash, person => person.Id.ToString());
                Console.ReadLine();
            }
        }
    }
}
