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
        Search for flights from BUD to JFK on <% Response.Write(defaultOutDate_BUDJFK); %>
         and from MEX to BUD on <% Response.Write(defaultInDate_MEXBUD); %>
        on 
        <asp:HyperLink ID="defaultUrlLink" runat="server" Target="_blank" ToolTip="Expedia Website">expedia.com
        </asp:HyperLink> <br />
        <asp:Label ID="searchWithNewDatesLabel_BUDJFK_MEXBUD" runat="server" Text="" Visible="false" />
            

        <asp:Button id="chooseNewDatesButton_BUDJFK_MEXBUD" runat="server"
        Text="Choose different dates" OnClick="ChooseNewDatesButtonClicked_BUDJFK_MEXBUD" />
        <br />
        <asp:Label id="selectInOrOutboundLabel_BUDJFK_MEXBUD" runat="server" Visible="false" />
        <asp:Label id="newDateLabel_BUDJFK_MEXBUD" runat="server" Visible="false" />        
        <asp:Label ID="helpsToMakeDateBold_BUDJFK_MEXBUD" runat="server" Visible = "false" Text = "</b>"/>
        
        <asp:Calendar ID="calendar_BUDJFK_MEXBUD" runat="server" Visible="false"
        FirstDayOfWeek="Monday"
        Font-Bold="false"              
        SelectionMode="Day" 
        ShowGridLines="False"        
        OnInit="Initialize_BUDJFK_MEXBUD"
        OnSelectionChanged="SetNewDate">
        <SelectedDayStyle BackColor="#4b6c9e" ForeColor="#f9f9f9"> </SelectedDayStyle>
        </asp:Calendar>            

        <asp:Button id="chooseThisDateButton_BUDJFK_MEXBUD" runat="server" Enabled="false" Text="Choose this date" OnClick="ChooseThisDateButtonClicked_BUDJFK_MEXBUD" Visible="false" />
        <br /><br />
    </li>

    <li>JFK -> CUN and CUN -> MEX flight:<br /><br />
        Search for flights from JFK to CUN on <% Response.Write(defaultOutDate_JFKCUN); %>
        and from CUN to MEX on <% Response.Write(defaultInDate_CUNMEX); %>
        on
        <asp:HyperLink ID="UrlLink_JFKCUN_CUNMEX" runat="server" Target="_blank"        
        ToolTip="Expedia Website">expedia.com
        </asp:HyperLink> <br /> 
        <asp:Label ID="searchWithNewDatesLabel_JFKCUN_CUNMEX" runat="server" Text="" Visible="false" />
            

        <asp:Button id="chooseNewDatesButton_JFKCUN_CUNMEX" runat="server"
        Text="Choose different dates" OnClick="ChooseNewDatesButtonClicked_JFKCUN_CUNMEX" />
        <br />
        <asp:Label id="selectInOrOutboundLabel_JFKCUN_CUNMEX" runat="server" Visible="false" />
        <asp:Label id="newDateLabel_JFKCUN_CUNMEX" runat="server" Visible="false" />   
        <asp:Label ID="helpsToMakeDateBold_JFKCUN_CUNMEX" runat="server" Visible = "false" Text = "</b>"/>         

        <asp:Calendar ID="calendar_JFKCUN_CUNMEX" runat="server" Visible="false"
        FirstDayOfWeek="Monday"
        Font-Bold="false"              
        SelectionMode="Day" 
        ShowGridLines="False"        
        OnInit="Initialize_JFKCUN_CUNMEX"
        OnSelectionChanged="SetNewDate">
        <SelectedDayStyle BackColor="#4b6c9e" ForeColor="#f9f9f9"> </SelectedDayStyle>
        </asp:Calendar>            

        <asp:Button id="chooseThisDateButton_JFKCUN_CUNMEX" runat="server" Enabled="false"
        Text="Choose this date" OnClick="ChooseThisDateButtonClicked_JFKCUN_CUNMEX" Visible="false" />
        <br /><br />
    </li>        
</ol>  

</asp:Content>
