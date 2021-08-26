<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TakeAwalk.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="display: inline; font-size: 40px">火車訂票系統</div>
    <div style="display: inline;">
        <span style="margin-left: 30px">
            <a href="Login.aspx">會員登入</a>
            <a href="Register.aspx">註冊會員</a>
        </span>
    </div>
    <br />
    <br />
    <table>
        <tr>
            <td>
                熱門優惠票
                <asp:GridView ID="gdvTicket" runat="server" AutoGenerateColumns="False" Height="78px" Width="233px">
                    <Columns>
                        <asp:BoundField HeaderText="票券名稱" DataField="TicketName" />
                        <asp:BoundField HeaderText="主辦單位" DataField="TrainCompany" />
                        <asp:BoundField HeaderText="票價" DataField="Price" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
