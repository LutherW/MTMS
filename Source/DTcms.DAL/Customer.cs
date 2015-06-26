using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class Customer
    {
        private string databaseprefix; //数据库表名前缀
        public Customer(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from mtms_Customer");
            strSql.Append(" where ");
            strSql.Append(" Id = @Id  ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into mtms_Customer(");
            strSql.Append("ShortName,FullName,TypeName,Category,Code,LinkMan,LinkTel,MobileNumber,LinkAddress,TaxRegistrationNumber,Remarks");
            strSql.Append(") values (");
            strSql.Append("@ShortName,@FullName,@TypeName,@Category,@Code,@LinkMan,@LinkTel,@MobileNumber,@LinkAddress,@TaxRegistrationNumber,@Remarks");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@ShortName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@FullName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@TypeName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Category", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@MobileNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@TaxRegistrationNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.ShortName;
            parameters[1].Value = model.FullName;
            parameters[2].Value = model.TypeName;
            parameters[3].Value = model.Category;
            parameters[4].Value = model.Code;
            parameters[5].Value = model.LinkMan;
            parameters[6].Value = model.LinkTel;
            parameters[7].Value = model.MobileNumber;
            parameters[8].Value = model.LinkAddress;
            parameters[9].Value = model.TaxRegistrationNumber;
            parameters[10].Value = model.Remarks;

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
        public bool Update(Model.Customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_Customer set ");

            strSql.Append(" ShortName = @ShortName , ");
            strSql.Append(" FullName = @FullName , ");
            strSql.Append(" TypeName = @TypeName , ");
            strSql.Append(" Category = @Category , ");
            strSql.Append(" Code = @Code , ");
            strSql.Append(" LinkMan = @LinkMan , ");
            strSql.Append(" LinkTel = @LinkTel , ");
            strSql.Append(" MobileNumber = @MobileNumber , ");
            strSql.Append(" LinkAddress = @LinkAddress , ");
            strSql.Append(" TaxRegistrationNumber = @TaxRegistrationNumber , ");
            strSql.Append(" Remarks = @Remarks  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@ShortName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@FullName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@TypeName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Category", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@MobileNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@TaxRegistrationNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.ShortName;
            parameters[2].Value = model.FullName;
            parameters[3].Value = model.TypeName;
            parameters[4].Value = model.Category;
            parameters[5].Value = model.Code;
            parameters[6].Value = model.LinkMan;
            parameters[7].Value = model.LinkTel;
            parameters[8].Value = model.MobileNumber;
            parameters[9].Value = model.LinkAddress;
            parameters[10].Value = model.TaxRegistrationNumber;
            parameters[11].Value = model.Remarks;
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
        public bool Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from mtms_Customer ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


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
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from mtms_Customer ");
            strSql.Append(" where ID in (" + Idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.Customer GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, ShortName, FullName, TypeName, Category, Code, LinkMan, LinkTel, MobileNumber, LinkAddress, TaxRegistrationNumber, Remarks  ");
            strSql.Append("  from mtms_Customer ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            Model.Customer model = new Model.Customer();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.ShortName = ds.Tables[0].Rows[0]["ShortName"].ToString();
                model.FullName = ds.Tables[0].Rows[0]["FullName"].ToString();
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                model.Category = ds.Tables[0].Rows[0]["Category"].ToString();
                model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                model.LinkMan = ds.Tables[0].Rows[0]["LinkMan"].ToString();
                model.LinkTel = ds.Tables[0].Rows[0]["LinkTel"].ToString();
                model.MobileNumber = ds.Tables[0].Rows[0]["MobileNumber"].ToString();
                model.LinkAddress = ds.Tables[0].Rows[0]["LinkAddress"].ToString();
                model.TaxRegistrationNumber = ds.Tables[0].Rows[0]["TaxRegistrationNumber"].ToString();
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM mtms_Customer ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" * ");
            strSql.Append(" FROM mtms_Customer ");
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
            strSql.Append("select * FROM mtms_Customer");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}
