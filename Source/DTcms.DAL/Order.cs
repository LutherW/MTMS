using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class Order
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from mtms_Order");
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
        public int Add(Model.Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into mtms_Order(");
            strSql.Append("Code,AcceptOrderTime,ArrivedTime,Shipper,ShipperLinkMan,ShipperLinkTel,Receiver,ReceiverLinkMan,ReceiverLinkTel,ContractNumber,LoadingAddress,UnloadingAddress,Goods,Unit,IsCharteredCar,Quantity,DispatchedCount,Haulway,LoadingCapacityRunning,NoLoadingCapacityRunning,BillNumber,WeighbridgeNumber,Formula,UnitPrice,TotalPrice,SettleAccountsWay,Status,Remarks");
            strSql.Append(") values (");
            strSql.Append("@Code,@AcceptOrderTime,@ArrivedTime,@Shipper,@ShipperLinkMan,@ShipperLinkTel,@Receiver,@ReceiverLinkMan,@ReceiverLinkTel,@ContractNumber,@LoadingAddress,@UnloadingAddress,@Goods,@Unit,@IsCharteredCar,@Quantity,@DispatchedCount,@Haulway,@LoadingCapacityRunning,@NoLoadingCapacityRunning,@BillNumber,@WeighbridgeNumber,@Formula,@UnitPrice,@TotalPrice,@SettleAccountsWay,@Status,@Remarks");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@AcceptOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ArrivedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Shipper", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ShipperLinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ShipperLinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Receiver", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ReceiverLinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ReceiverLinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ContractNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@UnloadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Goods", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Unit", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@IsCharteredCar", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("@Quantity", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DispatchedCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Haulway", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BillNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@WeighbridgeNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Formula", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SettleAccountsWay", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Code;
            parameters[1].Value = model.AcceptOrderTime;
            parameters[2].Value = model.ArrivedTime;
            parameters[3].Value = model.Shipper;
            parameters[4].Value = model.ShipperLinkMan;
            parameters[5].Value = model.ShipperLinkTel;
            parameters[6].Value = model.Receiver;
            parameters[7].Value = model.ReceiverLinkMan;
            parameters[8].Value = model.ReceiverLinkTel;
            parameters[9].Value = model.ContractNumber;
            parameters[10].Value = model.LoadingAddress;
            parameters[11].Value = model.UnloadingAddress;
            parameters[12].Value = model.Goods;
            parameters[13].Value = model.Unit;
            parameters[14].Value = model.IsCharteredCar;
            parameters[15].Value = model.Quantity;
            parameters[16].Value = model.DispatchedCount;
            parameters[17].Value = model.Haulway;
            parameters[18].Value = model.LoadingCapacityRunning;
            parameters[19].Value = model.NoLoadingCapacityRunning;
            parameters[20].Value = model.BillNumber;
            parameters[21].Value = model.WeighbridgeNumber;
            parameters[22].Value = model.Formula;
            parameters[23].Value = model.UnitPrice;
            parameters[24].Value = model.TotalPrice;
            parameters[25].Value = model.SettleAccountsWay;
            parameters[26].Value = model.Status;
            parameters[27].Value = model.Remarks;

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
        public bool Update(Model.Order model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_Order set ");

            strSql.Append(" Code = @Code , ");
            strSql.Append(" AcceptOrderTime = @AcceptOrderTime , ");
            strSql.Append(" ArrivedTime = @ArrivedTime , ");
            strSql.Append(" Shipper = @Shipper , ");
            strSql.Append(" ShipperLinkMan = @ShipperLinkMan , ");
            strSql.Append(" ShipperLinkTel = @ShipperLinkTel , ");
            strSql.Append(" Receiver = @Receiver , ");
            strSql.Append(" ReceiverLinkMan = @ReceiverLinkMan , ");
            strSql.Append(" ReceiverLinkTel = @ReceiverLinkTel , ");
            strSql.Append(" ContractNumber = @ContractNumber , ");
            strSql.Append(" LoadingAddress = @LoadingAddress , ");
            strSql.Append(" UnloadingAddress = @UnloadingAddress , ");
            strSql.Append(" Goods = @Goods , ");
            strSql.Append(" Unit = @Unit , ");
            strSql.Append(" IsCharteredCar = @IsCharteredCar , ");
            strSql.Append(" Quantity = @Quantity , ");
            strSql.Append(" DispatchedCount = @DispatchedCount , ");
            strSql.Append(" Haulway = @Haulway , ");
            strSql.Append(" LoadingCapacityRunning = @LoadingCapacityRunning , ");
            strSql.Append(" NoLoadingCapacityRunning = @NoLoadingCapacityRunning , ");
            strSql.Append(" BillNumber = @BillNumber , ");
            strSql.Append(" WeighbridgeNumber = @WeighbridgeNumber , ");
            strSql.Append(" Formula = @Formula , ");
            strSql.Append(" UnitPrice = @UnitPrice , ");
            strSql.Append(" TotalPrice = @TotalPrice , ");
            strSql.Append(" SettleAccountsWay = @SettleAccountsWay , ");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" Remarks = @Remarks  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@AcceptOrderTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ArrivedTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Shipper", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ShipperLinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ShipperLinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Receiver", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ReceiverLinkMan", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ReceiverLinkTel", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@ContractNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@UnloadingAddress", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Goods", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Unit", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@IsCharteredCar", SqlDbType.SmallInt,2) ,            
                        new SqlParameter("@Quantity", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DispatchedCount", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Haulway", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@LoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@NoLoadingCapacityRunning", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BillNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@WeighbridgeNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Formula", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@UnitPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SettleAccountsWay", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.AcceptOrderTime;
            parameters[3].Value = model.ArrivedTime;
            parameters[4].Value = model.Shipper;
            parameters[5].Value = model.ShipperLinkMan;
            parameters[6].Value = model.ShipperLinkTel;
            parameters[7].Value = model.Receiver;
            parameters[8].Value = model.ReceiverLinkMan;
            parameters[9].Value = model.ReceiverLinkTel;
            parameters[10].Value = model.ContractNumber;
            parameters[11].Value = model.LoadingAddress;
            parameters[12].Value = model.UnloadingAddress;
            parameters[13].Value = model.Goods;
            parameters[14].Value = model.Unit;
            parameters[15].Value = model.IsCharteredCar;
            parameters[16].Value = model.Quantity;
            parameters[17].Value = model.DispatchedCount;
            parameters[18].Value = model.Haulway;
            parameters[19].Value = model.LoadingCapacityRunning;
            parameters[20].Value = model.NoLoadingCapacityRunning;
            parameters[21].Value = model.BillNumber;
            parameters[22].Value = model.WeighbridgeNumber;
            parameters[23].Value = model.Formula;
            parameters[24].Value = model.UnitPrice;
            parameters[25].Value = model.TotalPrice;
            parameters[26].Value = model.SettleAccountsWay;
            parameters[27].Value = model.Status;
            parameters[28].Value = model.Remarks;
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

        public bool AddDispatchCount(int id, decimal dispatchCount, int status)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_Order set ");
            strSql.Append(" Status = @Status, ");

            //strSql.Append(" DispatchedCount += @DispatchCount ");

            strSql.Append(" DispatchedCount =DispatchedCount+ @DispatchCount ");

            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@DispatchCount", SqlDbType.Decimal,9),       
                        new SqlParameter("@Status", SqlDbType.Int,4)  
            };

            parameters[0].Value = id;
            parameters[1].Value = dispatchCount;
            parameters[2].Value = status;

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
            strSql.Append("delete from mtms_Order ");
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
            strSql.Append("delete from mtms_Order ");
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
        public Model.Order GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Code, AcceptOrderTime, ArrivedTime, Shipper, ShipperLinkMan, ShipperLinkTel, Receiver, ReceiverLinkMan, ReceiverLinkTel, ContractNumber, LoadingAddress, UnloadingAddress, Goods, Unit, IsCharteredCar, Quantity, DispatchedCount, Haulway, LoadingCapacityRunning, NoLoadingCapacityRunning, BillNumber, WeighbridgeNumber, Formula, UnitPrice, TotalPrice, SettleAccountsWay, Status, Remarks  ");
            strSql.Append("  from mtms_Order ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            Model.Order model = new Model.Order();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                if (ds.Tables[0].Rows[0]["AcceptOrderTime"].ToString() != "")
                {
                    model.AcceptOrderTime = DateTime.Parse(ds.Tables[0].Rows[0]["AcceptOrderTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ArrivedTime"].ToString() != "")
                {
                    model.ArrivedTime = DateTime.Parse(ds.Tables[0].Rows[0]["ArrivedTime"].ToString());
                }
                model.Shipper = ds.Tables[0].Rows[0]["Shipper"].ToString();
                model.ShipperLinkMan = ds.Tables[0].Rows[0]["ShipperLinkMan"].ToString();
                model.ShipperLinkTel = ds.Tables[0].Rows[0]["ShipperLinkTel"].ToString();
                model.Receiver = ds.Tables[0].Rows[0]["Receiver"].ToString();
                model.ReceiverLinkMan = ds.Tables[0].Rows[0]["ReceiverLinkMan"].ToString();
                model.ReceiverLinkTel = ds.Tables[0].Rows[0]["ReceiverLinkTel"].ToString();
                model.ContractNumber = ds.Tables[0].Rows[0]["ContractNumber"].ToString();
                model.LoadingAddress = ds.Tables[0].Rows[0]["LoadingAddress"].ToString();
                model.UnloadingAddress = ds.Tables[0].Rows[0]["UnloadingAddress"].ToString();
                model.Goods = ds.Tables[0].Rows[0]["Goods"].ToString();
                model.Unit = ds.Tables[0].Rows[0]["Unit"].ToString();
                if (ds.Tables[0].Rows[0]["IsCharteredCar"].ToString() != "")
                {
                    model.IsCharteredCar = int.Parse(ds.Tables[0].Rows[0]["IsCharteredCar"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Quantity"].ToString() != "")
                {
                    model.Quantity = decimal.Parse(ds.Tables[0].Rows[0]["Quantity"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DispatchedCount"].ToString() != "")
                {
                    model.DispatchedCount = decimal.Parse(ds.Tables[0].Rows[0]["DispatchedCount"].ToString());
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
                model.BillNumber = ds.Tables[0].Rows[0]["BillNumber"].ToString();
                model.WeighbridgeNumber = ds.Tables[0].Rows[0]["WeighbridgeNumber"].ToString();
                model.Formula = ds.Tables[0].Rows[0]["Formula"].ToString();
                if (ds.Tables[0].Rows[0]["UnitPrice"].ToString() != "")
                {
                    model.UnitPrice = decimal.Parse(ds.Tables[0].Rows[0]["UnitPrice"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalPrice"].ToString() != "")
                {
                    model.TotalPrice = decimal.Parse(ds.Tables[0].Rows[0]["TotalPrice"].ToString());
                }
                model.SettleAccountsWay = ds.Tables[0].Rows[0]["SettleAccountsWay"].ToString();
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
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
            strSql.Append(" FROM mtms_Order ");
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
            strSql.Append(" FROM mtms_Order ");
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
            strSql.Append("select * FROM mtms_Order");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}
