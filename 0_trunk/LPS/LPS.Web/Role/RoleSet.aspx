<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true"
    CodeBehind="RoleSet.aspx.cs" Inherits="LPS.Web.Role.RoseSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../styles/permission .css" rel="Stylesheet" />
    <style type="text/css">
        #tbChild
        {
            border-collapse: collapse;
        }
        .iframe_top
        {
            height: 29px;
            line-height: 29px;
            background: #e3f0f6;
            border-left: 1px solid #CCC;
            border-right: 1px solid #CCC;
            border-top: 1px solid #8fb6df;
            padding: 0px 5px;
            text-align:left;
        }
        #DivRole
        {
            border: 1px solid #CCCCCC;
            padding: 10px;
            background-color: #fafafc;
        }
    </style>
    <script type="text/javascript">
    <!--
        $(document).ready(function () {

            $(".permissions0").find("input").click(function () {
                var p = $(this);

                var check = false;
                if (p.attr("checked")) check = true;
                p.parents(".div0").find("input").attr("checked", check);
            });

            $(".permissions1").find("input").click(function () {
                var p = $(this);
                var checked = false;
                if (p.attr('checked')) checked = true;
                var childLeftItem = p.parents("tr:first").find("input").attr('checked', checked);
                var top = p.parents(".div0:first").find("input:first");
                if (checked && !top.attr('checked')) {
                    top.attr('checked', true);
                } else if (!checked && p.parents("table:first").find("input:checked").length == 0) {
                    top.attr('checked', false);
                }
            });

            $(".permissions2").find("input").click(function () {
                var p = $(this);
                var checked = p.attr('checked');
                if (checked) {
                    p.parents("tr:first").find("input:first").attr('checked', checked);
                    p.parents(".div0:first").find("input:first").attr('checked', checked);
                }
            });

            /*隐藏显示元素*/
            $(".cssHref").click(function () {
                var p = $(this).parent().next();
                var par = $(this).children();
                if (p.attr('class') == "tb") {
                    par.attr("src", "../images/common/radd.gif");
                    p.attr("class", "tbNoShow");
                }
                else {
                    par.attr("src", "../images/common/radd-.gif")
                    p.attr("class", "tb");
                }
            })
        });
    -->
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            <td style="text-align: right">
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
    <div id="page_Middle" style="text-align: left;">
        <table style="width: 100%;" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td id="page_Middle_Left">
                    &nbsp;
                </td>
                <td id="page_Middle_Middle">
                    <div id="page">
                        <div id="pageBody">
                            <table width="100%" cellpadding="0" cellspacing="0" border="0" class="tabbg">
                                <tr>
                                    <td style="width: 20px;">
                                        <img src="../images/search-icon.gif" alt="" />
                                    </td>
                                    <td align="left">
                                        权限设置信息
                                    </td>
                                </tr>
                            </table>
                            <div class="iframe_top">
                                角色名称：<asp:Label ID="lblName" runat="server"></asp:Label>
                                &nbsp;&nbsp;&nbsp;&nbsp; 描述：<asp:Label ID="lblDesc" runat="server"></asp:Label>
                            </div>
                            <div id="DivRole" style=" text-align:left;">
                                <asp:Repeater ID="rptMenu0" runat="server">
                                    <ItemTemplate>
                                        <div class="div0">
                                            <div  title='<%# Eval("MOD_NAME") %>'>
                                                <a class="cssHref">
                                                    <img src="../images/common/radd-.gif" alt="" border="0" /></a>
                                                <asp:CheckBox ID="cb0" CssClass="permissions0" runat="server" Checked='<%# Eval("IsChecked") %>'
                                                    Text='<%# Eval("MOD_NAME")%>' />
                                                <asp:Label runat="server" ID="lb0" Visible="false" Text='<%# Eval("MOD_URL") %>' />
                                                <hr />
                                            </div>
                                            <table cellpadding="0" cellspacing="0" id="tbChild" class="tb" width="100%">
                                                <asp:Repeater ID="rptMenu1" DataSource='<%# GetMenuList(Eval("MOD_URL")) %>' runat="server">
                                                    <ItemTemplate>
                                                        <tr>
                                                            <td class="lefttd">
                                                                <asp:CheckBox ID="cb1" CssClass="permissions1" runat="server" Checked='<%# Eval("IsChecked") %>'
                                                                    Text='<%# Eval("MOD_NAME")%>' ToolTip='<%# Eval("MOD_DESC") %>' />
                                                                <asp:Label runat="server" ID="lb1" Visible="false" Text='<%# Eval("MOD_URL") %>' />
                                                            </td>
                                                            <td class="secondtd">
                                                                <asp:Repeater ID="rptMenu2" runat="server" DataSource='<%# GetMenuList(Eval("MOD_URL")) %>'>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox runat="server" ID="cb2" CssClass="permissions2" Checked='<%# Eval("IsChecked") %>'
                                                                            Text='<%# Eval("MOD_NAME")%>' ToolTip='<%# Eval("MOD_DESC") %>' />
                                                                        <asp:Label runat="server" ID="lb2" Visible="false" Text='<%# Eval("MOD_URL") %>' />
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </table>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
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
                    <div>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btn_Save_Click">
                                <img src="../images/common/save.gif" alt="" />保存</asp:LinkButton>
                    </div>
                </td>
                <td id="page_Bottom_Right">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
