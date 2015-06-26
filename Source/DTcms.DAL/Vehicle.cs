using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class Vehicle
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from mtms_Vehicle");
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
        public int Add(Model.Vehicle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into mtms_Vehicle(");
            strSql.Append("CarCode,CarNumber,MotorcadeName,MotorcycleType,LoadingCapacity,EngineType,FrameNumber,ChassisNumber,InsuranceNumber,Remarks");
            strSql.Append(") values (");
            strSql.Append("@CarCode,@CarNumber,@MotorcadeName,@MotorcycleType,@LoadingCapacity,@EngineType,@FrameNumber,@ChassisNumber,@InsuranceNumber,@Remarks");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@CarCode", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CarNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@MotorcadeName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@MotorcycleType", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingCapacity", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@EngineType", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@FrameNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ChassisNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@InsuranceNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.CarCode;
            parameters[1].Value = model.CarNumber;
            parameters[2].Value = model.MotorcadeName;
            parameters[3].Value = model.MotorcycleType;
            parameters[4].Value = model.LoadingCapacity;
            parameters[5].Value = model.EngineType;
            parameters[6].Value = model.FrameNumber;
            parameters[7].Value = model.ChassisNumber;
            parameters[8].Value = model.InsuranceNumber;
            parameters[9].Value = model.Remarks;

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
        public bool Update(Model.Vehicle model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_Vehicle set ");

            strSql.Append(" CarCode = @CarCode , ");
            strSql.Append(" CarNumber = @CarNumber , ");
            strSql.Append(" MotorcadeName = @MotorcadeName , ");
            strSql.Append(" MotorcycleType = @MotorcycleType , ");
            strSql.Append(" LoadingCapacity = @LoadingCapacity , ");
            strSql.Append(" EngineType = @EngineType , ");
            strSql.Append(" FrameNumber = @FrameNumber , ");
            strSql.Append(" ChassisNumber = @ChassisNumber , ");
            strSql.Append(" InsuranceNumber = @InsuranceNumber , ");
            strSql.Append(" Remarks = @Remarks  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@CarCode", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CarNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@MotorcadeName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@MotorcycleType", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingCapacity", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@EngineType", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@FrameNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ChassisNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@InsuranceNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.CarCode;
            parameters[2].Value = model.CarNumber;
            parameters[3].Value = model.MotorcadeName;
            parameters[4].Value = model.MotorcycleType;
            parameters[5].Value = model.LoadingCapacity;
            parameters[6].Value = model.EngineType;
            parameters[7].Value = model.FrameNumber;
            parameters[8].Value = model.ChassisNumber;
            parameters[9].Value = model.InsuranceNumber;
            parameters[10].Value = model.Remarks;
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
            strSql.Append("delete from mtms_Vehicle ");
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
            strSql.Append("delete from mtms_Vehicle ");
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
        public Model.Vehicle GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, CarCode, CarNumber, MotorcadeName, MotorcycleType, LoadingCapacity, EngineType, FrameNumber, ChassisNumber, InsuranceNumber, Remarks  ");
            strSql.Append("  from mtms_Vehicle ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            Model.Vehicle model = new Model.Vehicle();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.CarCode = ds.Tables[0].Rows[0]["CarCode"].ToString();
                model.CarNumber = ds.Tables[0].Rows[0]["CarNumber"].ToString();
                model.MotorcadeName = ds.Tables[0].Rows[0]["MotorcadeName"].ToString();
                model.MotorcycleType = ds.Tables[0].Rows[0]["MotorcycleType"].ToString();
                if (ds.Tables[0].Rows[0]["LoadingCapacity"].ToString() != "")
                {
                    model.LoadingCapacity = decimal.Parse(ds.Tables[0].Rows[0]["LoadingCapacity"].ToString());
                }
                model.EngineType = ds.Tables[0].Rows[0]["EngineType"].ToString();
                model.FrameNumber = ds.Tables[0].Rows[0]["FrameNumber"].ToString();
                model.ChassisNumber = ds.Tables[0].Rows[0]["ChassisNumber"].ToString();
                model.InsuranceNumber = ds.Tables[0].Rows[0]["InsuranceNumber"].ToString();
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
            strSql.Append(" FROM mtms_Vehicle ");
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
            strSql.Append(" FROM mtms_Vehicle ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM mtms_Vehicle");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

    }
}
