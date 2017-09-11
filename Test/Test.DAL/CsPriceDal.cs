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
    public partial class CsPriceDal : ICsPriceDal
    {
        public bool Exists(int primaryKey)
            => DbClient.ExecuteScalar<int>("SELECT COUNT(1) FROM CrabShop.dbo.[CsPrice] WHERE 1 = @primaryKey", new { primaryKey }) > 0;

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsPrice] WHERE 1 = 1 {where};") > 0;

        public int Add(CsPrice model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsPrice] (");
            strSql.Append("PriceNumber,ProductId,PriceDate");
            strSql.Append(") VALUES (");
            strSql.Append("@PriceNumber,@ProductId,@PriceDate);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model, conn, transaction);
        }

        public bool Update(CsPrice model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsPrice] SET ");
            strSql.Append("PriceNumber = @PriceNumber,ProductId = @ProductId,PriceDate = @PriceDate");
            strSql.Append(" WHERE PriceId = @PriceId");
            return DbClient.Excute(strSql.ToString(), model, conn, transaction) > 0;
        }

        public bool Update(Dictionary<CsPriceEnum, object> updates, string where, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsPrice] SET ");
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
            => DbClient.Excute("DELETE FROM CrabShop.dbo.[CsPrice] WHERE PriceId = @primaryKey", new { primaryKey }, conn, transaction) > 0;

        public int DeleteByWhere(string where, IDbConnection conn = null, IDbTransaction transaction = null)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsPrice] WHERE 1 = 1 {where}", null, conn, transaction);

        public CsPrice GetModel(int primaryKey)
            => DbClient.Query<CsPrice>("SELECT * FROM CrabShop.dbo.[CsPrice] WHERE PriceId = @primaryKey", new { primaryKey }).FirstOrDefault();

        public List<CsPrice> GetModelList(string where)
            => DbClient.Query<CsPrice>($"SELECT * FROM CrabShop.dbo.[CsPrice] WHERE 1 = 1 {where}").ToList();

        public List<CsPrice> GetModelPage(CsPriceEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsPrice] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsPrice] WHERE 1 = 1 {where};");
            return DbClient.Query<CsPrice>(strSql.ToString()).ToList();
        }

    }
}