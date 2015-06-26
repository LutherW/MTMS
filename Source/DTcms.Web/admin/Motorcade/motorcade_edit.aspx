<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="motorcade_edit.aspx.cs" Inherits="DTcms.Web.admin.Motorcade.motorcade_edit" ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑车队</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/Validform_v5.3.2_min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    $(function () {
        //初始化表单验证
        $("#form1").initValidform();
    });
</script>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="motorcade_list.aspx" class="back"><i></i><span>返回列表页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <a href="motorcade_list.aspx"><span>所有车队</span></a>
  <i class="arrow"></i>
  <span>编辑车队</span>
</div>
<div class="line10"></div>
<!--/导航栏-->

<!--内容-->
<div class="content-tab-wrap">
  <div id="floatHead" class="content-tab">
    <div class="content-tab-ul-wrap">
      <ul>
        <li><a href="javascript:;" class="selected">编辑车队内容</a></li>
      </ul>
    </div>
  </div>
</div>

<div class="tab-content">
  <dl>
    <dt>车队名称</dt>
    <dd>
      <asp:TextBox ID="txtName" runat="server" CssClass="input normal" datatype="*1-100" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">*车队名称，100字符内</span>
    </dd>
  </dl>
  <dl>
    <dt>助记名</dt>
    <dd>
      <asp:TextBox ID="txtCode" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">非必填，可为空</span>
    </dd>
  </dl>
  <dl>
    <dt>外挂车队</dt>
    <dd>
        <asp:CheckBox ID="chkIsOutOfTeam" runat="server" />
    </dd>
  </dl>
  <dl>
    <dt>联系人</dt>
    <dd>
      <asp:TextBox ID="txtLinkMan" runat="server" CssClass="input normal" datatype="s0-50" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">非必填，可为空</span>
    </dd>
  </dl>
  <dl>
    <dt>联系电话</dt>
    <dd>
      <asp:TextBox ID="txtLinkTel" runat="server" CssClass="input high" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">非必填，可为空</span>
    </dd>
  </dl>
  <dl>
    <dt>联系地址</dt>
    <dd>
      <asp:TextBox ID="txtLinkAddress" runat="server" CssClass="input normal" sucmsg=" "></asp:TextBox>
      <span class="Validform_checktip">非必填，可为空</span>
    </dd>
  </dl>
  <dl>
    <dt>备注</dt>
    <dd>
      <asp:TextBox ID="txtRemarks" runat="server" CssClass="input" TextMode="MultiLine"></asp:TextBox>
      <span class="Validform_checktip">非必填，可为空</span>
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
