using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private string selectText;
    private string defaultDate;
    private string dateInURL = "";
    private string newOutDate, newInDate;
    private string route;

    /// <summary>
    /// These fields are used in Default.aspx when writing the default dates to the page.
    /// </summary> 
    
    /* 1st search BUD->JFK and MEX->BUD */
    protected const string defaultDate_BUDJFK = "6/3/2014";
    protected const string defaultDate_MEXBUD  = "8/10/2014";
    
    /* 2nd search JFK->CUN and CUN->MEX */
    protected const string defaultDate_JFKCUN = "8/20/2014";
    protected const string defaultDate_CUNMEX  = "8/23/2014";

    /* 3rd search JFK->LIM, LIM->RIO, RIO->BUE, BUE->CUN, CUN->MEX */
    protected const string defaultDate_3rd_1 = "8/20/2014";
    protected const string defaultDate_3rd_2 = "8/22/2014";
    protected const string defaultDate_3rd_3 = "8/24/2014";
    protected const string defaultDate_3rd_4 = "8/26/2014";
    protected const string defaultDate_3rd_5 = "8/28/2014";
    
    private void MessageBox(string message)
    {
        Label label = new Label();
        label.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert('" + message + "')</script>";
        Page.Controls.Add(label);
    } // MessageBox

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString.ToString().Contains("r="))
        {
            route = Request.QueryString["r"];
            if (route.Equals("budjfk_mexbud"))
                Initialize_BUDJFK_MEXBUD(calendar_BUDJFK_MEXBUD, e);
            else if (route.Equals("jfkcun_cunmex"))
                Initialize_JFKCUN_CUNMEX(calendar_JFKCUN_CUNMEX, e);
        }

        UrlLink_BUDMEX_MEXBUD.NavigateUrl =
            CreateURL(new string[]{defaultDate_BUDJFK, defaultDate_MEXBUD, "", "", ""},
                      new string[]{"BUDJFK", "MEXBUD", "", "", ""});

        UrlLink_JFKCUN_CUNMEX.NavigateUrl =
            CreateURL(new string[]{defaultDate_JFKCUN, defaultDate_CUNMEX, "", "", ""},
                      new string[]{"JFKCUN", "CUNMEX", "", "", ""});

        UrlLink_3rd_point.NavigateUrl =
            CreateURL(new string[]{defaultDate_3rd_1, defaultDate_3rd_2, defaultDate_3rd_3, defaultDate_3rd_4, defaultDate_3rd_5},
            new string[]{"JFKLIM", "LIMRIO", "RIOBUE", "BUECUN", "CUNMEX"});        
    } // Page_Load    

    protected void Initialize_BUDJFK_MEXBUD(Object sender, EventArgs e)
    {
        string queryString = Request.QueryString.ToString();

        if (queryString.Equals(""))
        {
            selectText = "Select a new BUD -> JFK date: ";
            defaultDate = defaultDate_BUDJFK;
            SetCalendarAndLabelText(calendar_BUDJFK_MEXBUD, defaultDate, selectText);
        }            
        else if (queryString.Contains("o=") && !queryString.Contains("i="))
        {
            selectText = "Select a new MEX -> BUD date: ";
            defaultDate = defaultDate_MEXBUD;
            SetCalendarAndLabelText(calendar_BUDJFK_MEXBUD, defaultDate, selectText);
            SetVisibility(calendar_BUDJFK_MEXBUD);        
        }
        else if (queryString.Contains("i="))
        {            
            newOutDate = Request.QueryString["o"];
            newInDate = Request.QueryString["i"];
            
            string labelText = "Search for the same flight (BUD->JFK:MEX->BUD) » ";            
            string href = "<a href='" + CreateURL(new string[]{newOutDate, newInDate, "", "", ""}, new string[]{"BUDJFK", "MEXBUD", "", "", ""})
                + "' title='Expedia Website' target='_blank'>with your given dates</a>";
            searchWithNewDatesLabel_BUDJFK_MEXBUD.Text = labelText + href + "<br />";
            searchWithNewDatesLabel_BUDJFK_MEXBUD.Visible = true;
            searchWithNewDatesLabel_JFKCUN_CUNMEX.Visible = false;
        }
        else if (queryString.Contains("r="))
        {
            SetVisibility(calendar_BUDJFK_MEXBUD);
            selectText = "Select a new BUD -> JFK date: ";
            defaultDate = defaultDate_BUDJFK;
            SetCalendarAndLabelText(calendar_BUDJFK_MEXBUD, defaultDate, selectText);            
        }
    } // Initialize_BUDJFK_MEXBUD
    protected void Initialize_JFKCUN_CUNMEX(Object sender, EventArgs e)
    {
        string queryString = Request.QueryString.ToString();

        if (queryString.Equals(""))
        {
            selectText = "Select a new JFK -> CUN date: ";
            defaultDate = defaultDate_JFKCUN;
            SetCalendarAndLabelText(calendar_JFKCUN_CUNMEX, defaultDate, selectText);
        }
        else if (queryString.Contains("o=") && !queryString.Contains("i="))
        {
            selectText = "Select a new CUN -> MEX date: ";
            defaultDate = defaultDate_CUNMEX;
            SetCalendarAndLabelText(calendar_JFKCUN_CUNMEX, defaultDate, selectText);
            SetVisibility(calendar_JFKCUN_CUNMEX);
        }
        else if (queryString.Contains("i="))
        {
            newOutDate = Request.QueryString["o"];
            newInDate = Request.QueryString["i"];

            string labelText = "Search for the same flight (JFK->CUN:CUN->MEX) » ";            
            string href = "<a href='" + CreateURL(new string[] { newOutDate, newInDate, "", "", "" }, new string[] { "JFKCUN", "CUNMEX", "", "", "" })
                + "' title='Expedia Website' target='_blank'>with your given dates</a>";
            searchWithNewDatesLabel_JFKCUN_CUNMEX.Text = labelText + href + "<br />";
            searchWithNewDatesLabel_JFKCUN_CUNMEX.Visible = true;
            searchWithNewDatesLabel_BUDJFK_MEXBUD.Visible = false;
        }
        else if (queryString.Contains("r=")) // 
        {
            SetVisibility(calendar_JFKCUN_CUNMEX);
            selectText = "Select a new JFK -> CUN date: ";
            defaultDate = defaultDate_JFKCUN;
            SetCalendarAndLabelText(calendar_JFKCUN_CUNMEX, defaultDate, selectText);
        }
    } // Initialize_JFKCUN_CUNMEX

    private void SetCalendarAndLabelText(Calendar calendar, string defaultDate, string selectText)
    {
        if (calendar.Equals(calendar_BUDJFK_MEXBUD))
        {
            calendar_BUDJFK_MEXBUD.SelectedDate = DateTime.Parse(defaultDate); // sets the date
            calendar_BUDJFK_MEXBUD.VisibleDate = calendar_BUDJFK_MEXBUD.SelectedDate;       // shows the set date
            selectInOrOutboundLabel_BUDJFK_MEXBUD.Text = "<b>" + selectText + "</b>" + "<b>";
        }
        else if (calendar.Equals(calendar_JFKCUN_CUNMEX))
        {
            calendar_JFKCUN_CUNMEX.SelectedDate = DateTime.Parse(defaultDate);
            calendar_JFKCUN_CUNMEX.VisibleDate = calendar_JFKCUN_CUNMEX.SelectedDate;
            selectInOrOutboundLabel_JFKCUN_CUNMEX.Text = "<b>" + selectText + "</b>" + "<b>";
        }
    } // SetCalendarAndLabelText

    protected void SetNewDate(Object sender, EventArgs e)
    {
        Calendar calendar = sender.Equals(calendar_BUDJFK_MEXBUD) ? calendar_BUDJFK_MEXBUD : calendar_JFKCUN_CUNMEX;
        DateTime newDate = calendar.SelectedDate.AddHours(4); // dateMin is ok on localhost too
        DateTime dateMin = DateTime.Now.AddHours(15);
        DateTime dateMax = DateTime.Now.AddMonths(11).AddDays(-5);

        if (newDate < dateMin)
        {
            MessageBox("Error:\\n" +
                "Expedia requires " + dateMin.ToShortDateString() + " or later!");
        }
        else if (newDate > dateMax)
        {
            MessageBox("Error:\\n" +
                "Expedia requires " + dateMax.ToShortDateString() + " or earlier!");
        }
        else
        {
            if (calendar.Equals(calendar_BUDJFK_MEXBUD))
            {
                newDateLabel_JFKCUN_CUNMEX.Visible = false;
                helpsToMakeDateBold_JFKCUN_CUNMEX.Visible = false;

                newDateLabel_BUDJFK_MEXBUD.Text = newDate.ToShortDateString();
                newDateLabel_BUDJFK_MEXBUD.Visible = true;                
                chooseThisDateButton_BUDJFK_MEXBUD.Enabled = true;
            }
            else if (calendar.Equals(calendar_JFKCUN_CUNMEX))
            {
                newDateLabel_BUDJFK_MEXBUD.Visible = false;
                helpsToMakeDateBold_BUDJFK_MEXBUD.Visible = false;

                newDateLabel_JFKCUN_CUNMEX.Text = newDate.ToShortDateString();
                newDateLabel_JFKCUN_CUNMEX.Visible = true;
                helpsToMakeDateBold_JFKCUN_CUNMEX.Visible = true;
                chooseThisDateButton_JFKCUN_CUNMEX.Enabled = true;
            }
        }
    } // SetNewDate
        
    protected void ChooseNewDatesButtonClicked_BUDJFK_MEXBUD(Object sender, EventArgs e)
    {
        string queryString = Request.QueryString.ToString();
        if (queryString.Contains("r=jfkcun_cunmex") || queryString.Contains("i="))        
            Response.Redirect("Default.aspx?r=budjfk_mexbud");
        
        SetVisibility(calendar_BUDJFK_MEXBUD); // else
    } // ChooseNewDatesButtonClicked_BUDJFK_MEXBUD
    protected void ChooseNewDatesButtonClicked_JFKCUN_CUNMEX(Object sender, EventArgs e)
    {
        string queryString = Request.QueryString.ToString();
        if (queryString.Contains("r=budjfk_mexbud") || queryString.Contains("i="))
            Response.Redirect("Default.aspx?r=jfkcun_cunmex");

        SetVisibility(calendar_JFKCUN_CUNMEX); // else
    } // ChooseNewDatesButtonClicked_JFKCUN_CUNMEX

    protected void SetVisibility(Calendar calendar)
    {
        if (calendar.Equals(calendar_BUDJFK_MEXBUD))
        {
            chooseNewDatesButton_JFKCUN_CUNMEX.Visible = true;
            selectInOrOutboundLabel_JFKCUN_CUNMEX.Visible = false;
            calendar_JFKCUN_CUNMEX.Visible = false;
            chooseThisDateButton_JFKCUN_CUNMEX.Visible = false;
            helpsToMakeDateBold_JFKCUN_CUNMEX.Visible = false;

            chooseNewDatesButton_BUDJFK_MEXBUD.Visible = false;
            selectInOrOutboundLabel_BUDJFK_MEXBUD.Visible = true;
            calendar_BUDJFK_MEXBUD.Visible = true;
            chooseThisDateButton_BUDJFK_MEXBUD.Visible = true;
            helpsToMakeDateBold_BUDJFK_MEXBUD.Visible = true;
        }
        else if (calendar.Equals(calendar_JFKCUN_CUNMEX))
        {
            chooseNewDatesButton_BUDJFK_MEXBUD.Visible = true;
            selectInOrOutboundLabel_BUDJFK_MEXBUD.Visible = false;
            calendar_BUDJFK_MEXBUD.Visible = false;
            chooseThisDateButton_BUDJFK_MEXBUD.Visible = false;
            helpsToMakeDateBold_BUDJFK_MEXBUD.Visible = false;

            chooseNewDatesButton_JFKCUN_CUNMEX.Visible = false;
            selectInOrOutboundLabel_JFKCUN_CUNMEX.Visible = true;
            calendar_JFKCUN_CUNMEX.Visible = true;
            chooseThisDateButton_JFKCUN_CUNMEX.Visible = true;
            helpsToMakeDateBold_JFKCUN_CUNMEX.Visible = true;
        }
    } // SetVisibility

    protected void ChooseThisDateButtonClicked_BUDJFK_MEXBUD(Object sender, EventArgs e)
    {        
        string rawUrl = Request.RawUrl;
        string date = newDateLabel_BUDJFK_MEXBUD.Text.ToString();            

        if (!rawUrl.Contains("o=")) // Default.aspx OR Default.aspx?r=......
        {
            if (rawUrl.Contains("r=")) // Default.aspx?r=....     ---> new search
            {
                dateInURL = "o=" + ConvertDateIntoExpediaFormat(date);                                        
                Response.Redirect(rawUrl + "&" + dateInURL); // refreshes the page            
            }
            else if (dateInURL.Equals("")) // Default.aspx      ---> 1st page load
            {
                dateInURL = "r=budjfk_mexbud" + "&" + "o=" + ConvertDateIntoExpediaFormat(date);
                Response.Redirect(rawUrl + "?" + dateInURL); // refreshes the page            
            }
        }
        else if (rawUrl.Contains("o=") && !rawUrl.Contains("i="))
        {
            dateInURL = "i=" + ConvertDateIntoExpediaFormat(date);                        
            Response.Redirect(rawUrl + "&" + dateInURL); // refreshes the page
        }
    } // ChooseThisDateButtonClicked_BUDJFK_MEXBUD
    protected void ChooseThisDateButtonClicked_JFKCUN_CUNMEX(Object sender, EventArgs e)
    {
        string rawUrl = Request.RawUrl;
        string date = newDateLabel_JFKCUN_CUNMEX.Text.ToString();

        if (!rawUrl.Contains("o=")) // Default.aspx OR Default.aspx?r=......
        {
            if (rawUrl.Contains("r=")) // Default.aspx?r=....     ---> new search
            {
                dateInURL = "o=" + ConvertDateIntoExpediaFormat(date);                                        
                Response.Redirect(rawUrl + "&" + dateInURL); // refreshes the page            
            }
            else if (dateInURL.Equals("")) // Default.aspx      ---> 1st page load
            {
                dateInURL = "r=jfkcun_cunmex" + "&" + "o=" + ConvertDateIntoExpediaFormat(date);                
                Response.Redirect(rawUrl + "?" + dateInURL); // refreshes the page            
            }
        }
        else if (rawUrl.Contains("o=") && !rawUrl.Contains("i="))
        {
            dateInURL = "i=" + ConvertDateIntoExpediaFormat(date);            
            Response.Redirect(rawUrl + "&" + dateInURL); // refreshes the page
        }
    } // ChooseThisDateButtonClicked_JFKCUN_CUNMEX

    protected void DropDownChanged(object sender, EventArgs e)
    {   
        switch (dropDown.SelectedIndex)
        {            
            // ---------------- Select a different route ----------------
            case 0: dropDownLink.Visible = false;
                    break;
            // JFK -> RIO, RIO -> LIM, LIM -> BUE, BUE -> CUN, CUN -> MEX
            case 1: System.Threading.Thread.Sleep(3000);
                    dropDownLink.NavigateUrl =
                    CreateURL(new string[]{ defaultDate_3rd_1, defaultDate_3rd_2, defaultDate_3rd_3, defaultDate_3rd_4, defaultDate_3rd_5},
                              new string[]{ "JFKRIO", "RIOLIM", "LIMBUE", "BUECUN", "CUNMEX"});
                    dropDownLink.Visible = true;
                    break;
            // JFK -> BUE, BUE -> RIO, RIO -> LIM, LIM -> CUN, CUN -> MEX
            case 2: System.Threading.Thread.Sleep(3000);
                    dropDownLink.NavigateUrl =
                    CreateURL(new string[] { defaultDate_3rd_1, defaultDate_3rd_2, defaultDate_3rd_3, defaultDate_3rd_4, defaultDate_3rd_5 },
                              new string[] { "JFKBUE", "BUERIO", "RIOLIM", "LIMCUN", "CUNMEX" });
                    dropDownLink.Visible = true;
                    break;
            // JFK -> LIM, LIM -> BUE, BUE -> RIO, RIO -> CUN, CUN -> MEX
            case 3: System.Threading.Thread.Sleep(3000);
                    dropDownLink.NavigateUrl =
                    CreateURL(new string[] { defaultDate_3rd_1, defaultDate_3rd_2, defaultDate_3rd_3, defaultDate_3rd_4, defaultDate_3rd_5 },
                              new string[] { "JFKLIM", "LIMBUE", "BUERIO", "RIOCUN", "CUNMEX" });
                    dropDownLink.Visible = true;
                    break;
            // JFK -> RIO, RIO -> BUE, BUE -> LIM, LIM -> CUN, CUN -> MEX
            case 4: System.Threading.Thread.Sleep(3000);
                    dropDownLink.NavigateUrl =
                    CreateURL(new string[] { defaultDate_3rd_1, defaultDate_3rd_2, defaultDate_3rd_3, defaultDate_3rd_4, defaultDate_3rd_5 },
                              new string[] { "JFKRIO", "RIOBUE", "BUELIM", "LIMCUN", "CUNMEX" });
                    dropDownLink.Visible = true;
                    break;
            // JFK -> BUE, BUE -> LIM, LIM -> RIO, RIO -> CUN, CUN -> MEX
            case 5: System.Threading.Thread.Sleep(3000);
                    dropDownLink.NavigateUrl =
                    CreateURL(new string[] { defaultDate_3rd_1, defaultDate_3rd_2, defaultDate_3rd_3, defaultDate_3rd_4, defaultDate_3rd_5 },
                              new string[] { "JFKBUE", "BUELIM", "LIMRIO", "RIOCUN", "CUNMEX" });
                    dropDownLink.Visible = true;
                    break;            
        } // switch           
    } // DropDownChanged
       
    private string CreateURL(string[] dates, string[] routes)
    {
        // ex.: routes[0] = "BUDJFK", routes[1] = "MEXBUD", routes[2] = "";
        bool is3rdPoint = !routes[2].Equals(string.Empty) ? true : false;

        string depLoc1; // 1st departure location
        string arrLoc1; // 1st arrival location
        string depLoc2; // 2nd departure location
        string arrLoc2; // 2nd arrival location
        string depLoc3, depLoc4, depLoc5, arrLoc3, arrLoc4, arrLoc5;

        depLoc1 = routes[0].Substring(0, 3);
        arrLoc1 = routes[0].Substring(3, 3);
        depLoc2 = routes[1].Substring(0, 3);
        arrLoc2 = routes[1].Substring(3, 3);
        
        StringBuilder sb = new StringBuilder(); // using System.Text;
        sb.Append("http://www.expedia.com/Flight-SearchResults?action=FlightSearchResults%40searchFlights&inpPackageType=FLIGHT_ONLY&inpFlightRouteType=3");
        sb.Append("&inpDepartureLocations=" + depLoc1 + "&inpDepartureLocations=" + depLoc2);
        sb.Append("&inpDepartureLocationCodes=" + depLoc1 + "&inpDepartureLocationCodes=" + depLoc2);
        sb.Append("&inpArrivalLocations=" + arrLoc1 + "&inpArrivalLocations=" + arrLoc2);
        sb.Append("&inpArrivalLocationCodes=" + arrLoc1 + "&inpArrivalLocationCodes=" + arrLoc2);
        sb.Append("&inpDepartureDates=" + dates[0]);
        sb.Append("&inpDepartureDates=" + dates[1]);
        if (is3rdPoint)
        {
            depLoc3 = routes[2].Substring(0, 3); arrLoc3 = routes[2].Substring(3, 3);
            depLoc4 = routes[3].Substring(0, 3); arrLoc4 = routes[3].Substring(3, 3);
            depLoc5 = routes[4].Substring(0, 3); arrLoc5 = routes[4].Substring(3, 3);
            sb.Append("&inpDepartureLocations=" + depLoc3);
            sb.Append("&inpDepartureLocations=" + depLoc4);
            sb.Append("&inpDepartureLocations=" + depLoc5);
            sb.Append("&inpDepartureLocationCodes=" + depLoc3);
            sb.Append("&inpDepartureLocationCodes=" + depLoc4);
            sb.Append("&inpDepartureLocationCodes=" + depLoc5);
            sb.Append("&inpArrivalLocations=" + arrLoc3);
            sb.Append("&inpArrivalLocations=" + arrLoc4);
            sb.Append("&inpArrivalLocations=" + arrLoc5);
            sb.Append("&inpArrivalLocationCodes=" + arrLoc3);
            sb.Append("&inpArrivalLocationCodes=" + arrLoc4);
            sb.Append("&inpArrivalLocationCodes=" + arrLoc5);
            sb.Append("&inpDepartureDates=" + dates[2]);
            sb.Append("&inpDepartureDates=" + dates[3]);
            sb.Append("&inpDepartureDates=" + dates[4]);
        }
        sb.Append("&inpDepartureTimes=362&inpDepartureTimes=362&inpHotelRoomCount=1&inpChildCounts=0&inpAdultCounts=1&inpSeniorCounts=0&inpInfants=2&inpFlightClass=3&inpRefundableFlightsOnly=OFF&inpSortType=0&inpFlightAirlinePreference=&inpIsNonstopOnly=N&inttkn=F5CsOgSVHJWClUEj");        
        
        return sb.ToString();
    } // CreateURL  

protected string ConvertDateIntoExpediaFormat(string date)
{
    string result = "";
    string[] parts = new string[] { "" };
    char[] delimiter = new char[] { '/' }; // Split() needs char[] instead of char
        
    if (!date.Equals(""))
    {
        if (date.Contains("/")) // somee.com: 6/3/2014 -> 6%2f3%2f2014
        {
            parts = date.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {                    
                if (part.Length == 4) // ex: 2014 in 6/3/2014
                    result += part;
                else
                    result += part + "%2f"; // ex: 8 or 10 in 8/10/2014
            }
        }
        else // localhost: 2014. 06. 03. -> 06%2f03%2f2014
        {
            result = date.Substring( 6, 2) + "%2f"
                   + date.Substring(10, 2) + "%2f"
                   + date.Substring( 0, 4);
        }
    }
    return result;
} // ConvertDateIntoExpediaFormat

// JFK -> LIM, LIM -> BUE, BUE -> RIO, RIO -> CUN, CUN -> MEX: $2739
// JFK -> LIM, LIM -> RIO, RIO -> BUE, BUE -> CUN, CUN -> MEX: $2175
// JFK -> RIO, RIO -> BUE, BUE -> LIM, LIM -> CUN, CUN -> MEX: $3331
// JFK -> RIO, RIO -> LIM, LIM -> BUE, BUE -> CUN, CUN -> MEX: $2359
// JFK -> BUE, BUE -> LIM, LIM -> RIO, RIO -> CUN, CUN -> MEX: $3637
// JFK -> BUE, BUE -> RIO, RIO -> LIM, LIM -> CUN, CUN -> MEX: $2540

/*2013.10.4:
Ár szerinti rendezés:

1, JFK -> LIM, LIM -> RIO, RIO -> BUE, BUE -> CUN, CUN -> MEX: $2175
2, JFK -> RIO, RIO -> LIM, LIM -> BUE, BUE -> CUN, CUN -> MEX: $2359
3, JFK -> BUE, BUE -> RIO, RIO -> LIM, LIM -> CUN, CUN -> MEX: $2540
4, JFK -> LIM, LIM -> BUE, BUE -> RIO, RIO -> CUN, CUN -> MEX: $2739
5, JFK -> RIO, RIO -> BUE, BUE -> LIM, LIM -> CUN, CUN -> MEX: $3331
6, JFK -> BUE, BUE -> LIM, LIM -> RIO, RIO -> CUN, CUN -> MEX: $3637*/
    
} // _Default class       


                                /* UNUSED METHOD */

/*
     private string GetParameterName(System.Reflection.MethodInfo method, int index)
    {
        string result = string.Empty;

        if (method != null && method.GetParameters().Length > index)
            result = method.GetParameters()[index].Name;

        return result;
    } // GetParameterName 
 */