using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Customer
{
    public partial class customer_edit : Web.UI.ManagePage
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
                if (!new BLL.Customer().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("customer_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            BLL.CustomerType bll = new BLL.CustomerType();
            DataTable dt = bll.GetList(0, strWhere, "Id desc").Tables[0];

            ddlTypeName.Items.Clear();
            ddlTypeName.Items.Add(new ListItem("请选择客户类型...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlTypeName.Items.Add(new ListItem(dr["Name"].ToString(), dr["Name"].ToString()));
            }

            ddlCategory.Items.Clear();
            ddlCategory.Items.Add(new ListItem("不限", ""));
            ddlCategory.Items.Add(new ListItem("托运方", "托运方"));
            ddlCategory.Items.Add(new ListItem("收货方", "收货方"));
            ddlCategory.Items.Add(new ListItem("托收两者", "托收两者"));
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Customer bll = new BLL.Customer();
            Model.Customer model = bll.GetModel(_id);

            ddlTypeName.SelectedValue = model.TypeName;
            txtShortName.Text = model.ShortName;
            txtFullName.Text = model.FullName;
            ddlCategory.SelectedValue = model.Category;
            txtCode.Text = model.Code;
            txtLinkMan.Text = model.LinkMan;
            txtLinkTel.Text = model.LinkTel;
            txtLinkAddress.Text = model.LinkAddress;
            txtMobileNumber.Text = model.MobileNumber;
            txtTaxRegistrationNumber.Text = model.TaxRegistrationNumber;
            txtRemarks.Text = model.Remarks;
          
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.Customer model = new Model.Customer();
            BLL.Customer bll = new BLL.Customer();

            model.TypeName = ddlTypeName.SelectedValue;
            model.ShortName = txtShortName.Text.Trim();
            model.FullName = txtFullName.Text.Trim();
            model.Category = ddlCategory.SelectedValue;
            model.Code = string.IsNullOrEmpty(txtCode.Text.Trim()) ? "" : txtCode.Text.Trim();
            model.LinkMan = txtLinkMan.Text.Trim();
            model.LinkTel = txtLinkTel.Text.Trim();
            model.LinkAddress = txtLinkAddress.Text.Trim();
            model.MobileNumber = txtMobileNumber.Text.Trim();
            model.TaxRegistrationNumber = txtTaxRegistrationNumber.Text.Trim();
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加客户:" + model.ShortName); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Customer bll = new BLL.Customer();
            Model.Customer model = bll.GetModel(_id);

            model.TypeName = ddlTypeName.SelectedValue;
            model.ShortName = txtShortName.Text.Trim();
            model.FullName = txtFullName.Text.Trim();
            model.Category = ddlCategory.SelectedValue;
            model.Code = string.IsNullOrEmpty(txtCode.Text.Trim()) ? "" : txtCode.Text.Trim();
            model.LinkMan = txtLinkMan.Text.Trim();
            model.LinkTel = txtLinkTel.Text.Trim();
            model.LinkAddress = txtLinkAddress.Text.Trim();
            model.MobileNumber = txtMobileNumber.Text.Trim();
            model.TaxRegistrationNumber = txtTaxRegistrationNumber.Text.Trim();
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改客户信息:" + model.ShortName); //记录日志
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
                ChkAdminLevel("customer_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改客户成功！", "customer_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("customer_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加客户成功！", "customer_list.aspx", "Success");
            }
        }
    }
}