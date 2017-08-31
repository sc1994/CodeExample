using Ninject;
using Test.BLL;
using Test.DAL;
using Test.IBLL;
using Test.IDAL;

namespace Test.Common.Infrastructure
{
    public class BindToConfig
    {
        public static void BindTo(IKernel kernel)
        {
            kernel.Bind<ICsUsersDal>().To<CsUsersDal>().InSingletonScope();
            kernel.Bind<ICsUsersBll>().To<CsUsersBll>().InSingletonScope();
            kernel.Bind<ICsPriceDal>().To<CsPriceDal>().InSingletonScope();
            kernel.Bind<ICsPriceBll>().To<CsPriceBll>().InSingletonScope();
            kernel.Bind<ICsRebateDal>().To<CsRebateDal>().InSingletonScope();
            kernel.Bind<ICsRebateBll>().To<CsRebateBll>().InSingletonScope();
            kernel.Bind<ICsDistrictDal>().To<CsDistrictDal>().InSingletonScope();
            kernel.Bind<ICsDistrictBll>().To<CsDistrictBll>().InSingletonScope();
            kernel.Bind<ICsCartDal>().To<CsCartDal>().InSingletonScope();
            kernel.Bind<ICsCartBll>().To<CsCartBll>().InSingletonScope();
            kernel.Bind<ICsOrderDetailDal>().To<CsOrderDetailDal>().InSingletonScope();
            kernel.Bind<ICsOrderDetailBll>().To<CsOrderDetailBll>().InSingletonScope();
            kernel.Bind<ICsSystemUsersDal>().To<CsSystemUsersDal>().InSingletonScope();
            kernel.Bind<ICsSystemUsersBll>().To<CsSystemUsersBll>().InSingletonScope();
            kernel.Bind<ICsProductsDal>().To<CsProductsDal>().InSingletonScope();
            kernel.Bind<ICsProductsBll>().To<CsProductsBll>().InSingletonScope();
            kernel.Bind<ICsPartsDal>().To<CsPartsDal>().InSingletonScope();
            kernel.Bind<ICsPartsBll>().To<CsPartsBll>().InSingletonScope();
            kernel.Bind<ICsSendDal>().To<CsSendDal>().InSingletonScope();
            kernel.Bind<ICsSendBll>().To<CsSendBll>().InSingletonScope();
            kernel.Bind<ICsAddressDal>().To<CsAddressDal>().InSingletonScope();
            kernel.Bind<ICsAddressBll>().To<CsAddressBll>().InSingletonScope();
            kernel.Bind<ICsOrderDal>().To<CsOrderDal>().InSingletonScope();
            kernel.Bind<ICsOrderBll>().To<CsOrderBll>().InSingletonScope();
            kernel.Bind<ICsMenusDal>().To<CsMenusDal>().InSingletonScope();
            kernel.Bind<ICsMenusBll>().To<CsMenusBll>().InSingletonScope();
        }
    }
}
