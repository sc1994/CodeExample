using DAL;
using Model;

namespace Business
{
	public class CartBusiness : BaseBussion<Cart, CartEnum, int>
	{
		public CartBusiness() : base(CartDal.Instance)
		{
		}
	}
}
