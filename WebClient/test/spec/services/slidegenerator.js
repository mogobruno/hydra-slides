'use strict';

describe('Service: slideGenerator', function () {

  // load the service's module
  beforeEach(module('webClientApp'));

  // instantiate service
  var slideGenerator;
  beforeEach(inject(function (_slideGenerator_) {
    slideGenerator = _slideGenerator_;
  }));

  it('should do something', function () {
    expect(!!slideGenerator).toBe(true);
  });

});
