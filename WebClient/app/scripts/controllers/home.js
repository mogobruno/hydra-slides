'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:HomeCtrl
 * @description
 * # HomeCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('HomeCtrl', function ($scope, requisition, slideGenerator) {

    requisition.get({
      url:'/slide',
      success: function(data){
        console.log(data);
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
