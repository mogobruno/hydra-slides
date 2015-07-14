'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:HomeCtrl
 * @description
 * # HomeCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('HomeCtrl', function ($scope, $location) {
    $scope.name = $location.search().name;
  });
