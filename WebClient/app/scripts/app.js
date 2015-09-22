'use strict';

/**
 * @ngdoc overview
 * @name webClientApp
 * @description
 * # webClientApp
 *
 * Main module of the application.
 */
angular
  .module('webClientApp', [
    'ngAnimate',
    'ngCookies',
    'ngResource',
    'ngRoute',
    'ngSanitize',
    'ngTouch',
    'angular-loading-bar',
    'FBAngular'
  ])
  .config(function ($routeProvider) {
    $routeProvider
      .when('/', {
        templateUrl: 'views/main.html',
        controller: 'MainCtrl',
        controllerAs: 'main'
      })
      .when('/home', {
        templateUrl: 'views/home.html',
        controller: 'HomeCtrl',
        controllerAs: 'home'
      })
      .when('/my/slides', {
        templateUrl: 'views/myslides.html',
        controller: 'MyslidesCtrl',
        controllerAs: 'myslides'
      })
      .when('/new/slide', {
        templateUrl: 'views/newslide.html',
        controller: 'NewslideCtrl',
        controllerAs: 'newslide'
      })
      .when('/edit/slide/:id', {
        templateUrl: 'views/newslide.html',
        controller: 'EditslideCtrl',
        controllerAs: 'editslide'
      })
      .when('/me', {
        templateUrl: 'views/me.html',
        controller: 'MeCtrl',
        controllerAs: 'me'
      })
      .when('/slide/:id', {
        templateUrl: 'views/slide.html',
        controller: 'SlideCtrl',
        controllerAs: 'slide'
      })
      .otherwise({
        redirectTo: '/'
      });
  })
  .value('serviceUrl', 'http://localhost:61807/hydra/api');

