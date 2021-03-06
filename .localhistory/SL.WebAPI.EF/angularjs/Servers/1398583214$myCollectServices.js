﻿var app = angular.module('share.mycollect.service', ['ngResource']);
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

               },
               cache: true,
               withCredentials: true,
               isArray: false

           },
         post:
            {
                method: "POST", params: {},
                headers: {

                },
                cache: true,
                withCredentials: true,
                isArray: true

            },
         put:
            {
                method: "PUT", params: {},
                headers: {
                    "X-Requested-With": "XMLHttpRequest",
                    "content-type": "application/x-www-form-urlencoded;charset=UTF-8",
                    "X-HTTP-Method-Override": "PUT"
                },
                cache: true,
                withCredentials: true,
                isArray: true
              
            },
         delete:
           {
               method: "DELETE", params: {},
               headers: {
                   "X-Requested-With": "XMLHttpRequest",
                   "content-type": "application/x-www-form-urlencoded;charset=UTF-8",
                    "X-HTTP-Method-Override": "DELETE"
               },
               cache: true,
               withCredentials: true,
               isArray: true
             
           }
     }
     );
});
