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
    /// 寄件方信息  数据访问层
    /// </summary>
    public partial class CsSendDal : ICsSendDal
    {
        public bool Exists(int primaryKey)
        {
            var strSql = "SELECT COUNT(1) FROM CrabShop.dbo.[CsSend] WHERE 1 = @primaryKey";
            var parameters = new { primaryKey };
            return DbClient.Excute(strSql, parameters) > 0;
        }

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsSend] WHERE 1 = 1 {where};") > 0;

        public int Add(CsSend model)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsSend] (");
            strSql.Append("CompanyName,SendPerson,ConSex,TelPhone,SendAddress,UserId,IsDefault");
            strSql.Append(") VALUES (");
            strSql.Append("@CompanyName,@SendPerson,@ConSex,@TelPhone,@SendAddress,@UserId,@IsDefault);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model);
        }

        public bool Update(CsSend model)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsSend] SET ");
            strSql.Append("CompanyName = @CompanyName,SendPerson = @SendPerson,ConSex = @ConSex,TelPhone = @TelPhone,SendAddress = @SendAddress,UserId = @UserId,IsDefault = @IsDefault");
            strSql.Append(" WHERE SendId = @SendId");
            return DbClient.Excute(strSql.ToString(), model) > 0;
        }

        public bool Update(Dictionary<CsSendEnum, object> updates, string where)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsSend] SET ");
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
            var strSql = "DELETE FROM CrabShop.dbo.[CsSend] WHERE SendId = @primaryKey";
            return DbClient.Excute(strSql, new { primaryKey }) > 0;
        }

        public int DeleteByWhere(string where)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsSend] WHERE 1 = 1 {where}");

        public CsSend GetModel(int primaryKey)
        {
            var strSql = "SELECT * FROM CrabShop.dbo.[CsSend] WHERE SendId = @primaryKey";
            return DbClient.Query<CsSend>(strSql, new { primaryKey }).FirstOrDefault();
        }

        public List<CsSend> GetModelList(string where)
        {
            var strSql = $"SELECT * FROM CrabShop.dbo.[CsSend] WHERE 1 = 1 {where}";
            return DbClient.Query<CsSend>(strSql).ToList();
        }

        public List<CsSend> GetModelPage(CsSendEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsSend] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsSend] WHERE 1 = 1 {where};");
            return DbClient.Query<CsSend>(strSql.ToString()).ToList();
        }

    }
}
