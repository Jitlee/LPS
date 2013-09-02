<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeafLevelEdit.aspx.cs" Inherits="LPS.Web.Base.BaseLeafLevelEdit" %>

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
<tr><td class="tdRight">等级名称：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtLeafLevelName" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">等级描述：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtLeafLevelDesc" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">烟叶等级价格：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtLeafLevelPrice" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">排序：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtLeafLevelSort" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">是否删除：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtLeafLevelIsDeleted" CssClass="textbox_skin" /> </td></tr>
<tr><td class="tdRight">删除日期：</td><td class="tdLeft" > <asp:TextBox  runat="server" ID="txtLeafLevelDeletedDate" CssClass="textbox_skin" /> </td></tr>

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

