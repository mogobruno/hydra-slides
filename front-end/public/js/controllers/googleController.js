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

	$('a').click(function(){
    $('html, body').animate({
        scrollTop: $( $.attr(this, 'href') ).offset().top
    }, 500);
    return false;
});

})