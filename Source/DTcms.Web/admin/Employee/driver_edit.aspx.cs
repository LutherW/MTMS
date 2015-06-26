using System;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Employee
{
    public partial class driver_edit : Web.UI.ManagePage
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
                if (!new BLL.Driver().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("driver_list", DTEnums.ActionEnum.View.ToString()); //检查权限
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
            BLL.Vehicle bll = new BLL.Vehicle();
            DataTable dt = bll.GetList(0, strWhere, "Id desc").Tables[0];

            ddlCarNumber.Items.Clear();
            ddlCarNumber.Items.Add(new ListItem("请选择所驾车辆...", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlCarNumber.Items.Add(new ListItem(dr["CarCode"].ToString(), dr["CarCode"].ToString()));
            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.Driver bll = new BLL.Driver();
            Model.Driver model = bll.GetModel(_id);

            ddlCarNumber.SelectedValue = model.CarNumber;
            txtRealName.Text = model.RealName;
            txtRealNameCode.Text = model.RealNameCode;
            txtIdCardNumber.Text = model.IdCardNumber;
            txtLinkTel.Text = model.LinkTel;
            txtLinkAddress.Text = model.LinkAddress;
            txtBeganWorkDate.Text = model.BeganWorkDate.ToString("yyyy-MM-dd");
            txtIssuedDate.Text = model.IssuedDate.ToString("yyyy-MM-dd");
            txtAnnualDate.Text = model.AnnualDate.ToString("yyyy-MM-dd");
            txtDrivingLicence.Text = model.DrivingLicence;
            txtDrivingPermitNumber.Text = model.DrivingPermitNumber;
            txtDrivingPermitType.Text = model.DrivingPermitType;
            chkIsDimission.Checked = (model.IsDimission == 1);
            txtRemarks.Text = model.Remarks;
          
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = false;
            Model.Driver model = new Model.Driver();
            BLL.Driver bll = new BLL.Driver();

            model.CarNumber = ddlCarNumber.SelectedValue;
            model.RealName = txtRealName.Text.Trim();
            model.RealNameCode = txtRealNameCode.Text.Trim();
            model.IdCardNumber = txtIdCardNumber.Text.Trim();
            model.LinkTel = txtLinkTel.Text.Trim();
            model.LinkAddress = txtLinkAddress.Text.Trim();
            model.BeganWorkDate = Utils.StrToDateTime(txtBeganWorkDate.Text.Trim());
            model.IssuedDate = Utils.StrToDateTime(txtIssuedDate.Text.Trim());
            model.AnnualDate = Utils.StrToDateTime(txtAnnualDate.Text.Trim());
            model.DrivingLicence = txtDrivingLicence.Text.Trim();
            model.DrivingPermitNumber = txtDrivingPermitNumber.Text.Trim();
            model.DrivingPermitType = txtDrivingPermitType.Text.Trim();
            model.IsDimission = chkIsDimission.Checked ? 1 : 0;
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Add(model) > 0)
            {
                AddAdminLog(DTEnums.ActionEnum.Add.ToString(), "添加司机:" + model.RealName); //记录日志
                result = true;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = false;
            BLL.Driver bll = new BLL.Driver();
            Model.Driver model = bll.GetModel(_id);

            model.CarNumber = ddlCarNumber.SelectedValue;
            model.RealName = txtRealName.Text.Trim();
            model.RealNameCode = txtRealNameCode.Text.Trim();
            model.IdCardNumber = txtIdCardNumber.Text.Trim();
            model.LinkTel = txtLinkTel.Text.Trim();
            model.LinkAddress = txtLinkAddress.Text.Trim();
            model.BeganWorkDate = Utils.StrToDateTime(txtBeganWorkDate.Text.Trim());
            model.IssuedDate = Utils.StrToDateTime(txtIssuedDate.Text.Trim());
            model.AnnualDate = Utils.StrToDateTime(txtAnnualDate.Text.Trim());
            model.DrivingLicence = txtDrivingLicence.Text.Trim();
            model.DrivingPermitNumber = txtDrivingPermitNumber.Text.Trim();
            model.DrivingPermitType = txtDrivingPermitType.Text.Trim();
            model.IsDimission = chkIsDimission.Checked ? 1 : 0;
            model.Remarks = txtRemarks.Text.Trim();

            if (bll.Update(model))
            {
                AddAdminLog(DTEnums.ActionEnum.Edit.ToString(), "修改司机信息:" + model.RealName); //记录日志
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
                ChkAdminLevel("driver_list", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("修改司机成功！", "driver_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("driver_list", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误！", "", "Error");
                    return;
                }
                JscriptMsg("添加司机成功！", "driver_list.aspx", "Success");
            }
        }
    }
}