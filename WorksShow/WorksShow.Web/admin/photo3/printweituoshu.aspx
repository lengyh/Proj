<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printweituoshu.aspx.cs"
    Inherits="WorksShow.Web.admin.photo.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin: 0 auto;
            font-size: 20px;
            letter-spacing: 2px;
            line-height: 1.4em;
        }
        h1
        {
            text-align: center;
        }
        .style1
        {
            border-collapse: collapse;
            border: 1px solid black;
            margin: 0 auto;
            text-align: center;
        }
        td
        {
            border: 1px solid black;
            height: 40px;
        }
        .lighter
        {
            font-weight: lighter;
        }
    </style>
    <script src="../../scripts/jquery/jquery-1.5.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        
    </script>
    <style media="print">
        .noprint
        {
            display: none;
        }
    </style>
    <script language="JavaScript">
        function doPrintSetup() {
            //打印设置
            printWB.ExecWB(8, 1)
        }
        function doPrintPreview() {
            //打印预览
            printWB.ExecWB(7, 1)
        }
        function doPrint() {
            //直接打印
            printWB.ExecWB(6, 6)
        }
    </script>
</head>
<body>
    <div class="noprint">
        <object id="printWB" style="dispaly: none" classid="clsid:8856F961-340A-11D0-A96B-00C04FD705A2"
            height="0">
        </object>
        <input type="button" value="打印设置" onclick="doPrintSetup();"></input>
        <input type="button" value="打印预览" onclick="doPrintPreview();"></input>
        <input type="button" value="直接打印" onclick="doPrint();"></input>
        <input type="button" value="关闭窗口" onclick="printWB.ExecWB(45,1);"></input>
    </div>
    <form id="form1" runat="server">
    <div style="border-bottom: 1px solid black; padding-bottom: 5px; width: 900px; margin: 0 auto;"
        class="lighter">
        <span style="float: right; vertical-align: bottom; padding-top: 30px;">重庆西材商品交易市场印制</span><span><img
            width="220" height="50" src="../../templates/faxinglei/img/dayin_taitou.JPG" /></span></div>
    <div style="margin: 0 auto; width: 800px;">
        <div>
            <div>
                <h1>
                    授权委托书</h1>
                <p>
                    重庆西材商品交易市场：<br />
                    <br />
                    我单位现正式授权 <span style="text-decoration: underline;">
                        <%=data[0] %>&nbsp; </span>先生/女士,使用我单位<span style="text-decoration: underline; width: 10px;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>交易账户，
                    代表我单位进行商品交易，并全权处理我单位该账户在重庆西材商品交易市场下发生的相关交易品种交易、交收、结算、仓储等相关业务事宜，其所填写的有关内容，提供的有关资料和做出的一切与重庆西材商品交易市场相关业务行为，都是我单位意愿之体现，均视为我单位的行为，由我单位对此负全部责任，无任何异议。
                </p>
                <p style="float: right; width: 350px;">
                    委托单位（公章）:____________<br />
                    法定代表人（签字）:__________<br />
                    被授权人（签字）：___________<br />
                    授权日期 ：____年____月____日
                </p>
            </div>
        </div>
        <table class="style1">
            <tr>
                <td style="width: 200px;">
                    被授权人姓名
                </td>
                <td>
                    <%=data[0] %>
                </td>
                <td>
                    性别
                </td>
                <td>
                    <%=data[1] %>
                </td>
                <td>
                    年龄
                </td>
                <td>
                    <%=data[2] %>岁
                </td>
            </tr>
            <tr>
                <td>
                    身份证号码
                </td>
                <td>
                    <%=data[3] %>
                </td>
                <td>
                    联系电话
                </td>
                <td colspan="3">
                    <%=data[4] %>
                </td>
            </tr>
            <tr>
                <td>
                    详细地址
                </td>
                <td colspan="5">
                    <%=data[5] %>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="text-align: left;">
                    <%
                        System.Collections.Generic.List<string> li = new System.Collections.Generic.List<string>();
                        li.AddRange(new string[] { "工商银行", "工商银行-银企互联", "工商银行-易极付", "农业银行（国付宝）", "建设银行（E商贸通）", "民生银行（国付宝）" });
                        foreach (string item in li)
                        {
                            if (item == data[7])
                            {
                                Response.Write("<input type='checkbox' name='wangyin' style='margin-left:10px;' value='" + item + "' checked='checked' />" + item);
                                continue;
                            }
                            Response.Write("<input type='checkbox' name='wangyin' value='" + item + "' />" + item);

                        }
                    %>
                </td>
            </tr>
            <tr>
                <td>
                    开户行全称
                </td>
                <td colspan="5">
                    <%=data[6] %>
                </td>
            </tr>
            <tr>
                <td>
                    银行账号
                </td>
                <td colspan="5">
                    <%=data[8] %>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <img src="<%=data[9] %>" alt="Alternate Text" width="400" height="250" />
                </td>
                <td colspan="4">
                    <img src="<%=data[10] %>" alt="Alternate Text" width="400" height="250" />
                </td>
            </tr>
        </table>
        <br />
        <div style="font-weight: bolder;">
            注：银行开卡姓名须为与被授权人是同一人，信用卡、存折不作为开户依据</div>
    </div>
    <br />
    <div style="margin-bottom: 40px; border-top: 1px solid black; padding-top: 5px; width: 900px;
        margin: 0 auto;" class="lighter">
        <span style="float: right; vertical-align: bottom;">邮寄地址：重庆市北部新区新南路龙湖国际4栋23F
            <br />
            邮 编：401147<br />
            网址：http://www.xcce.com.cn http://www.xcce.cn</span><span>地址：重庆市双福新区圆润工业园B栋 3F<br />
                电话：400-051-6999 023-88199899
                <br />
                传真：023-88199799</span></div>
    </form>
</body>
</html>
