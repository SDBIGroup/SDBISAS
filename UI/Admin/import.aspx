<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="import.aspx.cs" Inherits="Admin_import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:FileUpload ID="fuload" runat="server" />
    <br />
    <asp:Button ID="Button1" runat="server" Text="导入" OnClick="Btn1_Click" />
    <br />
    <asp:Label ID="lbmsg" runat="server" Text="Label"></asp:Label>

    <hr />

    <div>
        基本教师信息
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>本校教师</asp:ListItem>
            <asp:ListItem>外聘教师</asp:ListItem>
        </asp:RadioButtonList>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>
    <br />
    <br />
    <div>
        教师授课信息
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>教务处</asp:ListItem>
            <asp:ListItem>信息工程系</asp:ListItem>
            <asp:ListItem>会计系</asp:ListItem>
            <asp:ListItem>经济管理系</asp:ListItem>
            <asp:ListItem>食品工程系</asp:ListItem>
            <asp:ListItem>商务外语系</asp:ListItem>
            <asp:ListItem>机械工程系</asp:ListItem>
            <asp:ListItem>基础教学部</asp:ListItem>
            <asp:ListItem>建筑工程系</asp:ListItem>
        </asp:DropDownList>
        <asp:FileUpload ID="FileUpload2" runat="server" />
    </div>
    <br />
    <br />
    <div>
        校历
        <br />
        <asp:FileUpload ID="FileUpload3" runat="server" />
    </div>


</asp:Content>

