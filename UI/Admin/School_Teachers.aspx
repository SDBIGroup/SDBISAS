<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="School_Teachers.aspx.cs" Inherits="Admin_School_Teachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
.a { margin:0 auto;
       }
</style>
    <asp:button id="Button1" runat="server" text="查询" onclick="Button1_Click" />
    <div class="a">
    <asp:gridview id="GridView1" runat="server"></asp:gridview>
        </div>
    <br />
    <asp:label id="Label2" runat="server" text="Label"></asp:label>
</asp:Content>

