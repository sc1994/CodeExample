using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    /// 寄件方信息  逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsSendBll : BaseBll<CsSend, CsSendEnum, int>, ICsSendBll
    {
        public CsSendBll() : base(new CsSendDal()) { }

        public CsSendBll(IBaseDal<CsSend, CsSendEnum, int> dal) : base(dal) { }
    }
}
