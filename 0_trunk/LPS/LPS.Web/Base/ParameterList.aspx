<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true" CodeBehind="ParameterList.aspx.cs" Inherits="LPS.Web.Base.ParameterList" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">

	    $(document).ready(function () {
	         

	        var editArr = $(".gvEdit");
	        editArr.each(function (i, o) {
	            var obj = $(o);
	            obj.click(function () {
	                var murl = 'ParameterEdit.aspx?opType=alert&id=' + obj.attr("Guid") + "&ParamType=" + obj.attr("ParamType");
	                diag = new Dialog("Edit");
	                diag.URL = murl;
	                diag.Title = "修改参数";
	                diag.Width = 450;
	                diag.Height = 350;
	                diag.ShowButtonRow = false;
	                diag.OK = function (va) {
	                    $.DialogRefrsh();
	                };
	                diag.show();
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
							<asp:GridView ID="gv" AutoGenerateColumns="false" runat="server">
								<Columns>
									<asp:TemplateField HeaderText="序号">
										<ItemStyle BackColor="#bdeaff" Width="35" />
										<ItemTemplate>
											<%# Container.DataItemIndex+1 %>
										</ItemTemplate>
									</asp:TemplateField>
									<asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
										<ItemTemplate>
											<a guid="<%# Eval("ParamCode") %>" ParamType="<%# Eval("ParamType") %>" class="gvEdit">
												<img src="../images/Common/edit.gif" style="border: 0px;" alt="编辑" /></a>
										</ItemTemplate>
									</asp:TemplateField>
                                    
									<asp:BoundField DataField="ParamName" HeaderText="名称" />
									<asp:BoundField DataField="ParamValue" HeaderText="值" />
									<asp:BoundField DataField="ParamDesc" HeaderText="描述" />
								</Columns>
								<EmptyDataTemplate>
									<table class="gridview_skin" cellspacing="0" cellpadding="0" rules="all"  border="1"  style="border-collapse:collapse;">
										<tr class="gridview_skin_header">
											<th>名称</th>
											<th>值</th>
											<th>描述</th>
										</tr>
										<tr>
											<td colspan="5">
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

