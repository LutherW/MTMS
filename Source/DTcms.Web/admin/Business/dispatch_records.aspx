<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dispatch_records.aspx.cs" Inherits="DTcms.Web.admin.Business.dispatch_records" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>发车记录</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/jquery.browser.js"></script>
    <script type="text/javascript" charset="utf-8" src="../js/jquery.jqprint-0.3.js"></script>
    <link href="../../css/pagination.css" rel="stylesheet" type="text/css" />
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {

        });
        function print() {
            $("#print_content").jqprint();
        }

    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>发车记录</span>
            <i class="arrow"></i>
            <span>发车记录列表</span>
        </div>
        <!--/导航栏-->

        <!--工具栏-->
        <div class="toolbar-wrap">
            <div id="floatHead" class="toolbar">
                <div class="l-list">
                    <ul class="icon-list">
                        <li><a class="all" href="javascript:void(0);" onclick="print();"><i></i><span>打印</span></a></li>
                    </ul>
                    <div class="menu-list">
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlCarNumber" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCarNumber_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlCustomer1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer1_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <%--<span style="font-size:12px;">
                            收货方:
                        </span>
                        <div class="rule-single-select">
                            <asp:DropDownList ID="ddlCustomer2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCustomer2_SelectedIndexChanged"></asp:DropDownList>
                        </div>--%>
                    </div>
                </div>
                <div class="r-list">
                    <div style="float: left; margin-right: 10px; font-size: 12px;">
                        回车时间：<asp:TextBox ID="txtBeginTime" runat="server" CssClass="input" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox>
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
        <div class="table-container">
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
                        <tr>
                            <th width="5%">选择</th>
                            <th align="left" width="7%">出车时间</th>
                            <th align="left" width="7%">回车时间</th>
                            <th width="8%">托运方</th>
                            <th width="8%">收货方</th>
                            <th align="left" width="7%">签单时间</th>
                            <th width="5%">承运货物</th>
                            <th width="5%">数量</th>
                            <th width="8%">车号</th>
                            <th width="5%">司机</th>
                            <th width="5%">单价</th>
                            <th width="5%">总运费</th>
                            <th width="5%">回单日期</th>
                            <th width="5%">状态</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center">
                            <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" Style="vertical-align: middle;" />
                            <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />
                        </td>
                        <td><%#string.IsNullOrEmpty(Eval("FactDispatchTime").ToString()) ? "" : Convert.ToDateTime(Eval("FactDispatchTime")).ToString("yyyy/MM/dd")%></td>
                        <td><%#string.IsNullOrEmpty(Eval("FactBackTime").ToString()) ? "" : Convert.ToDateTime(Eval("FactBackTime")).ToString("yyyy/MM/dd")%></td>
                        <td align="center"><%#Eval("Shipper")%></td>
                        <td align="center"><%#Eval("Receiver")%></td>
                        <td align="center"><%#string.IsNullOrEmpty(Eval("AcceptOrderTime").ToString()) ? "" : Convert.ToDateTime(Eval("AcceptOrderTime")).ToString("yyyy/MM/dd")%></td>
                        <td align="center"><%#Eval("Goods")%></td>
                        <td align="center"><%#Eval("FactDispatchCount")%></td>
                        <td align="center"><%#Eval("CarNumber")%></td>
                        <td align="center"><%#Eval("Driver")%></td>
                        <td align="center">￥<%#string.Format("{0:N2}", Eval("UnitPrice"))%></td>
                        <td align="center">￥<%#string.Format("{0:N2}", Eval("TotalPrice"))%></td>
                        <td align="center"><%#string.IsNullOrEmpty(Eval("ReceiptTime").ToString()) ? "" : Convert.ToDateTime(Eval("ReceiptTime")).ToString("yyyy/MM/dd")%></td>
                        <td align="center"><%#GetStatus(Eval("Status").ToString())%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"15\">暂无记录</td></tr>" : ""%>
</table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
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
