<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CustomerDetail.aspx.cs" Inherits="TakeAwalk.SystemAdmin.CustomerDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>會員中心</h2>
    <table>
        <tr>
            <th>帳號:</th>
            <td>
                <asp:Literal ID="ltAccount" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <th>姓名:</th>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <th>身分證字號:</th>
            <td>
                <asp:TextBox ID="txtID" runat="server"></asp:TextBox></td>
        </tr>
         <tr>
            <th>電話:</th>
            <td>
                <asp:TextBox ID="txtMobilePhone" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th>Email:</th>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button ID="btnEdit" runat="server" Text="確定修改" /><asp:Button ID="btnLogout" runat="server" Text="返回" /></br>
    <asp:Button ID="btnPwd" runat="server" Text="變更密碼" />
</asp:Content>
