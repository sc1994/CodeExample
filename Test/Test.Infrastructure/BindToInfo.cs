//*******************************************
// 依次绑定了接口和实现之间的关系, 
// 据说可以直接引用其DLL去绑定,
// 但是不才, 先曲线救国一下 
//*******************************************
using Ninject;
using Test.BLL;
using Test.DAL;
using Test.IBLL;
using Test.IDAL;

namespace Test.Infrastructure
{
    public class BindToConfig
    {
        public static void BindTo(IKernel kernel)
        {
            kernel.Bind<ICsUsersDal>().To<CsUsersDal>().InSingletonScope();
            kernel.Bind<ICsUsersBll>().To<CsUsersBll>().InSingletonScope();
            kernel.Bind<ICsRebateDal>().To<CsRebateDal>().InSingletonScope();
            kernel.Bind<ICsRebateBll>().To<CsRebateBll>().InSingletonScope();
            kernel.Bind<ICsProductsDal>().To<CsProductsDal>().InSingletonScope();
            kernel.Bind<ICsProductsBll>().To<CsProductsBll>().InSingletonScope();
            kernel.Bind<ICsPriceDal>().To<CsPriceDal>().InSingletonScope();
            kernel.Bind<ICsPriceBll>().To<CsPriceBll>().InSingletonScope();
            kernel.Bind<ICsPartsDal>().To<CsPartsDal>().InSingletonScope();
            kernel.Bind<ICsPartsBll>().To<CsPartsBll>().InSingletonScope();
            kernel.Bind<ICsOrderDetailDal>().To<CsOrderDetailDal>().InSingletonScope();
            kernel.Bind<ICsOrderDetailBll>().To<CsOrderDetailBll>().InSingletonScope();
            kernel.Bind<ICsOrderDal>().To<CsOrderDal>().InSingletonScope();
            kernel.Bind<ICsOrderBll>().To<CsOrderBll>().InSingletonScope();
            kernel.Bind<ICsMenusDal>().To<CsMenusDal>().InSingletonScope();
            kernel.Bind<ICsMenusBll>().To<CsMenusBll>().InSingletonScope();
            kernel.Bind<ICsCartDal>().To<CsCartDal>().InSingletonScope();
            kernel.Bind<ICsCartBll>().To<CsCartBll>().InSingletonScope();
            kernel.Bind<ICsAddressDal>().To<CsAddressDal>().InSingletonScope();
            kernel.Bind<ICsAddressBll>().To<CsAddressBll>().InSingletonScope();
        }
    }
}
