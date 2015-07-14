'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:NavbarcontrollerCtrl
 * @description
 * # NavbarcontrollerCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('NavbarcontrollerCtrl', function ($scope, requisition, $window) {
      $scope.hasUser = false;

  		$scope.login = function(user){
  			requisition.post({
          url:'/login',
          data: user,
          success: function(data){
            console.dir(data);
            $scope.user = data.user;
            $scope.hasUser = true;
            $window.location.href = '#/home?name='+data.user.name;
          },
          error: function(data){
            //TODO arrumar esse trecho para um alert mais bonito ou uma modal
            console.err(data.userMessage);
          }
        });
  		};
  });
