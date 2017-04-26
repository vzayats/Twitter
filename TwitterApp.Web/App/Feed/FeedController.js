(function () {
    "use strict";

    angular.module("myApp")
        .controller("FeedController", FeedController);

    FeedController.$inject = ["FeedService", "$scope", "$http", "$window"];

    function FeedController(feedService, $scope, $http, $window) {
        var vm = this;

        vm.getMessages = getMessages;
        vm.showMoreTweets = showMoreTweets;
        vm.getUsers = getUsers;
        vm.userPage = userPage;

        vm.tweets = {};
        vm.users = {};
        vm.limitTweets = 20;

        $window.document.title = "Twitter - Feed";

        activate();

        function activate() {
            getMessages();
            getUsers();
        }

        //Load messages
        function getMessages() {
            feedService.getMessagesContent(function (data) {
                vm.tweets = data;
            });
        }

        //load more messages
        function showMoreTweets() {
            vm.limitTweets += 10;
            getMessages();
        }

        //Load user
        function getUsers() {
            feedService.getUsersContent(function (data) {
                vm.users = data;
            });
        }

        //Open user page
        function userPage() {
            $window.location.href = "/";
        };

        //load more messages when user scrolls down the page (dynamic loading)
        window.onscroll = function () {
            if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight) {
                showMoreTweets();
            }
        };
    }
}());