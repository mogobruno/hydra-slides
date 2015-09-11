'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:MeCtrl
 * @description
 * # MeCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('MeCtrl', function ($scope, requisition) {

      if(localStorage.user){
      	$scope.user = JSON.parse(localStorage.user);
      }

      $scope.saveUser = function(user){
      	requisition.put({
	      url:'/user/'+user.id,
	      authentication: true,
	      data: {
		    "name": user.name,
		    "email": user.email,
		    "nationality": user.nationality,
		    "job": user.job
		  },
	      success: function(data){
	      	console.log(user);
	      	localStorage.user = JSON.stringify(user);
	      	$scope.item = "";
	        swal("Dados salvos!", "Obrigado por manter seu cadastro atualizado! =D", "success");
	      },
	      error: function(data){
	        swal("Desculpe!", data.userMessage, "error");
	      }
	    })
      }
  });
