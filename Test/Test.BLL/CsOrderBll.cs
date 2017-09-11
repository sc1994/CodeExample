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
        // ReSharper disable once NotAccessedField.Local
        private readonly CsOrderDal _dal;
        public CsOrderBll(CsOrderDal dal) : base(dal)
        {
            _dal = dal;
        }

    }
}
