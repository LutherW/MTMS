using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 数据访问类:手机短信模板
    /// </summary>
    public partial class Motorcade
    {
        private string databaseprefix; //数据库表名前缀
        public Motorcade(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "Motorcade");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) from " + databaseprefix + "Motorcade");
            strSql.Append(" where Code=@Code ");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,254)};
            parameters[0].Value = code;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Motorcade model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "Motorcade(");
            strSql.Append("Name,Code,IsOutOfTeam,LinkMan,LinkTel,LinkAddress,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@Name,@Code,@IsOutOfTeam,@LinkMan,@LinkTel,@LinkAddress,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,254),
					new SqlParameter("@Code", SqlDbType.NVarChar,254),
					new SqlParameter("@IsOutOfTeam", SqlDbType.SmallInt),
					new SqlParameter("@LinkMan", SqlDbType.NVarChar,254),
                    new SqlParameter("@LinkTel", SqlDbType.NVarChar,254),
                    new SqlParameter("@LinkAddress", SqlDbType.NVarChar,254),
                    new SqlParameter("@Remarks", SqlDbType.NVarChar,254)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.IsOutOfTeam;
            parameters[3].Value = model.LinkMan;
            parameters[4].Value = model.LinkTel;
            parameters[5].Value = model.LinkAddress;
            parameters[6].Value = model.Remarks;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Motorcade model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "Motorcade set ");
            strSql.Append("Name=@Name,");
            strSql.Append("Code=@Code,");
            strSql.Append("IsOutOfTeam=@IsOutOfTeam,");
            strSql.Append("LinkMan=@LinkMan,");
            strSql.Append("LinkTel=@LinkTel,");
            strSql.Append("LinkAddress=@LinkAddress,");
            strSql.Append("Remarks=@Remarks");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,254),
					new SqlParameter("@Code", SqlDbType.NVarChar,254),
					new SqlParameter("@IsOutOfTeam", SqlDbType.SmallInt),
					new SqlParameter("@LinkMan", SqlDbType.NVarChar,254),
                    new SqlParameter("@LinkTel", SqlDbType.NVarChar,254),
                    new SqlParameter("@LinkAddress", SqlDbType.NVarChar,254),
                    new SqlParameter("@Remarks", SqlDbType.NVarChar,254),
                    new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = model.Name;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.IsOutOfTeam;
            parameters[3].Value = model.LinkMan;
            parameters[4].Value = model.LinkTel;
            parameters[5].Value = model.LinkAddress;
            parameters[6].Value = model.Remarks;
            parameters[7].Value = model.Id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "Motorcade ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Motorcade GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,Code,IsOutOfTeam,LinkMan,LinkTel,LinkAddress,Remarks from " + databaseprefix + "Motorcade ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.Motorcade model = new Model.Motorcade();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                if (ds.Tables[0].Rows[0]["IsOutOfTeam"].ToString() != "")
                {
                    model.IsOutOfTeam = ds.Tables[0].Rows[0]["IsOutOfTeam"].ToString().Equals("1");
                }
                model.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();
                model.LinkTel = ds.Tables[0].Rows[0]["LinkTel"].ToString();
                model.LinkAddress = ds.Tables[0].Rows[0]["LinkAddress"].ToString();
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Motorcade GetModel(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id from " + databaseprefix + "Motorcade");
            strSql.Append(" where Code=@Code");
            SqlParameter[] parameters = {
					new SqlParameter("@Code", SqlDbType.NVarChar,254)};
            parameters[0].Value = code;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" Id,Name,Code,IsOutOfTeam,LinkMan,LinkTel,LinkAddress,Remarks ");
            strSql.Append(" FROM " + databaseprefix + "Motorcade ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id,Name,Code,IsOutOfTeam,LinkMan,LinkTel,LinkAddress,Remarks FROM " + databaseprefix + "Motorcade");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}