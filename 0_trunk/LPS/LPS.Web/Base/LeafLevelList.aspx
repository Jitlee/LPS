<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true"
	CodeBehind="LeafLevelList.aspx.cs" Inherits="LPS.Web.Base.BaseLeafLevelList" %>

<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">

		$(document).ready(function () {
			$(".headerBtnAdd").click(function () {
				var murl = 'LeafLevelEdit.aspx';
				diag = new Dialog("Edit");
				diag.URL = murl;
				diag.Title = "添加";
				diag.Width = 600;
				diag.Height = 500;
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
					var murl = 'LeafLevelEdit.aspx?opType=alert&id=' + obj.attr("Guid");
					diag = new Dialog("Edit");
					diag.URL = murl;
					diag.Title = "修改";
					diag.Width = 600;
					diag.Height = 500;
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
					return confirm("你确定要删除此数据吗？");
				});
			});

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
								<img class="linkbutton_skin headerBtnAdd" id="aBtnAdd" runat="server" src="../images/common/add_btn.gif"
									alt="" />
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
							<asp:GridView ID="gvBaseLeafLevel" AutoGenerateColumns="false" runat="server">
								<Columns>
									<asp:TemplateField HeaderText="序号">
										<ItemStyle BackColor="#bdeaff" Width="35" />
										<ItemTemplate>
											<%# Container.DataItemIndex+1 %>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
										<ItemTemplate>
											<a guid="<%# Eval("LeafLevel") %>" class="gvEdit">
												<img src="../images/Common/edit.gif" style="border: 0px;" alt="编辑" /></a>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
										<ItemTemplate>
											<asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click"
												CommandArgument='<%#Eval("LeafLevel") %>' ImageUrl="~/images/Common/delete.gif"
												runat="server" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="LeafLevelName" HeaderText="等级名称" />
									<asp:BoundField DataField="LeafLevelDesc" HeaderText="等级描述" />
									<asp:BoundField DataField="LeafLevelPrice" HeaderText="烟叶等级价格" />
									<asp:BoundField DataField="LeafLevelSort" HeaderText="排序" />
									<asp:BoundField DataField="LeafLevelIsDeleted" HeaderText="是否删除" />
									<asp:BoundField DataField="LeafLevelDeletedDate" HeaderText="删除日期" />
								</Columns>
								<EmptyDataTemplate>
									<table class="gridview_skin" cellspacing="0" cellpadding="0" rules="all"  border="1"  style="border-collapse:collapse;">
										<tr class="gridview_skin_header">
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
						<uc2:pagenavigate ID="pg" PageSize="20" runat="server" />
					</div>
				</td>
				<td id="page_Bottom_Right">
					&nbsp;
				</td>
			</tr>
		</table>
	</div>
</asp:Content>
