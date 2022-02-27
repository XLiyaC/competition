<%@ Page Title="管理用户界面" Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="managinguser.aspx.cs" Inherits="managinguser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            height: 200px;
        }
        .auto-style4 {
            height: 28px;
        }
        .auto-style5 {
            height: 30px;
        }
        .auto-style6 {
            height: 33px;
        }
        .auto-style7 {
            height: 92px;
        }
        .auto-style8 {
            width: 34px;
            height: 32px;
            float: right;
        }
        .auto-style9 {
            height: 28px;
            text-align: right;
        }
        .auto-style10 {
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style4" colspan="4">
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style9">
                站外中药材批发资源<a href='https://p4psearch.1688.com/p4p114/p4psearch/offer2.htm?keywords=%D6%D0%D2%A9%B2%C4%C5%FA%B7%A2%CA%D0%B3%A1&cosite=360jj&location=landing_t4&trackid=88568813401075577236590&keywordid=23085719387&format=normal' target='_blank'><img src='tu/图标1.jpg' class="auto-style8" /><div class="auto-style10">
                </div>
                </a>
            &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="4">中药材汇总</td>
        </tr>
        <tr>
            <td class="auto-style3" colspan="4">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" PageSize="5" AutoGenerateSelectButton="True" CellPadding="4" OnPageIndexChanging="GridView1_PageIndexChanging" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" ForeColor="#333333" GridLines="None">
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
            <td class="auto-style5" colspan="4">
                <asp:Panel ID="Panel1" runat="server">
                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style6">药材号&nbsp;&nbsp;&nbsp;
                                <asp:Label ID="Label5" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>药材名&nbsp;&nbsp;&nbsp;
                                <br />
                                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="1397px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>产地<br /> 
                                <asp:TextBox ID="TextBox2" runat="server" Height="30px" TextMode="MultiLine" Width="1400px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">功效<br /> 
                                <asp:TextBox ID="TextBox3" runat="server" Height="30px" TextMode="MultiLine" Width="1400px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>相关药籍<br /> 
                                <asp:TextBox ID="TextBox4" runat="server" Height="30px" TextMode="MultiLine" Width="1400px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>图片信息&nbsp;
                                <asp:Image ID="Image2" runat="server" />
                                <br />
                                <asp:TextBox ID="TextBox7" runat="server" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加新项" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="修改" />
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="删除" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">
                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="确定" />
                                &nbsp;&nbsp;
                                <asp:Label ID="Label9" runat="server" Text="(药材编号自动生成)"></asp:Label>
                                <br />
                                <br />
                                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="取消" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4" colspan="4">用户交流信息</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" PageSize="5" AutoGenerateSelectButton="True" CellPadding="4" OnPageIndexChanging="GridView2_PageIndexChanging" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" ForeColor="#333333" GridLines="None">
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
            <td class="auto-style4" colspan="4">
                <asp:Panel ID="Panel2" runat="server">
                    <table class="auto-style2">
                        <tr>
                            <td>普通用户id
                                <asp:Label ID="Label6" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>药材编号&nbsp;
                                <asp:Label ID="Label7" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>留言详情<br /> 
                                <br />
                                <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" Width="1400px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>留言时间&nbsp;
                                <asp:Label ID="Label8" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                回复<br /> 
                                <asp:TextBox ID="TextBox6" runat="server" TextMode="MultiLine" Width="1398px" CssClass="using_text"></asp:TextBox>
                                <br />
                                管理用户id&nbsp;&nbsp;
                                <asp:Label ID="Label4" runat="server"></asp:Label>
                                &nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="回复" />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">所有药材的收藏评分总观</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

