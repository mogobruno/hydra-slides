Sandbox('googleController',['googleUtils','googleComponent'], function(gu, gc){

	gu.setSearchExecution({
		renderResult:function(imageSearch){
			gc.drawImages(imageSearch, 'results');
		},
		listener:function(execute){
			var element = document.getElementById('search');
			element.addEventListener('change', function(event){
				console.log('event');
				var element = event.target;
				console.log(execute);
				execute(element.value);
			});
		}
	})

})