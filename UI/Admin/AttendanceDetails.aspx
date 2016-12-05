<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceDetails.aspx.cs" Inherits="Admin_AttendanceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" />
    <asp:Button ID="btnAtten" runat="server" Text="提交" OnClick="btnAtten_Click" />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound">
        <Columns>
            <asp:BoundField DataField="ClassDepartment" HeaderText="所属系部" />
            <asp:BoundField DataField="ClassName" HeaderText="班级" />
            <asp:BoundField DataField="StuID" HeaderText="学号" />
            <asp:BoundField DataField="StuName" HeaderText="姓名" />
            <asp:TemplateField HeaderText="出勤情况">
                <ItemTemplate>
                    <asp:RadioButton ID="RadioButton1" runat="server" Text="正常" Checked="true" OnCheckedChanged="rdo_CheckChange" GroupName="g1" AutoPostBack="true" />
                    <asp:RadioButton ID="RadioButton2" runat="server" Text="迟到" OnCheckedChanged="rdo_CheckChange" GroupName="g1" AutoPostBack="true" />
                    <asp:RadioButton ID="RadioButton3" runat="server" Text="旷课" OnCheckedChanged="rdo_CheckChange" GroupName="g1" AutoPostBack="true" />
                    <asp:RadioButton ID="RadioButton4" runat="server" Text="早退" OnCheckedChanged="rdo_CheckChange" GroupName="g1" AutoPostBack="true" />
                    <asp:RadioButton ID="RadioButton5" runat="server" Text="请假" OnCheckedChanged="rdo_CheckChange" GroupName="g1" AutoPostBack="true" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:myConn %>" SelectCommand="SELECT [ClassDepartment], [StuID], [StuName], [ClassName] FROM [TabAllCourses] WHERE (([TeacherID] = @TeacherID) AND ([Course] = @Course) AND ([CurrentWeek] = @CurrentWeek) AND ([Time] = @Time) AND ([Week] = @Week))">
        <SelectParameters>
            <asp:SessionParameter Name="TeacherID" SessionField="UserID" Type="String" />
            <asp:SessionParameter Name="Course" SessionField="course" Type="String" />
            <asp:SessionParameter Name="CurrentWeek" SessionField="week" Type="String" />
            <asp:SessionParameter Name="Time" SessionField="time" Type="String" />
            <asp:SessionParameter Name="Week" SessionField="gweek" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

