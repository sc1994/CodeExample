using System.Web.Http;
using Test.Factory;

namespace Test.API.Controllers
{
    public class HomeController : ApiController
    {
        private readonly FactoryClass1 _factory;

        public HomeController(FactoryClass1 factory)
        {
            _factory = factory;
        }

        [HttpGet]
        public IHttpActionResult Haha()
        {
            return Json(_factory.GetList());
        }
    }
}
