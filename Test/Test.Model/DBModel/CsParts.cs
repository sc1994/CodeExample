using System;

namespace Test.Model.DBModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CsParts : BaseModel
    {
        public static string PrimaryKey { get; set; } = "";
        public static string IdentityKey { get; set; } = "PartId";

        /// <summary>
        /// 配件编号
        /// </summary>
        public int PartId { get; set; } = ToInt("");

        /// <summary>
        /// 配件类型 1必选配件 2可选配件
        /// </summary>
        public int PartType { get; set; } = ToInt("");

        /// <summary>
        /// 配件名称
        /// </summary>
        public string PartName { get; set; } = "";

        /// <summary>
        /// 配件重量
        /// </summary>
        public decimal PartWeight { get; set; } = ToDecimal("");

        /// <summary>
        /// 配件价格
        /// </summary>
        public decimal PartPrice { get; set; } = ToDecimal("");

        /// <summary>
        /// 操作日期
        /// </summary>
        public DateTime OperationDate { get; set; } = ToDateTime("1900-1-1");

        /// <summary>
        /// 配件状态 1可用 2 不可用
        /// </summary>
        public int PartState { get; set; } = ToInt("");

    }


    public enum CsPartsEnum
    {
        /// <summary>
        /// 配件编号
        /// </summary>
        PartId,
        /// <summary>
        /// 配件类型 1必选配件 2可选配件
        /// </summary>
        PartType,
        /// <summary>
        /// 配件名称
        /// </summary>
        PartName,
        /// <summary>
        /// 配件重量
        /// </summary>
        PartWeight,
        /// <summary>
        /// 配件价格
        /// </summary>
        PartPrice,
        /// <summary>
        /// 操作日期
        /// </summary>
        OperationDate,
        /// <summary>
        /// 配件状态 1可用 2 不可用
        /// </summary>
        PartState,
    }
}
