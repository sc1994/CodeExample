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
        // ReSharper disable once NotAccessedField.Local
        private readonly CsCartDal _dal;
        public CsCartBll(CsCartDal dal) : base(dal)
        {
            _dal = dal;
        }

    }
}
