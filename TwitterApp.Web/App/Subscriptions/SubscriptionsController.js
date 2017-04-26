(function() {
    "use strict";

    angular.module("myApp")
        .controller("SubscriptionsController", SubscriptionsController);

    SubscriptionsController.$inject = ["SubscriptionsService", "$scope", "$http", "toastr", "$window", "$location"];

    function SubscriptionsController(subscriptionsService, $scope, $http, toastr, $window, $location) {
        var vm = this;

        vm.getUsers = getUsers;
        vm.unfollowUser = unfollowUser;
        vm.showMoreUsers = showMoreUsers;
        vm.search = search;
        vm.cancelSearch = cancelSearch;
        vm.cancelSearch = openSubscribe;
        vm.openSubscribe = openSubscribe;

        vm.users = {};

        vm.searchText = "";
        vm.usersFilter = "";
        vm.limitUsers = 20;

        $window.document.title = "Twitter - Subscriptions";

        activate();

        function activate() {
            getUsers();
        }

        //Load users
        function getUsers() {
            subscriptionsService.getUsersContent(function(data) {
                vm.users = data;
            });
        }

        //Unfollow from user
        function unfollowUser(userId, userName) {
            subscriptionsService.unsubscribeUser(userId,
                function() {
                    toastr.success(
                        "You unsubscribed from @" + userName + "!",
                        "Unsubscribed",
                        {
                            closeButton: true,
                            timeOut: 5000
                        });
                    getUsers();
                });
        }

        //Search user
        function search() {
            if (vm.searchText.length >= 1) {
                vm.usersFilter = vm.searchText;
            } else {
                getUsers();
            }
        }

        //Clear search form
        function cancelSearch() {
            if (vm.searchText.length >= 1) {
                vm.searchText = "";
                vm.usersFilter = "";
                getUsers();
            }
        }

        //load more users
        function showMoreUsers() {
            vm.limitUsers += 10;
            getUsers();
        }

        //Open subscribe page
        function openSubscribe() {
            $location.url("/Subscribe");
        };

        //load more users when user scrolls down the page (dynamic loading)
        window.onscroll = function() {
            if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight) {
                showMoreUsers();
            }
        };
    }
}());