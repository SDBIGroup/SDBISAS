<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    这是admin面板
    <br />
    <asp:Label ID="lbTitile" runat="server" Text="Label"></asp:Label>
    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <!-- 显示头部 -->
            <table class="movies">
                <!-- table头部声明-->
                <tr>
                    <th>序号</th>
                    <th>详细信息</th>
                    <th>附加选项</th>
                    <th>操作</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <!-- 数据行 -->
            <tr>
                <td>
                    <%--自动编号--%>
                    <asp:Label ID="lbNo" runat="server" Text="<%#Container.ItemIndex+1 %>"></asp:Label>
                </td>
                <td>
                   <asp:TextBox ID="TBweek" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Week") %>'></asp:TextBox>
                    <asp:TextBox ID="TBtime" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Time") %>'></asp:TextBox>                          '
                    <asp:TextBox ID="TBcour" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Course") %>'></asp:TextBox>                         '
                    <asp:TextBox ID="TBarea" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Area") %>'></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="CheckBox1" Text="布置作业" runat="server" />
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="考勤" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <!-- 脚注行 -->
            </table>   
            <!-- table尾 -->
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="lbWork" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Repeater ID="Repeater2" runat="server"></asp:Repeater>
</asp:Content>

