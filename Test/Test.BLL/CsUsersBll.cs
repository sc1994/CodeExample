using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    ///   逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsUsersBll : BaseBll<CsUsers, CsUsersEnum, int>, ICsUsersBll
    {
        public CsUsersBll() : base(new CsUsersDal()) { }

        public CsUsersBll(IBaseDal<CsUsers, CsUsersEnum, int> dal) : base(dal) { }
    }
}
