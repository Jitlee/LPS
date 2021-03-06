﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpolyeeEdit.aspx.cs" Inherits="LPS.Web.Base.BaseEmpolyeeEdit" %>

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
		    $("#txtEmpolyeeCode").yz({ title: "登录名", type: "string", max: 20, isSave: true });
		    $("#txtUserId").yz({ title: "用户ID", type: "string", max: 20, isSave: true });
		    $("#txtUserPwd").yz({ title: "用户密码", type: "string", max: 20, isSave: true });
		    $("#txtEmpolyeeRfid").yz({ title: "RFID", type: "string", max: 20, isSave: true });
		    $("#txtEmpolyeeName").yz({ title: "姓名", type: "string", max: 20, isSave: true });
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
										登录名：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtEmpolyeeCode" CssClass="textbox_skin" />
									</td>
								</tr>
                                <tr>
									<td class="tdRight">
										用户ID：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtUserId" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										用户密码：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" TextMode="Password" ID="txtUserPwd" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										RFID：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtEmpolyeeRfid" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										姓名：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtEmpolyeeName" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										拼音缩写：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtEmpolyeePy" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										性别：
									</td>
									<td class="tdLeft">
										<asp:DropDownList ID="dpdEmpolyeeSex" runat="server">
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
										<asp:TextBox ID="txtEmpolyeeBirth" CssClass="textbox_skin" onfocus="WdatePicker();" runat="server" />
									</td>
								</tr>
                                <tr>
									<td class="tdRight">
										身份证号:
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtEmpolyeeCardId" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										籍贯：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtEmpolyeeHometown" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										入职日期：
									</td>
									<td class="tdLeft">
										<asp:TextBox ID="txtEmpolyeeEntryDate" CssClass="textbox_skin" onfocus="WdatePicker();"
											runat="server" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										手机号：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtEmpolyeePhone" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										电子邮箱：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtEmpolyeeEmail" CssClass="textbox_skin" />
									</td>
								</tr>
								<tr>
									<td class="tdRight">
										联系地址：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtEmpolyeeAddress" CssClass="textbox_skin" />
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
