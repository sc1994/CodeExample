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
        public CsPartsBll() : base(new CsPartsDal()) { }

        public CsPartsBll(IBaseDal<CsParts, CsPartsEnum, object> dal) : base(dal) { }
    }
}
