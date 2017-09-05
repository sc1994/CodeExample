using System;

namespace Test.Model.DBModel
{
    /// <summary>
    /// 菜单配置表
    /// </summary>
    public class CsMenus : BaseModel
    {
        public static string PrimaryKey { get; set; } = "MenuId";
        public static string IdentityKey { get; set; } = "MenuId";

        /// <summary>
        /// 菜单编号 主键 自动增长
        /// </summary>
        public int MenuId { get; set; }

        /// <summary>
        /// 菜单名称
        /// </summary>
        public string MenuName { get; set; } = string.Empty;

        /// <summary>
        /// 菜单路径
        /// </summary>
        public string MenuUrl { get; set; } = string.Empty;

        /// <summary>
        /// 菜单图标
        /// </summary>
        public string MenuIcon { get; set; } = string.Empty;

        /// <summary>
        /// 父级菜单编号,根目录编号为0
        /// </summary>
        public int MenuParId { get; set; }

        /// <summary>
        /// 状态 1表示可用 2表示不可用
        /// </summary>
        public int MenuState { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; } = string.Empty;

    }


    public enum CsMenusEnum
    {
        /// <summary>
        /// 菜单编号 主键 自动增长
        /// </summary>
        MenuId,
        /// <summary>
        /// 菜单名称
        /// </summary>
        MenuName,
        /// <summary>
        /// 菜单路径
        /// </summary>
        MenuUrl,
        /// <summary>
        /// 菜单图标
        /// </summary>
        MenuIcon,
        /// <summary>
        /// 父级菜单编号,根目录编号为0
        /// </summary>
        MenuParId,
        /// <summary>
        /// 状态 1表示可用 2表示不可用
        /// </summary>
        MenuState,
        /// <summary>
        /// 备注
        /// </summary>
        Remarks,
    }
}
