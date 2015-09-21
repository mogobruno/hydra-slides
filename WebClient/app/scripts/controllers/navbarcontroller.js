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
          url:'/account',
          data: user,
          success: function(data){
              if(data){
              var userToken = {
                token: data,
                name: user.email
              }
              localStorage.user = JSON.stringify(userToken);
              $scope.user = userToken
              $scope.hasUser = true;
              $window.location.href = '#/home';
            }else{
              swal("Desculpe!", "Login ou senha inválidos.", "error");
            }
          },
          error: function(data){
            swal("Desculpe!", data.userMessage, "error");
          }
        });
  		};

      $scope.logout = function(){
        delete localStorage.user;
        $scope.user = "";
        $scope.hasUser = false;
        $scope.menu = 1;
        $window.location.href = '#/';
      }
  });
