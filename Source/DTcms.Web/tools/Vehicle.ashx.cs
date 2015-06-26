using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;

namespace DTcms.Web.tools
{
    /// <summary>
    /// Vehicle 的摘要说明
    /// </summary>
    public class Vehicle : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = DTRequest.GetQueryString("action");

            switch (action)
            {
                case "details": 
                    Details(context);
                    break;
                case "list": 
                    List(context);
                    break;
            }
        }

        private void Details(HttpContext context)
        {
            int id = DTRequest.GetQueryInt("id");
            if (id < 1)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"无效的ID！\"}");
                return;
            }
            try
            {
                Model.Haulway haulway = new BLL.Haulway().GetModel(id);
                if (haulway != null)
                {
                    context.Response.Write("{\"status\": 1, \"msg\": \"获取成功！\", \"name\": \"" + haulway.Name + "\", \"id\": \"" + haulway.Id + "\", \"loadingCapacityRunning\": " + haulway.LoadingCapacityRunning + ", \"noLoadingCapacityRunning\": \"" + haulway.NoLoadingCapacityRunning + "\", \"code\": \"" + haulway.Code + "\"}");
                }
                else
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"记录不存在！\"}");
                }
            }
            catch
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"出现异常！\"}");
                return;
            }
        }

        private void List(HttpContext context)
        {
            string motorcade = DTRequest.GetQueryString("motorcade");
            if (string.IsNullOrEmpty(motorcade))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"无效的车队名称！\"}");
                return;
            }
            try
            {
                DataSet ds = new BLL.Vehicle().GetList(" MotorcadeName = '" + motorcade + "' ");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("{\"status\": 1, \"msg\": \"获取成功！\",\"vehicles\" : [");
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        sb.Append("{\"carCode\": \"" + dr["CarCode"].ToString() + "\", \"id\": \"" + dr["Id"].ToString() + "\", \"carNumber\": \"" + dr["CarNumber"].ToString() + "\"},");
                    }
                    if (sb.ToString().EndsWith(","))
                    {
                        sb.Remove(sb.Length - 1, 1);
                    }
                    sb.Append("]}");
                    context.Response.Write(sb.ToString());
                }
                else
                {
                    context.Response.Write("{\"status\": 0, \"msg\": \"记录不存在！\"}");
                }
            }
            catch
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"出现异常！\"}");
                return;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}