<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Manager_OrderList.aspx.cs" Inherits="TakeAwalk.SystemAdmin.OrderCancle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gv_orderlist" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="OrderID" HeaderText="訂單序號" />
            <asp:BoundField DataField="CreateDate" HeaderText="購買日期" />
            <asp:BoundField DataField="Name" HeaderText="姓名" />
            <asp:BoundField DataField="Total" HeaderText="總金額" />
            <asp:TemplateField><ItemTemplate><label>元</label></ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="Quantity" HeaderText="總張數" />
            <asp:TemplateField><ItemTemplate><label>張</label></ItemTemplate></asp:TemplateField>
            <asp:BoundField DataField="OrderStatus" HeaderText="訂單狀態" />
            <asp:BoundField HeaderText="修改訂單日期" DataField="ModifyDate" />
            <asp:TemplateField>
                <ItemTemplate>
                    <a href="OrderDetail.aspx?ID=<%# Eval("OrderID")%>">
                        <img src="/Images/icons-search.png" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
