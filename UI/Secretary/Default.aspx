<%@ Page Title="" Language="C#" MasterPageFile="~/Secretary/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Secretary_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    这是admin面板
     <style type="text/css">
         .a {
             margin: 0 auto;
             width: 100%;
             height: 300px;
         }
         .b{ width:400px;}
         .c{ width:800px;}
         .d{ width:300px;}
         .e {width:200px;
         }
         * {
             text-align:center;
         }
        
         </style>

    <asp:Label ID="lbTitile" runat="server" ></asp:Label>
    <div class="a">

    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <HeaderTemplate>
            <!-- 显示头部 -->
            <table class="movies">
                <!-- table头部声明-->
                <tr>
                    <th class="b">序号</th>
                    <th class="c">详细信息</th>
                    <th class="d">附加选项</th>
                    <th class="e">操作</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <!-- 数据行 -->
            <tr>
                <td class="b">
                    <%--自动编号--%>
                    <asp:Label ID="lbNo" runat="server" Text="<%#Container.ItemIndex+1 %>"></asp:Label>
                </td>
                <td class="c">
                   <asp:Label ID="TBweek" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Week") %>'></asp:Label>
                    <asp:Label ID="TBtime" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Time") %>'></asp:Label>
                    <asp:Label ID="TBcour" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Course") %>'></asp:Label>
                    <asp:Label ID="TBarea" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Area") %>'></asp:Label>
                </td>
                <td class="d">
                    <asp:CheckBox ID="CheckBox1" Text="布置作业" runat="server" />
                </td>
                <td  class="e">
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
    </div>
    <asp:Label ID="lbWork" runat="server" Text="Label"></asp:Label>
    <br />


    <asp:Repeater ID="Repeater2" runat="server">
         <HeaderTemplate>
            <!-- 显示头部 -->
            <table class="movies">
                <!-- table头部声明-->
                <tr>
                    <th>序号</th>
                    <th>详细信息</th>
                    <th>操作</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <!-- 数据行 -->
            <tr>
                <td class="b">
                    <%--自动编号--%>
                    <asp:Label ID="Label1" runat="server" Text="<%#Container.ItemIndex+1 %>"></asp:Label>
                </td>
                <td class="c">
                   <asp:Label ID="Label2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Week") %>'></asp:Label>
                    <asp:Label ID="Label3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Time") %>'></asp:Label>
                    <asp:Label ID="Label4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Course") %>'></asp:Label>
                    <asp:Label ID="Label5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"Area") %>'></asp:Label>
                </td>
                <td class="d">
                    <asp:Button ID="Button2" runat="server" Text="批改作业" />
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

