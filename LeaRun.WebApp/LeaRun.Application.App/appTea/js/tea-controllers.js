var AngCtrl = angular.module('starter.controllers', []);

AngCtrl
.controller('lrTabsCtrl', ['$scope', 'lrmBaseInfo', 'AreaInfo',  'listFreshStuInfo', 'listBaodaoYuyue', function ($scope, lrmBaseInfo, AreaInfo, listFreshStuInfo, listBaodaoYuyue) {
    AreaInfo.init();//初始化区域列表
    //lrmBaseInfo.init();//初始化基础信息
    //lrmBusinesss.init();//初始化学生基础信息
    //lrmCustomers.baseInit();//初始化教师基础信息

    listBaodaoYuyue.baseInit();//初始化，主要是用于下拉选框的字典数据要在此获得

    //listFreshStuInfo.init();//初始化新生信息

}])
//登录
.controller('LoginCtrl',['$scope', '$state', '$timeout', 'md5', '$learunTopAlert', '$learunHttp', 'ApiUrl', 'UserInfo',
    function ($scope, $state, $timeout, md5, $learunTopAlert, $learunHttp, ApiUrl, UserInfo) {
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
                "url": ApiUrl.loginApi,
                "data": { "password": md5.createHash($scope.data.password), "username": $scope.data.username },
                "success": function (data) {
                    $scope.logining = false;
                    if (data.status.code != 0) {
                        $learunTopAlert.show({ text: data.status.desc });
                    }
                    else {
                        UserInfo.set(data.result, data.token, true);
                        $scope.data.password = "";
                        $state.go("tab.home");
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
.controller('HomeCtrl', ['$scope', '$learunPageModal', 'HomeApps', 'Announces', '$learunHttp', 'ApiUrl', '$ionicModal',
    function ($scope, $learunPageModal, HomeApps, Announces, $learunHttp, ApiUrl, $ionicModal) {

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
    $scope.openCommDetailsModal = function (viewpage,direction, obj) {
        if (viewpage == "JiezhanstuDetails.html") {
            $scope.yuyue = obj;
        }

        if (viewpage == "answer.html") {
            var queryData = obj;
            $scope.AnswerStuInfoId = obj.stuInfoId;//给保存回复信息传参
            $scope.question = {};
            //查找咨询问题信息
            $learunHttp.post({
                "url": ApiUrl.TeaQuestionListApi,
                "data": { "page": 1, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": JSON.stringify(queryData) },
                "success": function (data) {
                    $scope.question = data;
                }
            });

            //获取回复信息
            $scope.answer = {};
            $learunHttp.post({
                "url": ApiUrl.TeaAnswerListApi,
                "data": { "page": 1, "rows": 10, "sidx": "Atime", "sord": "desc", "queryData": JSON.stringify(queryData) },
                "success": function (data) {
                    $scope.answer = data;
                }
            });
        }


        //$scope.detailsData = lrmCustomers.get(customerId);
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




//协同办公
.controller('WorkflowCtrl',['$scope',function($scope){

}])
//实例
.controller('CasesCtrl', ['$scope', '$learunPageModal', '$cordovaImagePicker','Cases', function ($scope, $learunPageModal,$cordovaImagePicker, Cases) {
    $scope.cases = Cases.all();
    //打开应用列表
    $learunPageModal($scope,'templates/cases/',function(id){$scope.caseItem = Cases.get(id);});
}])
.controller('CaseListCtrl', ['$scope', '$stateParams', '$ionicModal',function ($scope, $stateParams, $ionicModal) {
    $scope.showList = function (type) {
        $ionicModal.fromTemplateUrl('templates/cases/list/' + type + '.html', {
            scope: $scope
        }).then(function (modal) {
            $scope.CaseListModal = modal;
            $scope.CaseListModal.show();
        });
        $scope.closeModal = function () {
            $scope.CaseListModal.remove();
        };
    };
}])

.controller('CaseFormCtrl',['$scope',function ($scope) {
    $scope.checkbox = true;
    $scope.choice = 'A';
}])
//--选择相册
.controller('CasesPictureCtrl', ['$scope', '$cordovaImagePicker', '$cordovaFileTransfer', function ($scope, $cordovaImagePicker, $cordovaFileTransfer) {
    $scope.imgSrc = "";
    $scope.pickImage = function () {
        var options = {
            maximumImagesCount: 1,
            width: 355,
            height: 300,
            quality: 80
        };
        $cordovaImagePicker.getPictures(options).then(function (results) {

            $scope.imgSrc = results[0];
            alert("上传成功!" + results[0]);
        }, function (error) {
            // error getting photos
        });
    }
}])
//拍照
.controller('CasesCameraCtrl', ['$scope', '$cordovaCamera', function ($scope, $cordovaCamera) {
    $scope.imgSrc = "";
    $scope.doCemera = function () {
        var options = {
            targetWidth: 500,
            targetHeight: 500,
            destinationType: Camera.DestinationType.FILE_URI,
            sourceType: Camera.PictureSourceType.CAMERA,
        };
        $cordovaCamera.getPicture(options).then(function (imageURI) {
            alert(imageURI);
            $scope.imgSrc = imageURI;
        }, function (err) {
            // error
        });
    };
}])
//扫描条码
.controller('CasesBarcodeCtrl', ['$scope', '$cordovaBarcodeScanner', function ($scope, $cordovaBarcodeScanner) {
    $scope.barcode = "";
    $scope.doBarcode = function () {
        $cordovaBarcodeScanner.scan().then(function (barcodeData) {
            // Success! Barcode data is here
            $scope.barcode = barcodeData;

            alert(barcodeData.text);
        }, function (error) {
            // An error occurred
        });
        // NOTE: encoding not functioning yet
        $cordovaBarcodeScanner.encode(BarcodeScanner.Encode.TEXT_TYPE, " ").then(function (success) {
            // Success!
            alert(success);
        }, function (error) {
            // An error occurred
        });
    };
}])
//通讯录
.controller('CasesContactCtrl', ['$scope', '$cordovaContacts', '$ionicPlatform', function ($scope, $cordovaContacts, $ionicPlatform) {
    $scope.addContact = function () {
        $cordovaContacts.save($scope.contactForm).then(function (result) {
            // Contact saved

        }, function (err) {
            // Contact error
        });
    };
    $scope.getAllContacts = function () {
        var options = {};
        options.filter = '';
        options.multiple = true;
        $cordovaContacts.find(options).then(function (allContacts) { //省略参数，获取所有的信息
            alert(JSON.stringify(allContacts));
            $scope.contacts = allContacts;
        });
    };
    $scope.findContactsBySearchTerm = function (searchTerm) {
        var opts = {
            filter: searchTerm,
            multiple: true,// 返回匹配条件的任何信息
            fields: ['displayName', 'name'],
            desiredFields: [id]
        };
        if ($ionicPlatform.isAndroid()) {
            opts.hasPhoneNumber = true;//hasPhoneNumber 只适用于android
        };

        $cordovaContacts.find(opts).then(function (contactsFound) {
            $scope.contacts = contactsFound;
        });
        $scope.pickContactUsingNativeUI = function () {
            $cordovaContacts.pickContact().then(function (contactPicked) {
                $scope.contact = contactPicked;
            })
        }
    };
}])
//打电话
.controller('CasesTelCtrl', ['$scope', function ($scope) {
    $scope.doCallPhone10010 = function () {
        document.location.href = "tel:10010";
    };
    $scope.doCallPhone10086 = function () {
        document.location.href = "tel:10086";
    };
}])
//地理位置
.controller('CasesGeolocationCtrl', ['$scope', '$cordovaGeolocation', '$ionicLoading', function ($scode, $cordovaGeolocation, $ionicLoading) {

    $scode.geoFindMe = function () {
        //output.innerHTML = " ";
        $ionicLoading.show();
        var output = document.getElementById("out");
        var posOptions = { timeout: 10000, enableHighAccuracy: true };
        $cordovaGeolocation.getCurrentPosition(posOptions).then(function (position) {
            //$rootScope.$broadcast('selfLocation:update', position);
            lat = position.coords.latitude
            long = position.coords.longitude
            alert([lat, long]);
            output.innerHTML = '<p>Latitude is ' + lat + '° <br>Longitude is ' + long + '°</p>';
            $ionicLoading.hide();
        }, function (err) {
            console.log("无法获取地理位置!");
            $ionicLoading.hide();
            return;
        });
        var watchOptions = {
            timeout: 3000,
            enableHighAccuracy: false // may cause errors if true
        };
        var watch = $cordovaGeolocation.watchPosition(watchOptions);
        watch.then(null, function (err) {
            // error
        }, function (position) {
            var lat = position.coords.latitude
            var long = position.coords.longitude
        });
        watch.clearWatch();
        // OR
        $cordovaGeolocation.clearWatch(watch).then(function (result) {
            // success
        }, function (error) {
            // error
        });
    }
}])

//通知
.controller('NoticeCtrl', ['$scope', '$ionicModal', 'Notices', function ($scope, $ionicModal, Notices) {
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
.controller('PersonCenterCtrl', ['$scope', '$state','$learunPageModal', '$learunPopup', '$learunHttp', 'UserInfo', 'ApiUrl',
    function ($scope, $state,$learunPageModal, $learunPopup, $learunHttp, UserInfo, ApiUrl) {
        $scope.userinfo = UserInfo.get();
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
        $learunPageModal($scope,'templates/personCenter/');
    }])


;
