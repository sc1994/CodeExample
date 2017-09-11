using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    ///   逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsPartsBll : BaseBll<CsParts, CsPartsEnum, object>, ICsPartsBll
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly CsPartsDal _dal;
        public CsPartsBll(CsPartsDal dal) : base(dal)
        {
            _dal = dal;
        }

    }
}
