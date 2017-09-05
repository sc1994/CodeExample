using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Test.Factory;

namespace Test.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly FactoryClass1 _factory;

        public HomeController(FactoryClass1 factory)
        {
            _factory = factory;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Haha()
        {
            return Json(_factory.GetList(), JsonRequestBehavior.AllowGet);
        }
    }
}