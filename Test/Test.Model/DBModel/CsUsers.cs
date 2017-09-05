using System;

namespace Test.Model.DBModel
{
    /// <summary>
    /// 
    /// </summary>
    public class CsUsers : BaseModel
    {
        public static string PrimaryKey { get; set; } = "UserId";
        public static string IdentityKey { get; set; } = "UserId";

        /// <summary>
        /// 用户编号 主键 自动增长
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// 用户联系方式
        /// </summary>
        public string UserPhone { get; set; } = string.Empty;

        /// <summary>
        /// 用户性别 先生/女士
        /// </summary>
        public string UserSex { get; set; } = string.Empty;

        /// <summary>
        /// 用户状态 1表示可用 2表示不可用
        /// </summary>
        public int UserState { get; set; }

        /// <summary>
        /// 微信开放编号
        /// </summary>
        public string OpenId { get; set; } = string.Empty;

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; } = string.Empty;

        /// <summary>
        /// 余额
        /// </summary>
        public decimal UserBalance { get; set; }

    }


    public enum CsUsersEnum
    {
        /// <summary>
        /// 用户编号 主键 自动增长
        /// </summary>
        UserId,
        /// <summary>
        /// 用户名
        /// </summary>
        UserName,
        /// <summary>
        /// 用户联系方式
        /// </summary>
        UserPhone,
        /// <summary>
        /// 用户性别 先生/女士
        /// </summary>
        UserSex,
        /// <summary>
        /// 用户状态 1表示可用 2表示不可用
        /// </summary>
        UserState,
        /// <summary>
        /// 微信开放编号
        /// </summary>
        OpenId,
        /// <summary>
        /// 备注
        /// </summary>
        Remarks,
        /// <summary>
        /// 余额
        /// </summary>
        UserBalance,
    }
}
