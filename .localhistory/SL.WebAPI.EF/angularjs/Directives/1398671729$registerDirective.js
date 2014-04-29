var shareDirectives = angular.module('share.register.directives', []);
shareDirectives.directive("registerD", function (loginAPIService) {
    return {
        restrict: 'A',
        controller: 'registerController',
        templateUrl: './angularjs/Directives/registerD.html',
        link: function ($scope, $element, $attrs) {
            //注册
            $scope.registerClick = function () {
                var user = $scope.user;
                console.info(user);
                loginAPIService.post({},user, function (response) {
                    console.info(response);
                });
                /*registerAPIService.registerInfo($scope.user).success(function (data) {
                    console.info(data);
                    if (data[0].flag) {
                        alert("ok");
                    } else {
                        alert("用户名已被注册");
                    }
                });*/
            }
        }
    };
});
