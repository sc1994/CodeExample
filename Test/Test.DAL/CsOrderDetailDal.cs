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
    /// 订单扩展表  数据访问层
    /// </summary>
    public partial class CsOrderDetailDal : ICsOrderDetailDal
    {
        public bool Exists(int primaryKey)
            => DbClient.ExecuteScalar<int>("SELECT COUNT(1) FROM CrabShop.dbo.[CsOrderDetail] WHERE 1 = @primaryKey", new { primaryKey }) > 0;

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsOrderDetail] WHERE 1 = 1 {where};") > 0;

        public int Add(CsOrderDetail model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsOrderDetail] (");
            strSql.Append("OrderId,ProductId,UnitPrice,ProductNumber,TotalPrice,ChoseType");
            strSql.Append(") VALUES (");
            strSql.Append("@OrderId,@ProductId,@UnitPrice,@ProductNumber,@TotalPrice,@ChoseType);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model, conn, transaction);
        }

        public bool Update(CsOrderDetail model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsOrderDetail] SET ");
            strSql.Append("OrderId = @OrderId,ProductId = @ProductId,UnitPrice = @UnitPrice,ProductNumber = @ProductNumber,TotalPrice = @TotalPrice,ChoseType = @ChoseType");
            strSql.Append(" WHERE DetailId = @DetailId");
            return DbClient.Excute(strSql.ToString(), model, conn, transaction) > 0;
        }

        public bool Update(Dictionary<CsOrderDetailEnum, object> updates, string where, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsOrderDetail] SET ");
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
            => DbClient.Excute("DELETE FROM CrabShop.dbo.[CsOrderDetail] WHERE DetailId = @primaryKey", new { primaryKey }, conn, transaction) > 0;

        public int DeleteByWhere(string where, IDbConnection conn = null, IDbTransaction transaction = null)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsOrderDetail] WHERE 1 = 1 {where}", null, conn, transaction);

        public CsOrderDetail GetModel(int primaryKey)
            => DbClient.Query<CsOrderDetail>("SELECT * FROM CrabShop.dbo.[CsOrderDetail] WHERE DetailId = @primaryKey", new { primaryKey }).FirstOrDefault();

        public List<CsOrderDetail> GetModelList(string where)
            => DbClient.Query<CsOrderDetail>($"SELECT * FROM CrabShop.dbo.[CsOrderDetail] WHERE 1 = 1 {where}").ToList();

        public List<CsOrderDetail> GetModelPage(CsOrderDetailEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsOrderDetail] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsOrderDetail] WHERE 1 = 1 {where};");
            return DbClient.Query<CsOrderDetail>(strSql.ToString()).ToList();
        }

    }
}
