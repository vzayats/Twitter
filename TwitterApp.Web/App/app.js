angular.module("myApp",
        ["ngRoute", "toastr", "angular.filter"])
    .config([
        "$routeProvider",
        function($routeProvider) {

            $routeProvider
                .when("/", // Home Page
                {
                    templateUrl: "/App/Messages/Messages.html",
                    controller: "MessagesController",
                    controllerAs: "messagesCtrl"
                })
                .when("/Feed", // Feed Page
                {
                    templateUrl: "/App/Feed/Feed.html",
                    controller: "FeedController",
                    controllerAs: "feedCtrl"
                })
                .when("/Subscribe", // Subscribe Page
                {
                    templateUrl: "/App/Subscribe/Subscribe.html",
                    controller: "SubscribeController",
                    controllerAs: "subscribeCtrl"
                })
                .when("/Subscriptions", // Subscriptions Page
                {
                    templateUrl: "/App/Subscriptions/Subscriptions.html",
                    controller: "SubscriptionsController",
                    controllerAs: "subscriptionsCtrl"
                })
                .otherwise({ // This is when any route not matched - error
                    templateUrl: "/App/Error/Error.html",
                    controller: "ErrorController",
                    controllerAs: "errorCtrl"
                });
        }
    ]);