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
    private string defaultURL;
    private string route;

    /// <summary>
    /// These fields are used in Default.aspx when writing the default dates to the page.
    /// </summary>    
    protected const string defaultOutDate_BUDJFK = "6/3/2014";
    protected const string defaultInDate_MEXBUD  = "8/10/2014";
    protected const string defaultOutDate_JFKCUN = "8/20/2014";
    protected const string defaultInDate_CUNMEX  = "8/23/2014";

    /// <summary>
    /// Constructor
    /// </summary>
    public _Default()
    {
        defaultDate = defaultOutDate_BUDJFK;
        defaultURL = createURL(defaultOutDate_BUDJFK, defaultInDate_MEXBUD, "BUDJFK", "MEXBUD");
    }

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
            else if (route.Equals("jfk_cunmex"))
                Initialize_JFKCUN_CUNMEX(calendar_JFKCUN_CUNMEX, e);
        }

        defaultUrlLink.NavigateUrl = defaultURL;
        UrlLink_JFKCUN_CUNMEX.NavigateUrl = createURL(defaultOutDate_JFKCUN, defaultInDate_CUNMEX, "JFKCUN", "CUNMEX");
    } // Page_Load    

    protected void Initialize_BUDJFK_MEXBUD(Object sender, EventArgs e)
    {
        string queryString = Request.QueryString.ToString();

        if (queryString.Equals(""))
        {
            selectText = "Select a new BUD -> JFK date: ";
            defaultDate = defaultOutDate_BUDJFK;
            SetCalendarAndLabelText(calendar_BUDJFK_MEXBUD, defaultDate, selectText);
        }            
        else if (queryString.Contains("o=") && !queryString.Contains("i="))
        {
            selectText = "Select a new MEX -> BUD date: ";
            defaultDate = defaultInDate_MEXBUD;
            SetCalendarAndLabelText(calendar_BUDJFK_MEXBUD, defaultDate, selectText);
            SetVisibility(calendar_BUDJFK_MEXBUD);        
        }
        else if (queryString.Contains("i="))
        {            
            newOutDate = Request.QueryString["o"];
            newInDate = Request.QueryString["i"];
            
            string labelText = "Search for the same flight (BUD->JFK:MEX->BUD) » ";
            string href = "<a href='http://www.expedia.com/Flight-SearchResults?action=FlightSearchResults%40searchFlights&inpPackageType=FLIGHT_ONLY&inpFlightRouteType=3&inpDepartureLocations=BUD&inpDepartureLocations=MEX&inpDepartureLocationCodes=BUD&inpDepartureLocationCodes=MEX&inpArrivalLocations=JFK&inpArrivalLocations=BUD&inpArrivalLocationCodes=JFK&inpArrivalLocationCodes=BUD&inpDepartureDates=" + newOutDate + "&inpDepartureDates=" + newInDate + "&inpDepartureTimes=362&inpDepartureTimes=362&inpHotelRoomCount=1&inpChildCounts=0&inpAdultCounts=1&inpSeniorCounts=0&inpInfants=2&inpFlightClass=3&inpRefundableFlightsOnly=OFF&inpSortType=0&inpFlightAirlinePreference=&inpIsNonstopOnly=N&inttkn=F5CsOgSVHJWClUEj' "
                        + "title='Expedia Website' target='_blank'>with your given dates</a>";
            searchWithNewDatesLabel_BUDJFK_MEXBUD.Text = labelText + href + "<br />";
            searchWithNewDatesLabel_BUDJFK_MEXBUD.Visible = true;
            searchWithNewDatesLabel_JFKCUN_CUNMEX.Visible = false;
        }
        else if (queryString.Contains("r="))
        {
            SetVisibility(calendar_BUDJFK_MEXBUD);
            selectText = "Select a new BUD -> JFK date: ";
            defaultDate = defaultOutDate_BUDJFK;
            SetCalendarAndLabelText(calendar_BUDJFK_MEXBUD, defaultDate, selectText);            
        }
    } // Initialize_BUDJFK_MEXBUD
    protected void Initialize_JFKCUN_CUNMEX(Object sender, EventArgs e)
    {
        string queryString = Request.QueryString.ToString();

        if (queryString.Equals(""))
        {
            selectText = "Select a new JFK -> CUN date: ";
            defaultDate = defaultOutDate_JFKCUN;
            SetCalendarAndLabelText(calendar_JFKCUN_CUNMEX, defaultDate, selectText);
        }
        else if (queryString.Contains("o=") && !queryString.Contains("i="))
        {
            selectText = "Select a new CUN -> MEX date: ";
            defaultDate = defaultInDate_CUNMEX;
            SetCalendarAndLabelText(calendar_JFKCUN_CUNMEX, defaultDate, selectText);
            SetVisibility(calendar_JFKCUN_CUNMEX);
        }
        else if (queryString.Contains("i="))
        {
            newOutDate = Request.QueryString["o"];
            newInDate = Request.QueryString["i"];

            string labelText = "Search for the same flight (JFK->CUN:CUN->MEX) » ";
            string href = "<a href='http://www.expedia.com/Flight-SearchResults?action=FlightSearchResults%40searchFlights&inpPackageType=FLIGHT_ONLY&inpFlightRouteType=3&inpDepartureLocations=JFK&inpDepartureLocations=CUN&inpDepartureLocationCodes=JFK&inpDepartureLocationCodes=CUN&inpArrivalLocations=CUN&inpArrivalLocations=MEX&inpArrivalLocationCodes=CUN&inpArrivalLocationCodes=MEX&inpDepartureDates=" + newOutDate + "&inpDepartureDates=" + newInDate + "&inpDepartureTimes=362&inpDepartureTimes=362&inpHotelRoomCount=1&inpChildCounts=0&inpAdultCounts=1&inpSeniorCounts=0&inpInfants=2&inpFlightClass=3&inpRefundableFlightsOnly=OFF&inpSortType=0&inpFlightAirlinePreference=&inpIsNonstopOnly=N&inttkn=F5CsOgSVHJWClUEj' "
                        + "title='Expedia Website' target='_blank'>with your given dates</a>";
            searchWithNewDatesLabel_JFKCUN_CUNMEX.Text = labelText + href + "<br />";
            searchWithNewDatesLabel_JFKCUN_CUNMEX.Visible = true;
            searchWithNewDatesLabel_BUDJFK_MEXBUD.Visible = false;
        }
        else if (queryString.Contains("r=")) // 
        {
            SetVisibility(calendar_JFKCUN_CUNMEX);
            selectText = "Select a new JFK -> CUN date: ";
            defaultDate = defaultOutDate_JFKCUN;
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
       
    private string createURL(string defaultOutDate, string defaultInDate, string route1, string route2)
    {
        string outDep; // outbound departure location
        string outArr; // outbound arrival location
        string inDep;  // inbound departure location
        string inArr;  // inbound arrival location

        outDep = route1.Substring(0, 3);
        outArr = route1.Substring(3, 3);
        inDep = route2.Substring(0, 3);
        inArr = route2.Substring(3, 3);
        
        StringBuilder sb = new StringBuilder(); // using System.Text;
        sb.Append("http://www.expedia.com/Flight-SearchResults?action=FlightSearchResults%40searchFlights&inpPackageType=FLIGHT_ONLY&inpFlightRouteType=3");
        sb.Append("&inpDepartureLocations=" + outDep + "&inpDepartureLocations=" + inDep);
        sb.Append("&inpDepartureLocationCodes=" + outDep + "&inpDepartureLocationCodes=" + inDep);
        sb.Append("&inpArrivalLocations=" + outArr + "&inpArrivalLocations=" + inArr);
        sb.Append("&inpArrivalLocationCodes=" + outArr + "&inpArrivalLocationCodes=" + inArr);
        sb.Append("&inpDepartureDates=" + ConvertDateIntoExpediaFormat(defaultOutDate));
        sb.Append("&inpDepartureDates=" + ConvertDateIntoExpediaFormat(defaultInDate));        
        sb.Append("&inpDepartureTimes=362&inpDepartureTimes=362&inpHotelRoomCount=1&inpChildCounts=0&inpAdultCounts=1&inpSeniorCounts=0&inpInfants=2&inpFlightClass=3&inpRefundableFlightsOnly=OFF&inpSortType=0&inpFlightAirlinePreference=&inpIsNonstopOnly=N&inttkn=F5CsOgSVHJWClUEj");                
        
        return sb.ToString();
    } // createDefaultURL    

    protected string ConvertDateIntoExpediaFormat(string date)
    {
        string result = "";
        string[] parts = new string[] { "" };
        char[] delimiter = new char[] { '/' }; // Split() needs char[] instead of char
        
        if (!date.Equals(""))
        {
            if (date.Contains("/")) // somee.com: 6/3/2014 -> 06%2f03%2f2014
            {
                parts = date.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {                    
                    if (part.Length == 4) // ex: 2014 in 6/3/2014
                        result += part;
                    else if (part.Length == 1) // ex: 6 or 3 in 6/3/2014
                        result += "0" + part + "%2f";
                    else result += part + "%2f"; // ex: 10 in 8/10/2014
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

    // TODO

    // ChooseThisDateButtonClicked nem jó, mert a sender az nem calendar hanem button

    // 0, BUD -> JFK, MEX -> BUD
    // 1, JFK -> CUN, CUN -> MEX

    // 2, JFK -> LIM, LIM -> BUE, LIM -> RIO, RIO -> CUN, CUN -> MEX
    // 3, JFK -> LIM, LIM -> RIO, RIO -> BUE, BUE -> CUN, CUN -> MEX
    // 4, JFK -> RIO, RIO -> BUE, BUE -> LIM, LIM -> CUN, CUN -> MEX
    // 5, JFK -> RIO, RIO -> LIM, LIM -> BUE, BUE -> CUN, CUN -> MEX
    // 6, JFK -> BUE, BUE -> LIM, LIM -> RIO, RIO -> CUN, CUN -> MEX
    // 7, JFK -> BUE, BUE -> RIO, RIO -> LIM, LIM -> CUN, CUN -> MEX
} // _Default class         
