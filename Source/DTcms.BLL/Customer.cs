using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Model;

namespace DTcms.BLL
{
    public partial class Customer
    {

        private readonly DTcms.DAL.Customer dal = new DTcms.DAL.Customer("mtms_");
        public Customer()
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
        public int Add(Model.Customer model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Customer model)
        {
            return dal.Update(model);
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
        public Model.Customer GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public Model.Customer GetModelByCache(int Id)
        //{

        //    string CacheKey = "mtms_Model.CustomerModel-" + Id;
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
        //    return (Model.Customer)objModel;
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
        public List<Model.Customer> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Customer> DataTableToList(DataTable dt)
        {
            List<Model.Customer> modelList = new List<Model.Customer>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Customer model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.Customer();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.ShortName = dt.Rows[n]["ShortName"].ToString();
                    model.FullName = dt.Rows[n]["FullName"].ToString();
                    model.TypeName = dt.Rows[n]["TypeName"].ToString();
                    model.Category = dt.Rows[n]["Category"].ToString();
                    model.Code = dt.Rows[n]["Code"].ToString();
                    model.LinkMan = dt.Rows[n]["LinkMan"].ToString();
                    model.LinkTel = dt.Rows[n]["LinkTel"].ToString();
                    model.MobileNumber = dt.Rows[n]["MobileNumber"].ToString();
                    model.LinkAddress = dt.Rows[n]["LinkAddress"].ToString();
                    model.TaxRegistrationNumber = dt.Rows[n]["TaxRegistrationNumber"].ToString();
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
