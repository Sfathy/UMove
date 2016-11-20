<%@ Page Title="" Language="C#" MasterPageFile="~/Shipments/Site.Master" AutoEventWireup="true" CodeBehind="CreateTirp.aspx.cs" Inherits="UMoveNew.Shipments.CreateTirp" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        html, body {
            height: 100%;
            margin: 0;
            padding: 0;
        }

        #map {
            height: 100%;
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

        #pac-input {
            background-color: #fff;
            font-family: Roboto;
            font-size: 15px;
            font-weight: 300;
            margin-left: 12px;
            padding: 0 11px 0 13px;
            text-overflow: ellipsis;
            width: 300px;
        }

            #pac-input:focus {
                border-color: #4d90fe;
            }

        #pac-input2 {
            background-color: #fff;
            font-family: Roboto;
            font-size: 15px;
            font-weight: 300;
            margin-left: 12px;
            padding: 0 11px 0 13px;
            text-overflow: ellipsis;
            width: 300px;
        }

            #pac-input2:focus {
                border-color: #4d90fe;
            }

        .pac-container {
            font-family: Roboto;
        }

        #type-selector {
            color: #fff;
            background-color: #4d90fe;
            padding: 5px 11px 0px 11px;
        }

            #type-selector label {
                font-family: Roboto;
                font-size: 13px;
                font-weight: 300;
            }

        #target {
            width: 345px;
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
                        <label>
                            <asp:TextBox ID="txtTripName" runat="server" placeholder="Trip Name" required meta:resourcekey="txtTripNameResource1"></asp:TextBox></label>
                    </div>
                    <div class="section"><span>2</span></div>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" CssClass="asplab" runat="server" Text="Pickup (City or ZIP)" meta:resourcekey="Label2Resource1"></asp:Label>
                    <div class="inner-wrap">
                        <label>
                            <div class="row">
                                <div class="col-md-12">
                                     <div class="col-md-4">
                                         <asp:Label ID="Label7" runat="server" Text="<%$ Resources:CountryName %>"></asp:Label></div>
                                    <div class="col-md-6">
                                        <dx:ASPxComboBox ID="ASPxComboBox1" runat="server" TextField="CountryName" ValueField="CountryName" DataSourceID="SqlDataSource1" Theme="Aqua"></dx:ASPxComboBox>
                                        <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:DefaultConnection %>' SelectCommand="SELECT [CountryName] FROM [tbl_Countries]"></asp:SqlDataSource>
                                    </div>
                                </div>
                            </div>
                            <input id="pac-input" name="pac-input" class="controls" type="text" placeholder="Picup Location" required /></label>
                        <div id="map" name="map" style="width: 100%; height: 200px;"></div>
                        <script type="text/javascript">
                            function initAutocomplete() {
                                var map = new google.maps.Map(document.getElementById('map'), {
                                    center: { lat: 30.0444196, lng: 31.23571160000006 },
                                    zoom: 13,
                                    mapTypeId: google.maps.MapTypeId.ROADMAP
                                });
                                var map2 = new google.maps.Map(document.getElementById('map2'), {
                                    center: { lat: 30.0444196, lng: 31.23571160000006 },
                                    zoom: 13,
                                    mapTypeId: google.maps.MapTypeId.ROADMAP
                                });
                                // Create the search box and link it to the UI element.
                                var input = document.getElementById('pac-input');
                                var searchBox = new google.maps.places.SearchBox(input);
                                map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
                                var input2 = document.getElementById('pac-input2');
                                var searchBox2 = new google.maps.places.SearchBox(input2);
                                map2.controls[google.maps.ControlPosition.TOP_LEFT].push(input2);
                                // Bias the SearchBox results towards current map's viewport.
                                map.addListener('bounds_changed', function () {
                                    searchBox.setBounds(map.getBounds());
                                });
                                map2.addListener('bounds_changed', function () {
                                    searchBox2.setBounds(map2.getBounds());
                                });
                                var markers = [];
                                var markers2 = [];
                                // Listen for the event fired when the user selects a prediction and retrieve
                                // more details for that place.
                                searchBox.addListener('places_changed', function () {
                                    var places = searchBox.getPlaces();

                                    if (places.length == 0) {
                                        return;
                                    }

                                    // Clear out the old markers.
                                    markers.forEach(function (marker) {
                                        marker.setMap(null);
                                    });
                                    markers = [];

                                    // For each place, get the icon, name and location.
                                    var bounds = new google.maps.LatLngBounds();
                                    places.forEach(function (place) {
                                        var icon = {
                                            url: place.icon,
                                            size: new google.maps.Size(71, 71),
                                            origin: new google.maps.Point(0, 0),
                                            anchor: new google.maps.Point(17, 34),
                                            scaledSize: new google.maps.Size(25, 25)
                                        };
                                        document.getElementById("latn").value = place.geometry.location;
                                        // Create a marker for each place.
                                        markers.push(new google.maps.Marker({
                                            map: map,
                                            icon: icon,
                                            title: place.name,
                                            position: place.geometry.location
                                        }));

                                        if (place.geometry.viewport) {
                                            // Only geocodes have viewport.
                                            bounds.union(place.geometry.viewport);
                                        } else {
                                            bounds.extend(place.geometry.location);
                                        }
                                    });
                                    map.fitBounds(bounds);
                                });
                                searchBox2.addListener('places_changed', function () {
                                    var places2 = searchBox2.getPlaces();

                                    if (places2.length == 0) {
                                        return;
                                    }

                                    // Clear out the old markers.
                                    markers2.forEach(function (marker2) {
                                        marker2.setMap(null);
                                    });
                                    markers2 = [];

                                    // For each place, get the icon, name and location.
                                    var bounds2 = new google.maps.LatLngBounds();
                                    places2.forEach(function (place2) {
                                        var icon2 = {
                                            url: place2.icon,
                                            size: new google.maps.Size(71, 71),
                                            origin: new google.maps.Point(0, 0),
                                            anchor: new google.maps.Point(17, 34),
                                            scaledSize: new google.maps.Size(25, 25)
                                        };
                                        document.getElementById("latn2").value = place2.geometry.location;
                                        // Create a marker for each place.
                                        markers2.push(new google.maps.Marker({
                                            map: map2,
                                            icon: icon2,
                                            title: place2.name,
                                            position: place2.geometry.location
                                        }));

                                        if (place2.geometry.viewport) {
                                            // Only geocodes have viewport.
                                            bounds2.union(place.geometry.viewport);
                                        } else {
                                            bounds2.extend(place.geometry.location);
                                        }
                                    });
                                    map2.fitBounds(bounds2);
                                });
                            }



                        </script>

                        <%--<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyB3ZiAhRI5Wh8UBr-u65bdd2_VEOLUewJc&libraries=places&callback=initAutocomplete"
         async defer></script>--%>
                        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAfvj4pilXFB6MPNuPSMfqlLq3me9oZc9s&libraries=places&callback=initAutocomplete"
                            async defer></script>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <label>
                                        <asp:TextBox ID="txtdatepic" runat="server" placeholder="Pickup Date" required meta:resourcekey="txtdatepicResource1"></asp:TextBox></label>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtdatepic" BehaviorID="CalendarExtender1" Format="dd/MM/yyyy"/>
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
                        <label>
                            <input id="pac-input2" name="pac-input2" class="controls" type="text" placeholder="Dleivery Location" required /></label>
                        <div id="map2" name="map2" style="width: 100%; height: 200px;"></div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtdatedelivery" runat="server" placeholder="Delivery Date" required meta:resourcekey="txtdatedeliveryResource1"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtdatedelivery" BehaviorID="CalendarExtender2"  Format="dd/MM/yyyy"/>
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
                        <label>
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
                        </label>
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
