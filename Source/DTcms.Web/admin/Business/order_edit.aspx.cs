using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Business
{
    public partial class order_edit : Web.UI.ManagePage
    {
        string defaultpassword = "0|0|0|0"; //默认显示密码
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

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
                if (!new BLL.Order().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("order_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            BLL.Haulway haulwayBll = new BLL.Haulway();
            DataTable haulwayDT = haulwayBll.GetList(0, strWhere, "Id desc").Tables[0];
            ddlHaulway.Items.Clear();
            ddlHaulway.Items.Add(new ListItem("请选择运输路线", ""));
            foreach (DataRow dr in haulwayDT.Rows)
            {
                this.ddlHaulway.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

            ddlFormula.Items.Clear();
            ddlFormula.Items.Add(new ListItem("计量*运费单价", "1"));
            ddlFormula.Items.Add(new ListItem("计量*公里*运费单价", "2"));
            ddlFormula.Items.Add(new ListItem("固定运费", "3"));

            BLL.Customer customerBll = new BLL.Customer();
            DataTable customerDT = customerBll.GetList(0, strWhere, "Id desc").Tables[0];
            ddlShipper.Items.Clear();
            ddlShipper.Items.Add(new ListItem("请选择托运方", ""));
            ddlReceiver.Items.Clear();
            ddlReceiver.Items.Add(new ListItem("请选择收货方", ""));
            foreach (DataRow dr in customerDT.Rows)
            {
                if (!dr["Category"].ToString().Equals("托运方"))
                {
                    this.ddlReceiver.Items.Add(new ListItem(dr["ShortName"].ToString(), dr["Id"].ToString()));
                }
                if (!dr["Category"].ToString().Equals("收货方"))
                {
                    this.ddlShipper.Items.Add(new ListItem(dr["ShortName"].ToString(), dr["Id"].ToString()));
                }
            }

            BLL.Address addressBll = new BLL.Address();
            DataTable addressDT = addressBll.GetList(0, strWhere, "Id desc").Tables[0];
            ddlLoadingAddress.Items.Clear();
            ddlLoadingAddress.Items.Add(new ListItem("请选择装货地址", ""));
            ddlUnloadingAddress.Items.Clear();
            ddlUnloadingAddress.Items.Add(new ListItem("请选择卸货地址", ""));
            foreach (DataRow dr in addressDT.Rows)
            {
                if (!dr["CategoryName"].ToString().Equals("卸货地址"))
                {
                    this.ddlLoadingAddress.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                }
                if (!dr["CategoryName"].ToString().Equals("装货地址"))
                {
                    this.ddlUnloadingAddress.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
                }
            }

            BLL.Goods goodsBll = new BLL.Goods();
            DataTable goodsDT = goodsBll.GetList(0, strWhere, "Id desc").Tables[0];
            ddlGoods.Items.Clear();
            ddlGoods.Items.Add(new ListItem("请选择承运货物", ""));
            foreach (DataRow dr in goodsDT.Rows)
            {
                this.ddlGoods.Items.Add(new ListItem(dr["Name"].ToString(), dr["Id"].ToString()));
            }

            ddlSettleAccountsWay.Items.Clear();
            ddlSettleAccountsWay.Items.Add(new ListItem("现结", "现结"));
            ddlSettleAccountsWay.Items.Add(new ListItem("月结", "月结"));
            ddlSettleAccountsWay.Items.Add(new ListItem("预付", "预付"));
        }

        protected void ddlHaulway_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlHaulway.SelectedValue))
            {
                BLL.Haulway haulwayBll = new BLL.Haulway();
                Model.Haulway haulway = haulwayBll.GetModel(Convert.ToInt32(ddlHaulway.SelectedValue));
                if (haulway != null)
                {
                    txtLoadingCapacityRunning.Text = haulway.LoadingCapacityRunning.ToString();
                    txtNoLoadingCapacityRunning.Text = haulway.NoLoadingCapacityRunning.ToString();
                }
            }
        }

        protected void ddlFormula_SelectedIndexChanged(object sender, EventArgs e)
        {
            string val = ddlFormula.SelectedValue;
            switch (val)
            {
                case "1":
                    txtTotalPrice.Text = (Convert.ToDecimal(txtQuantity.Text.Trim()) * Convert.ToDecimal(txtUnitPrice.Text.Trim())).ToString("0.00");
                    break;
                case "2":
                    txtTotalPrice.Text = (Convert.ToDecimal(txtQuantity.Text.Trim()) * Convert.ToDecimal(txtLoadingCapacityRunning.Text.Trim()) * Convert.ToDecimal(txtUnitPrice.Text.Trim())).ToString("0.00");
                    break;
                case "3":
                    txtTotalPrice.Text = (Convert.ToDecimal(txtUnitPrice.Text.Trim())).ToString("0.00");
                    break;
                default:
                    break;
            }
        }

        protected void ddlShipper_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlShipper.SelectedValue))
            {
                BLL.Customer bll = new BLL.Customer();
                Model.Customer m = bll.GetModel(Convert.ToInt32(ddlShipper.SelectedValue));
                if (m != null)
                {
                    txtShipperLinkMan.Text = m.LinkMan;
                    txtShipperLinkTel.Text = m.LinkTel;
                }
            }
        }

        protected void ddlReceiver_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlReceiver.SelectedValue))
            {
                BLL.Customer bll = new BLL.Customer();
                Model.Customer m = bll.GetModel(Convert.ToInt32(ddlReceiver.SelectedValue));
                if (m != null)
                {
                    txtReceiverLinkMan.Text = m.LinkMan;
                    txtReceiverLinkTel.Text = m.LinkTel;
                }
            }
        }

        protected void ddlGoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlGoods.SelectedValue))
            {
                BLL.Goods bll = new BLL.Goods();
                Model.Goods m = bll.GetModel(Convert.ToInt32(ddlGoods.SelectedValue));
                if (m != null)
                {
                    txtUnit.Text = m.Unit;
                }
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Order bll = new BLL.Order();
            Model.Order model = bll.GetModel(_id);

            txtAcceptOrderTime.Text = model.AcceptOrderTime.ToString("yyyy-MM-dd");
            txtArrivedTime.Text = model.ArrivedTime.ToString("yyyy-MM-dd");
            txtQuantity.Text = model.Quantity.ToString();
            chkIsCharteredCar.Checked = model.IsCharteredCar == 1;
            if (!string.IsNullOrEmpty(model.Haulway))
            {
                ddlHaulway.Items.FindByText(model.Haulway).Selected = true;
            }
            
            txtLoadingCapacityRunning.Text = model.LoadingCapacityRunning.ToString();
            txtNoLoadingCapacityRunning.Text = model.NoLoadingCapacityRunning.ToString();
            if (!string.IsNullOrEmpty(model.Formula))
            {
                ddlFormula.Items.FindByText(model.Formula).Selected = true;
            }
            txtUnitPrice.Text = model.UnitPrice.ToString();
            txtTotalPrice.Text = model.TotalPrice.ToString();

            if (!string.IsNullOrEmpty(model.Shipper))
            {
                ddlShipper.Items.FindByText(model.Shipper).Selected = true;
            }
            txtShipperLinkMan.Text = model.ShipperLinkMan;
            txtShipperLinkTel.Text = model.ShipperLinkTel;
            if (!string.IsNullOrEmpty(model.Receiver))
            {
                ddlReceiver.Items.FindByText(model.Receiver).Selected = true;
            }
            txtReceiverLinkMan.Text = model.ReceiverLinkMan;
            txtReceiverLinkTel.Text = model.ReceiverLinkTel;
            txtContractNumber.Text = model.ContractNumber;
            txtBillNumber.Text = model.BillNumber;
            txtWeighbridgeNumber.Text = model.WeighbridgeNumber;
            if (!string.IsNullOrEmpty(model.LoadingAddress))
            {
                ddlLoadingAddress.Items.FindByText(model.LoadingAddress).Selected = true;
            }
            if (!string.IsNullOrEmpty(model.UnloadingAddress))
            {
                ddlUnloadingAddress.Items.FindByText(model.UnloadingAddress).Selected = true;
            }
            if (!string.IsNullOrEmpty(model.SettleAccountsWay))
            {
                ddlSettleAccountsWay.Items.FindByText(model.SettleAccountsWay).Selected = true;
            }
            if (!string.IsNullOrEmpty(model.Goods))
            {
                ddlGoods.Items.FindByText(model.Goods).Selected = true;
            }
            txtUnit.Text = model.Unit;
            txtRemarks.Text = model.Remarks;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.Order model = new Model.Order();
            BLL.Order bll = new BLL.Order();

            model.Code = "No" + DateTime.Now.ToString("yyyyMMddhhmmss");
            model.AcceptOrderTime = Convert.ToDateTime(txtAcceptOrderTime.Text.Trim());
            model.ArrivedTime = Convert.ToDateTime(txtArrivedTime.Text.Trim());
            model.Shipper = ddlShipper.SelectedItem.Text;
            model.ShipperLinkMan = txtShipperLinkMan.Text.Trim();
            model.ShipperLinkTel = txtShipperLinkTel.Text.Trim();
            model.Receiver = ddlReceiver.SelectedItem.Text;
            model.ReceiverLinkMan = txtReceiverLinkMan.Text.Trim();
            model.ReceiverLinkTel = txtReceiverLinkTel.Text.Trim();
            model.ContractNumber = txtContractNumber.Text.Trim();
            model.LoadingAddress = ddlLoadingAddress.SelectedItem.Text;
            model.UnloadingAddress = ddlUnloadingAddress.SelectedItem.Text;
            model.Goods = ddlGoods.SelectedItem.Text;
            model.Unit = txtUnit.Text.Trim();
            model.IsCharteredCar = chkIsCharteredCar.Checked ? 1 : 0;
            model.Quantity = Convert.ToDecimal(txtQuantity.Text.Trim());
            model.DispatchedCount = 0.00M;
            model.Haulway = ddlHaulway.SelectedItem.Text;
            model.LoadingCapacityRunning = Convert.ToDecimal(txtLoadingCapacityRunning.Text.Trim());
            model.NoLoadingCapacityRunning = Convert.ToDecimal(txtNoLoadingCapacityRunning.Text.Trim());
            model.BillNumber = txtBillNumber.Text.Trim();
            model.WeighbridgeNumber = txtWeighbridgeNumber.Text.Trim();
            model.Formula = ddlFormula.SelectedItem.Text;
            model.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
            model.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text.Trim());
            model.SettleAccountsWay = ddlSettleAccountsWay.SelectedValue;
            model.Status = 0;
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加订单:" + model.Code); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Order bll = new BLL.Order();
            Model.Order model = bll.GetModel(_id);

            model.AcceptOrderTime = Convert.ToDateTime(txtAcceptOrderTime.Text.Trim());
            model.ArrivedTime = Convert.ToDateTime(txtArrivedTime.Text.Trim());
            model.Shipper = ddlShipper.SelectedItem.Text;
            model.ShipperLinkMan = txtShipperLinkMan.Text.Trim();
            model.ShipperLinkTel = txtShipperLinkTel.Text.Trim();
            model.Receiver = ddlReceiver.SelectedItem.Text;
            model.ReceiverLinkMan = txtReceiverLinkMan.Text.Trim();
            model.ReceiverLinkTel = txtReceiverLinkTel.Text.Trim();
            model.ContractNumber = txtContractNumber.Text.Trim();
            model.LoadingAddress = ddlLoadingAddress.SelectedItem.Text;
            model.UnloadingAddress = ddlUnloadingAddress.SelectedItem.Text;
            model.Goods = ddlGoods.SelectedItem.Text;
            model.Unit = txtUnit.Text.Trim();
            model.IsCharteredCar = chkIsCharteredCar.Checked ? 1 : 0;
            model.Quantity = Convert.ToDecimal(txtQuantity.Text.Trim());
            model.Haulway = ddlHaulway.SelectedItem.Text;
            model.LoadingCapacityRunning = Convert.ToDecimal(txtLoadingCapacityRunning.Text.Trim());
            model.NoLoadingCapacityRunning = Convert.ToDecimal(txtNoLoadingCapacityRunning.Text.Trim());
            model.BillNumber = txtBillNumber.Text.Trim();
            model.WeighbridgeNumber = txtWeighbridgeNumber.Text.Trim();
            model.Formula = ddlFormula.SelectedItem.Text;
            model.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
            model.TotalPrice = Convert.ToDecimal(txtTotalPrice.Text.Trim());
            model.SettleAccountsWay = ddlSettleAccountsWay.SelectedValue;
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改订单信息:" + model.Code); //记录日志
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
                ChkAdminLevel("order_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改订单成功！", "order_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("order_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加订单成功！", "order_list.aspx", "Success");
            }
        }
    }
}