<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdmin/Admin.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="TakeAwalk.SystemAdmin.OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gv_orderdetails" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="TicketName" HeaderText="票券名稱" />
            <asp:BoundField DataField="TrainCompany" HeaderText="主辦單位" />
            <asp:BoundField DataField="ActivityStartDate" DataFormatString="{0:d}" HeaderText="活動開始日期" />
            <asp:BoundField DataField="ActivityEndDate" DataFormatString="{0:d}" HeaderText="活動結束日期" />
            <asp:BoundField DataField="Price" HeaderText="票價" />
            <asp:BoundField DataField="Quantity" HeaderText="數量" />
            <asp:TemplateField>
            <itemtemplate>
                <button type="button"><img src="/Images/trash_icon.png" onclick="Imgbtn_delete_Click"></button>
            </itemtemplate>
            </asp:TemplateField>       
        </Columns>
    </asp:GridView>
</asp:Content>
