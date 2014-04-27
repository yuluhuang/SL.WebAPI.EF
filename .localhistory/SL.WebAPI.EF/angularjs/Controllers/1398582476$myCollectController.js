var app = angular.module('share.mycollect.controller', []);
app.controller('myCollectController', function ($scope, myCollectAPIService, loginAPIService, $http) {

    $scope.collects = {};
    $scope.collect = {}; //用于修改收藏
    //如果是登录状态
    // loginAPIService.islogin().success(function (data) {
    // if (data[0].flag) {
    myCollectAPIService.get({}, function (response) {
        console.info("sssss", response);
        if (response) {
            console.info("sssss", response.value);
            $scope.collects = response.value;
        } else {
            alert("error");
        }
    });
    //}
    // });

    //编辑状态
    $scope.showCollect = function (collect) {
        $scope.collect = collect;
    }

    //提交
    $scope.submitCollect = function (collect) {
        //loginAPIService.islogin().success(function (data) {
        // if (data[0].flag && data[0].power >= 2) {
        var collect = $scope.collect;
        console.info(collect.collectId);
        var collectId = collect.collectId;
        if (collect.collectId) {
            var collection = $scope.collect;
            //var putCollection = new myCollectAPIService(collection);
            //putCollection.$post({colletId: collectId }, {}, function (response) {
            //    console.info(response);

            //});

            myCollectAPIService.post({ colletId: collectId }, collection, function (responde) {
                console.info(response);
            });


        } else {

            collect.taskId = "1";
            collect.time = (new Date()).getTime();
            collect.userId = "1";
            collect.userTable_Id = "1";
            console.info("aaa", collect);
            //var postCollection = new myCollectAPIService(collect);

            //postCollection.$post({ action: "POST"}, {}, function (response) {
            //    console.info("aaa", response);
            //    if (response) {
            //        //$scope.collects.splice(0, 0, collect);
            //        $scope.collects.unshift(collect);
            //        // alert("success");
            //    } else {
            //        alert("error");
            //    }
            //});
            myCollectAPIService.post({}, collect, function (responde) {
                console.info(response);
            });
        }
        //  } else {
        //  if (data[0].flag) {
        //  alert("login");
        //  window.location.href = "login.html";
        // } else {
        //      alert("权限不足");
        //   }
        // }
        // });
    }

    //delete collect
    $scope.deleteCollect = function (id) {
        // loginAPIService.islogin().success(function (data) {
        // if (data[0].flag && data[0].power >= 2) {
        /*  $http({
           method: 'GET',
           headers: {
               "Content-Type": "text/plain",
               "X-HTTP-Method-Override": "DELETE"
           },
           url: 'sl/Collection/' + id + '/',
           params: {
              
           },
           withCredentials: true
       });;*/
        myCollectAPIService.post({ action: "DELETE", colletId: id }, {}, function (response) {
            console.info(response);
            if (response) {
                angular.forEach($scope.collects, function (v, k) {
                    if (v.collectId == id) {
                        $scope.collects.splice(k, 1);
                    }
                });
                alert("success");

            } else {
                alert("error");
            }
        })
        //        } else {
        //            if (data[0].flag) {
        //                alert("login");
        //                window.location.href = "login.html";
        //            } else {
        //                alert("权限不足");
        //            }
        //        }
        //    });
    }
});
