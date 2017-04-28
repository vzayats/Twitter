(function() {
    "use strict";

    angular
        .module("myApp")
        .factory("SubscriptionsService", SubscriptionsService);

    SubscriptionsService.$inject = ["$http", "$window"];

    function SubscriptionsService($http, $window) {
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
                .catch(function(error) {
                    if (error.status === 401) {
                        $window.location.href = "/Account/Login?returnurl=/";
                    }
                });
        };

        //Unsubscribe from user
        function unsubscribeUser(id) {
            return $http.delete("/api/Subscriptions/DeleteSubscription/" + id)
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