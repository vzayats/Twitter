(function() {
    "use strict";

    angular.module("myApp")
        .controller("FeedController", FeedController);

    FeedController.$inject = ["FeedService", "$scope", "$http", "$window"];

    function FeedController(feedService, $scope, $http, $window) {
        var vm = this;

        vm.getMessages = getMessages;
        vm.getUsers = getUsers;

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
    }
}());