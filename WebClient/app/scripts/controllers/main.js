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
        //TODO arrumar esse trecho para um alert mais bonito ou uma modal
        alert(data.userMessage);
      }
    });

    $scope.createUser = function(user){
  		requisition.post({
        url:'/user',
        data: user,
        success: function(data){
          alert("Usuário cadastrado com sucesso.");
        },
        error: function(data){
          //TODO arrumar esse trecho para um alert mais bonito ou uma modal
          alert(data.userMessage);
        }
      });
    };
  });
