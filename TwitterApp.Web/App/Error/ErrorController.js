(function() {
    "use strict";

    angular.module("myApp")
        .controller("ErrorController", ErrorController);

    ErrorController.$inject = ["$scope", "$window", "$location"];

    function ErrorController($scope, $window, $location) {
        var vm = this;

        vm.openHomePage = openHomePage;

        $window.document.title = "Twitter - 404 Error";

        function openHomePage() {
            $location.url("/");
        };
    }
}());