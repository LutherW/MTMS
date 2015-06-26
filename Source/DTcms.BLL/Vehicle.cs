using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using DTcms.Model;

namespace DTcms.BLL
{
    public partial class Vehicle
    {

        private readonly DTcms.DAL.Vehicle dal = new DTcms.DAL.Vehicle ();
        public Vehicle()
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
        public int Add(Model.Vehicle model)
        {
            return dal.Add(model);

        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Vehicle model)
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
        public Model.Vehicle GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        //public Model.Vehicle GetModelByCache(int Id)
        //{

        //    string CacheKey = "mtms_Model.VehicleModel-" + Id;
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
        //    return (Model.Vehicle)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedVehicle)
        {
            return dal.GetList(Top, strWhere, filedVehicle);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Vehicle> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Vehicle> DataTableToList(DataTable dt)
        {
            List<Model.Vehicle> modelList = new List<Model.Vehicle>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Vehicle model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Model.Vehicle();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.CarCode = dt.Rows[n]["CarCode"].ToString();
                    model.CarNumber = dt.Rows[n]["CarNumber"].ToString();
                    model.MotorcadeName = dt.Rows[n]["MotorcadeName"].ToString();
                    model.MotorcycleType = dt.Rows[n]["MotorcycleType"].ToString();
                    if (dt.Rows[n]["LoadingCapacity"].ToString() != "")
                    {
                        model.LoadingCapacity = decimal.Parse(dt.Rows[n]["LoadingCapacity"].ToString());
                    }
                    model.EngineType = dt.Rows[n]["EngineType"].ToString();
                    model.FrameNumber = dt.Rows[n]["FrameNumber"].ToString();
                    model.ChassisNumber = dt.Rows[n]["ChassisNumber"].ToString();
                    model.InsuranceNumber = dt.Rows[n]["InsuranceNumber"].ToString();
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

        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion

    }
}
