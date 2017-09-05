using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    ///   逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsCartBll : BaseBll<CsCart, CsCartEnum, int>, ICsCartBll
    {
        public CsCartBll() : base(new CsCartDal()) { }

        public CsCartBll(IBaseDal<CsCart, CsCartEnum, int> dal) : base(dal) { }
    }
}
