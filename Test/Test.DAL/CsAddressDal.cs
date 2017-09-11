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
    /// 收货地址表   数据访问层
    /// </summary>
    public partial class CsAddressDal : ICsAddressDal
    {
        public bool Exists(int primaryKey)
            => DbClient.ExecuteScalar<int>("SELECT COUNT(1) FROM CrabShop.dbo.[CsAddress] WHERE 1 = @primaryKey", new { primaryKey }) > 0;

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsAddress] WHERE 1 = 1 {where};") > 0;

        public int Add(CsAddress model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsAddress] (");
            strSql.Append("Province,City,District,Details,Consignee,ConSex,TelPhone,IsDefault");
            strSql.Append(") VALUES (");
            strSql.Append("@Province,@City,@District,@Details,@Consignee,@ConSex,@TelPhone,@IsDefault);");
            strSql.Append("SELECT @@IDENTITY");
            return DbClient.ExecuteScalar<int>(strSql.ToString(), model, conn, transaction);
        }

        public bool Update(CsAddress model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsAddress] SET ");
            strSql.Append("Province = @Province,City = @City,District = @District,Details = @Details,Consignee = @Consignee,ConSex = @ConSex,TelPhone = @TelPhone,IsDefault = @IsDefault");
            strSql.Append(" WHERE AddressId = @AddressId");
            return DbClient.Excute(strSql.ToString(), model, conn, transaction) > 0;
        }

        public bool Update(Dictionary<CsAddressEnum, object> updates, string where, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsAddress] SET ");
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
            => DbClient.Excute("DELETE FROM CrabShop.dbo.[CsAddress] WHERE AddressId = @primaryKey", new { primaryKey }, conn, transaction) > 0;

        public int DeleteByWhere(string where, IDbConnection conn = null, IDbTransaction transaction = null)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsAddress] WHERE 1 = 1 {where}", null, conn, transaction);

        public CsAddress GetModel(int primaryKey)
            => DbClient.Query<CsAddress>("SELECT * FROM CrabShop.dbo.[CsAddress] WHERE AddressId = @primaryKey", new { primaryKey }).FirstOrDefault();

        public List<CsAddress> GetModelList(string where)
            => DbClient.Query<CsAddress>($"SELECT * FROM CrabShop.dbo.[CsAddress] WHERE 1 = 1 {where}").ToList();

        public List<CsAddress> GetModelPage(CsAddressEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsAddress] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsAddress] WHERE 1 = 1 {where};");
            return DbClient.Query<CsAddress>(strSql.ToString()).ToList();
        }

    }
}
