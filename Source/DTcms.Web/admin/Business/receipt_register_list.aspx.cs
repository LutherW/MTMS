using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.Business
{
    public partial class receipt_register_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string _carNumber;
        protected string _customer1;
        protected string _customer2;
        protected string _beginTime;
        protected string _endTime;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("receipt_register_list", DTEnums.ActionEnum.View.ToString()); //检查权限
            _carNumber = DTRequest.GetQueryString("carNumber");
            _customer1 = DTRequest.GetQueryString("customer1");
            _customer2 = DTRequest.GetQueryString("customer2");
            _beginTime = DTRequest.GetQueryString("beginTime");
            _endTime = DTRequest.GetQueryString("endTime");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量


            if (!Page.IsPostBack)
            {
                TreeBind(""); //绑定类别
                RptBind("Status = 2" + CombSqlTxt(_carNumber, _customer1, _customer2, _beginTime, _endTime, this.keywords), "Id desc");
            }
        }

        #region 绑定组别=================================
        private void TreeBind(string strWhere)
        {
            BLL.Vehicle goodsBll = new BLL.Vehicle();
            DataTable goodsDT = goodsBll.GetList(0, strWhere, "Id desc").Tables[0];

            ddlCarNumber.Items.Clear();
            ddlCarNumber.Items.Add(new ListItem("不限", ""));
            foreach (DataRow dr in goodsDT.Rows)
            {
                this.ddlCarNumber.Items.Add(new ListItem(dr["CarCode"].ToString(), dr["CarCode"].ToString()));
            }
        }
        #endregion

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (!string.IsNullOrEmpty(_carNumber))
            {
                ddlCarNumber.SelectedValue = _carNumber;
            }
            if (!string.IsNullOrEmpty(_beginTime))
            {
                txtBeginTime.Text = _beginTime;
            }
            if (!string.IsNullOrEmpty(_endTime))
            {
                txtEndTime.Text = _endTime;
            }
            this.txtKeywords.Text = this.keywords;
            BLL.TransportOrder bll = new BLL.TransportOrder();
            this.rptList.DataSource = bll.GetTransportOrders(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("receipt_register_list.aspx", "carNumber={0}&customer1={1}&customer2={2}&beginTime={3}&endTime={4}&keywords={5}&page={6}",
                _carNumber, _customer1, _customer2, txtBeginTime.Text, txtEndTime.Text, this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        protected string GetTransportOrderItems(string transportOrderId) 
        {
            BLL.TransportOrderItem itemBll = new BLL.TransportOrderItem();
            string shippers = string.Empty;
            string goods = string.Empty;
            string loadingAddress = string.Empty;
            string unloadingAddress = string.Empty;
            DataSet ds = itemBll.GetList(0, "TransportOrderId = " + transportOrderId + "", "Shipper, Goods, LoadingAddress, UnloadingAddress");
            if (ds != null && ds.Tables[0].Rows.Count  > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    shippers += dr["Shipper"].ToString() + ",";
                    goods += dr["Goods"].ToString() + ",";
                    loadingAddress += dr["LoadingAddress"].ToString() + ",";
                    unloadingAddress += dr["UnloadingAddress"].ToString() + ",";
                }
                shippers = shippers.TrimEnd(',');
                goods = goods.TrimEnd(',');
                loadingAddress = loadingAddress.TrimEnd(',');
                unloadingAddress = unloadingAddress.TrimEnd(',');
            }

            string html = string.Format("<td align=\"center\">{0}</td><td align=\"center\">{1}</td><td align=\"center\">{2}</td><td align=\"center\">{3}</td>",
                shippers, goods, loadingAddress, unloadingAddress);

            return html;
        }

        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string carNumber, string customer1, string customer2, string beginTime, string endTime, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (!string.IsNullOrEmpty(carNumber))
            {
                strTemp.Append(" and CarNumber='" + carNumber + "'");
            }
            if (!string.IsNullOrEmpty(beginTime))
            {
                strTemp.Append(" and FactBackTime>='" + beginTime + "'");
            }
            if (!string.IsNullOrEmpty(endTime))
            {
                strTemp.Append(" and FactBackTime<='" + endTime + "'");
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (MotorcadeName like '%" + _keywords + "%' or Driver like '%" + _keywords + "%' or Code like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回运输单每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("receipt_register_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("receipt_register_list.aspx", "carNumber={0}&customer1={1}&customer2={2}&beginTime={3}&endTime={4}&keywords={5}}",
                _carNumber, _customer1, _customer2,txtBeginTime.Text, txtEndTime.Text, txtKeywords.Text));
        }

        //筛选类别
        protected void ddlCarNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("receipt_register_list.aspx", "carNumber={0}&customer1={1}&customer2={2}&beginTime={3}&endTime={4}&keywords={5}",
                ddlCarNumber.SelectedValue, _customer1, _customer2,_beginTime,_endTime, keywords));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("receipt_register_list_page_size", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("receipt_register_list.aspx", "carNumber={0}&customer1={1}&customer2={2}&beginTime={3}&endTime={4}&keywords={5}",
                _carNumber, _customer1, _customer2,_beginTime,_endTime, this.keywords));
        }


        //批量删除
        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    ChkAdminLevel("receipt_register_list", DTEnums.ActionEnum.Delete.ToString()); //检查权限
        //    int sucCount = 0;
        //    int errorCount = 0;
        //    BLL.TransportOrder bll = new BLL.TransportOrder();
        //    BLL.TransportOrderItem itemBll = new BLL.TransportOrderItem();
        //    for (int i = 0; i < rptList.Items.Count; i++)
        //    {
        //        int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
        //        CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
        //        if (cb.Checked)
        //        {
        //            if (bll.Delete(id))
        //            {
        //                itemBll.DeleteBy(id);
        //                sucCount += 1;
        //            }
        //            else
        //            {
        //                errorCount += 1;
        //            }
        //        }
        //    }
        //    AddAdminLog(DTEnums.ActionEnum.Delete.ToString(), "删除运输单" + sucCount + "条，失败" + errorCount + "条"); //记录日志
        //    JscriptMsg("删除成功" + sucCount + "条，失败" + errorCount + "条！",
        //        Utils.CombUrlTxt("receipt_register_list.aspx", "carNumber={0}&customer1={1}&customer2={2}&keywords={3}", _carNumber, _customer1, _customer2, this.keywords), "Success");
        //}

    }
}