Sandbox('indexController',['ajaxUtils'], function(ajaxUtils){

	console.log(ajaxUtils);
	ajaxUtils.get(
		'http://demo2119355.mockable.io/hydra/v1/login',
		{login:'jose',password:'senha'},
		{
			success:function(data){
				console.log(data);
			},
			error: function(data){
				console.log(data);
			}
		}
	)

	$('a').click(function(event){
		event.preventDefault();
		$('html, body').animate({
			scrollTop: $( $.attr(this, 'href') ).offset().top
		}, 500);
	});

});
