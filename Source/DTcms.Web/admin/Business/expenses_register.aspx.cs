using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Business
{
    public partial class expenses_register : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected string transportOrderItems = string.Empty;
        protected string consumptions = string.Empty;

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
                ChkAdminLevel("expenses_register_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            labFactDispatchTime.Text = model.FactDispatchTime.Value.ToString("yyyy-MM-dd");
            txtFactBackTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            labMotorcade.Text = model.MotorcadeName;
            labCarNumber.Text = model.CarNumber;
            labDriver.Text = model.Driver;
            labAdvance.Text = model.Advance.ToString();
            labPayee.Text = model.Driver;
            txtRepayment.Text = model.Advance.ToString();
            txtFactRepayment.Text = "0.00";

            BLL.TransportOrderItem itemBll = new BLL.TransportOrderItem();
            DataTable dt = itemBll.GetList(" TransportOrderId = " + model.Id + "").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                transportOrderItems += "<tr data-value=\"" + dr["Id"].ToString() + "\">";
                transportOrderItems += "<td width=\"5%\"><input type=\"hidden\" name=\"transportOrderItemId\" value=\"" + dr["Id"].ToString() + "\"/></td>";
                transportOrderItems += "<td align=\"left\">" + dr["OrderCode"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\"><select name='roundStatus'>";
                transportOrderItems += "<option value='往'>往</option>";
                transportOrderItems += "<option value='返'>返</option>";
                transportOrderItems += "<option value='往返'>往返</option>";
                transportOrderItems += "</select></td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Shipper"].ToString() + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Receiver"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"10%\">" + dr["Goods"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"9%\">" + dr["Unit"].ToString()  + "</td>";
                transportOrderItems += "<td width=\"6%\"><input type=\"text\" name=\"factDispatchCount\" class=\"input small\" value=\"" + dr["FactDispatchCount"].ToString() + "\" style='width:50px'/></td>";
                transportOrderItems += "<td width=\"5%\"><input type=\"text\" name=\"factReceivedCount\" class=\"input small\" value=\"" + dr["FactReceivedCount"].ToString() + "\" style='width:50px'/></td>";
                transportOrderItems += "<td width=\"5%\">￥" + string.Format("{0:N2}",dr["UnitPrice"].ToString())+ "</td>";
                transportOrderItems += "<td width=\"5%\">￥<input type=\"text\" name=\"totalPrice\" value=\"" + dr["TotalPrice"].ToString() + "\" style='width:50px'/></td>";
                transportOrderItems += "</tr>";
            }

            BLL.CostItem costItemBll = new BLL.CostItem();
            DataTable costItemDT = costItemBll.GetAllList().Tables[0];
            foreach (DataRow dr in costItemDT.Rows)
            {
                consumptions += "<tr data-value=\"" + dr["Id"].ToString() + "\">";
                consumptions += "<td width=\"5%\"><input type=\"hidden\" name=\"costItemName\" value=\"" + dr["Name"].ToString() + "\"/></td>";
                consumptions += "<td width=\"5%\">" + dr["Name"].ToString() + "</td>";
                consumptions += "<td width=\"50%\">￥<input type=\"text\" name=\"money\" class=\"input small\" value=\"0.00\"/></td>";
                consumptions += "</tr>";
            }
          
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.TransportOrder bll = new BLL.TransportOrder();
            Model.TransportOrder model = bll.GetModel(_id);

            model.FactBackTime = Utils.StrToDateTime(txtFactBackTime.Text.Trim(), DateTime.Now);
            model.Repayment = Utils.StrToDecimal(txtRepayment.Text.Trim(), 0.00M);
            model.FactRepayment = Utils.StrToDecimal(txtFactRepayment.Text.Trim(), 0.00M);
            model.Carriage = Utils.StrToDecimal(txtCarriage.Text.Trim(), 0.00M);
            model.Status = 2;

            string[] itemIds = Request.Params.GetValues("transportOrderItemId");
            string[] factDispatchCounts = Request.Params.GetValues("factDispatchCount");
            string[] factReceivedCounts = Request.Params.GetValues("factReceivedCount");
            string[] totalPrices = Request.Params.GetValues("totalPrice");
            string[] roundStatus = Request.Params.GetValues("roundStatus");

            string[] costItemNames = Request.Params.GetValues("costItemName");
            string[] monies = Request.Params.GetValues("money");


            List<Model.TransportOrderItem> item_list = new List<Model.TransportOrderItem>();
            BLL.TransportOrderItem itemBll = new BLL.TransportOrderItem();
            Model.TransportOrderItem item;

            List<Model.Order> orders = new List<Model.Order>();
            BLL.Order orderBll = new BLL.Order();
            Model.Order order;
            for (int i = 0; i < itemIds.Length; i++)
            {
                item = itemBll.GetModel(Utils.StrToInt(itemIds[i], 0));
                if (item != null)
                {
                    decimal oldFactDispatchCount = item.FactDispatchCount;
                    decimal newFactDispatchCount = Utils.StrToDecimal(factDispatchCounts[i], 0.00M);
                    order = orderBll.GetModel(item.OrderId);
                    order.DispatchedCount += newFactDispatchCount - oldFactDispatchCount;
                    orders.Add(order);

                    item.FactDispatchCount = newFactDispatchCount;
                    item.FactReceivedCount = Utils.StrToDecimal(factReceivedCounts[i], 0.00M);
                    item.TotalPrice = Utils.StrToDecimal(totalPrices[i], 0.00M);
                    item.RoundStatus = roundStatus[i];
                    item_list.Add(item);
                }
            }
            List<Model.Consumption> consumption_list = new List<Model.Consumption>();
            for (int i = 0; i < costItemNames.Length; i++)
            {
                Model.Consumption consumption = new Model.Consumption();
                consumption.Name = costItemNames[i];
                consumption.Money = Utils.StrToDecimal(monies[i], 0.00M);
                consumption.TransportOrderId = _id;
                consumption_list.Add(consumption);
            }

            if (bll.Update(model, item_list, consumption_list, orders))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "回车报账信息:" + model.Code); //记录日志
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
                ChkAdminLevel("expenses_register_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("回车报账成功！", "expenses_register_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("expenses_register_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加运输单成功！", "expenses_register_list.aspx", "Success");
            }
        }
    }
}