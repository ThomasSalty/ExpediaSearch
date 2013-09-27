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
            SetVisibility();            
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
    } // Initialize
    
    void SetCalendarAndLabelText(string defaultDate, string selectText)
    {
        calendar1.SelectedDate = DateTime.Parse(defaultDate); // sets the date
        calendar1.VisibleDate = calendar1.SelectedDate;       // shows the set date
        selectInOrOutboundLabel.Text = "<b>" + selectText + "</b>" + "<b>";
    }
    void SetNewDate(Object sender, EventArgs e)
    {
        DateTime newDate = calendar1.SelectedDate;        
        newDateLabel.Text = newDate.ToShortDateString();
        ValidateNewDate(newDateLabel.Text);
        newDateLabel.Visible = true;
        helpsToMakeDateBold.Visible = true;
        chooseThisDateButton.Enabled = true;  
    }
    void ValidateNewDate(string newDate)
    {
        
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
    } // ChooseThisDateButtonClicked
        
    string ConvertDateIntoExpediaFormat(string date) 
    {            
        string result = "";
        string[] parts = new string[] {""};
        char[] delimiter = new char[] { '/' }; // Split() needs char[] instead of char
        if (date != "")
        {
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
        }
        return result;
    } // ConvertDateIntoExpediaFormat
        
    // TODO
    // 0, githubon merge-elni a developer a masterral
    // 1, obout.com Calendar controllal min es max date
    // 2, Elore haladás érzékeltetése >> -alakkal és/vagy valahogy
    // 3, About-ba: wiki IATA, wiki Latin-America