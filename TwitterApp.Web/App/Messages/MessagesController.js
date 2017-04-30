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
        vm.getCurrentUser = getCurrentUser;

        vm.tweets = [];
        vm.users = {};
        vm.data = vm.tweets.slice(0, 20);

        $window.document.title = "Twitter - Messages";

        activate();

        function activate() {
            getCurrentUser();
        }

        //Load messages (dynamic loading)
        function getMessages() {
            messagesService.getMessagesContent()
                .then(function(data) {
                    vm.data = data.slice(0, vm.data.length + 3);
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
    }
}());