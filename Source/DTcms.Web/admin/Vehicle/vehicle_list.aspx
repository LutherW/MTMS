<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vehicle_list.aspx.cs" Inherits="DTcms.Web.admin.Vehicle.vehicle_list" %>
<%@ Import Namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>车辆管理</title>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="../../scripts/lhgdialog/lhgdialog.js?skin=idialog"></script>
<script type="text/javascript" src="../js/layout.js"></script>
<link  href="../../css/pagination.css" rel="stylesheet" type="text/css" />
<link href="../skin/default/style.css" rel="stylesheet" type="text/css" />
<%--<script type="text/javascript">
    //发送短信
    function PostSMS(mobiles) {
        if (mobiles == "") {
            $.dialog.alert('对不起，手机号码不能为空！');
            return false;
        }
        var dialog = $.dialog({
            title: '发送手机短信',
            content: '<textarea id="txtSmsContent" name="txtSmsContent" rows="2" cols="20" class="input"></textarea>',
            min: false,
            max: false,
            lock: true,
            ok: function () {
                var remark = $("#txtSmsContent", parent.document).val();
                if (remark == "") {
                    $.dialog.alert('对不起，请输入手机短信内容！', function () { }, dialog);
                    return false;
                }
                var postData = { "mobiles": mobiles, "content": remark };
                //发送AJAX请求
                $.ajax({
                    type: "post",
                    url: "../../tools/admin_ajax.ashx?action=sms_message_post",
                    data: postData,
                    dataType: "json",
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        $.dialog.alert('尝试发送失败，错误信息：' + errorThrown, function () { }, dialog);
                    },
                    success: function (data, textStatus) {
                        if (data.status == 1) {
                            dialog.close();
                            $.dialog.tips(data.msg, 2, '32X32/succ.png', function () { location.reload(); }); //刷新页面
                        } else {
                            $.dialog.alert('错误提示：' + data.msg, function () { }, dialog);
                        }
                    }
                });
                return false;
            },
            cancel: true
        });
    }
</script>--%>
</head>

<body class="mainbody">
<form id="form1" runat="server">
<!--导航栏-->
<div class="location">
  <a href="javascript:history.back(-1);" class="back"><i></i><span>返回上一页</span></a>
  <a href="../center.aspx" class="home"><i></i><span>首页</span></a>
  <i class="arrow"></i>
  <span>车辆管理</span>
  <i class="arrow"></i>
  <span>车辆列表</span>
</div>
<!--/导航栏-->

<!--工具栏-->
<div class="toolbar-wrap">
  <div id="floatHead" class="toolbar">
    <div class="l-list">
      <ul class="icon-list">
        <li><a class="add" href="vehicle_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>"><i></i><span>新增</span></a></li>
        <li><a class="all" href="javascript:;" onclick="checkAll(this);"><i></i><span>全选</span></a></li>
        <li><asp:LinkButton ID="btnDelete" runat="server" CssClass="del" OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><i></i><span>删除</span></asp:LinkButton></li>
      </ul>
      <div class="menu-list">
        <div class="rule-single-select">
          <asp:DropDownList ID="ddlMotorcadeName" runat="server" AutoPostBack="True" onselectedindexchanged="ddlMotorcadeName_SelectedIndexChanged"></asp:DropDownList>
        </div>
      </div>
    </div>
    <div class="r-list">
      <asp:TextBox ID="txtKeywords" runat="server" CssClass="keyword" />
      <asp:LinkButton ID="lbtnSearch" runat="server" CssClass="btn-search" onclick="btnSearch_Click">查询</asp:LinkButton>
    </div>
  </div>
</div>
<!--/工具栏-->

<!--列表-->
<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0" class="ltable">
  <tr>
    <th width="8%">选择</th>
    <th align="left" width="10%">车号</th>
    <th align="left" style="display:none;">车牌号码</th>
    <th width="8%">所属车队</th>
    <th width="8%">车型号</th>
    <th width="8%">载重</th>
    <th width="8%">发动机型号</th>
    <th width="8%">车架号</th>
    <th width="8%">底盘号</th>
    <th width="8%">保险号</th>
    <th>备注</th>
    <th width="8%">操作</th>
  </tr>
</HeaderTemplate>
<ItemTemplate>
  <tr>
    <td align="center">
      <asp:CheckBox ID="chkId" CssClass="checkall" runat="server" style="vertical-align:middle;" />
      <asp:HiddenField ID="hidId" Value='<%#Eval("Id")%>' runat="server" />
    </td>
    <td width="64">
      <a href="vehicle_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("Id")%>">
        <%#Eval("CarCode")%>
      </a>
    </td>
    <td style="display:none;"><%#Eval("CarNumber")%></td>
    <td align="center"><%#Eval("MotorcadeName")%></td>
    <td align="center"><%#Eval("MotorcycleType")%></td>
    <td align="center"><%#Eval("LoadingCapacity")%></td>
    <td align="center"><%#Eval("EngineType")%></td>
    <td align="center"><%#Eval("FrameNumber")%></td>
    <td align="center"><%#Eval("ChassisNumber")%></td>
    <td align="center"><%#Eval("InsuranceNumber")%></td>
    <td align="center"><%#Eval("Remarks")%></td>
    <td align="center"><a href="vehicle_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a></td>
  </tr>
</ItemTemplate>
<FooterTemplate>
  <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"9\">暂无记录</td></tr>" : ""%>
</table>
</FooterTemplate>
</asp:Repeater>
<!--/列表-->

<!--内容底部-->
<div class="line20"></div>
<div class="pagelist">
  <div class="l-btns">
    <span>显示</span><asp:TextBox ID="txtPageNum" runat="server" CssClass="pagenum" onkeydown="return checkNumber(event);" ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox><span>条/页</span>
  </div>
  <div id="PageContent" runat="server" class="default"></div>
</div>
<!--/内容底部-->
</form>
</body>
</html>
