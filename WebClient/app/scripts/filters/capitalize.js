'use strict';

/**
 * @ngdoc filter
 * @name webClientApp.filter:capitalize
 * @function
 * @description
 * # capitalize
 * Filter in the webClientApp.
 */
angular.module('webClientApp')
  .filter('capitalize', function() {
  return function(input, scope) {
    if (input!=null)
    input = input.toLowerCase();
    return input.substring(0,1).toUpperCase()+input.substring(1);
  }
});