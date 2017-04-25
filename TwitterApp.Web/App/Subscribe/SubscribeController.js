(function() {
    "use strict";

    angular.module("myApp")
        .controller("SubscribeController", SubscribeController);

    SubscribeController.$inject = ["SubscribeService", "$scope", "$http", "toastr", "$window"];

    function SubscribeController(subscribeService, $scope, $http, toastr, $window) {
        var vm = this;

        vm.getUsers = getUsers;
        vm.followUser = followUser;
        vm.showMoreUsers = showMoreUsers;
        vm.search = search;
        vm.cancelSearch = cancelSearch;

        vm.users = {};

        vm.searchText = "";
        vm.usersFilter = "";
        vm.limitUsers = 20;

        $window.document.title = "Twitter - Subscribe";

        activate();

        function activate() {
            getUsers();
        }

        //Load users
        function getUsers() {
            subscribeService.getUsersContent(function(data) {
                vm.users = data;
            });
        }

        //Follow user
        function followUser(userId, userName) {
            var userData = {
                SubscribeUserId: userId
            };
            subscribeService.subscribeUser(userData,
                function() {
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

        //load more users
        function showMoreUsers() {
            vm.limitUsers += 10;
            getUsers();
        }

        //load more users when user scrolls down the page (dynamic loading)
        window.onscroll = function() {
            if ((window.innerHeight + window.scrollY) >= document.body.offsetHeight) {
                showMoreUsers();
            }
        };
    }
}());