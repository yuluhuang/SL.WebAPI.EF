var app = angular.module("share.login.controller", []);
app.controller('loginController', function ($scope, loginAPIService, baseUrlService) {
    //登录
    $scope.loginClick = function () {
        loginAPIService.get({}, $scope.user, function (response) {
            console.info(response);
        });


            /*($scope.user).success(function (data) {
            console.info(data);
            if (data[0].flag) {
                // $scope.username = data;
                window.location.href = "myhome.html";
            }
        });*/
    }
});