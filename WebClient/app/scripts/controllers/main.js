'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('MainCtrl', function ($scope, requisition) {
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
