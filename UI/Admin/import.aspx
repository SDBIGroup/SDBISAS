<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="import.aspx.cs" Inherits="Admin_import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:FileUpload ID="fuload" runat="server" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="导入" OnClick="Btn1_Click" />
    <br />
    <asp:Label ID="lbmsg" runat="server" Text="Label"></asp:Label>


</asp:Content>

