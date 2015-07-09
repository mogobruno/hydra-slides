Sandbox('ajaxUtils', [], function(){
	
	var ajax = function(params){
		var token = sessionStorage.token;
		params.data.token = token;
		$.ajax({
			url: params.url,
			dataType: params.dataType,
			type: params.type,
			contentType: params.contentType,
			data: params.data,
			success: function(data, textStatus, jQxhr){
				sessionStorage.token = data.token;
				params.success(data, textSatatus, jQxhr);
			},
			error: function(jqXhr, textStatus, errorThrown){
				params.error(jqXhr, textStatus, errorThrown);
			}
		});
	}
	
	var get = function(url,data,objectCallbacks){
		ajax({
			url: url,
			data: data,
			dataType: 'text/json',
			contentType: 'application/json',
			type: 'get',
			success: objectCallbacks.success,
			error: objectCallbacks.error
		});
	}

	var put = function(url,data,objectCallbacks){
		ajax({
			url: url,
			data: data,
			dataType: 'text/json',
			contentType: 'application/json',
			type: 'put',
			success: objectCallbacks.success,
			error: objectCallbacks.error
		});
	}

	var post = function(url,data,objectCallbacks){
		ajax({
			url: url,
			data: data,
			dataType: 'text/json',
			contentType: 'application/json',
			type: 'post',
			success: objectCallbacks.success,
			error: objectCallbacks.error
		});
	}

	var del = function(url,data,objectCallbacks){
		ajax({
			url: url,
			data: data,
			dataType: 'text/json',
			contentType: 'application/json',
			type: 'delete',
			success: objectCallbacks.success,
			error: objectCallbacks.error
		});
	}

	return {
		get: get,
		put: put,
		post: post,
		delete: del
	}
});