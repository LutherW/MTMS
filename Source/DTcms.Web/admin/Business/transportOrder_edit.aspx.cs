using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Business
{
    public partial class transportOrder_edit : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected string transportOrderItems = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.TransportOrder().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("transportOrder_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                TreeBind(""); //绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定类别=================================
        private void TreeBind(string strWhere)
        {
            BLL.Motorcade bll = new BLL.Motorcade();
            DataTable dt = bll.GetList(0, strWhere, "Id desc").Tables[0];

            ddlMotorcade.Items.Clear();
            ddlMotorcade.Items.Add(new ListItem("请选择车队", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlMotorcade.Items.Add(new ListItem(dr["Name"].ToString(), dr["Name"].ToString()));
            }
            ddlMotorcade.SelectedIndex = 0;

            string motorcadeName = ddlMotorcade.SelectedValue;
            BLL.Vehicle vehicleBll = new BLL.Vehicle();
            ddlCarNumber.Items.Clear();
            ddlCarNumber.Items.Add(new ListItem("请选择车辆", ""));
            if (!string.IsNullOrEmpty(motorcadeName))
            {
                DataTable vehicledt = vehicleBll.GetList(0, " MotorcadeName = '" + motorcadeName + "' ", "Id desc").Tables[0];

                foreach (DataRow dr in vehicledt.Rows)
                {
                    this.ddlCarNumber.Items.Add(new ListItem(dr["CarCode"].ToString(), dr["CarCode"].ToString()));
                }
            }
            else
            {
                DataTable vehicledt = vehicleBll.GetList(0, "", "Id desc").Tables[0];

                foreach (DataRow dr in vehicledt.Rows)
                {
                    this.ddlCarNumber.Items.Add(new ListItem(dr["CarCode"].ToString(), dr["CarCode"].ToString()));
                }
            }

            BLL.Order orderBll = new BLL.Order();
            this.rptList.DataSource = orderBll.GetList(" Quantity > DispatchedCount ");
            this.rptList.DataBind();
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            txtDispatchTime.Text = model.DispatchTime.ToString("yyyy-MM-dd");
            txtBackTime.Text = model.BackTime.ToString("yyyy-MM-dd");
            ddlMotorcade.SelectedValue = model.MotorcadeName;
            ddlCarNumber.SelectedValue = model.CarNumber;
            txtDriver.Text = model.Driver;
            txtRemarks.Text = model.Remarks;

            BLL.TransportOrderItem itemBll = new BLL.TransportOrderItem();
            DataTable dt = itemBll.GetList(" TransportOrderId = " + model.Id + "").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                transportOrderItems += "<tr data-value=\"" + dr["Id"].ToString() + "\" data-order-id=\"" + dr["OrderId"].ToString() + "\">";
                transportOrderItems += "<td width=\"5%\"><input type=\"hidden\" name=\"orderId\" value=\"" + dr["OrderId"].ToString() + "\"/></td>";
                transportOrderItems += "<td width=\"10%\">" + dr["BillNumber"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Shipper"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Receiver"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Goods"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"9%\">" + dr["Unit"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"6%\">" + dr["DispatchCount"].ToString() + "</td>";
                transportOrderItems += "<td width=\"5%\"><input type=\"text\" name=\"factDispatchCount\" value=\"" + dr["FactDispatchCount"].ToString() + "\" class=\"input small\"/></td>";
                transportOrderItems += "<td width=\"5%\">" + dr["UnitPrice"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"5%\">" + dr["TotalPrice"].ToString()  + "</td>";
                transportOrderItems += "</tr>";
            }
          
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.TransportOrder model = new Model.TransportOrder();
            BLL.TransportOrder bll = new BLL.TransportOrder();

            string[] orderIds = Request.Params.GetValues("orderId");
            string[] factDispatchCounts = Request.Params.GetValues("factDispatchCount");
            if (orderIds == null)
            {
                JscriptMsg("请填写运输项信息！", "", "Error");
                return false;
            }

            model.Code = "No" + DateTime.Now.ToString("yyyyMMddhhmmss");
            model.DispatchTime = Convert.ToDateTime(txtDispatchTime.Text.Trim());
            model.FactDispatchTime = DateTime.Now;
            model.BackTime = Convert.ToDateTime(txtBackTime.Text.Trim());
            model.FactBackTime = DateTime.Now;
            model.MotorcadeName = ddlMotorcade.SelectedValue;
            model.CarNumber = ddlCarNumber.SelectedValue;
            model.Driver = txtDriver.Text.Trim();
            model.Remarks = txtRemarks.Text.Trim();

            List<Model.TransportOrderItem> item_list = new List<Model.TransportOrderItem>();//运输子项
            List<Model.Order> order_list = new List<Model.Order>();//订单
            BLL.Order orderBll = new BLL.Order();
            for (int i = 0; i < orderIds.Length; i++)
            {
                Model.Order order = orderBll.GetModel(Convert.ToInt32(orderIds[i]));
                if (order != null)
                {
                    Model.TransportOrderItem item = new Model.TransportOrderItem();
                    item.OrderId = order.Id;
                    item.OrderCode = order.Code;
                    item.ContractNumber = order.ContractNumber;
                    item.BillNumber = order.BillNumber;
                    item.Shipper = order.Shipper;
                    item.Receiver = order.Receiver;
                    item.LoadingAddress = order.LoadingAddress;
                    item.UnloadingAddress = order.UnloadingAddress;
                    item.Goods = order.Goods;
                    item.Unit = order.Unit;
                    item.DispatchCount = order.Quantity;
                    item.FactDispatchCount = Convert.ToDecimal(factDispatchCounts[i]);
                    item.FactReceivedCount = item.FactDispatchCount;
                    item.CompensationCosts = 0.00M;
                    item.MyCosts = 0.00m;
                    item.Haulway = order.Haulway;
                    item.LoadingCapacityRunning = order.LoadingCapacityRunning;
                    item.NoLoadingCapacityRunning = order.NoLoadingCapacityRunning;
                    item.Formula = order.Formula;
                    item.UnitPrice = order.UnitPrice;
                    item.TotalPrice = order.TotalPrice;
                    item.CompanyPrice = item.TotalPrice;
                    item_list.Add(item);

                   // int status = (order.IsCharteredCar == 1 || ((order.DispatchedCount + item.FactDispatchCount) == order.Quantity)) ? 1 : 0;
                    //order.Status = status;
                    order.DispatchedCount = order.DispatchedCount + item.FactDispatchCount;
                    order_list.Add(order);
                }
            }
            if (bll.Add(model,item_list,order_list) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加运输单:" + model.Code); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            string[] orderIds = Request.Params.GetValues("orderId");
            string[] factDispatchCounts = Request.Params.GetValues("factDispatchCount");

            if (orderIds == null)
            {
                JscriptMsg("请填写运输项信息！", "", "Error");
                return false;
            }
            model.DispatchTime = Convert.ToDateTime(txtDispatchTime.Text.Trim());
            model.FactDispatchTime = DateTime.Now;
            model.BackTime = Convert.ToDateTime(txtBackTime.Text.Trim());
            model.FactBackTime = DateTime.Now;
            model.MotorcadeName = ddlMotorcade.SelectedValue;
            model.CarNumber = ddlCarNumber.SelectedValue;
            model.Driver = txtDriver.Text.Trim();
            model.Remarks = txtRemarks.Text.Trim();
            model.AddTime = DateTime.Now;
            model.Status = 0;

            List<Model.TransportOrderItem> item_list = new List<Model.TransportOrderItem>();
            List<Model.Order> order_list = new List<Model.Order>();//订单
            BLL.Order orderBll = new BLL.Order();

            //new BLL.TransportOrderItem().DeleteBy(model.Id);//删除该运输单下 所有 运输子项

            for (int i = 0; i < orderIds.Length; i++)
            {
                Model.Order order = orderBll.GetModel(Convert.ToInt32(orderIds[i]));
                if (order != null)
                {
                    Model.TransportOrderItem item = new Model.TransportOrderItem();
                    item.OrderId = order.Id;
                    item.OrderCode = order.Code;
                    item.ContractNumber = order.ContractNumber;
                    item.BillNumber = order.BillNumber;
                    item.Shipper = order.Shipper;
                    item.Receiver = order.Receiver;
                    item.LoadingAddress = order.LoadingAddress;
                    item.UnloadingAddress = order.UnloadingAddress;
                    item.Goods = order.Goods;
                    item.Unit = order.Unit;
                    item.DispatchCount = order.Quantity;
                    item.FactDispatchCount = Convert.ToDecimal(factDispatchCounts[i]);
                    item.FactReceivedCount = item.FactDispatchCount;
                    item.CompensationCosts = 0.00M;
                    item.MyCosts = 0.00m;
                    item.Haulway = order.Haulway;
                    item.LoadingCapacityRunning = order.LoadingCapacityRunning;
                    item.NoLoadingCapacityRunning = order.NoLoadingCapacityRunning;
                    item.Formula = order.Formula;
                    item.UnitPrice = order.UnitPrice;
                    item.TotalPrice = order.TotalPrice;
                    item.CompanyPrice = item.TotalPrice;
                    item_list.Add(item);
                    
                    //int status = (order.IsCharteredCar == 1 || ((order.DispatchedCount + item.FactDispatchCount) == order.Quantity)) ? 1 : 0;
                    //order.Status = status;
                    //order.DispatchedCount = item.FactDispatchCount;
                    //order_list.Add(order);
                }
            }
            if (bll.Update(model,item_list,order_list))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改运输单信息:" + model.Code); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("transportOrder_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改运输单成功！", "transportOrder_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("transportOrder_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加运输单成功！", "transportOrder_list.aspx", "Success");
            }
        }
    }
}