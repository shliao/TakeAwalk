﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="Tickets.aspx.cs" Inherits="TakeAwalk.SystemAdmin.Tickets" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row gx-5 align-items-center justify-content-center" style="background-color: lightgray">
        <div class="col-lg-8 col-xl-7 col-xxl-6">
            <div class="my-5 text-center text-xl-start">
                <h2>優惠票購買</h2>
                <br />
                <asp:GridView ID="gv_ticket" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="700px">
                    <Columns>
                        <asp:BoundField DataField="TicketID" HeaderText="票券編號" />
                        <asp:BoundField DataField="TicketName" HeaderText="票券名稱" />
                        <asp:BoundField DataField="TrainCompany" HeaderText="主辦單位" />
                        <asp:BoundField DataField="ActivityStartDate" HeaderText="開始日期" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="ActivityEndDate" HeaderText="結束日期" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="Price" HeaderText="票價" />
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
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                <asp:GridView ID="gv_selected" runat="server" AutoGenerateColumns="False" Visible="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="TicketID" HeaderText="票券編號" />
                        <asp:BoundField DataField="TicketContent_Confirm" HeaderText="票券名稱" />
                        <asp:BoundField DataField="TrainCompany_Confirm" HeaderText="主辦單位" />
                        <asp:BoundField DataField="TicketPrice_Confirm" HeaderText="票價" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <label>元</label></ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Quantity_Confirm" HeaderText="數量" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <label>張</label></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:Label ID="lbError" runat="server" Text="未勾選任何優惠票，請按取消後重新操作" Visible="False"></asp:Label>
                <asp:Label ID="lbAmount" runat="server" Visible="False"></asp:Label><br /><br />
                <asp:Button ID="btnConfirm" runat="server" Text="確認選項" OnClick="btnConfirm_Click" />
                <asp:Button ID="btnBuy" runat="server" Text="確定訂購" OnClick="btnBuy_Click" Visible="False" />
                <asp:Button ID="btnCancel" runat="server" Text="取消" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
    <!--使用者登入時,隱藏管理者頁面-->
    <script>
        var admin = document.getElementById('admin');
        var admin2 = document.getElementById('admin2');
        if (0 ==<%=currentUser.UserLevel%>) {
            admin.style.display = 'none';
            admin2.style.display = 'none';}
    </script>
</asp:Content>