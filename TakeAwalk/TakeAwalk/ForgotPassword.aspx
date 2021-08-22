<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="TakeAwalk.ForgotPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: 40px">忘記密碼</div>
    <br />
    <table>
        <tr>
            <td>
                帳號:
                <asp:TextBox ID="txbAccount" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                信箱:
                <asp:TextBox ID="txbEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div>
        <span>
            <asp:Button ID="btnSave" runat="server" Text="送出" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancle" runat="server" Text="取消" OnClick="btnCancle_Click" />
        </span>
    </div>
</asp:Content>
