(function() {
    "use strict";

    angular
        .module("myApp")
        .factory("MessagesService", MessagesService);

    MessagesService.$inject = ["$http", "$window"];

    function MessagesService($http, $window) {

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
                .catch(function(error) {
                    if (error.status === 401) {
                        $window.location.href = "/Account/Login?returnurl=/";
                    }
                });
        };

        //Delete message
        function deleteMessagePermanently(id) {
            return $http.delete("/api/Messages/DeleteMessage/" + id)
                .then(function(response) {
                    return response.data;
                })
                .catch(function(error) {
                    if (error.status === 401) {
                        $window.location.href = "/Account/Login?returnurl=/";
                    }
                });
        };

        //Create message
        function createTweet(messageData) {
            return $http.post("/api/Messages/PostMessage", messageData)
                .then(function(response) {
                    return response.data;
                })
                .catch(function(error) {
                    if (error.status === 401) {
                        $window.location.href = "/Account/Login?returnurl=/";
                    }
                });
        };

        //Get current user
        function getUsersContent() {
            return $http.get("/api/Subscribe/GetSubscribeUsers")
                .then(function(response) {
                    return response.data;
                })
                .catch(function(error) {
                    if (error.status === 401) {
                        $window.location.href = "/Account/Login?returnurl=/";
                    }
                });
        };

        return service;
    }
})();