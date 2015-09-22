'use strict';

describe('Controller: EditslideCtrl', function () {

  // load the controller's module
  beforeEach(module('webClientApp'));

  var EditslideCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    EditslideCtrl = $controller('EditslideCtrl', {
      $scope: scope
      // place here mocked dependencies
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(EditslideCtrl.awesomeThings.length).toBe(3);
  });
});
