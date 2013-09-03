<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true"
	CodeBehind="EmpolyeeList.aspx.cs" Inherits="LPS.Web.Base.BaseEmpolyeeList" %>

<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">

		$(document).ready(function () {
			$(".headerBtnAdd").click(function () {
				var murl = 'EmpolyeeEdit.aspx';
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
					var murl = 'EmpolyeeEdit.aspx?opType=alert&id=' + obj.attr("Guid");
					diag = new Dialog("Edit");
					diag.URL = murl;
					diag.Title = "修改用户";
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
							<asp:GridView ID="gvBaseEmpolyee" AutoGenerateColumns="false" runat="server">
								<Columns>
									<asp:TemplateField HeaderText="序号">
										<ItemStyle BackColor="#bdeaff" Width="35" />
										<ItemTemplate>
											<%# Container.DataItemIndex+1 %>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
										<ItemTemplate>
											<a guid="<%# Eval("EmpolyeeId") %>" class="gvEdit">
												<img src="../images/Common/edit.gif" style="border: 0px;" alt="编辑" /></a>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
										<ItemTemplate>
											<asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click"
												CommandArgument='<%#Eval("EmpolyeeId") %>' ImageUrl="~/images/Common/delete.gif"
												runat="server" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="EmpolyeeCode" HeaderText="编号" />
									<asp:BoundField DataField="EmpolyeeRfid" HeaderText="RFID" />
									<asp:BoundField DataField="EmpolyeeName" HeaderText="名称" />
									<asp:BoundField DataField="EmpolyeePy" HeaderText="拼音缩写" />
									<asp:BoundField DataField="EmpolyeeSex" HeaderText="性别" />
									<asp:BoundField DataField="EmpolyeeBirth" DataFormatString="{0: yyyy-MM-dd}" HeaderText="出生日期" />
									<asp:BoundField DataField="EmpolyeeEntryDate" DataFormatString="{0: yyyy-MM-dd}" HeaderText="入职日期" />
									<asp:BoundField DataField="EmpolyeePhone" HeaderText="手机号" />
									<asp:BoundField DataField="EmpolyeeEmail" HeaderText="电子邮箱" />
									<asp:BoundField DataField="EmpolyeeAddress" HeaderText="联系地址" />
									<asp:BoundField DataField="EmpolyeeHometown" HeaderText="籍贯" />
									<asp:BoundField DataField="EmpolyeeCardId" HeaderText="身份证号" />
									<asp:BoundField DataField="UserId" HeaderText="用户ID" />
									<asp:BoundField DataField="EmpolyeeCreateDate" DataFormatString="{0: yyyy-MM-dd}" HeaderText="创建日期" />
									<asp:BoundField DataField="EmpolyeeIsDeleted" HeaderText="删除 " />
									<asp:BoundField DataField="EmpolyeeDeletedDate" DataFormatString="{0: yyyy-MM-dd}" HeaderText="删除日期" />
								</Columns>
								<EmptyDataTemplate>
									<table class="gridview_skin" cellspacing="0" cellpadding="0" rules="all"  border="1"  style="border-collapse:collapse;">
										<tr class="gridview_skin_header">
											<th>
												员工编号
											</th>
											<th>
												员工RFID
											</th>
											<th>
												员工名称
											</th>
											<th>
												员工拼音缩写
											</th>
											<th>
												员工性别
											</th>
											<th>
												员工出生日期
											</th>
											<th>
												员工入职日期
											</th>
											<th>
												员工手机号
											</th>
											<th>
												员工电子邮箱
											</th>
											<th>
												员工联系地址
											</th>
											<th>
												员工籍贯
											</th>
											<th>
												员工身份证号
											</th>
											<th>
												用户ID
											</th>
											<th>
												用户密码
											</th>
											<th>
												员工创建日期
											</th>
											<th>
												N 表示已删除
											</th>
											<th>
												员工删除日期
											</th>
										</tr>
										<tr>
											<td colspan="17">
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
