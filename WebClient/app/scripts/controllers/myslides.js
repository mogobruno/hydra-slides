'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:MyslidesCtrl
 * @description
 * # MyslidesCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('MyslidesCtrl', function ($scope, requisition, slideGenerator) {
    requisition.get({
      url:'/slide',
      success: function(data){
        for(var index in data){
          var presentation = data[index];
          var cover = slideGenerator.generateCover(presentation);
          presentation.coverImage = cover;
        }
        $scope.presentations = data;
      },
      error: function(data){
        swal("Desculpe!", data.userMessage, "error");
      }
    });

    $scope.deleteSlide = function(slide){
      swal({
        title: "Você tem certeza?",
        text: "Não sera possivel recuperar essa apresentação após ela ter sido apagada!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "deletar!",
        closeOnConfirm: false }, 
        function(){   
          requisition.delete({
            url:'/slide/'+slide.id,
            success: function(data){
              for(var index in $scope.presentations){
                var presentation = $scope.presentations[index];
                if(presentation.id === slide.id){
                  $scope.presentations.splice(index, 1);
                }
              }
              swal("Slide Deletado!", "Slide deletado com sucesso!", "success");
            },
            error: function(data){
              swal("Desculpe!", data.userMessage, "error");
            }
          });
        }
      );
    };

  });
