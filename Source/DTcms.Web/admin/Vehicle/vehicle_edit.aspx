<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vehicle_edit.aspx.cs" Inherits="DTcms.Web.admin.Vehicle.vehicle_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑车辆</title>
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
            $(".upload-img").each(function () {
                $(this).InitSWFUpload({ sendurl: "../../tools/upload_ajax.ashx", flashurl: "../../scripts/swfupload/swfupload.swf" });
            });
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="vehicle_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>车辆管理</span>
            <i class="arrow"></i>
            <span>编辑车辆</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" class="selected">车辆信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>所属车队</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:1000">
                        <asp:DropDownList ID="ddlMotorcadeName" runat="server" datatype="*" errormsg="请选择车队" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>车号</dt>
                <dd>
                    <asp:TextBox ID="txtCarCode" runat="server" CssClass="input high" datatype="*2-100" errormsg="输入2-100个字符" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl style="display: none;">
                <dt>车牌号</dt>
                <dd>
                    <asp:TextBox ID="txtCarNumber" runat="server" CssClass="input high" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">如果不填写与车号相同
                    </span></dd>
            </dl>
            <dl>
                <dt>车型</dt>
                <dd>
                    <div class="rule-single-select" style="z-index:888">
                        <asp:DropDownList ID="ddlMotorcycleType" runat="server"></asp:DropDownList>
                    </div>
                    <span class="Validform_checktip"></span></dd>
            </dl>
            <dl>
                <dt>载重</dt>
                <dd>
                    <asp:TextBox ID="txtLoadingCapacity" runat="server" CssClass="input small" datatype="/^(([1-9]{1}\d*)|([0]{1}))(\.(\d){1,2})?$/" errormsg="请输入数字类型" sucmsg=" " Text="0.00"></asp:TextBox>
                    <span class="Validform_checktip">如果不填写默认为0</span></dd>
            </dl>
            <dl>
                <dt>发动机型号</dt>
                <dd>
                    <asp:TextBox ID="txtEngineType" runat="server" CssClass="input high"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>车架号</dt>
                <dd>
                    <asp:TextBox ID="txtFrameNumber" runat="server" CssClass="input high"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>底盘号</dt>
                <dd>
                    <asp:TextBox ID="txtChassisNumber" runat="server" CssClass="input high"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>保险号</dt>
                <dd>
                    <asp:TextBox ID="txtInsuranceNumber" runat="server" CssClass="input high"></asp:TextBox></dd>
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
