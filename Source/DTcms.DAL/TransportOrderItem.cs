using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;

namespace DTcms.DAL
{
    public partial class TransportOrderItem
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from mtms_TransportOrderItem");
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
        public int Add(Model.TransportOrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into mtms_TransportOrderItem(");
            strSql.Append("TransportOrderId,RoundStatus,ContractNumber,BillNumber,Shipper,Receiver,LoadingAddress,UnloadingAddress,Goods,Unit,FactDispatchCount,FactReceivedCount,CompensationCosts,MyCosts,Haulway,LoadingCapacityRunning,NoLoadingCapacityRunning,Formula,UnitPrice,TotalPrice,CompanyPrice,DispatchCount,OrderCode,OrderId");
            strSql.Append(") values (");
            strSql.Append("@TransportOrderId,@RoundStatus,@ContractNumber,@BillNumber,@Shipper,@Receiver,@LoadingAddress,@UnloadingAddress,@Goods,@Unit,@FactDispatchCount,@FactReceivedCount,@CompensationCosts,@MyCosts,@Haulway,@LoadingCapacityRunning,@NoLoadingCapacityRunning,@Formula,@UnitPrice,@TotalPrice,@CompanyPrice,@DispatchCount,@OrderCode,@OrderId");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@TransportOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoundStatus", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ContractNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@BillNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Shipper", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Receiver", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@UnloadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Goods", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Unit", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@FactDispatchCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactReceivedCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CompensationCosts", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MyCosts", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Haulway", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Formula", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CompanyPrice", SqlDbType.Decimal,9),
                        new SqlParameter("@DispatchCount", SqlDbType.Decimal,9),
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,254),
                        new SqlParameter("@OrderId", SqlDbType.Int,4)  
              
            };

            parameters[0].Value = model.TransportOrderId;
            parameters[1].Value = model.RoundStatus;
            parameters[2].Value = model.ContractNumber;
            parameters[3].Value = model.BillNumber;
            parameters[4].Value = model.Shipper;
            parameters[5].Value = model.Receiver;
            parameters[6].Value = model.LoadingAddress;
            parameters[7].Value = model.UnloadingAddress;
            parameters[8].Value = model.Goods;
            parameters[9].Value = model.Unit;
            parameters[10].Value = model.FactDispatchCount;
            parameters[11].Value = model.FactReceivedCount;
            parameters[12].Value = model.CompensationCosts;
            parameters[13].Value = model.MyCosts;
            parameters[14].Value = model.Haulway;
            parameters[15].Value = model.LoadingCapacityRunning;
            parameters[16].Value = model.NoLoadingCapacityRunning;
            parameters[17].Value = model.Formula;
            parameters[18].Value = model.UnitPrice;
            parameters[19].Value = model.TotalPrice;
            parameters[20].Value = model.CompanyPrice;
            parameters[21].Value = model.DispatchCount;
            parameters[22].Value = model.OrderCode;
            parameters[23].Value = model.OrderId;

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
        public bool Update(Model.TransportOrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_TransportOrderItem set ");

            strSql.Append(" TransportOrderId = @TransportOrderId , ");
            strSql.Append(" RoundStatus = @RoundStatus , ");
            strSql.Append(" ContractNumber = @ContractNumber , ");
            strSql.Append(" BillNumber = @BillNumber , ");
            strSql.Append(" Shipper = @Shipper , ");
            strSql.Append(" Receiver = @Receiver , ");
            strSql.Append(" LoadingAddress = @LoadingAddress , ");
            strSql.Append(" UnloadingAddress = @UnloadingAddress , ");
            strSql.Append(" Goods = @Goods , ");
            strSql.Append(" Unit = @Unit , ");
            strSql.Append(" FactDispatchCount = @FactDispatchCount , ");
            strSql.Append(" FactReceivedCount = @FactReceivedCount , ");
            strSql.Append(" CompensationCosts = @CompensationCosts , ");
            strSql.Append(" MyCosts = @MyCosts , ");
            strSql.Append(" Haulway = @Haulway , ");
            strSql.Append(" LoadingCapacityRunning = @LoadingCapacityRunning , ");
            strSql.Append(" NoLoadingCapacityRunning = @NoLoadingCapacityRunning , ");
            strSql.Append(" Formula = @Formula , ");
            strSql.Append(" UnitPrice = @UnitPrice , ");
            strSql.Append(" TotalPrice = @TotalPrice , ");
            strSql.Append(" CompanyPrice = @CompanyPrice,  ");
            strSql.Append(" OrderCode = @OrderCode,  ");
            strSql.Append(" OrderId = @OrderId  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@TransportOrderId", SqlDbType.Int,4) ,            
                        new SqlParameter("@RoundStatus", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ContractNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@BillNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Shipper", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Receiver", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@UnloadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Goods", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Unit", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@FactDispatchCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactReceivedCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CompensationCosts", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MyCosts", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Haulway", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Formula", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CompanyPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@OrderCode", SqlDbType.VarChar,254) ,
                        new SqlParameter("@OrderId", SqlDbType.Int,4) 
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.TransportOrderId;
            parameters[2].Value = model.RoundStatus;
            parameters[3].Value = model.ContractNumber;
            parameters[4].Value = model.BillNumber;
            parameters[5].Value = model.Shipper;
            parameters[6].Value = model.Receiver;
            parameters[7].Value = model.LoadingAddress;
            parameters[8].Value = model.UnloadingAddress;
            parameters[9].Value = model.Goods;
            parameters[10].Value = model.Unit;
            parameters[11].Value = model.FactDispatchCount;
            parameters[12].Value = model.FactReceivedCount;
            parameters[13].Value = model.CompensationCosts;
            parameters[14].Value = model.MyCosts;
            parameters[15].Value = model.Haulway;
            parameters[16].Value = model.LoadingCapacityRunning;
            parameters[17].Value = model.NoLoadingCapacityRunning;
            parameters[18].Value = model.Formula;
            parameters[19].Value = model.UnitPrice;
            parameters[20].Value = model.TotalPrice;
            parameters[21].Value = model.CompanyPrice;
            parameters[22].Value = model.OrderCode;
            parameters[23].Value = model.OrderId;

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

        public bool UpdateFactDispatchCount(int id, decimal factDispatchCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_TransportOrderItem set ");
            strSql.Append(" FactDispatchCount = @FactDispatchCount ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@FactDispatchCount", SqlDbType.Decimal,9)     
            };

            parameters[0].Value = id;
            parameters[1].Value = factDispatchCount;

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

        public bool UpdateExpensesInfo(Model.TransportOrderItem model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_TransportOrderItem set ");
            strSql.Append(" FactDispatchCount = @FactDispatchCount, ");
            strSql.Append(" FactReceivedCount = @FactReceivedCount, ");
            strSql.Append(" TotalPrice = @TotalPrice, ");
            strSql.Append(" RoundStatus = @RoundStatus ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@FactDispatchCount", SqlDbType.Decimal,9),
                        new SqlParameter("@FactReceivedCount", SqlDbType.Decimal,9) ,
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,
                        new SqlParameter("@RoundStatus", SqlDbType.VarChar,254) 
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.FactDispatchCount;
            parameters[2].Value = model.FactReceivedCount;
            parameters[3].Value = model.TotalPrice;
            parameters[4].Value = model.RoundStatus;

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
            strSql.Append("delete from mtms_TransportOrderItem ");
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

        public bool DeleteBy(int transportOrderId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from mtms_TransportOrderItem ");
            strSql.Append(" where TransportOrderId=@TransportOrderId");
            SqlParameter[] parameters = {
					new SqlParameter("@TransportOrderId", SqlDbType.Int,4)
			};
            parameters[0].Value = transportOrderId;


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
            strSql.Append("delete from mtms_TransportOrderItem ");
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
        public Model.TransportOrderItem GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, TransportOrderId, OrderId, OrderCode, RoundStatus, ContractNumber, BillNumber, Shipper, Receiver, LoadingAddress, UnloadingAddress, Goods, Unit, FactDispatchCount, FactReceivedCount, CompensationCosts, MyCosts, Haulway, LoadingCapacityRunning, NoLoadingCapacityRunning, Formula, UnitPrice, TotalPrice, CompanyPrice  ");
            strSql.Append("  from mtms_TransportOrderItem ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            Model.TransportOrderItem model = new Model.TransportOrderItem();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TransportOrderId"].ToString() != "")
                {
                    model.TransportOrderId = int.Parse(ds.Tables[0].Rows[0]["TransportOrderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderId"].ToString() != "")
                {
                    model.OrderId = int.Parse(ds.Tables[0].Rows[0]["OrderId"].ToString());
                }
                model.OrderCode = ds.Tables[0].Rows[0]["OrderCode"].ToString();
                model.RoundStatus = ds.Tables[0].Rows[0]["RoundStatus"].ToString();
                model.ContractNumber = ds.Tables[0].Rows[0]["ContractNumber"].ToString();
                model.BillNumber = ds.Tables[0].Rows[0]["BillNumber"].ToString();
                model.Shipper = ds.Tables[0].Rows[0]["Shipper"].ToString();
                model.Receiver = ds.Tables[0].Rows[0]["Receiver"].ToString();
                model.LoadingAddress = ds.Tables[0].Rows[0]["LoadingAddress"].ToString();
                model.UnloadingAddress = ds.Tables[0].Rows[0]["UnloadingAddress"].ToString();
                model.Goods = ds.Tables[0].Rows[0]["Goods"].ToString();
                model.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                if (ds.Tables[0].Rows[0]["FactDispatchCount"].ToString() != "")
                {
                    model.FactDispatchCount = decimal.Parse(ds.Tables[0].Rows[0]["FactDispatchCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactReceivedCount"].ToString() != "")
                {
                    model.FactReceivedCount = decimal.Parse(ds.Tables[0].Rows[0]["FactReceivedCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CompensationCosts"].ToString() != "")
                {
                    model.CompensationCosts = decimal.Parse(ds.Tables[0].Rows[0]["CompensationCosts"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MyCosts"].ToString() != "")
                {
                    model.MyCosts = decimal.Parse(ds.Tables[0].Rows[0]["MyCosts"].ToString());
                }
                model.Haulway = ds.Tables[0].Rows[0]["Haulway"].ToString();
                if (ds.Tables[0].Rows[0]["LoadingCapacityRunning"].ToString() != "")
                {
                    model.LoadingCapacityRunning = decimal.Parse(ds.Tables[0].Rows[0]["LoadingCapacityRunning"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NoLoadingCapacityRunning"].ToString() != "")
                {
                    model.NoLoadingCapacityRunning = decimal.Parse(ds.Tables[0].Rows[0]["NoLoadingCapacityRunning"].ToString());
                }
                model.Formula = ds.Tables[0].Rows[0]["Formula"].ToString();
                if (ds.Tables[0].Rows[0]["UnitPrice"].ToString() != "")
                {
                    model.UnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalPrice"].ToString() != "")
                {
                    model.TotalPrice = decimal.Parse(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CompanyPrice"].ToString() != "")
                {
                    model.CompanyPrice = decimal.Parse(ds.Tables[0].Rows[0]["CompanyPrice"].ToString());
                }

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
            strSql.Append(" FROM mtms_TransportOrderItem ");
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
            strSql.Append(" FROM mtms_TransportOrderItem ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


    }
}
