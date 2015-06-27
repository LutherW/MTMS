using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Model;

namespace DTcms.BLL
{
    public partial class TransportOrder
    {

        private readonly DTcms.DAL.TransportOrder dal = new DTcms.DAL.TransportOrder ();
        public TransportOrder()
        { }

        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.TransportOrder model,List<Model.TransportOrderItem> item_list,List<Model.Order> order_list)
        {
            return dal.Add(model, item_list, order_list);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.TransportOrder model,List<Model.TransportOrderItem> item_list)
        {
            return dal.Update(model, item_list);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.TransportOrder model, List<Model.TransportOrderItem> item_list, List<Model.Consumption> consumption_list, List<Model.Order> orders)
        {
            return dal.Update(model, item_list, consumption_list, orders);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.TransportOrder model,List<Model.TransportOrderItem> item_list,List<Model.Order> order_list)
        {
            return dal.Update(model, item_list, order_list);
        }

        public bool Update(int id, DateTime warningTime) 
        {
            return dal.Update(id, warningTime);
        }

        public bool UpdateReceipt(Model.TransportOrder model) 
        {
            return dal.UpdateReceipt(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string Idlist)
        {
            return dal.DeleteList(Idlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.TransportOrder GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public Model.TransportOrder GetModelByCache(int Id)
        //{

        //    string CacheKey = "mtms_Model.TransportOrderModel-" + Id;
        //    object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
        //    if (objModel == null)
        //    {
        //        try
        //        {
        //            objModel = dal.GetModel(Id);
        //            if (objModel != null)
        //            {
        //                int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
        //                Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
        //            }
        //        }
        //        catch { }
        //    }
        //    return (Model.TransportOrder)objModel;
        //}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedTransportOrder)
        {
            return dal.GetList(Top, strWhere, filedTransportOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.TransportOrder> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.TransportOrder> DataTableToList(DataTable dt)
        {
            List<Model.TransportOrder> modelList = new List<Model.TransportOrder>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.TransportOrder model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.TransportOrder();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Code = dt.Rows[n]["Code"].ToString();
                    if (dt.Rows[n]["DispatchTime"].ToString() != "")
                    {
                        model.DispatchTime = DateTime.Parse(dt.Rows[n]["DispatchTime"].ToString());
                    }
                    if (dt.Rows[n]["FactDispatchTime"].ToString() != "")
                    {
                        model.FactDispatchTime = DateTime.Parse(dt.Rows[n]["FactDispatchTime"].ToString());
                    }
                    if (dt.Rows[n]["TimeLimit"].ToString() != "")
                    {
                        model.TimeLimit = int.Parse(dt.Rows[n]["TimeLimit"].ToString());
                    }
                    if (dt.Rows[n]["BackTime"].ToString() != "")
                    {
                        model.BackTime = DateTime.Parse(dt.Rows[n]["BackTime"].ToString());
                    }
                    if (dt.Rows[n]["FactBackTime"].ToString() != "")
                    {
                        model.FactBackTime = DateTime.Parse(dt.Rows[n]["FactBackTime"].ToString());
                    }
                    model.MotorcadeName = dt.Rows[n]["MotorcadeName"].ToString();
                    model.CarNumber = dt.Rows[n]["CarNumber"].ToString();
                    model.Trailer = dt.Rows[n]["Trailer"].ToString();
                    model.Driver = dt.Rows[n]["Driver"].ToString();
                    if (dt.Rows[n]["DispatchCount"].ToString() != "")
                    {
                        model.DispatchCount = decimal.Parse(dt.Rows[n]["DispatchCount"].ToString());
                    }
                    if (dt.Rows[n]["FactDispatchCount"].ToString() != "")
                    {
                        model.FactDispatchCount = decimal.Parse(dt.Rows[n]["FactDispatchCount"].ToString());
                    }
                    if (dt.Rows[n]["FactReceivedCount"].ToString() != "")
                    {
                        model.FactReceivedCount = decimal.Parse(dt.Rows[n]["FactReceivedCount"].ToString());
                    }
                    if (dt.Rows[n]["Advance"].ToString() != "")
                    {
                        model.Advance = decimal.Parse(dt.Rows[n]["Advance"].ToString());
                    }
                    model.Payee = dt.Rows[n]["Payee"].ToString();
                    if (dt.Rows[n]["Repayment"].ToString() != "")
                    {
                        model.Repayment = decimal.Parse(dt.Rows[n]["Repayment"].ToString());
                    }
                    if (dt.Rows[n]["FactRepayment"].ToString() != "")
                    {
                        model.FactRepayment = decimal.Parse(dt.Rows[n]["FactRepayment"].ToString());
                    }
                    if (dt.Rows[n]["Percentage"].ToString() != "")
                    {
                        model.Percentage = decimal.Parse(dt.Rows[n]["Percentage"].ToString());
                    }
                    if (dt.Rows[n]["Carriage"].ToString() != "")
                    {
                        model.Carriage = decimal.Parse(dt.Rows[n]["Carriage"].ToString());
                    }
                    if (dt.Rows[n]["FactCarriage"].ToString() != "")
                    {
                        model.FactCarriage = decimal.Parse(dt.Rows[n]["FactCarriage"].ToString());
                    }
                    if (dt.Rows[n]["CostTotal"].ToString() != "")
                    {
                        model.CostTotal = decimal.Parse(dt.Rows[n]["CostTotal"].ToString());
                    }
                    if (dt.Rows[n]["Profit"].ToString() != "")
                    {
                        model.Profit = decimal.Parse(dt.Rows[n]["Profit"].ToString());
                    }
                    if (dt.Rows[n]["AddTime"].ToString() != "")
                    {
                        model.AddTime = DateTime.Parse(dt.Rows[n]["AddTime"].ToString());
                    }
                    if (dt.Rows[n]["Status"].ToString() != "")
                    {
                        model.Status = int.Parse(dt.Rows[n]["Status"].ToString());
                    }
                    model.Remarks = dt.Rows[n]["Remarks"].ToString();


                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public DataSet GetRecordsList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetRecordsList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public DataSet GetTransportOrders(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetTransportOrders(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public DataSet GetTransportOrdersAndDriver(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetTransportOrdersAndDriver(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion

    }
}
