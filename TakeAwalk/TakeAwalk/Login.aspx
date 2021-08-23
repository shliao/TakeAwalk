<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TakeAwalk.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="font-size: 40px">會員登入</div>
    <br />
    <table>
        <tr>
            <td>帳號:
                <asp:TextBox ID="txbAccount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>密碼:
                <asp:TextBox ID="txbPassword" runat="server"></asp:TextBox><br />
                <div style="margin-left: 150px">
                    <a href="ForgotPassword.aspx">忘記密碼?</a>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    <br />
    <div>
        <span>
            <asp:Button ID="btnLogin" runat="server" Text="登入" OnClick="btnLogin_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click" />
        </span>
    </div>

</asp:Content>
