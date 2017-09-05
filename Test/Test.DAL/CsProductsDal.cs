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
    public partial class CsProductsDal : ICsProductsDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM CrabShop.dbo.[CsProducts] WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsProducts] WHERE 1 = 1 {where};") > 0;

        public int Add(CsProducts model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsProducts] (");
            strSql.Append("ProductType,ProductName,ProductWeight,ProductState");
            strSql.Append(") VALUES (");
            strSql.Append("@ProductType,@ProductName,@ProductWeight,@ProductState);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CsProducts model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsProducts] SET ");
            strSql.Append("ProductType = @ProductType,ProductName = @ProductName,ProductWeight = @ProductWeight,ProductState = @ProductState");
            strSql.Append(" WHERE ProductId = @ProductId");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(Dictionary<CsProductsEnum, object> updates, string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsProducts] SET ");
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
            var strSql = "DELETE FROM CrabShop.dbo.[CsProducts] WHERE ProductId = @primaryKey";
            return DbClient.Excute(strSql, new { primaryKey }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsProducts] WHERE 1 = 1 {where}");

        public CsProducts GetModel(int primaryKey)
        {
            var strSql = "SELECT * FROM CrabShop.dbo.[CsProducts] WHERE ProductId = @primaryKey";
            return DbClient.Query<CsProducts>(strSql, new { primaryKey }).FirstOrDefault();
        }

        public List<CsProducts> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM CrabShop.dbo.[CsProducts] WHERE 1 = 1 {where}";
            return DbClient.Query<CsProducts>(strSql).ToList();
        }

        public List<CsProducts> GetModelPage(CsProductsEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsProducts] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsProducts] WHERE 1 = 1 {where};");
            return DbClient.Query<CsProducts>(strSql.ToString()).ToList();
        }

    }
}
