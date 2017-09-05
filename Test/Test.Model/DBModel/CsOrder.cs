using System;

namespace Test.Model.DBModel
{
    /// <summary>
    /// 订单表
    /// </summary>
    public class CsOrder : BaseModel
    {
        public static string PrimaryKey { get; set; } = "OrderId";
        public static string IdentityKey { get; set; } = "";

        /// <summary>
        /// 订单编号,由下单日期自动生成
        /// </summary>
        public string OrderId { get; set; } = string.Empty;

        /// <summary>
        /// 下单用户
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        public decimal TotalMoney { get; set; }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal DiscountMoney { get; set; }

        /// <summary>
        /// 实际金额
        /// </summary>
        public decimal ActualMoney { get; set; }

        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime OrderDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 订单状态 1已下单未至支付 2支付成功 3 配货中 4 已发货
        /// </summary>
        public int OrderState { get; set; }

    }


    public enum CsOrderEnum
    {
        /// <summary>
        /// 订单编号,由下单日期自动生成
        /// </summary>
        OrderId,
        /// <summary>
        /// 下单用户
        /// </summary>
        UserId,
        /// <summary>
        /// 总金额
        /// </summary>
        TotalMoney,
        /// <summary>
        /// 优惠金额
        /// </summary>
        DiscountMoney,
        /// <summary>
        /// 实际金额
        /// </summary>
        ActualMoney,
        /// <summary>
        /// 下单时间
        /// </summary>
        OrderDate,
        /// <summary>
        /// 订单状态 1已下单未至支付 2支付成功 3 配货中 4 已发货
        /// </summary>
        OrderState,
    }
}
