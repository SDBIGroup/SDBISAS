<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="School_Teachers.aspx.cs" Inherits="Admin_School_Teachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
</asp:Content>

