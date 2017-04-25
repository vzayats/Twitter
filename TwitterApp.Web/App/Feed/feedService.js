(function() {
    "use strict";

    angular
        .module("myApp")
        .factory("FeedService", FeedService);

    FeedService.$inject = ["$http", "$window"];

    function FeedService($http, $window) {

        var service = {
            getMessagesContent: getMessagesContent,
            getUsersContent: getUsersContent
        };

        //Get messages
        function getMessagesContent(callBack) {
            $http.get("/api/Messages/GetFollowMessages")
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

        //Get users
        function getUsersContent(callBack) {
            $http.get("/api/Subscribe/GetSubscribeUsers")
                .then(function (response) {
                    if (callBack) {
                        callBack(response.data);
                    }
                })
                .catch(function (error) {
                    if (error.status === 401) {
                        $window.location.href = "/Account/Login?returnurl=/";
                    }
                });
        };

        return service;
    }
})();