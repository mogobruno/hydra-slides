'use strict';

/**
 * @ngdoc function
 * @name webClientApp.controller:EditslideCtrl
 * @description
 * # EditslideCtrl
 * Controller of the webClientApp
 */
angular.module('webClientApp')
  .controller('EditslideCtrl', function ($scope, $routeParams, $location, requisition, slideGenerator) {
    
	$scope.view = {
      title : "Editar Slide"
    };

    requisition.get({
      url:'/slide/'+$routeParams.id,
      success: function(data){
        var slides = slideGenerator.generateSlides(data);
        data.slidesImages = slides;
        $scope.presentation = data;
        $scope.actualImage = $scope.presentation.slidesImages[$scope.index];
        stringifySlideContent(data.content);
      },
      error: function(data){
        swal("Desculpe!", data.userMessage, "error");
      }
    });
    

    $scope.renderPreview = function(presentation){
      generateSlides(presentation);
    }

    var stringifySlideContent = function(content){
    	
    	var stringContent = "";
    	for(var index in content){
    		console.log(content[index]);
    		var slide = content[index];
    		stringContent += slide.title.concat("\n");
    		stringContent += slide.content.concat("\n\n");
    		console.log(stringContent);
    	}
    	$scope.presentation.slideContent = stringContent;
    }

    var generateSlides = function(presentation){
      var slidesContent = [];
      if(presentation.slideContent){
        var content = presentation.slideContent.split('\n');
        for(var index = 0; index<content.length; index+=3){
          var slide = {};
          slide.title = content[index];
          slide.content = content[index+1];
          slidesContent.push(slide);
        }
      }

      $scope.presentation.content = JSON.stringify(slidesContent);
      var slides = slideGenerator.generateSlides($scope.presentation);
      $scope.presentation.slidesImages = slides;
    }

    $scope.save = function(presentation){

      requisition.put({
          url:'/slide/'+$routeParams.id,
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
                title: "Apresentação atualizada!",
                text: "A apresentação "+presentation.title+" foi ataulizada com sucesso!",
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
            swal("Desculpe!", data.userMessage, "error");
          }
        });
    }
  });
