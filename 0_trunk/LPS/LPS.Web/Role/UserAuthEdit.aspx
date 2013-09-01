<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserAuthEdit.aspx.cs" Inherits="LPS.Web.Role.UserAuthEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>角色管理</title>
    <link href="../../styles/main.css" rel="stylesheet" type="text/css" />
    <link href="../../styles/page.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../Scripts/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../Scripts/Dialog.js"></script>
    <script type="text/javascript" src="../Scripts/main.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#txtName").yz({ title: "角色名称", type: "string", max: 50, isSave: true });            
        });
    </script>
    <style type="text/css">
     .iframe_top
        {
            height: 29px;
            line-height: 29px;
            background: #e3f0f6;
            font-family: Arial,宋体;
            border:1px solid #8fb6df;
            padding:0px 5px;
            text-align:left;
        }
        .role_table
        {
            width:100%;
            margin-top:2px;
            background-color:#fafafc;
            border:1px solid #cdced0;
	        font-size:12px;
        }
       .role_table td{  text-align:left;}
       
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div id="page_Top">
        <table style="width: 100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td id="page_Top_Left">
                    &nbsp;
                </td>
                <td id="page_Top_Middle">
                    <table style="width: 100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>
                                <div id="nav1">
                                    <span class="STYLE3">你当前的位置</span>：[<asp:SiteMapPath ID="SiteMapPath1" runat="server"
                                        PathSeparator="]-[">
                                    </asp:SiteMapPath>
                                    ]</div>
                            </td>
                        </tr>
                    </table>
                </td>
                <td id="page_Top_Right">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="page_Middle">
        <table style="width: 100%;" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td id="page_Middle_Left">
                    &nbsp;
                </td>
                <td id="page_Middle_Middle">
                    <div id="page">
                        <div id="pageBody" style="padding: 15px;">
                            <div class="iframe_top">
                                用户姓名:<asp:Label ID="txt_ShowName" runat="server"></asp:Label>
                                &nbsp; 系统登录名:<asp:Label ID="txt_LoginCode" runat="server"></asp:Label>
                            </div>
                           
                            <table class="role_table">
                                <tr>
                                    <td>
                                        <div style="line-height: 30px;  font-size:14px; text-align:left;">
                                        请选择要授予的角色：</div>

                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBoxList RepeatDirection="Vertical" Width="100%" RepeatColumns="2" ID="cblRoseList"
                                            runat="server" CellPadding="0" CellSpacing="0" CssClass="CheckBoxList">
                                        </asp:CheckBoxList>
                                    </td>
                                </tr>
                            </table>
                                
                                
                            
                        </div>
                    </div>
                </td>
                <td id="page_Middle_Right">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    <div id="page_Bottom">
        <table style="width: 100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td id="page_Bottom_Left">
                    &nbsp;
                </td>
                <td id="page_Bottom_Middle">
                    <table style="width: 100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td>

                             <asp:LinkButton ID="lbtSave" runat="server" CssClass="ibtnwindow" OnClick="btn_Save_Click">
                <img src="../images/common/save.gif" border="0" alt="保存" />保存
            </asp:LinkButton>&nbsp; 
                                <a class="linkbutton_skin" href="javascript:;" onclick="$.DialogClose();">
                                    <img src="../images/common/delete.gif" alt="" />关闭</a>
                            </td>
                        </tr>
                    </table>
                </td>
                <td id="page_Bottom_Right">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

