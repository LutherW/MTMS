<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="receipt_register.aspx.cs" Inherits="DTcms.Web.admin.Business.receipt_register" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>回单登记</title>
    <script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
    <script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
    <script type="text/javascript" src="../../scripts/datepicker/WdatePicker.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.queue.js"></script>
    <script type="text/javascript" src="../../scripts/swfupload/swfupload.handlers.js"></script>
    <script type="text/javascript" src="../js/layout.js"></script>
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
                    order.unit= $("#unit_" + id).html();
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
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="receipt_register_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>回单登记列表</span>
            <i class="arrow"></i>
            <span>回单登记</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">登记信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>登记时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtReceiptTime" runat="server" CssClass="input date normal" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>备注</dt>
                <dd>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                </dd>
            </dl>
        </div>
        <!--/内容-->

        <!--工具栏-->
        <div class="page-footer">
            <div class="btn-list">
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
