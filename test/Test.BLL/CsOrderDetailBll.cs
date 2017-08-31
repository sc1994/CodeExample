using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    /// 订单详细表  逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsOrderDetailBll : BaseBll<CsOrderDetail, CsOrderDetailEnum, int>, ICsOrderDetailBll
    {
        public CsOrderDetailBll() : base(new CsOrderDetailDal()) { }

        public CsOrderDetailBll(IBaseDal<CsOrderDetail, CsOrderDetailEnum, int> dal) : base(dal) { }
    }
}
