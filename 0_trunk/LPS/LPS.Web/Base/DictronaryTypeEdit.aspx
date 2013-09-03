<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DictronaryTypeEdit.aspx.cs"
	Inherits="LPS.Web.Base.BaseDictronaryTypeEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title><#ClassTitle>信息</title>
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
							<table class="tableOneline" border="0" cellpadding="0" cellspacing="1">
								<tr>
									<td class="tdRight">
										类型名称：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtDictTypeName" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										类型描述：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtDictTypeDesc" CssClass="textbox_skin" />
									</td>
								</tr>
							</table>
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
								<asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtSave_Click">
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
