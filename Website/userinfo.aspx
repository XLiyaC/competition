<%@ Page Title="用户基本信息" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="userinfo.aspx.cs" Inherits="userinfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            height: 33px;
        }
        .auto-style4 {
            width: 315px;
        }
        .auto-style5 {
            height: 33px;
            width: 211px;
        }
        .auto-style7 {
            height: 33px;
            width: 195px;
        }
        .auto-style10 {
            height: 30px;
        }
        .auto-style15 {
            width: 195px;
            height: 28px;
        }
        .auto-style16 {
            width: 315px;
            height: 28px;
        }
        .auto-style17 {
            height: 28px;
        }
        .auto-style18 {
            width: 246px;
            height: 30px;
        }
        .auto-style19 {
            height: 33px;
            width: 246px;
        }
        .auto-style20 {
            width: 246px;
        }
        .auto-style21 {
            width: 195px;
        }
        .auto-style22 {
            width: 195px;
            height: 30px;
        }
        .auto-style23 {
            height: 28px;
            width: 178px;
            background-color: #C0DCF1;
        }
        .auto-style24 {
            width: 178px;
            height: 30px;
        }
        .auto-style25 {
            width: 178px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style21">用户号</td>
            <td class="auto-style4" colspan="2">
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td>
                不可修改</td>
        </tr>
        <tr>
            <td class="auto-style22">用户名</td>
            <td class="auto-style24">
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </td>
            <td class="auto-style18">
                <asp:TextBox ID="TextBox1" runat="server" Width="132px"></asp:TextBox>
                &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="修改" />
            </td>
            <td class="auto-style10">
                可修改
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">密码</td>
            <td class="auto-style23">
                <asp:Label ID="Label6" runat="server"></asp:Label>
            </td>
            <td class="auto-style19">
                <asp:TextBox ID="TextBox2" runat="server" Width="132px"></asp:TextBox>
                &nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="修改" />
            </td>
            <td class="auto-style3">
                可修改 
                <asp:Label ID="Label8" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">年龄</td>
            <td class="auto-style25">
                <asp:Label ID="Label7" runat="server"></asp:Label>
            </td>
            <td class="auto-style20">
                <asp:TextBox ID="TextBox3" runat="server" Width="132px"></asp:TextBox>
            &nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="修改" />
            </td>
            <td>
                可修改 
                <asp:Label ID="Label9" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">修改时间</td>
            <td class="auto-style4" colspan="2">
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
            <td>
                不可修改</td>
        </tr>
        <tr>
            <td class="auto-style15">等级</td>
            <td class="auto-style16" colspan="2">
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
            <td class="auto-style17">
                不可修改</td>
        </tr>
        <tr>
            <td class="auto-style21">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style21">
                <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="注销用户" />
                <br />
                注销成功后立即返回首页</td>
            <td colspan="3">
                <asp:Label ID="Label10" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style21">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">返回用户界面</asp:LinkButton>
            </td>
            <td colspan="3">
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">返回首页</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

