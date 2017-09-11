using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    /// 收货地址表   逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsAddressBll : BaseBll<CsAddress, CsAddressEnum, int>, ICsAddressBll
    {
        // ReSharper disable once NotAccessedField.Local
        private readonly CsAddressDal _dal;
        public CsAddressBll(CsAddressDal dal) : base(dal)
        {
            _dal = dal;
        }

    }
}
