'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:NewslideCtrl
 * @description
 * # NewslideCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('NewslideCtrl', function ($scope, $location, requisition, slideGenerator) {
    
    if(localStorage.presentation){
      $scope.presentation = JSON.parse(localStorage.presentation);  
    }else{
      $scope.presentation = {};
    }
    

    $scope.renderPreview = function(presentation){
      generateSlides(presentation);
    }

    var generateSlides = function(presentation){
      console.log(presentation);
      var slidesContent = [];
      if(presentation.slideContent){
        var content = presentation.slideContent.split('\n');
        for(var index = 0; index<content.length; index+=3){
          var slide = {};
          slide.title = content[index];
          slide.content = content[index+1];
          slidesContent.push(slide);
        }
        console.log(JSON.stringify(slidesContent));
      }

      $scope.presentation.content = JSON.stringify(slidesContent);
      var slides = slideGenerator.generateSlides($scope.presentation);
      $scope.presentation.slidesImages = slides;
      console.log($scope.presentation);
      localStorage.presentation = JSON.stringify($scope.presentation);
    }

    $scope.save = function(presentation){

      requisition.post({
          url:'/slide',
          authentication: true,
          data: {
              "title":presentation.title,
              "content":JSON.stringify(presentation.content),
              "description":presentation.description,
              "theme":presentation.theme,
              "subtitle":presentation.subTitle
          },
          success: function(data){
            swal(
              {
                title: "Apresentação salva!",
                text: "A apresentação "+presentation.title+" foi salva com sucesso!",
                type: "success",
              }, 
              function(){
                delete localStorage.presentation;
                $location.path("/home");
                $scope.$apply();
              }
            );
          },
          error: function(data){
            console.log(data);
            swal("Desculpe!", data.userMessage, "error");
          }
        });
    }
  });
