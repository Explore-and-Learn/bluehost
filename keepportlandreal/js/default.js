(function () {

	"use strict"

	/**
	 * Open's CNN web site
	 */
	function openCnn() {
		open("http://cnn.com");
	}

	$(document).ready(function(){

			$("#mainMenu").on("click", function(){
				openCnn();
			})

	})

})();