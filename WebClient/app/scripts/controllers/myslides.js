'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:MyslidesCtrl
 * @description
 * # MyslidesCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('MyslidesCtrl', function ($scope, requisition, slideGenerator) {
    requisition.get({
      url:'/slide',
      success: function(data){
        for(var index in data){
          var presentation = data[index];
          var cover = slideGenerator.generateCover(presentation);
          presentation.coverImage = cover;
        }
        $scope.presentations = data;
      },
      error: function(data){
        swal("Desculpe!", data.userMessage, "error");
      }
    });
  });
