'use strict';

describe('Controller: MyslidesCtrl', function () {

  // load the controller's module
  beforeEach(module('webClientApp'));

  var MyslidesCtrl,
    scope;

  // Initialize the controller and a mock scope
  beforeEach(inject(function ($controller, $rootScope) {
    scope = $rootScope.$new();
    MyslidesCtrl = $controller('MyslidesCtrl', {
      $scope: scope
      // place here mocked dependencies
    });
  }));

  it('should attach a list of awesomeThings to the scope', function () {
    expect(MyslidesCtrl.awesomeThings.length).toBe(3);
  });
});
