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
                loginAPIService.post({},user, function (response,status) {
                    console.info(response, status);

                }).then(function (response, status) { console.info(response, status); }, function (response, status) { console.info(response, status); });
            }
        }
    };
});
