<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WorksShow.Web.admin.WebForm1" %>
<!DOCTYPE html>
<html>
<head>
    <title>教学信息管理系统 </title>
 <%--   <link href="@Url.Content("~/Content/Common.css")" rel="stylesheet" type="text/css" />
    <link href="@Url.Content("~/Content/Login.css")" rel="stylesheet" type="text/css" />--%>
    <link href="../Style/Common.css" rel="stylesheet" type="text/css" />
    <link href="../Style/Login.css" rel="stylesheet" type="text/css" />
<%--    <script src="@Url.Content("~/Scripts/jquery-1.5.1.min.js")" type="text/javascript"></script>--%>
    <script src="../scripts/jquery-2.1.4.min.js" type="text/javascript"></script>
<%--    <script src="@Url.Content("~/Scripts/Loading.js")" type="text/javascript"></script>--%>
    <script src="../scripts/Loading.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        $.ajaxSetup({
            cache: false //关闭AJAX相应的缓存 
        });

        $(document).ready(function () {
            $("#error").hide();
            $("#mask").hide();
            $("#divTopContainer").css("margin-left",($(document).width()-681)/2);
            ChangeValidateCodeImage();
        });

        function Login() {
            if ($("#txtUserName").val() == "" || $("#txtPassword").val() == "") {
                $("#error").text("用户名或密码不能为空！");
                $("#error").show();
                return;
            }
            if ($("#txtCode").val() == "") {
                $("#error").text("验证码不能为空！");
                $("#error").show();
                return;
            }
                $.ajax({
                        url:"@Url.Content("~/Login/Login")", 
                        type:"post",
                        data:{ userName: function () { return $("#txtUserName").val() }, password: function () { return $("#txtPassword").val() },code:function(){ return $("#txtCode").val() } },
                        beforeSend:function(){ showMask();},
                        complete:function(){hidMask();},
                        error: function(XMLHttpRequest, textStatus, errorThrown) { 
                                 $("#error").text(errorThrown);
                                 $("#error").show();},
                        success:function (data) {
                            if (data.substring(0,1) == "/") {
                                window.location = data;
                            }
                            else {
                                $("#error").text(data);
                                $("#error").show();
                            }}});
        }

        function Reset() {
            $("#txtUserName").val("");
            $("#txtPassword").val("");
            $("#valiCode").val("");
            $("#error").hide();
        }


        function ChangeValidateCodeImage()
        {
            $.ajax({
                        url:"@Url.Content("~/Login/GetValidateCodeImageName")", 
                        type:"post",
                        data:null,
                        beforeSend:function(){ showMask();},
                        complete:function(){ hidMask();},
                        success:function (data) {
                            var path = "@Url.Content("~/images/Temp/")" + data;
                            $("#valiCode").attr("src",path);
                        }
                 });
        }

        function DoEvents()
        {
            if(event.keyCode==13) 
            {
                Login();
            }
        }
    </script>
</head>
<body>
    <div id="divTopContainer">
        <div class="left">
            <div>
                本系统支持IE8以上、Google浏览器</div>
        </div>
        <div class="center">
            <div class="welcome">
                教学信息管理系统
            </div>
            <div class="divid" style="margin-top: 20px;">
                登录名称：<input type="text"  maxlength="10" id="txtUserName" name="txtUserName" /></div>
            <div class="divid">
                登录密码：<input type="password"  maxlength="10" id="txtPassword" name="txtPassword" /></div>
            <div class="divid" style="margin-left: 15px;">
                <div style="float: left;">
                    验&nbsp;证&nbsp;码：<input type="text" onkeypress="DoEvents()" id="txtCode" name="txtCode"
                        maxlength="4" style="width: 62px;" /></div>
                <div style="margin-top: 2px; float: left;">
                    <a href="javascript:ChangeValidateCodeImage();">
                        <img id="valiCode" border="0" src="" alt="验证码" /></a></div>
            </div>
            <div style="clear: both;">
            </div>
            <div class="btns">
                <input name="submit" class="btn" value=" 登  录 " type="button" onclick="Login()" />
                <input name="Password" class="btn" type="button" value="重 置" onclick="Reset()" />
            </div>
            <div id="error" style="color: Red; margin-top: 10px;">
            </div>
        </div>
        <div class="right">
        </div>
        <div style="clear: both;">
        </div>
    </div>
</body>
</html>

