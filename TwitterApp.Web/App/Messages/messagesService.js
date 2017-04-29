(function() {
    "use strict";

    angular
        .module("myApp")
        .factory("MessagesService", MessagesService);

    MessagesService.$inject = ["$http"];

    function MessagesService($http) {

        var service = {
            getMessagesContent: getMessagesContent,
            deleteMessagePermanently: deleteMessagePermanently,
            createTweet: createTweet,
            getUsersContent: getUsersContent
        };

        //Get messages
        function getMessagesContent() {
            return $http.get("/api/Messages/")
                .then(function(response) {
                    return response.data;
                })
                .catch(function() {
                    console.log("Error while retrieving messages!");
                });
        };

        //Delete message
        function deleteMessagePermanently(id) {
            return $http.delete("/api/Messages/DeleteMessage/" + id)
                .then(function(response) {
                    return response.data;
                })
                .catch(function() {
                    console.log("Error when deleting message!");
                });
        };

        //Create message
        function createTweet(messageData) {
            return $http.post("/api/Messages/PostMessage", messageData)
                .then(function(response) {
                    return response.data;
                })
                .catch(function() {
                    console.log("Error while creating message!");
                });
        };

        //Get current user
        function getUsersContent() {
            return $http.get("/api/Subscribe/GetSubscribeUsers")
                .then(function(response) {
                    return response.data;
                })
                .catch(function() {
                    console.log("Error while retrieving current user!");
                });
        };

        return service;
    }
})();