var shareDirectives = angular.module('share.register.directives', []);
shareDirectives.directive("registerD", function (loginAPIService,$http) {
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

                }, function (response) { console.info(response); });

                $http({
                    method: 'POST',
                    headers: { "X-HTTP-Method-Override": "POST" },
                    url: 'odataLogin/Login',
                    params: {
                      
                    },
                    data:user,
                    withCredentials: true
                }).error(function (data, s) { console.info(data, s); });
            }
        }
    };
});
