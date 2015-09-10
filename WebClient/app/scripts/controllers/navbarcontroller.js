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
      var user = localStorage.user;

      console.log(localStorage.user);

      if(user){
          $scope.hasUser = true;
          $scope.user = JSON.parse(user);
          //$window.location.href = '#/home';
      }else{
          $scope.hasUser = false;
          $window.location.href = '#/';
      }

      $scope.menu = 1;

  		$scope.login = function(user){
  			requisition.post({
          url:'/loginfake',
          data: user,
          success: function(data){
            localStorage.user = JSON.stringify(data);
            console.dir(data.name);
            $scope.hasUser = true;
            $window.location.href = '#/home';
          },
          error: function(data){
            swal("Desculpe!", data.userMessage, "error");
          }
        });
  		};

      $scope.logout = function(){
        requisition.post({
          url:'/logoutfake',
          authentication: true,
          success: function(data){
            delete localStorage.user;
            console.dir(data);
            $scope.hasUser = false;
            $scope.menu = 1;
            $window.location.href = '#/';
          },
          error: function(data){
            swal("Desculpe!", data.userMessage, "error");
          }
        });
      }
  });
