Sandbox(['module'], function(module){
	QUnit.test('Teste do module', function(assert){
		assert.ok(module.stringValidator('Oie'));
		assert.notOk(module.stringValidator(123));
	})
});