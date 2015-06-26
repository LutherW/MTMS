<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="DTcms.Web.admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>管理员登录</title>
    <link href="skin/default/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript">
        $(function () {
            //检测IE
            if ('undefined' == typeof (document.body.style.maxHeight)) {
                window.location.href = 'ie6update.html';
            }
        });
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <%--<div class="login-screen">
	<div class="login-icon">LOGO</div>
    <div class="login-form">
        <h1>系统管理登录</h1>
        <div class="control-group">
            <asp:TextBox ID="txtUserName1" runat="server" CssClass="login-field" placeholder="用户名" title="用户名"></asp:TextBox>
            <label class="login-field-icon user" for="txtUserName"></label>
        </div>
        <div class="control-group">
            <asp:TextBox ID="txtPassword1" runat="server" CssClass="login-field" TextMode="Password" placeholder="密码" title="密码"></asp:TextBox>
            <label class="login-field-icon pwd" for="txtPassword"></label>
        </div>
        <div></div>
        <span class="login-tips"><i></i><b id="msgtip" runat="server">请输入用户名和密码</b></span>
    </div>
    <i class="arrow">箭头</i>
</div>--%>


        <div class="container">
            <div id="signin_bg">
                <img src="skin/default/signin_bg.png" /></div>
            <div id="signin_logo"><a href="/">
                <img src="skin/default/login_logo.png" /></a></div>
            <div id="signin_panel">
                <div class="form-group">
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" placeholder="用户名" title="用户名"></asp:TextBox>
                    <label class="login-field-icon user" for="txtUserName"></label>
                </div>
                <div class="form-group password-group">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="密码（6-20位数字、字母、常用符号）" title="密码"></asp:TextBox>
                    <label class="login-field-icon pwd" for="txtPassword"></label>
                </div>
                <asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="btn-login submitbtn btn_blue" OnClick="btnSubmit_Click" />
                <div class="tip"><span class="login-tips"><i></i><b id="msgtip" runat="server">请输入用户名和密码</b></span></div>
            </div>
        </div>
    </form>
</body>
</html>
