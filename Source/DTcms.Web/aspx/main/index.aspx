<%@ Page Language="C#" AutoEventWireup="true" Inherits="DTcms.Web.UI.Page.index" ValidateRequest="false" %>
<%@ Import namespace="System.Collections.Generic" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="DTcms.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by DTcms Template Engine at 2014/3/22 1:20:53.
		本页面代码由DTcms模板引擎生成于 2014/3/22 1:20:53. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n<title>");
	templateBuilder.Append(Utils.ObjectToStr(config.webtitle));
	templateBuilder.Append("</title>\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webkeyword));
	templateBuilder.Append("\" name=\"keywords\" />\r\n<meta content=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webdescription));
	templateBuilder.Append("\" name=\"description\" />\r\n<link media=\"screen\" type=\"text/css\" href=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/css/style.css\" rel=\"stylesheet\">\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/browser_redirect.ashx\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery-1.10.2.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("scripts/jquery/jquery.KinSlideshow-1.2.1.min.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\" src=\"");
	templateBuilder.Append("/templates/green");
	templateBuilder.Append("/js/base.js\"></");
	templateBuilder.Append("script>\r\n<script type=\"text/javascript\">\r\n    $(function () {\r\n        $(\"#focusNews\").KinSlideshow();\r\n    })\r\n</");
	templateBuilder.Append("script>\r\n</head>\r\n\r\n<body>\r\n<!--Header-->\r\n");

	templateBuilder.Append("<div class=\"header\">\r\n  <div class=\"header_inner\">\r\n    <h1 class=\"logo\">\r\n      <a title=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webname));
	templateBuilder.Append("\" href=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.weburl));
	templateBuilder.Append("\">");
	templateBuilder.Append(Utils.ObjectToStr(config.webname));
	templateBuilder.Append("</a>\r\n    </h1>\r\n    <ul class=\"nav\">\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">首页</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\">新闻资讯</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\">购物商城</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\">图片分享</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\">资源下载</a></li>\r\n    </ul>\r\n    <div class=\"search\">\r\n      <input id=\"keywords\" name=\"keywords\" class=\"input\" type=\"text\" x-webkit-speech=\"\" autofocus=\"\" placeholder=\"输入回车搜索\" onkeydown=\"if(event.keyCode==13){SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');return false};\" />\r\n      <input class=\"submit\" type=\"submit\" value=\"搜索\" onclick=\"SiteSearch('");
	templateBuilder.Append(linkurl("search"));

	templateBuilder.Append("', '#keywords');\" />\r\n    </div>\r\n    <script type=\"text/javascript\">\r\n        $.ajax({\r\n            type: \"POST\",\r\n            url: \"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=user_check_login\",\r\n            dataType: \"json\",\r\n            timeout: 20000,\r\n            success: function (data, textStatus) {\r\n                if (data.status == 1) {\r\n                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","exit"));

	templateBuilder.Append("\">退出</a></li>');\r\n                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("usercenter","index"));

	templateBuilder.Append("\">会员中心</a></li>');\r\n                } else {\r\n                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("register"));

	templateBuilder.Append("\">注册</a></li>');\r\n                    $(\"#menu\").append('<li><a href=\"");
	templateBuilder.Append(linkurl("login"));

	templateBuilder.Append("\">登录</a></li>');\r\n                }\r\n            }\r\n        });\r\n    </");
	templateBuilder.Append("script>\r\n    <ul id=\"menu\" class=\"menu\">\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\">联系我们</a></li>\r\n      <li><a href=\"");
	templateBuilder.Append(linkurl("shopping","cart"));

	templateBuilder.Append("\">购物车<script type=\"text/javascript\" src=\"");
	templateBuilder.Append(Utils.ObjectToStr(config.webpath));
	templateBuilder.Append("tools/submit_ajax.ashx?action=view_cart_count\"></");
	templateBuilder.Append("script>件</a></li>\r\n    </ul>\r\n  </div>\r\n</div>");


	templateBuilder.Append("\r\n<!--/Header-->\r\n\r\n<div class=\"boxwrap\">\r\n  <div class=\"left710\">\r\n    <div class=\"pad20\">\r\n      <!--Focus-->\r\n      <div class=\"left300\">\r\n        <div id=\"focusNews\" class=\"ifocus\">\r\n          ");
	DataTable focusNews = get_article_list("news", 0, 8, "status=0 and is_slide=1");

	foreach(DataRow dr in focusNews.Rows)
	{

	templateBuilder.Append("\r\n          <a title=\"" + Utils.ObjectToStr(dr["title"]) + "\" target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\"><img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" alt=\"" + Utils.ObjectToStr(dr["title"]) + "\" /></a>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </div>\r\n      </div>\r\n      <!--/Focus-->\r\n      <!--Top News-->\r\n      <div class=\"right350 icnts\">\r\n        ");
	DataTable topNews = get_article_list("news", 0, 2, "status=0 and is_top=1");

	int newsdr1__loop__id=0;
	foreach(DataRow newsdr1 in topNews.Rows)
	{
		newsdr1__loop__id++;


	if (newsdr1__loop__id==1)
	{

	templateBuilder.Append("\r\n        <h3 class=\"tit\"><a title=\"" + Utils.ObjectToStr(newsdr1["title"]) + "\" href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(newsdr1["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(newsdr1["title"]) + "</a></h3>\r\n        ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n        <ul class=\"list\">\r\n          ");
	DataTable redNews = get_article_list("news", 0, 8, "status=0 and is_red=1");

	int newsdr11__loop__id=0;
	foreach(DataRow newsdr11 in redNews.Rows)
	{
		newsdr11__loop__id++;


	if (newsdr11__loop__id<=4)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <span>[");
	templateBuilder.Append(get_category_title(Utils.StrToInt(Utils.ObjectToStr(newsdr11["category_id"]), 0), "").ToString());

	templateBuilder.Append("]</span>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(newsdr11["id"])));

	templateBuilder.Append("\" title=\"" + Utils.ObjectToStr(newsdr11["title"]) + "\">" + Utils.ObjectToStr(newsdr11["title"]) + "</a>\r\n          </li>\r\n          ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n        ");
	int newsdr2__loop__id=0;
	foreach(DataRow newsdr2 in topNews.Rows)
	{
		newsdr2__loop__id++;


	if (newsdr2__loop__id==2)
	{

	templateBuilder.Append("\r\n        <h3 class=\"tit\"><a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(newsdr2["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(newsdr2["title"]) + "</a></h3>\r\n        ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n        <ul class=\"list last\">\r\n          ");
	int newsdr12__loop__id=0;
	foreach(DataRow newsdr12 in redNews.Rows)
	{
		newsdr12__loop__id++;


	if (newsdr12__loop__id>4)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <span>[");
	templateBuilder.Append(get_category_title(Utils.StrToInt(Utils.ObjectToStr(newsdr12["category_id"]), 0), "").ToString());

	templateBuilder.Append("]</span>\r\n            <a href=\"");
	templateBuilder.Append(linkurl("news_show",Utils.ObjectToStr(newsdr12["id"])));

	templateBuilder.Append("\" title=\"" + Utils.ObjectToStr(newsdr12["title"]) + "\">" + Utils.ObjectToStr(newsdr12["title"]) + "</a>\r\n          </li>\r\n          ");
	}	//end for if

	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n      <!--/Top News-->\r\n      <div class=\"clear\"></div>\r\n    </div>\r\n    <!--Hot Goods-->\r\n    <div class=\"clear\"></div>\r\n    <div class=\"igoods_box\">\r\n      <div class=\"igoods_list\">\r\n        <dl class=\"head\">\r\n          <dt>购物商城</dt>\r\n          <dd>\r\n            <ul class=\"sub_nav\">\r\n              ");
	DataTable category_list1 = get_category_child_list("goods", 0);

	int cdr1__loop__id=0;
	foreach(DataRow cdr1 in category_list1.Rows)
	{
		cdr1__loop__id++;


	templateBuilder.Append("\r\n              <li class=\"n");
	templateBuilder.Append(cdr1__loop__id.ToString());

	templateBuilder.Append("\"><a href=\"");
	templateBuilder.Append(linkurl("goods_list",Utils.ObjectToStr(cdr1["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(cdr1["title"]) + "</a></li>\r\n              ");
	}	//end for if

	templateBuilder.Append("\r\n            </ul>\r\n          </dd>\r\n        </dl>\r\n        \r\n        <ul class=\"list\">\r\n          ");
	DataTable redGoods = get_article_list("goods", 0, 8, "status=0 and is_red=1");

	foreach(DataRow dr in redGoods.Rows)
	{

	templateBuilder.Append("\r\n          <li>\r\n            <a class=\"pic\" href=\"");
	templateBuilder.Append(linkurl("goods_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\"><img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" alt=\"" + Utils.ObjectToStr(dr["title"]) + "\" /></a>\r\n            <div class=\"info\">\r\n              <a class=\"name\" href=\"");
	templateBuilder.Append(linkurl("goods_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(dr["title"]) + "</a>\r\n              <div class=\"price\">\r\n                <span>价格：</span>\r\n                <strong>￥" + Utils.ObjectToStr(dr["sell_price"]) + "</strong>\r\n              </div>\r\n            </div>\r\n          </li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </div>\r\n    </div>\r\n    <!--/Hot Goods-->\r\n  </div>\r\n  \r\n  <div class=\"left264\">\r\n    <!--Red Download-->\r\n    <div class=\"idown_list\">\r\n      <h3>推荐资源</h3>\r\n      <ul>\r\n        ");
	DataTable redDown = get_article_list("down", 0, 5, "is_red=1 and img_url<>''");

	foreach(DataRow dr in redDown.Rows)
	{

	templateBuilder.Append("\r\n        <li><a href=\"");
	templateBuilder.Append(linkurl("down_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\"> <img border=\"0\" alt=\"" + Utils.ObjectToStr(dr["title"]) + "\" src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" /> </a> <a href=\"");
	templateBuilder.Append(linkurl("down_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(dr["title"]) + "</a> <br />\r\n          <span class=\"date\">更新：");	templateBuilder.Append(Utils.ObjectToDateTime(Utils.ObjectToStr(dr["add_time"])).ToString("yyyy-MM-dd"));

	templateBuilder.Append("</span> <br />\r\n          <a class=\"down\" href=\"");
	templateBuilder.Append(linkurl("down_show",Utils.ObjectToStr(dr["id"])));

	templateBuilder.Append("\">下载</a>\r\n        </li>\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n      </ul>\r\n    </div>\r\n    <!--/Red Download-->\r\n    <!--Hot Goods-->\r\n    <div class=\"isidebar\">\r\n      <h3>热门商品</h3>\r\n      <div class=\"list\">\r\n        <ol> \r\n          ");
	DataTable hotGoods = get_article_list("goods", 0, 10, "status=0 and is_hot=1", "click desc,id desc");

	int goodsdr2__loop__id=0;
	foreach(DataRow goodsdr2 in hotGoods.Rows)
	{
		goodsdr2__loop__id++;


	if (goodsdr2__loop__id==1)
	{

	templateBuilder.Append("\r\n          <li class=\"active\" onmouseover=\"ToggleProps(this, 'active');\">\r\n          ");
	}
	else
	{

	templateBuilder.Append("\r\n          <li onmousemove=\"ToggleProps(this, 'active');\">\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n            <i class=\"num\">");
	templateBuilder.Append(goodsdr2__loop__id.ToString());

	templateBuilder.Append("</i>\r\n            <div class=\"photo\">\r\n              <a title=\"" + Utils.ObjectToStr(goodsdr2["title"]) + "\" href=\"");
	templateBuilder.Append(linkurl("goods_show",Utils.ObjectToStr(goodsdr2["id"])));

	templateBuilder.Append("\"><img src=\"" + Utils.ObjectToStr(goodsdr2["img_url"]) + "\" alt=\"" + Utils.ObjectToStr(goodsdr2["title"]) + "\"></a>\r\n            </div>\r\n            <div class=\"props\">\r\n              <p class=\"name\"><a title=\"" + Utils.ObjectToStr(goodsdr2["title"]) + "\" href=\"");
	templateBuilder.Append(linkurl("goods_show",Utils.ObjectToStr(goodsdr2["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(goodsdr2["title"]) + "</a></p>\r\n              <p class=\"price\">¥" + Utils.ObjectToStr(goodsdr2["sell_price"]) + "</p>\r\n              <p class=\"button\"><a class=\"ibtn\" href=\"");
	templateBuilder.Append(linkurl("goods_show",Utils.ObjectToStr(goodsdr2["id"])));

	templateBuilder.Append("\">立即购买</a></p>\r\n            </div>\r\n          </li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n          </ol>\r\n      </div>\r\n    </div>\r\n    <!--Hot Goods-->\r\n  </div>\r\n</div>\r\n\r\n<div class=\"clear\"></div>\r\n<div class=\"boxwrap\" style=\"border-top:0;\">\r\n  <!--Red Photo-->\r\n  <div class=\"iphoto_list\">\r\n    <dl class=\"head\">\r\n      <dt>图片分享</dt>\r\n      <dd>\r\n        <ul class=\"sub_nav\">\r\n          ");
	DataTable category_list2 = get_category_child_list("photo", 0);

	int cdr2__loop__id=0;
	foreach(DataRow cdr2 in category_list2.Rows)
	{
		cdr2__loop__id++;


	templateBuilder.Append("\r\n          <li class=\"n");
	templateBuilder.Append(cdr2__loop__id.ToString());

	templateBuilder.Append("\"><a href=\"");
	templateBuilder.Append(linkurl("photo_list",Utils.ObjectToStr(cdr2["id"])));

	templateBuilder.Append("\">" + Utils.ObjectToStr(cdr2["title"]) + "</a></li>\r\n          ");
	}	//end for if

	templateBuilder.Append("\r\n        </ul>\r\n      </dd>\r\n    </dl>\r\n    <div class=\"clear\"></div>\r\n    <div class=\"list\">\r\n      <ul>\r\n        ");
	DataTable redPhoto = get_article_list("photo", 0, 12, "status=0 and is_red=1");

	int photodr1__loop__id=0;
	foreach(DataRow photodr1 in redPhoto.Rows)
	{
		photodr1__loop__id++;


	templateBuilder.Append("\r\n        <li class=\"a");
	templateBuilder.Append(photodr1__loop__id.ToString());

	templateBuilder.Append("\">\r\n          <img src=\"" + Utils.ObjectToStr(photodr1["img_url"]) + "\" alt=\"" + Utils.ObjectToStr(photodr1["title"]) + "\" />\r\n          <a title=\"" + Utils.ObjectToStr(photodr1["title"]) + "\" href=\"");
	templateBuilder.Append(linkurl("photo_show",Utils.ObjectToStr(photodr1["id"])));

	templateBuilder.Append("\"><strong>" + Utils.ObjectToStr(photodr1["title"]) + "</strong><br><span>");
	templateBuilder.Append(Utils.DropHTML(Utils.ObjectToStr(photodr1["zhaiyao"]),28));

	templateBuilder.Append("</span><br>查看详情</a><i class=\"absbg\"></i>\r\n        </li>\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n      </ul>\r\n    </div>\r\n  </div>\r\n  <!--/Red Photo-->\r\n  <!--Links-->\r\n  <div class=\"ilink_list\">\r\n    <h3><span class=\"graylink\"><a href=\"");
	templateBuilder.Append(linkurl("link"));

	templateBuilder.Append("\">更多...</a></span>友情链接</h3>\r\n    <p class=\"txt\">\r\n      ");
	DataTable linkList1 = get_plugin_method("DTcms.Web.Plugin.Link", "link", "get_link_list", 0, "is_lock=0 and is_image=0 and is_red=1");

	foreach(DataRow dr in linkList1.Rows)
	{

	templateBuilder.Append("\r\n      <a target=\"_blank\" href=\"" + Utils.ObjectToStr(dr["site_url"]) + "\">" + Utils.ObjectToStr(dr["title"]) + "</a> | \r\n      ");
	}	//end for if

	templateBuilder.Append("\r\n    </p>\r\n    <div class=\"img\">\r\n      <ul>\r\n        ");
	DataTable linkList2 = get_plugin_method("DTcms.Web.Plugin.Link", "link", "get_link_list", 9, "is_lock=0 and is_image=1 and is_red=1");

	foreach(DataRow dr in linkList2.Rows)
	{

	templateBuilder.Append("\r\n        <li><a target=\"_blank\" href=\"" + Utils.ObjectToStr(dr["site_url"]) + "\" title=\"" + Utils.ObjectToStr(dr["title"]) + "\"><img src=\"" + Utils.ObjectToStr(dr["img_url"]) + "\" width=\"88\" height=\"31\" /></a></li>\r\n        ");
	}	//end for if

	templateBuilder.Append("\r\n      </ul>\r\n      <div class=\"clear\"></div>\r\n    </div>\r\n  </div>\r\n  <!--/Links-->\r\n</div>\r\n\r\n<!--Footer-->\r\n");

	templateBuilder.Append("<div class=\"footer\">\r\n  <div class=\"footer_inner\">\r\n    <div class=\"foot_nav\">\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("index"));

	templateBuilder.Append("\">首 页</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("content","about"));

	templateBuilder.Append("\">关于我们</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("news"));

	templateBuilder.Append("\">新闻资讯</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("goods"));

	templateBuilder.Append("\">购物商城</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("down"));

	templateBuilder.Append("\">资源下载</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("photo"));

	templateBuilder.Append("\">图片分享</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("feedback"));

	templateBuilder.Append("\">留言反馈</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("link"));

	templateBuilder.Append("\">友情链接</a>|\r\n      <a target=\"_blank\" href=\"");
	templateBuilder.Append(linkurl("content","contact"));

	templateBuilder.Append("\">联系我们</a>|\r\n    </div>\r\n    <div class=\"clear\"></div>\r\n    <div class=\"copyright\">\r\n      <p>版权所有 动力启航软件工作室 粤ICP备11064298号 版本：V");
	templateBuilder.Append(Utils.GetVersion().ToString());

	templateBuilder.Append(" © Copyright 2009 - 2011. dtcms.net. All Rights Reserved. <script src=\"http://s24.cnzz.com/stat.php?id=1996164&web_id=1996164&show=pic\" language=\"JavaScript\"></");
	templateBuilder.Append("script>&nbsp; </p>\r\n    </div>\r\n  </div>\r\n</div>");


	templateBuilder.Append("\r\n<!--/Footer-->\r\n</body>\r\n</html>");
	Response.Write(templateBuilder.ToString());
}
</script>
