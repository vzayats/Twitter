(function() {
    "use strict";

    angular
        .module("myApp")
        .factory("FeedService", FeedService);

    FeedService.$inject = ["$http"];

    function FeedService($http) {

        var service = {
            getMessagesContent: getMessagesContent,
            getUsersContent: getUsersContent
        };

        //Get messages
        function getMessagesContent() {
            return $http.get("/api/Messages/GetFollowMessages")
                .then(function(response) {
                    return response.data;
                })
                .catch(function() {
                    console.log("Error while retrieving messages!");
                });
        };

        //Get users
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