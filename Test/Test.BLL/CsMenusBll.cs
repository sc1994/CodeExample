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
        public CsMenusBll() : base(new CsMenusDal()) { }

        public CsMenusBll(IBaseDal<CsMenus, CsMenusEnum, int> dal) : base(dal) { }
    }
}
