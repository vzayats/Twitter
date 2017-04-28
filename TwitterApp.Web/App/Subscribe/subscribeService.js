(function() {
    "use strict";

    angular
        .module("myApp")
        .factory("SubscribeService", SubscribeService);

    SubscribeService.$inject = ["$http", "$window"];

    function SubscribeService($http, $window) {
        var service = {
            getUsersContent: getUsersContent,
            subscribeUser: subscribeUser
        };

        //Get users
        function getUsersContent() {
            return $http.get("/api/Subscribe/GetUsers")
                .then(function(response) {
                    return response.data;
                })
                .catch(function(error) {
                    if (error.status === 401) {
                        $window.location.href = "/Account/Login?returnurl=/";
                    }
                });
        };

        //Subscribe user
        function subscribeUser(userData) {
            return $http.post("/api/Subscriptions/PostSubscription", userData)
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