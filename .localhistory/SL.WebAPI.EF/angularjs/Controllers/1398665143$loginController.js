var app = angular.module("share.login.controller", []);
app.controller('loginController', function ($scope, searchAPIService) {
    //登录
    $scope.loginClick = function () {
        searchAPIService.post($scope.user).success(function (data) {
            console.info(data);
            if (data[0].flag) {
                // $scope.username = data;
                window.location.href = "myhome.html";
            }
        });
    }
});