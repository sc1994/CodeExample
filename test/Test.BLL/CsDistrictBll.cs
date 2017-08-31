using Test.DAL;
using Test.IDAL;
using Test.IBLL;
using Test.Model.DBModel;

namespace Test.BLL
{
    /// <summary>
    /// 全国省市区三级数据  逻辑层(此类中的代码不会被覆盖)
    /// </summary>
    public class CsDistrictBll : BaseBll<CsDistrict, CsDistrictEnum, int>, ICsDistrictBll
    {
        public CsDistrictBll() : base(new CsDistrictDal()) { }

        public CsDistrictBll(IBaseDal<CsDistrict, CsDistrictEnum, int> dal) : base(dal) { }
    }
}
