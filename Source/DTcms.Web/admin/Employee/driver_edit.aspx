<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="driver_edit.aspx.cs" Inherits="DTcms.Web.admin.Employee.driver_edit" ValidateRequest="false" %>
<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑司机</title>
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
  <a href="driver_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>司机管理</span>
  <i class="arrow"></i>
  <span>编辑司机</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" class="selected">司机信息</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>所驾车辆</dt>
    <dd>
      <div class="rule-single-select">
        <asp:DropDownList id="ddlCarNumber" runat="server" datatype="*" errormsg="请选择所驾车辆" sucmsg=" "></asp:DropDownList>
      </div>
    </dd>
  </dl>
  <dl>
    <dt>姓名</dt>
    <dd><asp:TextBox ID="txtRealName" runat="server" CssClass="input normal" datatype="s2-5" errormsg="输入2-100个字符" sucmsg=" "></asp:TextBox> 
        <span class="Validform_checktip">*</span></dd>
  </dl> 
  <dl>
    <dt>助记码</dt>
    <dd><asp:TextBox ID="txtRealNameCode" runat="server" CssClass="input high"></asp:TextBox>
         <span class="Validform_checktip"></span></dd>
  </dl>
    <dl>
    <dt>身份证号码</dt>
    <dd><asp:TextBox ID="txtIdCardNumber" runat="server" CssClass="input high"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>联系电话</dt>
    <dd><asp:TextBox ID="txtLinkTel" runat="server" CssClass="input high"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>联系地址</dt>
    <dd><asp:TextBox ID="txtLinkAddress" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>开始工作时间</dt>
    <dd><span class="input-date"><asp:TextBox ID="txtBeganWorkDate" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span></dd>
  </dl>
    <dl>
    <dt>驾照取证时间</dt>
    <dd><span class="input-date"><asp:TextBox ID="txtIssuedDate" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span></dd>
  </dl>
    <dl>
    <dt>驾照年审时间</dt>
    <dd><span class="input-date"><asp:TextBox ID="txtAnnualDate" runat="server" CssClass="input normal date" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" datatype="/^\s*$|^\d{4}\-\d{1,2}\-\d{1,2}$/" errormsg="请选择正确的日期" sucmsg=" "></asp:TextBox><i>日期</i></span></dd>
  </dl>
    <dl>
    <dt>驾驶证号</dt>
    <dd><asp:TextBox ID="txtDrivingLicence" runat="server" CssClass="input high"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>准驾证号</dt>
    <dd><asp:TextBox ID="txtDrivingPermitNumber" runat="server" CssClass="input high"></asp:TextBox></dd>
  </dl>
    <dl>
    <dt>准驾车型</dt>
    <dd><asp:TextBox ID="txtDrivingPermitType" runat="server" CssClass="input normal"></asp:TextBox></dd>
  </dl>
  <dl>
    <dt>是否离职</dt>
    <dd>
        <asp:CheckBox ID="chkIsDimission" runat="server" /></dd>
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
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btn" onclick="btnSubmit_Click" />
    <input name="btnReturn" type="button" value="返回上一页" class="btn yellow" onclick="javascript:history.back(-1);" />
  </div>
  <div class="clear"></div>
</div>
<!--/工具栏-->

</form>
</body>
</html>
