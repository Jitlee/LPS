<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="pagenavigate.ascx.cs" Inherits="LPS.Web.UI.pagenavigate" %>
<script type="text/javascript">
<!--
    $(document).ready(function () {
        var pageIndex = Number($("#<%= lab_PageIndex.ClientID %>").text());
        var pageCount = Number($("#<%= lab_PageCount.ClientID %>").text());
        var img_first = $("#<%= img_first.ClientID %>").click(function () {
            if (pageIndex == 0) {
                $.alert("当前没有任何记录！");
                return false;
            } else if (pageIndex == 1) {
                $.alert("已经是第一页了！");
                return false;
            }
            return true;
        });
        $("#<%= img_prev.ClientID %>").click(function () {
            if (pageIndex == 0) {
                $.alert("当前没有任何记录！");
                return false;
            } else if (pageIndex == 1) {
                $.alert("已经是第一页了");
                return false;
            } else if (pageIndex < 0) {
                $.alert("页码出现负数，太不可思议了，返回第一页吧！");
                img_first.click();
                return false;
            }
            return true;
        });
        $("#<%= img_next.ClientID %>").click(function () {
            if (pageIndex == 0) {
                $.alert("当前没有任何记录！");
                return false;
            } if (pageIndex == pageCount) {
                $.alert("已经是最后一页了");
                return false;
            } else if (pageIndex > pageCount) {
                $.alert("页数超出范围，太不可思议了，返回最后一页吧！");
                img_last.click();
            }
            return true;
        });
        var img_last = $("#<%= img_last.ClientID %>").click(function () {
            if (pageIndex == 0) {
                $.alert("当前没有任何记录！");
                return false;
            } else if (pageIndex == pageCount) {
                $.alert("已经是最后一页了！");
                return false;
            }
            return true;
        });

        $("#<%= img_gopage.ClientID %>").click(function () {
            var txt_gopage = $("#<%= txt_gopage.ClientID %>");
            var gopage = Number(txt_gopage.val());
            if (isNaN(gopage)) {
                $.alert("请输入正确的页数！");
                return false;
            } else if (gopage < 1) {
                txt_gopage.val(1);
            } else if (gopage > pageCount) {
                txt_gopage.val(pageCount);
            }
            return true;
        });
    });
-->
</script>

<table width="100%" cellpadding="0" cellspacing="0" id="PN" runat="server">
    <tr>
        <td style="text-align: left; "><div style="float:left">
            共有<asp:Label ID="lab_RecordCount" runat="server" ForeColor="#557CF2">0</asp:Label>
            条记录，当前第<asp:Label ID="lab_PageIndex" runat="server" ForeColor="#557CF2" Text="0"></asp:Label>
            /<asp:Label ID="lab_PageCount" runat="server" ForeColor="#557CF2" Text="0"></asp:Label>
            页，每页</div>
            <div style="float:left;display: inline;border:solid 1px #CCCCCC">
            <div style=" overflow:hidden;">
            <asp:DropDownList ID="ddlPageSize" runat="server" BackColor="#ddf3ff" ForeColor="#557CF2" style="float: left;display:block;margin: -2px;margin-right:-20px;">
                <asp:ListItem>10</asp:ListItem>
                <asp:ListItem>15</asp:ListItem>
                <asp:ListItem Selected="True">20</asp:ListItem>
                <asp:ListItem>30</asp:ListItem>
                <asp:ListItem>50</asp:ListItem>                
            </asp:DropDownList>
            </div>
            </div>
            <div style="float:left">条</div>
        </td>
        <td style="text-align: right; ">
            <asp:ImageButton ID="img_first" runat="server" ImageUrl="~/images/pagenavigate/first.gif" CausesValidation="False"
                ToolTip="首页" Style="margin-left: 2px"></asp:ImageButton>
            <asp:ImageButton ID="img_prev" runat="server" ImageUrl="~/images/pagenavigate/prev.gif" CausesValidation="False" ToolTip="上一页"
                    Style="margin-left: 2px"></asp:ImageButton>
            <asp:ImageButton ID="img_next" runat="server" ImageUrl="~/images/pagenavigate/next.gif" CausesValidation="False" ToolTip="下一页" Style="margin-left: 2px">
            </asp:ImageButton>
            <asp:ImageButton ID="img_last" runat="server" ImageUrl="~/images/pagenavigate/last.gif" Style="margin-left: 2px" CausesValidation="False" ToolTip="尾页"></asp:ImageButton>
        </td>
        <td style="text-align: right; width:40px;">
            转到</td>
        <td style="width: 23px; text-align: center; vertical-align: middle; ">
            <asp:TextBox ID="txt_gopage" runat="server" Width="21px" Height="16px" BorderWidth="1" Font-Size="12px"
                ForeColor="#557CF2" BorderColor="#888888" Style="text-align: center" Text="1" CssClass="textbox_skin"></asp:TextBox>
        </td>
        <td style="width: 31px;">
            <asp:ImageButton ID="img_gopage" runat="server" ImageUrl="~/images/pagenavigate/go.gif" CausesValidation="False"
                Style="margin: 2px" ToolTip="转到"></asp:ImageButton></td>
    </tr>
</table>
