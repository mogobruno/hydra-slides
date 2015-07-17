'use strict';

describe('Service: slideCanvas', function () {

  // load the service's module
  beforeEach(module('webClientApp'));

  // instantiate service
  var slideCanvas;
  beforeEach(inject(function (_slideCanvas_) {
    slideCanvas = _slideCanvas_;
  }));

  it('should do something', function () {
    expect(!!slideCanvas).toBe(true);
  });

});
