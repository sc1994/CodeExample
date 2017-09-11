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
    /// 订单表  数据访问层
    /// </summary>
    public partial class CsOrderDal : ICsOrderDal
    {
        public bool Exists(string primaryKey)
            => DbClient.ExecuteScalar<int>("SELECT COUNT(1) FROM CrabShop.dbo.[CsOrder] WHERE 1 = @primaryKey", new { primaryKey }) > 0;

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsOrder] WHERE 1 = 1 {where};") > 0;

        public string Add(CsOrder model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsOrder] (");
            strSql.Append("OrderId,UserId,TotalMoney,DiscountMoney,ActualMoney,OrderDate,OrderState");
            strSql.Append(") VALUES (");
            strSql.Append("@OrderId,@UserId,@TotalMoney,@DiscountMoney,@ActualMoney,@OrderDate,@OrderState);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<string>(strSql.ToString(), model, conn, transaction);
        }

        public bool Update(CsOrder model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsOrder] SET ");
            strSql.Append("UserId = @UserId,TotalMoney = @TotalMoney,DiscountMoney = @DiscountMoney,ActualMoney = @ActualMoney,OrderDate = @OrderDate,OrderState = @OrderState");
            strSql.Append(" WHERE OrderId = @OrderId");
            return DbClient.Excute(strSql.ToString(), model, conn, transaction) > 0;
        }

        public bool Update(Dictionary<CsOrderEnum, object> updates, string where, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsOrder] SET ");
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

        public bool Delete(string primaryKey, IDbConnection conn = null, IDbTransaction transaction = null)
            => DbClient.Excute("DELETE FROM CrabShop.dbo.[CsOrder] WHERE OrderId = @primaryKey", new { primaryKey }, conn, transaction) > 0;

        public int DeleteByWhere(string where, IDbConnection conn = null, IDbTransaction transaction = null)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsOrder] WHERE 1 = 1 {where}", null, conn, transaction);

        public CsOrder GetModel(string primaryKey)
            => DbClient.Query<CsOrder>("SELECT * FROM CrabShop.dbo.[CsOrder] WHERE OrderId = @primaryKey", new { primaryKey }).FirstOrDefault();

        public List<CsOrder> GetModelList(string where)
            => DbClient.Query<CsOrder>($"SELECT * FROM CrabShop.dbo.[CsOrder] WHERE 1 = 1 {where}").ToList();

        public List<CsOrder> GetModelPage(CsOrderEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsOrder] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsOrder] WHERE 1 = 1 {where};");
            return DbClient.Query<CsOrder>(strSql.ToString()).ToList();
        }

    }
}
