<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="DictronaryTypeList.aspx.cs" Inherits="LPS.Web.Base.BaseDictronaryTypeList" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $(".headerBtnAdd").click(function () {
                var strVar = 'BaseDictronaryTypeEdit.aspx';
                $.popup({ title: "添加", url: strVar, borderStyle: { height: 600, width: 500 }, ok: function (obj) {

                    $.popup.Refrsh();
                }
                }); //$.popup

            });

            var editArr = $(".gvEdit");
            editArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    var m_url = 'BaseDictronaryTypeEdit.aspx?opType=alert&id=' + obj.attr("Guid");
                    $.popup({ title: "修改", url: m_url, borderStyle: { height: 600, width: 500 }, ok: function () {
                        $.popup.Refrsh();
                    }
                    }); //$.popup
                });
            });

            var editArr = $(".deleteTS");
            editArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    return confirm("你确定要删除此数据吗？");
                });
            });

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
        <td width="6"><img src="../images/gridview/gridheader_03.gif" alt="" /></td>
        <td>列表</td>
        <td width="60"><a class="headerBtnAdd" id="aBtnAdd" runat="server"><img src="../images/Common/add_btn.gif" /></a></td>
        <td width="6"><img src="../images/gridview/gridheader_06.gif" alt="" /></td>
        </tr>
    </table>
    <div class="divgrid">
    
    <div class="overflow_grid">
    <asp:GridView ID="gvBaseDictronaryType" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemStyle BackColor="#bdeaff" Width="25" />
                <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <a  guid="<%# Eval("DictType") %>" class="gvEdit"><img src="../images/Common/edit.gif" style="border: 0px;" alt="编辑" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click" CommandArgument='<%#Eval("DictType") %>' ImageUrl="~/images/Common/delete.gif" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
			<asp:BoundField DataField="DictTypeName" HeaderText="类型名称"  />
			<asp:BoundField DataField="DictTypeDesc" HeaderText="描述"  />
        </Columns>
        <EmptyDataTemplate>
            <table class="empty_gridview" cellspacing="0">
                <tr>
                                                    <th></th>                                <th></th>
                </tr>
                <tr>
                    <td colspan="2">
                        没有数据
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
    </asp:GridView>
    </div>
    <uc2:pagenavigate ID="pg" runat="server" />
    </div>
</asp:Content>

