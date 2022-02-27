<%@ Page Title="中药材管理登陆界面" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
    .auto-style5 {
            width: 444px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style5">用户号</td>
            <td>
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">用户名</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">密码</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:Button ID="Button1" runat="server" Text="管理用户登录" OnClick="Button1_Click" />
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
            <td>
                <asp:Button ID="Button2" runat="server" Text="普通用户登录" OnClick="Button2_Click" />
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">注册新用户</asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">清空</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
    </table>
</asp:Content>

