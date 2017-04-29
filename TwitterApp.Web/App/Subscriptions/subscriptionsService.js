(function() {
    "use strict";

    angular
        .module("myApp")
        .factory("SubscriptionsService", SubscriptionsService);

    SubscriptionsService.$inject = ["$http"];

    function SubscriptionsService($http) {
        var service = {
            getUsersContent: getUsersContent,
            unsubscribeUser: unsubscribeUser
        };

        //Get users
        function getUsersContent() {
            return $http.get("/api/Subscribe/GetSubscribtionsUsers")
                .then(function(response) {
                    return response.data;
                })
                .catch(function() {
                    console.log("Error while retrieving users!");
                });
        };

        //Unsubscribe from user
        function unsubscribeUser(id) {
            return $http.delete("/api/Subscriptions/DeleteSubscription/" + id)
                .then(function(response) {
                    return response.data;
                })
                .catch(function() {
                    console.log("Error when unsubscribing from a user!");
                });
        };

        return service;
    }
})();