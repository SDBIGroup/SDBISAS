<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="GetMessage.aspx.cs" Inherits="Admin_GetMessage"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Repeater ID="Repeater1" OnItemCommand="Repeater1_ItemCommand" runat="server">
        <HeaderTemplate>
            <!-- 显示头部 -->
            <table>
                <!-- table头部声明-->
                <tr>
                    <th>序号</th>
                    <th>发布时间</th>
                    <th>详细信息</th>
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
                    <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"time") %>'></asp:Label>
                </td>
                <td>
                   <asp:Label ID="message" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"message") %>'></asp:Label>
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="已读" />
                    <asp:Label ID="msgID" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"id") %>'></asp:Label>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <!-- 脚注行 -->
            </table>   
            <!-- table尾 -->
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

