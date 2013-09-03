<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true"
	CodeBehind="FarmerList.aspx.cs" Inherits="LPS.Web.Base.BaseFarmerList" %>

<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">

		$(document).ready(function () {
			$(".headerBtnAdd").click(function () {
				var murl = 'FarmerEdit.aspx';
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
					var murl = 'FarmerEdit.aspx?opType=alert&id=' + obj.attr("Guid");
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
							<asp:GridView ID="gvBaseFarmer" AutoGenerateColumns="false" runat="server">
								<Columns>
									<asp:TemplateField HeaderText="序号">
										<ItemStyle BackColor="#bdeaff" Width="35" />
										<ItemTemplate>
											<%# Container.DataItemIndex+1 %>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
										<ItemTemplate>
											<a guid="<%# Eval("FarmerId") %>" class="gvEdit">
												<img src="../images/Common/edit.gif" style="border: 0px;" alt="编辑" /></a>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
										<ItemTemplate>
											<asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click"
												CommandArgument='<%#Eval("FarmerId") %>' ImageUrl="~/images/Common/delete.gif"
												runat="server" />
										</ItemTemplate>
									</asp:TemplateField>
									<asp:BoundField DataField="FarmarCode" HeaderText="烟农编码" />
									<asp:BoundField DataField="FarmerRfid" HeaderText="烟农RFID标识" />
									<asp:BoundField DataField="FarmerName" HeaderText="烟农名称" />
									<asp:BoundField DataField="FarmerPy" HeaderText="烟农拼音缩写" />
									<asp:BoundField DataField="FarmerPhone" HeaderText="烟农电话" />
									<asp:BoundField DataField="FarmerEmail" HeaderText="烟农电子邮箱" />
									<asp:BoundField DataField="FarmerAddress" HeaderText="烟农地址" />
									<asp:BoundField DataField="FarmerRmark" HeaderText="备注" />
									<asp:BoundField DataField="FarmerSex" HeaderText="性别" />
									<asp:BoundField DataField="FarmerBirth" HeaderText="出生日期" />
									<asp:BoundField DataField="FarmerCardId" HeaderText="身份证" />
									<asp:BoundField DataField="FarmerIsDeleted" HeaderText="是否删除" />
								</Columns>
								<EmptyDataTemplate>
									<table class="gridview_skin" cellspacing="0" cellpadding="0" rules="all"  border="1"  style="border-collapse:collapse;">
										<tr class="gridview_skin_header">
											<th>
												烟农编码
											</th>
											<th>
												烟农RFID标识
											</th>
											<th>
												烟农名称
											</th>
											<th>
												烟农拼音缩写
											</th>
											<th>
												烟农电话
											</th>
											<th>
												烟农电子邮箱
											</th>
											<th>
												烟农地址
											</th>
											<th>
												备注
											</th>
											<th>
												性别
											</th>
											<th>
												出生日期
											</th>
											<th>
												身份证
											</th>
											<th>
												创建日期
											</th>
											<th>
												是否删除
											</th>
											<th>
												删除日期
											</th>
										</tr>
										<tr>
											<td colspan="14">
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
