'use strict';

describe('Controller: NavbarcontrollerCtrl', function () {

  // load the controller's module
  beforeEach(module('webClientApp'));

  var NavbarcontrollerCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    NavbarcontrollerCtrl = $controller('NavbarcontrollerCtrl', {
      $scope: scope
      // place here mocked dependencies
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(NavbarcontrollerCtrl.awesomeThings.length).toBe(3);
  });
});
