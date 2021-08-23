<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="TakeAwalk.SystemAdmin.Tickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gv_ticket" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TicketContent" HeaderText="票券名稱" />
            <asp:BoundField DataField="TrainCompany" HeaderText="主辦單位"/>
            <asp:BoundField DataField="ActivityStartDate" HeaderText="開始日期"/>
            <asp:BoundField DataField="ActivityEndDate" HeaderText="結束日期"/>
            <asp:BoundField DataField="TicketPrice" HeaderText="票價"/>
            <asp:TemplateField HeaderText="數量 (上限3張)">
                <ItemTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="勾選">
                <ItemTemplate>
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnConfirm" runat="server" Text="確認選項" /><asp:Button ID="btnCancel" runat="server" Text="取消" />
</asp:Content>
