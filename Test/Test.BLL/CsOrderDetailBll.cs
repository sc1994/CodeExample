using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    /// 订单扩展表  逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsOrderDetailBll : BaseBll<CsOrderDetail, CsOrderDetailEnum, int>, ICsOrderDetailBll
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly CsOrderDetailDal _dal;
        public CsOrderDetailBll(CsOrderDetailDal dal) : base(dal)
        {
            _dal = dal;
        }

    }
}
