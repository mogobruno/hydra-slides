'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:MeCtrl
 * @description
 * # MeCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('MeCtrl', function ($scope) {

      if(localStorage.user){
      	$scope.user = JSON.parse(localStorage.user);
      }
  });
