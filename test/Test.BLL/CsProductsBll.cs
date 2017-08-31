using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    /// 商品表[螃蟹种类]  逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsProductsBll : BaseBll<CsProducts, CsProductsEnum, int>, ICsProductsBll
    {
        public CsProductsBll() : base(new CsProductsDal()) { }

        public CsProductsBll(IBaseDal<CsProducts, CsProductsEnum, int> dal) : base(dal) { }
    }
}
