using System;

namespace Test.Model.DBModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CsRebate : BaseModel
    {
        public static string PrimaryKey { get; set; } = "RebateId";
        public static string IdentityKey { get; set; } = "RebateId";

        /// <summary>
        /// 返利编号 主键 自动增长
        /// </summary>
        public int RebateId { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 返利金钱
        /// </summary>
        public decimal RebateMoney { get; set; }

        /// <summary>
        /// 购买重量
        /// </summary>
        public decimal RebateWeight { get; set; }

        /// <summary>
        /// 返利时间
        /// </summary>
        public DateTime RebateTime { get; set; } = ToDateTime("1900-1-1");

    }


    public enum CsRebateEnum
    {
        /// <summary>
        /// 返利编号 主键 自动增长
        /// </summary>
        RebateId,
        /// <summary>
        /// 用户编号
        /// </summary>
        UserId,
        /// <summary>
        /// 返利金钱
        /// </summary>
        RebateMoney,
        /// <summary>
        /// 购买重量
        /// </summary>
        RebateWeight,
        /// <summary>
        /// 返利时间
        /// </summary>
        RebateTime,
    }
}
