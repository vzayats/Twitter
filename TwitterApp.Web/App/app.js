angular.module("myApp",
        ["ui.router", "toastr", "angular.filter", "angular-loading-bar", "ngAnimate", "infinite-scroll"])
    .service("authInterceptor",
        function($q) {
            var service = this;

            service.responseError = function(response) {
                if (response.status === 401) {
                    window.location = "/Account/Login";
                }
                return $q.reject(response);
            };
        })
    .config([
        "$stateProvider", "$urlRouterProvider", "$httpProvider",
        function($stateProvider, $urlRouterProvider, $httpProvider) {

            $httpProvider.interceptors.push("authInterceptor");

            $stateProvider
                .state("Messages", // Messages Page
                    {
                        url: "/",
                        templateUrl: "/App/Messages/Messages.html",
                        controller: "MessagesController",
                        controllerAs: "messagesCtrl"
                    })
                .state("Feed", // Feed Page
                    {
                        url: "/Feed",
                        templateUrl: "/App/Feed/Feed.html",
                        controller: "FeedController",
                        controllerAs: "feedCtrl"
                    })
                .state("Subscribe", // Subscribe Page
                    {
                        url: "/Subscribe",
                        templateUrl: "/App/Subscribe/Subscribe.html",
                        controller: "SubscribeController",
                        controllerAs: "subscribeCtrl"
                    })
                .state("Subscriptions", // Subscriptions Page
                    {
                        url: "/Subscriptions",
                        templateUrl: "/App/Subscriptions/Subscriptions.html",
                        controller: "SubscriptionsController",
                        controllerAs: "subscriptionsCtrl"
                    })
                .state("Error", //Error page
                    {
                        url: "/Error",
                        templateUrl: "/App/Error/Error.html",
                        controller: "ErrorController",
                        controllerAs: "errorCtrl"
                    });

            //This is when any route not matched
            $urlRouterProvider.otherwise("/");
        }
    ]);