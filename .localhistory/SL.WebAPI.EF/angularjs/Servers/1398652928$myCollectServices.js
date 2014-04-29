var app = angular.module('share.mycollect.service', ['ngResource']);
app.service('myCollectAPIService', function ($http, $resource, baseUrlService) {
    var baseurl = baseUrlService.get();
    //return $resource(baseurl + "sl/collection/:colletId/",
    return $resource(baseurl + 'odata/Collections(:colletId)',
     {},
     {
         get:
           {
               method: "POST", params: {},
               headers: {

               },
               cache: true,
               withCredentials: true,
               isArray: false,
               headers: {
                   "X-HTTP-Method-Override": "GET"
               },
           },
         post:
            {
                method: "POST", params: {},
                headers: {

                },
                cache: true,
                withCredentials: true,
                isArray: true,
                headers: {
                    "X-HTTP-Method-Override": "POST"
                },

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
