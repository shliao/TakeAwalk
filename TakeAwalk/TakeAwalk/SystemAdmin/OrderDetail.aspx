<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="TakeAwalk.SystemAdmin.OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row gx-5 align-items-center justify-content-center" style="background-color: lightgray">
        <div class="col-lg-8 col-xl-7 col-xxl-6">
            <div class="my-5 text-center text-xl-start">
                <h2>購票內容</h2>
                <br />
                <asp:GridView ID="gv_orderdetails" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="650px">
                    <Columns>
                        <asp:BoundField DataField="TicketID" HeaderText="票券編號" />
                        <asp:BoundField DataField="TicketName" HeaderText="票券名稱" />
                        <asp:BoundField DataField="TrainCompany" HeaderText="主辦單位" />
                        <asp:BoundField DataField="ActivityStartDate" DataFormatString="{0:d}" HeaderText="活動開始日期" />
                        <asp:BoundField DataField="ActivityEndDate" DataFormatString="{0:d}" HeaderText="活動結束日期" />
                        <asp:BoundField DataField="Price" HeaderText="票價" />
                        <asp:BoundField DataField="Quantity" HeaderText="數量" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <LinkButton onclick="Imgbtn_delete_Click" runat="server">
                                    <img src="/Images/trash_icon.png" height="20" width="20"></LinkButton>
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