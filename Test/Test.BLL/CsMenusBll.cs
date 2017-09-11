using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    /// 菜单配置表  逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsMenusBll : BaseBll<CsMenus, CsMenusEnum, int>, ICsMenusBll
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly CsMenusDal _dal;
        public CsMenusBll(CsMenusDal dal) : base(dal)
        {
            _dal = dal;
        }

    }
}
