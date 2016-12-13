<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="LocationTeachers.aspx.cs" Inherits="Admin_LocationTeachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
      <style type="text/css">
         .a {
             margin: 0 auto;
             width: 100%;
             height: 600px;
         }
         </style>
    <asp:label runat="server" text="请选择查询的部门"></asp:label>
    &nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList1" runat="server">
        <asp:ListItem>教务处</asp:ListItem>
        <asp:ListItem>会计系</asp:ListItem>
        <asp:ListItem>经济管理系</asp:ListItem>
        <asp:ListItem>食品工程系</asp:ListItem>
        <asp:ListItem>机械工程系</asp:ListItem>
        <asp:ListItem>信息工程系</asp:ListItem>
    </asp:DropDownList>
    &nbsp;
    <asp:Button ID="Button1" runat="server" Text=" 查询 " OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="3" GridLines="Horizontal" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="Department" HeaderText="所属部门" ReadOnly="True">
                <ControlStyle Width="100px" />
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="User_ID" HeaderText="工号" ReadOnly="True">
                <ControlStyle Width="100px" />
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="User_Name" HeaderText="姓名" ReadOnly="True">
                <ControlStyle Width="100px" />
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="权限">
                <EditItemTemplate>
                    <asp:DropDownList ID="dStatus" runat="server">
                        <asp:ListItem>1</asp:ListItem>
                        <asp:ListItem>2</asp:ListItem>
                        <asp:ListItem>3</asp:ListItem>
                        <asp:ListItem>4</asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Role") %>'></asp:Label>
                </ItemTemplate>
                <ControlStyle Width="50px" />
                <ItemStyle Width="100px" />
            </asp:TemplateField>
            <asp:CommandField HeaderText="编辑" ShowEditButton="True">
                <ItemStyle Width="100px" />
            </asp:CommandField>
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                <ItemStyle Width="90px" />
            </asp:CommandField>
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
    </div>
</asp:Content>

