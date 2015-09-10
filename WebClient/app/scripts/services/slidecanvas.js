'use strict';

/**
 * @ngdoc service
 * @name webClientApp.slideCanvas
 * @description
 * # slideCanvas
 * Service in the webClientApp.
 */
angular.module('webClientApp')
  .service('slideCanvas', function () {
    var canvas = document.createElement('canvas');
    canvas.width = 1366;
    canvas.height = 768;
    var context = canvas.getContext('2d');

    function wrapText(context, text, x, y, maxWidth, lineHeight) {
        var words = text.split(' ');
        var line = '';

        for(var n = 0; n < words.length; n++) {
          var testLine = line + words[n] + ' ';
          var metrics = context.measureText(testLine);
          var testWidth = metrics.width;
          if (testWidth > maxWidth && n > 0) {
            context.fillText(line, x, y);
            line = words[n] + ' ';
            y += lineHeight;
          }
          else {
            line = testLine;
          }
        }
        context.fillText(line, x, y);
      }

    this.coverTitle = function(value, color){
      context.font = '110px Calibri';
      context.textAlign = 'center';
      context.fillStyle = color;
      context.fillText(value, canvas.width/2, canvas.height/2);
    }

    this.coverSubTitle = function(value, color){
      context.font = '60px Calibri';
      context.textAlign = 'center';
      context.fillStyle = color;
      context.fillText(value, canvas.width/2, (canvas.height/2)+150);
    }

    this.slideTitle = function(value, color){
      context.font = '60px Calibri';
      context.textAlign = 'left';
      context.fillStyle = color;
      var startTextWidth = canvas.width*0.1;
      var startTextHeight = canvas.height*0.16;
      context.fillText(value, startTextWidth, startTextHeight);
    }

    this.fullText = function(value, color){
      context.font = '30px Calibri';
      context.textAlign = 'left';
      context.fillStyle = color;
      var startTextWidth = canvas.width*0.1;
      var startTextHeight = canvas.height*0.3;
      var maxWidth = canvas.width*0.82;
      var lineHeight = 45;
      wrapText(context, value, startTextWidth, startTextHeight, maxWidth, lineHeight);
    }

    this.textLeft = function(value, color){
      context.font = '35px Calibri';
      context.fillStyle = color;
      var startTextWidth = canvas.width*0.3;
      var startTextHeight = canvas.height*0.3;
      var maxWidth = canvas.width*0.45;
      var lineHeight = 45;
      wrapText(context, value, startTextWidth, startTextHeight, maxWidth, lineHeight);
    }

    this.backgroundColor = function(color){
      context.fillStyle = color;
      context.fillRect(0,0,canvas.width,canvas.height);
    }

    this.getImage= function(){
      return canvas.toDataURL("image/png");
    }
  });
