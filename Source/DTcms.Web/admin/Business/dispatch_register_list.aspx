<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dispatch_register_list.aspx.cs" Inherits="DTcms.Web.admin.Business.dispatch_register_list" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>出车登记</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
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
            <span>出车登记</span>
            <i class="arrow"></i>
            <span>待出车登记列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <div class="menu-list">
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlCarNumber" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCarNumber_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="r-list">
                    <div style="float: left; margin-right: 10px; font-size: 12px;">
                        计划出车时间：<asp:TextBox ID="txtBeginTime" runat="server" CssClass="input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
                        -
                        <asp:TextBox ID="txtEndTime" runat="server" CssClass="input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
                    </div>

                    <div style="float: right;">
                        <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
                        <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" OnClick="btnSearch_Click">查询</asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <!--/工具栏-->

        <!--列表-->
        <asp:Repeater ID="rptList" runat="server">
            <HeaderTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                    <tr>
                        <th width="5%">序号</th>
                        <th align="left" width="12%">运输单号</th>
                        <th align="left" width="10%">计划出车时间</th>
                        <th width="8%">车号</th>
                        <th width="8%">司机</th>
                        <th width="10%">托运方</th>
                        <th width="10%">承运货物</th>
                        <th width="10%">装货地址</th>
                        <th>卸货地址</th>
                        <th width="5%">操作</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center"><%#rptList.Items.Count+1%>
                    </td>
                    <td><%#Eval("Code")%></td>
                    <td><%#string.Format("{0:d}", Eval("DispatchTime"))%></td>
                    <td align="center"><%#Eval("CarNumber")%></td>
                    <td align="center"><%#Eval("Driver")%></td>
                    <%#GetTransportOrderItems(Eval("Id").ToString()) %>
                    <td align="center">
                        <%#Eval("Status").ToString().Equals("1") ? "<a href=\"dispatch_print.aspx?action="+DTEnums.ActionEnum.Edit+"&id="+Eval("Id")+"\">打印派车单</a>" : "<a href=\"dispatch_register.aspx?action="+DTEnums.ActionEnum.Edit+"&id="+Eval("Id")+"\">登记</a>" %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"12\">暂无记录</td></tr>" : ""%>
</table>
            </FooterTemplate>
        </asp:Repeater>
        <!--/列表-->

        <!--内容底部-->
        <div class="line20"></div>
        <div class="pagelist">
            <div class="l-btns">
                <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" OnTextChanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
            </div>
            <div id="PageContent" runat="server" class="default"></div>
        </div>
        <!--/内容底部-->
    </form>
</body>
</html>
