<%@ Page Title="Expedia Search" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">

<h2>
    My plan for a possible trip to Latin America in the summer of 2014:<br /><br />
</h2>    
<ol>        
    <li>BUD -> JFK and MEX -> BUD flight:<br /><br />
        Search for flights from BUD to JFK on <% Response.Write(defaultOutDate); %>
         and from MEX to BUD on <% Response.Write(defaultInDate); %>
        on 
        <asp:HyperLink ID="defaultUrlLink" runat="server" Target="_blank" ToolTip="Expedia Website">expedia.com
        </asp:HyperLink> <br />
        <asp:Label ID="searchWithNewDatesLabel" runat="server" Text="" Visible="false" />
            

        <asp:Button id="chooseNewDatesButton" runat="server" Text="Choose different dates" OnClick="ChooseNewDatesButtonClicked" />
        <br />
        <asp:Label id="selectInOrOutboundLabel" runat="server" Visible="false" />
        <asp:Label id="newDateLabel" runat="server" Visible="false" />
        <asp:Label ID="helpsToMakeDateBold" runat="server" Visible = "false" Text = "</b>"/>
        
        <asp:Calendar ID="calendar1" runat="server" Visible="false"
        FirstDayOfWeek="Monday"
        Font-Bold="false"              
        SelectionMode="Day" 
        ShowGridLines="False"        
        OnInit="Initialize"
        OnSelectionChanged="SetNewDate">
        <SelectedDayStyle BackColor="#4b6c9e" ForeColor="#f9f9f9"> </SelectedDayStyle>
        </asp:Calendar>    

        <asp:Button id="chooseThisDateButton" runat="server" Enabled="false" Text="Choose this date" OnClick="ChooseThisDateButtonClicked" Visible="false" />        
    </li>        
</ol>   

<hr /><br />
    
<p>
    You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
        title="MSDN ASP.NET Docs" >documentation on ASP.NET at MSDN</a>.
</p>

</asp:Content>
