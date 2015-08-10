'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:NewslideCtrl
 * @description
 * # NewslideCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('NewslideCtrl', function ($scope, requisition, slideGenerator) {
    requisition.get({
      url:'/slide/1',
      success: function(data){
        var slides = slideGenerator.generateSlides(data.presentation);
        data.presentation.slidesImages = slides;
        $scope.presentation = data.presentation;
        $scope.actualImage = $scope.presentation.slidesImages[$scope.index];
        console.log($scope.presentation);
      },
      error: function(data){
        //TODO arrumar esse trecho para um alert mais bonito ou uma modal
        console.log(data.userMessage);
      }
    });
  });
