var app = angular.module('share.mycollect.service', ['ngResource']);
app.service('myCollectAPIService', function ($http, $resource, baseUrlService) {
    var baseurl = baseUrlService.get();
       //return $resource(baseurl + "sl/collection/:colletId/",
    return $resource(baseurl + 'odata/Collections/:colletId/',
     {},
     {
         get:
           {
               method: "GET", params: {},
               headers: {
                   "X-Requested-With": "XMLHttpRequest",
                   "content-type": "application/x-www-form-urlencoded;charset=UTF-8",
                   "X-HTTP-Method-Override":"GET"
               },
               cache: true,
               withCredentials: true,
               isArray: true,
               transformRequest: function (obj) {
                   var str = [];
                   for (var p in obj) {
                       str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                   }
                   return str.join("&");
                   //return $.param(obj);
               }
           },
         post:
            {
                method: "POST", params: {},
                headers: {
                    "X-Requested-With": "XMLHttpRequest",
                    "content-type": "application/x-www-form-urlencoded;charset=UTF-8",
                    "X-HTTP-Method-Override": "POST"
                },
                cache: true,
                withCredentials: true,
                isArray: true,
                transformRequest: function (obj) {
                    var str = [];
                    for (var p in obj) {
                        str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                    }
                    return str.join("&");
                    //return $.param(obj);
                }
            }
     }
     );
});
