<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="TakeAwalk.SystemAdmin.Tickets" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gv_ticket" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TicketContent" HeaderText="票券名稱" />
            <asp:BoundField DataField="TrainCompany" HeaderText="主辦單位"/>
            <asp:BoundField DataField="ActivityStartDate" HeaderText="開始日期" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="ActivityEndDate" HeaderText="結束日期" DataFormatString="{0:d}"/>
            <asp:BoundField DataField="TicketPrice" HeaderText="票價"/>
            <asp:TemplateField HeaderText="數量 (上限3張)">
                <ItemTemplate>
                    <asp:DropDownList ID="ddl_quantity" runat="server">
                        <asp:ListItem Value="1" Text="1"></asp:ListItem>
                        <asp:ListItem Value="2" Text="2"></asp:ListItem>
                        <asp:ListItem Value="3" Text="3"></asp:ListItem>
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="勾選">
                <ItemTemplate>
                    <asp:CheckBox ID="cbox" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gv_selected" runat="server" AutoGenerateColumns="False" Visible="False">
        <Columns>
            <asp:BoundField DataField="TicketContent_Confirm" HeaderText="票券名稱" />
            <asp:BoundField DataField="TrainCompany_Confirm" HeaderText="主辦單位" />
            <asp:BoundField DataField="TicketPrice_Confirm" HeaderText="票價" />
            <asp:TemplateField><ItemTemplate><label>元</label></ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="Quantity_Confirm" HeaderText="數量" />
            <asp:TemplateField><ItemTemplate><label>張</label></ItemTemplate></asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lbError" runat="server" Text="未勾選任何優惠票" Visible="False"></asp:Label>
    <asp:Label ID="lbAmount" runat="server" Visible="False"></asp:Label><br/>
    <asp:Button ID="btnConfirm" runat="server" Text="確認選項" OnClick="btnConfirm_Click" />
    <asp:Button ID="btnBuy" runat="server" Text="確定訂購" OnClick="btnBuy_Click" Visible="False" />
    <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
</asp:Content>
