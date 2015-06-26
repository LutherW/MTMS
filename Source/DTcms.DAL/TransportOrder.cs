using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class TransportOrder
    {

        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from mtms_TransportOrder");
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
        public int Add(Model.TransportOrder model, List<Model.TransportOrderItem> item_list, List<Model.Order> order_list)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into mtms_TransportOrder(");
            strSql.Append("Code,DispatchTime,FactDispatchTime,TimeLimit,BackTime,FactBackTime,MotorcadeName,CarNumber,Trailer,Driver,Advance,Payee,Repayment,FactRepayment,Percentage,Carriage,FactCarriage,CostTotal,Profit,AddTime,Status,Remarks");
            strSql.Append(") values (");
            strSql.Append("@Code,@DispatchTime,@FactDispatchTime,@TimeLimit,@BackTime,@FactBackTime,@MotorcadeName,@CarNumber,@Trailer,@Driver,@Advance,@Payee,@Repayment,@FactRepayment,@Percentage,@Carriage,@FactCarriage,@CostTotal,@Profit,@AddTime,@Status,@Remarks");
            strSql.Append(") ");
            strSql.Append(";set @ReturnValue= @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@DispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactDispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@TimeLimit", SqlDbType.Int,4) ,            
                        new SqlParameter("@BackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactBackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@MotorcadeName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CarNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Trailer", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Driver", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Advance", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Payee", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Repayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactRepayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Percentage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Carriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactCarriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CostTotal", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Profit", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254),
                    new SqlParameter("@ReturnValue",SqlDbType.Int)};

            parameters[0].Value = model.Code;
            parameters[1].Value = model.DispatchTime;
            parameters[2].Value = null;
            parameters[3].Value = model.TimeLimit;
            parameters[4].Value = model.BackTime;
            parameters[5].Value = null;
            parameters[6].Value = model.MotorcadeName;
            parameters[7].Value = model.CarNumber;
            parameters[8].Value = model.Trailer;
            parameters[9].Value = model.Driver;
            parameters[10].Value = model.Advance;
            parameters[11].Value = model.Payee;
            parameters[12].Value = model.Repayment;
            parameters[13].Value = model.FactRepayment;
            parameters[14].Value = model.Percentage;
            parameters[15].Value = model.Carriage;
            parameters[16].Value = model.FactCarriage;
            parameters[17].Value = model.CostTotal;
            parameters[18].Value = model.Profit;
            parameters[19].Value = DateTime.Now;
            parameters[20].Value = model.Status;
            parameters[21].Value = model.Remarks;
            parameters[22].Direction = ParameterDirection.Output;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            //运输子项
            if (item_list != null)
            {
                foreach (Model.TransportOrderItem modelt in item_list)
                {
                    StringBuilder strSql1 = new StringBuilder();
                    strSql1.Append("insert into mtms_TransportOrderItem(");
                    strSql1.Append("TransportOrderId,RoundStatus,ContractNumber,BillNumber,Shipper,Receiver,LoadingAddress,UnloadingAddress,Goods,Unit,FactDispatchCount,FactReceivedCount,CompensationCosts,MyCosts,Haulway,LoadingCapacityRunning,NoLoadingCapacityRunning,Formula,UnitPrice,TotalPrice,CompanyPrice,DispatchCount,OrderCode,OrderId");
                    strSql1.Append(") values (");
                    strSql1.Append("@TransportOrderId,@RoundStatus,@ContractNumber,@BillNumber,@Shipper,@Receiver,@LoadingAddress,@UnloadingAddress,@Goods,@Unit,@FactDispatchCount,@FactReceivedCount,@CompensationCosts,@MyCosts,@Haulway,@LoadingCapacityRunning,@NoLoadingCapacityRunning,@Formula,@UnitPrice,@TotalPrice,@CompanyPrice,@DispatchCount,@OrderCode,@OrderId");
                    strSql1.Append(") ");
                    SqlParameter[] parameters1 = {
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
                        new SqlParameter("@OrderId", SqlDbType.Int,4)};

                    parameters1[0].Direction = ParameterDirection.InputOutput;
                    parameters1[1].Value = modelt.RoundStatus;
                    parameters1[2].Value = modelt.ContractNumber;
                    parameters1[3].Value = modelt.BillNumber;
                    parameters1[4].Value = modelt.Shipper;
                    parameters1[5].Value = modelt.Receiver;
                    parameters1[6].Value = modelt.LoadingAddress;
                    parameters1[7].Value = modelt.UnloadingAddress;
                    parameters1[8].Value = modelt.Goods;
                    parameters1[9].Value = modelt.Unit;
                    parameters1[10].Value = modelt.FactDispatchCount;
                    parameters1[11].Value = modelt.FactReceivedCount;
                    parameters1[12].Value = modelt.CompensationCosts;
                    parameters1[13].Value = modelt.MyCosts;
                    parameters1[14].Value = modelt.Haulway;
                    parameters1[15].Value = modelt.LoadingCapacityRunning;
                    parameters1[16].Value = modelt.NoLoadingCapacityRunning;
                    parameters1[17].Value = modelt.Formula;
                    parameters1[18].Value = modelt.UnitPrice;
                    parameters1[19].Value = modelt.TotalPrice;
                    parameters1[20].Value = modelt.CompanyPrice;
                    parameters1[21].Value = modelt.DispatchCount;
                    parameters1[22].Value = modelt.OrderCode;
                    parameters1[23].Value = modelt.OrderId;

                    cmd = new CommandInfo(strSql1.ToString(), parameters1);
                    sqllist.Add(cmd);
                }
            }
            //订单
            if (order_list != null)
            {
                foreach (Model.Order modelt in order_list)
                {
                    StringBuilder strSql2 = new StringBuilder();
                    strSql2.Append("update mtms_Order set ");
                    strSql2.Append(" Status=@Status,");
                    strSql2.Append(" DispatchedCount=@DispatchCount ");
                    strSql2.Append(" where Id=@Id ");
                    SqlParameter[] parameters2 = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@DispatchCount", SqlDbType.Decimal,9),       
                        new SqlParameter("@Status", SqlDbType.Int,4)};

                    parameters2[0].Value = modelt.Id;
                    parameters2[1].Value = modelt.DispatchedCount;
                    parameters2[2].Value = modelt.Status;

                    cmd = new CommandInfo(strSql2.ToString(), parameters2);
                    sqllist.Add(cmd);
                }
            }

            DbHelperSQL.ExecuteSqlTranWithIndentity(sqllist);
            return (int)parameters[22].Value;
        }
        //更新
        public bool Update(Model.TransportOrder model, List<Model.TransportOrderItem> Item_list)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update mtms_TransportOrder set ");

                        strSql.Append(" Code = @Code , ");
                        strSql.Append(" DispatchTime = @DispatchTime , ");
                        strSql.Append(" FactDispatchTime = @FactDispatchTime , ");
                        strSql.Append(" TimeLimit = @TimeLimit , ");
                        strSql.Append(" BackTime = @BackTime , ");
                        strSql.Append(" FactBackTime = @FactBackTime , ");
                        strSql.Append(" MotorcadeName = @MotorcadeName , ");
                        strSql.Append(" CarNumber = @CarNumber , ");
                        strSql.Append(" Trailer = @Trailer , ");
                        strSql.Append(" Driver = @Driver , ");
                        strSql.Append(" Advance = @Advance , ");
                        strSql.Append(" Payee = @Payee , ");
                        strSql.Append(" Repayment = @Repayment , ");
                        strSql.Append(" FactRepayment = @FactRepayment , ");
                        strSql.Append(" Percentage = @Percentage , ");
                        strSql.Append(" Carriage = @Carriage , ");
                        strSql.Append(" FactCarriage = @FactCarriage , ");
                        strSql.Append(" CostTotal = @CostTotal , ");
                        strSql.Append(" Profit = @Profit , ");
                        strSql.Append(" AddTime = @AddTime , ");
                        strSql.Append(" Status = @Status , ");
                        strSql.Append(" WarningTime = @WarningTime , ");
                        strSql.Append(" Remarks = @Remarks  ");
                        strSql.Append(" where Id=@Id ");

                        SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@DispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactDispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@TimeLimit", SqlDbType.Int,4) ,            
                        new SqlParameter("@BackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactBackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@MotorcadeName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CarNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Trailer", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Driver", SqlDbType.VarChar,254) ,            
       
                        new SqlParameter("@Advance", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Payee", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Repayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactRepayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Percentage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Carriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactCarriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CostTotal", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Profit", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,             
                        new SqlParameter("@WarningTime", SqlDbType.DateTime) ,           
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)};

                        parameters[0].Value = model.Id;
                        parameters[1].Value = model.Code;
                        parameters[2].Value = model.DispatchTime;
                        parameters[3].Value = model.FactDispatchTime;
                        parameters[4].Value = model.TimeLimit;
                        parameters[5].Value = model.BackTime;
                        parameters[6].Value = model.FactBackTime;
                        parameters[7].Value = model.MotorcadeName;
                        parameters[8].Value = model.CarNumber;
                        parameters[9].Value = model.Trailer;
                        parameters[10].Value = model.Driver;
                        parameters[11].Value = model.Advance;
                        parameters[12].Value = model.Payee;
                        parameters[13].Value = model.Repayment;
                        parameters[14].Value = model.FactRepayment;
                        parameters[15].Value = model.Percentage;
                        parameters[16].Value = model.Carriage;
                        parameters[17].Value = model.FactCarriage;
                        parameters[18].Value = model.CostTotal;
                        parameters[19].Value = model.Profit;
                        parameters[20].Value = model.AddTime;
                        parameters[21].Value = model.Status;
                        parameters[22].Value = model.WarningTime;
                        parameters[23].Value = model.Remarks;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        
                        if (Item_list != null)
                        {
                            foreach (Model.TransportOrderItem modelt in Item_list)
                            {
                                StringBuilder strSql1 = new StringBuilder();
                                strSql1.Append("update mtms_TransportOrderItem set ");

                                strSql1.Append(" TransportOrderId = @TransportOrderId , ");
                                strSql1.Append(" RoundStatus = @RoundStatus , ");
                                strSql1.Append(" ContractNumber = @ContractNumber , ");
                                strSql1.Append(" BillNumber = @BillNumber , ");
                                strSql1.Append(" Shipper = @Shipper , ");
                                strSql1.Append(" Receiver = @Receiver , ");
                                strSql1.Append(" LoadingAddress = @LoadingAddress , ");
                                strSql1.Append(" UnloadingAddress = @UnloadingAddress , ");
                                strSql1.Append(" Goods = @Goods , ");
                                strSql1.Append(" Unit = @Unit , ");
                                strSql1.Append(" FactDispatchCount = @FactDispatchCount , ");
                                strSql1.Append(" FactReceivedCount = @FactReceivedCount , ");
                                strSql1.Append(" CompensationCosts = @CompensationCosts , ");
                                strSql1.Append(" MyCosts = @MyCosts , ");
                                strSql1.Append(" Haulway = @Haulway , ");
                                strSql1.Append(" LoadingCapacityRunning = @LoadingCapacityRunning , ");
                                strSql1.Append(" NoLoadingCapacityRunning = @NoLoadingCapacityRunning , ");
                                strSql1.Append(" Formula = @Formula , ");
                                strSql1.Append(" UnitPrice = @UnitPrice , ");
                                strSql1.Append(" TotalPrice = @TotalPrice , ");
                                strSql1.Append(" CompanyPrice = @CompanyPrice,  ");
                                strSql1.Append(" OrderCode = @OrderCode,  ");
                                strSql1.Append(" OrderId = @OrderId  ");
                                strSql1.Append(" where Id=@Id ");

                                SqlParameter[] parameters1 = {
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
                        new SqlParameter("@OrderId", SqlDbType.Int,4)};

                                parameters1[0].Value = modelt.Id;
                                parameters1[1].Value = modelt.TransportOrderId;
                                parameters1[2].Value = modelt.RoundStatus;
                                parameters1[3].Value = modelt.ContractNumber;
                                parameters1[4].Value = modelt.BillNumber;
                                parameters1[5].Value = modelt.Shipper;
                                parameters1[6].Value = modelt.Receiver;
                                parameters1[7].Value = modelt.LoadingAddress;
                                parameters1[8].Value = modelt.UnloadingAddress;
                                parameters1[9].Value = modelt.Goods;
                                parameters1[10].Value = modelt.Unit;
                                parameters1[11].Value = modelt.FactDispatchCount;
                                parameters1[12].Value = modelt.FactReceivedCount;
                                parameters1[13].Value = modelt.CompensationCosts;
                                parameters1[14].Value = modelt.MyCosts;
                                parameters1[15].Value = modelt.Haulway;
                                parameters1[16].Value = modelt.LoadingCapacityRunning;
                                parameters1[17].Value = modelt.NoLoadingCapacityRunning;
                                parameters1[18].Value = modelt.Formula;
                                parameters1[19].Value = modelt.UnitPrice;
                                parameters1[20].Value = modelt.TotalPrice;
                                parameters1[21].Value = modelt.CompanyPrice;
                                parameters1[22].Value = modelt.OrderCode;
                                parameters1[23].Value = modelt.OrderId;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString(), parameters1);
                            }
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }
        //更新
        public bool Update(Model.TransportOrder model, List<Model.TransportOrderItem> Item_list,List<Model.Consumption> consumption_list)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update mtms_TransportOrder set ");

                        strSql.Append(" Code = @Code , ");
                        strSql.Append(" DispatchTime = @DispatchTime , ");
                        strSql.Append(" FactDispatchTime = @FactDispatchTime , ");
                        strSql.Append(" TimeLimit = @TimeLimit , ");
                        strSql.Append(" BackTime = @BackTime , ");
                        strSql.Append(" FactBackTime = @FactBackTime , ");
                        strSql.Append(" MotorcadeName = @MotorcadeName , ");
                        strSql.Append(" CarNumber = @CarNumber , ");
                        strSql.Append(" Trailer = @Trailer , ");
                        strSql.Append(" Driver = @Driver , ");
                        strSql.Append(" Advance = @Advance , ");
                        strSql.Append(" Payee = @Payee , ");
                        strSql.Append(" Repayment = @Repayment , ");
                        strSql.Append(" FactRepayment = @FactRepayment , ");
                        strSql.Append(" Percentage = @Percentage , ");
                        strSql.Append(" Carriage = @Carriage , ");
                        strSql.Append(" FactCarriage = @FactCarriage , ");
                        strSql.Append(" CostTotal = @CostTotal , ");
                        strSql.Append(" Profit = @Profit , ");
                        strSql.Append(" AddTime = @AddTime , ");
                        strSql.Append(" Status = @Status , ");
                        strSql.Append(" WarningTime = @WarningTime , ");
                        strSql.Append(" Remarks = @Remarks  ");
                        strSql.Append(" where Id=@Id ");

                        SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@DispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactDispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@TimeLimit", SqlDbType.Int,4) ,            
                        new SqlParameter("@BackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactBackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@MotorcadeName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CarNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Trailer", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Driver", SqlDbType.VarChar,254) ,            
       
                        new SqlParameter("@Advance", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Payee", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Repayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactRepayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Percentage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Carriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactCarriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CostTotal", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Profit", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,          
                        new SqlParameter("@WarningTime", SqlDbType.DateTime) ,           
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)};

                        parameters[0].Value = model.Id;
                        parameters[1].Value = model.Code;
                        parameters[2].Value = model.DispatchTime;
                        parameters[3].Value = model.FactDispatchTime;
                        parameters[4].Value = model.TimeLimit;
                        parameters[5].Value = model.BackTime;
                        parameters[6].Value = model.FactBackTime;
                        parameters[7].Value = model.MotorcadeName;
                        parameters[8].Value = model.CarNumber;
                        parameters[9].Value = model.Trailer;
                        parameters[10].Value = model.Driver;
                        parameters[11].Value = model.Advance;
                        parameters[12].Value = model.Payee;
                        parameters[13].Value = model.Repayment;
                        parameters[14].Value = model.FactRepayment;
                        parameters[15].Value = model.Percentage;
                        parameters[16].Value = model.Carriage;
                        parameters[17].Value = model.FactCarriage;
                        parameters[18].Value = model.CostTotal;
                        parameters[19].Value = model.Profit;
                        parameters[20].Value = model.AddTime;
                        parameters[21].Value = model.Status;
                        parameters[22].Value = model.WarningTime;
                        parameters[23].Value = model.Remarks;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);
                        
                        if (Item_list != null)
                        {
                            foreach (Model.TransportOrderItem modelt in Item_list)
                            {
                                StringBuilder strSql1 = new StringBuilder();
                                strSql1.Append("update mtms_TransportOrderItem set ");

                                strSql1.Append(" TransportOrderId = @TransportOrderId , ");
                                strSql1.Append(" RoundStatus = @RoundStatus , ");
                                strSql1.Append(" ContractNumber = @ContractNumber , ");
                                strSql1.Append(" BillNumber = @BillNumber , ");
                                strSql1.Append(" Shipper = @Shipper , ");
                                strSql1.Append(" Receiver = @Receiver , ");
                                strSql1.Append(" LoadingAddress = @LoadingAddress , ");
                                strSql1.Append(" UnloadingAddress = @UnloadingAddress , ");
                                strSql1.Append(" Goods = @Goods , ");
                                strSql1.Append(" Unit = @Unit , ");
                                strSql1.Append(" FactDispatchCount = @FactDispatchCount , ");
                                strSql1.Append(" FactReceivedCount = @FactReceivedCount , ");
                                strSql1.Append(" CompensationCosts = @CompensationCosts , ");
                                strSql1.Append(" MyCosts = @MyCosts , ");
                                strSql1.Append(" Haulway = @Haulway , ");
                                strSql1.Append(" LoadingCapacityRunning = @LoadingCapacityRunning , ");
                                strSql1.Append(" NoLoadingCapacityRunning = @NoLoadingCapacityRunning , ");
                                strSql1.Append(" Formula = @Formula , ");
                                strSql1.Append(" UnitPrice = @UnitPrice , ");
                                strSql1.Append(" TotalPrice = @TotalPrice , ");
                                strSql1.Append(" CompanyPrice = @CompanyPrice,  ");
                                strSql1.Append(" OrderCode = @OrderCode , ");
                                strSql1.Append(" OrderId = @OrderId  ");
                                strSql1.Append(" where Id=@Id ");

                                SqlParameter[] parameters1 = {
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
                        new SqlParameter("@OrderId", SqlDbType.Int,4)};

                                parameters1[0].Value = modelt.Id;
                                parameters1[1].Value = modelt.TransportOrderId;
                                parameters1[2].Value = modelt.RoundStatus;
                                parameters1[3].Value = modelt.ContractNumber;
                                parameters1[4].Value = modelt.BillNumber;
                                parameters1[5].Value = modelt.Shipper;
                                parameters1[6].Value = modelt.Receiver;
                                parameters1[7].Value = modelt.LoadingAddress;
                                parameters1[8].Value = modelt.UnloadingAddress;
                                parameters1[9].Value = modelt.Goods;
                                parameters1[10].Value = modelt.Unit;
                                parameters1[11].Value = modelt.FactDispatchCount;
                                parameters1[12].Value = modelt.FactReceivedCount;
                                parameters1[13].Value = modelt.CompensationCosts;
                                parameters1[14].Value = modelt.MyCosts;
                                parameters1[15].Value = modelt.Haulway;
                                parameters1[16].Value = modelt.LoadingCapacityRunning;
                                parameters1[17].Value = modelt.NoLoadingCapacityRunning;
                                parameters1[18].Value = modelt.Formula;
                                parameters1[19].Value = modelt.UnitPrice;
                                parameters1[20].Value = modelt.TotalPrice;
                                parameters1[21].Value = modelt.CompanyPrice;
                                parameters1[22].Value = modelt.OrderCode;
                                parameters1[23].Value = modelt.OrderId;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql1.ToString(), parameters1);
                            }
                        }

                        if (consumption_list != null)
                        {
                            foreach (Model.Consumption modelt in consumption_list)
                            {
                                StringBuilder strSql2 = new StringBuilder();
                                strSql2.Append("insert into mtms_Consumption(");
                                strSql2.Append("Name,TransportOrderId,Money");
                                strSql2.Append(") values (");
                                strSql2.Append("@Name,@TransportOrderId,@Money");
                                strSql2.Append(") ");
                                SqlParameter[] parameters2 = {
			                        new SqlParameter("@Name", SqlDbType.VarChar,254) ,            
                                    new SqlParameter("@TransportOrderId", SqlDbType.Int,4) ,            
                                    new SqlParameter("@Money", SqlDbType.Decimal,9)};

                                parameters2[0].Value = modelt.Name;
                                parameters2[1].Value = modelt.TransportOrderId;
                                parameters2[2].Value = modelt.Money;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                            }
                        }

                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.TransportOrder model, List<Model.TransportOrderItem> item_list, List<Model.Order> order_list)
        {
            using (SqlConnection conn = new SqlConnection(DbHelperSQL.connectionString))
            {
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("update mtms_TransportOrder set ");
                        strSql.Append(" Code = @Code , ");
                        strSql.Append(" DispatchTime = @DispatchTime , ");
                        strSql.Append(" FactDispatchTime = @FactDispatchTime , ");
                        strSql.Append(" TimeLimit = @TimeLimit , ");
                        strSql.Append(" BackTime = @BackTime , ");
                        strSql.Append(" FactBackTime = @FactBackTime , ");
                        strSql.Append(" MotorcadeName = @MotorcadeName , ");
                        strSql.Append(" CarNumber = @CarNumber , ");
                        strSql.Append(" Trailer = @Trailer , ");
                        strSql.Append(" Driver = @Driver , ");
                        strSql.Append(" Advance = @Advance , ");
                        strSql.Append(" Payee = @Payee , ");
                        strSql.Append(" Repayment = @Repayment , ");
                        strSql.Append(" FactRepayment = @FactRepayment , ");
                        strSql.Append(" Percentage = @Percentage , ");
                        strSql.Append(" Carriage = @Carriage , ");
                        strSql.Append(" FactCarriage = @FactCarriage , ");
                        strSql.Append(" CostTotal = @CostTotal , ");
                        strSql.Append(" Profit = @Profit , ");
                        strSql.Append(" AddTime = @AddTime , ");
                        strSql.Append(" Status = @Status , ");
                        strSql.Append(" WarningTime = @WarningTime , ");
                        strSql.Append(" Remarks = @Remarks  ");
                        strSql.Append(" where Id=@Id ");
                        SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@DispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactDispatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@TimeLimit", SqlDbType.Int,4) ,            
                        new SqlParameter("@BackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FactBackTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@MotorcadeName", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@CarNumber", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Trailer", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Driver", SqlDbType.VarChar,254) , 
                        new SqlParameter("@Advance", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Payee", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Repayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactRepayment", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Percentage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Carriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FactCarriage", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@CostTotal", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Profit", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@AddTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Status", SqlDbType.Int,4) ,          
                        new SqlParameter("@WarningTime", SqlDbType.DateTime) ,          
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)};
                        parameters[0].Value = model.Id;
                        parameters[1].Value = model.Code;
                        parameters[2].Value = model.DispatchTime;
                        parameters[3].Value = model.FactDispatchTime;
                        parameters[4].Value = model.TimeLimit;
                        parameters[5].Value = model.BackTime;
                        parameters[6].Value = model.FactBackTime;
                        parameters[7].Value = model.MotorcadeName;
                        parameters[8].Value = model.CarNumber;
                        parameters[9].Value = model.Trailer;
                        parameters[10].Value = model.Driver;
                        parameters[11].Value = model.Advance;
                        parameters[12].Value = model.Payee;
                        parameters[13].Value = model.Repayment;
                        parameters[14].Value = model.FactRepayment;
                        parameters[15].Value = model.Percentage;
                        parameters[16].Value = model.Carriage;
                        parameters[17].Value = model.FactCarriage;
                        parameters[18].Value = model.CostTotal;
                        parameters[19].Value = model.Profit;
                        parameters[20].Value = model.AddTime;
                        parameters[21].Value = model.Status;
                        parameters[22].Value = model.WarningTime;
                        parameters[23].Value = model.Remarks;
                        DbHelperSQL.ExecuteSql(conn, trans, strSql.ToString(), parameters);

                        //删除运输子单
                        new TransportOrderItem().DeleteBy(model.Id);

                        //添加运输子单 List<Model.TransportOrderItem> item_list
                        if (item_list != null)
                        {
                            StringBuilder strSql2;
                            foreach (Model.TransportOrderItem modelt in item_list)
                            {
                                strSql2 = new StringBuilder();
                                strSql2.Append("insert into mtms_TransportOrderItem(");
                                strSql2.Append("TransportOrderId,RoundStatus,ContractNumber,BillNumber,Shipper,Receiver,LoadingAddress,UnloadingAddress,Goods,Unit,FactDispatchCount,FactReceivedCount,CompensationCosts,MyCosts,Haulway,LoadingCapacityRunning,NoLoadingCapacityRunning,Formula,UnitPrice,TotalPrice,CompanyPrice,DispatchCount,OrderCode,OrderId");
                                strSql2.Append(") values (");
                                strSql2.Append("@TransportOrderId,@RoundStatus,@ContractNumber,@BillNumber,@Shipper,@Receiver,@LoadingAddress,@UnloadingAddress,@Goods,@Unit,@FactDispatchCount,@FactReceivedCount,@CompensationCosts,@MyCosts,@Haulway,@LoadingCapacityRunning,@NoLoadingCapacityRunning,@Formula,@UnitPrice,@TotalPrice,@CompanyPrice,@DispatchCount,@OrderCode,@OrderId");
                                strSql2.Append(") ");
                                SqlParameter[] parameters2 = {
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
                                                new SqlParameter("@OrderId", SqlDbType.Int,4)};

                                parameters2[0].Value = modelt.TransportOrderId;
                                parameters2[1].Value = modelt.RoundStatus;
                                parameters2[2].Value = modelt.ContractNumber;
                                parameters2[3].Value = modelt.BillNumber;
                                parameters2[4].Value = modelt.Shipper;
                                parameters2[5].Value = modelt.Receiver;
                                parameters2[6].Value = modelt.LoadingAddress;
                                parameters2[7].Value = modelt.UnloadingAddress;
                                parameters2[8].Value = modelt.Goods;
                                parameters2[9].Value = modelt.Unit;
                                parameters2[10].Value = modelt.FactDispatchCount;
                                parameters2[11].Value = modelt.FactReceivedCount;
                                parameters2[12].Value = modelt.CompensationCosts;
                                parameters2[13].Value = modelt.MyCosts;
                                parameters2[14].Value = modelt.Haulway;
                                parameters2[15].Value = modelt.LoadingCapacityRunning;
                                parameters2[16].Value = modelt.NoLoadingCapacityRunning;
                                parameters2[17].Value = modelt.Formula;
                                parameters2[18].Value = modelt.UnitPrice;
                                parameters2[19].Value = modelt.TotalPrice;
                                parameters2[20].Value = modelt.CompanyPrice;
                                parameters2[21].Value = modelt.DispatchCount;
                                parameters2[22].Value = modelt.OrderCode;
                                parameters2[23].Value = modelt.OrderId;
                                DbHelperSQL.ExecuteSql(conn, trans, strSql2.ToString(), parameters2);
                            }
                        }
                        //更新订单数量 List<Model.Order> order_list

                        //订单
                        if (order_list != null)
                        {
                            foreach (Model.Order modelt in order_list)
                            {
                                StringBuilder strSql3 = new StringBuilder();
                                strSql3.Append("update mtms_Order set ");
                                strSql3.Append(" Status=@Status,");
                                strSql3.Append(" DispatchedCount=@DispatchCount ");
                                strSql3.Append(" where Id=@Id ");
                                SqlParameter[] parameters3 = {
			                        new SqlParameter("@Id", SqlDbType.Int,4) ,            
                                    new SqlParameter("@DispatchCount", SqlDbType.Decimal,9),       
                                    new SqlParameter("@Status", SqlDbType.Int,4)};

                                parameters3[0].Value = modelt.Id;
                                parameters3[1].Value = modelt.DispatchedCount;
                                parameters3[2].Value = modelt.Status;
                                
                                DbHelperSQL.ExecuteSql(conn, trans, strSql3.ToString(), parameters3);
                            }
                        }
                        trans.Commit();
                    }
                    catch
                    {
                        trans.Rollback();
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Update(int id, DateTime warningTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_TransportOrder set ");

            strSql.Append(" WarningTime = @WarningTime ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@WarningTime", SqlDbType.DateTime)         
              
            };

            parameters[0].Value = id;
            parameters[1].Value = warningTime;
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

        public bool UpdateReceipt(Model.TransportOrder model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mtms_TransportOrder set ");

            strSql.Append(" ReceiptTime = @ReceiptTime ,");
            strSql.Append(" Status = @Status , ");
            strSql.Append(" Remarks = @Remarks  ");
            strSql.Append(" where Id=@Id ");

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReceiptTime", SqlDbType.DateTime),
                        new SqlParameter("@Status", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remarks", SqlDbType.VarChar,254)      
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.ReceiptTime;
            parameters[2].Value = model.Status;
            parameters[3].Value = model.Remarks;
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
            strSql.Append("delete from mtms_TransportOrder ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            List<CommandInfo> sqllist = new List<CommandInfo>();
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from mtms_TransportOrderItem ");
            strSql2.Append(" where TransportOrderId=@TransportOrderId");
            SqlParameter[] parameters2 = {
					new SqlParameter("@TransportOrderId", SqlDbType.Int,4)
			};
            parameters2[0].Value = Id;
            cmd = new CommandInfo(strSql2.ToString(), parameters2);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
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
            strSql.Append("delete from mtms_TransportOrder ");
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
        public Model.TransportOrder GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Code, DispatchTime, FactDispatchTime, TimeLimit, BackTime, FactBackTime, MotorcadeName, CarNumber, Trailer, Driver, Advance, Payee, Repayment, FactRepayment, Percentage, Carriage, FactCarriage, CostTotal, Profit, AddTime, Status,WarningTime, Remarks  ");
            strSql.Append("  from mtms_TransportOrder ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            Model.TransportOrder model = new Model.TransportOrder();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.Code = ds.Tables[0].Rows[0]["Code"].ToString();
                if (ds.Tables[0].Rows[0]["DispatchTime"].ToString() != "")
                {
                    model.DispatchTime = DateTime.Parse(ds.Tables[0].Rows[0]["DispatchTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactDispatchTime"].ToString() != "")
                {
                    model.FactDispatchTime = DateTime.Parse(ds.Tables[0].Rows[0]["FactDispatchTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TimeLimit"].ToString() != "")
                {
                    model.TimeLimit = int.Parse(ds.Tables[0].Rows[0]["TimeLimit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BackTime"].ToString() != "")
                {
                    model.BackTime = DateTime.Parse(ds.Tables[0].Rows[0]["BackTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactBackTime"].ToString() != "")
                {
                    model.FactBackTime = DateTime.Parse(ds.Tables[0].Rows[0]["FactBackTime"].ToString());
                }
                model.MotorcadeName = ds.Tables[0].Rows[0]["MotorcadeName"].ToString();
                model.CarNumber = ds.Tables[0].Rows[0]["CarNumber"].ToString();
                model.Trailer = ds.Tables[0].Rows[0]["Trailer"].ToString();
                model.Driver = ds.Tables[0].Rows[0]["Driver"].ToString();
                if (ds.Tables[0].Rows[0]["Advance"].ToString() != "")
                {
                    model.Advance = decimal.Parse(ds.Tables[0].Rows[0]["Advance"].ToString());
                }
                model.Payee = ds.Tables[0].Rows[0]["Payee"].ToString();
                if (ds.Tables[0].Rows[0]["Repayment"].ToString() != "")
                {
                    model.Repayment = decimal.Parse(ds.Tables[0].Rows[0]["Repayment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactRepayment"].ToString() != "")
                {
                    model.FactRepayment = decimal.Parse(ds.Tables[0].Rows[0]["FactRepayment"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Percentage"].ToString() != "")
                {
                    model.Percentage = decimal.Parse(ds.Tables[0].Rows[0]["Percentage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Carriage"].ToString() != "")
                {
                    model.Carriage = decimal.Parse(ds.Tables[0].Rows[0]["Carriage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FactCarriage"].ToString() != "")
                {
                    model.FactCarriage = decimal.Parse(ds.Tables[0].Rows[0]["FactCarriage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CostTotal"].ToString() != "")
                {
                    model.CostTotal = decimal.Parse(ds.Tables[0].Rows[0]["CostTotal"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Profit"].ToString() != "")
                {
                    model.Profit = decimal.Parse(ds.Tables[0].Rows[0]["Profit"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WarningTime"].ToString() != "")
                {
                    model.WarningTime = DateTime.Parse(ds.Tables[0].Rows[0]["WarningTime"].ToString());
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
            strSql.Append(" FROM mtms_TransportOrder ");
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
            strSql.Append(" FROM mtms_TransportOrder ");
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
            strSql.Append("SELECT a.Id AS TransportOrderItemId, a.Shipper, a.Receiver, a.BillNumber, a.Goods, a.Unit,a.DispatchCount,FactDispatchCount,a.LoadingAddress,a.UnloadingAddress, ");
            strSql.Append("b.Id AS Id,b.Code,b.DispatchTime,b.FactDispatchTime,b.FactBackTime,b.CarNumber,b.Driver,b.Status,b.WarningTime ");
            strSql.Append("FROM mtms_TransportOrderItem a LEFT JOIN mtms_TransportOrder b ON a.TransportOrderId = b.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public DataSet GetRecordsList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT a.Id AS TransportOrderItemId, a.Shipper, a.Receiver, a.BillNumber, a.Goods, a.Unit,a.DispatchCount,FactDispatchCount,a.LoadingAddress,a.UnloadingAddress,a.UnitPrice,a.TotalPrice, ");
            strSql.Append("b.Id AS Id,b.Code,b.DispatchTime,b.FactDispatchTime,b.FactBackTime,b.CarNumber,b.Driver,b.Status, b.ReceiptTime,b.WarningTime, ");
            strSql.Append("c.AcceptOrderTime ");
            strSql.Append("FROM mtms_TransportOrderItem a LEFT JOIN mtms_TransportOrder b ON a.TransportOrderId = b.Id, mtms_Order c WHERE a.OrderId = c.Id ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(strWhere);
            }
            //recordCount = 0;
            recordCount = recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            //throw new Exception(PagingHelper.CreateCountingSql(strSql.ToString()));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public DataSet GetTransportOrders(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM mtms_TransportOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public DataSet GetTransportOrdersAndItem(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * ");
            strSql.Append("FROM mtms_TransportOrder ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public DataSet GetTransportOrdersAndDriver(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select  a.Id AS Id, a.Code,a.FactBackTime,a.CarNumber,a.Driver,a.WarningTime,
                            b.LinkTel,b.RealName,b.IdCardNumber,b.LinkAddress 
                            FROM mtms_TransportOrder a 
                            left join mtms_Driver b  on a.CarNumber = b.CarNumber ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));

            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}
