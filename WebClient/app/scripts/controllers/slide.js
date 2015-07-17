'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:SlideCtrl
 * @description
 * # SlideCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('SlideCtrl', function ($scope, requisition, slideGenerator) {
    //TODO trocar o 1 pelo id da rota em $routeParam ou $stateParam

    $scope.index = 0;

    $scope.isFullscreen = false;

    $scope.toggleFullScreen = function() {
        $scope.index = 0;
        $scope.actualImage = $scope.presentation.slidesImages[$scope.index];
        $scope.isFullscreen = !$scope.isFullscreen;
    }

    $scope.next = function(){
        if($scope.index < $scope.presentation.slidesImages.length)
          ++$scope.index;
        $scope.actualImage = $scope.presentation.slidesImages[$scope.index];
    }

    $scope.previous = function(){
        if($scope.index > 0)
          --$scope.index;
        $scope.actualImage = $scope.presentation.slidesImages[$scope.index];
    }



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
