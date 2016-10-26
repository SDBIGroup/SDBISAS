<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="School_Teachers.aspx.cs" Inherits="Admin_School_Teachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label2" runat="server" Text="按系部查询"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem>所有</asp:ListItem>
    <asp:ListItem Value="信息与艺术设计系"></asp:ListItem>
    <asp:ListItem Value="会计系"></asp:ListItem>
</asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="查询" />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>

