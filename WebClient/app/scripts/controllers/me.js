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
      $scope.name = "me";
      $scope.email = "me@email.com";
  });
