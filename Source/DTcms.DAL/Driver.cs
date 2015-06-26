using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class Driver
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from mtms_Driver");
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
        public int Add(Model.Driver model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into mtms_Driver(");
            strSql.Append("RealName,RealNameCode,CarNumber,IdCardNumber,LinkTel,LinkAddress,BeganWorkDate,IssuedDate,AnnualDate,DrivingLicence,DrivingPermitNumber,DrivingPermitType,IsDimission,Remarks");
            strSql.Append(") values (");
            strSql.Append("@RealName,@RealNameCode,@CarNumber,@IdCardNumber,@LinkTel,@LinkAddress,@BeganWorkDate,@IssuedDate,@AnnualDate,@DrivingLicence,@DrivingPermitNumber,@DrivingPermitType,@IsDimission,@Remarks");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@RealName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@RealNameCode", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CarNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@IdCardNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@BeganWorkDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@IssuedDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@AnnualDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@DrivingLicence", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@DrivingPermitNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@DrivingPermitType", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@IsDimission", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.RealName;
            parameters[1].Value = model.RealNameCode;
            parameters[2].Value = model.CarNumber;
            parameters[3].Value = model.IdCardNumber;
            parameters[4].Value = model.LinkTel;
            parameters[5].Value = model.LinkAddress;
            parameters[6].Value = model.BeganWorkDate;
            parameters[7].Value = model.IssuedDate;
            parameters[8].Value = model.AnnualDate;
            parameters[9].Value = model.DrivingLicence;
            parameters[10].Value = model.DrivingPermitNumber;
            parameters[11].Value = model.DrivingPermitType;
            parameters[12].Value = model.IsDimission;
            parameters[13].Value = model.Remarks;

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
        public bool Update(Model.Driver model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_Driver set ");

            strSql.Append(" RealName = @RealName , ");
            strSql.Append(" RealNameCode = @RealNameCode , ");
            strSql.Append(" CarNumber = @CarNumber , ");
            strSql.Append(" IdCardNumber = @IdCardNumber , ");
            strSql.Append(" LinkTel = @LinkTel , ");
            strSql.Append(" LinkAddress = @LinkAddress , ");
            strSql.Append(" BeganWorkDate = @BeganWorkDate , ");
            strSql.Append(" IssuedDate = @IssuedDate , ");
            strSql.Append(" AnnualDate = @AnnualDate , ");
            strSql.Append(" DrivingLicence = @DrivingLicence , ");
            strSql.Append(" DrivingPermitNumber = @DrivingPermitNumber , ");
            strSql.Append(" DrivingPermitType = @DrivingPermitType , ");
            strSql.Append(" IsDimission = @IsDimission , ");
            strSql.Append(" Remarks = @Remarks  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@RealName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@RealNameCode", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CarNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@IdCardNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LinkAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@BeganWorkDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@IssuedDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@AnnualDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@DrivingLicence", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@DrivingPermitNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@DrivingPermitType", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@IsDimission", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.RealName;
            parameters[2].Value = model.RealNameCode;
            parameters[3].Value = model.CarNumber;
            parameters[4].Value = model.IdCardNumber;
            parameters[5].Value = model.LinkTel;
            parameters[6].Value = model.LinkAddress;
            parameters[7].Value = model.BeganWorkDate;
            parameters[8].Value = model.IssuedDate;
            parameters[9].Value = model.AnnualDate;
            parameters[10].Value = model.DrivingLicence;
            parameters[11].Value = model.DrivingPermitNumber;
            parameters[12].Value = model.DrivingPermitType;
            parameters[13].Value = model.IsDimission;
            parameters[14].Value = model.Remarks;
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
            strSql.Append("delete from mtms_Driver ");
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
            strSql.Append("delete from mtms_Driver ");
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
        public Model.Driver GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, RealName, RealNameCode, CarNumber, IdCardNumber, LinkTel, LinkAddress, BeganWorkDate, IssuedDate, AnnualDate, DrivingLicence, DrivingPermitNumber, DrivingPermitType, IsDimission, Remarks  ");
            strSql.Append("  from mtms_Driver ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            Model.Driver model = new Model.Driver();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.RealNameCode = ds.Tables[0].Rows[0]["RealNameCode"].ToString();
                model.CarNumber = ds.Tables[0].Rows[0]["CarNumber"].ToString();
                model.IdCardNumber = ds.Tables[0].Rows[0]["IdCardNumber"].ToString();
                model.LinkTel = ds.Tables[0].Rows[0]["LinkTel"].ToString();
                model.LinkAddress = ds.Tables[0].Rows[0]["LinkAddress"].ToString();
                if (ds.Tables[0].Rows[0]["BeganWorkDate"].ToString() != "")
                {
                    model.BeganWorkDate = DateTime.Parse(ds.Tables[0].Rows[0]["BeganWorkDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssuedDate"].ToString() != "")
                {
                    model.IssuedDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssuedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AnnualDate"].ToString() != "")
                {
                    model.AnnualDate = DateTime.Parse(ds.Tables[0].Rows[0]["AnnualDate"].ToString());
                }
                model.DrivingLicence = ds.Tables[0].Rows[0]["DrivingLicence"].ToString();
                model.DrivingPermitNumber = ds.Tables[0].Rows[0]["DrivingPermitNumber"].ToString();
                model.DrivingPermitType = ds.Tables[0].Rows[0]["DrivingPermitType"].ToString();
                if (ds.Tables[0].Rows[0]["IsDimission"].ToString() != "")
                {
                    model.IsDimission = int.Parse(ds.Tables[0].Rows[0]["IsDimission"].ToString());
                }
                model.Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }

        public Model.Driver GetModel(string carNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, RealName, RealNameCode, CarNumber, IdCardNumber, LinkTel, LinkAddress, BeganWorkDate, IssuedDate, AnnualDate, DrivingLicence, DrivingPermitNumber, DrivingPermitType, IsDimission, Remarks  ");
            strSql.Append("  from mtms_Driver ");
            strSql.Append(" where CarNumber=@CarNumber");
            SqlParameter[] parameters = {
					new SqlParameter("@CarNumber", SqlDbType.VarChar,254)
			};
            parameters[0].Value = carNumber;


            Model.Driver model = new Model.Driver();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.RealName = ds.Tables[0].Rows[0]["RealName"].ToString();
                model.RealNameCode = ds.Tables[0].Rows[0]["RealNameCode"].ToString();
                model.CarNumber = ds.Tables[0].Rows[0]["CarNumber"].ToString();
                model.IdCardNumber = ds.Tables[0].Rows[0]["IdCardNumber"].ToString();
                model.LinkTel = ds.Tables[0].Rows[0]["LinkTel"].ToString();
                model.LinkAddress = ds.Tables[0].Rows[0]["LinkAddress"].ToString();
                if (ds.Tables[0].Rows[0]["BeganWorkDate"].ToString() != "")
                {
                    model.BeganWorkDate = DateTime.Parse(ds.Tables[0].Rows[0]["BeganWorkDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IssuedDate"].ToString() != "")
                {
                    model.IssuedDate = DateTime.Parse(ds.Tables[0].Rows[0]["IssuedDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AnnualDate"].ToString() != "")
                {
                    model.AnnualDate = DateTime.Parse(ds.Tables[0].Rows[0]["AnnualDate"].ToString());
                }
                model.DrivingLicence = ds.Tables[0].Rows[0]["DrivingLicence"].ToString();
                model.DrivingPermitNumber = ds.Tables[0].Rows[0]["DrivingPermitNumber"].ToString();
                model.DrivingPermitType = ds.Tables[0].Rows[0]["DrivingPermitType"].ToString();
                if (ds.Tables[0].Rows[0]["IsDimission"].ToString() != "")
                {
                    model.IsDimission = int.Parse(ds.Tables[0].Rows[0]["IsDimission"].ToString());
                }
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
            strSql.Append(" FROM mtms_Driver ");
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
            strSql.Append(" FROM mtms_Driver ");
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
            strSql.Append("select * FROM mtms_Driver");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}
