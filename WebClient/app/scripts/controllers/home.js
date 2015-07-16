'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:HomeCtrl
 * @description
 * # HomeCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('HomeCtrl', function ($scope, requisition) {

    requisition.get({
      url:'/slides',
      success: function(data){
        console.dir(data);
        $scope.presentations = data.presentations;
      },
      error: function(data){
        //TODO arrumar esse trecho para um alert mais bonito ou uma modal
        console.log(data.userMessage);
      }
    });

});
