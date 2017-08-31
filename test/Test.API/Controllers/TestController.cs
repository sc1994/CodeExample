using Test.Common;
using Test.Factory;
using System.Web.Mvc;

namespace Test.API.Controllers
{
    public class TestController : Controller
    {
        private readonly FactoryTest _test;

        public TestController(FactoryTest test)
        {
            _test = test;
        }


        // GET: Test
        public ActionResult Index()
        {
            return Content(_test.GetList().ToJson());
        }
    }
}