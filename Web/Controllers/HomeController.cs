using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Entity;
using Cache;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

            return View();
        }

        public ActionResult About()
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
            CacheProvider.RedisDefault1.SetHash(CacheKeys.DefaultHashtKey, hash, person => person.Id.ToString());
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}