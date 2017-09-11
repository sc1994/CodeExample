using Dapper;
using System.Linq;
using System.Data;
using Test.IDAL;
using Test.Model.DBModel;
using Test.Common;
using System.Collections.Generic;
using System.Text;

namespace Test.DAL
{
    /// <summary>
    ///   数据访问层
    /// </summary>
    public partial class CsUsersDal : ICsUsersDal
    {
        public bool Exists(int primaryKey)
            => DbClient.ExecuteScalar<int>("SELECT COUNT(1) FROM CrabShop.dbo.[CsUsers] WHERE 1 = @primaryKey", new { primaryKey }) > 0;

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsUsers] WHERE 1 = 1 {where};") > 0;

        public int Add(CsUsers model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsUsers] (");
            strSql.Append("UserName,UserPhone,UserSex,UserState,OpenId,Remarks,UserBalance");
            strSql.Append(") VALUES (");
            strSql.Append("@UserName,@UserPhone,@UserSex,@UserState,@OpenId,@Remarks,@UserBalance);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model, conn, transaction);
        }

        public bool Update(CsUsers model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsUsers] SET ");
            strSql.Append("UserName = @UserName,UserPhone = @UserPhone,UserSex = @UserSex,UserState = @UserState,OpenId = @OpenId,Remarks = @Remarks,UserBalance = @UserBalance");
            strSql.Append(" WHERE UserId = @UserId");
            return DbClient.Excute(strSql.ToString(), model, conn, transaction) > 0;
        }

        public bool Update(Dictionary<CsUsersEnum, object> updates, string where, IDbConnection conn = null, IDbTransaction transaction = null)
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
            return DbClient.Excute(strSql.ToString(), para, conn, transaction) > 0;
        }

        public bool Delete(int primaryKey, IDbConnection conn = null, IDbTransaction transaction = null)
            => DbClient.Excute("DELETE FROM CrabShop.dbo.[CsUsers] WHERE UserId = @primaryKey", new { primaryKey }, conn, transaction) > 0;

        public int DeleteByWhere(string where, IDbConnection conn = null, IDbTransaction transaction = null)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsUsers] WHERE 1 = 1 {where}", null, conn, transaction);

        public CsUsers GetModel(int primaryKey)
            => DbClient.Query<CsUsers>("SELECT * FROM CrabShop.dbo.[CsUsers] WHERE UserId = @primaryKey", new { primaryKey }).FirstOrDefault();

        public List<CsUsers> GetModelList(string where)
            => DbClient.Query<CsUsers>($"SELECT * FROM CrabShop.dbo.[CsUsers] WHERE 1 = 1 {where}").ToList();

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
