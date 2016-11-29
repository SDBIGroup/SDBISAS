<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddNewUser.aspx.cs" Inherits="Admin_AddNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    选择系部：
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>信息与艺术设计系</asp:ListItem>
        <asp:ListItem>经管系</asp:ListItem>
        <asp:ListItem>商务外语系</asp:ListItem>
    </asp:DropDownList>
    选择权限：
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>管理员</asp:ListItem>
        <asp:ListItem>系部领导</asp:ListItem>
        <asp:ListItem>教师</asp:ListItem>
    </asp:DropDownList>
    <br />
    工号：
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    姓名：
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    性别：
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
    <br />

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
</asp:Content>

