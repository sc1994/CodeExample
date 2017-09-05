using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    /// 订单表  逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsOrderBll : BaseBll<CsOrder, CsOrderEnum, string>, ICsOrderBll
    {
        public CsOrderBll() : base(new CsOrderDal()) { }

        public CsOrderBll(IBaseDal<CsOrder, CsOrderEnum, string> dal) : base(dal) { }
    }
}
