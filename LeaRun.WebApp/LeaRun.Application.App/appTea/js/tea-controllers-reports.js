AngCtrl

//报表
.controller('ReportsCtrl', [
    '$scope', '$learunPageModal', '$timeout', '$ionicModal', '$learunPopup', '$ionicLoading', '$learunTopAlert', '$learunTriggerRefresh', '$learunSelectModal', '$learunDataIsAll', 'UserInfo', 'lrmBaseInfo', '$learunHttp', 'ApiUrl',
  function ($scope, $learunPageModal, $timeout, $ionicModal, $learunPopup, $ionicLoading, $learunTopAlert, $learunTriggerRefresh, $learunSelectModal, $learunDataIsAll, UserInfo, lrmBaseInfo, $learunHttp, ApiUrl) {
      $scope.detailsData = UserInfo.get();
      
      //详情页
      $scope.openDetailsModal = function (viewpage, direction) {


          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/reports/'+ viewpage, {
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
      



      $learunPageModal($scope, 'templates/homeApps/reports/');
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
