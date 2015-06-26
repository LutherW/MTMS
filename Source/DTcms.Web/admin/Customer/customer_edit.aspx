<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customer_edit.aspx.cs" Inherits="DTcms.Web.admin.Customer.customer_edit" ValidateRequest="false" %>

<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑客户</title>
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
        });
    </script>
</head>

<body class="mainbody">
    <form id="form1" runat="server">
        <!--导航栏-->
        <div class="location">
            <a href="customer_list.aspx" class="back"><i></i><span>返回列表页</span></a>
            <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
            <i class="arrow"></i>
            <span>客户管理</span>
            <i class="arrow"></i>
            <span>编辑客户</span>
        </div>
        <div class="line10"></div>
        <!--/导航栏-->

        <!--内容-->
        <div class="content-tab-wrap">
            <div id="floatHead" class="content-tab">
                <div class="content-tab-ul-wrap">
                    <ul>
                        <li><a href="javascript:;" class="selected">客户信息</a></li>
                    </ul>
                </div>
            </div>
        </div>

        <div class="tab-content">
            <dl>
                <dt>客户类型</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlTypeName" runat="server" datatype="*" errormsg="请选择客户类型" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>简称</dt>
                <dd>
                    <asp:TextBox ID="txtShortName" runat="server" CssClass="input normal" datatype="*2-100" errormsg="输入2-100个字符" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip">*</span></dd>
            </dl>
            <dl>
                <dt>全称</dt>
                <dd>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
                    <span class="Validform_checktip"></span></dd>
            </dl>
            <dl>
                <dt>客户类别</dt>
                <dd>
                    <div class="rule-single-select">
                        <asp:DropDownList ID="ddlCategory" runat="server" datatype="*" errormsg="请选择客户类别" sucmsg=" "></asp:DropDownList>
                    </div>
                </dd>
            </dl>
            <dl>
                <dt>助记码</dt>
                <dd>
                    <asp:TextBox ID="txtCode" runat="server" CssClass="input high"></asp:TextBox>
                    <span class="Validform_checktip"></span></dd>
            </dl>
            <dl>
                <dt>联系人</dt>
                <dd>
                    <asp:TextBox ID="txtLinkMan" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>联系电话</dt>
                <dd>
                    <asp:TextBox ID="txtLinkTel" runat="server" CssClass="input high"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>联系地址</dt>
                <dd>
                    <asp:TextBox ID="txtLinkAddress" runat="server" CssClass="input normal"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>手机号</dt>
                <dd>
                    <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="input high"></asp:TextBox></dd>
            </dl>
            <dl>
                <dt>税务登记号</dt>
                <dd>
                    <asp:TextBox ID="txtTaxRegistrationNumber" runat="server" CssClass="input high"></asp:TextBox></dd>
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
