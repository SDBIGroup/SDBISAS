<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="import.aspx.cs" Inherits="Admin_import" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .a{
	width:100%;
	height:30px;
   
	background-image:url(images/99.png);
	}  
          .b {
          float:left;
          margin-left:300px;
         
       }
        .c{
	font-size:16px;
	color:#CCC;
    margin-left:15px;
	

       }
        </style>
    <div class="a"></div>
    <asp:FileUpload ID="fuload" runat="server" />
   
    <asp:Button ID="Button1" runat="server" Text="导入" OnClick="Btn1_Click" />
    </div>
    <asp:Label ID="lbmsg" runat="server" Text="Label"></asp:Label>

    <hr />

    <div>
        <div class="a"><span class="c">基本教师信息</span></div>
       
        <br />
        <div class="b">
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem>本校教师</asp:ListItem>
            <asp:ListItem>外聘教师</asp:ListItem>
        </asp:RadioButtonList>
            </div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
    </div>
    <br />
    <br />
    <div>
       
       <div class="a"><span class="c">教师授课信息</span></div>
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
         <div class="a"><span class="c">校历导入</span></div>
        <asp:FileUpload ID="FileUpload3" runat="server" />
    </div>


</asp:Content>

