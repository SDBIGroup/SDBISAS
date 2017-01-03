<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="GetMessage.aspx.cs" Inherits="Admin_GetMessage"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="../css/style1.css" rel="stylesheet" type="text/css"/>
<script src="../js/jquery-1.10.2.min.js" type="text/javascript">
</script>
<script src="../js/jquery.tablesorter.js" type="text/javascript">
</script>
    <script type="text/javascript">
(function(){
	("#aaa").tablesorter(
	{
	sortList: [[0, 1]],
	widgets:['zebra'],
	
	
	});
	});
</script>
    <style type="text/css">
        .a {
            width:85%;
            height:500px;
        }
        .b {
            width:220px;
            text-align:center;
        }
        </style>
    <div class="a">
    <asp:Repeater ID="Repeater1" OnItemCommand="Repeater1_ItemCommand" runat="server">
        <HeaderTemplate>
            <!-- 显示头部 -->
            <table class="tablesorter" id="aaa">
                <!-- table头部声明-->
                <thead>
                <tr >
                    <th class="b">序号</th>
                    <th class="b">发布时间</th>
                    <th class="b">详细信息</th>
                    <th class="b">操作</th>
                </tr>
                </thead> 
        </HeaderTemplate> 
        <ItemTemplate><tbody>
            <!-- 数据行 -->
          
            <tr>
                <td  class="b">
                    <%--自动编号--%>
                    <asp:Label ID="lbNo" runat="server" Text="<%#Container.ItemIndex+1 %>"></asp:Label>
                </td>
                <td  class="b">
                    <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"time") %>'></asp:Label>
                </td>
                <td  class="b">
                   <asp:Label ID="message" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"message") %>'></asp:Label>
                </td>
                <td  class="b">
                    <asp:Button ID="Button1" runat="server" Text="已读" />
                    <asp:Label ID="msgID" runat="server" Visible="false" Text='<%#DataBinder.Eval(Container.DataItem,"id") %>'></asp:Label>
                </td>
            </tr>
          </tbody>
        </ItemTemplate>
        <FooterTemplate>
            <!-- 脚注行 -->
            </table>   
            <!-- table尾 -->
        </FooterTemplate>
    </asp:Repeater>
        </div>
</asp:Content>

