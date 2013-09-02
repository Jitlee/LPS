<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="EmpolyeeList.aspx.cs" Inherits="LPS.Web.Base.BaseEmpolyeeList" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $(".headerBtnAdd").click(function () {
                var strVar = 'BaseEmpolyeeEdit.aspx';
                $.popup({ title: "添加", url: strVar, borderStyle: { height: 600, width: 500 }, ok: function (obj) {

                    $.popup.Refrsh();
                }
                }); //$.popup

            });

            var editArr = $(".gvEdit");
            editArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    var m_url = 'BaseEmpolyeeEdit.aspx?opType=alert&id=' + obj.attr("Guid");
                    $.popup({ title: "修改", url: m_url, borderStyle: { height: 600, width: 500 }, ok: function () {
                        $.popup.Refrsh();
                    }
                    }); //$.popup
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

    <table class="gridheader_table" cellpadding="0" cellspacing="0">
        <tr>
        <td width="6"><img src="../images/gridview/gridheader_03.gif" alt="" /></td>
        <td>列表</td>
        <td width="60"><a class="headerBtnAdd" id="aBtnAdd" runat="server"><img src="../images/Common/add_btn.gif" /></a></td>
        <td width="6"><img src="../images/gridview/gridheader_06.gif" alt="" /></td>
        </tr>
    </table>
    <div class="divgrid">
    
    <div class="overflow_grid">
    <asp:GridView ID="gvBaseEmpolyee" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemStyle BackColor="#bdeaff" Width="25" />
                <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <a  guid="<%# Eval("EmpolyeeId") %>" class="gvEdit"><img src="../images/Common/edit.gif" style="border: 0px;" alt="编辑" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click" CommandArgument='<%#Eval("EmpolyeeId") %>' ImageUrl="~/images/Common/delete.gif" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
			<asp:BoundField DataField="EMPOLYEE_CODE" HeaderText="员工编号"  />
			<asp:BoundField DataField="EMPOLYEE_RFID" HeaderText="员工RFID"  />
			<asp:BoundField DataField="EMPOLYEE_NAME" HeaderText="员工名称"  />
			<asp:BoundField DataField="EMPOLYEE_PY" HeaderText="员工拼音缩写"  />
			<asp:BoundField DataField="EMPOLYEE_SEX" HeaderText="员工性别"  />
			<asp:BoundField DataField="EMPOLYEE_BIRTH" HeaderText="员工出生日期"  />
			<asp:BoundField DataField="EMPOLYEE_ENTRY_DATE" HeaderText="员工入职日期"  />
			<asp:BoundField DataField="EMPOLYEE_PHONE" HeaderText="员工手机号"  />
			<asp:BoundField DataField="EMPOLYEE_EMAIL" HeaderText="员工电子邮箱"  />
			<asp:BoundField DataField="EMPOLYEE_ADDRESS" HeaderText="员工联系地址"  />
			<asp:BoundField DataField="EMPOLYEE_HOMETOWN" HeaderText="员工籍贯"  />
			<asp:BoundField DataField="EMPOLYEE_CARD_ID" HeaderText="员工身份证号"  />
			<asp:BoundField DataField="USER_ID" HeaderText="用户ID"  />
			<asp:BoundField DataField="USER_PWD" HeaderText="用户密码"  />
			<asp:BoundField DataField="EMPOLYEE_CREATE_DATE" HeaderText="员工创建日期"  />
			<asp:BoundField DataField="EMPOLYEE_IS_DELETED" HeaderText="N 表示已删除 "  />
			<asp:BoundField DataField="EMPOLYEE_DELETED_DATE" HeaderText="员工删除日期"  />
        </Columns>
        <EmptyDataTemplate>
            <table class="empty_gridview" cellspacing="0">
                <tr>
                                                    <th>员工编号</th>                                <th>员工RFID</th>                                <th>员工名称</th>                                <th>员工拼音缩写</th>                                <th>员工性别</th>                                <th>员工出生日期</th>                                <th>员工入职日期</th>                                <th>员工手机号</th>                                <th>员工电子邮箱</th>                                <th>员工联系地址</th>                                <th>员工籍贯</th>                                <th>员工身份证号</th>                                <th>用户ID</th>                                <th>用户密码</th>                                <th>员工创建日期</th>                                <th>N 表示已删除 </th>                                <th>员工删除日期</th>
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
    <uc2:pagenavigate ID="pg" runat="server" />
    </div>
</asp:Content>

