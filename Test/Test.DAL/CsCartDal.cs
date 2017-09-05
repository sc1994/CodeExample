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
    ///   数据访问层
    /// </summary>
    public partial class CsCartDal : ICsCartDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM CrabShop.dbo.[CsCart] WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsCart] WHERE 1 = 1 {where};") > 0;

        public int Add(CsCart model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsCart] (");
            strSql.Append("UserId,ProductId,ProductNumber,ChoseType");
            strSql.Append(") VALUES (");
            strSql.Append("@UserId,@ProductId,@ProductNumber,@ChoseType);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CsCart model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsCart] SET ");
            strSql.Append("UserId = @UserId,ProductId = @ProductId,ProductNumber = @ProductNumber,ChoseType = @ChoseType");
            strSql.Append(" WHERE CartId = @CartId");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(Dictionary<CsCartEnum, object> updates, string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsCart] SET ");
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
            var strSql = "DELETE FROM CrabShop.dbo.[CsCart] WHERE CartId = @primaryKey";
            return DbClient.Excute(strSql, new { primaryKey }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsCart] WHERE 1 = 1 {where}");

        public CsCart GetModel(int primaryKey)
        {
            var strSql = "SELECT * FROM CrabShop.dbo.[CsCart] WHERE CartId = @primaryKey";
            return DbClient.Query<CsCart>(strSql, new { primaryKey }).FirstOrDefault();
        }

        public List<CsCart> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM CrabShop.dbo.[CsCart] WHERE 1 = 1 {where}";
            return DbClient.Query<CsCart>(strSql).ToList();
        }

        public List<CsCart> GetModelPage(CsCartEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsCart] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsCart] WHERE 1 = 1 {where};");
            return DbClient.Query<CsCart>(strSql.ToString()).ToList();
        }

    }
}
