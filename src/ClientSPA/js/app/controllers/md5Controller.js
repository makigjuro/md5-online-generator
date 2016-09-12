(function() {
    'use strict';

    angular
        .module('app')
        .controller('MD5', MD5);

    MD5.$inject = ['dataservice'];
    /* @ngInject */
    function MD5(dataservice) {
        var vm = this;
        vm.url = '';
        vm.checksum = '';
        vm.getMD5ChecksumHandler = getMD5ChecksumHandler;
        vm.title = 'MD5 Checksum Generator for Websites';

        function getMD5ChecksumHandler() {
            vm.checksum = '';
           
            return dataservice.getMD5Checksum(encodeURIComponent(vm.url)).then(function (data) {
                vm.checksum = data;
                return vm.cheksum;
            });
        }
    }
})();
