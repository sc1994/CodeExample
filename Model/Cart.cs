namespace Model
{
	/// <summary>
	/// 购物车表
	/// </summary>
	public class Cart : BaseModel
	{
		public Cart() : base("CartId", "CartId")
		{
		}

		/// <summary>
		/// 购物车编号 主键自动增长
		/// </summary>
		public int CartId { get; set; }

		/// <summary>
		/// 微信公开Id
		/// </summary>
		public string OpenId { get; set; } = string.Empty;

		/// <summary>
		/// 商品编号
		/// </summary>
		public int ProductId { get; set; }

		/// <summary>
		/// 购买数量
		/// </summary>
		public int ProductNumber { get; set; }

		/// <summary>
		/// 选择类型 1表示螃蟹 2表示配件(包含必须配件和可选配件)
		/// </summary>
		public int ChoseType { get; set; }
	}


	public enum CartEnum
	{
		/// <summary>
		/// 购物车编号 主键自动增长
		/// </summary>
		CartId,

		/// <summary>
		/// 微信公开Id
		/// </summary>
		OpenId,

		/// <summary>
		/// 商品编号
		/// </summary>
		ProductId,

		/// <summary>
		/// 购买数量
		/// </summary>
		ProductNumber,

		/// <summary>
		/// 选择类型 1表示螃蟹 2表示配件(包含必须配件和可选配件)
		/// </summary>
		ChoseType,
	}
}