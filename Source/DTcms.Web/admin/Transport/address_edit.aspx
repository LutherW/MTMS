<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="address_edit.aspx.cs" Inherits="DTcms.Web.admin.Transport.address_edit" ValidateRequest="false" %>
<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑装卸货地址</title>
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
  <a href="address_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>运输管理</span>
  <i class="arrow"></i>
  <span>编辑装卸货地址</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" class="selected">装卸货地址信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>类别</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlCategory" runat="server" datatype="*" errormsg="请选择类别" sucmsg=" ">
            <asp:ListItem Text="装货地址" Value="装货地址"></asp:ListItem>
            <asp:ListItem Text="卸货地址" Value="卸货地址"></asp:ListItem>
        </asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>名称</dt>
    <dd><asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="*2-100" errormsg="输入2-100个字符" sucmsg=" "></asp:TextBox> 
        <span class="Validform_checktip">*</span></dd>
  </dl> 
  <dl>
    <dt>助记码</dt>
    <dd><asp:TextBox ID="txtCode" runat="server" CssClass="input high"></asp:TextBox>
         <span class="Validform_checktip">不填写默认为名称</span></dd>
  </dl>
</div>

<!--/内容-->

<!--工具栏-->
<div class="page-footer">
  <div class="btn-list">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

</form>
</body>
</html>
