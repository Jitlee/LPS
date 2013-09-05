<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictronaryEdit.aspx.cs"
	Inherits="LPS.Web.Base.BaseDictronaryEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>信息</title>
	<link href="../styles/main.css" rel="stylesheet" type="text/css" />
	<link href="../styles/page.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../Scripts/jquery-1.8.3.min.js"></script>
	<script type="text/javascript" src="../Scripts/Dialog.js"></script>
	<script type="text/javascript" src="../Scripts/main.js"></script>
	<script type="text/javascript" src="../Scripts/jquery.validator.js"></script>
	<script type="text/javascript">
		$(document).ready(function () {

		});
	</script>
    <style type="text/css">
        .data_dictionary_div
        {
	        background-color:#fafafc;
	        border:1px solid #cdced0;
	        font-size:12px;
	        width:90%;
	        margin:10px auto;
	        padding:10px;
        }
        .data_dictionary_gridview
        {
	        width:100%;
        }
        .data_dictionary_gridview td
        {
	        border-bottom:1px dashed Gray;
	        padding-top:10px;
        }
    </style>
</head>
<body>
	<form id="form1" runat="server">
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
                        <div id="pageBody" style="padding: 15px;">
                            <div class="data_dictionary_div">
                                添加子类：
                                <asp:TextBox ID="txtAddSub" runat="server" MaxLength="15" CssClass="vertical_middle"></asp:TextBox>
                                <font style="color: Red;">*</font>
                                <asp:Button ID="btnAddSub" runat="server" Text="添加" CssClass="btn_bg vertical_middle"
                                    OnClick="btnAddSub_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注：子类最多只能输入15字。
                                <br />
                                <asp:Label ID="lblAlert" runat="server" ForeColor="Red"></asp:Label>
                            </div>
                            <div class="data_dictionary_div">
                                <strong>
                                    <asp:Label ID="lblmain" runat="server"></asp:Label></strong>
                                <asp:TextBox ID="txtMain" runat="server"></asp:TextBox>
                                <asp:ImageButton ID="ibtnTitleEdit" runat="server" ImageUrl="~/images/Common/edit.gif"
                                    ToolTip="编辑" CssClass="vertical_middle" OnClick="ibtnTitleEdit_Click" />
                                <asp:LinkButton ID="lbtnUpdate" runat="server" Text="保存" CssClass="data_dictionary"
                                    OnClick="lbtnUpdate_Click" OnClientClick="return $.yz.getErrorList()"></asp:LinkButton>
                                <asp:LinkButton ID="lbtnCancel" runat="server" Text="取消" CssClass="data_dictionary"
                                    OnClick="lbtnCancel_Click"></asp:LinkButton>
                                <asp:GridView ID="gridSubName" runat="server" AutoGenerateColumns="false" CssClass="data_dictionary_gridview"
                                    SkinID="ewrewq" ShowHeader="false" GridLines="None" DataKeyNames="ID" OnRowCancelingEdit="gridSubName_RowCancelingEdit"
                                    OnRowDeleting="gridSubName_RowDeleting" OnRowEditing="gridSubName_RowEditing"
                                    OnRowUpdating="gridSubName_RowUpdating">
                                    <Columns>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtsubName" runat="server" Text='<%#Bind("DictType")%>' CssClass="txtsubName"></asp:TextBox>
                                                <asp:HiddenField ID="hideSub" runat="server" Value='<%#Bind("DictType")%>' />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="lblsubName" runat="server" Text='<%#Eval("DictType")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="60" />
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lbtnUpdate" runat="server" CausesValidation="True" CommandName="Update"
                                                    Text="保存" CssClass="ibtnwindow"></asp:LinkButton>
                                                <asp:LinkButton ID="lbtnCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                                    Text="取消" CssClass="ibtnwindow"></asp:LinkButton>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" ImageUrl="~/images/Common/edit.gif"
                                                    ToolTip="编辑" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemStyle Width="60" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" ImageUrl="~/images/Common/delete.gif"
                                                    ToolTip="删除" AlternateText="删除" OnClientClick="return confirm('您确定要删除该子类吗?');" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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
					<table style="width: 100%" border="0" cellspacing="0" cellpadding="0">
						<tr>
							<td>
								 
                                <img src="../images/common/save.gif" alt="" />保存</asp:LinkButton>
								<a class="linkbutton_skin" href="javascript:;" onclick="$.DialogClose();">
									<img src="../images/common/delete.gif" alt="" />关闭</a>
							</td>
						</tr>
					</table>
				</td>
				<td id="page_Bottom_Right">
					&nbsp;
				</td>
			</tr>
		</table>
	</div>
	</form>
</body>
</html>
