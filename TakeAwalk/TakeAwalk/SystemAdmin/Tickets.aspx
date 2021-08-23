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
        <asp:Button ID="btnConfirm" runat="server" Text="確認選項" OnClick="btnConfirm_Click" /><asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
    <asp:GridView ID="gv_selected" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gv_selected_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="票券名稱" HeaderText="票券名稱" />
            <asp:BoundField DataField="主辦單位" HeaderText="主辦單位" />
            <asp:BoundField DataField="票價" HeaderText="票價" />
            <asp:BoundField DataField="數量" HeaderText="數量" />
        </Columns>
    </asp:GridView></br>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal></br>
        <asp:Button ID="btnBuy" runat="server" Text="確定訂購" OnClick="btnConfirm_Click" /><asp:Button ID="Button2" runat="server" Text="取消" OnClick="btnCancel_Click" />
</asp:Content>
