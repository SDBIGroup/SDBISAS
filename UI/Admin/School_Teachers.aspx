<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="School_Teachers.aspx.cs" Inherits="Admin_School_Teachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:button id="Button1" runat="server" text="查询" onclick="Button1_Click" />
    <asp:gridview id="GridView1" runat="server"></asp:gridview>
    <br />
    <asp:label id="Label2" runat="server" text="Label"></asp:label>
</asp:Content>

