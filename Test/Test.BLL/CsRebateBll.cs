using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    ///   逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsRebateBll : BaseBll<CsRebate, CsRebateEnum, int>, ICsRebateBll
    {
        public CsRebateBll() : base(new CsRebateDal()) { }

        public CsRebateBll(IBaseDal<CsRebate, CsRebateEnum, int> dal) : base(dal) { }
    }
}
