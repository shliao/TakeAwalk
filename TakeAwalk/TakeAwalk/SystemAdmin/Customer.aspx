<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="TakeAwalk.SystemAdmin.Customer" %>

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
                <asp:Literal ID="ltName" runat="server"></asp:Literal></td>
        </tr>
         <tr>
            <th>身分證字號:</th>
            <td>
                <asp:Literal ID="ltID" runat="server"></asp:Literal></td>
        </tr>
         <tr>
            <th>電話:</th>
            <td>
                <asp:Literal ID="ltMobilePhone" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <th>Email:</th>
            <td>
                <asp:Literal ID="ltEmail" runat="server"></asp:Literal></td>
        </tr>
    </table>
</asp:Content>
