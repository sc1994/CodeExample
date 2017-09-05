using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    ///   逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsPriceBll : BaseBll<CsPrice, CsPriceEnum, int>, ICsPriceBll
    {
        public CsPriceBll() : base(new CsPriceDal()) { }

        public CsPriceBll(IBaseDal<CsPrice, CsPriceEnum, int> dal) : base(dal) { }
    }
}
