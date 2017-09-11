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
        // ReSharper disable once NotAccessedField.Local
        private readonly CsPriceDal _dal;
        public CsPriceBll(CsPriceDal dal) : base(dal)
        {
            _dal = dal;
        }

    }
}
