<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="SendMessage.aspx.cs" Inherits="Admin_SendMessage" enableEventValidation="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
        .b {
            width:800px;
            margin-left:300px;

        }
        .c {
        
        width:1000px;
        height:400px;
        margin-left:20px;
        }
        .d {
        margin-left:200px;
        }

     </style>
    <div class="b">
    <asp:CheckBox ID="teacher" runat="server" Text="教师"/>
        &nbsp;
    <asp:CheckBox ID="fdy" runat="server" Text ="辅导员"/>
         &nbsp;
    <asp:CheckBox ID="ld" runat="server" Text ="系院领导"/>
         &nbsp;
    <asp:CheckBox ID="admin" runat="server" Text ="管理员"/>
         &nbsp;
       </div>
    <br />
    <div class="c">
    <asp:TextBox ID="TextBox1" runat="server" Height="380px" Rows="30" Width="980px" Columns="300" TextMode="MultiLine"></asp:TextBox>
        </div>
    <br />
    <div class="d">
    <asp:Button ID="Button1" runat="server" Text="发送消息" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

