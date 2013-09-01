<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="RoleList.aspx.cs" Inherits="LPS.Web.Role.RoleList" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
             $(document).ready(function () {

                 $(".headerBtnAdd").click(function () {
                     var murl = "RoleEdit.aspx";
                     diag = new Dialog("Edit");
                     diag.URL = murl;
                     diag.Title = "添加角色";
                     diag.Width = 450;
                     diag.Height = 350;
                     diag.ShowButtonRow = false;
                     diag.OK = function (va) {
                         $.DialogRefrsh();
                     };
                     diag.show();
                 });

                 var editArr = $(".gvEdit");
                 editArr.each(function (i, o) {
                     var obj = $(o);
                     obj.click(function () {
                         var murl = 'RoleEdit.aspx?opType=alert&id=' + obj.attr("Guid");
                         diag = new Dialog("Edit");
                         diag.URL = murl;
                         diag.Title = "修改角色";
                         diag.Width = 450;
                         diag.Height = 350;
                         diag.ShowButtonRow = false;
                         diag.OK = function (va) {
                             $.DialogRefrsh();
                         };
                         diag.show();
                     });
                 });

                 var editArr = $(".deleteTS");
                 editArr.each(function (i, o) {
                     var obj = $(o);
                     obj.click(function () {
                         return confirm("你确定要删除此角色吗？");
                     });//end click
                 });//end each
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
                           <td style="text-align: right;">
                                    <img class="linkbutton_skin headerBtnAdd"  id="aBtnAdd" runat="server" src="../images/common/add_btn.gif" alt="" />
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
                            <asp:GridView ID="gvDataList" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:TemplateField HeaderText="权限设置">
                                        <ItemStyle Width="70px" />
                                        <ItemTemplate>
                                            <a href="RoleSet.aspx?guid=<%# Eval("Guid") %>" class="linkbutton_skin">
                                                <img alt="" src="../images/common/roseSetRight.gif" /></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
                                        <ItemTemplate>
                                            <a guid="<%# Eval("Guid") %>" class="gvEdit">
                                                <img src="../images/common/edit.gif" style="border: 0px;" alt="编辑" /></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click"
                                                CommandArgument='<%#Eval("Guid") %>' ImageUrl="~/images/common/delete.gif" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="RoleName" HeaderText="名称" />
                                    <asp:BoundField DataField="RoleDesc" HeaderText="描述" />
                                </Columns>
                            </asp:GridView>
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
