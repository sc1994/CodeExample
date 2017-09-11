using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    ///   逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsProductsBll : BaseBll<CsProducts, CsProductsEnum, int>, ICsProductsBll
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly CsProductsDal _dal;
        public CsProductsBll(CsProductsDal dal) : base(dal)
        {
            _dal = dal;
        }

    }
}
