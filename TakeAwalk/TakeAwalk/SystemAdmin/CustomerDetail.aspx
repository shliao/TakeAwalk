<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CustomerDetail.aspx.cs" Inherits="TakeAwalk.SystemAdmin.CustomerDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>會員中心</h2>
    <table>
        <tr>
            <th>帳號:</th>
            <td>
                <asp:Literal ID="ltlAccount" runat="server"></asp:Literal></td>
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
                <asp:TextBox ID="txtMobilePhone" runat="server" TextMode="Phone" pattern="[0-9]{3}[0-9]{3}[0-9]{4}"></asp:TextBox></td>
        </tr>
        <tr>
            <th>Email:</th>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal><br />
    <asp:Button ID="btnEdit" runat="server" Text="確定修改" OnClick="btnEdit_Click" />
    <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" /></br>
    <asp:Button ID="btnPwd" runat="server" Text="變更密碼" OnClick="btnPwd_Click" />
</asp:Content>