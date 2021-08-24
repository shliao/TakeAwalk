<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CustomerPasswordChange.aspx.cs" Inherits="TakeAwalk.SystemAdmin.CustomerPasswordChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="font-size: 40px">變更密碼</div>
    <br />
    <table>
        <tr>
            <td>帳號:
               <asp:Literal ID="ltlAccount" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>原密碼:
                <asp:TextBox ID="txbPassword" runat="server" TextMode="Password" MaxLength="16"></asp:TextBox>
                <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>新密碼:
                <asp:TextBox ID="txbNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:Literal ID="ltlMsg2" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>確認新密碼:
                <asp:TextBox ID="txbNewPasswordCmf" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <asp:Literal ID="ltlCheckInput" runat="server"></asp:Literal>
    <div>
        <span>
            <asp:Button ID="btnSave" runat="server" Text="確定變更" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnCancle" runat="server" Text="取消變更" OnClick="btnCancle_Click" />
        </span>
    </div>
</asp:Content>
