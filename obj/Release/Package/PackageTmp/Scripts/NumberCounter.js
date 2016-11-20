/**
 * Number Counter Widget
 */

	var config = {
		eventNS:              'widgetCounter',
		numberContainerClass: '.js-number',
	};

	var NumberCounter = function( $widgetElement ){
        'use strict';
        
		this.$widgetElement = $widgetElement;
		this.uniqueNS = _.uniqueId( config.eventNS );

		this.registerListeners();

		$( document ).trigger( 'scroll.' + this.uniqueNS );

		return this;
	};

	// Helper: Add leading zeros for counting numbers
	var leadingZeros = function( num, size ) {
        'use strict';
        
		var output = '' + num;

		while ( output.length < size ) {
			output = '0' + output;
		}

		return output;
	};

	_.extend( NumberCounter.prototype, {
		/**
		 * Register dom listeners.
		 */
		registerListeners: function () {
            'use strict';
			$( document ).on( 'scroll.' + this.uniqueNS, _.throttle( _.bind( function() {
				if ( this.widgetScrolledIntoView() ) {
					this.triggerCounting();
				}
			}, this ), 500 ) );

			return this;
		},

		/**
		 * Destroy all listeners registered in the registerListeners()
		 */
		destroyListeners: function () {
            'use strict';
			$( document ).off( 'scroll.' + this.uniqueNS );

			return this;
		},

		/**
		 * Trigger counting for all the numbers in a single widget
		 */
		triggerCounting: function () {
            'use strict';
			_.each( this.getSingleNumbersInWidget(), function ( $singleNumber ) {
				this.animateValue( $singleNumber, 0, $singleNumber.data( 'to' ), this.$widgetElement.data( 'speed' ) );
			}, this );

			this.destroyListeners();
		},

		/**
		 * Get all single number containers in a Number Widget.
		 * @return {array} array of cached jQuery elements
		 */
		getSingleNumbersInWidget: function () {
            'use strict';
			var singleNumbers = [];

			this.$widgetElement.find( config.numberContainerClass ).each( function() {
				singleNumbers.push( $( this ) );
			} );

			return singleNumbers;
		},


		/**
		 * Animate counting
		 * Assumes integer values for start, end and speed and DOM element for the element parameter
		 */
		animateValue: function( $element, start, end, speed ) {
            'use strict';
			// debugger;
			var range = end - start,
				minTimer = 50, // No timer shorter than 50ms (not really visible any way)
				stepTime = Math.abs( Math.floor( speed / range ) ); // Calculate step time to show all intermediate values

			// Never go below minTimer
			stepTime = Math.max( stepTime, minTimer );

			// Get current time and calculate desired end time
			var startTime = new Date().getTime(),
				endTime = startTime + speed,
				timer;

			var run = function() {
				var now = new Date().getTime(),
					remaining = Math.max( ( endTime - now ) / speed, 0 ),
					value     = Math.round( end - ( remaining * range ) );

				$element.text( leadingZeros( value, end.toString().length ) );

				if ( value === end ) {
					clearInterval( timer );
				}
			};

			timer = setInterval( run, stepTime );
			run();
		},

		/**
		 * Function for detecting if the element is visible on screen
		 */
		widgetScrolledIntoView: function() {
            'use strict';
			var docViewTop    = $( window ).scrollTop(),
				docViewBottom = docViewTop + $( window ).height(),
				elemTop       = this.$widgetElement.offset().top,
				elemBottom    = elemTop + this.$widgetElement.height();

			return ( ( elemBottom <= docViewBottom ) && ( elemTop >= docViewTop ) );
		},
	});