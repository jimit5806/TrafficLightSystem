<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrafficLightSystemBonus.aspx.cs" Inherits="TrafficLightSystem.TrafficLightSystemBonus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true"></asp:ScriptManager>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=txtdate.ClientID %>").dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <div>
        <h1>Traffic Light System with green right-turn</h1>

        <asp:Label ID="lblError" BackColor="Red" runat="server"></asp:Label>
        <br />
        <br />

        Select Date and Time* : &nbsp;&nbsp;
        <asp:TextBox ID="txtdate" runat="server" ReadOnly="true"></asp:TextBox>
        <img src="Images/calender.png" />

        <br />
        <br />

        <asp:Button ID="btnStart" runat="server" Text="Start" OnClick="btnStart_Click" />
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;  
        <asp:Button ID="btnStop" runat="server" Text="Reset" OnClick="btnReset_Click" />

        <asp:Timer runat="server" ID="TimerDisplay" OnTick="TimerDisplay_Tick" Interval="1000" />
        <asp:UpdatePanel runat="server" ID="UpdatePanel1" RenderMode="Block">
            <triggers>
                <asp:PostBackTrigger ControlID="TimerDisplay" />
            </triggers>
        </asp:UpdatePanel>

        <asp:Timer runat="server" ID="TimerCounter" OnTick="TimerCounter_Tick" Interval="1000" />
        <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Always" RenderMode="Inline">
            <triggers>
                <asp:AsyncPostBackTrigger ControlID="TimerCounter" EventName="Tick" />
            </triggers>
            <contenttemplate>
                <br />
                Counter :
                <asp:Label ID="lblCounter" runat="server"></asp:Label>
            </contenttemplate>
        </asp:UpdatePanel>

    </div>

    <br />
    Status:
    <asp:Label ID="lblStatus" runat="server"></asp:Label>
    <br />
    <br />

    <div style="margin: auto; width: 9%; padding: 10px;">
        North 
    <br />
        <asp:Panel runat="server" Width="100px" Height="100px">
            <asp:Image ID="NorthNoLight" ImageAlign="Top" runat="server" ImageUrl="~/Images/NoLight.png" Width="100px" Height="100px" />
            <asp:Image ID="NorthGreen" runat="server" ImageUrl="~/Images/Green.jpg" Width="100px" Height="100px" Visible="false" />
            <asp:Image ID="NorthYellow" runat="server" ImageUrl="~/Images/Yellow.jpg" Width="100px" Height="100px" Visible="False" />
            <asp:Image ID="NorthRed" runat="server" ImageUrl="~/Images/Red.png" Width="100px" Height="100px" Visible="False" />
        </asp:Panel>
    </div>
    <br />


    <div style="float: left; margin-left: 25%;">
        West 
        <asp:Panel HorizontalAlign="Left" runat="server" Width="100px" Height="100px">
            <asp:Image ImageAlign="Left" ID="WestNoLight" runat="server" ImageUrl="~/Images/NoLight.png" Width="100px" Height="100px" />
            <asp:Image ID="WestGreen" runat="server" ImageUrl="~/Images/Green.jpg" Width="100px" Height="100px" Visible="false" />
            <asp:Image ID="WestYellow" runat="server" ImageUrl="~/Images/Yellow.jpg" Width="100px" Height="100px" Visible="False" />
            <asp:Image ID="WestRed" runat="server" ImageUrl="~/Images/Red.png" Width="100px" Height="100px" Visible="False" />
        </asp:Panel>
    </div>

    <div style="float: right; margin-right: 25%;">
        East 
    <br />
        <asp:Panel HorizontalAlign="Right" runat="server" Width="100px" Height="100px">
            <asp:Image ImageAlign="Right" ID="EastNoLight" runat="server" ImageUrl="~/Images/NoLight.png" Width="100px" Height="100px" />
            <asp:Image ID="EastGreen" runat="server" ImageUrl="~/Images/Green.jpg" Width="100px" Height="100px" Visible="false" />
            <asp:Image ID="EastYellow" runat="server" ImageUrl="~/Images/Yellow.jpg" Width="100px" Height="100px" Visible="False" />
            <asp:Image ID="EastRed" runat="server" ImageUrl="~/Images/Red.png" Width="100px" Height="100px" Visible="False" />
        </asp:Panel>
    </div>


    <div style="margin: auto; width: 9%; padding: 200px;">
        South 
    <br />
        <asp:Panel runat="server" Width="100px" Height="100px">
            <asp:Image ID="SouthNoLight" ImageAlign="Bottom" runat="server" ImageUrl="~/Images/NoLight.png" Width="100px" Height="100px" />
            <asp:Image ID="SouthGreen" runat="server" ImageUrl="~/Images/Green.jpg" Width="100px" Height="100px" Visible="false" />
            <asp:Image ID="SouthYellow" runat="server" ImageUrl="~/Images/Yellow.jpg" Width="100px" Height="100px" Visible="False" />
            <asp:Image ID="SouthRed" runat="server" ImageUrl="~/Images/Red.png" Width="100px" Height="100px" Visible="False" />
            <asp:Image ID="SouthGreenArrow" runat="server" ImageUrl="~/Images/GreenWithArrow.jpg" Width="100px" Height="100px" Visible="false" />
            <asp:Image ID="SouthYellowArrow" runat="server" ImageUrl="~/Images/YellowWithArrow.jpg" Width="100px" Height="100px" Visible="false" />
        </asp:Panel>
    </div>
    <br />


</asp:Content>
