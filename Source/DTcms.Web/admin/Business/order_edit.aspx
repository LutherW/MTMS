<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="order_edit.aspx.cs" Inherits="DTcms.Web.admin.Business.order_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑订单</title>
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
            //初始化上传控件
            //$(".upload-img").each(function () {
            //    $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            //});

            $("#ddlHaulway").change(function () {
                var val = $(this).val();
                if (val > 0) {
                    $.getJSON("../../tools/Haulway.ashx", { "action": "details", "id": val }, function (data) {
                        if (data.status == 1) {
                            $("#txtLoadingCapacityRunning").val(data.loadingCapacityRunning);
                            $("#txtNoLoadingCapacityRunning").val(data.noLoadingCapacityRunning);
                        }
                    });
                } else {
                    $("#txtLoadingCapacityRunning").val("0.00");
                    $("#txtNoLoadingCapacityRunning").val("0.00");
                }
            });

            $("#ddlFormula").change(function () {
                var val = $(this).val();
                var quantity = $("#txtQuantity").val();
                var unitPrice = $("#txtUnitPrice").val();

                if (val == 1) {
                    if (quantity > 0 && unitPrice > 0) {
                        $("#txtTotalPrice").val(quantity * unitPrice);
                    }
                } else if (val == 2) {
                    var loadingCapacityRunning = $("#txtLoadingCapacityRunning").val();
                    if (quantity > 0 && unitPrice > 0 && loadingCapacityRunning > 0) {
                        $("#txtTotalPrice").val(quantity * unitPrice * loadingCapacityRunning);
                    }
                }
            });

            $("#txtTotalPrice").focus(function () {
                var val = $("#ddlFormula").val();
                var quantity = $("#txtQuantity").val();
                var unitPrice = $("#txtUnitPrice").val();

                if (val == 1) {
                    if (quantity > 0 && unitPrice > 0) {
                        $(this).val(quantity * unitPrice);
                    }
                } else if (val == 2) {
                    var loadingCapacityRunning = $("#txtLoadingCapacityRunning").val();
                    if (quantity > 0 && unitPrice > 0 && loadingCapacityRunning > 0) {
                        $(this).val(quantity * unitPrice * loadingCapacityRunning);
                    }
                }
            });

            $("#ddlShipper").change(function () {
                var val = $(this).val();
                if (val > 0) {
                    $.getJSON("../../tools/Customer.ashx", { "action": "details", "id": val }, function (data) {
                        if (data.status == 1) {
                            $("#txtShipperLinkMan").val(data.linkMan);
                            $("#txtShipperLinkTel").val(data.linkTel);
                        }
                    });
                } else {
                    $("#txtShipperLinkMan").val("");
                    $("#txtShipperLinkTel").val("");
                }
            });

            $("#ddlReceiver").change(function () {
                var val = $(this).val();
                if (val > 0) {
                    $.getJSON("../../tools/Customer.ashx", { "action": "details", "id": val }, function (data) {
                        if (data.status == 1) {
                            $("#txtReceiverLinkMan").val(data.linkMan);
                            $("#txtReceiverLinkTel").val(data.linkTel);
                        }
                    });
                } else {
                    $("#txtReceiverLinkMan").val("");
                    $("#txtReceiverLinkTel").val("");
                }
            });

            $("#ddlGoods").change(function () {
                var val = $(this).val();
                if (val > 0) {
                    //$.getJSON("../../tools/Goods.ashx", { "action": "details", "id": val }, function (data) {
                    //    console.info(data);
                    //});
                    $.getJSON("../../tools/Goods.ashx", { "action": "details", "id": val }, function (data) {
                        if (data.status == 1) {
                            $("#txtUnit").val(data.unit);
                        }
                    });
                } else {
                    $("#txtUnit").val("");
                }
            });
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="order_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>订单管理</span>
            <i class="arrow"></i>
            <span>编辑订单</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" onclick="tabs(this);" class="selected">基本信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">客户信息</a></li>
                        <li><a href="javascript:;" onclick="tabs(this);">货物信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>接单时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtAcceptOrderTime" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>要求到货时间</dt>
                <dd>
                    <span class="input-date"><asp:TextBox ID="txtArrivedTime" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span>
                    <span class="Validform_checktip"></span></dd>
            </dl>
            <dl>
                <dt>预发量</dt>
                <dd>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="0.00" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" " CssClass="input small"></asp:TextBox>
                    <asp:CheckBox ID="chkIsCharteredCar" runat="server" Text="包车" />
                    <span class="Validform_checktip">如果选择包车，预发量填0.00</span></dd>
            </dl>
            <dl>
                <dt>运输路线</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:11000">
                        <asp:DropDownList ID="ddlHaulway" runat="server" datatype="*" errormsg="请选择运输路线" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span></dd>
            </dl>
            <dl>
                <dt>载重公里</dt>
                <dd>
                    <asp:TextBox ID="txtLoadingCapacityRunning" runat="server" CssClass="input small" Text="0.00"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>空载公里</dt>
                <dd>
                    <asp:TextBox ID="txtNoLoadingCapacityRunning" runat="server" CssClass="input small" Text="0.00"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>计费公式</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:9999">
                        <asp:DropDownList ID="ddlFormula" runat="server" datatype="*" errormsg="请选择计费公式" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>运费单价</dt>
                <dd>
                    <asp:TextBox ID="txtUnitPrice" runat="server" Text="0.00" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>元</dd>
            </dl>
            <dl>
                <dt>运费</dt>
                <dd>
                    <asp:TextBox ID="txtTotalPrice" runat="server" CssClass="input high" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请填写正确的数字" sucmsg=" "></asp:TextBox>元</dd>
            </dl>
            <dl>
                <dt>结算方式</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:9990">
                        <asp:DropDownList ID="ddlSettleAccountsWay" runat="server" datatype="*" errormsg="请选择结算方式" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
        </div>

        <div class="tab-content" style="display: none;">
            <dl>
                <dt>提货地址</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:11013">
                        <asp:DropDownList ID="ddlLoadingAddress" runat="server" datatype="*" errormsg="请选择提货地址" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>目的地址</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:11004">
                        <asp:DropDownList ID="ddlUnloadingAddress" runat="server" datatype="*" errormsg="请选择目的地址" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>合同号</dt>
                <dd>
                    <asp:TextBox ID="txtContractNumber" runat="server" CssClass="input high"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>提单号</dt>
                <dd>
                    <asp:TextBox ID="txtBillNumber" runat="server" CssClass="input high"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>地磅号</dt>
                <dd>
                    <asp:TextBox ID="txtWeighbridgeNumber" runat="server" CssClass="input high"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>托运方</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:11000">
                        <asp:DropDownList ID="ddlShipper" runat="server" datatype="*" errormsg="请选择托运方" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>联系人</dt>
                <dd>
                    <asp:TextBox ID="txtShipperLinkMan" runat="server" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>联系电话</dt>
                <dd>
                    <asp:TextBox ID="txtShipperLinkTel" runat="server" CssClass="input high"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>收货方</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:1006">
                        <asp:DropDownList ID="ddlReceiver" runat="server" datatype="*" errormsg="请选择收货方" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>联系人</dt>
                <dd>
                    <asp:TextBox ID="txtReceiverLinkMan" runat="server" CssClass="input normal"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>联系电话</dt>
                <dd>
                    <asp:TextBox ID="txtReceiverLinkTel" runat="server" CssClass="input high"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>


        </div>

        <div class="tab-content" style="display: none;">
            <dl>
                <dt>承运货物</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:1007">
                        <asp:DropDownList ID="ddlGoods" runat="server" datatype="*" errormsg="请选择承运货物" sucmsg=" "></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span>
                </dd>
            </dl>
            <dl>
                <dt>计量单位</dt>
                <dd>
                    <asp:TextBox ID="txtUnit" runat="server" CssClass="input small"></asp:TextBox>
                    <span class="Validform_checktip"></span>
                </dd>
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
