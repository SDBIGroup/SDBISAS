<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AddNewUser.aspx.cs" Inherits="Admin_AddNewUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .a {
        margin-left:200px;

        }
        .b {
       width: 100%;
        height:550px;
        margin:0 auto;
        }
    </style>
    <div class="b">
    <div class="a">
         <br />
    选择系部：
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>信息与艺术设计系</asp:ListItem>
        <asp:ListItem>经管系</asp:ListItem>
        <asp:ListItem>商务外语系</asp:ListItem>
    </asp:DropDownList>
   </div>
         <br />
    <div class="a">
         选择权限：
    <asp:DropDownList ID="DropDownList2" runat="server">
        <asp:ListItem>管理员</asp:ListItem>
        <asp:ListItem>系部领导</asp:ListItem>
        <asp:ListItem>教师</asp:ListItem>
    </asp:DropDownList>
        </div>
    <br />
        <div class="a">
    工号：
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </div>
         <br />
            <div class="a">
    姓名：
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </div>
         <br />
                <div class="a">
    性别：
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </div>
    <br />
    <div class="a">
    <asp:Button ID="Button1" runat="server" Text="添加账户" OnClick="Button1_Click" />
    </div>
        </div>
</asp:Content>

