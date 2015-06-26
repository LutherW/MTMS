<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="expenses_register.aspx.cs" Inherits="DTcms.Web.admin.Business.expenses_register" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>回车报账</title>
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
                html += "<td width=\"9%\">" + order.unit + "</td>";
                html += "<td width=\"6%\">" + order.quantity + "</td>";
                html += "<td width=\"5%\"><input type=\"text\" class=\"input small\" name=\"factDispatchCount\" value=\"0.00\"/></td>";
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
            <a href="expenses_register_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>回车报账列表</span>
            <i class="arrow"></i>
            <span>回车报账</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">运输单信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">承运单信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">出车费用</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>出车时间</dt>
                <dd><asp:Label ID="labFactDispatchTime" runat="server" Text=""></asp:Label></dd>
            </dl>
            <dl>
                <dt>回车时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtFactBackTime" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>车队</dt>
                <dd>
                    <asp:Label ID="labMotorcade" runat="server" Text=""></asp:Label>
                </dd>
            </dl>
            <dl>
                <dt>车号</dt>
                <dd><asp:Label ID="labCarNumber" runat="server" Text=""></asp:Label></dd>
            </dl>
            <dl>
                <dt>司机</dt>
                <dd><asp:Label ID="labDriver" runat="server" Text=""></asp:Label></dd>
            </dl>
            <dl>
                <dt>出车领款</dt>
                <dd><asp:Label ID="labAdvance" runat="server" Text=""></asp:Label></dd>
            </dl>
            <dl>
                <dt>领款人</dt>
                <dd>
                    <asp:Label ID="labPayee" runat="server" Text=""></asp:Label></dd>
            </dl>
            <dl>
                <dt>应交还款</dt>
                <dd>
                    <asp:TextBox ID="txtRepayment" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入正确的数字" sucmsg=" ">0.00</asp:TextBox>元
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>实交还款</dt>
                <dd>
                    <asp:TextBox ID="txtFactRepayment" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入正确的数字" sucmsg=" ">0.00</asp:TextBox>元
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>司机费用(工资)</dt>
                <dd>
                    <asp:TextBox ID="txtCarriage" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入正确的数字" sucmsg=" ">0.00</asp:TextBox>元
                    <span class="Validform_checktip">*</span></dd>
            </dl>
        </div>
        <div class="tab-content" style="display: none; padding: 0 0 10px 0;">
            <table style="margin-top: 15px; width: 100%;">
                <tr style="padding-bottom: 20px;">
                    <td colspan="12" style="text-align: center; font-weight: bold;">调度订单项</td>
                </tr>
            </table>
            <table id="transportOrderItems" style="margin-top: 15px; width: 100%; border: none;" class="ltable">
                <tr data-name="dispatched">
                    <td width="5%"></td>
                    <td align="left">单据编号</td>
                    <td width="10%">往返</td>
                    <td width="10%">托运方</td>
                    <td width="10%">收货方</td>
                    <td width="9%">货物</td>
                    <td width="6%">计量单位</td>
                    <td width="9%">实发量</td>
                    <td width="9%">实收量</td>
                    <td width="5%">单价</td>
                    <td width="5%">总价</td>
                </tr>
                <%=transportOrderItems %>
            </table>
        </div>
        <div class="tab-content" style="display: none; padding: 0 0 10px 0;">
            <table id="transportOrderItems" style="margin-top: 15px; width: 100%; border: none;" class="ltable">
                <tr data-name="dispatched">
                    <td width="5%"></td>
                    <td align="left">费用名称</td>
                    <td width="50%">金额</td>
                </tr>
                <%=consumptions %>
            </table>
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
