var app = angular.module('baseurl.service', []);
app.service('baseService', function () {
    this.get=function(){
        var baseurl="";
        return  baseurl;
    }
    this.statusFilter = function (data) {
        if (data == "403") {
            return "";
        }
        else if (data == "400") {
            return "用户名已存在";
        }
       
    }
});