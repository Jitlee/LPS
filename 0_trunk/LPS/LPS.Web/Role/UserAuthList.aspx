<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true"
    CodeBehind="UserAuthList.aspx.cs" Inherits="LPS.Web.Role.UserAuthList" %>

<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../Scripts/Dialog.js"></script>
    

    <script type="text/javascript">
        $(document).ready(function () {
            var authArr = $(".imgUserAuth");
            authArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    var m_url = "UserAuthEdit.aspx?userid=" + obj.attr("userid");
                    diag = new Dialog("DgPrint");
                    diag.Width = 450;
                    diag.Height = 400;
                    diag.Title = "用户授权";
                    diag.URL = m_url;
                    diag.ShowButtonRow = false;
                    diag.OK = function (str) {
                        $.DialogRefrsh();
                    };
                    diag.show();
                }); //click

            }); //each
        });
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
                        <div id="pageBody">
                            <div class="minheight">
                                <table class="searchtable" cellspacing="0">
                                    <tr class="rows">
                                        <td style="width: 52px;" align="right">
                                            姓名：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtUserName" CssClass="textbox_skin" runat="server"></asp:TextBox>
                                        </td>
                                        <td style="width: 80px;" align="right">
                                            部门：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtdept" CssClass="textbox_skin" runat="server"></asp:TextBox>
                                        </td>
                                         <td style="width: 60px;">
                                         <asp:Button ID="btnStat" runat="server" Text="查询" OnClientClick="return $.yz.getErrorList()"
                                           Width="42"  OnClick="button_search_Click" CssClass="btn_bg" />
                                    </td>
                                    </tr>
                                </table>
                                <div class="fenyeheight">
                                    <asp:GridView ID="gvDataList" AutoGenerateColumns="false" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="序号">
                                                <ItemStyle Width="30" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="授权" HeaderStyle-Width="60">
                                                <ItemTemplate>
                                                    <img src="../images/common/roseSetRight.gif" style="border: 0px;" alt="授权" class="imgUserAuth"
                                                        userid="<%# Server.UrlEncode(Eval("EmpolyeeId").ToString().Trim()) %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="姓名" DataField="EmpolyeeName" />
                                            <asp:BoundField HeaderText="登录名" DataField="EmpolyeeCode" />
                                             
                                            <asp:BoundField HeaderText="角色" DataField="RoseNameList" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <table class="gridview_skin" cellspacing="0" cellpadding="0" rules="all" border="0"
                                                border="1" id="ContentPlaceHolder1_gvDataList" style="border-collapse: collapse;">
                                                <tr class="gridview_skin_header">
                                                    <th scope="col">
                                                        序号
                                                    </th>
                                                    <th scope="col">
                                                        授权
                                                    </th>
                                                    <th scope="col">
                                                        姓名
                                                    </th>
                                                    <th scope="col">
                                                        登录名
                                                    </th>
                                                   
                                                    <th scope="col">
                                                        角色
                                                    </th>
                                                </tr>
                                                <tr>
                                                <td colspan="6">没有角色！</td>
                                                </tr>
                                            </table>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
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
                        <uc2:pagenavigate ID="pagenavigate1" PageSize="20" runat="server" />
                    </div>
                </td>
                <td id="page_Bottom_Right">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
