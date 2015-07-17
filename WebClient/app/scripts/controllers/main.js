'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('MainCtrl', function ($scope, requisition, slideGenerator) {

    requisition.get({
      url:'/deslogado/slides',
      success: function(data){
        for(var index in data.presentations){
          var presentation = data.presentations[index];
          var cover = slideGenerator.generateCover(presentation);
          presentation.coverImage = cover;
        }
        $scope.presentations = data.presentations;
        console.log($scope.presentations);
      },
      error: function(data){
        //TODO arrumar esse trecho para um alert mais bonito ou uma modal
        console.log(data.userMessage);
      }
    });

    $scope.createUser = function(user){
  		requisition.post({
        url:'/user',
        data: user,
        success: function(data){
          console.log(data.userMessage);
        },
        error: function(data){
          //TODO arrumar esse trecho para um alert mais bonito ou uma modal
          console.log(data.userMessage);
        }
      });
    };
  });
