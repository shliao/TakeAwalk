<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="CustomerList.aspx.cs" Inherits="TakeAwalk.SystemAdmin.CustomerList" %>

<%@ Register Src="~/UserControls/ucPager.ascx" TagPrefix="uc1" TagName="ucPager" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row gx-5 align-items-center justify-content-center" style="background-color: lightgray">
        <div class="col-lg-8 col-xl-7 col-xxl-6">
            <div class="my-5 text-center text-xl-start">
                <h2>客戶資料</h2>
                <br />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                    <Columns>
                        <%--        <asp:BoundField DataField="CustomerID" HeaderText="客戶編號" />--%>
                        <asp:BoundField DataField="Name" HeaderText="姓名" />
                        <asp:BoundField DataField="IdNumber" HeaderText="身分證字號" />
                        <asp:BoundField DataField="MobilePhone" HeaderText="手機號碼" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="Account" HeaderText="帳號" />
                        <asp:BoundField DataField="Password" HeaderText="密碼" DataFormatString="********" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="OrderList.aspx?CustomerID=<%# Eval("CustomerID") %>">
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
                <asp:Literal runat="server" ID="ltPager">
                </asp:Literal>
                <uc1:ucPager runat="server" ID="ucPager" PageSize="10" CurrentPage="1" TotalSize="10" Url="CustomerList.aspx" />
                <asp:PlaceHolder ID="plcNoData" runat="server" Visible="false">
                    <p style="color: red; background-color: cornflowerblue">
                        沒有客戶資料...
                    </p>
                </asp:PlaceHolder>
            </div>
        </div>
    </div>
</asp:Content>
