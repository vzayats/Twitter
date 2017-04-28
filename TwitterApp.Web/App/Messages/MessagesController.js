(function() {
    "use strict";

    angular.module("myApp")
        .controller("MessagesController", MessagesController);

    MessagesController.$inject = ["MessagesService", "$scope", "$http", "toastr", "$window"];

    function MessagesController(messagesService, $scope, $http, toastr, $window) {
        var vm = this;

        vm.getMessages = getMessages;
        vm.createTweet = createTweet;
        vm.removeTweet = removeTweet;
        vm.showMoreTweets = showMoreTweets;
        vm.getCurrentUser = getCurrentUser;

        vm.tweets = {};
        vm.users = {};
        vm.limitTweets = 20;

        $window.document.title = "Twitter - Messages";

        activate();

        function activate() {
            getCurrentUser();
            getMessages();
        }

        //Load messages
        function getMessages() {
            messagesService.getMessagesContent()
                .then(function(data) {
                    vm.tweets = data;
                });
        }

        //Create tweet
        function createTweet() {
            var messageData = {
                Tweet: $scope.Tweet
            };
            messagesService.createTweet(messageData)
                .then(function() {
                    getMessages();
                    toastr.success(
                        "Message was successfully posted!",
                        "Posted",
                        {
                            closeButton: true,
                            timeOut: 5000
                        });
                    $scope.Tweet = null;
                });
        }

        //Remove tweet
        function removeTweet(id) {
            swal({
                    title: "Deleting message!",
                    text: "Are you sure that you want to delete a message?",
                    type: "warning",
                    showCancelButton: true,
                    confirmButtonColor: "#DD6B55",
                    confirmButtonText: "Yes, delete it!",
                    closeOnConfirm: false
                },
                function() {
                    messagesService.deleteMessagePermanently(id)
                        .then(function() {
                            getMessages();
                            swal({
                                title: "Deleted!",
                                text: "Message deleted successfully",
                                timer: 2000,
                                showConfirmButton: false,
                                type: "success"
                            });
                        });
                });
        }

        //Load current user
        function getCurrentUser() {
            messagesService.getUsersContent()
                .then(function(data) {
                    vm.users = data;
                });
        }

        //load more messages
        function showMoreTweets() {
            vm.limitTweets += 10;
            getMessages();
        }

        //load more messages when user scrolls down the page (dynamic loading)
        window.onscroll = function() {
            if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight) {
                showMoreTweets();
            }
        };
    }
}());