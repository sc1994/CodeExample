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
    /// 用户表  数据访问层
    /// </summary>
    public partial class CsUsersDal : ICsUsersDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM CrabShop.dbo.[CsUsers] WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsUsers] WHERE 1 = 1 {where};") > 0;

        public int Add(CsUsers model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsUsers] (");
            strSql.Append("UserName,UserPhone,UserSex,UserState,OpenId,Remarks,UserBalance,TotalWight");
            strSql.Append(") VALUES (");
            strSql.Append("@UserName,@UserPhone,@UserSex,@UserState,@OpenId,@Remarks,@UserBalance,@TotalWight);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CsUsers model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsUsers] SET ");
            strSql.Append("UserName = @UserName,UserPhone = @UserPhone,UserSex = @UserSex,UserState = @UserState,OpenId = @OpenId,Remarks = @Remarks,UserBalance = @UserBalance,TotalWight = @TotalWight");
            strSql.Append(" WHERE UserId = @UserId");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(Dictionary<CsUsersEnum, object> updates, string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsUsers] SET ");
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
            var strSql = "DELETE FROM CrabShop.dbo.[CsUsers] WHERE UserId = @primaryKey";
            return DbClient.Excute(strSql, new { primaryKey }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsUsers] WHERE 1 = 1 {where}");

        public CsUsers GetModel(int primaryKey)
        {
            var strSql = "SELECT * FROM CrabShop.dbo.[CsUsers] WHERE UserId = @primaryKey";
            return DbClient.Query<CsUsers>(strSql, new { primaryKey }).FirstOrDefault();
        }

        public List<CsUsers> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM CrabShop.dbo.[CsUsers] WHERE 1 = 1 {where}";
            return DbClient.Query<CsUsers>(strSql).ToList();
        }

        public List<CsUsers> GetModelPage(CsUsersEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsUsers] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsUsers] WHERE 1 = 1 {where};");
            return DbClient.Query<CsUsers>(strSql.ToString()).ToList();
        }

    }
}
