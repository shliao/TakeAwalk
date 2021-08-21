<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TakeAwalk.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display: inline; font-size:40px">購票首頁</div>
    <div style="display: inline;">
        <span style="margin-left: 30px">
            <asp:Button ID="Lgnbtn" runat="server" Text="會員登入" />
            <asp:Button ID="Rgrbtn" runat="server" Text="註冊會員" />
        </span>
    </div>
    <br />
    <br />
    <table>
        <tr>
            <td>熱門優惠票
                <asp:GridView ID="GvTicket" runat="server"></asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
