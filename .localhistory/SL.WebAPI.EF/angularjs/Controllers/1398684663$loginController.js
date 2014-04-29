var app = angular.module("share.login.controller", []);
app.controller('loginController', function ($scope, loginAPIService, baseUrlService) {
    //登录
    $scope.loginClick = function () {
        loginAPIService.get({}, $scope.user, function (response) {
            console.info(response);
        });


        $http({
            method: 'POST',
            headers: { "X-HTTP-Method-Override": "GET" },
            url: baseurl + 'odataLogin/Login',
            params: {

            },
            withCredentials: true
        }).success(function (data,status) {
            console.info(data, status);
            if (data[0].flag) {
                // $scope.username = data;
                window.location.href = "myhome.html";
            }
        });
    }
});