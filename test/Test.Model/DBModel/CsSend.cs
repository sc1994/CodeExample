using System;
namespace Test.Model.DBModel
{
    /// <summary>
    /// 寄件方信息
    /// </summary>
    public class CsSend : BaseModel
    {
        public static string PrimaryKey { get; set; } = "SendId";
        public static string IdentityKey { get; set; } = "SendId";

        /// <summary>
        /// 寄件信息编号 主键 自增
        /// </summary>
        public int SendId { get; set; }

        /// <summary>
        /// 寄件公司名称
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// 联系人
        /// </summary>
        public string SendPerson { get; set; } = string.Empty;

        /// <summary>
        /// 性别 先生/女士
        /// </summary>
        public string ConSex { get; set; } = string.Empty;

        /// <summary>
        /// 联系电话
        /// </summary>
        public string TelPhone { get; set; } = string.Empty;

        /// <summary>
        /// 联系地址
        /// </summary>
        public string SendAddress { get; set; } = string.Empty;

        /// <summary>
        /// 所属用户
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 是否默认地址 1默认 2不默认
        /// </summary>
        public int IsDefault { get; set; }

    }


    public enum CsSendEnum
    {
        /// <summary>
        /// 寄件信息编号 主键 自增
        /// </summary>
        SendId,
        /// <summary>
        /// 寄件公司名称
        /// </summary>
        CompanyName,
        /// <summary>
        /// 联系人
        /// </summary>
        SendPerson,
        /// <summary>
        /// 性别 先生/女士
        /// </summary>
        ConSex,
        /// <summary>
        /// 联系电话
        /// </summary>
        TelPhone,
        /// <summary>
        /// 联系地址
        /// </summary>
        SendAddress,
        /// <summary>
        /// 所属用户
        /// </summary>
        UserId,
        /// <summary>
        /// 是否默认地址 1默认 2不默认
        /// </summary>
        IsDefault,
    }
}
