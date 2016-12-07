<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceDetails.aspx.cs" Inherits="Admin_AttendanceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .a {
            float: left;
            margin-left: 15px;
        }

        .b {
            margin: 0 auto;
        }
    </style>
    <div class="a">
        <asp:label id="Label1" runat="server"></asp:label>
        <asp:button id="btnClose" runat="server" text="关闭" onclick="btnClose_Click" />
        <asp:button id="btnAtten" runat="server" text="提交" onclick="btnAtten_Click" />

        <asp:label id="Label2" runat="server"></asp:label>

        <asp:label id="Label3" runat="server"></asp:label>

        <asp:label id="Label4" runat="server"></asp:label>

        <asp:label id="Label5" runat="server"></asp:label>

        <asp:label id="Label6" runat="server"></asp:label>
    </div>
    <asp:scriptmanager id="ScriptManager1" runat="server">
  </asp:scriptmanager>
    <div class="b">
        <asp:updatepanel runat="server" id="UpdatePanel1">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="class_department" HeaderText="所属系部" />
            <asp:BoundField DataField="class_name" HeaderText="班级" />
            <asp:BoundField DataField="stu_id" HeaderText="学号" />
            <asp:BoundField DataField="stu_name" HeaderText="姓名" />
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
      </ContentTemplate>
    </asp:updatepanel>
    </div>

    <asp:sqldatasource id="SqlDataSource1" runat="server" connectionstring="<%$ ConnectionStrings:myConn %>" selectcommand="SELECT [class_department], [stu_id], [stu_name], [class_name] FROM [TabCourses] WHERE (([teacher_id] = @TeacherID) AND ([course] = @Course) AND ([current_week] = @CurrentWeek) AND ([time] = @Time) AND ([week] = @Week))">
        <SelectParameters>
            <asp:SessionParameter Name="TeacherID" SessionField="userID" Type="String" />
            <asp:SessionParameter Name="Course" SessionField="currentCourse" Type="String" />
            <asp:SessionParameter Name="CurrentWeek" SessionField="currentWeek" Type="String" />
            <asp:SessionParameter Name="Time" SessionField="time" Type="String" />
            <asp:SessionParameter Name="Week" SessionField="week" Type="String" />
        </SelectParameters>
    </asp:sqldatasource>

</asp:Content>

