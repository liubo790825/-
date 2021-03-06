angular.module('starter.controllers', [])
.controller('lrTabsCtrl', ['$scope','lrmBaseInfo','AreaInfo','lrmBusinesss','lrmCustomers',function ($scope,lrmBaseInfo, AreaInfo,lrmBusinesss,lrmCustomers) {
    AreaInfo.init();//初始化区域列表
    lrmBaseInfo.init();//初始化基础信息
    lrmBusinesss.init();//初始化学生基础信息
    lrmCustomers.baseInit();//初始化教师基础信息
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
.controller('HomeCtrl', ['$scope','$learunPageModal','HomeApps','Announces',function ($scope,$learunPageModal, HomeApps, Announces) {
    $scope.homeApps = HomeApps.all();//在modules.js中.factory('HomeApps'定义了或取值 all()也是里面定义的方法
    $scope.announces = Announces.all();
    //打开应用列表
    $learunPageModal($scope,'templates/homeApps/');
}])


//学生管理
.controller('BusinesssCtrl', [
    '$scope','$timeout', '$ionicModal', '$learunPopup','$ionicLoading','$learunTopAlert','$learunTriggerRefresh','$learunSelectModal','$learunDataIsAll','lrmBusinesss','lrmBaseInfo',
  function ($scope,$timeout, $ionicModal, $learunPopup,$ionicLoading, $learunTopAlert, $learunTriggerRefresh,$learunSelectModal,$learunDataIsAll, lrmBusinesss,lrmBaseInfo) {
      $scope.data = lrmBusinesss.getList();

    //刷新数据
    $timeout(function () {
      $learunTriggerRefresh.triggerRefresh('businesslist-content');
    },450);
    $scope.doRefresh = function () {
      lrmBusinesss.update(function () {
        $scope.$broadcast('scroll.refreshComplete');
      });
    };
    $scope.doLoadMore = function () {
      lrmBusinesss.add(function () {
        $scope.$broadcast('scroll.infiniteScrollComplete');
      });
    };

    //搜索页
    $scope.closeSearchModal = function () {
      $scope.searchModal.remove();
    };
    $scope.openSearch = function () {
      $scope.searchData = lrmBusinesss.getSearchList();
      console.log($scope.searchData);
      if($scope.searchModal != null)
      {
        $scope.searchModal.remove();
      }
      $ionicModal.fromTemplateUrl('templates/homeApps/business/businessSearch.html', {
        scope: $scope,
        animation: 'lr-slide-in-right',
        focusFirstInput: true
      }).then(function (modal) {
        $scope.searchModal = modal;
        $scope.searchModal.show();
      });
    };
    $scope.doSearch = function () {
      lrmBusinesss.searchData();
    };
    $scope.loadMoreSearch = function () {
      lrmBusinesss.searchDataAdd(function () {
        $scope.$broadcast('scroll.infiniteScrollComplete');
      });
    };

    //详情页
    $scope.openDetailsModal = function (chanceId) {
      $scope.detailsData = lrmBusinesss.get(chanceId);
      if($scope.detailsModal != null)
      {
        $scope.detailsModal.remove();
      }
      $ionicModal.fromTemplateUrl('templates/homeApps/business/businessDetails.html', {
        scope: $scope,
        animation: 'lr-slide-in-right'
      }).then(function (modal) {
        $scope.detailsModal = modal;
        $scope.detailsModal.show();
      });
    };
    $scope.closeDetailsModal = function () {
      $scope.detailsModal.remove();
    };

    //编辑页
    $scope.openEditModal = function (item) {
      $scope.editData ={};
      $scope.editTitle = "新建";
      if(item != undefined)
      {
        $scope.editData = item;
        $scope.editTitle = "编辑";
      }
      if($scope.editModal != undefined){
        $scope.editModal.remove();
      }
      $ionicModal.fromTemplateUrl('templates/homeApps/business/businessEdit.html', {
        scope: $scope,
        animation: 'slide-in-up',
      }).then(function (modal) {
        $scope.editModal = modal;
        $scope.editModal.show();
      });
    };
    $scope.closeEditModal = function () {
      if($learunDataIsAll.isHave($scope.editData)) {
        $learunPopup.confirm({
          title: '<p> </p>内容未保存，要放弃编辑吗？<p> </p>',
          okText: '放弃',
          ok: function () {
            $scope.editModal.remove();
          }
        });
      }else {
        $scope.editModal.remove();
      }
    };
    $scope.isInputActive = function(name){
      return ($scope.editData[name]!= null && $scope.editData[name]!= ""&& $scope.editData[name]!= undefined);
    };

      //类似下拉选框
    $scope.openSourceSelectModal = function () {//打开选择学生来源
      $learunSelectModal({
        title:"学生来源",
        bgAllColor:"royal-bg",
        selectValue:$scope.editData.sourceId,
        text:"itemName",
        value:"itemValue",
        data:lrmBusinesss.getChanceSource(),
        onChange: function (item) {
          $scope.editData.sourceId = item.value;
          $scope.editData.sourceName = item.text;
        }
      });
    };
    $scope.openStageSelectModal = function () {//打开选择学生阶段
      $learunSelectModal({
        title:"学生阶段",
        selectValue:$scope.editData.stageId,
        text:"itemName",
        value:"itemValue",
        bgColor:"bgColor",
        data:lrmBusinesss.getChancePhases(),
        onChange: function (item) {
          $scope.editData.stageId = item.value;
          $scope.editData.stageName = item.text;
          $scope.editData.bgStageColor = item.bgColor;
        }
      });
    };
    $scope.openTraceUserSelectModal = function(){
      $learunSelectModal({
        title:"关注人员",
        bgAllColor:"calm-bg",
        selectValue:$scope.editData.traceUserId,
        text:"realName",
        value:"userId",
        data:lrmBaseInfo.getUserInfoList("2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1"),
        onChange: function (item) {
          $scope.editData.traceUserId = item.value;
          $scope.editData.traceUserName = item.text;
        }
      });
    };

    //删除
    $scope.doDelete = function (business) {
      $learunPopup.confirm({
        title: '<p> </p>确定要删除?<p> </p>',
        okText: '删除',
        ok: function () {
          lrmBusinesss.remove(business);
          if($scope.detailsModal != null) {
            $scope.detailsModal.remove();
          }
        }
      });
    };
    //添加保存
    $scope.doSubmit = function () {
      var res = $learunDataIsAll.isAll($scope.editData,lrmBusinesss.getEditDataEx());
      if(res != null) {
        $learunTopAlert.show({ text: res.name + " 不能为空" });
      }else {
        $ionicLoading.show();
        lrmBusinesss.editSubmit($scope.editData,function(){
          $ionicLoading.hide();
          $scope.editModal.remove();
          $learunTriggerRefresh.triggerRefresh('businesslist-content');//和home-business.html中的<ion-content delegate-handle="businesslist-content">对应
        });
      }
    }
  }])



//教师管理
.controller('CustomersCtrl',[
  '$scope','$timeout' ,'$ionicModal','$ionicLoading', '$learunTopAlert', '$learunTriggerRefresh', '$learunPopup','$learunSelectModal','$learunDataIsAll','lrmBaseInfo', 'lrmCustomers'
  ,function ($scope,$timeout, $ionicModal,$ionicLoading, $learunTopAlert, $learunTriggerRefresh, $learunPopup,$learunSelectModal,$learunDataIsAll,lrmBaseInfo, lrmCustomers) {
    $scope.data = lrmCustomers.getList();
    //刷新数据
    $timeout(function () {
      $learunTriggerRefresh.triggerRefresh('customerlist-content');
    },450);
    $scope.doRefresh = function () {
      lrmCustomers.update(function () {
        $scope.$broadcast('scroll.refreshComplete');
      });
    };
    $scope.doLoadMore = function () {
      lrmCustomers.add(function () {
        $scope.$broadcast('scroll.infiniteScrollComplete');
      });
    };
    //详情页
    $scope.openDetailsModal = function (customerId) {
      $scope.detailsData = lrmCustomers.get(customerId);
      if($scope.detailsModal != null)
      {
        $scope.detailsModal.remove();
      }
      $ionicModal.fromTemplateUrl('templates/homeApps/customers/customersDetails.html', {
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
    //搜索页
    $scope.closeSearchModal = function () {
      $scope.searchModal.remove();
    };
    $scope.openSearch = function () {
      $scope.searchData = lrmCustomers.getSearchList();
      if($scope.searchModal != null)
      {
        $scope.searchModal.remove();
      }
      $ionicModal.fromTemplateUrl('templates/homeApps/customers/customersSearch.html', {
        scope: $scope,
        animation: 'lr-slide-in-right',
        focusFirstInput: true
      }).then(function (modal) {
        $scope.searchModal = modal;
        $scope.searchModal.show();
      });

    };
    $scope.doSearch = function () {
      lrmCustomers.searchData();
    };
    $scope.loadMoreSearch = function () {
      lrmCustomers.searchDataAdd(function () {
        $scope.$broadcast('scroll.infiniteScrollComplete');
      });
    };
    //编辑页
    $scope.openEditModal = function (item) {
      $scope.editData ={
      };
      $scope.editTitle = "新建";
      if(item != undefined)
      {
        $scope.editData = item;
        $scope.editTitle = "编辑";
      }

      if($scope.editModal != undefined){
        $scope.editModal.remove();
      }
      $ionicModal.fromTemplateUrl('templates/homeApps/customers/customersEdit.html', {
          scope: $scope,
          animation: 'slide-in-up',
      }).then(function (modal) {
          $scope.editModal = modal;
          $scope.editModal.show();
      });
    };
    $scope.closeEditModal = function () {
      if($learunDataIsAll.isHave($scope.editData)) {
        $learunPopup.confirm({
          title: '<p> </p>内容未保存，要放弃编辑吗？<p> </p>',
          okText: '放弃',
          ok: function () {
            $scope.editModal.remove();
          }
        });
      }else {
        $scope.editModal.remove();
      }
    };
    $scope.isInputActive = function(name){
      return ($scope.editData[name]!= null && $scope.editData[name]!= ""&& $scope.editData[name]!= undefined);
    };

    $scope.openTypeSelectModal = function () {//教师类别
      $learunSelectModal({
        title:"教师类别",
        bgAllColor:"royal-bg",
        selectValue:$scope.editData.custTypeId,
        text:"itemName",
        value:"itemValue",
        data:lrmCustomers.getCustType(),
        onChange: function (item) {
          $scope.editData.custTypeId = item.value;
          $scope.editData.custTypeName = item.text;
        }
      });
    };
    $scope.openLevelSelectModal = function () {//教师级别
      $learunSelectModal({
        title:"教师级别",
        bgAllColor:"positive-bg",
        selectValue:$scope.editData.custLevelId,
        text:"itemName",
        value:"itemValue",
        data:lrmCustomers.getCustLevel(),
        onChange: function (item) {
          $scope.editData.custLevelId = item.value;
          $scope.editData.custLevelName = item.text;
        }
      });
    };
    $scope.openDegreeSelectModal = function () {//教师程度
      $learunSelectModal({
        title:"教师程度",
        bgAllColor:"balanced-bg",
        selectValue:$scope.editData.custDegreeId,
        text:"itemName",
        value:"itemValue",
        data:lrmCustomers.getCustDegree(),
        onChange: function (item) {
          $scope.editData.custDegreeId = item.value;
          $scope.editData.custDegreeName = item.text;
        }
      });
    };
    $scope.openTraceUserSelectModal = function(){
      $learunSelectModal({
        title:"主要联系人",
        bgAllColor:"calm-bg",
        selectValue:$scope.editData.traceUserId,
        text:"realName",
        value:"userId",
        data:lrmBaseInfo.getUserInfoList("2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1"),
        onChange: function (item) {
          $scope.editData.traceUserId = item.value;
          $scope.editData.traceUserName = item.text;
        }
      });
    };
    //删除
    $scope.doDelete = function (customer) {
        $learunPopup.confirm({
            title: '<p> </p>确定要删除?<p> </p>',
            okText: '删除',
            ok: function () {
              lrmCustomers.remove(customer);
              if($scope.detailsModal != null) {
                $scope.detailsModal.remove();
              }
            }
        });
    };
    //添加保存
    $scope.submitCust = function () {
      var res = $learunDataIsAll.isAll($scope.editData,lrmCustomers.getEditDataEx());
      if(res != null) {
        $learunTopAlert.show({ text: res.name + "不能为空" });
      } else {
        $ionicLoading.show();
        $scope.editData.shortName = $scope.editData.fullName;
        lrmCustomers.editSubmit($scope.editData,function(){
          $ionicLoading.hide();
          $scope.editModal.remove();
          $learunTriggerRefresh.triggerRefresh('customerlist-content');
        });
      }
    }
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
.controller('NoticeCtrl', ['$scope','$ionicModal',function ($scope,$ionicModal) {
    $scope.allNotices = {
        "btnNoRead":[
          { title: '【通知】界面不好看，工作都白干，客户重颜值，内涵放一边', content: '界面不好看，工作都白干，客户重颜值，内涵放一边', datatime: '04月26日', id: '1', type: '1' },
          { title: '【通知】号外！号外！泉江开发APP不用美工了', content: '号外！号外！泉江开发APP不用美工了', datatime: '04月18日', id: '2', type: '1' },
          { title: '【公告】泉江全栈开发工程师培养计划', content: '泉江全栈开发工程师培养计划', datatime: '04月15日', id: '3', type: '1' },
          { title: '【公告】前端后台一把抓，开发不再要美工！', content: '前端后台一把抓，开发不再要美工！', datatime: '04月11日', id: '4', type: '1' },
          { title: '【公告】现在的客户重颜值，一定要把界面弄好看！！', content: '现在的客户重颜值，一定要把界面弄好看！！', datatime: '04月06日', id: '5', type: '1' }
          ],
        "btnRead":[
          { title: '【公告】新生入学接待工作通知', content: '新生入学接待工作通知新生入学接待工作通知新生入学接待工作通知新生入学接待工作通知新生入学接待工作通知新生入学接待工作通知', datatime: '05月05日', id: '7', type: '2' },
          { title: '【公告】教务处排课通知', content: '教务处排课通知教务处排课通知教务处排课通知教务处排课通知教务处排课通知教务处排课通知', datatime: '04月29日', id: '8', type: '2' },
          { title: '【公告】学生选课通知', content: '学生选课通知学生选课通知学生选课通知学生选课通知学生选课通知学生选课通知', datatime: '04月26日', id: '9', type: '2' },
          { title: '【公告】期末录成绩通知', content: '期末录成绩通知期末录成绩通知期末录成绩通知期末录成绩通知期末录成绩通知期末录成绩通知期末录成绩通知', datatime: '04月23日', id: '10', type: '2' },
          { title: '【通知】关于使用在线考试系统考试的通知', content: '关于使用在线考试系统考试的通知关于使用在线考试系统考试的通知关于使用在线考试系统考试的通知关于使用在线考试系统考试的通知关于使用在线考试系统考试的通知', datatime: '03月21日', id: '11', type: '2' },
          { title: '【通知】启用迎新系统的通知', content: '启用迎新系统的通知启用迎新系统的通知启用迎新系统的通知启用迎新系统的通知启用迎新系统的通知启用迎新系统的通知启用迎新系统的通知', datatime: '03月18日', id: '12', type: '2' },
          { title: '【通知】宿舍调整公告', content: '宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告宿舍调整公告', datatime: '03月27日', id: '14', type: '2' }]
    };
    $scope.active = 'btnNoRead';
    $scope.notices = $scope.allNotices[$scope.active];
    $scope.setActive = function(type) {
        $scope.active = type;
        $scope.notices = $scope.allNotices[type];
    };
    $scope.isActive = function(type){
        return type === $scope.active;
    };

    //打开详情页
    $scope.openNoticesModal = function (noticeId) {
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


//抵校管理
.controller('BaodaoCtrl', [
    '$scope', '$learunPageModal', '$timeout', '$ionicModal', '$learunPopup', '$ionicLoading', '$learunTopAlert', '$learunTriggerRefresh', '$learunSelectModal', '$learunDataIsAll', 'UserInfo', 'lrmBaseInfo',
  function ($scope, $learunPageModal, $timeout, $ionicModal, $learunPopup, $ionicLoading, $learunTopAlert, $learunTriggerRefresh, $learunSelectModal, $learunDataIsAll, UserInfo, lrmBaseInfo) {
      $scope.detailsData = UserInfo.get();
      
      //详情页
      $scope.openDetailsModal = function (viewpage,direction) {
          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/baodao/'+ viewpage, {
              scope: $scope,
              animation: 'slide-in-' + direction,//left,right,up,down
          }).then(function (modal) {
              $scope.detailsModal = modal;
              $scope.detailsModal.show();
          });
      };
      $scope.closeDetailsModal = function () {
          $scope.detailsModal.remove();
      };
      //编辑页
      $scope.openEditModal = function (viewpage, direction,item) {
          $scope.editData = {};
          $scope.editTitle = "抵校信息";
          if (item != undefined) {
              $scope.editData = item;
              $scope.editTitle = "抵校信息修改";
          }
          else
              editTitle = "抵校信息登记";

          if ($scope.editModal != undefined) {
              $scope.editModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/baodao/' + viewpage, {
              scope: $scope,
              animation: 'slide-in-' + direction,//left,right,up,down
          }).then(function (modal) {
              $scope.editModal = modal;
              $scope.editModal.show();
          });
      };
      $scope.closeEditModal = function () {
          if ($learunDataIsAll.isHave($scope.editData)) {
              $learunPopup.confirm({
                  title: '<p> </p>内容未保存，要放弃编辑吗？<p> </p>',
                  okText: '放弃',
                  ok: function () {
                      $scope.editModal.remove();
                  }
              });
          } else {
              $scope.editModal.remove();
          }
      };
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };
      ////var arriveType = {};//来校方式
      ////var baodaoDept = {};//报到院系
      ////var stationName = {};//到站名称
      //$scope.openArriveTypeSelectModal = function () {//打开选择来校方式
      //    $learunSelectModal({
      //        title: "来校方式",
      //        bgAllColor: "royal-bg",
      //        selectValue: $scope.editData.arriveType,
      //        text: "itemName",
      //        value: "itemValue",
      //        data: Dxdj.getArriveType(),
      //        onChange: function (item) {
      //            //$scope.editData.sourceId = item.value;
      //            $scope.editData.arriveType = item.text;
      //        }
      //    });
      //};
      //$scope.openBaodaoDeptSelectModal = function () {//打开选择报到院系
      //    $learunSelectModal({
      //        title: "报到院系",
      //        selectValue: $scope.editData.baodaoDept,
      //        text: "itemName",
      //        value: "itemValue",
      //        //bgColor: "bgColor",
      //        data: Dxdj.getBaodaoDept(),
      //        onChange: function (item) {
      //            //$scope.editData.stageId = item.value;
      //            $scope.editData.baodaoDept = item.text;
      //            //$scope.editData.bgStageColor = item.bgColor;
      //        }
      //    });
      //};
      //$scope.openStationNameSelectModal = function () {//打开选择到站名称
      //    $learunSelectModal({
      //        title: "到站名称",
      //        selectValue: $scope.editData.stationName,
      //        text: "itemName",
      //        value: "itemValue",
      //        //bgColor: "bgColor",
      //        data: Dxdj.getStationName(),
      //        onChange: function (item) {
      //            //$scope.editData.stageId = item.value;
      //            $scope.editData.stationName = item.text;
      //            //$scope.editData.bgStageColor = item.bgColor;
      //        }
      //    });
      //};

      //添加保存
      $scope.doSubmit = function () {
          var res = $learunDataIsAll.isAll($scope.editData, Dxdj.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + " 不能为空" });
          } else {
              $ionicLoading.show();
              Dxdj.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $learunTriggerRefresh.triggerRefresh('baodaolist-content');
              });
          }
      }
      $learunPageModal($scope, 'templates/homeApps/baodao/');
  }])


//绿色通道
.controller('GreenChannelCtrl', [
  '$scope', '$timeout','$learunPageModal', '$ionicModal', '$ionicLoading', '$learunTopAlert', '$learunTriggerRefresh', '$learunPopup', '$learunSelectModal', '$learunDataIsAll', 'lrmBaseInfo', 'lrmCustomers'
  , function ($scope, $timeout,$learunPageModal, $ionicModal, $ionicLoading, $learunTopAlert, $learunTriggerRefresh, $learunPopup, $learunSelectModal, $learunDataIsAll, lrmBaseInfo, lrmCustomers) {


      $learunPageModal($scope, 'templates/homeApps/GreenChannel/');


      $scope.data = lrmCustomers.getList();
      //刷新数据
      $timeout(function () {
          $learunTriggerRefresh.triggerRefresh('customerlist-content');
      }, 450);
      $scope.doRefresh = function () {
          lrmCustomers.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          lrmCustomers.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //详情页
      $scope.openDetailsModal = function (customerId) {
          $scope.detailsData = lrmCustomers.get(customerId);
          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/greenchannel/greenchannelDetails.html', {
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
      //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = lrmCustomers.getSearchList();
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/greenchannel/greenchannelSearch.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {
          lrmCustomers.searchData();
      };
      $scope.loadMoreSearch = function () {
          lrmCustomers.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };
      //编辑页
      $scope.openEditModal = function (item) {
          $scope.editData = {
          };
          $scope.editTitle = "新建";
          if (item != undefined) {
              $scope.editData = item;
              $scope.editTitle = "编辑";
          }

          if ($scope.editModal != undefined) {
              $scope.editModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/greenchannel/greenchannelEdit.html', {
              scope: $scope,
              animation: 'slide-in-up',
          }).then(function (modal) {
              $scope.editModal = modal;
              $scope.editModal.show();
          });
      };
      $scope.closeEditModal = function () {
          if ($learunDataIsAll.isHave($scope.editData)) {
              $learunPopup.confirm({
                  title: '<p> </p>内容未保存，要放弃编辑吗？<p> </p>',
                  okText: '放弃',
                  ok: function () {
                      $scope.editModal.remove();
                  }
              });
          } else {
              $scope.editModal.remove();
          }
      };
      $scope.isInputActive = function (name) {
          return ($scope.editData[name] != null && $scope.editData[name] != "" && $scope.editData[name] != undefined);
      };

      $scope.openTypeSelectModal = function () {//教师类别
          $learunSelectModal({
              title: "教师类别",
              bgAllColor: "royal-bg",
              selectValue: $scope.editData.custTypeId,
              text: "itemName",
              value: "itemValue",
              data: lrmCustomers.getCustType(),
              onChange: function (item) {
                  $scope.editData.custTypeId = item.value;
                  $scope.editData.custTypeName = item.text;
              }
          });
      };
      $scope.openLevelSelectModal = function () {//教师级别
          $learunSelectModal({
              title: "教师级别",
              bgAllColor: "positive-bg",
              selectValue: $scope.editData.custLevelId,
              text: "itemName",
              value: "itemValue",
              data: lrmCustomers.getCustLevel(),
              onChange: function (item) {
                  $scope.editData.custLevelId = item.value;
                  $scope.editData.custLevelName = item.text;
              }
          });
      };
      $scope.openDegreeSelectModal = function () {//教师程度
          $learunSelectModal({
              title: "教师程度",
              bgAllColor: "balanced-bg",
              selectValue: $scope.editData.custDegreeId,
              text: "itemName",
              value: "itemValue",
              data: lrmCustomers.getCustDegree(),
              onChange: function (item) {
                  $scope.editData.custDegreeId = item.value;
                  $scope.editData.custDegreeName = item.text;
              }
          });
      };
      $scope.openTraceUserSelectModal = function () {
          $learunSelectModal({
              title: "主要联系人",
              bgAllColor: "calm-bg",
              selectValue: $scope.editData.traceUserId,
              text: "realName",
              value: "userId",
              data: lrmBaseInfo.getUserInfoList("2f077ff9-5a6b-46b3-ae60-c5acdc9a48f1"),
              onChange: function (item) {
                  $scope.editData.traceUserId = item.value;
                  $scope.editData.traceUserName = item.text;
              }
          });
      };
      //删除
      $scope.doDelete = function (customer) {
          $learunPopup.confirm({
              title: '<p> </p>确定要删除?<p> </p>',
              okText: '删除',
              ok: function () {
                  lrmCustomers.remove(customer);
                  if ($scope.detailsModal != null) {
                      $scope.detailsModal.remove();
                  }
              }
          });
      };
      //添加保存
      $scope.submitCust = function () {
          var res = $learunDataIsAll.isAll($scope.editData, lrmCustomers.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.shortName = $scope.editData.fullName;
              lrmCustomers.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $learunTriggerRefresh.triggerRefresh('customerlist-content');
              });
          }
      }
  }])

;
