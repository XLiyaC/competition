<%@ Page Title="用户登录界面" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="generaluser.aspx.cs" Inherits="generaluser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            height: 28px;
        }
        .auto-style10 {
            height: 33px;
        }
        .auto-style12 {
        }
        .auto-style13 {
        }
        .auto-style15 {
        }
        .auto-style16 {
        }
        .auto-style17 {
            width: 205px;
            height: 33px;
        }
        .auto-style18 {
            height: 39px;
        }
        .auto-style19 {
            height: 52px;
        }
        .auto-style20 {
            width: 37px;
            height: 34px;
            float: right;
        }
        .auto-style21 {
            text-align: right;
        }
        .auto-style22 {
        border: 1px solid #4A95BD;
        padding: 1px 4px;
    }
        .auto-style23 {
        height: 28px;
        width: 149px;
        background-color: #C0DCF1;
    }
    .auto-style24 {
        background-color: #C0DCF1;
    }
        .auto-style26 {
        text-align: left;
    }
        .auto-style27 {
            width: 100%;
        }
        .auto-style28 {
            height: 28px;
            width: 149px;
            background-color: #C0DCF1;
        }
        .auto-style29 {
        background-color: #C0DCF1;
        height: 76px;
    }
        body {
        background-color: #C0DCF1;
    }
        </style>
<link href="css/style.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tbody class="auto-style22">
        <tr>
            <td class="auto-style26">
                <a href='https://p4psearch.1688.com/p4p114/p4psearch/offer2.htm?keywords=%D6%D0%D2%A9%B2%C4%C5%FA%B7%A2%CA%D0%B3%A1&cosite=360jj&location=landing_t4&trackid=88568813401075577236590&keywordid=23085719387&format=normal' target='_blank'>
                
                </a>
                <asp:Label ID="Label28" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                站外中药材批发资源<a href='https://p4psearch.1688.com/p4p114/p4psearch/offer2.htm?keywords=%D6%D0%D2%A9%B2%C4%C5%FA%B7%A2%CA%D0%B3%A1&cosite=360jj&location=landing_t4&trackid=88568813401075577236590&keywordid=23085719387&format=normal' target='_blank'><img src='tu/图标1.jpg' class="auto-style20" /></a></td>
        </tr>
        <tr>
            <td>
                关键词&nbsp; 
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="搜索" OnClick="Button1_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style28">
                <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AutoGenerateSelectButton="True" PageSize="3" CellPadding="4" OnPageIndexChanging="GridView3_PageIndexChanging" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" ForeColor="#333333" GridLines="None">
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
            <td class="auto-style3">
                <asp:Panel ID="Panel4" runat="server">
                    <table class="auto-style27">
                        <tr>
                            <td colspan="2" class="auto-style24">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>产地</td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server" Width="875px" TextMode="MultiLine" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>功效</td>
                            <td>
                                <asp:TextBox ID="TextBox5" runat="server" Width="876px" TextMode="MultiLine" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>相关药籍</td>
                            <td>
                                <asp:TextBox ID="TextBox6" runat="server" Width="875px" TextMode="MultiLine" Height="83px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style19">图片</td>
                            <td class="auto-style19">
                                <asp:Image ID="Image2" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style18" colspan="2">
                                <asp:Button ID="Button21" runat="server" OnClick="Button21_Click" style="height: 32px" Text="留言详情" />
                                &nbsp; &lt;-点击后显示留言详情&nbsp;
                                <br />
                                <asp:Label ID="Label16" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="auto-style28"></td>
                        </tr>
                        <tr>
                            <td colspan="2" class="auto-style29">
                                <asp:Button ID="Button23" runat="server" OnClick="Button23_Click" Text="收藏评分情况" />
                                &nbsp; &lt;-点击后显示收藏评分情况&nbsp;
                                <br />
                                <asp:Label ID="Label17" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Panel ID="Panel5" runat="server">
                    <table class="auto-style27">
                        <tr>
                            <td class="auto-style24" colspan="2">
                                <asp:Label ID="Label18" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style24">留言</td>
                            <td class="auto-style24">
                                <asp:TextBox ID="TextBox7" runat="server" Width="1010px" TextMode="MultiLine" Height="133px" CssClass="using_text"></asp:TextBox>
                                <br />
                                200字以内<br /> 
                                <asp:Label ID="Label7" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style24">&nbsp;</td>
                            <td class="auto-style24">
                                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="添加" />
                                &nbsp;
                                <asp:Button ID="Button33" runat="server" OnClick="Button33_Click" Text="修改" />
                                &nbsp;
                                <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="取消" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style24">回复</td>
                            <td class="auto-style24">
                                <asp:TextBox ID="TextBox8" runat="server" Width="1010px" TextMode="MultiLine" Height="55px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style24">&nbsp;</td>
                            <td class="auto-style24">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server">
                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style24" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style24">收藏</td>
                            <td class="auto-style24">
                                <asp:Label ID="Label32" runat="server"></asp:Label>
                                <br />
                                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="确定收藏" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="取消收藏" />
                                <br />
                                <asp:Label ID="Label4" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style24">
                                <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click">该药材的被收藏数</asp:LinkButton>
                            </td>
                            <td class="auto-style24">
                                <asp:Label ID="Label29" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style24">
                                &nbsp;</td>
                            <td class="auto-style24">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style24">&nbsp;评分</td>
                            <td class="auto-style24">
                                <asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
                                &nbsp;&nbsp; 0到10分(输入整数，默认为6)&nbsp;
                                <br />
                                <asp:Button ID="Button17" runat="server" OnClick="Button14_Click" Text="评分" />
                                &nbsp;<asp:Button ID="Button25" runat="server" OnClick="Button25_Click" Text="更改" />
                                &nbsp;
                                <asp:Label ID="Label13" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style24">&nbsp;</td>
                            <td class="auto-style24">
                                <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click">该药材的评分总观</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>中药材推荐</td>
        </tr>
        <tr>
            <td>
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
            <td>
                <asp:Panel ID="Panel6" runat="server">
                    <table class="auto-style2">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td>产地</td>
                            <td>
                                <asp:TextBox ID="TextBox10" runat="server" Width="861px" TextMode="MultiLine" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>功效</td>
                            <td>
                                <asp:TextBox ID="TextBox11" runat="server" Width="861px" TextMode="MultiLine" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>相关药籍</td>
                            <td>
                                <asp:TextBox ID="TextBox12" runat="server" Width="858px" TextMode="MultiLine" Height="80px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>图片</td>
                            <td>
                                <asp:Image ID="Image3" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button20" runat="server" OnClick="Button20_Click" Text="留言详情" />
                            </td>
                            <td>&nbsp;&lt;-点击后显示留言详情&nbsp;<asp:Label ID="Label20" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button26" runat="server" OnClick="Button26_Click" Text="收藏评分详情" />
                            </td>
                            <td>&nbsp;&lt;-点击后显示留言详情 &nbsp;<asp:Label ID="Label21" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel7" runat="server">
                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style12" colspan="2">
                                <asp:Label ID="Label22" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">留言</td>
                            <td>
                                <asp:TextBox ID="TextBox13" runat="server" Width="1004px" TextMode="MultiLine" Height="132px" CssClass="using_text"></asp:TextBox>
                                <br />
                                200字以内<br /> 
                                <asp:Label ID="Label8" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">&nbsp;</td>
                            <td>
                                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="添加" />
                                &nbsp;
                                <asp:Button ID="Button32" runat="server" OnClick="Button32_Click" Text="修改" />
                                &nbsp;
                                <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="取消" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">回复</td>
                            <td>
                                <asp:TextBox ID="TextBox14" runat="server" Width="1008px" TextMode="MultiLine" Height="58px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style12">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel2" runat="server">
                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style15" colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">收藏</td>
                            <td>
                                <asp:Label ID="Label33" runat="server"></asp:Label>
                                <br />
                                <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="确定收藏" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="取消收藏" />
                                <br />
                                <asp:Label ID="Label5" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15">
                                <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton11_Click">该药材的被收藏数</asp:LinkButton>
                            </td>
                            <td>
                                <asp:Label ID="Label30" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15">
                                &nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style15">评分</td>
                            <td>
                                <asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
                                &nbsp;0到10分(输入整数，默认为6分)&nbsp;&nbsp;
                                <br />
                                <asp:Button ID="Button18" runat="server" OnClick="Button18_Click" Text="评分" />
                                &nbsp;<asp:Button ID="Button28" runat="server" OnClick="Button28_Click" Text="更改" />
                                &nbsp;<asp:Label ID="Label14" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td>
                                <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton12_Click">该药材的评分总观</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>已收藏中药材</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView2" runat="server" AllowPaging="True" PageSize="3" AutoGenerateSelectButton="True" CellPadding="4" OnPageIndexChanging="GridView2_PageIndexChanging" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" ForeColor="#333333" GridLines="None">
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
            <td>
                <asp:Panel ID="Panel8" runat="server">
                    <table class="auto-style2">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                &nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td>产地</td>
                            <td>
                                <asp:TextBox ID="TextBox16" runat="server" Width="868px" TextMode="MultiLine" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>功效</td>
                            <td>
                                <asp:TextBox ID="TextBox17" runat="server" Width="867px" TextMode="MultiLine" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>相关药籍</td>
                            <td>
                                <asp:TextBox ID="TextBox18" runat="server" Width="865px" TextMode="MultiLine" Height="80px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style23">图片</td>
                            <td class="auto-style23">
                                <asp:Image ID="Image4" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button22" runat="server" OnClick="Button22_Click" Text="留言详情" />
                            </td>
                            <td>&nbsp;&lt;-点击后显示留言详情 &nbsp;<asp:Label ID="Label24" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button29" runat="server" OnClick="Button29_Click" Text="收藏评分详情" />
                            </td>
                            <td>&nbsp;&lt;-点击后显示收藏评分详情 
                                <asp:Label ID="Label27" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel9" runat="server">
                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style13" colspan="2">
                                <asp:Label ID="Label25" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">留言</td>
                            <td>
                                <asp:TextBox ID="TextBox19" runat="server" Width="1002px" TextMode="MultiLine" Height="129px" CssClass="using_text"></asp:TextBox>
                                <br />
                                200字以内<br /> 
                                <asp:Label ID="Label9" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">&nbsp;</td>
                            <td>
                                <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="添加" />
                                &nbsp;
                                <asp:Button ID="Button30" runat="server" OnClick="Button30_Click" Text="修改" />
                                &nbsp;
                                <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="取消" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">回复</td>
                            <td>
                                <asp:TextBox ID="TextBox20" runat="server" Width="1008px" TextMode="MultiLine" Height="52px" CssClass="using_text"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style13">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table class="auto-style2">
                    <tr>
                        <td>
                            <asp:Panel ID="Panel3" runat="server">
                                <table class="auto-style2">
                                    <tr>
                                        <td class="auto-style16" colspan="2">
                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">收藏</td>
                                        <td>
                                            <asp:Label ID="Label34" runat="server"></asp:Label>
                                            <br />
                                            <asp:Button ID="Button12" runat="server" OnClick="Button12_Click" Text="确定收藏" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="Button13" runat="server" OnClick="Button13_Click" Text="取消收藏" />
                                            <br />
                                            <asp:Label ID="Label6" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style16">
                                            <asp:LinkButton ID="LinkButton13" runat="server" OnClick="LinkButton13_Click">该药材的被收藏数</asp:LinkButton>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label31" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style17">
                                            &nbsp;</td>
                                        <td class="auto-style10">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style17">评分</td>
                                        <td class="auto-style10">
                                            <asp:TextBox ID="TextBox24" runat="server" Width="158px"></asp:TextBox>
                                            &nbsp; 0到10分(输入整数，默认为6分)&nbsp;&nbsp;
                                            <br />
                                            <asp:Button ID="Button19" runat="server" OnClick="Button19_Click" Text="评分" />
                                            &nbsp;<asp:Button ID="Button31" runat="server" OnClick="Button31_Click" Text="更改" />
&nbsp;
                                            <asp:Label ID="Label15" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style17">&nbsp;</td>
                                        <td class="auto-style10">
                                            <asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkButton14_Click">该药材的评分总观</asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
&nbsp;</td>
        </tr>
    </table>
</asp:Content>

