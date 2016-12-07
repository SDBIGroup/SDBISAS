<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="LoadExcelToDataBase.aspx.cs" Inherits="Admin_LoadExcelToDataBase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <style type="text/css">
.a{
	width:100%;
	height:30px;
    background-color:#333;
	/*background-image:url(images/99.png);*/
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
       .d {
        
       margin-left:30px;
       }
</style>
        <div class="a"><span class="c">教师导入</span></div>
        <div class="b">
    <asp:RadioButton ID="rdoTeachers" runat="server" OnCheckedChanged="rdo_CheckedChanged" Text="本校教师" />
       
    <asp:RadioButton ID="rdoOthers" runat="server" Text="外聘教师" OnCheckedChanged="rdo_CheckedChanged" />
        </div>
    
    <br />
    <div class="d">
    <asp:Label ID="Label2" runat="server" Text="请选择要导入的文件"></asp:Label>

    <asp:FileUpload ID="FileUpload1" runat="server" />
    
    <asp:Button ID="btnImportTeachers" runat="server" Text="导入"  OnClick="btnImportTeachers_Click" />
   
    </div>
       
    <br />
  
    <div class="a"><span class="c">各系导入</span></div>
      
    <asp:DropDownList runat="server" ID="ddlDepartmentName" OnSelectedIndexChanged="ddlDepartmentName_SelectedIndexChanged">
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
   
   
    <asp:FileUpload ID="filecourse" runat="server" />
    <asp:Button ID="btnImportCourse" runat="server" Text="导入" OnClick="btnImportCourse_Click" />
    <br />
     <div class="a"><span class="c">校历导入</span></div>
    <asp:FileUpload ID="FileUpload2" runat="server" />
    <asp:Button ID="BtnImportCalendar" runat="server" Text="导入" OnClick="BtnImportCalendar_Click" />
    <br />
    <asp:Label ID="lbMessage1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage2" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage3" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage4" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage5" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage6" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage7" runat="server" Text="Label"></asp:Label>
    <br />
    <div class="a"><span class="c">数据分析</span></div>
    <asp:Button ID="btnClearPreData" runat="server" Text="清除入库数据" />
    <asp:Button ID="btnPreOperation" runat="server" Text="Button" />
    <asp:Button ID="btnTeacherAttendance" runat="server" Text="Button" />
</asp:Content>

