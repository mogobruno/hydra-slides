var Sandbox = function(){

	var argumentsArray = Array.prototype.slice.call(arguments);
	
	var callback = argumentsArray.pop();
	var orderedModules = argumentsArray.pop();
	var newModuleName = argumentsArray.pop();

	if(this instanceof Sandbox){
		return new Sandbox(orderedModules, callback);
	}

	var modules = [];
	for(index in orderedModules){
		modules.push(Sandbox.modules[orderedModules[index]]);
	}


	if( typeof newModuleName === 'string'){
		Sandbox.modules[newModuleName] = callback.apply(undefined,modules);
	}else{
		callback.apply(undefined,modules);
	}
	
}

Sandbox.modules = {};