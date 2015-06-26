using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Web;

namespace DTcms.Web.tools
{
    /// <summary>
    /// Motorcade 的摘要说明
    /// </summary>
    public class Motorcade : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = DTRequest.GetQueryString("action");

            switch (action)
            {
                case "details": //验证扩展字段是否重复
                    Details(context);
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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}