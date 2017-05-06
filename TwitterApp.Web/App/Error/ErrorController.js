(function() {
    "use strict";

    angular.module("myApp")
        .controller("ErrorController", ErrorController);

    ErrorController.$inject = ["$scope", "$window"];

    function ErrorController($scope, $window) {

        $window.document.title = "Twitter - 404 Error";
    }
}());