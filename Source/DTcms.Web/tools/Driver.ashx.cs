using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Web;

namespace DTcms.Web.tools
{
    /// <summary>
    /// Driver 的摘要说明
    /// </summary>
    public class Driver : IHttpHandler
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
            string carNumber = DTRequest.GetQueryString("carNumber");
            if (string.IsNullOrEmpty(carNumber))
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"无效的车号！\"}");
                return;
            }
            try
            {
                Model.Driver model = new BLL.Driver().GetModel(carNumber);
                if (model != null)
                {
                    context.Response.Write("{\"status\": 1, \"msg\": \"获取成功！\", \"name\": \"" + model.RealName + "\", \"id\": \"" + model.Id + "\", \"idCardNumber\": \"" + model.IdCardNumber + "\", \"linkTel\": \"" + model.LinkTel + "\", \"linkAddress\": \"" + model.LinkAddress + "\"}");
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