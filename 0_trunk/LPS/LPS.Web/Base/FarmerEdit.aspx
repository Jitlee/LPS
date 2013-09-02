<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FarmerEdit.aspx.cs" Inherits="LPS.Web.Base.BaseFarmerEdit" %>

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
<tr><td class="tdRight">烟农编码：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmarCode" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">烟农RFID标识：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerRfid" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">烟农名称：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerName" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">烟农拼音缩写：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerPy" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">烟农电话：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerPhone" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">烟农电子邮箱：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerEmail" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">烟农地址：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerAddress" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">备注：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerRmark" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">性别：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerSex" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">出生日期：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerBirth" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">身份证：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerCardId" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">创建日期：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerCreateDate" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">是否删除：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerIsDeleted" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">删除日期：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtFarmerDeletedDate" CssClass="textbox_skin" /> </td></tr>

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

