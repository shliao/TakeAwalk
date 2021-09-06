<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Manager_OrderList.aspx.cs" Inherits="TakeAwalk.SystemAdmin.OrderCancle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row gx-5 align-items-center justify-content-center" style="background-color: lightgray">
        <div class="col-lg-8 col-xl-7 col-xxl-6">
            <div class="my-5 text-center text-xl-start">
                <h2>管理客戶訂單</h2>
                <br />
                <asp:GridView ID="gv_orderlist" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField DataField="OrderID" HeaderText="訂單序號" />
                        <asp:BoundField DataField="CreateDate" HeaderText="購買日期" DataFormatString="{0:yyyy/MM/dd HH:mm}" />
                        <asp:BoundField DataField="Name" HeaderText="姓名" />
                        <asp:BoundField DataField="Total" HeaderText="總金額" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <label>元</label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Quantity" HeaderText="總張數" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <label>張</label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="OrderStatus" HeaderText="訂單狀態" />
                        <asp:BoundField HeaderText="修改訂單日期" DataField="ModifyDate" DataFormatString="{0:yyyy/MM/dd HH:mm}" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="OrderDetail.aspx?ID=<%# Eval("OrderID")%>">
                                    <img src="/Images/icons-search.png" />
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
