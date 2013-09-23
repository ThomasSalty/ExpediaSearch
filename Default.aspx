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
            Search for flights from BUD to JFK on 3rd June 2014 and from MEX to BUD on 10th August
            on 
            <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" ToolTip="Expedia Website"
            NavigateUrl="http://www.expedia.com/Flight-SearchResults?action=FlightSearchResults%40searchFlights&inpPackageType=FLIGHT_ONLY&inpFlightRouteType=3&inpDepartureLocations=BUD&inpDepartureLocations=MEX&inpDepartureLocationCodes=BUD&inpDepartureLocationCodes=MEX&inpArrivalLocations=JFK&inpArrivalLocations=BUD&inpArrivalLocationCodes=JFK&inpArrivalLocationCodes=BUD&inpDepartureDates=06%2F03%2F2014&inpDepartureDates=08%2F10%2F2014&inpDepartureTimes=362&inpDepartureTimes=362&inpHotelRoomCount=1&inpChildCounts=0&inpAdultCounts=1&inpSeniorCounts=0&inpInfants=2&inpFlightClass=3&inpRefundableFlightsOnly=OFF&inpSortType=0&inpFlightAirlinePreference=&inpIsNonstopOnly=N&inttkn=F5CsOgSVHJWClUEj">expedia.com
            </asp:HyperLink> <br />

            <asp:Label ID="searchWithNewDatesLabel" runat="server" Text="" Visible="false" />
            

            <asp:Button id="chooseNewDatesButton" runat="server" Text="Choose different dates" OnClick="ChooseNewDatesButtonClicked" />
            <br />
            <asp:Label id="selectInOrOutboundLabel" runat="server" Visible="false" />
            <asp:Label id="newDateLabel" runat="server" Visible="false" />
            <asp:Label ID="helpsToMakeDateBold" runat="server" Visible = "false" Text = "</b>"/>
            
            <asp:Calendar ID="calendar1" runat="server" Visible="false"
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

    <script language="C#" runat="server">
        
        int expediaDateLength = 14; // ex.: 06%2F03%2F2014
        string selectText;
        string defaultDate = defaultOutDate;
        string dateInURL = "";
        string newOutDate, newInDate;
        const string defaultOutDate = "6/3/2014", defaultInDate = "8/10/2014";              
        
        void Initialize(Object sender, EventArgs e)
        {            
            string queryString = Request.QueryString.ToString();
            
            if (queryString.Equals(""))
            {
                selectText = "Select a new BUD -> JFK date: ";
                defaultDate = defaultOutDate;
                SetCalendarAndLabelText(defaultDate, selectText);
            }
            else if (queryString.Contains("o=") && !queryString.Contains("i="))
            {
                selectText = "Select a new MEX -> BUD date: ";
                defaultDate = defaultInDate;
                SetCalendarAndLabelText(defaultDate, selectText);
                chooseNewDatesButton.Visible = false;
                selectInOrOutboundLabel.Visible = true;
                calendar1.Visible = true;
                chooseThisDateButton.Visible = true;
            }
            else if (queryString.Contains("i="))
            {
                
                newOutDate = queryString.Substring(queryString.IndexOf("o=")+2, expediaDateLength);
                newInDate  = queryString.Substring(queryString.IndexOf("i=")+2, expediaDateLength);

                string labelText = "Search for the same flight (BUD->JFK:MEX->BUD) » ";
                string href = "<a href='http://www.expedia.com/Flight-SearchResults?action=FlightSearchResults%40searchFlights&inpPackageType=FLIGHT_ONLY&inpFlightRouteType=3&inpDepartureLocations=BUD&inpDepartureLocations=MEX&inpDepartureLocationCodes=BUD&inpDepartureLocationCodes=MEX&inpArrivalLocations=JFK&inpArrivalLocations=BUD&inpArrivalLocationCodes=JFK&inpArrivalLocationCodes=BUD&inpDepartureDates=" + newOutDate + "&inpDepartureDates=" + newInDate + "&inpDepartureTimes=362&inpDepartureTimes=362&inpHotelRoomCount=1&inpChildCounts=0&inpAdultCounts=1&inpSeniorCounts=0&inpInfants=2&inpFlightClass=3&inpRefundableFlightsOnly=OFF&inpSortType=0&inpFlightAirlinePreference=&inpIsNonstopOnly=N&inttkn=F5CsOgSVHJWClUEj' "
                    + "title='Expedia Website' target='_blank'>with your given dates</a>";                
                searchWithNewDatesLabel.Text = labelText + href + "<br />";
                searchWithNewDatesLabel.Visible = true;
            }
            else if (queryString.Equals("newSearch"))
            {
                SetVisibility();
                selectText = "Select a new BUD -> JFK date: ";
                defaultDate = defaultOutDate;
                SetCalendarAndLabelText(defaultDate, selectText);
            }
        }
        void SetCalendarAndLabelText(string defaultDate, string selectText)
        {
            calendar1.SelectedDate = DateTime.Parse(defaultDate);
            calendar1.VisibleDate = calendar1.SelectedDate;            
            selectInOrOutboundLabel.Text = "<b>" + selectText + "</b>" + "<b>";
        }
        void SetNewDate(Object sender, EventArgs e)
        {
            DateTime newDate = calendar1.SelectedDate;
            newDateLabel.Text = newDate.ToShortDateString();
            newDateLabel.Visible = true;
            helpsToMakeDateBold.Visible = true;
            chooseThisDateButton.Enabled = true;  
        }
        void ChooseNewDatesButtonClicked(Object sender, EventArgs e)
        {
            if (Request.QueryString.ToString().Contains("i="))
                Response.Redirect("Default.aspx?newSearch");
            SetVisibility();           
        }
        void SetVisibility()
        {
            chooseNewDatesButton.Visible = false;
            selectInOrOutboundLabel.Visible = true;
            calendar1.Visible = true;
            chooseThisDateButton.Visible = true; 
        }
        void ChooseThisDateButtonClicked (Object sender, EventArgs e)
        {            
            string rawUrl = Request.RawUrl;
            if (!rawUrl.Contains("o="))
            {
                dateInURL = "o=" + ConvertDateIntoExpediaFormat(newDateLabel.Text.ToString());                
                Response.Redirect(rawUrl + "?" + dateInURL); // refreshes the page            
            }
            else if (rawUrl.Contains("o=") && !rawUrl.Contains("i="))
            {
                dateInURL += "i=" + ConvertDateIntoExpediaFormat(newDateLabel.Text.ToString());                
                Response.Redirect(rawUrl + "&" + dateInURL); // refreshes the page
            }            
        }
        
        string ConvertDateIntoExpediaFormat(string date) 
        {            
            string result = "";
            string[] parts = new string[] {""};
            char[] delimiter = new char[] { '/' }; // Split() needs char[] instead of char
            if (date != "")
                if (date.Contains("/")) // somee.com: 6/3/2014 -> 06%2F03%2F2014
                {
                    parts = date.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string part in parts)
                    {
                        if (part.Length == 4) // ex: 2014
                            result += part;
                        else if (part.Length == 1) // ex: 6 or 3
                            result += "0" + part + "%2F";
                        else result += part + "%2F";
                    }
                }
                else // localhost: 2014. 06. 03. -> 06%2F03%2F2014
                {
                    result = date.Substring( 6, 2) + "%2F"
                           + date.Substring(10, 2) + "%2F"
                           + date.Substring( 0, 4);
                }
            return result;
        }
        
        // TODO
        // 1, Dim dtToday As DateTime = Date.Today; dtToday = dtToday.AddMonths(-2);
        // 2, Előre haladás érzékeltetése >> -alakkal és/vagy valahogy
        // 3, About-ba: wiki IATA, wiki Latin-America
        
    </script>

    <hr /><br />
    
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs" >documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
