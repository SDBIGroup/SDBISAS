<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="School_Teachers.aspx.cs" Inherits="Admin_School_Teachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    按照系部查询<asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>教务处</asp:ListItem>
        <asp:ListItem>会计系</asp:ListItem>
        <asp:ListItem>经济管理系</asp:ListItem>
        <asp:ListItem>食品工程系</asp:ListItem>
        <asp:ListItem>机械工程系</asp:ListItem>
        <asp:ListItem>信息工程系</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"></asp:GridView>
    <br />
</asp:Content>

