(function() {
    'use strict';

    angular
        .module('app')
        .factory('dataservice', dataservice);

    dataservice.$inject = ['$http', '$location', '$q', 'exceptions'];
    /* @ngInject */
    function dataservice($http, $location, $q, exceptions) {

        var service = {
            getMD5Checksum: getMD5Checksum
        };

        return service;

        function getMD5Checksum(url) {
            
            function getMD5ChecksumComplete(data) {
                return data.data.checksum;
            }

            return $http.post('/api/md5/',
                {
                    Url : url
                })
                .then(getMD5ChecksumComplete)
                .catch(function(message) {
                    exceptions.catcher('XHR Failed for getMD5Checksum')(message);
                    $location.url('/');
                });
        }
    }
})();
