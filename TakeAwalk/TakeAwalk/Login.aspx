<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TakeAwalk.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="font-size: 40px">會員登入頁</div>
    <br />
    <table>
        <tr>
            <td>帳號:
                <asp:TextBox ID="actbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>密碼:
                <asp:TextBox ID="pwdbox" runat="server"></asp:TextBox><br />
                <div style="margin-left: 150px"> <a href="/SystemAdmin/ForgotPassword.aspx">忘記密碼?</a></div>
               
            </td>
        </tr>
    </table>
    <div>
        <span>
            <asp:Button ID="Savebtn" runat="server" Text="送出" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Againbtn" runat="server" Text="重新輸入" />
        </span>
    </div>

</asp:Content>
