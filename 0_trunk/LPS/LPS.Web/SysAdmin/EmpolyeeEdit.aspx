<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpolyeeEdit.aspx.cs" Inherits="LPS.Web.Base.BaseEmpolyeeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title><#ClassTitle>信息</title>
    <link href="../Styles/PopuWindow.css" rel="Stylesheet" />
    <link href="../Styles/right.css" rel="Stylesheet" />
    <script type="text/javascript" src="../Scripts/jquery-1.4.4.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.bgiframe.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.popup.js"></script>
    <script type="text/javascript" src="../Scripts/EditCommon.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {

        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wdiv" class="wdiv">
        <table  id="tbContentMain" border="0" cellpadding="0" cellspacing="0" class="window_table" runat="server">
<tr><td class="tdRight">员工编号：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeeCode" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工RFID：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeeRfid" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工名称：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeeName" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工拼音缩写：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeePy" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工性别：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeeSex" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工出生日期：</td><td class="tdLeft" > <asp:TextBox  ID="txtEmpolyeeBirth" CssClass="textbox_skin"  onfocus="WdatePicker();"  runat="server"/> </td></tr>
<tr><td class="tdRight">员工入职日期：</td><td class="tdLeft" > <asp:TextBox  ID="txtEmpolyeeEntryDate" CssClass="textbox_skin"  onfocus="WdatePicker();"  runat="server"/> </td></tr>
<tr><td class="tdRight">员工手机号：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeePhone" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工电子邮箱：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeeEmail" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工联系地址：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeeAddress" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工籍贯：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeeHometown" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工身份证号：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeeCardId" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">用户ID：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtUserId" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">用户密码：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtUserPwd" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工创建日期：</td><td class="tdLeft" > <asp:TextBox  ID="txtEmpolyeeCreateDate" CssClass="textbox_skin"  onfocus="WdatePicker();"  runat="server"/> </td></tr>
<tr><td class="tdRight">N 表示已删除 ：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtEmpolyeeIsDeleted" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">员工删除日期：</td><td class="tdLeft" > <asp:TextBox  ID="txtEmpolyeeDeletedDate" CssClass="textbox_skin"  onfocus="WdatePicker();"  runat="server"/> </td></tr>

        </table>
    </div>
    <div class="window_footer_div">
        <div style="padding-top:5px;">
        <asp:LinkButton ID="lbtSave" runat="server" CssClass="ibtnwindow" OnClick="lbtSave_Click" OnClientClick="return $.yz.getErrorList()">
                <img src="../images/icon/save.gif" border="0" alt="保存" />保存
        </asp:LinkButton>&nbsp;
        <a class="ibtnwindow" href="javascript:;" onclick="$.popup.close();">
            <img src="../images/icon/delete.gif" border="0" alt="" />关闭
        </a>
        </div>
    </div>
    </form>
</body>
</html>

