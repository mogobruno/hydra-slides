'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:NavbarcontrollerCtrl
 * @description
 * # NavbarcontrollerCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('NavbarcontrollerCtrl', function ($scope) {
  		$scope.login = function(user){
  			console.log(user);
  		}
  });
