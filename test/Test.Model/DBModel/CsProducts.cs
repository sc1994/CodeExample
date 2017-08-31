using System;
namespace Test.Model.DBModel
{
    /// <summary>
    /// 商品表[螃蟹种类]
    /// </summary>
    public class CsProducts : BaseModel
    {
        public static string PrimaryKey { get; set; } = "ProductId";
        public static string IdentityKey { get; set; } = "ProductId";

        /// <summary>
        /// 螃蟹商品编号
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 螃蟹商品类型 1 大宗采购 2 包塘直补
        /// </summary>
        public int ProductType { get; set; }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// 产品图片
        /// </summary>
        public string ProductImage { get; set; } = string.Empty;

        /// <summary>
        /// 商品重量
        /// </summary>
        public decimal ProductWeight { get; set; }

        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// 商品状态 1表示正常 0表示下架
        /// </summary>
        public int ProductState { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationDate { get; set; } = DateTime.Now;

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
        /// 产品图片
        /// </summary>
        ProductImage,
        /// <summary>
        /// 商品重量
        /// </summary>
        ProductWeight,
        /// <summary>
        /// 商品价格
        /// </summary>
        ProductPrice,
        /// <summary>
        /// 商品状态 1表示正常 0表示下架
        /// </summary>
        ProductState,
        /// <summary>
        /// 操作时间
        /// </summary>
        OperationDate,
    }
}
