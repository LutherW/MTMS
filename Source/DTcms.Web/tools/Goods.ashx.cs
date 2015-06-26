using DTcms.Common;
using System;
using System.Collections.Generic;
using System.Web;

namespace DTcms.Web.tools
{
    /// <summary>
    /// Goods 的摘要说明
    /// </summary>
    public class Goods : IHttpHandler
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
            //context.Response.ContentType = "application/json";
            //int id = DTRequest.GetQueryInt("id");
            //if (id < 1)
            //{
            //    context.Response.Write("{\"status\": 0, \"msg\": \"无效的ID！\"}");
            //    return;
            //}
            //try
            //{
            //    Model.Goods model = new BLL.Goods().GetModel(id);
            //    if (model != null)
            //    {
            //        context.Response.Write("{\"status\": 1, \"msg\": \"获取成功！\", \"name\": \"" + model.Name + "\", \"id\": \"" + model.Id + "\", \"categoryName\": " + model.CategoryName + ", \"unit\": \"" + model.Unit + "\", \"code\": \"" + model.Code + "\"}");
            //    }
            //    else
            //    {
            //        context.Response.Write("{\"status\": 0, \"msg\": \"记录不存在！\"}");
            //    }
            //}
            //catch
            //{
            //    context.Response.Write("{\"status\": 0, \"msg\": \"出现异常！\"}");
            //    return;
            //}
            int id = DTRequest.GetQueryInt("id");
            if (id < 1)
            {
                context.Response.Write("{\"status\": 0, \"msg\": \"无效的ID！\"}");
                return;
            }
            try
            {
                Model.Goods model = new BLL.Goods().GetModel(id);
                if (model != null)
                {
                    context.Response.Write("{\"status\": 1, \"msg\": \"获取成功！\", \"name\": \"" + model.Name + "\", \"id\": \"" + model.Id + "\", \"categoryName\": \"" + model.CategoryName + "\", \"unit\": \"" + model.Unit + "\",\"code\": \"" + model.Code + "\"}");
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