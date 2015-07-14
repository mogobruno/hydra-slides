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
      var token = sessionStorage.token;
      if(token){
          $scope.hasUser = true;
          $window.location.href = '#/home';
      }else{
          $scope.hasUser = false;
          $window.location.href = '#/';
      }

  		$scope.login = function(user){
  			requisition.post({
          url:'/login',
          data: user,
          success: function(data){
            console.dir(data.user.name);
            $scope.hasUser = true;
            $window.location.href = '#/home';
          },
          error: function(data){
            //TODO arrumar esse trecho para um alert mais bonito ou uma modal
            console.err(data.userMessage);
          }
        });
  		};

      $scope.logout = function(){
        requisition.post({
          url:'/logout',
          authentication: true,
          success: function(data){
            console.dir(data);
            $scope.hasUser = false;
            $window.location.href = '#/';
          },
          error: function(data){
            //TODO arrumar esse trecho para um alert mais bonito ou uma modal
            console.err(data.userMessage);
          }
        });
      }
  });
