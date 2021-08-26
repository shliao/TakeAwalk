<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="TakeAwalk.SystemAdmin.CustomerList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="CustomerID" HeaderText="客戶編號" />
            <asp:BoundField DataField="Name" HeaderText="姓名" />
            <asp:BoundField DataField="IdNumber" HeaderText="身分證字號" />
            <asp:BoundField DataField="MobilePhone" HeaderText="手機號碼" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Account" HeaderText="帳號" />
            <asp:BoundField DataField="Password" HeaderText="密碼" />
        </Columns>
    </asp:GridView>
</asp:Content>
