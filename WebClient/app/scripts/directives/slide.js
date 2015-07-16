'use strict';

/**
 * @ngdoc directive
 * @name webClientApp.directive:slide
 * @description
 * # slide
 */
angular.module('webClientApp')
  .directive('slide', function () {
    return {
      template: '<canvas></canvas>',
      restrict: 'E',
      link: function postLink(scope, element, attrs) {
        var theme = attrs.theme;
        var canvas = document.createElement('canvas');
        canvas.width = 1920;
        canvas.height = 1080;
        var context = canvas.getContext('2d');

        context.fillStyle="#3498db";
        context.fillRect(0,0,1920,1080);

        var text = 'Tigre';
        context.font="200px Verdana";
        context.fillStyle="#ffffff";
        context.fillText(text,(1920/2),(1080/2));

        var image = new Image();
      	image.src = canvas.toDataURL("image/png");
        image.className = 'img-responsive';
        element.html(image);
      }
    };
  });
