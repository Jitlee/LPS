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
            $("#txtDictCode").yz({ title: "编码", type: "string", max: 20, canEmpty: false, isSave: true });
            $("#txtDictName").yz({ title: "名称", type: "string", max: 20, canEmpty: false, isSave: true });
        });
    </script>
    <style type="text/css">
        *{ padding:0px; margin:0px;}
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
                        <div id="pageBody" style="padding: 5px;">
                             <table class="tableOneline" border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td colspan="4" style=" text-align:left; font-size:12px; padding-left:5px;">
                                            添加子类：
                                    </td>
                                </tr>
                                 <tr>
									<td class="tdRight">
										编码：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtDictCode" CssClass="textbox_skin" />
									</td>
									<td class="tdRight">
										名称：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtDictName" CssClass="textbox_skin" />
									</td>
								</tr>
                                <tr>
									<td class="tdRight">
										描述：
									</td>
									<td class="tdLeft">
										<asp:TextBox runat="server" ID="txtDictDesc" CssClass="textbox_skin" />
									</td>
                                    <td  colspan="2" class="tdLeft">
                                        <asp:Button ID="btnAddSub" runat="server" Text="添加" CssClass="btn_bg vertical_middle"
                                            OnClientClick="return $.yz.getErrorList()" OnClick="btnAddSub_Click" />
                                    </td>
                                </tr>
                             </table>

                             <table class="tableOneline" border="0" cellpadding="0" cellspacing="1">
                                <tr>
                                    <td style=" text-align:left; font-size:12px; padding-left:5px;">
                                         数据字典类型：
                                         <span   style="font-weight:bold;">
                                            <asp:Label ID="lblmain" runat="server"></asp:Label>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td  align="right">
                                            <asp:GridView ID="gridSubName" runat="server" AutoGenerateColumns="false" CssClass="data_dictionary_gridview"
                                                   GridLines="None" DataKeyNames="DictCode" OnRowCancelingEdit="gridSubName_RowCancelingEdit"
                                                OnRowDeleting="gridSubName_RowDeleting" OnRowEditing="gridSubName_RowEditing"
                                                OnRowUpdating="gridSubName_RowUpdating">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="编码">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDictCode" Width="90px"  runat="server" Text='<%#Bind("DictCode")%>' CssClass="textbox_skin"></asp:TextBox>
                                                            <asp:TextBox ID="txtOldSubName" runat="server" Text='<%#Bind("DictCode")%>'  CssClass="NoShow"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1"   runat="server" Text='<%#Eval("DictCode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="名称">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDictName" Width="90px"  runat="server" Text='<%#Bind("DictName")%>' CssClass="textbox_skin"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label2"  runat="server" Text='<%#Eval("DictName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="描述">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtDictDesc" Width="90px" runat="server" Text='<%#Bind("DictDesc")%>' CssClass="textbox_skin"></asp:TextBox>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label3"  runat="server" Text='<%#Eval("DictDesc")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="操作">
                                                        <ItemStyle Width="80" />
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
                                                    <asp:TemplateField  HeaderText="删除">
                                                        <ItemStyle Width="60" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" ImageUrl="~/images/Common/delete.gif"
                                                                ToolTip="删除" AlternateText="删除" OnClientClick="return confirm('您确定要删除该子类吗?');" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EmptyDataTemplate>
                                                    <table class="gridview_skin" cellspacing="0" cellpadding="0" rules="all" border="1"
                                                        style="border-collapse: collapse; width:100%;">
                                                        <tr class="gridview_skin_header">
                                                            <th>编码</th>
                                                            <th>名称</th>
                                                            <th>描述</th>
                                                        </tr>
                                                    </table>
                                                </EmptyDataTemplate>
                                            </asp:GridView>
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
                                &nbsp;
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
