<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="LoadExcelToDataBase.aspx.cs" Inherits="Admin_LoadExcelToDataBase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:RadioButton ID="rdoTeachers" runat="server" OnCheckedChanged="rdo_CheckedChanged" Text="本校教师" />
    <asp:RadioButton ID="rdoOthers" runat="server" Text="外聘教师" OnCheckedChanged="rdo_CheckedChanged" />
    <br />
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="btnImportTeachers" runat="server" Text="导入" OnClick="btnImportTeachers_Click" />
    <br />
    <asp:dropdownlist runat="server" ID="ddlDepartmentName" OnSelectedIndexChanged="ddlDepartmentName_SelectedIndexChanged"></asp:dropdownlist>
    <asp:FileUpload ID="filecourse" runat="server" />
    <asp:Button ID="btnImportCourse" runat="server" Text="导入" OnClick="btnImportCourse_Click" />
    <br />
    <asp:Label ID="lbMessage1" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage2" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage3" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage4" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage5" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage6" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="lbMessage7" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Button ID="btnClearPreData" runat="server" Text="清除入库数据" />
    <asp:Button ID="btnPreOperation" runat="server" Text="Button" />
    <asp:Button ID="btnTeacherAttendance" runat="server" Text="Button" />
</asp:Content>

