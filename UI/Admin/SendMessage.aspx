<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="Admin_SendMessage" enableEventValidation="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:CheckBox ID="teacher" runat="server" Text="教师"/>
    <asp:CheckBox ID="fdy" runat="server" Text ="辅导员"/>
    <asp:CheckBox ID="ld" runat="server" Text ="系院领导"/>
    <asp:CheckBox ID="admin" runat="server" Text ="管理员"/>
    <br />
    <asp:TextBox ID="TextBox1" runat="server" Height="200px" Rows="30" Width="500px" Columns="300" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Button ID="Button1" runat="server" Text="发送消息" OnClick="Button1_Click" />
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>

