'use strict';

describe('Controller: NewslideCtrl', function () {

  // load the controller's module
  beforeEach(module('webClientApp'));

  var NewslideCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    NewslideCtrl = $controller('NewslideCtrl', {
      $scope: scope
      // place here mocked dependencies
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(NewslideCtrl.awesomeThings.length).toBe(3);
  });
});
