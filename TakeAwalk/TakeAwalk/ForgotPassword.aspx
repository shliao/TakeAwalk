<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TakeAwalk.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="font-size: 40px">忘記密碼</div>
    <br />
    <table>
        <tr>
            <td>帳號:
                <asp:TextBox ID="actbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>信箱:
                <asp:TextBox ID="emlbox" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div>
        <span>
            <asp:Button ID="Savebtn" runat="server" Text="送出" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Againbtn" runat="server" Text="重新輸入" />
        </span>
    </div>
</asp:Content>
