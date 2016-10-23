(function () {

	"use strict"

	/**
	 * Opens CNN web site
	 * @param {boolean} openSite
	 */
	function openCnn(openSite) {
		if(openSite)
			open("http://cnn.com");
	}

	$(document).ready(function(){

			$("#mainMenu").on("click", function(){
				openCnn(true);
			});

	});

})();