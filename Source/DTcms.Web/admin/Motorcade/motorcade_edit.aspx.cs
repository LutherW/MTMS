using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Motorcade
{
    public partial class motorcade_edit : Web.UI.ManagePage
    {
        private string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
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
                if (!new BLL.Motorcade().Exists(this.id))
                {
                    JscriptMsg("记录不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("motorcade_list", DTEnums.ActionEnum.View.ToString()); //检查权限
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Motorcade bll = new BLL.Motorcade();
            Model.Motorcade model = bll.GetModel(_id);

            txtName.Text = model.Name;
            txtCode.Text = model.Code;
            chkIsOutOfTeam.Checked = model.IsOutOfTeam;
            txtLinkMan.Text = model.LinkMan;
            txtLinkTel.Text = model.LinkTel;
            txtLinkAddress.Text = model.LinkAddress;
            txtRemarks.Text = model.Remarks;

        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            Model.Motorcade model = new Model.Motorcade();
            BLL.Motorcade bll = new BLL.Motorcade();

            model.Name = txtName.Text.Trim();
            model.Code = txtCode.Text.Trim();
            model.IsOutOfTeam = chkIsOutOfTeam.Checked;
            model.LinkMan = txtLinkMan.Text.Trim();
            model.LinkTel = txtLinkTel.Text.Trim();
            model.LinkAddress = txtLinkAddress.Text.Trim();
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加车队:" + model.Name); //记录日志
                return true;
            }
            return false;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Motorcade bll = new BLL.Motorcade();
            Model.Motorcade model = bll.GetModel(_id);

            model.Name = txtName.Text.Trim();
            model.Code = txtCode.Text.Trim();
            model.IsOutOfTeam = chkIsOutOfTeam.Checked;
            model.LinkMan = txtLinkMan.Text.Trim();
            model.LinkTel = txtLinkTel.Text.Trim();
            model.LinkAddress = txtLinkAddress.Text.Trim();
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改车队:" + model.Name); //记录日志
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
                ChkAdminLevel("motorcade_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改车队成功！", "motorcade_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("motorcade_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加车队成功！", "motorcade_list.aspx", "Success");
            }
        }
    }
}