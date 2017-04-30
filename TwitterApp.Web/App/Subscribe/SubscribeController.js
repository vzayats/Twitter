(function() {
    "use strict";

    angular.module("myApp")
        .controller("SubscribeController", SubscribeController);

    SubscribeController.$inject = ["SubscribeService", "$scope", "$http", "toastr", "$window"];

    function SubscribeController(subscribeService, $scope, $http, toastr, $window) {
        var vm = this;

        vm.getUsers = getUsers;
        vm.followUser = followUser;
        vm.search = search;
        vm.cancelSearch = cancelSearch;

        vm.users = [];
        vm.data = vm.users.slice(0, 10);

        vm.searchText = "";
        vm.usersFilter = "";

        $window.document.title = "Twitter - Subscribe";

        activate();

        function activate() {
            getUsers();
        }

        //Load users (dynamic loading)
        function getUsers() {
            subscribeService.getUsersContent()
                .then(function(data) {
                    vm.data = data.slice(0, vm.data.length + 3);
                });
        }

        //Follow user
        function followUser(userId, userName) {
            var userData = {
                SubscribeUserId: userId
            };
            subscribeService.subscribeUser(userData)
                .then(function() {
                    toastr.success(
                        "You subscribed to @" + userName + "!",
                        "Subscribed",
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