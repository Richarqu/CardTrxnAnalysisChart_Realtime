<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <h2>STERLING CARD TRANSACTION ANALYSIS</h2>
        <%-- %><p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>--%>
    </div>

    <div class="row">
        <div class="col-xs-6">
            <asp:Chart ID="ChartATM" runat="server" Height="350px" Width="650px" OnDataBound="ChartATM_DataBound" >
                    <Series>
                        <asp:Series Name="Series1" LegendText ="Success" ChartArea="ChartAreaATM" XValueMember="Hour"  YValueMembers="Success" Color="LimeGreen" IsValueShownAsLabel="true" ToolTip="#XVAL"></asp:Series>
                    </Series>
                    <Series>
                        <asp:Series Name="Series2" LegendText ="Failed" ChartArea="ChartAreaATM" XValueMember="Hour" YValueMembers="Failed" Color="Orange" IsValueShownAsLabel="true" ToolTip="#XVAL" ></asp:Series>
                    </Series>
                    <Series>
                        <asp:Series Name="Series3" LegendText ="Timeout" ChartArea="ChartAreaATM" XValueMember="Hour" YValueMembers="Timeout" Color="FireBrick" IsValueShownAsLabel="true" ToolTip="#XVAL" ></asp:Series>
                    </Series>
                     <Legends>
                         <asp:Legend Docking="Bottom" Alignment="Center"></asp:Legend>
                     </Legends>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartAreaATM" BackColor="WhiteSmoke"></asp:ChartArea>
                    </ChartAreas>
                    <Titles>
                    <asp:Title Name="ATM" Visible="true" Text="ATM">
                    </asp:Title>
                </Titles>
                </asp:Chart>
        </div>
        <div class="col-xs-6">
            <asp:Chart ID="ChartPOS" runat="server" Height="350px" Width="650px" BorderlineWidth="10" OnDataBound="ChartPOS_DataBound">
                    <Series>
                        <asp:Series Name="Series1" LegendText ="Success" ChartArea="ChartAreaPOS" XValueMember="Hour" YValueMembers="Success" Color="LimeGreen" IsValueShownAsLabel="true"></asp:Series>
                    </Series>
                    <Series>
                        <asp:Series Name="Series2" LegendText ="Failed" ChartArea="ChartAreaPOS" XValueMember="Hour" YValueMembers="Failed" Color="Orange" IsValueShownAsLabel="true"></asp:Series>
                    </Series>
                <Series>
                        <asp:Series Name="Series3" LegendText ="Timeout" ChartArea="ChartAreaPOS" XValueMember="Hour" YValueMembers="Timeout" Color="FireBrick" IsValueShownAsLabel="true" ToolTip="#XVAL" ></asp:Series>
                    </Series>
                     <Legends>
                         <asp:Legend Docking="Bottom" Alignment="Center"></asp:Legend>
                     </Legends>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartAreaPOS" BackColor="WhiteSmoke"></asp:ChartArea>
                    </ChartAreas>
                <Titles>
                    <asp:Title Name="POS" Visible="true" Text="POS">
                    </asp:Title>
                </Titles>
                </asp:Chart>
        </div>
        <div class="col-xs-6">
            <asp:Chart ID="ChartOTH" runat="server" Height="350px" Width="650px" BorderlineWidth ="15" OnDataBound="ChartOTH_DataBound">
                    <Series>
                        <asp:Series Name="Series1" LegendText ="Success" ChartArea="ChartAreaOTH" XValueMember="Hour" YValueMembers="Success" Color="LimeGreen" IsValueShownAsLabel="true"></asp:Series>
                    </Series>
                    <Series>
                        <asp:Series Name="Series2" LegendText ="Failed" ChartArea="ChartAreaOTH" XValueMember="Hour" YValueMembers="Failed" Color="Orange" IsValueShownAsLabel="true"></asp:Series>
                    </Series>
                <Series>
                        <asp:Series Name="Series3" LegendText ="Timeout" ChartArea="ChartAreaOTH" XValueMember="Hour" YValueMembers="Timeout" Color="FireBrick" IsValueShownAsLabel="true"></asp:Series>
                    </Series>
                     <Legends>
                         <asp:Legend Docking="Bottom" Alignment="Center"></asp:Legend>
                     </Legends>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartAreaOTH" BackColor="WhiteSmoke"></asp:ChartArea>
                    </ChartAreas>
                 <Titles>
                    <asp:Title Name="OTHERS" Visible="true" Text="OTHERS">
                    </asp:Title>
                </Titles>
                </asp:Chart>  
        </div>
        <div class="col-xs-6">
            <asp:Chart ID="ChartNOU" runat="server" Height="350px" Width="650px" BorderlineWidth ="15" Visible="false">
                    <Series>
                        <asp:Series Name="Series1" LegendText ="Success" ChartArea="ChartAreaNOU" XValueMember="Hour" YValueMembers="Success" Color="LimeGreen" IsValueShownAsLabel="true"></asp:Series>
                    </Series>
                    <Series>
                        <asp:Series Name="Series2" LegendText ="Failed" ChartArea="ChartAreaNOU" XValueMember="Hour" YValueMembers="Failed" Color="FireBrick" IsValueShownAsLabel="true"></asp:Series>
                    </Series>
                <Series>
                        <asp:Series Name="Series3" LegendText ="Timeout" ChartArea="ChartAreaNOU" XValueMember="Hour" YValueMembers="Timeout" Color="FireBrick" IsValueShownAsLabel="true"></asp:Series>
                    </Series>
                     <Legends>
                         <asp:Legend Docking="Bottom" Alignment="Center"></asp:Legend>
                     </Legends>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartAreaNOU" BackColor="WhiteSmoke"></asp:ChartArea>
                    </ChartAreas>
                 <Titles>
                    <asp:Title Name="NOU" Visible="true" Text="NOU">
                    </asp:Title>
                </Titles>
                </asp:Chart>  
        </div>
    </div>
    <script type="text/javascript">
        function Reload() {
            location.reload();
        }
        setTimeout(Reload, 60000);
    </script>
</asp:Content>
