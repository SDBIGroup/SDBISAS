<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="DataChart.aspx.cs" Inherits="Admin_DataChart" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
     <style type="text/css">
         .a {
         margin-left:30px;

         }
         .b {
         background-color:greenyellow;
        
         }
         </style>

    <div class="b">
    截至目前，各系旷课人数
        </div>
   
    <br /><div class="a">
    <asp:Chart ID="Chart1" runat="server" Width="1000px" Height="230px">
        <Series>
            <asp:Series Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
     </div>
    <br />
    <br />
    <div class="b">
    截至目前，各系迟到人数
      </div> 
    <br /> <div class="a">
    <asp:Chart ID="Chart2" runat="server" Width="1000px" Height="230px">
        <Series>
            <asp:Series Name="Series1">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
         </div>
</asp:Content>

