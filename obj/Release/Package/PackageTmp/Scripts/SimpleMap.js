/* global google, define */

	/**
	 * Google Maps
	 *
	 * @link http://snazzymaps.com/style/27/shift-worker
	 */

	var mapOptions = {
		latLng:      '0,0',
		address: 	 '',
		zoom:        8,
		type:        'ROADMAP',
		styles:      '',
		scrollwheel: false,
		draggable:   true,
		markers:     [
			{
				locationlatlng: '0,0',
				title:          'demo marker',
				custompinimage: '',
			}
		],
	};


	/**
	 * Constructor
	 * @param {jQuery selector} element where to create a map to
	 * @param {Object} options
	 */
	var SimpleMap = function( elm, options ) {
        'use strict';
		this.mapOptions = $.extend( {}, mapOptions, options );
		this.elm = elm;
		this.setOptions();

		return this;
	};

	SimpleMap.prototype.setOptions = function() {
        'use strict';
		this.mapOptions.latLng    = this.getLatLngFromString( this.mapOptions.latLng );
		this.mapOptions.center    = new google.maps.LatLng( this.mapOptions.latLng[0], this.mapOptions.latLng[1]);
		this.mapOptions.mapTypeId = this.getMapConstant();

		return this;
	};

	/**
	 * Returns the constant for the google maps
	 * @return MapTypeId
	 * @link https://developers.google.com/maps/documentation/javascript/maptypes#MapTypes
	 */
	SimpleMap.prototype.getMapConstant = function() {
        'use strict';
		switch ( this.mapOptions.type.toLowerCase() ) {
			case 'roadmap':
				return google.maps.MapTypeId.ROADMAP;
			case 'satellite':
				return google.maps.MapTypeId.SATELLITE;
			case 'hybrid':
				return google.maps.MapTypeId.HYBRID;
			case 'terrain':
				return google.maps.MapTypeId.TERRAIN;
			default:
				return google.maps.MapTypeId.ROADMAP;
		}
	};

	/**
	 * Helper function to create lagLng array if the context is string
	 * Editing in-place.
	 * @return void
	 */
	SimpleMap.prototype.getLatLngFromString = function( str ) {
        'use strict';
		if ( _.isString( str ) ) {
			return _.map( str.split( ',' ), function (val) {
				return parseFloat( val, 10 );
			} );
		} else {
			return str;
		}
	};


	SimpleMap.prototype.renderMap = function() {
        'use strict';
		
		if( ! _.isUndefined( this.elm ) ) {
			this.map = new google.maps.Map( this.elm.get(0), this.mapOptions );
		} else {
			return false;
		}
		
		//route or map?
				
		if (typeof route !== typeof undefined && route !== false) {
		   			
			var start = new google.maps.LatLng(28.694004, 77.110291);
			var end = new google.maps.LatLng(28.72082, 77.107241);

			var directionsDisplay = new google.maps.DirectionsRenderer();// also, constructor can get "DirectionsRendererOptions" object
			directionsDisplay.setMap(this.map); // map should be already initialized.

			route.travelMode = google.maps.TravelMode.DRIVING;
			route.provideRouteAlternatives = false;

			var request = route;
			
			var directionsService = new google.maps.DirectionsService(); 
			directionsService.route(request, function(response, status) {
				if (status == google.maps.DirectionsStatus.OK) {
					directionsDisplay.setDirections(response);
				}
			});
		   
		} else {
			
			this.addMarkers();
			
		}
	
		return this;
	};

	SimpleMap.prototype.addMarkers = function () {
        'use strict';
		
		// add all markers
		$.each( this.mapOptions.markers, $.proxy( function ( i, val ) {
			
			var theMap = this.map;
			
			var geocoder = new google.maps.Geocoder();
						
			geocoder.geocode({'address': val.address}, function(results, status) {
				
				if (status === google.maps.GeocoderStatus.OK) {
										
					theMap.setCenter(results[0].geometry.location);
					var marker = new google.maps.Marker({
			        	map: theMap,
			        	position: results[0].geometry.location,
						title: val.title,
			      	});
					
					if ( ! _( val.custompinimage).isEmpty() ) {
						marker.setIcon( val.custompinimage );
					}
			    	
				} else {
					
					alert('Geocode was not successful for the following reason: ' + status);
			    
				}	
			});
			
			
		}, this ) );
		
	};

