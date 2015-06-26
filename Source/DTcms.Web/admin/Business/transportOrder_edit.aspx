<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transportOrder_edit.aspx.cs" Inherits="DTcms.Web.admin.Business.transportOrder_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑运输单</title>
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
            <a href="transportOrder_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>运输单管理</span>
            <i class="arrow"></i>
            <span>编辑运输单</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">运输单信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">运单项信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>计划出车时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtDispatchTime" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>预计回车时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtBackTime" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip"></span></dd>
            </dl>
            <dl>
                <dt>车队</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:9999">
                        <asp:DropDownList ID="ddlMotorcade" runat="server" datatype="*" errormsg="请选择车队" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>车号</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:9990">
                        <asp:DropDownList ID="ddlCarNumber" runat="server" datatype="*" errormsg="请选择车辆" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>司机</dt>
                <dd>
                    <asp:TextBox ID="txtDriver" runat="server" CssClass="input high" datatype="*2-100" errormsg="输入2-100个字符" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>备注</dt>
                <dd>
                    <asp:TextBox ID="txtRemarks" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
                </dd>
            </dl>
        </div>
        <div class="tab-content" style="display: none; padding: 0 0 10px 0;">
            <table style="margin-top: 15px; width: 100%;">
                <tr style="padding-bottom: 20px;">
                    <td colspan="12" style="text-align: center; font-weight: bold;">待调度订单</td>
                </tr>
            </table>
            <asp:Repeater ID="rptList" runat="server">
                <HeaderTemplate>
                    <table id="orders" width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable" style="margin-top: 15px; width: 100%; border: none;">
                        <tr>
                            <th width="5%">选择</th>
                            <th width="8%">合同号</th>
                            <th width="8%">提单号</th>
                            <th width="9%">要求到货时间</th>
                            <th width="10%">托运方</th>
                            <th width="10%">收货方</th>
                            <th width="8%">货物</th>
                            <th width="5%">计量单位</th>
                            <th width="8%">包车/预发/已调</th>
                            <th width="5%">单价</th>
                            <th width="5%">总价</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr data-name="dispatching">
                        <td align="center">
                            <input type="checkbox" name="chkId" value="<%#Eval("Id")%>" style="vertical-align: middle;" />
                        </td>
                        <td id="contractNumber_<%#Eval("Id")%>" align="center"><%#Eval("ContractNumber")%></td>
                        <td id="billNumber_<%#Eval("Id")%>" align="center"><%#Eval("BillNumber")%></td>
                        <td id="arrivedTime_<%#Eval("Id")%>" align="center"><%#Eval("ArrivedTime")%></td>
                        <td id="shipper_<%#Eval("Id")%>" align="center"><%#Eval("Shipper")%></td>
                        <td id="receiver_<%#Eval("Id")%>" align="center"><%#Eval("Receiver")%></td>
                        <td id="goods_<%#Eval("Id")%>" align="center"><%#Eval("Goods")%></td>
                        <td id="unit_<%#Eval("Id")%>" align="center"><%#Eval("Unit")%></td>
                        <td id="quantity_<%#Eval("Id")%>" align="center"><%#Eval("IsCharteredCar").ToString().Equals("1") ? "包车" : Eval("Quantity").ToString() + "/" + Eval("DispatchedCount").ToString()%></td>
                        <td id="unitPrice_<%#Eval("Id")%>" align="center">￥<%#string.Format("{0:N2}", Eval("UnitPrice"))%></td>
                        <td id="totalPrice_<%#Eval("Id")%>" align="center">￥<%#string.Format("{0:N2}", Eval("TotalPrice"))%></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate></table></FooterTemplate>
            </asp:Repeater>
            <table style="margin-top: 15px; width: 100%;">
                <tr style="padding-bottom: 20px;">
                    <td colspan="12" style="text-align: center; font-weight: bold;">已调度订单</td>
                </tr>
            </table>
            <table id="transportOrderItems" style="margin-top: 15px; width: 100%; border: none;" class="ltable">
                <tr data-name="dispatched">
                    <td width="5%"></td>
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
                <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" OnClick="btnSubmit_Click" />
                <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript: history.back(-1);" />
            </div>
            <div class="clear"></div>
        </div>
        <!--/工具栏-->

    </form>
</body>
</html>
