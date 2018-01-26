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
            Expression<Func<Person, bool>> first =
                x => x.FirstName == "sun";

            first = first.And(x => x.LastName == "cheng");

            Console.WriteLine(first.Body.ToString());
            //var model = new Person
            //{
            //    Id = Guid.NewGuid(),
            //    FirstName = "sun",
            //    LastName = "cheng"
            //};
            //var result = CacheProvider.RedisDefault.Set(CacheKeys.DefaultKey, model);
            //var result = CacheProvider.RedisDefault.Get<Person>(CacheKeys.DefaultKey);
            //var hash = new List<Person>
            //		   {
            //			   new Person
            //			   {
            //				   Id = Guid.NewGuid(),
            //				   FirstName = "sun",
            //				   LastName = "cheng"
            //			   },
            //			   new Person
            //			   {
            //				   Id = Guid.NewGuid(),
            //				   FirstName = "sun2",
            //				   LastName = "cheng2"
            //			   },
            //			   new Person
            //			   {
            //				   Id = Guid.NewGuid(),
            //				   FirstName = "sun3",
            //				   LastName = "cheng3"
            //			   }
            //		   };
            //CacheProvider.RedisDefault.SetHash(CacheKeys.DefaultHashtKey, hash, person => person.Id.ToString());
        }
    }
}
