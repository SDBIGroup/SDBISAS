<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="ChangePWD.aspx.cs" Inherits="Admin_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .a {
        margin-left:20px;

        }
        .b {
            margin-left:30px;
        }
        .c { background-image:url(../images/bg4.jpg);
            width:500px;
            margin-left:300px;
        }
       </style>
    <div class="c">
    <div class="a">
    <asp:Label ID="Label2" runat="server" Text="原密码"></asp:Label>
        &nbsp;
    <asp:TextBox ID="ymm" type="password" runat="server" ></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        </div>
    <div class="a">
    <br/>
    <asp:Label ID="Label3" runat="server" Text="新密码"></asp:Label>
         &nbsp;
    <asp:TextBox ID="xmm" type="password" runat="server"></asp:TextBox>
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        </div>
        <div class="a">
    <br/>
    <asp:Label ID="Label1" type="password" runat="server" Text="确认密码"></asp:Label>
             
    <asp:TextBox ID="qrmm" runat="server"></asp:TextBox>
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
            </div>
    <div class="b">
    <br/>
        
    <asp:Button ID="Button1" runat="server" Text=" 确认 " OnClick="Button1_Click" />
        <br/>
          <asp:Label ID="Label7" runat="server"></asp:Label>
        </div>
        </div>
</asp:Content>

