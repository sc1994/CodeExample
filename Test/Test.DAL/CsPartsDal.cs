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
    public partial class CsPartsDal : ICsPartsDal
    {
        public bool Exists(object primaryKey)
            => false;

        public bool ExistsByWhere(string where)
            => DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsParts] WHERE 1 = 1 {where};") > 0;

        public object Add(CsParts model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("INSERT INTO CrabShop.dbo.[CsParts] (");
            strSql.Append("PartType,PartName,PartWeight,PartPrice,OperationDate,PartState");
            strSql.Append(") VALUES (");
            strSql.Append("@PartType,@PartName,@PartWeight,@PartPrice,@OperationDate,@PartState);");
            return DbClient.Excute(strSql.ToString(), model, conn, transaction);
        }

        public bool Update(CsParts model, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsParts] SET ");
            strSql.Append("PartType = @PartType,PartName = @PartName,PartWeight = @PartWeight,PartPrice = @PartPrice,OperationDate = @OperationDate,PartState = @PartState");
            strSql.Append(" WHERE PartId = @PartId");
            return DbClient.Excute(strSql.ToString(), model, conn, transaction) > 0;
        }

        public bool Update(Dictionary<CsPartsEnum, object> updates, string where, IDbConnection conn = null, IDbTransaction transaction = null)
        {
            var strSql = new StringBuilder();
            strSql.Append("UPDATE CrabShop.dbo.[CsParts] SET ");
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

        public bool Delete(object primaryKey, IDbConnection conn = null, IDbTransaction transaction = null)
            => false;

        public int DeleteByWhere(string where, IDbConnection conn = null, IDbTransaction transaction = null)
            => DbClient.Excute($"DELETE FROM CrabShop.dbo.[CsParts] WHERE 1 = 1 {where}", null, conn, transaction);

        public CsParts GetModel(object primaryKey)
            => null;

        public List<CsParts> GetModelList(string where)
            => DbClient.Query<CsParts>($"SELECT * FROM CrabShop.dbo.[CsParts] WHERE 1 = 1 {where}").ToList();

        public List<CsParts> GetModelPage(CsPartsEnum order, string where, int pageIndex, int pageSize, out int total)
        {
            var strSql = new StringBuilder();
            strSql.Append($"SELECT * FROM ( SELECT TOP ({pageSize})");
            strSql.Append($"ROW_NUMBER() OVER ( ORDER BY {order} DESC ) AS ROWNUMBER,* ");
            strSql.Append(" FROM  CrabShop.dbo.[CsParts] ");
            strSql.Append($" WHERE 1 = 1 {where} ");
            strSql.Append(" ) A");
            strSql.Append($" WHERE ROWNUMBER BETWEEN {(pageIndex - 1) * pageSize + 1} AND {pageIndex * pageSize}; ");
            total = DbClient.ExecuteScalar<int>($"SELECT COUNT(1) FROM CrabShop.dbo.[CsParts] WHERE 1 = 1 {where};");
            return DbClient.Query<CsParts>(strSql.ToString()).ToList();
        }

    }
}
