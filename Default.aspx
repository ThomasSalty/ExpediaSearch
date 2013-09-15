﻿<%@ Page Title="Expedia Search" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        My plan for a possible trip to Latin America in the summer of 2014:<br /><br />
    </h2>
    <p>
        1) Search for flight from BUD to JFK on 3rd June 2014 and from MEX to BUD on 10th August
           on 
           <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank" ToolTip="Expedia Website"
            NavigateUrl="http://www.expedia.com/Flight-SearchResults?action=FlightSearchResults%40searchFlights&inpPackageType=FLIGHT_ONLY&inpFlightRouteType=3&inpDepartureLocations=BUD&inpDepartureLocations=MEX&inpDepartureLocationCodes=BUD&inpDepartureLocationCodes=MEX&inpArrivalLocations=JFK&inpArrivalLocations=BUD&inpArrivalLocationCodes=JFK&inpArrivalLocationCodes=BUD&inpDepartureDates=06%2F03%2F2014&inpDepartureDates=08%2F10%2F2014&inpDepartureTimes=362&inpDepartureTimes=362&inpHotelRoomCount=1&inpChildCounts=0&inpAdultCounts=1&inpSeniorCounts=0&inpInfants=2&inpFlightClass=3&inpRefundableFlightsOnly=OFF&inpSortType=0&inpFlightAirlinePreference=&inpIsNonstopOnly=N&inttkn=F5CsOgSVHJWClUEj">expedia.com
           </asp:HyperLink>          
    </p>

    <script language="C#" runat="server">
        
        string selectText;
        string defaultDate;
        void Initialize(Object sender, EventArgs e)
        {            
            if (Request.QueryString.ToString().Equals("x"))
            {
                selectText = "Select a new MEX -> BUD date: ";
                defaultDate = "2014-08-10";
            }
            else
            {
                selectText = "Select a new BUD -> JFK date: ";
                defaultDate = "2014-06-03";
            }
            calendar1.SelectedDate = DateTime.Parse(defaultDate);
            calendar1.VisibleDate = calendar1.SelectedDate;
            selectInOrOutboundLabel.Text = selectText;    
        }
        void SetNewDate(Object sender, EventArgs e)
        {
            DateTime newDate = calendar1.SelectedDate;
            label1.Text = newDate.ToShortDateString();
            label1.Visible = true;
            button1.Text = "Select MEX -> BUD date";
            button1.Visible = true;
        }
        void ButtonClicked (Object sender, EventArgs e)
        {
            button1.Visible = false;
            selectText = "Select a new MEX -> BUD date: ";
            Response.Redirect(Request.RawUrl+"?x"); // refreshes the page            
        }
        
        // TODO
        // 1, Calendar csak akkor ha változtatni szeretnék a dátumokon
        // 2, Előre haladás érzékeltetése >> -alakkal és/vagy valahogy
        // 3, Új expedia link az új dátumokkal
        
    </script>

    <asp:Label id="selectInOrOutboundLabel" runat="server" />
    <asp:Label id="label1" runat="server" Visible="false" />
       
    <asp:Calendar ID="calendar1" runat="server"
      SelectionMode="Day" 
      ShowGridLines="False"
      OnInit="Initialize"
      OnSelectionChanged="SetNewDate">
      <SelectedDayStyle BackColor="#4b6c9e" ForeColor="#f9f9f9"> </SelectedDayStyle>
    </asp:Calendar>     
    <asp:Button id="button1" runat="server" Visible="false" OnClick="ButtonClicked" />
        
    <hr /><br />    
    
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
