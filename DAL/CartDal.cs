using Model;
using System;
using Utilities;
using IBaseSqlServer;
using System.Collections.Generic;

namespace DAL
{
	public class CartDal : IBaseSqlServer<Cart, CartEnum, int>
	{
		private static readonly Lazy<CartDal> Lazy = new Lazy<CartDal>(() => new CartDal());

		public static CartDal Instance => Lazy.Value;

		public bool Exists(int primaryKey)
		{
			Console.WriteLine(primaryKey);
			return false;
		}

		public bool ExistsByWhere(string where)
		{
			LogHelper.UserLog(where);
			return false;
		}

		public int Add(Cart model)
		{
			throw new System.NotImplementedException();
		}

		public bool Update(Cart model)
		{
			throw new System.NotImplementedException();
		}

		public bool Update(Dictionary<CartEnum, object> updates, string @where)
		{
			throw new System.NotImplementedException();
		}

		public bool Delete(int primaryKey)
		{
			throw new System.NotImplementedException();
		}

		public int DeleteByWhere(string @where)
		{
			throw new System.NotImplementedException();
		}

		public Cart GetModel(int primaryKey)
		{
			throw new System.NotImplementedException();
		}

		public List<Cart> GetModelList(string @where)
		{
			throw new System.NotImplementedException();
		}

		public List<Cart> GetModelPage(CartEnum order, string @where, int pageIndex, int pageSize, out int total)
		{
			throw new System.NotImplementedException();
		}
	}
}
