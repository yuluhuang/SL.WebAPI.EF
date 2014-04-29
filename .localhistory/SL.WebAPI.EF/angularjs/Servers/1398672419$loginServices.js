var app = angular.module('share.login.service', ['ngResource']);
app.service('loginAPIService', function ($resource, $http, baseUrlService) {
    var baseurl = baseUrlService.get();
    return $resource(baseurl + "odataLogin/Login",
        {},
        {
            get:
           {
               method: "POST", params: {},
               headers: {
                   "X-HTTP-Method-Override": "GET"
               },
               cache: true,
               withCredentials: true,
               isArray: false
           },
            post:
               {
                   method: "POST", params: {},
                   headers: {
                       "X-HTTP-Method-Override": "POST"
                   },
                   cache: true,
                   withCredentials: true,
                   isArray: true
               },
            put:
               {
                   method: "POST", params: {},
                   headers: {
                       "X-HTTP-Method-Override": "PUT"
                   },
                   cache: true,
                   withCredentials: true,
                   isArray: true

               },
            delete:
              {
                  method: "POST", params: {},
                  headers: {
                      "X-HTTP-Method-Override": "DELETE"
                  },
                  cache: true,
                  withCredentials: true,
                  isArray: true

              }
        }
        );
});


/*
app.service('loginAPIService', function ($http, baseUrlService) {
    var baseurl = baseUrlService.get();
    var loginAPI = {};
    loginAPI.loginInfo = function (user) {
        return $http({
            method: 'POST',
            headers: { "X-Requested-With": "XMLHttpRequest" },
            url: baseurl + 'ashx/LoginHandler.ashx',
            params: {
                flag: "login",
                username: user.username,
                password: user.password
            },
            withCredentials: true
        });
    }
    loginAPI.islogin = function () {
        return $http({
            method: 'POST',
            headers: { "X-Requested-With": "XMLHttpRequest" },
            url: baseurl + 'ashx/LoginHandler.ashx',
            params: {
                flag: "islogin"
            },
            withCredentials: true
        });
    }

    loginAPI.logout = function () {
        return $http({
            method: 'POST',
            headers: { "X-Requested-With": "XMLHttpRequest" },
            url: baseurl + 'ashx/LoginHandler.ashx',
            params: {
                flag: "logout"
            },
            withCredentials: true
        });
    }
    return loginAPI;
});*/

