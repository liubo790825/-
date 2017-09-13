var AngCtrl = angular.module('starter.controllers', []);

AngCtrl
.controller('lrTabsCtrl', ['$scope', 'AreaInfo', 'Dxdj', 'YuyueInfo', 'UserInfo', 'DormBedChoice', 'Notices', 'Announces', 'LvseTongdao', 'StuLeave', 'BehaviorRecode', function ($scope, AreaInfo, Dxdj, YuyueInfo, UserInfo, DormBedChoice, Notices, Announces, LvseTongdao, StuLeave, BehaviorRecode) {
    AreaInfo.init();//初始化区域列表
    //lrmBaseInfo.init();//初始化基础信息
    //Notices.all();
    //Announces.all();

    Dxdj.baseInit();//初始化预约报到基础信息
    LvseTongdao.baseInit();//初始化绿色通道基础信息
    StuLeave.baseInit();//初始化请假基础信息
    BehaviorRecode.baseInit();//初始化操行违规类型
    //继续初始化
    //var cwdata = DormBedChoice.getList();//获得床位信息
    var stuinfo = UserInfo.get();
    //var queryData = { "BaodaoOther1": stuinfo.identityCardNo };
    //YuyueInfo.init(queryData);
}])
//学生登录
.controller('LoginCtrl', ['$scope', '$state', '$timeout', 'md5', '$learunTopAlert', '$learunHttp', 'ApiUrl', 'UserInfo', '$learunFormatDate',
function ($scope, $state, $timeout, md5, $learunTopAlert, $learunHttp, ApiUrl, UserInfo, $learunFormatDate) {
    $scope.data = {};
    $scope.logining = false;
    $scope.doLogin = function () {
        if ($scope.data.username == undefined || $scope.data.username == "") {
            $learunTopAlert.show({ text: "请输入账号" });
            return false;
        }
        if ($scope.data.password == undefined || $scope.data.password == "") {
            $learunTopAlert.show({ text: "请输入密码" });
            return false;
        }
        $scope.logining = true;
        $learunHttp.post({
            "url": ApiUrl.loginApi,//要用学生登录的api
            "data": { "password": md5.createHash($scope.data.password), "username": $scope.data.username },
            "success": function (data) {
                $scope.logining = false;
                if (data.status.code != 0) {
                    $learunTopAlert.show({ text: data.status.desc });
                }
                else {


                    //var b = UserInfo.getBaseData();
                    ////获取基础数据
                    //getBaseData: function (callback) {
                    //    
                    //}
                    $learunHttp.post({
                        "url": ApiUrl.baseDataApi,
                        "data": { "queryData": JSON.stringify(data.result.entity) },
                        "success": function (backdata) {
                            //var ob = backdata.result;
                            if (backdata.result.deptName != "")
                                data.result.entity.deptName = backdata.result.deptName
                            if (backdata.result.majorName != "")
                                data.result.entity.majorName = backdata.result.majorName
                            if (backdata.result.className != "")
                                data.result.entity.className = backdata.result.className

                            data.result.entity.birthday = $learunFormatDate(data.result.entity.birthday, 'yyyy-MM-dd');
                            UserInfo.set(data.result, data.token, true);
                            $state.go("tab.home");
                        },
                        "error": function () {
                            $learunTopAlert.show({ text: "获取基础数据失败" });
                        },
                        "finally": function () {
                            callback();
                        }
                    });

                    //UserInfo.set(data.result, data.token, true);

                    //$scope.data.password = "";
                    //$state.go("tab.home");
                }
            },
            "error": function () {
                $scope.logining = false;
                $learunTopAlert.show({ text: "通信失败" });
            }
        });
    };
}])


//主页 在uirouter.js 中的.state('tab.home', {指定了HomeCtrl
.controller('HomeCtrl', ['$scope', '$learunPageModal', 'HomeApps', 'Announces', '$learunHttp', 'ApiUrl', '$ionicModal', function ($scope, $learunPageModal, HomeApps, Announces, $learunHttp, ApiUrl, $ionicModal) {
    $scope.homeApps = HomeApps.all();//在modules.js中.factory('HomeApps'定义了或取值 all()也是里面定义的方法
    //$scope.announces = Announces.all();

    $scope.announces = {};// Announces.all();

    $learunHttp.post({
        "url": ApiUrl.noticeListApi,
        "data": { "page": 1, "rows": 10, "sidx": "SortCode,ReleaseTime", "sord": "desc", "queryData": null },//{},为空要出问题
        "success": function (data) {
            var announces = data.result.rows;
            $scope.announces = announces;
        }
    });


    //打开应用列表
    $learunPageModal($scope, 'templates/homeApps/');
    //*
    //获取公告单条信息
    $scope.get = function (announceId) {
        for (var i = 0; i < $scope.announces.length; i++) {
            if ($scope.announces[i].newsId == announceId) {
                return $scope.announces[i];
            }
        }
        return null;
    }


    //打开公告详情页
    $scope.openDetailsModal = function (announceId) {
        $scope.announce = $scope.get(announceId);

        if ($scope.detailsModal != null) {
            $scope.detailsModal.remove();
        }
        $ionicModal.fromTemplateUrl('templates/notices/homeNoticeDetails.html', {
            scope: $scope,
            animation: 'lr-slide-in-right',
        }).then(function (modal) {
            $scope.detailsModal = modal;
            $scope.detailsModal.show();
        });
    };
    $scope.closeDetailsModal = function () {
        $scope.detailsModal.remove();
    };
    //*/


    //公共详情页，其他页找不到调用会调这个
    $scope.openCommDetailsModal = function (viewpage, direction, obj) {
        if ($scope.detailsModal != null) {
            $scope.detailsModal.remove();
        }
        $ionicModal.fromTemplateUrl('templates/homeApps/baodao/' + viewpage, {
            scope: $scope,
            animation: 'lr-slide-in-' + direction,
        }).then(function (modal) {
            $scope.detailsModal = modal;
            $scope.detailsModal.show();
        });
    };
    $scope.closeCommDetailsModal = function () {
        $scope.detailsModal.remove();
    };



}])


//通知
.controller('NoticeCtrl', ['$scope', '$ionicModal', '$learunHttp', 'ApiUrl', 'Notices', function ($scope, $ionicModal, $learunHttp, ApiUrl, Notices) {
    /* $scope.allNotices = {
         "btnNoRead":[
           { title: '【通知】界面不好看，工作都白干，客户重颜值，内涵放一边', content: '界面不好看，工作都白干，客户重颜值，内涵放一边', datatime: '04月26日', newsId: '1', type: '1' },
           { title: '【通知】号外！号外！泉江开发APP不用美工了', content: '号外！号外！泉江开发APP不用美工了', datatime: '04月18日', newsId: '2', type: '1' },
           { title: '【公告】泉江全栈开发工程师培养计划', content: '泉江全栈开发工程师培养计划', datatime: '04月15日', newsId: '3', type: '1' },
           { title: '【公告】前端后台一把抓，开发不再要美工！', content: '前端后台一把抓，开发不再要美工！', datatime: '04月11日', newsId: '4', type: '1' },
           { title: '【公告】现在的客户重颜值，一定要把界面弄好看！！', content: '现在的客户重颜值，一定要把界面弄好看！！', datatime: '04月06日', newsId: '5', type: '1' }
           ],
         "btnRead":[
           { title: '【公告】新生入学接待工作通知', content: '新生入学接待工作通知新生入学接待工作通知新生入学接待工作通知新生入学接待工作通知新生入学接待工作通知新生入学接待工作通知', datatime: '05月05日', newsId: '7', type: '2' },
           { title: '【公告】教务处排课通知', content: '教务处排课通知教务处排课通知教务处排课通知教务处排课通知教务处排课通知教务处排课通知', datatime: '04月29日', newsId: '8', type: '2' },
           { title: '【公告】学生选课通知', content: '学生选课通知学生选课通知学生选课通知学生选课通知学生选课通知学生选课通知', datatime: '04月26日', newsId: '9', type: '2' },
           { title: '【公告】期末录成绩通知', content: '期末录成绩通知期末录成绩通知期末录成绩通知期末录成绩通知期末录成绩通知期末录成绩通知期末录成绩通知', datatime: '04月23日', newsId: '10', type: '2' },
           { title: '【通知】关于使用在线考试系统考试的通知', content: '关于使用在线考试系统考试的通知关于使用在线考试系统考试的通知关于使用在线考试系统考试的通知关于使用在线考试系统考试的通知关于使用在线考试系统考试的通知', datatime: '03月21日', newsId: '11', type: '2' },
           { title: '【通知】启用迎新系统的通知', content: '启用迎新系统的通知启用迎新系统的通知启用迎新系统的通知启用迎新系统的通知启用迎新系统的通知启用迎新系统的通知启用迎新系统的通知', datatime: '03月18日', newsId: '12', type: '2' },
           { title: '【通知】宿舍调整公告', content: '宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告', datatime: '03月27日', newsId: '14', type: '2' }
         ]
     };
     */

    $scope.newNotices = Notices.all();

    //$scope.newNotices = {
    //    "btnNoRead": [],//未读
    //    "btnRead": []//已读
    //};

    //$learunHttp.post({
    //    "url": ApiUrl.noticeListApi,
    //    "data": { "page": 1, "rows": 10, "sidx": "SortCode,ReleaseTime", "sord": "desc", "queryData": null },//{},为空要出问题
    //    "success": function (data) {
    //       var readdata = data.result.rows;
    //       for (var i in readdata) {
    //           var item = readdata[i];
    //           $scope.newNotices.btnNoRead.push(item);
    //        }
    //    }
    //});

    //$learunHttp.post({
    //    "url": ApiUrl.noticeListApi,
    //    "data": { "page": 1, "rows": 10, "sidx": "SortCode,ReleaseTime", "sord": "desc", "queryData": null },//{},为空要出问题
    //    "success": function (data) {
    //        var unreaddata = data.result.rows;
    //        for (var i in unreaddata) {
    //            var item = unreaddata[i];
    //            $scope.newNotices.btnRead.push(item);
    //        }
    //    }
    //});

    $scope.active = 'btnNoRead';
    $scope.notices = $scope.newNotices[$scope.active];
    $scope.setActive = function (type) {
        $scope.active = type;
        $scope.notices = $scope.newNotices[type];
    };
    $scope.isActive = function (type) {
        return type === $scope.active;
    };

    $scope.getColor = function (readtype) {
        var readtype = readtype == "1" ? "bgcolor_d" : "bgcolor_c";
        return readtype;
    };

    //获取公告单条信息
    $scope.get = function (noticeId) {
        for (var i = 0; i < $scope.notices.length; i++) {
            if ($scope.notices[i].newsId == noticeId) {
                return $scope.notices[i];
            }
        }
        return null;
    }

    //打开详情页
    $scope.openNoticesModal = function (noticeId) {
        $scope.notice = $scope.get(noticeId);

        $ionicModal.fromTemplateUrl(('templates/notices/noticeDetails.html'), {
            scope: $scope,
            animation: 'lr-slide-in-right'
        }).then(function (modal) {
            $scope.noticesModal = modal;
            $scope.noticesModal.show();
        });
    };
    $scope.closeNoticesModal = function () {
        $scope.noticesModal.remove();
    };







}])
.controller('NoticeListCtrl', function ($scope) {
})

//我的
.controller('PersonCenterCtrl', ['$scope', '$state', '$learunPageModal', '$learunPopup', '$learunHttp', 'UserInfo', 'ApiUrl',
    function ($scope, $state, $learunPageModal, $learunPopup, $learunHttp, UserInfo, ApiUrl) {
        $scope.stuinfo = UserInfo.get();
        $scope.outLogin = function () {
            $learunPopup.confirm({
                title: '<p> </p>确定要退出登录?<p> </p>',
                okText: '退出',
                ok: function () {
                    $learunHttp.post({
                        "url": ApiUrl.outLoginApi,
                        "success": function (data) {
                            console.log(data);
                            UserInfo.clear();
                            $state.go("login");
                        },
                        "error": function () {
                            console.log("error");
                            UserInfo.clear();
                            $state.go("login");
                        }
                    });
                },
            });
        };
        //打开个人信息列表
        $learunPageModal($scope, 'templates/personCenter/');
    }])


;
