# CodeExample
CodeGeneration 项目生成代码展示 

### 代码生成工具
[点我查看](https://github.com/sc1994/CodeGeneration)

## 说明
- Test.API/Test.Web 控制器Home/Haha中的  实现了一次读库的调用, 是可以调通的(你本地没库是调不通的~)
- Web/API 只引用了 Factory以及IBLL(只使用一个简单IBLL方法,简化调用过程) (Model,Common 是通用的) 
- 在 Factory 中去 调用IBLL 

## 代码片段
##### Test.API/Controller/HomeController.cs
```
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

```

##### Test.Factory/FactoryTest.cs
```
using Test.IBLL;
using Test.Model.DBModel;
using System.Collections.Generic;

namespace Test.Factory
{
    public class FactoryClass1
    {
        private readonly ICsOrderBll _csOrderBll;

        public FactoryClass1(ICsOrderBll csOrderBll)
        {
            _csOrderBll = csOrderBll;
        }

        public IEnumerable<CsOrder> GetList()
        {
            return _csOrderBll.GetModelList("");
        }
    }
}

```




