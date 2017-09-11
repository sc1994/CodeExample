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
        // ReSharper disable once NotAccessedField.Local
        private readonly CsRebateDal _dal;
        public CsRebateBll(CsRebateDal dal) : base(dal)
        {
            _dal = dal;
        }

    }
}
