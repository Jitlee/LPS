<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FarmerEdit.aspx.cs" Inherits="LPS.Web.Base.BaseFarmerEdit" %>

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
	<script type="text/javascript" src="../Scripts/My97DatePicker/WdatePicker.js"></script>
	<script type="text/javascript">
		$(document).ready(function () {
			$("#txtFarmarCode").yz({ title: "编码", type: "string", max: 20, isSave: true });
			$("#txtFarmerRfid").yz({ title: "RFID标识", type: "string", max: 20, isSave: true });
			$("#txtFarmerName").yz({ title: "姓名", type: "string", max: 20, isSave: true });
			$("#txtFarmerPy").yz({ title: "拼音缩写", type: "string", max: 20, isSave: true });
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
										编码：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtFarmarCode" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										RFID标识：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtFarmerRfid" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										姓名：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtFarmerName" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										拼音缩写：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtFarmerPy" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										性别：
									</td>
									<td class="tdLeft">
										<asp:DropDownList ID="dpdFarmerSex" runat="server">
                                            <asp:ListItem Text="男"></asp:ListItem>
                                            <asp:ListItem Text="女"></asp:ListItem>
                                        </asp:DropDownList>
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										出生日期：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtFarmerBirth" CssClass="textbox_skin"  onfocus="WdatePicker();" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										身份证：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtFarmerCardId" CssClass="textbox_skin" />
									</td>
								</tr>
								
								<tr>
									<td class="tdRight">
										电话：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtFarmerPhone" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										电子邮箱：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtFarmerEmail" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										地址：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtFarmerAddress" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										备注：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtFarmerRmark" CssClass="textbox_skin" />
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
								<asp:LinkButton ID="LinkButton1" runat="server" OnClick="lbtSave_Click"
                                         OnClientClick="return $.yz.getErrorList()">
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
