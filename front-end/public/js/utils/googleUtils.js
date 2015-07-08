Sandbox('googleUtils',[], function(){
	var imageSearch,
		renderResult;

	var searchComplete = function(){
		renderResult(imageSearch);
	}

	function defineImageSearch(searchComplete, listener) {
		listener(function(term){
			imageSearch = new google.search.ImageSearch();
			imageSearch.setSearchCompleteCallback(this, searchComplete, null);
			imageSearch.execute(term);
		});
	}

	var setSearchExecution = function(params){
		renderResult = params.renderResult;
		google.load('search', '1', {'callback':function(){
			defineImageSearch(searchComplete, params.listener);
		}});
	}

	return {
		setSearchExecution: setSearchExecution
	}
});