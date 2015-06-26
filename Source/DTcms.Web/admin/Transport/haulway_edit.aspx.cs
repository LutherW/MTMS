using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Transport
{
    public partial class haulway_edit : Web.UI.ManagePage
    {
        //string defaultpassword = "0|0|0|0"; //默认显示密码
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
                if (!new BLL.Haulway().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("haulway_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            BLL.Haulway bll = new BLL.Haulway();
            Model.Haulway model = bll.GetModel(_id);

            txtName.Text = model.Name;
            txtCode.Text = model.Code;
            txtLoadingCapacityRunning.Text = model.LoadingCapacityRunning.ToString();
            txtNoLoadingCapacityRunning.Text = model.NoLoadingCapacityRunning.ToString();
          
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.Haulway model = new Model.Haulway();
            BLL.Haulway bll = new BLL.Haulway();

            model.Name = txtName.Text.Trim();
            model.Code = string.IsNullOrEmpty(txtCode.Text.Trim()) ? model.Name : txtCode.Text.Trim();
            model.LoadingCapacityRunning = Utils.StrToDecimal(txtLoadingCapacityRunning.Text.Trim(), 0.00M);
            model.NoLoadingCapacityRunning = Utils.StrToDecimal(txtNoLoadingCapacityRunning.Text.Trim(), 0.00M);

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加运输路线:" + model.Name); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Haulway bll = new BLL.Haulway();
            Model.Haulway model = bll.GetModel(_id);

            model.Name = txtName.Text.Trim();
            model.Code = string.IsNullOrEmpty(txtCode.Text.Trim()) ? model.Name : txtCode.Text.Trim();
            model.LoadingCapacityRunning = Utils.StrToDecimal(txtLoadingCapacityRunning.Text.Trim(), 0.00M);
            model.NoLoadingCapacityRunning = Utils.StrToDecimal(txtNoLoadingCapacityRunning.Text.Trim(), 0.00M);

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改运输路线信息:" + model.Name); //记录日志
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
                ChkAdminLevel("haulway_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改运输路线成功！", "haulway_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("haulway_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加运输路线成功！", "haulway_list.aspx", "Success");
            }
        }
    }
}