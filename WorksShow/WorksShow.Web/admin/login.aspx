<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WorksShow.Web.admin.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>管理员登录</title>
    <%--    <link href="../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="images/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="js/function.js"></script>--%>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jQuery.js"></script>
    <script type="text/javascript" src="js/fun.base.js"></script>
    <script type="text/javascript" src="js/script.js"></script>
    <script type="text/javascript">
        //表单验证
        $(function () {
            //检测IE
            if ($.browser.msie && $.browser.version == "6.0") {
                window.location.href = 'ie6update.html';
            }
            $('#value_1').focus();
            $("#form1").validate({
                errorPlacement: function (lable, element) {
                    element.ligerTip({ content: lable.html(), appendIdTo: lable });
                },
                success: function (lable) {
                    lable.ligerHideTip();
                }
            });
        });
    </script>
    <style>
        .login_copyright
        {
            background-image: url('images/login-foot.jpg');
        }
    </style>
</head>
<body class="loginbody">
    <form id="form1" runat="server">
    <%--<div class="login_div">--%>
    <%--<div class="login_box">
    	<div class="login_logo">LOGO</div>
        <div class="login_content">
          <dl>
			<dt>登录账号：</dt>
            <dd><asp:TextBox ID="txtUserName" runat="server" CssClass="login_input required" style="width:130px;" /></dd>
          </dl>
          <dl>
			<dt>登录密码：</dt>
            <dd><asp:TextBox ID="txtUserPwd" runat="server" CssClass="login_input required" TextMode="Password" style="width:130px;" /></dd>
          </dl>
          <dl>
			<dt>验证码：</dt>
            <dd>
                <asp:TextBox ID="txtCode" runat="server" CssClass="login_input required" MaxLength="6" style="width:55px;text-transform:uppercase;" />
                <img src="../tools/verify_code.ashx" width="70" height="22" alt="点击切换验证码" title="点击切换验证码" style=" margin-top:2px; vertical-align:top;cursor:pointer;" onclick="ToggleCode(this, '../tools/verify_code.ashx');return false;" />
            </dd>
          </dl>
        </div>
        <div class="login_foot">
			<div class="right"><asp:Button ID="btnSubmit" runat="server" Text="登 录" CssClass="login_btn" onclick="btnSubmit_Click" /></div>
			<span><asp:CheckBox ID="cbRememberId" runat="server" Text="记住用户名" Checked="True" /></span>
		</div>
        <div class="login_tip">
            <asp:Label ID="lblTip" runat="server" Text="请输入用户名及密码" Visible="False" />
        </div>
    </div>
	<div class="login_copyright">Copyright © 2017 - 2020 <a href="http://www.cqgcxy.com:804/">重庆工程学院软件与计算机学院</a> . All Rights Reserved.<br /></div>
</div>--%>
    <div class="login">
        <div class="box png">
            <div class="logo png">
            </div>
            <div class="input">
                <div class="log">
                    <div class="name">
                        <label>
                            用户名</label><%--<input type="text" class="text" id="value_1" placeholder="用户名" name="value_1" tabindex="1" runat="server"/>--%>
                        <asp:TextBox ID="value_1" class="text" placeholder="用户名" name="value_1" TabIndex="1"
                            runat="server"></asp:TextBox>
                    </div>
                    <div class="pwd">
                        <label>
                            密 码
                        </label>
                        <%--<input type="password" class="text" id="value_2" placeholder="密码" name="value_2" tabindex="2" runat="server"/>--%>
                        <asp:TextBox ID="value_2" class="text" runat="server" placeholder="密码" TextMode="Password" name="value_2"
                            TabIndex="2"></asp:TextBox>
                        <%--  <input type="button" class="submit" tabindex="3" value="登录">--%>
                    </div>
                    <div class="code" style="margin-top: 10px;">
                        <label style="font-size: 14px; padding-left: 4px;">
                            验证码</label>
                        <asp:TextBox ID="txtCode" runat="server" class="text" MaxLength="6" placeholder="验证码"
                            Style="width: 124px; text-transform: uppercase;" />
                        <img src="../tools/verify_code.ashx" width="70" height="22" alt="点击切换验证码" title="点击切换验证码"
                            style="margin-top: 2px; vertical-align: top; cursor: pointer;" onclick="ToggleCode(this, '../tools/verify_code.ashx');return false;" />
                        <asp:Button ID="btnSubmit" class="submit" TabIndex="3" runat="server" Text="登 录"
                            OnClick="btnSubmit_Click" />
                        <span style="    margin-left: 267px;margin-top: -7px;display:block;">
                            <asp:CheckBox ID="cbRememberId" runat="server" Text="记住用户名" Checked="True" /></span>
                          <%--      <input id="cbRememberId" type="checkbox" name="cbRememberId" checked="checked">
                                <label for="cbRememberId" style="width: 62px;margin-top: -7px;">记住用户名</label>--%>
                        <div class="check">
                        </div>
                    </div>
                    <div class="login_tip" style="margin: -41px 0px 0px 260px; color: red;">
                        <asp:Label ID="lblTip" runat="server" Text="请输入用户名及密码" Visible="False" />
                    </div>
                    <div class="tip" style="margin: -41px 0px 0px 260px; color: red;">
                    </div>
                </div>
            </div>
        </div>
        <div class="air-balloon ab-1 png">
        </div>
        <div class="air-balloon ab-2 png">
        </div>
        <div class="footer">
        </div>
    </div>
    <!--[if IE 6]>
<script src="js/DD_belatedPNG.js" type="text/javascript"></script>
<script>DD_belatedPNG.fix('.png')</script>
<![endif]-->
    </form>
</body>
</html>
