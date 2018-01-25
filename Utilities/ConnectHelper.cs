using System.Configuration;

namespace Utilities
{
    /// <summary>
    /// 配置持久化
    /// </summary>
    public class ConnectHelper
    {
        /// <summary>
        /// 数据库链接配置
        /// </summary>
        public static readonly string ConnString = GetConfig("DBString");
        /// <summary>
        /// 缓存默认连接位置
        /// </summary>
        public static readonly string CacheDefault = GetConfig("RedisDefault");


        #region 私方法
        private static string GetConfig(string key)
        {
            typeof(ConnectHelper).LogInfo($"读取\"{key}\"配置记录,验证是否做了持久化配置");
            return ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
        #endregion
    }
}
