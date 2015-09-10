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
    $scope.presentation = {};

    if(localStorage.user){
      var user = JSON.parse(localStorage.user);
      console.log(user);
      $scope.presentation.ownerId = user.id;  
    }
    

    $scope.renderPreview = function(presentation){
      generateSlides(presentation);
    }

    var generateSlides = function(presentation){
      console.log(presentation);
      var slidesContent = [];
      if(presentation.slideContent){
        var content = presentation.slideContent.split('\n');
        for(var index = 0; index<content.length; index+=3){
          var slide = {};
          slide.title = content[index];
          slide.content = content[index+1];
          slidesContent.push(slide);
        }
        console.log(JSON.stringify(slidesContent));
      }

      $scope.presentation.content = JSON.stringify(slidesContent);
      var slides = slideGenerator.generateSlides($scope.presentation);
      $scope.presentation.slidesImages = slides;
      console.log($scope.presentation);
    }
  });
