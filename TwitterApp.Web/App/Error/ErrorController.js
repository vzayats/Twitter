(function() {
    "use strict";

    angular.module("myApp")
        .controller("ErrorController", ErrorController);

    ErrorController.$inject = ["$scope", "$window"];

    function ErrorController($scope, $window) {
        var vm = this;

        vm.openHomePage = openHomePage;

        $window.document.title = "Twitter - 404 Error";

        function openHomePage() {
            $window.location.href = '/';
        };
    }
}());