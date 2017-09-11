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
        // ReSharper disable once NotAccessedField.Local
        private readonly CsUsersDal _dal;
        public CsUsersBll(CsUsersDal dal) : base(dal)
        {
            _dal = dal;
        }

    }
}
