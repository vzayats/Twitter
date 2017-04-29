(function() {
    "use strict";

    angular
        .module("myApp")
        .factory("SubscribeService", SubscribeService);

    SubscribeService.$inject = ["$http"];

    function SubscribeService($http) {
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
                .catch(function() {
                    console.log("Error while retrieving users!");
                });
        };

        //Subscribe user
        function subscribeUser(userData) {
            return $http.post("/api/Subscriptions/PostSubscription", userData)
                .then(function(response) {
                    return response.data;
                })
                .catch(function() {
                    console.log("Error when subscribing user!");
                });
        };

        return service;
    }
})();