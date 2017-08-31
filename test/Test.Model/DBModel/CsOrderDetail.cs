using System;
namespace Test.Model.DBModel
{
    /// <summary>
    /// 订单详细表
    /// </summary>
    public class CsOrderDetail : BaseModel
    {
        public static string PrimaryKey { get; set; } = "DetailId";
        public static string IdentityKey { get; set; } = "DetailId";

        /// <summary>
        /// 订单详细编号 主键 自动增长
        /// </summary>
        public int DetailId { get; set; }

        /// <summary>
        /// 订单编号
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// 产品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 销售单价
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 购买数量
        /// </summary>
        public int ProductNumber { get; set; }

        /// <summary>
        /// 该商品总价
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// 选择产品类别 1表示螃蟹 2表示配件
        /// </summary>
        public int ChoseType { get; set; }

    }


    public enum CsOrderDetailEnum
    {
        /// <summary>
        /// 订单详细编号 主键 自动增长
        /// </summary>
        DetailId,
        /// <summary>
        /// 订单编号
        /// </summary>
        OrderId,
        /// <summary>
        /// 产品编号
        /// </summary>
        ProductId,
        /// <summary>
        /// 销售单价
        /// </summary>
        UnitPrice,
        /// <summary>
        /// 购买数量
        /// </summary>
        ProductNumber,
        /// <summary>
        /// 该商品总价
        /// </summary>
        TotalPrice,
        /// <summary>
        /// 选择产品类别 1表示螃蟹 2表示配件
        /// </summary>
        ChoseType,
    }
}
