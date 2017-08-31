using System;
namespace Test.Model.DBModel
{
    /// <summary>
    /// 全国省市区三级数据
    /// </summary>
    public class CsDistrict : BaseModel
    {
        public static string PrimaryKey { get; set; } = "Id";
        public static string IdentityKey { get; set; } = "Id";

        /// <summary>
        /// 编号 主键 自动增长
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 父级编号
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 区域编码
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// 排序编号
        /// </summary>
        public int Sort { get; set; }

        /// <summary>
        /// 首重价格
        /// </summary>
        public int FirstPrice { get; set; }

        /// <summary>
        /// 后续价格
        /// </summary>
        public int FllowPrice { get; set; }

    }


    public enum CsDistrictEnum
    {
        /// <summary>
        /// 编号 主键 自动增长
        /// </summary>
        Id,
        /// <summary>
        /// 名称
        /// </summary>
        Name,
        /// <summary>
        /// 父级编号
        /// </summary>
        ParentId,
        /// <summary>
        /// 区域编码
        /// </summary>
        Code,
        /// <summary>
        /// 排序编号
        /// </summary>
        Sort,
        /// <summary>
        /// 首重价格
        /// </summary>
        FirstPrice,
        /// <summary>
        /// 后续价格
        /// </summary>
        FllowPrice,
    }
}
