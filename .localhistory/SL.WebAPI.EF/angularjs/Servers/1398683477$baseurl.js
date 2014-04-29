var app = angular.module('baseurl.service', []);
app.service('baseUrlService', function () {
    this.get=function(){
        var baseurl="";
        return  baseurl;
    }
    this.verifyFilter = function (data) {
        if (data == "403") {
            return "";
        }
       
    }
});