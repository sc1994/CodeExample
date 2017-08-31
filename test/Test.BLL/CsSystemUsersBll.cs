using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    /// 系统用户表  逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsSystemUsersBll : BaseBll<CsSystemUsers, CsSystemUsersEnum, int>, ICsSystemUsersBll
    {
        public CsSystemUsersBll() : base(new CsSystemUsersDal()) { }

        public CsSystemUsersBll(IBaseDal<CsSystemUsers, CsSystemUsersEnum, int> dal) : base(dal) { }
    }
}
