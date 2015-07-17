'use strict';

/**
 * @ngdoc directive
 * @name webClientApp.directive:slide
 * @description
 * # slide
 */
angular.module('webClientApp')
  .directive('slide', function () {
    var createSlide = function(scope, element, attrs){
      if(scope.presentation){
        var theme = scope.presentation.theme;
        var title = scope.presentation.title;
        var subtitle = scope.presentation.subTitle;

        var canvas = document.createElement('canvas');
        canvas.width = 1920;
        canvas.height = 1080;
        var context = canvas.getContext('2d');

        context.fillStyle = theme;
        context.fillRect(0,0,1920,1080);

        var x = canvas.width / 2;
        var y = canvas.height / 2;

        context.font = '100pt Calibri';
        context.textAlign = 'center';
        context.fillStyle = 'white';

        context.fillText(title, x, y);

        context.font = '50pt Calibri';
        context.textAlign = 'center';
        context.fillStyle = 'white';
        context.fillText(subtitle, x, y+150);


        var image = new Image();
        image.src = canvas.toDataURL("image/png");
        image.className = 'img-responsive';
        element.html(image);
      }
    }

    var link = function(scope, element, attrs){
      scope.$watchCollection('presentation', function(){
        createSlide(scope, element, attrs);
      });
    }
    return {
      restrict: 'E',
      link: link
    };
  });
