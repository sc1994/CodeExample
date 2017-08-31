
using Test.Common;
using Test.IBLL;

namespace Test.Factory
{
    public class Test
    {
        private readonly ICsOrderBll _csOrderBll;

        public Test(ICsOrderBll csOrderBll)
        {
            _csOrderBll = csOrderBll;
        }

        public string GetList()
        {
            return _csOrderBll.GetModelList("").Count.ToString();
        }
    }
}
