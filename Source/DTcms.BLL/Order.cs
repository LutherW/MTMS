using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Model;

namespace DTcms.BLL
{
    public partial class Order
    {

        private readonly DTcms.DAL.Order dal = new DTcms.DAL.Order ();
        public Order()
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
        public int Add(Model.Order model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Order model)
        {
            return dal.Update(model);
        }

        public bool AddDispatchCount(int id, decimal dispatchCount, int status) 
        {
            return dal.AddDispatchCount(id, dispatchCount, status);
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
        public Model.Order GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public Model.Order GetModelByCache(int Id)
        //{

        //    string CacheKey = "mtms_Model.OrderModel-" + Id;
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
        //    return (Model.Order)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Order> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Order> DataTableToList(DataTable dt)
        {
            List<Model.Order> modelList = new List<Model.Order>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Order model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.Order();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Code = dt.Rows[n]["Code"].ToString();
                    if (dt.Rows[n]["AcceptOrderTime"].ToString() != "")
                    {
                        model.AcceptOrderTime = DateTime.Parse(dt.Rows[n]["AcceptOrderTime"].ToString());
                    }
                    if (dt.Rows[n]["ArrivedTime"].ToString() != "")
                    {
                        model.ArrivedTime = DateTime.Parse(dt.Rows[n]["ArrivedTime"].ToString());
                    }
                    model.Shipper = dt.Rows[n]["Shipper"].ToString();
                    model.ShipperLinkMan = dt.Rows[n]["ShipperLinkMan"].ToString();
                    model.ShipperLinkTel = dt.Rows[n]["ShipperLinkTel"].ToString();
                    model.Receiver = dt.Rows[n]["Receiver"].ToString();
                    model.ReceiverLinkMan = dt.Rows[n]["ReceiverLinkMan"].ToString();
                    model.ReceiverLinkTel = dt.Rows[n]["ReceiverLinkTel"].ToString();
                    model.ContractNumber = dt.Rows[n]["ContractNumber"].ToString();
                    model.LoadingAddress = dt.Rows[n]["LoadingAddress"].ToString();
                    model.UnloadingAddress = dt.Rows[n]["UnloadingAddress"].ToString();
                    model.Goods = dt.Rows[n]["Goods"].ToString();
                    model.Unit = dt.Rows[n]["Unit"].ToString();
                    if (dt.Rows[n]["IsCharteredCar"].ToString() != "")
                    {
                        model.IsCharteredCar = int.Parse(dt.Rows[n]["IsCharteredCar"].ToString());
                    }
                    if (dt.Rows[n]["Quantity"].ToString() != "")
                    {
                        model.Quantity = decimal.Parse(dt.Rows[n]["Quantity"].ToString());
                    }
                    if (dt.Rows[n]["DispatchedCount"].ToString() != "")
                    {
                        model.DispatchedCount = decimal.Parse(dt.Rows[n]["DispatchedCount"].ToString());
                    }
                    model.Haulway = dt.Rows[n]["Haulway"].ToString();
                    if (dt.Rows[n]["LoadingCapacityRunning"].ToString() != "")
                    {
                        model.LoadingCapacityRunning = decimal.Parse(dt.Rows[n]["LoadingCapacityRunning"].ToString());
                    }
                    if (dt.Rows[n]["NoLoadingCapacityRunning"].ToString() != "")
                    {
                        model.NoLoadingCapacityRunning = decimal.Parse(dt.Rows[n]["NoLoadingCapacityRunning"].ToString());
                    }
                    model.BillNumber = dt.Rows[n]["BillNumber"].ToString();
                    model.WeighbridgeNumber = dt.Rows[n]["WeighbridgeNumber"].ToString();
                    model.Formula = dt.Rows[n]["Formula"].ToString();
                    if (dt.Rows[n]["UnitPrice"].ToString() != "")
                    {
                        model.UnitPrice = decimal.Parse(dt.Rows[n]["UnitPrice"].ToString());
                    }
                    if (dt.Rows[n]["TotalPrice"].ToString() != "")
                    {
                        model.TotalPrice = decimal.Parse(dt.Rows[n]["TotalPrice"].ToString());
                    }
                    model.SettleAccountsWay = dt.Rows[n]["SettleAccountsWay"].ToString();
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

        #endregion

    }
}
