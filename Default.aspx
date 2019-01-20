<%@ Page Title="Expedia Search" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h2>
    My plan for a possible trip to Latin America in the summer of 2014:<br /><br />
</h2>    
<ol>        
    <li>BUD -&gt; JFK and MEX -&gt; BUD flight:<br /><br />
        Search for flights from BUD to JFK on <% Response.Write(defaultDate_BUDJFK); %>
         and from MEX to BUD on <%= defaultDate_MEXBUD %>
        on 
        <asp:HyperLink ID="UrlLink_BUDMEX_MEXBUD" runat="server" Target="_blank" ToolTip="Expedia Website">expedia.com
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

        <asp:Button id="chooseThisDateButton_BUDJFK_MEXBUD" runat="server" Enabled="false"
        Text="Choose this date" OnClick="ChooseThisDateButtonClicked_BUDJFK_MEXBUD" Visible="false" />
        <br /><br />
    </li>

    <li>JFK -&gt; CUN and CUN -&gt; MEX flight:<br /><br />
        Search for flights from JFK to CUN on <%= defaultDate_JFKCUN %>
        and from CUN to MEX on <% Response.Write(defaultDate_CUNMEX); %>
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
    
    <li>JFK -&gt; LIM, LIM -&gt; RIO, RIO -&gt; BUE, BUE -&gt; CUN, CUN -&gt; MEX flight:<br /><br />
        Search for the given flights on the following dates
        <% Response.Write(defaultDate_3rd_1); %>,
        <%= defaultDate_3rd_2 %>, <%= defaultDate_3rd_3 %>,
        <%= defaultDate_3rd_4 %> and <%= defaultDate_3rd_5 %>        
        on   
        <asp:HyperLink ID="UrlLink_3rd_point" runat="server" Target="_blank"        
        ToolTip="Expedia Website">expedia.com
        </asp:HyperLink> <br />
                
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
<!--        </asp:ScriptManager> -->              
        
        <asp:UpdateProgress ID="updateProgress" runat="server"
        AssociatedUpdatePanelID="updatePanel">
            <ProgressTemplate>
                <!--                
                <img id="loadingImage" alt="loading" src="Images/spinner.gif" />
                -->            
                <asp:Image ID="loadingImage" runat="server" AlternateText="loading..."
                ImageUrl="~/Images/loadinfo.net.gif" ImageAlign="AbsBottom" Height="18px" 
                    Width="18px" />                            
                &nbsp; <asp:Label id="loadingLabel" runat="server" Text="Loading..." 
                    Font-Size="Small" />
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdatePanel ID="updatePanel" runat="server">
            <ContentTemplate>
                Search for a different route:
                <asp:DropDownList ID="dropDown" runat="server" AutoPostBack="True" ForeColor="#666666" OnSelectedIndexChanged="DropDownChanged"
                Font-Names="'Helvetica Neue', 'Lucida Grande', 'Segoe UI', Arial, Helvetica, Verdana, sans-serif" >
                    <asp:ListItem Value="------------------------ Select a different route ----------------------------">------------------------ Select a different route ----------------------</asp:ListItem>
                    <asp:ListItem>JFK -&gt; RIO, RIO -&gt; LIM, LIM -&gt; BUE, BUE -&gt; CUN, CUN -&gt; MEX</asp:ListItem>
                    <asp:ListItem>JFK -&gt; BUE, BUE -&gt; RIO, RIO -&gt; LIM, LIM -&gt; CUN, CUN -&gt; MEX</asp:ListItem>
                    <asp:ListItem>JFK -&gt; LIM, LIM -&gt; BUE, BUE -&gt; RIO, RIO -&gt; CUN, CUN -&gt; MEX</asp:ListItem>
                    <asp:ListItem>JFK -&gt; RIO, RIO -&gt; BUE, BUE -&gt; LIM, LIM -&gt; CUN, CUN -&gt; MEX</asp:ListItem>
                    <asp:ListItem>JFK -&gt; BUE, BUE -&gt; LIM, LIM -&gt; RIO, RIO -&gt; CUN, CUN -&gt; MEX</asp:ListItem>
                </asp:DropDownList>        
                           
                <asp:HyperLink ID="dropDownLink" runat="server" Target="_blank"
                ToolTip="Expedia Website" Visible="False" >expedia.com
                </asp:HyperLink>          
            </ContentTemplate>
        </asp:UpdatePanel>        
        
    </li>
</ol>  

</asp:Content>
