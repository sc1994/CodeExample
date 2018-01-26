using System;
using System.Collections.Generic;
using Cache;
using Entity;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			//var model = new Person
			//{
			//    Id = Guid.NewGuid(),
			//    FirstName = "sun",
			//    LastName = "cheng"
			//};
			//var result = CacheProvider.RedisDefault.Set(CacheKeys.DefaultKey, model);
			//var result = CacheProvider.RedisDefault.Get<Person>(CacheKeys.DefaultKey);
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
			CacheProvider.RedisDefault.SetHash(CacheKeys.DefaultHashtKey, hash,person =>  person.Id.ToString());
		}
	}
}
