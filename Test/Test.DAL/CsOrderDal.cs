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
    /// 订单表  数据访问层
    /// </summary>
    public partial class CsOrderDal : ICsOrderDal
    {
        public bool Exists(string primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM CrabShop.dbo.[CsOrder] WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsOrder] WHERE 1 = 1 {where};") > 0;

        public string Add(CsOrder model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsOrder] (");
            strSql.Append("OrderId,UserId,TotalMoney,DiscountMoney,ActualMoney,OrderDate,OrderState");
            strSql.Append(") VALUES (");
            strSql.Append("@OrderId,@UserId,@TotalMoney,@DiscountMoney,@ActualMoney,@OrderDate,@OrderState);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<string>(strSql.ToString(), model);
        }

        public bool Update(CsOrder model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsOrder] SET ");
            strSql.Append("UserId = @UserId,TotalMoney = @TotalMoney,DiscountMoney = @DiscountMoney,ActualMoney = @ActualMoney,OrderDate = @OrderDate,OrderState = @OrderState");
            strSql.Append(" WHERE OrderId = @OrderId");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(Dictionary<CsOrderEnum, object> updates, string where)
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
            return DbClient.Excute(strSql.ToString(), para) > 0;
        }

        public bool Delete(string primaryKey)
        {
            var strSql = "DELETE FROM CrabShop.dbo.[CsOrder] WHERE OrderId = @primaryKey";
            return DbClient.Excute(strSql, new { primaryKey }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsOrder] WHERE 1 = 1 {where}");

        public CsOrder GetModel(string primaryKey)
        {
            var strSql = "SELECT * FROM CrabShop.dbo.[CsOrder] WHERE OrderId = @primaryKey";
            return DbClient.Query<CsOrder>(strSql, new { primaryKey }).FirstOrDefault();
        }

        public List<CsOrder> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM CrabShop.dbo.[CsOrder] WHERE 1 = 1 {where}";
            return DbClient.Query<CsOrder>(strSql).ToList();
        }

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
