/* global define */
define( ['jquery', 'underscore'], function ( $, _ ) {
	'use strict';

	var config = {
		offset:          32, // px
		lineClassName:   'widget-title__line',
		inlineClassName: 'widget-title__inline',
		eventNS:         'ptwl', // namespace
		updateInterval:  500, // ms
	};

	var WidgetLine = function ( $elm ) {
		this.$elm = $elm;

		this
			.addLineElm()
			.updateLineCSS()
			.addListeners();

		return this;
	};

	_.extend( WidgetLine.prototype, {
		/**
		 * Adds new element to DOM which is representing a line
		 */
		addLineElm: function () {
			this.$elm.append( '<span class="' + config.lineClassName + '  js-added-line"></span>' );

			this.$line = this.$elm.find( '.' + config.lineClassName );

			return this;
		},

		/**
		 * Updates CSS propery `left` of a line according to text
		 */
		updateLineCSS: function () {
			this.$line.css( 'left', config.offset + parseInt( this.$elm.find( '.' + config.inlineClassName ).width(), 10 ) );

			return this;
		},

		/**
		 * Adds event listeners
		 */
		addListeners: function () {
			$( window ).on( 'resize.' + config.eventNS, _.debounce( _.bind( this.updateLineCSS, this ), config.updateInterval ) );

			return this;
		},

		/**
		 * Removes event listeners
		 */
		removeListeners: function () {
			$( window ).off( 'resize.' + config.eventNS );

			return this;
		}
	} );


	return WidgetLine;
} );