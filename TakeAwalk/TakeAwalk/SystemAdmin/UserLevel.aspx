<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UserLevel.aspx.cs" Inherits="TakeAwalk.SystemAdmin.UserLevel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    目前使用者<asp:Literal ID="ltl_Name" runat="server"></asp:Literal><br />
            使用者權限<asp:DropDownList runat="server" id="UserLv_ddl">
        <asp:ListItem Value="0">管理者</asp:ListItem>
        <asp:ListItem Value="1">一般使用者</asp:ListItem>
        <asp:ListItem Value="2">黑名單</asp:ListItem>
    </asp:DropDownList><br />
    <asp:Button runat="server" Text="保存" id="Save_btn" OnClick="Save_btn_Click" />
</asp:Content>
