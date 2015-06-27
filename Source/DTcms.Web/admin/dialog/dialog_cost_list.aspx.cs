using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.admin.dialog
{
    public partial class dialog_cost_list : Web.UI.ManagePage
    {
        private int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.id = DTRequest.GetQueryInt("id");
            if (!Page.IsPostBack)
            {
                //ChkAdminLevel("store_in_order", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        #region 数据绑定=================================
        private void RptBind()
        {
            BLL.Consumption consumptionBll = new BLL.Consumption();
            DataSet consumptionDS = consumptionBll.GetList(0, "TransportOrderId = " + id + "", "Money");

            this.rptList.DataSource = consumptionDS;
            this.rptList.DataBind();
        }
        #endregion

    }
}