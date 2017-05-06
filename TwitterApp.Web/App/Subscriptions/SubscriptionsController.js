(function() {
    "use strict";

    angular.module("myApp")
        .controller("SubscriptionsController", SubscriptionsController);

    SubscriptionsController.$inject = ["SubscriptionsService", "$scope", "$http", "toastr", "$window"];

    function SubscriptionsController(subscriptionsService, $scope, $http, toastr, $window) {
        var vm = this;

        vm.getUsers = getUsers;
        vm.unfollowUser = unfollowUser;
        vm.search = search;
        vm.cancelSearch = cancelSearch;

        vm.users = [];
        vm.data = vm.users.slice(0, 10);

        vm.searchText = "";
        vm.usersFilter = "";

        $window.document.title = "Twitter - Subscriptions";

        activate();

        function activate() {
            getUsers();
        }

        //Load users (dynamic loading)
        function getUsers() {
            subscriptionsService.getUsersContent()
                .then(function(data) {
                    vm.data = data.slice(0, vm.data.length + 3);
                });
        }

        //Unfollow from user
        function unfollowUser(userId, userName) {
            subscriptionsService.unsubscribeUser(userId)
                .then(function() {
                    getUsers();
                    toastr.success(
                        "You unsubscribed from @" + userName + "!",
                        "Unsubscribed",
                        {
                            closeButton: true,
                            timeOut: 5000
                        });
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
    }
}());