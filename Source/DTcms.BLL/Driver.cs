using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Model;

namespace DTcms.BLL
{
    public partial class Driver
    {

        private readonly DTcms.DAL.Driver dal = new DTcms.DAL.Driver ();
        public Driver()
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
        public int Add(Model.Driver model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Driver model)
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
        public Model.Driver GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        public Model.Driver GetModel(string carNumber)
        {

            return dal.GetModel(carNumber);
        }


        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public Model.Driver GetModelByCache(int Id)
        //{

        //    string CacheKey = "mtms_Model.DriverModel-" + Id;
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
        //    return (Model.Driver)objModel;
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
        public List<Model.Driver> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Driver> DataTableToList(DataTable dt)
        {
            List<Model.Driver> modelList = new List<Model.Driver>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Driver model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.Driver();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.RealName = dt.Rows[n]["RealName"].ToString();
                    model.RealNameCode = dt.Rows[n]["RealNameCode"].ToString();
                    model.CarNumber = dt.Rows[n]["CarNumber"].ToString();
                    model.IdCardNumber = dt.Rows[n]["IdCardNumber"].ToString();
                    model.LinkTel = dt.Rows[n]["LinkTel"].ToString();
                    model.LinkAddress = dt.Rows[n]["LinkAddress"].ToString();
                    if (dt.Rows[n]["BeganWorkDate"].ToString() != "")
                    {
                        model.BeganWorkDate = DateTime.Parse(dt.Rows[n]["BeganWorkDate"].ToString());
                    }
                    if (dt.Rows[n]["IssuedDate"].ToString() != "")
                    {
                        model.IssuedDate = DateTime.Parse(dt.Rows[n]["IssuedDate"].ToString());
                    }
                    if (dt.Rows[n]["AnnualDate"].ToString() != "")
                    {
                        model.AnnualDate = DateTime.Parse(dt.Rows[n]["AnnualDate"].ToString());
                    }
                    model.DrivingLicence = dt.Rows[n]["DrivingLicence"].ToString();
                    model.DrivingPermitNumber = dt.Rows[n]["DrivingPermitNumber"].ToString();
                    model.DrivingPermitType = dt.Rows[n]["DrivingPermitType"].ToString();
                    if (dt.Rows[n]["IsDimission"].ToString() != "")
                    {
                        model.IsDimission = int.Parse(dt.Rows[n]["IsDimission"].ToString());
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
