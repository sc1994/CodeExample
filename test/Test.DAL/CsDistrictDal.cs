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
    /// 全国省市区三级数据  数据访问层
    /// </summary>
    public partial class CsDistrictDal : ICsDistrictDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM CrabShop.dbo.[CsDistrict] WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsDistrict] WHERE 1 = 1 {where};") > 0;

        public int Add(CsDistrict model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsDistrict] (");
            strSql.Append("Name,ParentId,Code,Sort,FirstPrice,FllowPrice");
            strSql.Append(") VALUES (");
            strSql.Append("@Name,@ParentId,@Code,@Sort,@FirstPrice,@FllowPrice);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CsDistrict model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsDistrict] SET ");
            strSql.Append("Name = @Name,ParentId = @ParentId,Code = @Code,Sort = @Sort,FirstPrice = @FirstPrice,FllowPrice = @FllowPrice");
            strSql.Append(" WHERE Id = @Id");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(Dictionary<CsDistrictEnum, object> updates, string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsDistrict] SET ");
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
            var strSql = "DELETE FROM CrabShop.dbo.[CsDistrict] WHERE Id = @primaryKey";
            return DbClient.Excute(strSql, new { primaryKey }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsDistrict] WHERE 1 = 1 {where}");

        public CsDistrict GetModel(int primaryKey)
        {
            var strSql = "SELECT * FROM CrabShop.dbo.[CsDistrict] WHERE Id = @primaryKey";
            return DbClient.Query<CsDistrict>(strSql, new { primaryKey }).FirstOrDefault();
        }

        public List<CsDistrict> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM CrabShop.dbo.[CsDistrict] WHERE 1 = 1 {where}";
            return DbClient.Query<CsDistrict>(strSql).ToList();
        }

        public List<CsDistrict> GetModelPage(CsDistrictEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsDistrict] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsDistrict] WHERE 1 = 1 {where};");
            return DbClient.Query<CsDistrict>(strSql.ToString()).ToList();
        }

    }
}
