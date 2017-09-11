using System;

namespace Test.Model.DBModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CsProducts : BaseModel
    {
        public static string PrimaryKey { get; set; } = "ProductId";
        public static string IdentityKey { get; set; } = "ProductId";

        /// <summary>
        /// 螃蟹商品编号
        /// </summary>
        public int ProductId { get; set; } = ToInt("");

        /// <summary>
        /// 螃蟹商品类型 1 大宗采购 2 包塘直补
        /// </summary>
        public int ProductType { get; set; } = ToInt("");

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; } = "";

        /// <summary>
        /// 商品重量
        /// </summary>
        public decimal ProductWeight { get; set; } = ToDecimal("");

        /// <summary>
        /// 商品状态 1表示正常 2表示下架
        /// </summary>
        public int ProductState { get; set; } = ToInt("");

    }


    public enum CsProductsEnum
    {
        /// <summary>
        /// 螃蟹商品编号
        /// </summary>
        ProductId,
        /// <summary>
        /// 螃蟹商品类型 1 大宗采购 2 包塘直补
        /// </summary>
        ProductType,
        /// <summary>
        /// 商品名称
        /// </summary>
        ProductName,
        /// <summary>
        /// 商品重量
        /// </summary>
        ProductWeight,
        /// <summary>
        /// 商品状态 1表示正常 2表示下架
        /// </summary>
        ProductState,
    }
}
