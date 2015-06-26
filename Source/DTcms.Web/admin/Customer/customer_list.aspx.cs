using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Customer
{
    public partial class customer_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string _typeName;
        protected string _categoryName;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("customer_list", DTEnums.ActionEnum.View.ToString()); //检查权限
            _typeName = DTRequest.GetQueryString("typeName");
            _categoryName = DTRequest.GetQueryString("categoryName");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                TreeBind(""); //绑定类别
                RptBind("Id>0" + CombSqlTxt(_typeName, _categoryName, this.keywords), "Id desc");
            }
        }

        #region 绑定组别=================================
        private void TreeBind(string strWhere)
        {
            BLL.CustomerType bll = new BLL.CustomerType();
            DataTable dt = bll.GetList(0, strWhere, "Id desc").Tables[0];

            ddlTypeName.Items.Clear();
            ddlTypeName.Items.Add(new ListItem("不限", ""));
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

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (!string.IsNullOrEmpty(_typeName))
            {
                ddlTypeName.SelectedValue = _typeName;
            }
            if (!string.IsNullOrEmpty(_categoryName))
            {
                ddlCategory.SelectedValue = _categoryName;
            }
            this.txtKeywords.Text = this.keywords;
            BLL.Customer bll = new BLL.Customer();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("customer_list.aspx", "typeName={0}&categoryName={1}&keywords={2}&page={3}",
                _typeName, _categoryName, this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string typeName, string categoryName, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(typeName))
            {
                strTemp.Append(" and TypeName='" + typeName + "'");
            }
            if (!string.IsNullOrEmpty(categoryName))
            {
                strTemp.Append(" and Category='" + categoryName + "'");
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (ShortName like '%" + _keywords + "%' or FullName like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回客户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("customer_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("customer_list.aspx", "typeName={0}&categoryName={1}&keywords={2}",
                _typeName, _categoryName, txtKeywords.Text));
        }

        //筛选类别
        protected void ddlTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("customer_list.aspx", "typeName={0}&categoryName={1}&keywords={2}",
                ddlTypeName.SelectedValue, _categoryName, this.keywords));
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("customer_list.aspx", "typeName={0}&categoryName={1}&keywords={2}",
                _typeName, ddlCategory.SelectedValue, this.keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("customer_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("customer_list.aspx", "typeName={0}&categoryName={1}&keywords={2}",
                _typeName, _categoryName, this.keywords));
        }


        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("customer_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            int sucCount = 0;
            int errorCount = 0;
            BLL.Customer bll = new BLL.Customer();
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
            AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除客户" + sucCount + "条，失败" + errorCount + "条"); //记录日志
            JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
                Utils.CombUrlTxt("customer_list.aspx", "typeName={0}&categoryName={1}&keywords={2}", _typeName, _categoryName, this.keywords), "Success");
        }

    }
}