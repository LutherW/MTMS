using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Model;

namespace DTcms.BLL
{
    public partial class TransportOrderItem
    {

        private readonly DTcms.DAL.TransportOrderItem dal = new DTcms.DAL.TransportOrderItem ();
        public TransportOrderItem()
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
        public int Add(Model.TransportOrderItem model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.TransportOrderItem model)
        {
            return dal.Update(model);
        }

        public bool UpdateFactDispatchCount(int id, decimal factDispatchCount) 
        {
            return dal.UpdateFactDispatchCount(id, factDispatchCount);
        }

        public bool UpdateExpensesInfo(Model.TransportOrderItem model)
        {
            return dal.UpdateExpensesInfo(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id);
        }
        public bool DeleteBy(int transportorderid)
        {

            return dal.DeleteBy(transportorderid);
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
        public Model.TransportOrderItem GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public Model.TransportOrderItem GetModelByCache(int Id)
        //{

        //    string CacheKey = "mtms_Model.TransportOrderItemModel-" + Id;
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
        //    return (Model.TransportOrderItem)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedTransportOrderItem)
        {
            return dal.GetList(Top, strWhere, filedTransportOrderItem);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.TransportOrderItem> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.TransportOrderItem> DataTableToList(DataTable dt)
        {
            List<Model.TransportOrderItem> modelList = new List<Model.TransportOrderItem>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.TransportOrderItem model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.TransportOrderItem();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    if (dt.Rows[n]["TransportOrderId"].ToString() != "")
                    {
                        model.TransportOrderId = int.Parse(dt.Rows[n]["TransportOrderId"].ToString());
                    }
                    model.RoundStatus = dt.Rows[n]["RoundStatus"].ToString();
                    model.ContractNumber = dt.Rows[n]["ContractNumber"].ToString();
                    model.BillNumber = dt.Rows[n]["BillNumber"].ToString();
                    model.Shipper = dt.Rows[n]["Shipper"].ToString();
                    model.Receiver = dt.Rows[n]["Receiver"].ToString();
                    model.LoadingAddress = dt.Rows[n]["LoadingAddress"].ToString();
                    model.UnloadingAddress = dt.Rows[n]["UnloadingAddress"].ToString();
                    model.Goods = dt.Rows[n]["Goods"].ToString();
                    model.Unit = dt.Rows[n]["Unit"].ToString();
                    if (dt.Rows[n]["FactDispatchCount"].ToString() != "")
                    {
                        model.FactDispatchCount = decimal.Parse(dt.Rows[n]["FactDispatchCount"].ToString());
                    }
                    if (dt.Rows[n]["FactReceivedCount"].ToString() != "")
                    {
                        model.FactReceivedCount = decimal.Parse(dt.Rows[n]["FactReceivedCount"].ToString());
                    }
                    if (dt.Rows[n]["CompensationCosts"].ToString() != "")
                    {
                        model.CompensationCosts = decimal.Parse(dt.Rows[n]["CompensationCosts"].ToString());
                    }
                    if (dt.Rows[n]["MyCosts"].ToString() != "")
                    {
                        model.MyCosts = decimal.Parse(dt.Rows[n]["MyCosts"].ToString());
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
                    model.Formula = dt.Rows[n]["Formula"].ToString();
                    if (dt.Rows[n]["UnitPrice"].ToString() != "")
                    {
                        model.UnitPrice = decimal.Parse(dt.Rows[n]["UnitPrice"].ToString());
                    }
                    if (dt.Rows[n]["TotalPrice"].ToString() != "")
                    {
                        model.TotalPrice = decimal.Parse(dt.Rows[n]["TotalPrice"].ToString());
                    }
                    if (dt.Rows[n]["CompanyPrice"].ToString() != "")
                    {
                        model.CompanyPrice = decimal.Parse(dt.Rows[n]["CompanyPrice"].ToString());
                    }


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
        #endregion

    }
}
