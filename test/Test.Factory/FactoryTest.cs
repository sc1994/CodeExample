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
