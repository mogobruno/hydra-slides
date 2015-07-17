'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:SlideCtrl
 * @description
 * # SlideCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('SlideCtrl', function ($scope, requisition) {
    //TODO trocar o 1 pelo id da rota em $routeParam ou $stateParam
    requisition.get({
      url:'/slide/1',
      success: function(data){
        console.dir(data.presentation);
        $scope.presentation = data.presentation;
      },
      error: function(data){
        //TODO arrumar esse trecho para um alert mais bonito ou uma modal
        console.log(data.userMessage);
      }
    });
  });
