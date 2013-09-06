<%@ Page Title="" Language="C#" MasterPageFile="~/Main/MasterPage.master" AutoEventWireup="true"
	CodeBehind="DictronaryList.aspx.cs" Inherits="LPS.Web.Base.BaseDictronaryList" %>

<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
.first_level 
{
    background-color:#EAEAEA;
    border:1px solid #cdced0;
    height:27px;
    line-height:27px;
    color:#333333;
    margin-top:5px;
    width:100%;
}
.first_level a
{
    float:right;
    margin-right:20px;
}
.second_level 
{
    background:#fafafc;
	line-height:27px;
    border-left:1px solid #cdced0;
    border-right:1px solid #cdced0;
    border-bottom:1px solid #cdced0;
    width:100%;
}
.second_level span
{
    width:180px; float:left; padding:0px 0px 0px 10px;
}
a.data_dictionary:link
{
    color:#034af3;
    text-decoration: none;
}
a.data_dictionary:visited
{
    color:#3366cc;
    text-decoration: none;
}
a.data_dictionary:hover
{
    color: #ff6633;
}
</style>
	<script type="text/javascript">

	    $(document).ready(function () {
	        $(".headerBtnEdit").each(function (i, o) {
	            $(o).click(function () {
	                var murl = 'DictronaryEdit.aspx?val=' + $(this).attr("Value");
	                diag = new Dialog("Edit");
	                diag.URL = murl;
	                diag.Title = "数据字典管理";
	                diag.Width = 600;
	                diag.Height = 500;
	                diag.ShowButtonRow = false;
	                diag.OK = function (va) {
	                    $.DialogRefrsh();
	                };
	                diag.show();
	                return false;
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
                            <table  class="searchtable" cellspacing="0">
                                <tr class="rows">
                                    <th width="70">
                                        查询大类：
                                    </th>
                                    <td width="160">
                                        <asp:TextBox ID="txtMain" runat="server"></asp:TextBox>
                                    </td>
                                    <td style=" text-align:left;">
                                        <asp:Button ID="btnSearch" runat="server" Text="查询" CssClass="btn_bg vertical_middle"
                                            OnClick="btnSearch_Click" OnClientClick="return $.yz.getErrorList()" />
                                    </td>
                                </tr>
                            </table>
                            <div style=" padding:0px; margin:0px; width:100%; overflow-x:hidden;">
                                <asp:Repeater ID="rptDataDictionaryTitle" runat="server" OnItemDataBound="rptDataDictionaryTitle_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="first_level">
                                            <strong style="float: left; padding-left: 5px;">
                                                <%# Eval("DictTypeName")%></strong>
                                            <asp:LinkButton ID="lbtnEdit" runat="server" Text="[编辑]" CssClass="headerBtnEdit data_dictionary"
                                                Value='<%#Eval("DictType")%>'></asp:LinkButton>
                                            <asp:HiddenField ID="Hidden1" runat="server" Visible="false" Value='<%#Eval("DictType")%>' />
                                        </div>
                                        <div class="second_level">
                                            <asp:Repeater ID="rptDataDictionarySub" runat="server">
                                                <ItemTemplate>
                                                    <span>
                                                        <%# Eval("DictCode")%></span>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <div style="clear: both;">
                                            </div>
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
						<%--<uc2:pagenavigate ID="pg" PageSize="20" runat="server" />--%>
                        &nbsp;
					</div>
				</td>
				<td id="page_Bottom_Right">
					&nbsp;
				</td>
			</tr>
		</table>
	</div>
</asp:Content>
