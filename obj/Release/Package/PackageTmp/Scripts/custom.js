$(function(){
	"use strict";
        
	/**
	 * gallery
	 */
	$('.gallery').each(function(){
		
		$(this).magnificPopup({
			delegate: 'a', // child items selector, by clicking on it popup will open
		  	type: 'image',
			gallery:{
			    enabled:true
			}
		});
		
	})
	
	
	
	/**
	 * Maps
	 */
	$( '.js-where-we-are' ).each( function () {
		new SimpleMap( $( this ), {
			markers: mapMarkers,
			zoom:    $( this ).data( 'zoom' ),
			type:    $( this ).data( 'type' ),
			styles:  [{"featureType":"administrative","elementType":"labels.text.fill","stylers":[{"color":"#444444"}]},{"featureType":"landscape","elementType":"all","stylers":[{"color":"#f2f2f2"}]},{"featureType":"landscape.man_made","elementType":"geometry.fill","stylers":[{"color":"#eeeeee"}]},{"featureType":"landscape.natural.landcover","elementType":"geometry.fill","stylers":[{"color":"#dddddd"}]},{"featureType":"landscape.natural.terrain","elementType":"geometry.fill","stylers":[{"color":"#dddddd"}]},{"featureType":"poi","elementType":"all","stylers":[{"visibility":"off"}]},{"featureType":"road","elementType":"all","stylers":[{"saturation":-100},{"lightness":45}]},{"featureType":"road.highway","elementType":"all","stylers":[{"visibility":"simplified"}]},{"featureType":"road.arterial","elementType":"labels.icon","stylers":[{"visibility":"off"}]},{"featureType":"transit","elementType":"all","stylers":[{"visibility":"off"}]},{"featureType":"water","elementType":"all","stylers":[{"color":"#46bcec"},{"visibility":"on"}]},{"featureType":"water","elementType":"geometry.fill","stylers":[{"color":"#1f425d"}]},{"featureType":"water","elementType":"labels.text.fill","stylers":[{"color":"#979797"}]},{"featureType":"water","elementType":"labels.text.stroke","stylers":[{"weight":"0.01"}]}],
		}).renderMap();
	});
	
	$( '.route' ).each( function () {
		new SimpleMap( $( this ), {
			zoom:    $( this ).data( 'zoom' ),
			type:    $( this ).data( 'type' ),
			styles:  [{"featureType":"administrative","elementType":"labels.text.fill","stylers":[{"color":"#444444"}]},{"featureType":"landscape","elementType":"all","stylers":[{"color":"#f2f2f2"}]},{"featureType":"landscape.man_made","elementType":"geometry.fill","stylers":[{"color":"#eeeeee"}]},{"featureType":"landscape.natural.landcover","elementType":"geometry.fill","stylers":[{"color":"#dddddd"}]},{"featureType":"landscape.natural.terrain","elementType":"geometry.fill","stylers":[{"color":"#dddddd"}]},{"featureType":"poi","elementType":"all","stylers":[{"visibility":"off"}]},{"featureType":"road","elementType":"all","stylers":[{"saturation":-100},{"lightness":45}]},{"featureType":"road.highway","elementType":"all","stylers":[{"visibility":"simplified"}]},{"featureType":"road.arterial","elementType":"labels.icon","stylers":[{"visibility":"off"}]},{"featureType":"transit","elementType":"all","stylers":[{"visibility":"off"}]},{"featureType":"water","elementType":"all","stylers":[{"color":"#46bcec"},{"visibility":"on"}]},{"featureType":"water","elementType":"geometry.fill","stylers":[{"color":"#1f425d"}]},{"featureType":"water","elementType":"labels.text.fill","stylers":[{"color":"#979797"}]},{"featureType":"water","elementType":"labels.text.stroke","stylers":[{"weight":"0.01"}]}],
		}).renderMap();
	});
	
	
	/**
	 * Number Counter Widget JS code
	 */
	// Get all number counter widgets
	var $counterWidgets = $( '.widget-number-counters' );

	if ( $counterWidgets.length ) {
		$counterWidgets.each( function () {
			new NumberCounter( $( this ) );
		} );
	}
	
	
	
	/**
	 * Menu height on large screens, break point
	 */
	(function () {
		$( 'head' ).append( '<style type="text/css" id="main-nav-css"></style>' );

		var $menu = $( '.js-main-nav' ),
			$css = $( '#main-nav-css' );

		if ( ! $menu || ! $css ) {
			return;
		}

		var isMultilineMenu = function () {
			return $menu.height() > 45;
		};

		var updateMenuStyle = function () {
			if ( Modernizr.mq( '(min-width: 1200px)' ) && isMultilineMenu() ) {
				var lines = Math.round( $menu.height() / 60 );
				$css.text( '@media (min-width: 1200px) { .header__container::before { bottom: ' + (lines * 60 - 30) + 'px; } .header__container::after { bottom: ' + (lines * 60 ) + 'px; } }' );
			}
			else if ( Modernizr.mq( '(min-width: 992px)' ) && isMultilineMenu() ) {
				$css.text( '@media (min-width: 992px) { .header__container::before, .header__container::after { bottom: ' + $menu.height() + 'px; } }' );
			}
			else {
				$css.text( '' );
			}
		};

		updateMenuStyle();
		$( window ).on( 'resize', _.debounce( updateMenuStyle, 250 ) );
	})();
	
	
	/**
	 * Quick quote form submission
	 */
	
	var theForm
	
	$('form.aSubmit').validator().on('submit', function (e) {
		
		theForm = $(this);
		
		if (e.isDefaultPrevented()) {
	    	
			alert('Please fill out the Quick Quote form');
	  	
		} else {
			
			$('#loader').fadeIn();
	    	
			$.ajax({
				url: $(this).attr('action'),
				method: 'post',
				data: $(this).serialize()
			}).done(function(ret){
				
				$('#loader').fadeOut();
				
				if( ret == "Message sent!" ) {
					
					theForm.find('.response.success').fadeIn();
					
				} else {
					
					theForm.find('.response.error').fadeIn();
					
				}
							
				setTimeout(function(){ theForm.find('.response').fadeOut() }, 7000)
				
			})
			
		}
		
		return false;
		
	})
	
	
	/**
	 * Request quote scroll
	 */
    $('#button_requestQuote').on('click', function(){
        
        $('html, body').animate({
	        scrollTop: $("#quickQuoteForm_wrapper").offset().top
	    }, 2000);
            
    });
	
})