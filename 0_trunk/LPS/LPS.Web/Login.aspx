<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LPS.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>用户登录</title>
    <link href="Styles/login.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery-1.8.3.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#btn").click(function () {
                var txtName = $("#tbxUserCode");
                var txtPwd = $("#tbxPassword");
                if (txtName.val() == "") {
                    alert("用户名不能为空！");
                    txtName.focus();
                    return false;
                }

                if (txtPwd.val() == "") {
                    alert("密码不能为空！");
                    txtPwd.focus();
                    return false;
                }
            });

        });
    </script>
</head>
<body>
    <div id="login">
        <form id="form1" runat="server">
            <div id="logintb">
                <table style="width:300" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td style="width:63">
                            用户名：
                        </td>
                        <td style="width:237;text-align:left;">
                            <asp:TextBox ID="tbxUserCode" autocomplete="off" runat="server" Maxlength="16" CssClass="tbxSty" 
                                meta:resourcekey="tbxUserCodeResource1"></asp:TextBox>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密&nbsp;&nbsp;码：
                        </td>
                        <td style="text-align:left">
                            <asp:TextBox ID="tbxPassword" runat="server" maxlength="16" 
                                TextMode="Password"  CssClass="tbxSty" 
                                meta:resourcekey="tbxPasswordResource1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td style="text-align:left"><asp:ImageButton ID="btn" runat="server" 
                                ImageUrl="~/images/login/dl.gif" onclick="btn_Click" 
                                meta:resourcekey="btnResource1" />
                            </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:center">
                            &nbsp;<asp:Label ID="labMessage" runat="server" 
                                meta:resourcekey="labMessageResource1"></asp:Label></td>
                    </tr>
                </table>
            </div>
        </form>
    </div>
</body>
</html>
