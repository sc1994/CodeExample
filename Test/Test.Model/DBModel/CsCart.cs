using System;

namespace Test.Model.DBModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CsCart : BaseModel
    {
        public static string PrimaryKey { get; set; } = "CartId";
        public static string IdentityKey { get; set; } = "CartId";

        /// <summary>
        /// 购物车编号 主键自动增长
        /// </summary>
        public int CartId { get; set; } = ToInt("");

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; } = ToInt("");

        /// <summary>
        /// 商品编号
        /// </summary>
        public int ProductId { get; set; } = ToInt("");

        /// <summary>
        /// 购买数量
        /// </summary>
        public int ProductNumber { get; set; } = ToInt("");

        /// <summary>
        /// 选择类型 1表示螃蟹 2表示配件(包含必须配件和可选配件)
        /// </summary>
        public int ChoseType { get; set; } = ToInt("");

    }


    public enum CsCartEnum
    {
        /// <summary>
        /// 购物车编号 主键自动增长
        /// </summary>
        CartId,
        /// <summary>
        /// 用户编号
        /// </summary>
        UserId,
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
