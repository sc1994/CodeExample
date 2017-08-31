# CodeExample
CodeGeneration 项目生成代码展示 

## 说明
- Test.Web没有去实现, (实现类似Test.API)
- Test.API 控制器中的 Test 实现了一次读库的调用, 是可以调通的(你本地没库是调不通的~~~~)
- API 只引用了 Factory (Model,Common 是通用的) 
- 在 Factory 中去 调用IBLL (使用了DI 所以我们不需要去实例化接口)

## 代码片段
##### Test.API/Controller/TestController.cs
```
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

```

##### Test.Factory/FactoryTest
```
using Test.IBLL;

namespace Test.Factory
{
    public class FactoryTest
    {
        private readonly ICsOrderBll _csOrderBll;

        public FactoryTest(ICsOrderBll csOrderBll)
        {
            _csOrderBll = csOrderBll;
        }

        public string GetList()
        {
            return _csOrderBll.GetModelList("").Count.ToString();
        }
    }
}
```


