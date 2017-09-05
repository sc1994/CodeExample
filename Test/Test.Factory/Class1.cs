using System.Collections.Generic;
using Test.IBLL;
using Test.Model.DBModel;

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
