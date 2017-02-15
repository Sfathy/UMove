<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="CreateTirp.aspx.cs" Inherits="UMoveNew.Shipments.CreateTirp" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://ajax.aspnetcdn.com/ajax/jQuery/jquery-3.1.1.min.js"></script>
    <style>
        /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
        #map {
            height: 100%;
        }
        /* Optional: Makes the sample page fill the window. */
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        .controls {
            margin-top: 10px;
            border: 1px solid transparent;
            border-radius: 2px 0 0 2px;
            box-sizing: border-box;
            -moz-box-sizing: border-box;
            height: 32px;
            outline: none;
            box-shadow: 0 2px 6px rgba(0, 0, 0, 0.3);
        }

        #origin-input,
        #destination-input {
            background-color: #fff;
            font-family: Roboto;
            font-size: 15px;
            font-weight: 300;
            margin-left: 12px;
            padding: 0 11px 0 13px;
            text-overflow: ellipsis;
            width: 300px;
        }

            #origin-input:focus,
            #destination-input:focus {
                border-color: #4d90fe;
            }

        #mode-selector {
            color: #fff;
            background-color: #4d90fe;
            margin-left: 12px;
            padding: 5px 11px 0px 11px;
        }

            #mode-selector label {
                font-family: Roboto;
                font-size: 13px;
                font-weight: 300;
            }
    </style>

    <link href="<%$ Resources:form.css %>" rel="stylesheet" type="text/css" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="counters">
        <div class="container">
            <div class="row">
                <div class="form-style-10">
                    <div class="section"><span>1</span></div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label1" CssClass="asplab" runat="server" Text="Trip Name" meta:resourcekey="Label1Resource1"></asp:Label>
                    <div class="inner-wrap">
                       
                            <asp:TextBox ID="txtTripName" runat="server" placeholder="Trip Name" required meta:resourcekey="txtTripNameResource1"></asp:TextBox>
                    </div>
                    <div class="section"><span>2</span></div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" CssClass="asplab" runat="server" Text="Pickup (City or ZIP)" meta:resourcekey="Label2Resource1"></asp:Label>
                    <div class="inner-wrap">
                        
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label7" runat="server" Text="<%$ Resources:CountryName %>"></asp:Label>
                                    </div>
                                    <div class="col-md-6">

                                        <asp:DropDownList ID="ASPxComboBox1" runat="server" DataTextField="CountryName" DataValueField="CountryName" DataSourceID="SqlDataSource1"></asp:DropDownList>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [CountryName] FROM [tbl_Countries]"></asp:SqlDataSource>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <input id="origin-input" name="origin-input" class="controls" type="text"
                                                placeholder="Enter an origin location" />
                                        </div>
                                        <div class="col-md-6">
                                            <input id="destination-input" name="destination-input" class="controls" type="text"
                                                placeholder="Enter a destination location" />
                                        </div>
                                    </div>
                                </div>
                                <div id="mode-selector" class="controls" style="display: none;">
                                    <input type="radio" name="type" id="changemode-walking" checked="checked" />
                                    <label for="changemode-walking">Walking</label>

                                    <input type="radio" name="type" id="changemode-transit" />
                                    <label for="changemode-transit">Transit</label>

                                    <input type="radio" name="type" id="changemode-driving" />
                                    <label for="changemode-driving">Driving</label>
                                </div>
                                <div id="map" name="map" style="width: 100%; height: 300px"></div>
                            </div>
                            <script>
                                // This example requires the Places library. Include the libraries=places
                                // parameter when you first load the API. For example:
                                // <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_API_KEY&libraries=places">

                                function initMap() {
                                    var map = new google.maps.Map(document.getElementById('map'), {
                                        mapTypeControl: false,
                                        center: { lat: -33.80820191724644, lng: -33.979191697010805 },
                                        zoom: 13
                                    });

                                    new AutocompleteDirectionsHandler(map);
                                }

                                /**
                                 * @constructor
                                */
                                function AutocompleteDirectionsHandler(map) {
                                    this.map = map;
                                    this.originPlaceId = null;
                                    this.destinationPlaceId = null;
                                    this.travelMode = 'WALKING';
                                    var originInput = document.getElementById('origin-input');
                                    var destinationInput = document.getElementById('destination-input');
                                    var modeSelector = document.getElementById('mode-selector');
                                    this.directionsService = new google.maps.DirectionsService;
                                    this.directionsDisplay = new google.maps.DirectionsRenderer;
                                    this.directionsDisplay.setMap(map);

                                    var originAutocomplete = new google.maps.places.Autocomplete(
                                        originInput, { placeIdOnly: true });
                                    var destinationAutocomplete = new google.maps.places.Autocomplete(
                                        destinationInput, { placeIdOnly: true });

                                    this.setupClickListener('changemode-walking', 'WALKING');
                                    this.setupClickListener('changemode-transit', 'TRANSIT');
                                    this.setupClickListener('changemode-driving', 'DRIVING');

                                    this.setupPlaceChangedListener(originAutocomplete, 'ORIG');
                                    this.setupPlaceChangedListener(destinationAutocomplete, 'DEST');

                                    this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(originInput);
                                    this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(destinationInput);
                                    this.map.controls[google.maps.ControlPosition.TOP_LEFT].push(modeSelector);
                                }

                                // Sets a listener on a radio button to change the filter type on Places
                                // Autocomplete.
                                AutocompleteDirectionsHandler.prototype.setupClickListener = function (id, mode) {
                                    var radioButton = document.getElementById(id);
                                    var me = this;
                                    radioButton.addEventListener('click', function () {
                                        me.travelMode = mode;
                                        me.route();
                                        var xx = me.route();
                                    });
                                };

                                AutocompleteDirectionsHandler.prototype.setupPlaceChangedListener = function (autocomplete, mode) {
                                    var me = this;
                                    autocomplete.bindTo('bounds', this.map);
                                    autocomplete.addListener('place_changed', function () {
                                        var place = autocomplete.getPlace();
                                        if (!place.place_id) {
                                            window.alert("Please select an option from the dropdown list.");
                                            return;
                                        }
                                        if (mode === 'ORIG') {
                                            me.originPlaceId = place.place_id;
                                            var xx = autocomplete.getBounds();
                                            var lat = xx["f"]["b"];
                                            var long = xx["f"]["f"];
                                            document.getElementById("latn").value = "(" + lat + "," + long + ")";
                                        } else {
                                            me.destinationPlaceId = place.place_id;
                                            var xx2 = autocomplete.getBounds();
                                            var lat2 = xx2["f"]["b"];
                                            var long2 = xx2["f"]["f"];
                                            document.getElementById("latn2").value = "(" + lat2 + "," + long2 + ")";
                                        }

                                        me.route();
                                    });

                                };

                                AutocompleteDirectionsHandler.prototype.route = function () {
                                    if (!this.originPlaceId || !this.destinationPlaceId) {
                                        return;
                                    }
                                    var me = this;

                                    this.directionsService.route({
                                        origin: { 'placeId': this.originPlaceId },
                                        destination: { 'placeId': this.destinationPlaceId },
                                        travelMode: this.travelMode
                                    }, function (response, status) {
                                        if (status === 'OK') {
                                            me.directionsDisplay.setDirections(response);
                                        } else {
                                            window.alert('Directions request failed due to ' + status);
                                        }
                                    });
                                };

                            </script>
                            <!-- on serve -->
                            <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAulFpy14Z-NyksphFAn9_jn2pNKM8XthM&libraries=places&callback=initMap"
            async defer></script>
                            <!-- on local -->
                           <%-- <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAfvj4pilXFB6MPNuPSMfqlLq3me9oZc9s&libraries=places&callback=initMap"
                                async defer></script>--%>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                       
                                            <asp:TextBox ID="txtdatepic" runat="server" placeholder="Pickup Date" required meta:resourcekey="txtdatepicResource1"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatepic" BehaviorID="CalendarExtender1" Format="MM/dd/yyyy" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="DropDownList2" runat="server" meta:resourcekey="DropDownList2Resource1">
                                            <asp:ListItem Value="1" meta:resourcekey="ListItemResource1">Residence</asp:ListItem>
                                            <asp:ListItem Value="2" meta:resourcekey="ListItemResource2">Business (with loading dock or forklift)</asp:ListItem>
                                            <asp:ListItem Value="3" meta:resourcekey="ListItemResource3">Business (without loading dock or forklift)</asp:ListItem>
                                            <asp:ListItem Value="4" meta:resourcekey="ListItemResource4">Port</asp:ListItem>
                                            <asp:ListItem Value="5" meta:resourcekey="ListItemResource5">Construction Site</asp:ListItem>
                                            <asp:ListItem Value="6" meta:resourcekey="ListItemResource6">Trade Show / Convention Center</asp:ListItem>
                                            <asp:ListItem Value="7" meta:resourcekey="ListItemResource7">Storage Facility</asp:ListItem>
                                            <asp:ListItem Value="8" meta:resourcekey="ListItemResource8">Military Base</asp:ListItem>
                                            <asp:ListItem Value="9" meta:resourcekey="ListItemResource9">Airport</asp:ListItem>
                                            <asp:ListItem Value="10" meta:resourcekey="ListItemResource10">Other Secured or Limited Access Location</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                    </div>


                    <div class="section"><span>3</span></div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" CssClass="asplab" runat="server" Text="Delivery (City or ZIP)" meta:resourcekey="Label3Resource1"></asp:Label>
                    <div class="inner-wrap">
                    
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtdatedelivery" runat="server" placeholder="Delivery Date" required meta:resourcekey="txtdatedeliveryResource1"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdatedelivery" BehaviorID="CalendarExtender2" Format="MM/dd/yyyy" />
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="DropDownList1" runat="server" meta:resourcekey="DropDownList1Resource1">

                                            <asp:ListItem Value="1" meta:resourcekey="ListItemResource11">Residence</asp:ListItem>
                                            <asp:ListItem Value="2" meta:resourcekey="ListItemResource12">Business (with loading dock or forklift)</asp:ListItem>
                                            <asp:ListItem Value="3" meta:resourcekey="ListItemResource13">Business (without loading dock or forklift)</asp:ListItem>
                                            <asp:ListItem Value="4" meta:resourcekey="ListItemResource14">Port</asp:ListItem>
                                            <asp:ListItem Value="5" meta:resourcekey="ListItemResource15">Construction Site</asp:ListItem>
                                            <asp:ListItem Value="6" meta:resourcekey="ListItemResource16">Trade Show / Convention Center</asp:ListItem>
                                            <asp:ListItem Value="7" meta:resourcekey="ListItemResource17">Storage Facility</asp:ListItem>
                                            <asp:ListItem Value="8" meta:resourcekey="ListItemResource18">Military Base</asp:ListItem>
                                            <asp:ListItem Value="9" meta:resourcekey="ListItemResource19">Airport</asp:ListItem>
                                            <asp:ListItem Value="10" meta:resourcekey="ListItemResource20">Other Secured or Limited Access Location</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                    </div>
                    <div class="section"><span>4</span></div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label4" CssClass="asplab" runat="server" Text="Price or Transporters bid" meta:resourcekey="Label4Resource1"></asp:Label>
                    <div class="inner-wrap">

                        <div class="row">
                            <div class="col-md-12">

                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" CssClass="checkboxlist" meta:resourcekey="RadioButtonList1Resource1">
                                    <asp:ListItem Value="1" meta:resourcekey="ListItemResource21">Transporters bid</asp:ListItem>
                                    <asp:ListItem Value="2" meta:resourcekey="ListItemResource22">Price</asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                <label style="color: #2A88AD; font-weight: bolder; font-size: 18px">
                                    <asp:Label ID="Label5" runat="server" Text="IF you chosse Transporters bid leave Price box Empty" meta:resourcekey="Label5Resource1"></asp:Label></label>
                                <asp:TextBox ID="txtprice" runat="server" TextMode="Number" placeholder="Price" meta:resourcekey="txtpriceResource1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="section"><span>5</span></div>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label6" CssClass="asplab" runat="server" Text="Select the service types you will consider" meta:resourcekey="Label6Resource1"></asp:Label>
                    <div class="inner-wrap">

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <asp:RadioButtonList ID="RadioButtonList2" CssClass="checkboxlist" runat="server">
                                            <asp:ListItem Value="1" meta:resourcekey="ListItemResource23" Selected="True">Tow Away</asp:ListItem>
                                            <asp:ListItem Value="2" meta:resourcekey="ListItemResource24">Drive Away</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:RadioButtonList ID="RadioButtonList3" CssClass="checkboxlist" runat="server">
                                            <asp:ListItem Value="3" meta:resourcekey="ListItemResource25" Selected="True">Open Transport</asp:ListItem>
                                            <asp:ListItem Value="4" meta:resourcekey="ListItemResource26">Enclosed Transport</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>
                            </div>

                        <asp:TextBox ID="txtdetais" TextMode="MultiLine" runat="server" placeholder="Special Instructions (optional)" meta:resourcekey="txtdetaisResource1"></asp:TextBox>
                    </div>
                    <div class="button-section">
                        <asp:Button runat="server" ID="btnsave" type="submit" Text="Save" OnClick="btnsave_Click" meta:resourcekey="btnsaveResource1" />
                        <div style="/* margin-left: 82%; *//* margin-top: -36px; */float: left;">
                            <asp:LinkButton runat="server" ID="btnback" Text="Back" OnClick="btnback_Click" meta:resourcekey="btnbackResource1" />
                        </div>
                    </div>
                    <input type="hidden" id="latn" name="latn" />

                    <input type="hidden" id="latn2" name="latn2" />

                </div>
            </div>
        </div>
    </div>

</asp:Content>
