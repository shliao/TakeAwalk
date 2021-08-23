<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="TicketComfirm.aspx.cs" Inherits="TakeAwalk.SystemAdmin.TicketComfirm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gv_ticket" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TicketContent" HeaderText="票券名稱" />
            <asp:BoundField DataField="TrainCompany" HeaderText="主辦單位"/>
            <asp:BoundField DataField="TicketPrice" HeaderText="票價"/>
            <asp:TemplateField HeaderText="購買數量">
                <ItemTemplate>
                    <asp:Literal ID="ltlQuantity" runat="server"></asp:Literal>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Literal ID="ltlTotalPrice" runat="server"></asp:Literal></br>
    <asp:Button ID="btnConfirm" runat="server" Text="確認購買" /><asp:Button ID="btnCancel" runat="server" Text="取消" />
</asp:Content>
