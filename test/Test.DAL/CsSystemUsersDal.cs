using Dapper;
using System.Collections.Generic;
using System.Linq;
using Test.IDAL;
using Test.Model.DBModel;
using Test.Common;
using System.Text;

namespace Test.DAL
{
    /// <summary>
    /// 系统用户表  数据访问层
    /// </summary>
    public partial class CsSystemUsersDal : ICsSystemUsersDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM CrabShop.dbo.[CsSystemUsers] WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsSystemUsers] WHERE 1 = 1 {where};") > 0;

        public int Add(CsSystemUsers model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsSystemUsers] (");
            strSql.Append("SysUserName,SysUserPassword,SysUserType,SysUserState,SysUserDate,DeleteDate,DeleteDescribe");
            strSql.Append(") VALUES (");
            strSql.Append("@SysUserName,@SysUserPassword,@SysUserType,@SysUserState,@SysUserDate,@DeleteDate,@DeleteDescribe);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CsSystemUsers model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsSystemUsers] SET ");
            strSql.Append("SysUserName = @SysUserName,SysUserPassword = @SysUserPassword,SysUserType = @SysUserType,SysUserState = @SysUserState,SysUserDate = @SysUserDate,DeleteDate = @DeleteDate,DeleteDescribe = @DeleteDescribe");
            strSql.Append(" WHERE SysUserId = @SysUserId");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(Dictionary<CsSystemUsersEnum, object> updates, string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsSystemUsers] SET ");
            var para = new DynamicParameters();
            foreach (var update in updates)
            {
                strSql.Append($" {update.Key} = @{update.Key},");
                para.Add(update.Key.ToString(), update.Value);
            }
            strSql.Remove(strSql.Length - 1, 1);
            strSql.Append($" WHERE 1=1 {where}");
            return DbClient.Excute(strSql.ToString(), para) > 0;
        }

        public bool Delete(int primaryKey)
        {
            var strSql = "DELETE FROM CrabShop.dbo.[CsSystemUsers] WHERE SysUserId = @primaryKey";
            return DbClient.Excute(strSql, new { primaryKey }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsSystemUsers] WHERE 1 = 1 {where}");

        public CsSystemUsers GetModel(int primaryKey)
        {
            var strSql = "SELECT * FROM CrabShop.dbo.[CsSystemUsers] WHERE SysUserId = @primaryKey";
            return DbClient.Query<CsSystemUsers>(strSql, new { primaryKey }).FirstOrDefault();
        }

        public List<CsSystemUsers> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM CrabShop.dbo.[CsSystemUsers] WHERE 1 = 1 {where}";
            return DbClient.Query<CsSystemUsers>(strSql).ToList();
        }

        public List<CsSystemUsers> GetModelPage(CsSystemUsersEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsSystemUsers] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsSystemUsers] WHERE 1 = 1 {where};");
            return DbClient.Query<CsSystemUsers>(strSql.ToString()).ToList();
        }

    }
}
