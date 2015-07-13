'use strict';

describe('Service: requisition', function () {

  // load the service's module
  beforeEach(module('webClientApp'));

  // instantiate service
  var requisition;
  beforeEach(inject(function (_requisition_) {
    requisition = _requisition_;
  }));

  it('should do something', function () {
    expect(!!requisition).toBe(true);
  });

});
