<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="AttendanceDetails.aspx.cs" Inherits="Admin_AttendanceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <style type="text/css">
.a { 
      margin-left:15px;
       }
        .b {
            width: 100%;
            height:500px;
           margin:0 auto;
            text-align:center;
       }
        .c {
        width:150px;
        }
        .d {
        background-image:url(../images/99.png)
        }
        </style>
    
    <asp:Label ID="Label1" runat="server" ></asp:Label> &nbsp;
    <asp:Button ID="btnClose" runat="server" Text="Close" OnClick="btnClose_Click" /> &nbsp;
    <asp:Button ID="btnAtten" runat="server" Text="提交" OnClick="btnAtten_Click" /> &nbsp;
   <br/>
    <div class="d">
    <asp:Label ID="Label2" runat="server" ></asp:Label>
   
    <asp:Label ID="Label3" runat="server" ></asp:Label>
    
    <asp:Label ID="Label4" runat="server" ></asp:Label>
    
    <asp:Label ID="Label5" runat="server" ></asp:Label>
    
    <asp:Label ID="Label6" runat="server" ></asp:Label>
   </div>
    <asp:scriptmanager id="ScriptManager1" runat="server">
  </asp:scriptmanager>
    <div class="b">
    <asp:updatepanel runat="server" id="UpdatePanel1">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Height="318px" style="margin-top: 0px" Width="1017px">
                <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            
            <asp:BoundField DataField="class_department" HeaderText="所属系部"><ControlStyle Width="100px" />
                <ItemStyle Width="200px" /></asp:BoundField>
                
            <asp:BoundField DataField="class_name" HeaderText="班级" ><ControlStyle Width="80px" />
                <ItemStyle Width="150px" /></asp:BoundField>
            <asp:BoundField DataField="stu_id" HeaderText="学号" ><ControlStyle Width="100px" />
                <ItemStyle Width="150px" /></asp:BoundField>
            <asp:BoundField DataField="stu_name" HeaderText="姓名" >
               </asp:BoundField>
          
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
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
      </ContentTemplate>
    </asp:updatepanel>
    </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:myConn %>" SelectCommand="SELECT [class_department], [stu_id], [stu_name], [class_name] FROM [TabCourses] WHERE (([teacher_id] = @TeacherID) AND ([course] = @Course) AND ([current_week] = @CurrentWeek) AND ([time] = @Time) AND ([week] = @Week))">
        <SelectParameters>
            <asp:SessionParameter Name="TeacherID" SessionField="userID" Type="String" />
            <asp:SessionParameter Name="Course" SessionField="currentCourse" Type="String" />
            <asp:SessionParameter Name="CurrentWeek" SessionField="currentWeek" Type="String" />
            <asp:SessionParameter Name="Time" SessionField="time" Type="String" />
            <asp:SessionParameter Name="Week" SessionField="week" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>

</asp:Content>

