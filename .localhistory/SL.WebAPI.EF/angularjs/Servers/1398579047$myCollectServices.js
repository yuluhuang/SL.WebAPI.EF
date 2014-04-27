var app = angular.module('share.mycollect.service', ['ngResource']);
app.service('myCollectAPIService', function ($http, $resource, baseUrlService) {
    var baseurl = baseUrlService.get();
       //return $resource(baseurl + "sl/collection/:colletId/",
    return $resource(baseurl + 'odata/Collections/:action/:colletId/',
     {},
     {
         get: { method: "GET", params: {}, cache: true, withCredentials: true, isArray: false},//, header: {:"X-HTTP-Method-Override"}
         post: { method: "POST", params: {}, cache: true, withCredentials: true, isArray: false },
     }
     );
});
