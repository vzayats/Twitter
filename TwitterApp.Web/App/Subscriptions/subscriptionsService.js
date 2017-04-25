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
        function getUsersContent(callBack) {
            $http.get("/api/Subscribe/GetSubscribtionsUsers")
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

        //Unsubscribe from user
        function unsubscribeUser(id, callBack) {
            $http.delete("/api/Subscriptions/DeleteSubscription/" + id)
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