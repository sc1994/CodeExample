using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    /// 收货地址表  逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsAddressBll : BaseBll<CsAddress, CsAddressEnum, int>, ICsAddressBll
    {
        public CsAddressBll() : base(new CsAddressDal()) { }

        public CsAddressBll(IBaseDal<CsAddress, CsAddressEnum, int> dal) : base(dal) { }
    }
}
