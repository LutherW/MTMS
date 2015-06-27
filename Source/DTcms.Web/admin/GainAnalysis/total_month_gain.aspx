<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="total_month_gain.aspx.cs" Inherits="DTcms.Web.admin.GainAnalysis.total_month_gain" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>总利润统计</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>总利润统计</span>
            <i class="arrow"></i>
            <span>总利润统计列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="r-list">
                    <asp:TextBox ID="txtEndTime" runat="server" CssClass="keyword" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" " />
                    <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search"  OnClick="btnSearch_Click">查询</asp:LinkButton>
                </div>
                <div class="r-list">
                    - <asp:TextBox ID="txtBeginTime" runat="server" CssClass="keyword" Text="" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "/>
                </div>
                <div class="r-list">
                   
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="20%" colspan="2">收入类</th>
            </tr>
            <tr>
                <td width="20%" style="text-align:right">运费&nbsp;:&nbsp;&nbsp;</td>
                <td>￥<%=string.Format("{0:N2}", totalIncome) %></td>
            </tr>
            <tr>
                <td width="20%" style="text-align:right">出车交款&nbsp;:&nbsp;&nbsp;</td>
                <td>￥<%=string.Format("{0:N2}", totalFactRepayment) %></td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="20%" colspan="2">支出类</th>
            </tr>
            <tr>
                <td width="20%" style="text-align:right">司机费用&nbsp;:&nbsp;&nbsp;</td>
                <td>￥<%=string.Format("{0:N2}", totalCarriage) %></td>
            </tr>
            <tr>
                <td width="20%" style="text-align:right">出车支款&nbsp;:&nbsp;&nbsp;</td>
                <td>￥<%=string.Format("{0:N2}", totalAdvance) %></td>
            </tr>
            <%=costItem %>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
            <tr>
                <th width="20%" colspan="2">总利润</th>
            </tr>
            <tr>
                <td width="20%" style="text-align:right">总计&nbsp;:&nbsp;&nbsp;</td>
                <td <%if (totalGain>0) {%> style="color:green"<%}else{ %>style="color:#c00;"<%} %>><b style="font-size:14px;">￥<%=string.Format("{0:N2}", totalGain) %></b></td>
            </tr>
        </table>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <!--/内容底部-->
    </form>
</body>
</html>
