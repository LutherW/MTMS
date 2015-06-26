using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Vehicle
{
    public partial class vehicle_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string _motorcadeName;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("vehicle_list", DTEnums.ActionEnum.View.ToString()); //检查权限
            this._motorcadeName = DTRequest.GetQueryString("motorcadeName");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                TreeBind(""); //绑定类别
                RptBind("Id>0" + CombSqlTxt(this._motorcadeName, this.keywords), "Id desc");
            }
        }

        #region 绑定组别=================================
        private void TreeBind(string strWhere)
        {
            BLL.Motorcade bll = new BLL.Motorcade();
            DataTable dt = bll.GetList(0, strWhere, "Id desc").Tables[0];

            this.ddlMotorcadeName.Items.Clear();
            this.ddlMotorcadeName.Items.Add(new ListItem("不限", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlMotorcadeName.Items.Add(new ListItem(dr["Name"].ToString(), dr["Name"].ToString()));
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (!string.IsNullOrEmpty(_motorcadeName))
            {
                this.ddlMotorcadeName.SelectedValue = this._motorcadeName;
            }
            this.txtKeywords.Text = this.keywords;
            BLL.Vehicle bll = new BLL.Vehicle();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("vehicle_list.aspx", "motorcadeName={0}&keywords={1}&page={2}",
                this._motorcadeName, this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string motorcadeName, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(motorcadeName))
            {
                strTemp.Append(" and MotorcadeName='" + motorcadeName+"'");
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (CarCode like '%" + _keywords + "%' or CarNumber like '%" + _keywords + "%' or MotorcadeName like '%" + _keywords + "%' or MotorcycleType like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回车辆每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("vehicle_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("vehicle_list.aspx", "motorcadeName={0}&keywords={1}",
                this._motorcadeName.ToString(), txtKeywords.Text));
        }

        //筛选类别
        protected void ddlMotorcadeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("vehicle_list.aspx", "motorcadeName={0}&keywords={1}",
                ddlMotorcadeName.SelectedValue, this.keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("vehicle_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("vehicle_list.aspx", "motorcadeName={0}&keywords={1}",
                this._motorcadeName.ToString(), this.keywords));
        }


        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("vehicle_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.Vehicle bll = new BLL.Vehicle();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    if (bll.Delete(id))
                    {
                        sucCount += 1;
                    }
                    else
                    {
                        errorCount += 1;
                    }
                }
            }
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除车辆" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
                Utils.CombUrlTxt("vehicle_list.aspx", "motorcadeName={0}&keywords={1}", this._motorcadeName.ToString(), this.keywords), "Success");
        }

    }
}