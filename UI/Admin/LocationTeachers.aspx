<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="LocationTeachers.aspx.cs" Inherits="Admin_LocationTeachers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnPageIndexChanging="GridView1_PageIndexChanging">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="Department" HeaderText="所属部门" ReadOnly="True">
            <ControlStyle Width="80px" />
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="UserID" HeaderText="工号" ReadOnly="True" >
            <ControlStyle Width="80px" />
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="UserName" HeaderText="姓名" ReadOnly="True" >
            <ControlStyle Width="80px" />
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Role" HeaderText="权限" >
            <ControlStyle Width="50px" />
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:CommandField HeaderText="编辑" ShowEditButton="True" >
            <ItemStyle Width="80px" />
            </asp:CommandField>
            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" >
            <ItemStyle Width="70px" />
            </asp:CommandField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</asp:Content>

