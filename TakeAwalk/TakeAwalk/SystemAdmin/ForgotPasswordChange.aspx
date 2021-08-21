<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="ForgotPasswordChange.aspx.cs" Inherits="TakeAwalk.SystemAdmin.ForgotPasswordChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="font-size: 40px">忘記密碼</div>
    <br />
    <table>
        <tr>
            <td>帳號:
               <asp:Literal ID="ltlAct" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>新密碼:
                <asp:TextBox ID="pwdbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>確認新密碼:
                <asp:TextBox ID="npwdbox" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
    <br />
    <div>
        <span>
            <asp:Button ID="Savebtn" runat="server" Text="確定變更" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Againbtn" runat="server" Text="取消變更" />
        </span>
    </div>
</asp:Content>
