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
        function getMessagesContent(callBack) {
            $http.get("/api/Messages/")
                .then(function(response) {
                    if (callBack) {
                        callBack(response.data);
                    }
                })
                .catch(function(error) {
                    if (error.status === 401) {
                        $window.location.href = "/Account/Login?returnurl=/";
                    }
                });
        };

        //Delete message
        function deleteMessagePermanently(id, callBack) {
            $http.delete("/api/Messages/DeleteMessage/" + id)
                .then(function(response) {
                    if (callBack) {
                        callBack(response.data);
                    }
                })
                .catch(function(error) {
                    if (error.status === 401) {
                        $window.location.href = "/Account/Login?returnurl=/";
                    }
                });
        };

        //Create message
        function createTweet(messageData, callBack) {
            $http.post("/api/Messages/PostMessage", messageData)
                .then(function(response) {
                    if (callBack) {
                        callBack(response.data);
                    }
                })
                .catch(function(error) {
                    if (error.status === 401) {
                        $window.location.href = "/Account/Login?returnurl=/";
                    }
                });
        };

        //Get current user
        function getUsersContent(callBack) {
            $http.get("/api/Subscribe/GetSubscribeUsers")
                .then(function(response) {
                    if (callBack) {
                        callBack(response.data);
                    }
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