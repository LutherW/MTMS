<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dispatch_print.aspx.cs" Inherits="DTcms.Web.admin.Business.dispatch_print" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>派车单打印</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
    <script type="text/javascript" src="../js/jquery.browser.js"></script>
    <script type="text/javascript" src="../js/jquery.jqprint-0.3.js"></script>
    <link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            //初始化表单验证
            $("#form1").initValidform();

            $("#orders tr[data-name='dispatching'] :checkbox").click(function () {
                var checked = $(this).attr("checked");
                if (checked) {
                    $(this).removeAttr("checked");
                    removeTransportOrderItem($(this).val());
                } else {
                    $(this).attr("checked", "checked");
                    var id = $(this).val();
                    var order = {};
                    order.id = id;
                    order.code = $("#code_" + id).html();
                    order.arrivedTime = $("#arrivedTime_" + id).html();
                    order.shipper = $("#shipper_" + id).html();
                    order.receiver = $("#receiver_" + id).html();
                    order.unit = $("#unit_" + id).html();
                    order.quantity = $("#quantity_" + id).html();
                    order.goods = $("#goods_" + id).html();
                    order.billNumber = $("#billNumber_" + id).html();
                    order.unitPrice = $("#unitPrice_" + id).html();
                    order.totalPrice = $("#totalPrice_" + id).html();
                    addTransportOrderItem(order);
                }
            });

            $("#ddlMotorcade").change(function () {
                var val = $(this).val();
                if (val != "") {
                    $.getJSON("../../tools/Vehicle.ashx", { "action": "list", "motorcade": val }, function (data) {
                        if (data.status == 1) {
                            var options = "";
                            $.each(data.vehicles, function (i, n) {
                                options += "<option value='" + data.vehicles[i].carCode + "'>" + data.vehicles[i].carCode + "</option>"
                            });
                            $("#ddlCarNumber").html(options);
                        }
                    });
                }
            });

            $("#ddlCarNumber").change(function () {
                var val = $(this).val();
                if (val != "") {
                    $.getJSON("../../tools/Driver.ashx", { "action": "details", "carNumber": val }, function (data) {
                        if (data.status == 1) {
                            $("#txtDriver").val(data.name);
                        }
                    });
                } else {
                    $("#txtDriver").val("");
                }
            });
        });

        function addTransportOrderItem(order) {
            if ($("tr[data-value='" + order.id + "']").length == 0) {
                var html = "<tr data-value=\"" + order.id + "\">";
                html += "<td width=\"5%\"><input type=\"hidden\" name=\"orderId\" value=\"" + order.id + "\"/></td>";
                html += "<td align=\"left\">" + order.code + "</td>";
                html += "<td width=\"10%\">" + order.billNumber + "</td>";
                html += "<td width=\"10%\">" + order.shipper + "</td>";
                html += "<td width=\"10%\">" + order.receiver + "</td>";
                html += "<td width=\"10%\">" + order.goods + "</td>";
                html += "<td width=\"9%\" align=\"center\">" + order.unit + "</td>";
                html += "<td width=\"6%\">" + order.quantity + "</td>";
                html += "<td width=\"5%\"><input type=\"text\" name=\"factDispatchCount\" value=\"0.00\"/></td>";
                html += "<td width=\"5%\">" + order.unitPrice + "</td>";
                html += "<td width=\"5%\">" + order.totalPrice + "</td>";
                html += "</tr>";
                $("#transportOrderItems tr[data-name='dispatched']").after(html);
            }
        }

        function removeTransportOrderItem(orderId) {
            $("#transportOrderItems tr").remove("[data-value='" + orderId + "']");
        }

        function print() {
            $("#print_content").jqprint();
        }
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="dispatch_register_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>出车登记列表</span>
            <i class="arrow"></i>
            <span>派车单打印</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->

        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">派车单信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content" id="print_content">
            <table style="margin-top: 15px; width: 100%;">
                <tr style="padding-bottom: 20px;">
                    <td colspan="15" style="text-align: center; font-weight: bold;">派车单信息</td>
                </tr>
                <tr style="padding-bottom: 20px;">
                    <td colspan="15" style="text-align: center; font-weight: bold;height:15px;"></td>
                </tr>
                <tr>
                    <td width="1%"></td>
                    <td align="right" width="8%">运输单号：</td>
                    <td align="left">
                        <asp:Label ID="labCode" runat="server" Text=""></asp:Label></td>
                    <td width="10%" align="right">出车时间：</td>
                    <td align="left"><asp:Label ID="labFactDispatchTime" runat="server" Text=""></asp:Label></td>
                    <td width="9%" align="right">车队：</td>
                    <td align="left"><asp:Label ID="labMotorcadeName" runat="server" Text=""></asp:Label></td>
                    <td width="10%" align="right">车号：</td>
                    <td align="left"><asp:Label ID="labCarNumber" runat="server" Text=""></asp:Label></td>
                    <td width="8%" align="right">司机：</td>
                    <td align="left"><asp:Label ID="labDriver" runat="server" Text=""></asp:Label></td>
                    <td width="10%" align="right">出车领款：</td>
                    <td align="left">￥<asp:Label ID="labAdvance" runat="server" Text=""></asp:Label></td>
                    <td width="8%" align="right">领款人：</td>
                    <td align="left"><asp:Label ID="labPayee" runat="server" Text=""></asp:Label></td>
                </tr>
            </table>
            <table style="margin-top: 15px; width: 100%;">
                <tr style="padding-bottom: 20px;">
                    <td colspan="12" style="text-align: center; font-weight: bold;">承运清单</td>
                </tr>
            </table>
            <table id="transportOrderItems" style="margin-top: 15px; width: 100%; border: none;" class="ltable">
                <tr data-name="dispatched">
                    <td width="1%"></td>
                    <td align="left">订单编号</td>
                    <td width="10%">提单号</td>
                    <td width="10%">托运方</td>
                    <td width="10%">收货方</td>
                    <td width="9%">货物</td>
                    <td width="6%">计量单位</td>
                    <td width="10%">包车/预发/已调</td>
                    <td width="9%">调度计量</td>
                    <td width="5%">单价</td>
                    <td width="5%">总价</td>
                </tr>
                <%=transportOrderItems %>
            </table>
        </div>

        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <input name="btnReturn" type="button" value="打印" class="btn" onclick="print();" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
