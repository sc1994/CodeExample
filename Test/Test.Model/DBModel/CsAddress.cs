using System;

namespace Test.Model.DBModel
{
    /// <summary>
    /// 收货地址表 
    /// </summary>
    public class CsAddress : BaseModel
    {
        public static string PrimaryKey { get; set; } = "AddressId";
        public static string IdentityKey { get; set; } = "AddressId";

        /// <summary>
        /// 收货地址编号 主键 自动增长
        /// </summary>
        public int AddressId { get; set; }

        /// <summary>
        /// 省名称
        /// </summary>
        public string Province { get; set; } = string.Empty;

        /// <summary>
        /// 城市名称
        /// </summary>
        public string City { get; set; } = string.Empty;

        /// <summary>
        /// 县区
        /// </summary>
        public string District { get; set; } = string.Empty;

        /// <summary>
        /// 详细地址
        /// </summary>
        public string Details { get; set; } = string.Empty;

        /// <summary>
        /// 收货人
        /// </summary>
        public string Consignee { get; set; } = string.Empty;

        /// <summary>
        /// 性别 先生/女士
        /// </summary>
        public string ConSex { get; set; } = string.Empty;

        /// <summary>
        /// 联系方式
        /// </summary>
        public string TelPhone { get; set; } = string.Empty;

        /// <summary>
        /// 是否默认地址 1默认 2不默认
        /// </summary>
        public int IsDefault { get; set; }

    }


    public enum CsAddressEnum
    {
        /// <summary>
        /// 收货地址编号 主键 自动增长
        /// </summary>
        AddressId,
        /// <summary>
        /// 省名称
        /// </summary>
        Province,
        /// <summary>
        /// 城市名称
        /// </summary>
        City,
        /// <summary>
        /// 县区
        /// </summary>
        District,
        /// <summary>
        /// 详细地址
        /// </summary>
        Details,
        /// <summary>
        /// 收货人
        /// </summary>
        Consignee,
        /// <summary>
        /// 性别 先生/女士
        /// </summary>
        ConSex,
        /// <summary>
        /// 联系方式
        /// </summary>
        TelPhone,
        /// <summary>
        /// 是否默认地址 1默认 2不默认
        /// </summary>
        IsDefault,
    }
}
