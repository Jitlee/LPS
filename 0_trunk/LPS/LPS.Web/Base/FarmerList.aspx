<%@ Page Title="" Language="C#" MasterPageFile="~/Main/SiteMain.Master" AutoEventWireup="true" CodeBehind="FarmerList.aspx.cs" Inherits="LPS.Web.Base.BaseFarmerList" %>
<%@ Register Src="../UI/pagenavigate.ascx" TagName="pagenavigate" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(document).ready(function () {
            $(".headerBtnAdd").click(function () {
                var strVar = 'BaseFarmerEdit.aspx';
                $.popup({ title: "添加", url: strVar, borderStyle: { height: 600, width: 500 }, ok: function (obj) {

                    $.popup.Refrsh();
                }
                }); //$.popup

            });

            var editArr = $(".gvEdit");
            editArr.each(function (i, o) {
                var obj = $(o);
                obj.click(function () {
                    var m_url = 'BaseFarmerEdit.aspx?opType=alert&id=' + obj.attr("Guid");
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
    <asp:GridView ID="gvBaseFarmer" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:TemplateField HeaderText="序号">
                <ItemStyle BackColor="#bdeaff" Width="25" />
                <ItemTemplate>
                        <%# Container.DataItemIndex+1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="编辑" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <a  guid="<%# Eval("FarmerId") %>" class="gvEdit"><img src="../images/Common/edit.gif" style="border: 0px;" alt="编辑" /></a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="删除" HeaderStyle-Width="4%">
                <ItemTemplate>
                    <asp:ImageButton ID="ibtn_delete" CssClass="deleteTS" CommandName="delete" OnCommand="GView_LinkButton_Click" CommandArgument='<%#Eval("FarmerId") %>' ImageUrl="~/images/Common/delete.gif" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            
			<asp:BoundField DataField="FarmarCode" HeaderText="烟农编码"  />
			<asp:BoundField DataField="FarmerRfid" HeaderText="烟农RFID标识"  />
			<asp:BoundField DataField="FarmerName" HeaderText="烟农名称"  />
			<asp:BoundField DataField="FarmerPy" HeaderText="烟农拼音缩写"  />
			<asp:BoundField DataField="FarmerPhone" HeaderText="烟农电话"  />
			<asp:BoundField DataField="FarmerEmail" HeaderText="烟农电子邮箱"  />
			<asp:BoundField DataField="FarmerAddress" HeaderText="烟农地址"  />
			<asp:BoundField DataField="FarmerRmark" HeaderText="备注"  />
			<asp:BoundField DataField="FarmerSex" HeaderText="性别"  />
			<asp:BoundField DataField="FarmerBirth" HeaderText="出生日期"  />
			<asp:BoundField DataField="FarmerCardId" HeaderText="身份证"  />
			
			<asp:BoundField DataField="FarmerIsDeleted" HeaderText="是否删除"  />
			
        </Columns>
        <EmptyDataTemplate>
            <table class="empty_gridview" cellspacing="0">
                <tr>
                                                    <th>烟农编码</th>                                <th>烟农RFID标识</th>                                <th>烟农名称</th>                                <th>烟农拼音缩写</th>                                <th>烟农电话</th>                                <th>烟农电子邮箱</th>                                <th>烟农地址</th>                                <th>备注</th>                                <th>性别</th>                                <th>出生日期</th>                                <th>身份证</th>                                <th>创建日期</th>                                <th>是否删除</th>                                <th>删除日期</th>
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
    <uc2:pagenavigate ID="pg" runat="server" />
    </div>
</asp:Content>

