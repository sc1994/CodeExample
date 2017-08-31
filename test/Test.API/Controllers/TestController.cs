using System.Web.Mvc;
using Test.Common;

namespace Test.API.Controllers
{
    public class TestController : Controller
    {
        private readonly Factory.Test _test;

        public TestController(Factory.Test test)
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