'use strict';

/**
 * @ngdoc service
 * @name webClientApp.requisition
 * @description
 * # requisition
 * Service in the webClientApp.
 */
angular.module('webClientApp')
  .service('requisition', function ($http, serviceUrl) {

    var httpRequesition = function(params){
      params.data = params.data || {};
      if(params.authentication){
        params.data.token = sessionStorage.token;
      }
      console.info('post:login:data'+JSON.stringify(params.data));
      $http({
        method:params.type,
        url: serviceUrl + params.url,
        headers: params.headers,
        data: params.data
      }).success(function(data){ //, status, headers, config
        if(data.error){
          params.error(data);
        }else{
          sessionStorage.token = data.token;
          params.success(data);
        }
      }).error(function(data){ //, status, headers, config
        var data = data || {};
        data.userMessage = 'Erro de comunicação com o servidor, tente novamente mais tarde.';
        params.error(data);
      });
    };

    this.get = function(params){
      params.type = 'get';
      httpRequesition(params);
    };

    this.post = function(params){
      params.type = 'post';
      httpRequesition(params);
    };

    this.put = function(params){
      params.type = 'put';
      httpRequesition(params);
    };

    this.delete = function(params){
      params.type = 'delete';
      httpRequesition(params);
    };

  });
