<%@ Page Title="Expedia Search | About" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About this website:
    </h2>
    <br />
    <p>
    The term <asp:HyperLink ID="Latin_America" runat="server" Target="_blank"
    NavigateUrl="http://en.wikipedia.org/wiki/Latin_america"
    ToolTip="Wikipedia | Latin America">Latin America
    </asp:HyperLink> is used instead of saying South America and Mexico.<br />
    </p>

    <p>
    The <asp:HyperLink ID="IATA" runat="server" Target="_blank"
    NavigateUrl="http://en.wikipedia.org/wiki/International_Air_Transport_Association_airport_code"
    ToolTip="Wikipedia | IATA airport code">IATA airport codes
    </asp:HyperLink> are used for searching departure and arrival airports.<br />
    </p>
    
    Example IATA codes: <ul>
                            <li>BUD - Budapest, Hungary</li>                            
                            <li>JFK - New York, USA (John F. Kennedy International Airport)</li>
                            <li>CUN - Cancun, Mexico</li>
                            <li>MEX - Mexico City, Mexico</li>
                            <li>RIO - Rio De Janeiro, Brazil</li>
                            <li>LIM - Lima, Peru</li>
                            <li>BUE - Buenos Aires, Argentina</li>
                        </ul>
    

</asp:Content>
