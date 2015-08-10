'use strict';

/**
 * @ngdoc service
 * @name webClientApp.slideGenerator
 * @description
 * # slideGenerator
 * Service in the webClientApp.
 */
angular.module('webClientApp')
  .service('slideGenerator', function (slideCanvas) {
      var generateSlide = function(theme, slide){
        slideCanvas.backgroundColor(theme);
        slideCanvas.fullText(slide.content, 'white');
        return slideCanvas.getImage();
      }

      this.generateCover = function(presentation){
        slideCanvas.backgroundColor(presentation.theme);
        slideCanvas.coverTitle(presentation.title, 'white');
        slideCanvas.coverSubTitle(presentation.subTitle, 'white');
        return slideCanvas.getImage();
      }

      this.generateSlides = function(presentation){
        var slides = [];
        slides.push(this.generateCover(presentation));
        for(var index in presentation.slides){
          var slide = presentation.slides[index];
          slides.push(generateSlide(presentation.theme, slide));
        }
        return slides;
      }
  });
