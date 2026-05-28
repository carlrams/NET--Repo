"use strict";

// Class definition
var KTModalNewTarget = function () {
	var form;

	// Init form inputs
	var initForm = function () {
		// Due date. For more info, please visit the official plugin site: https://flatpickr.js.org/
		var datepicker01 = $(form.querySelector('[name="datepicker01"]'));
		datepicker01.flatpickr({
			dateFormat: "m/d/Y"
		});
		var datepicker02 = $(form.querySelector('[name="datepicker02"]'));
		datepicker02.flatpickr({
			dateFormat: "m/d/Y"
		});
	}

	return {
		// Public functions
		init: function () {
			form = document.querySelector('#form1');

			initForm();
		}
	};
}();

// On document ready
KTUtil.onDOMContentLoaded(function () {
	KTModalNewTarget.init();
});