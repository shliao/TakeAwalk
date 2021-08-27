<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="TakeAwalk.SystemAdmin.OrderList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gv_orderlist" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="訂單序號" />
            <asp:BoundField DataField="CreateDate" HeaderText="購買日期" />
            <asp:BoundField HeaderText="總金額" DataField="Total" />
            <asp:TemplateField>
                <ItemTemplate>
                    <label>元</label></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="總張數" DataField="Quantity" />
            <asp:TemplateField>
                <ItemTemplate>
                    <label>張</label></ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="OrderStatus" HeaderText="訂單狀態" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="OrderDetail.aspx?ID=<%# Eval("OrderID")%>">
                        <img src="/Images/icons-search.png" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Content>
