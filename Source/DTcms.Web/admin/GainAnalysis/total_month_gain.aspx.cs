using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.GainAnalysis
{
    public partial class total_month_gain : Web.UI.ManagePage
    {
        protected string _beginTime;
        protected string _endTime;

        protected decimal totalIncome = 0.00M;
        protected decimal totalFactRepayment = 0.00M;
        protected decimal totalCarriage = 0.00M;
        protected decimal totalAdvance = 0.00M;
        protected decimal totalGain = 0.00M;
        protected decimal totalCostItem = 0.00M;
        protected string costItem = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            ChkAdminLevel("total_month_gain", DTEnums.ActionEnum.View.ToString()); //检查权限
            _beginTime = DTRequest.GetQueryString("beginTime");
            _endTime = DTRequest.GetQueryString("endTime");

            if (!Page.IsPostBack)
            {
                RptBind();
            }
        }

        #region 数据绑定=================================
        private void RptBind()
        {
            string sql = " Status = 3 ";
            if (!string.IsNullOrEmpty(_beginTime))
            {
                sql += " AND FactBackTime >= '" + _beginTime + "' ";
                txtBeginTime.Text = _beginTime;
            }
            else 
            {
                sql += " AND FactBackTime >= '" + DateTime.Now.AddMonths(-1) + "' ";
                txtBeginTime.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
            }
            if (!string.IsNullOrEmpty(_endTime))
            {
                sql += " AND FactBackTime <= '" + _endTime + "' ";
                txtEndTime.Text = _endTime;
            }
            else
            {
                sql += " AND FactBackTime <= '" + DateTime.Now + "' ";
                txtEndTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
            string ids = string.Empty;
            BLL.TransportOrder bll = new BLL.TransportOrder();
            DataSet tods = bll.GetList(sql);
            if (tods != null && tods.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in tods.Tables[0].Rows)
                {
                    ids += dr["Id"].ToString() + ",";
                    totalFactRepayment += Utils.StrToDecimal(dr["FactRepayment"].ToString(), 0.00M);
                    totalCarriage += Utils.StrToDecimal(dr["Carriage"].ToString(), 0.00M);
                    totalAdvance += Utils.StrToDecimal(dr["Advance"].ToString(), 0.00M);
                }
                if (ids.EndsWith(","))
                {
                    ids = ids.TrimEnd(',');
                }
            }
            if (!string.IsNullOrEmpty(ids))
            {
                BLL.TransportOrderItem itemBll = new BLL.TransportOrderItem();
                DataSet itemds = itemBll.GetList(" TransportOrderId IN (" + ids + ") ");
                if (itemds != null && itemds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in itemds.Tables[0].Rows)
                    {
                        totalIncome += Utils.StrToDecimal(dr["TotalPrice"].ToString(), 0.00M);
                    }
                }

                BLL.Consumption cBll = new BLL.Consumption();
                DataSet cds = cBll.GetSumList(" TransportOrderId IN (" + ids + ") ");
                if (cds != null && cds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in cds.Tables[0].Rows)
                    {
                        totalCostItem += Utils.StrToDecimal(dr["TotalMoney"].ToString(), 0.00M);
                        costItem += "<tr><td width=\"20%\" style=\"text-align:right\">"+dr["Name"].ToString()+"&nbsp;:&nbsp;&nbsp;</td>";
                        costItem += "<td>￥" + string.Format("{0:N2}", dr["TotalMoney"]) + "</td></tr>";
                    }
                }
            }
            //throw new Exception("totalIncome:" + totalIncome.ToString()
            //    + "totalFactRepayment:" + totalFactRepayment.ToString()
            //    + "totalCarriage:" + totalCarriage.ToString()
            //    + "totalAdvance:" + totalAdvance.ToString()
            //    + "totalCostItem:" + totalCostItem.ToString()
            //    );
            totalGain = totalIncome + totalFactRepayment - totalCarriage - totalAdvance - totalCostItem;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("total_month_gain.aspx", "beginTime={0}&endTime={1}",
                txtBeginTime.Text.Trim(), txtEndTime.Text.Trim()));
        }
    }
}