AngCtrl

//新生信息
.controller('FreshStuCtrl', ['$learunHttp', 'ApiUrl',
   '$scope', '$timeout', '$ionicModal', '$ionicLoading', '$learunTopAlert', '$learunTriggerRefresh', '$learunPopup', '$learunSelectModal', '$learunDataIsAll', 'listFreshStuInfo',
   function ($learunHttp, ApiUrl,$scope, $timeout, $ionicModal, $ionicLoading, $learunTopAlert, $learunTriggerRefresh, $learunPopup, $learunSelectModal, $learunDataIsAll, listFreshStuInfo) {
      //$scope.data = listFreshStuInfo.getList();
      //$scope.TeaClassNo = { "ClassNo": '234234412,16201' };//教师带的班级号

      //刷新数据
      $timeout(function () {
          $learunTriggerRefresh.triggerRefresh('freshStuInfolist-content');
      }, 450);
      $scope.doRefresh = function () {
          //listFreshStuInfo.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          //}, $scope.TeaClassNo);
      };
      $scope.doLoadMore = function () {
          //listFreshStuInfo.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
        // }, $scope.TeaClassNo);
      };


      //详情页======================================================================
      $scope.openDetailsModal = function (freshstuid) {

          if (freshstuid = "MyStudents.html") {
              var queryData = { "ClassNo": '234234412' };
              $learunHttp.post({
                  "url": ApiUrl.freshStuListApi,
                  "data": {"queryData": JSON.stringify(queryData) },
                  "isverify": true,
                  "success": function (data) {
                      $scope.xinshenginfo=data
                  }
              })
          }


          $scope.detailsData = listFreshStuInfo.get(freshstuid);
          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/customers/customersDetails.html', {//?
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
       //======================================================================

      //搜索页
      $scope.closeSearchModal = function () {
          $scope.searchModal.remove();
      };
      $scope.openSearch = function () {
          $scope.searchData = listFreshStuInfo.getSearchList();
          if ($scope.searchModal != null) {
              $scope.searchModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/baodao/MyStudents.html', {
              scope: $scope,
              animation: 'lr-slide-in-right',
              focusFirstInput: true
          }).then(function (modal) {
              $scope.searchModal = modal;
              $scope.searchModal.show();
          });

      };
      $scope.doSearch = function () {
          listFreshStuInfo.searchData();
      };
      $scope.loadMoreSearch = function () {
          listFreshStuInfo.searchDataAdd(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

  }])


//预约管理
.controller('BaodaoYueyueCtrl', [
  '$scope', '$timeout', '$ionicModal', '$ionicLoading', '$learunTopAlert', '$learunTriggerRefresh', '$learunPopup', '$learunSelectModal', '$learunDataIsAll', 'listBaodaoYuyue'
  , function ($scope, $timeout, $ionicModal, $ionicLoading, $learunTopAlert, $learunTriggerRefresh, $learunPopup, $learunSelectModal, $learunDataIsAll, listBaodaoYuyue) {
      $scope.data = listBaodaoYuyue.getList();
      //刷新数据
      $timeout(function () {
          $learunTriggerRefresh.triggerRefresh('yystudentslist-content');//'yystudentslist-content'注意和jiezhan.html中的对应
      }, 450);
      $scope.doRefresh = function () {
          listBaodaoYuyue.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          });
      };
      $scope.doLoadMore = function () {
          listBaodaoYuyue.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          });
      };

      ////详情页
      //$scope.openDxxxDetailsModal = function (viewpage, obj) {
      //    if (viewpage == "JiezhanstuDetails.html") {
      //        $scope.yuyue = obj;
      //    }

      //    //$scope.detailsData = lrmCustomers.get(customerId);
      //    if ($scope.detailsModal != null) {
      //        $scope.detailsModal.remove();
      //    }
      //    $ionicModal.fromTemplateUrl('templates/homeApps/baodao/' + viewpage, {
      //        scope: $scope,
      //        animation: 'lr-slide-in-right',
      //    }).then(function (modal) {
      //        $scope.detailsModal = modal;
      //        $scope.detailsModal.show();
      //    });
      //};
      //$scope.closeDxxxDetailsModal = function () {
      //    alert('sss')
      //    $scope.detailsModal.remove();
      //};



  }])

   


//抵校管理
.controller('BaodaoCtrl', [
    '$scope', '$learunPageModal', '$timeout', '$ionicModal', '$learunPopup', '$ionicLoading', '$learunTopAlert', '$learunTriggerRefresh', '$learunSelectModal', '$learunDataIsAll', 'UserInfo', 'lrmBaseInfo', '$learunHttp', 'ApiUrl', 'AQuestions', 'StuLeave', 'CancelApp',
  function ($scope, $learunPageModal, $timeout, $ionicModal, $learunPopup, $ionicLoading, $learunTopAlert, $learunTriggerRefresh, $learunSelectModal, $learunDataIsAll, UserInfo, lrmBaseInfo, $learunHttp, ApiUrl, AQuestions, StuLeave, CancelApp) {
      $scope.detailsData = UserInfo.get();
      $scope.editData = {};
      $scope.TCdata = {};
      $scope.Number = {};
     


      //显示记录数量
      $scope.NumberModal = function () {
          
          $learunHttp.post({//接站信息
              "url": ApiUrl.TeaJiezhanNumberApi,
              "success": function (data) {
                  $scope.Number.Jiezhan = data;
              }
          });
          $learunHttp.post({//军训服信息
              "url": ApiUrl.TeaJunxunfuNumberApi,
              "success": function (data) {
                  $scope.Number.Junxunfu = data;
              }
          });
          $learunHttp.post({//绿色通道
              "url": ApiUrl.TeaLvsetongdaoNumberApi,
              "success": function (data) {
                  $scope.Number.Lvsetongdao = data;
              }
          });
          $learunHttp.post({//推迟报到
              "url": ApiUrl.TeaTuichibaodaoNumberApi,
              "success": function (data) {
                  $scope.Number.Tuichibaodao = data;
              }
          });
          $learunHttp.post({//咨询回复
              "url": ApiUrl.TeaZixunhuifuNumberApi,
              "success": function (data) {
                  $scope.Number.Zixunhuifu = data;
              }
          });
          //$learunHttp.post({//新生花名册
          //    "url": ApiUrl.TeaXinshengNumberApi,
          //    "success": function (data) {
          //        $scope.Number.Xinsheng = data;
          //    }
          //});
          $learunHttp.post({//新生住宿信息
              "url": ApiUrl.TeaXinshengzhusuNumberApi,
              "success": function (data) {
                  $scope.Number.Xinshengzhusu = data;
              }
          });
      }
      //工作办理记录数
      $scope.HomeWork = function () {
          $learunHttp.post({//请假
              "url": ApiUrl.TeaStuLeaveNumberApi,
              "success": function (data) {
                  $scope.Number.TeaStuLeaveNumber = data;
              }
          });
          $learunHttp.post({//操行扣分撤销申请
              "url": ApiUrl.TeaCancelAppNumberApi,
              "success": function (data) {
                  $scope.Number.TeaCancelAppNumber = data;
              }
          });
      }

      //打开报到功能模块页==============================================================
      $scope.openBaodaoFuncModal = function (viewpage, direction, obj) {

          if (viewpage == "MyStudents.html") {
              var queryData = { "ClassNo": "234234412,124454567" };//多个班级号如何传值
              $learunHttp.post({
                  "url": ApiUrl.freshStuListApi,
                  "data": { "queryData": JSON.stringify(queryData) },
                  "isverify": true,
                  "success": function (data) {
                      $scope.xinshenginfo = data;
                  }
              })
          }

          if (viewpage == "answerDetails.html") {
              $scope.Qstu = {};
              //查找咨询学生信息
              $learunHttp.post({
                  "url": ApiUrl.TeaQStuListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": null },
                  "success": function (data) {
                      $scope.Qstu = data;
                  }
              });
          }
          
          


          if (viewpage == "Junxunfu.html") {
              $scope.Junxunfu = {};
              //查找军训服装信息
              $learunHttp.post({
                  "url": ApiUrl.JunXunFuListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": null },
                  "success": function (data) {
                      $scope.Junxunfu = data;
                  }
              });
          }
          if (viewpage == "junxunfuDetails.html") {
              //军训服详情页
              $scope.junxunfuzhuang = {};
              $scope.junxunfuzhuang = obj;
          }



          if (viewpage == "lvsetongdao.html") {
              $scope.lvse = {};
              //查询绿色通道信息
              $learunHttp.post({
                  "url": ApiUrl.LvseTongdaoListApi,
                  "data":{"page": 1, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": null },
                  "success": function (data) {
                      $scope.lvse = data;
                  }
              });
          }
          if (viewpage == "lvsetongdaoDetails.html") {
              $scope.lvseInfo = obj;
              //查询绿色通道信息
              
          }


          if (viewpage == "MyStuLeave.html") {
              $scope.ruzhu = {};
              //查询宿舍入住情况
              $learunHttp.post({
                  "url": ApiUrl.RuZhuListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": null },
                  "success": function (data) {
                      $scope.ruzhu = data;
                  }
              });
          }
          


          if (viewpage == "qingjiashenpiDetails.html") {
              $scope.LeaveStu = {};
              //查询请假学生列表
              $learunHttp.post({
                  "url": ApiUrl.LeaveStuListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": null },
                  "success": function (data) {
                      $scope.LeaveStu = data;
                  }
              });
          }
          if (viewpage == "qingjiaweishenpi.html") {
              $scope.NotReviewStuLeaveList = {};
              var queryData = { "StuNo": obj.stuNo };
              //查询未审核学生请假列表
              $learunHttp.post({
                  "url": ApiUrl.TeaGetNotReviewStuLeaveListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.NotReviewStuLeaveList = data.result.rows;
                  }
              });
          }

          if (viewpage == "qingjiayishenpi.html") {
              $scope.ReviewStuLeaveList = {};
              var queryData = { "StuNo": obj.stuNo };
              //查询已审核学生请假列表
              $learunHttp.post({
                  "url": ApiUrl.TeaGetReviewStuLeaveListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.ReviewStuLeaveList = data.result.rows;
                  }
              });
          }
          if (viewpage == "qingjiaResult.html" || viewpage == "qingjiashenpi2Details.html") {//审核详细页面
              $scope.ReviewLeaveStuInfo = {};
              $scope.StuLeaveMajorClassInfo = {};
              $scope.ReviewLeaveStuInfo = obj;
              var queryData = { "StuNo": obj.stuNo };
              //查询请假学生的班级专业信息
              $learunHttp.post({
                  "url": ApiUrl.TeaGetStuLeaveMajorClassInfoApi,
                  "data": { "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.StuLeaveMajorClassInfo = data.result;
                  }
              });
          }
          

          if (viewpage == "TeaCaoxingKoufenChexiaoList.html") {
              $scope.ReviewStuCaoxingKoufenList = {};
              //查询操行扣分撤销申请列表
              $learunHttp.post({
                  "url": ApiUrl.TeaGetReviewStuCaoxingKoufenListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "StuName", "sord": "desc" },
                  "success": function (data) {
                      $scope.ReviewStuCaoxingKoufenList = data.result.rows;
                  }
              });
          }
          if (viewpage == "TeaChakanCaoxingChexiaoShenqing.html") {
              $scope.StuCaoxingKoufenInfo = obj;//单条记录详细信息
          }



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
      $scope.closeBaodaoFuncModal = function () {//关闭页面
          $scope.detailsModal.remove();
      };
      //报到功能modal-end===================================================================



      //添加保存咨询回复消息
      $scope.SaveAnswerSubmit = function () {
          var res = $learunDataIsAll.isAll($scope.editData, AQuestions.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + " 不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.stuInfoId = $scope.AnswerStuInfoId;
              $scope.editData.atime = new Date();
              AQuestions.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $learunTriggerRefresh.triggerRefresh('answer-content');
              });
          }
          $scope.$broadcast('scroll.refreshComplete');
      }

      $scope.doRefresh = function () {//刷新页面
          //查找出有推迟报到的学生与班级
          $learunHttp.post({
              "url": ApiUrl.TuiChiInfoListApi,
              "data": { "page": 1, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": null },
              "success": function (data) {
                  $scope.TCdata = data;
              }
          });
          $scope.$broadcast('scroll.refreshComplete');
      };
      
      $scope.JustRefresh = function () {//刷新页面
          $scope.$broadcast('scroll.refreshComplete');
      };





      //请假审核代码start===================================================================
      $scope.editData = {};
      $scope.submitLeaveshenpi = function () {
          var res = $learunDataIsAll.isAll($scope.editData, StuLeave.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.iD = $scope.ReviewLeaveStuInfo.iD;
              StuLeave.editSubmit($scope.editData, function () { 
                  $ionicLoading.hide();
                  $scope.detailsModal.remove();
                  $learunTriggerRefresh.triggerRefresh('Leaveshenpi-content');
              });
          }
      }
      //请假审核代码end==================================================================

      //操行扣分申请撤销代码start===================================================================
      $scope.editData = {};
      $scope.submitCancelAppReview = function () {
          
          var res = $learunDataIsAll.isAll($scope.editData, CancelApp.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.appId = $scope.StuCaoxingKoufenInfo.appId;
              $scope.editData.checker = $scope.detailsData.name;
              $scope.editData.roleName = "教师";
              $scope.editData.checkerTime = new Date();

              CancelApp.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.detailsModal.remove();
                  $learunTriggerRefresh.triggerRefresh('TeaReviewCancelApp-content');
              });
          }
      }
      //操行扣分申请撤销代码end==================================================================



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
