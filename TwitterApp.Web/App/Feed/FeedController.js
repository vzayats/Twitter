(function() {
    "use strict";

    angular.module("myApp")
        .controller("FeedController", FeedController);

    FeedController.$inject = ["FeedService", "$scope", "$http", "$window", "$location"];

    function FeedController(feedService, $scope, $http, $window, $location) {
        var vm = this;

        vm.getMessages = getMessages;
        vm.getUsers = getUsers;
        vm.userPage = userPage;
        vm.openSubscribe = openSubscribe;

        vm.tweets = [];
        vm.users = {};
        vm.data = vm.tweets.slice(0, 20);

        $window.document.title = "Twitter - Feed";

        activate();

        function activate() {
            getUsers();
            getMessages();
        }

        //Load messages (dynamic loading)
        function getMessages() {
            feedService.getMessagesContent()
                .then(function(data) {
                    vm.data = data.slice(0, vm.data.length + 3);
                });
        }

        //Load user
        function getUsers() {
            feedService.getUsersContent()
                .then(function(data) {
                    vm.users = data;
                });
        }

        //Open user page
        function userPage() {
            $location.url("/");
        };

        //Open subscribe page
        function openSubscribe() {
            $location.url("/Subscribe");
        };
    }
}());