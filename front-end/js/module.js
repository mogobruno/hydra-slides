Sandbox('module', [], function(){
	var stringValidator = function(value){
		return typeof value === "string";
	}

	return{
		stringValidator:stringValidator
	}
});