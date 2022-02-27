<%@ Page Title="总观" Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="totalvisual.aspx.cs" Inherits="mesvisual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 425px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td>汇总</td>
        </tr>
        <tr>
            <td>
                <table class="auto-style2">
                    <tr>
                        <td colspan="2">各药材的收藏详情(选择可查看药材的具体评分情况)</td>
                    </tr>
                    <tr>
                        <td aria-checked="undefined" colspan="2">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" CellPadding="4" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="5" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#284775" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td aria-checked="undefined" colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td aria-checked="undefined" class="auto-style3">
                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">所有药材评分的平均数</asp:LinkButton>
                        </td>
                        <td aria-checked="undefined">
                            <asp:Label ID="Label1" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

