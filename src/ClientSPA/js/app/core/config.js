(function() {
    'use strict';

    var appcore = angular.module('app');

    appcore.constant('toastr', toastr);

    appcore
        .config(['$httpProvider', function($httpProvider) {
            $httpProvider.interceptors.push('LoadingInterceptor');
        }])
        .service('LoadingInterceptor', ['$q', '$rootScope', '$log',
        function ($q, $rootScope, $log) {

            var xhrCreations = 0;
            var xhrResolutions = 0;

            function isLoading() {
                return xhrResolutions < xhrCreations;
            }

            function updateStatus() {
                $rootScope.loading = isLoading();
            }

            return {
                request: function (config) {
                    xhrCreations++;
                    updateStatus();
                    return config;
                },
                requestError: function (rejection) {
                    xhrResolutions++;
                    updateStatus();
                    $log.error('Request error:', rejection);
                    return $q.reject(rejection);
                },
                response: function (response) {
                    xhrResolutions++;
                    updateStatus();
                    return response;
                },
                responseError: function (rejection) {
                    xhrResolutions++;
                    updateStatus();
                    $log.error('Response error:', rejection);
                    return $q.reject(rejection);
                }
            };
        }]);

    appcore.config(toastrConfig);

    toastrConfig.$inject = ['toastr'];
    /* @ngInject */
    function toastrConfig(toastr) {
        toastr.options.timeOut = 4000;
        toastr.options.positionClass = 'toast-bottom-right';
    }

    var config = {
        appErrorPrefix: '[MD5Generator Error] ', 
        appTitle: 'MD5Generator'
    };

    appcore.value('config', config);
})();
