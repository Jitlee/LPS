<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="LeafLevelList.aspx.cs" Inherits="LPS.Web.Base.BaseLeafLevelList" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $(".headerBtnAdd").click(function () {
                var strVar = 'BaseLeafLevelEdit.aspx';
                $.popup({ title: "添加", url: strVar, borderStyle: { height: 600, width: 500 }, ok: function (obj) {

                    $.popup.Refrsh();
                }
                }); //$.popup

            });

            var editArr = $(".gvEdit");
            editArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    var m_url = 'BaseLeafLevelEdit.aspx?opType=alert&id=' + obj.attr("Guid");
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
    <asp:GridView ID="gvBaseLeafLevel" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemStyle BackColor="#bdeaff" Width="25" />
                <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <a  guid="<%# Eval("LeafLevel") %>" class="gvEdit"><img src="../images/Common/edit.gif" style="border: 0px;" alt="编辑" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click" CommandArgument='<%#Eval("LeafLevel") %>' ImageUrl="~/images/Common/delete.gif" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
			<asp:BoundField DataField="LeafLevelName" HeaderText="等级名称"  />
			<asp:BoundField DataField="LeafLevelDesc" HeaderText="等级描述"  />
			<asp:BoundField DataField="LeafLevelPrice" HeaderText="烟叶等级价格"  />
			<asp:BoundField DataField="LeafLevelSort" HeaderText="排序"  />
			<asp:BoundField DataField="LeafLevelIsDeleted" HeaderText="是否删除"  />
			<asp:BoundField DataField="LeafLevelDeletedDate" HeaderText="删除日期"  />
        </Columns>
        <EmptyDataTemplate>
            <table class="empty_gridview" cellspacing="0">
				<tr>
					<th>
						等级名称
					</th>
					<th>
						等级描述
					</th>
					<th>
						烟叶等级价格
					</th>
					<th>
						排序
					</th>
					<th>
						是否删除
					</th>
					<th>
						删除日期
					</th>
				</tr>
                <tr>
                    <td colspan="6">
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

