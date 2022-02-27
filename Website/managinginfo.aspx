<%@ Page Title="管理用户基本信息" Language="C#" MasterPageFile="~/MasterPage3.master" AutoEventWireup="true" CodeFile="managinginfo.aspx.cs" Inherits="managinginfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            height: 30px;
        }
        .auto-style4 {
            width: 191px;
        }
        .auto-style5 {
            height: 30px;
            width: 191px;
        }
        .auto-style6 {
            width: 274px;
        }
        .auto-style7 {
            height: 30px;
            width: 243px;
        }
        .auto-style8 {
            width: 243px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="auto-style2">
        <tr>
            <td class="auto-style4">用户号</td>
            <td colspan="3">
                <asp:Label ID="Label4" runat="server"></asp:Label>
            </td>
            <td>
                不可修改</td>
        </tr>
        <tr>
            <td class="auto-style5">用户名</td>
            <td class="auto-style3">
                <asp:Label ID="Label6" runat="server"></asp:Label>
            </td>
            <td class="auto-style7" colspan="2">
                <asp:TextBox ID="TextBox10" runat="server" Width="150px"></asp:TextBox>
                &nbsp;<asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="修改" />
            </td>
            <td class="auto-style3">
                可修改
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">年龄</td>
            <td class="auto-style3">
                <asp:Label ID="Label7" runat="server"></asp:Label>
            </td>
            <td class="auto-style7" colspan="2">
                <asp:TextBox ID="TextBox11" runat="server" Width="150px"></asp:TextBox>
                &nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="修改" />
            </td>
            <td class="auto-style3">
                可修改 
                <asp:Label ID="Label9" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">密码</td>
            <td>
                <asp:Label ID="Label8" runat="server"></asp:Label>
            </td>
            <td class="auto-style8" colspan="2">
                <asp:TextBox ID="TextBox12" runat="server" Width="150px"></asp:TextBox>
                &nbsp;<asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="修改" />
            </td>
            <td>
                可修改 
                <asp:Label ID="Label10" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">修改时间</td>
            <td colspan="3">
                <asp:Label ID="Label5" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td colspan="2">
                <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="注销用户" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                注销成功后立即返回首页&nbsp;
                </td>
            <td colspan="2">
                <asp:Label ID="Label11" runat="server"></asp:Label>
                </td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td colspan="4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                新增用户号</td>
            <td class="auto-style6" colspan="3">
                <asp:Label ID="Label3" runat="server"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
            <td>
                (自动生成用户ID)</td>
        </tr>
        <tr>
            <td class="auto-style5">新增用户名</td>
            <td class="auto-style3" colspan="4">
                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">年龄</td>
            <td class="auto-style3" colspan="4">
                <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">用户密码</td>
            <td colspan="3">
                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            </td>
            <td>
                (默认密码为000000)</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td colspan="4">
                <asp:Button ID="Button2" runat="server" Text="添加新管理者" OnClick="Button2_Click" />
            &nbsp;
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">返回首页</asp:LinkButton>
            </td>
            <td colspan="4">
                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">转到管理界面</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td colspan="4">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

