<%@ Page Title="注册新用户" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 255px;
        }
        .auto-style4 {
            width: 254px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style3">用户号</td>
            <td class="auto-style4">
                <asp:Label ID="Label2" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            <td>
                (自动生成用户ID)</td>
        </tr>
        <tr>
            <td class="auto-style3">用户名</td>
            <td colspan="2">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">年龄</td>
            <td colspan="2">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">密码</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
            </td>
            <td>
                (默认密码为000000)</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" Text="注册" OnClick="Button1_Click" />
            &nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
            </td>
            <td colspan="2">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">返回首页</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

