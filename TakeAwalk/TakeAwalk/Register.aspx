<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TakeAwalk.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="font-size: 40px">會員註冊頁</div>
    <br />
    <table>

        <tr>
            <td>帳號:
                <asp:TextBox ID="actbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>密碼:
                <asp:TextBox ID="pwdbox" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>姓名: 
                <asp:TextBox ID="nmebox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>信箱:
                <asp:TextBox ID="emlbox" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>電話:
                <asp:TextBox ID="telbox" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>身分證字號:
                <asp:TextBox ID="idbox" runat="server"></asp:TextBox>
            </td>
        </tr>

    </table>
    <br />
    <div>
        <span>
            <asp:Button ID="Savebtn" runat="server" Text="送出" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Againbtn" runat="server" Text="重新輸入" />
        </span>
    </div>
</asp:Content>
