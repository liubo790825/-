AngCtrl//angular.module('starter.controllers', [])

//抵校管理
.controller('BaodaoCtrl', ['$learunHttp','ApiUrl',
    '$scope', '$learunPageModal', '$timeout', '$ionicModal', '$learunPopup', '$ionicLoading', '$learunTopAlert', '$learunTriggerRefresh', '$learunSelectModal', '$learunDataIsAll', 'UserInfo', 'Dxdj', 'YuyueInfo', '$learunFormatDate', 'DormBedChoice', 'MyRoommatesList', 'listClassmates', 'JunXunFu', 'MyQuestion', 'TuiChiBaoDao', 'LvseTongdao', 'StuLeave', 'BehaviorRecode', 'CancelApp', 'ExchangeDorm',
  function ($learunHttp, ApiUrl, $scope, $learunPageModal, $timeout, $ionicModal, $learunPopup, $ionicLoading, $learunTopAlert, $learunTriggerRefresh, $learunSelectModal, $learunDataIsAll, UserInfo, Dxdj, YuyueInfo, $learunFormatDate, DormBedChoice, MyRoommatesList, listClassmates, JunXunFu, MyQuestion, TuiChiBaoDao, LvseTongdao, StuLeave, BehaviorRecode, CancelApp, ExchangeDorm) {
      $scope.stuinfo = UserInfo.get();
      var queryData = { "BaodaoOther1": $scope.stuinfo.identityCardNo };
      $scope.yydata = {};// YuyueInfo.get();//获得已有报到预约取数据
      $scope.MyRoommatesdata = MyRoommatesList.getList();//获取同寝室学生信息
      $scope.data = listClassmates.getList();//获取同学学生信息
      $scope.MyQuestionData = MyQuestion.getList();//获取咨询的问题

      $scope.Number = {};//记录数量



      //$scope.yydata = YuyueInfo.getEntity();//测试用

      //$scope.ssdata = DormChoice.getList();//获得宿舍信息
      //$scope.cwdata = DormBedChoice.getList();//获得床位信息
      //var dormstandard = [{
      //    id: 0,
      //    type: '四人间',
      //    price: '1480',     
      //    left: '32'
      //}, {
      //    id: 1,
      //    type: '六人间',
      //    price: '1280',
      //    left: '129'
      //}];
      //$scope.dormStandard = dormstandard;
      ////刷新数据
      //$timeout(function () {
      //    $learunTriggerRefresh.triggerRefresh('classmates-content');
      //}, 450);
      //$scope.doRefresh = function () {
      //    listClassmates.update(function () {
      //        $scope.$broadcast('scroll.refreshComplete');
      //    });
      //};
      //$scope.doLoadMore = function () {
      //    listClassmates.add(function () {
      //        $scope.$broadcast('scroll.infiniteScrollComplete');
      //    });
      //};

      //预约报到代码start===================================================================




      //（报到预约）详情页(此为通用页,考虑做些判断)
      $scope.openDetailsModal = function (viewpage, direction, obj) {
          if (viewpage == "BaodaoDetails.html") {//判断是否打开报到预约详情页面
                   $learunHttp.post({
                      "url": ApiUrl.YuyueListApi,
                      "data": { "queryData": JSON.stringify(queryData) },
                      "success": function (data) {
                          yuyueInfo = data.result;
                          if (yuyueInfo != null)
                              yuyueInfo.arrivalDate = yuyueInfo.arrivalDate == null ? "" : $learunFormatDate(yuyueInfo.arrivalDate, 'yyyy-MM-dd hh:mm'); //格式化日期
                          $scope.item = yuyueInfo;
                          return yuyueInfo;
                      }
                  });
          }

          if (viewpage == "JunxunfuDetails.html") {//判断是否打开军训服装详情页面
              $learunHttp.post({
                  "url": ApiUrl.junXunFuListApi,
                  "data": { "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      junXunFuInfo = data.result;
                      if (junXunFuInfo != null)
                          //junXunFuInfo.arrivalDate = junXunFuInfo.arrivalDate == null ? "" : $learunFormatDate(junXunFuInfo.arrivalDate, 'yyyy-MM-dd hh:mm'); //格式化日期
                      $scope.item = junXunFuInfo;
                      return junXunFuInfo;
                  }
              });
          }

          if (viewpage == "TuichiBaodao.html") {//判断是否打开推迟报到详情页面

              var queryData = { "IdentityCardNo": $scope.stuinfo.identityCardNo };
              $learunHttp.post({
                  "url": ApiUrl.TuiChiBaoDaoListApi,
                  "data": { "queryData": JSON.stringify(queryData) },
                  "async":false,
                  "success": function (data) {
                                  $scope.editData = {};
                                  if (data != undefined) {
                                      $scope.editData = data;
                                      $scope.editTitle = "推迟报到信息修改";
                                  }
                      TuiChiInfo = data.result;
                      if (TuiChiInfo != null)
                      $scope.editData = TuiChiInfo;
                      return TuiChiInfo;
                  }
              });
          }

          if (viewpage == "ask.html") {
              //获取回复信息
              $scope.answer = {};
              var queryData = { "stuInfoId": $scope.stuinfo.stuInfoId };
              $learunHttp.post({
                  "url": ApiUrl.StuAnswerListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "Atime", "sord": "desc", "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.answer = data;
                  }
              });

          }

          if (viewpage == "lvsetongdaoEdit.html") {//判断是否打开绿色通道页面

              var queryData = { "StuInfoId": $scope.stuinfo.stuInfoId };
              $learunHttp.post({
                  "url": ApiUrl.LvseTongdaoListApi,
                  "data": { "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.editData = {};
                      if (data != undefined) {
                          $scope.editData = data;
                          $scope.editTitle = "推迟报到信息修改";
                      }
                      LvseInfo = data.result;
                      if (LvseInfo != null)
                          $scope.editData = LvseInfo;
                      return LvseInfo;
                  }
              });

              $scope.openHujiLeibieSelectModal = function () {//选择户籍类别
                  $learunSelectModal({
                      title: "户籍类别",
                      bgAllColor: "royal-bg",
                      selectValue: $scope.editData.hujiLeibie,
                      text: "itemName",
                      value: "itemValue",
                      data: LvseTongdao.getHujiLeibie(),
                      onChange: function (item) {
                          $scope.editData.hujiLeibie = item.value;
                          $scope.editData.hujiLeibie = item.text;
                      }
                  });
              };
              $scope.openFamilyTypeSelectModal = function () {//选择家庭类型
                  $learunSelectModal({
                      title: "家庭类型",
                      bgAllColor: "royal-bg",
                      selectValue: $scope.editData.familyType,
                      text: "itemName",
                      value: "itemValue",
                      data: LvseTongdao.getFamilyType(),
                      onChange: function (item) {
                          $scope.editData.familyType = item.value;
                          $scope.editData.familyType = item.text;
                      }
                  });
              };
              $scope.openLoanBankSelectModal = function () {//选择生源地贷款银行
                  $learunSelectModal({
                      title: "生源地贷款银行",
                      bgAllColor: "royal-bg",
                      selectValue: $scope.editData.loanBank,
                      text: "itemName",
                      value: "itemValue",
                      data: LvseTongdao.getLoanBank(),
                      onChange: function (item) {
                          $scope.editData.loanBank = item.value;
                          $scope.editData.loanBank = item.text;
                      }
                  });
              };
          }

          

          if (viewpage == "qingjiaDetails.html") { //判断打开请假详情页
              var dt =new Date();
              var queryData = { "StuNo": $scope.stuinfo.stuNo };
              $learunHttp.post({
                  "url": ApiUrl.StuLeaveListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "CreateDate", "sord": "desc", "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.editData = {};
                      if (data != undefined) {
                          $scope.editData = data;
                      }
                      StuLeaveInfo = data.result;
                      if (StuLeaveInfo != null) {
                          for (var i in StuLeaveInfo.rows) {
                              var endtime = new Date(StuLeaveInfo.rows[i].endTime.replace("T", " "));

                              if (StuLeaveInfo.rows[i].beAllow == '0') {
                                  StuLeaveInfo.rows[i].beAllow = '审核中';
                              }
                              else if (StuLeaveInfo.rows[i].beAllow == '1') {

                                  StuLeaveInfo.rows[i].beAllow = '审核通过';
                                  if (StuLeaveInfo.rows[i].beCancel == "1") {
                                      StuLeaveInfo.rows[i].beAllow = '已销假';
                                  }
                                  if (dt > endtime && StuLeaveInfo.rows[i].beCancel != "1") {
                                      StuLeaveInfo.rows[i].beAllow = '已超时';
                                  }
                                  if (dt < endtime && StuLeaveInfo.rows[i].beCancel != "1") {
                                      StuLeaveInfo.rows[i].beAllow = '未销假';
                                  }
                                  
                              }
                              else {
                                  StuLeaveInfo.rows[i].beAllow = '审核未通过';
                              }
                          }
                          $scope.editData = StuLeaveInfo;
                      }
                         
                      return StuLeaveInfo;
                  }
              });
          }


          if (viewpage == "qingjiaResult.html") {//判断打开单条请假记录详细
              var queryData = { "ID": obj.iD };
              $learunHttp.post({
                  "url": ApiUrl.StuLeaveResultListApi,
                  "data": {"queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.editData = {};
                      if (data != undefined) {
                          $scope.editData = data;
                      }
                      StuLeaveResultInfo = data.result;
                      if (StuLeaveInfo != null) {
                          $scope.editData = StuLeaveResultInfo;
                      }
                      return StuLeaveResultInfo;
                  }
              });
          }
          
          if (viewpage == "Zonghexuefen-Jiangzuo.html") {//查看综合成绩分数
              var queryData = { "StuId": $scope.stuinfo.stuInfoId };
              $learunHttp.post({
                  "url": ApiUrl.QualityScoreListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "QualityId", "sord": "desc", "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.QualityInfo = {};
                      if (data != undefined) {
                          $scope.QualityInfo = data;
                      }
                      QualityScore = data.result;
                      if (QualityScore != null) {
                          $scope.QualityInfo = QualityScore;
                      }
                      return QualityScore;
                  }
              });

          }


          if (viewpage == "CaoxingfenshuDetails.html") {
              $scope.openHujiLeibieSelectModal = function () {//选择违规操行类型
                  $learunSelectModal({
                      title: "违规操行类别",
                      bgAllColor: "royal-bg",
                      selectValue: $scope.editData.breachBehavior,
                      text: "itemName",
                      value: "itemValue",
                      data: BehaviorRecode.getBehaviorRecodeType(),
                      onChange: function (item) {
                          $scope.editData.breachBehavior = item.value;
                          $scope.editData.breachBehavior = item.text;
                      }
                  });
              };
          }


          if (viewpage == "ChakanCaoxingfenshuList.html") {//查看我的操行违规记录
              var queryData = { "StuNo": $scope.stuinfo.stuNo };
              $learunHttp.post({
                  "url": ApiUrl.GetMyBreachBehaviorListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "BreachTime", "sord": "desc", "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.MyBreachBehaviorList = {};
                      if (data != undefined) {
                          $scope.MyBreachBehaviorList = data;
                      }
                      MyBreachBehaviorList = data.result;
                      if (MyBreachBehaviorList != null) {
                          $scope.MyBreachBehaviorList = MyBreachBehaviorList;
                          for (i in MyBreachBehaviorList.rows) {
                              if ($scope.MyBreachBehaviorList.rows[i].isCanceled == "0") {
                                  $scope.MyBreachBehaviorList.rows[i].isCanceled = "未撤销";
                                  $scope.MyBreachBehaviorList.rows[i].show = "true";
                              }
                              else if ($scope.MyBreachBehaviorList.rows[i].isCanceled == "1") {
                                  $scope.MyBreachBehaviorList.rows[i].isCanceled == "撤销申请中";
                                  $scope.MyBreachBehaviorList.rows[i].show = "false";
                              }
                              else {
                                  $scope.MyBreachBehaviorList.rows[i].isCanceled = "已撤销";
                                  $scope.MyBreachBehaviorList.rows[i].show = "false";
                              }
                          }
                      }
                      return MyBreachBehaviorList;
                  }
              });
          }

          if (viewpage == "ChakanCaoxingfenshuDetails.html") {//查看我的操行违规记录详细信息
              $scope.MyBreachBehaviorInfo = obj;
          }


          if (viewpage == "CaoxingKoufenChexiaoList.html") {//申请撤销操行违规记录列表
              $learunHttp.post({
                  "url": ApiUrl.GetcancelAppListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "CheckerTime", "sord": "desc" },
                  "success": function (data) {
                      $scope.cancelAppList = {};
                      if (data != undefined) {
                          $scope.cancelAppList = data;
                      }
                      cancelAppList = data.result;
                      if (cancelAppList != null) {
                          $scope.cancelAppList = cancelAppList;
                      }
                      return cancelAppList;
                  }
              });
          }
          if (viewpage == "ChakanCaoxingChexiaoShenqing.html") {
              $scope.cancelAppInfo = obj;//单条记录详细信息
          }

          if (viewpage == "CaoxingKoufenYuChexiao.html") {
              $learunHttp.post({//未处理撤销申请记录数
                  "url": ApiUrl.StuCaoXingCheXiaoNumberApi,
                  "success": function (data) {
                         $scope.Number.CaoXingCheXiaoNumber = data
                  }
              });   
          }

          if (viewpage == "DormExchangeGetMyInfo.html") {//我的宿舍交换申请记录
              $scope.DormExchangeGetMyInfo = {};
              var queryData = { "AppStuNo": $scope.stuinfo.stuNo };
              $learunHttp.post({
                  "url": ApiUrl.SelectMyDromExchagngeApi,
                  "data": { "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.DormExchangeGetMyInfo = data.result;
                      if ($scope.DormExchangeGetMyInfo.targetPassed == "0") {
                          $scope.DormExchangeGetMyInfo.targetPassed = "未查看"
                      }
                      else if ($scope.DormExchangeGetMyInfo.targetPassed == "1") {
                          $scope.DormExchangeGetMyInfo.targetPassed = "同意"
                      }
                      else {
                          $scope.DormExchangeGetMyInfo.targetPassed = "不同意"
                      }
                      if ($scope.DormExchangeGetMyInfo.passed == "1") {
                          $scope.DormExchangeGetMyInfo.passed = "申请中"
                      }
                      else if ($scope.DormExchangeGetMyInfo.passed == "2") {
                          $scope.DormExchangeGetMyInfo.passed = "通过"
                      }
                      else {
                          $scope.DormExchangeGetMyInfo.passed = "未通过"
                      }
                  }
              });
          }


          if (viewpage == "DormExchangeMyList.html") {//对我的交换申请
              $scope.GetMyExchangeList = {};
              var queryData = {"page": 1, "rows": 10, "sidx": "AppStuName", "sord": "desc" , "TargetStuNo": $scope.stuinfo.stuNo };
              $learunHttp.post({
                  "url": ApiUrl.GetMyExchangeListApi,
                  "data": { "queryData": JSON.stringify(queryData)},
                  "success": function (data) {
                      $scope.GetMyExchangeList = data.result.rows;
                      for (i in $scope.GetMyExchangeList) {
                          if ($scope.GetMyExchangeList[i].passed == "2") {
                              $scope.GetMyExchangeList[i].status = "已通过";
                              $scope.GetMyExchangeList[i].passed = "false";
                          }
                          else if ($scope.GetMyExchangeList[i].passed == "1") {
                          
                              if ($scope.GetMyExchangeList[i].targetPassed == "0") {
                                  $scope.GetMyExchangeList[i].status = "未处理";
                              }
                              else if ($scope.GetMyExchangeList[i].targetPassed == "1") {
                                  $scope.GetMyExchangeList[i].status = "等待老师审核";
                              }
                          }
                      }
                  }
              });
          }
          if (viewpage == "DormExchangeMyListDetails.html") {
              $scope.GetMyExchangeList = obj;
          }
          




          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/baodao/' + viewpage, {
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


     




      //（军训服和报到预约登记）编辑页(此为通用页,考虑做些判断),item为传入的要编辑的对象
      $scope.openEditModal = function (viewpage, direction, item) {
          $scope.editData = {};
          $scope.editTitle = "抵校信息";
          if (viewpage == "baodaoEdit.html") {//判断是否打开报到预约编辑页面
              if ($scope.item != undefined) {
                  $scope.editData = $scope.item;
                  $scope.editTitle = "抵校信息修改";
              }
              else {
                  editTitle = "抵校信息登记";
                  $scope.editData.stuNo = $scope.stuinfo.stuNo;
                  $scope.editData.stuName = $scope.stuinfo.stuName;
                  $scope.editData.baodaoOther1 = $scope.stuinfo.identityCardNo;              
              }
          }

          if (viewpage == "qingjiaadd.html") {
              $scope.editData = {};
              $scope.openLeaveTypeSelectModal = function () {//选择请假类型
                  $learunSelectModal({
                      title: "请假类型",
                      bgAllColor: "royal-bg",
                      selectValue: $scope.editData.leaveType,
                      text: "itemName",
                      value: "itemDetailId",
                      data: StuLeave.getLeaveType(),
                      onChange: function (item) {
                          $scope.editData.leaveTypeId = item.value;
                          $scope.editData.leaveType = item.text;
                      }
                  });
              };
          }


          if (viewpage == "junxunfuEdit.html") {//判断是否打开军训服装编辑页面
              if ($scope.item != undefined) {
                  $scope.editData = $scope.item;
                  $scope.editTitle = "军训服信息修改";
              }
              else {
                  editTitle = "军训服信息登记";
                  $scope.editData.stuNo = $scope.stuinfo.stuNo;
                  $scope.editData.baodaoOther1 = $scope.stuinfo.identityCardNo;
              }
          }

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
      
      $scope.openArrivalModeSelectModal = function () {//选择到达方式
          $learunSelectModal({
              title: "到达方式",
              bgAllColor: "royal-bg",
              selectValue: $scope.editData.arrivalMode,
              text: "itemName",
              value: "itemValue",
              data: Dxdj.getArrivalMode(),
              onChange: function (item) {
                  $scope.editData.arrivalMode = item.value;
                  $scope.editData.arrivalMode = item.text;
              }
          });
      };
      $scope.openArrivalPositionSelectModal = function () {//选择到站地点
          $learunSelectModal({
              title: "到站地点",
              bgAllColor: "royal-bg",
              selectValue: $scope.editData.arrivalPosition,
              text: "itemName",
              value: "itemValue",
              data: Dxdj.getArrivalPosition(),
              onChange: function (item) {
                  $scope.editData.arrivalPosition = item.value;
                  $scope.editData.arrivalPosition = item.text;
              }
          });
      };


      $scope.JunXunFuSize = {//军训服装尺寸
          S: { "bgColor": 'positive-bg', "itemName": 'S', "itemValue": 'S' },
          M: { "bgColor": 'royal-bg', "itemName": 'M', "itemValue": 'M' },
          L: { "bgColor": 'energized-bg', "itemName": 'L', "itemValue": 'L' },
          XL: { "bgColor": 'balanced-bg', "itemName": 'XL', "itemValue": 'XL' },
          XXL: { "bgColor": 'assertive-bg', "itemName": 'XXL', "itemValue": 'XXL' },
          XXXL: { "bgColor": 'stable-bg', "itemName": 'XXXL', "itemValue": 'XXXL' },
      };
      $scope.openJXFClothSelectModal = function () {//选择军训衣服尺寸
          $learunSelectModal({
              title: "衣服尺码",
              bgAllColor: "royal-bg",
              selectValue: $scope.editData.clothSize,
              text: "itemName",
              value: "itemValue",
              data: $scope.JunXunFuSize,
              onChange: function (item) {
                  $scope.editData.clothSize = item.value;
                  $scope.editData.clothSize = item.text;
              }
          });
      };
      $scope.openJXFPantsSelectModal = function () {//选择军训裤子尺寸
          $learunSelectModal({
              title: "裤子尺码",
              bgAllColor: "royal-bg",
              selectValue: $scope.editData.pantsSize,
              text: "itemName",
              value: "itemValue",
              data: $scope.JunXunFuSize,
              onChange: function (item) {
                  $scope.editData.pantsSize = item.value;
                  $scope.editData.pantsSize = item.text;
              }
          });
      };
      
      //添加修改预约报到保存
      $scope.submitYuyue = function () {
          var res = $learunDataIsAll.isAll($scope.editData, Dxdj.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.stuNo = $scope.stuinfo.stuNo;
              $scope.editData.stuName = $scope.stuinfo.stuName;
              $scope.editData.baodaoOther1 = $scope.stuinfo.identityCardNo;
              Dxdj.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $learunTriggerRefresh.triggerRefresh('baodaoDetailHandle');
              });
          }
      }


      //添加修改军训服保存
      $scope.submitJunXunFu = function () {
          var res = $learunDataIsAll.isAll($scope.editData, JunXunFu.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.stuNo = $scope.stuinfo.stuNo;
              $scope.editData.baodaoOther1 = $scope.stuinfo.identityCardNo;
              JunXunFu.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $learunTriggerRefresh.triggerRefresh('JunXunFuHandle');
              });
          }
      }
      //预约报到代码end===================================================================




      //预约宿舍代码start===================================================================


      //显示各标准余下床位
      $scope.DormStandard = [{
          left4: 65,
          left6: 112
      }];
      $scope.left = 444;


      //显示宿舍标准选择
      $scope.openDormStandardModal = function (viewpage, direction) {
          

          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/baodao/' + viewpage, {
              scope: $scope,
              animation: 'slide-in-' + direction,//left,right,up,down
          }).then(function (modal) {
              $scope.detailsModal = modal;
              $scope.detailsModal.show();
          });
      };

      $scope.cwdata = {};

      //选中房间标准后
      $scope.submitDormStandard = function (standard) {
          $scope.standard = standard;
          $learunTopAlert.show({ text: "已提交房间标准：" + standard });


          //根据标准找出符合的床位 standard=800,本专业的
          var queryData = { "MajorId": $scope.stuinfo.majorNo, "Price": standard, "DormFloorsType": $scope.stuinfo.gender + '生' };
          $learunHttp.post({
              "url": ApiUrl.dormBedListApi,
              "data": { "queryData": JSON.stringify(queryData) },
              "success": function (data) {
                  $scope.cwdata = data;
              }
          });
          $scope.openDormSelectModal('DormSelect.html', 'right', standard);//使用双重循环

      }

      //显示可用标准之床位
      $scope.openDormSelectModal = function (viewpage, direction, standard) {

          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/baodao/' + viewpage, {
              scope: $scope,
              animation: 'slide-in-' + direction,//left,right,up,down
          }).then(function (modal) {
              $scope.detailsModal = modal;
              $scope.detailsModal.show();
          });
      };

      //选中床位后
      $scope.submitBedSelect = function (choicebed) {
          $learunTopAlert.show({ text: "已提交床位号：" + choicebed });
          DormBedChoice.saveSubmit(choicebed, $scope.stuinfo.stuInfoId);

          //if ($scope.detailsModal != null) {
          //    $scope.detailsModal.remove();
          //}
      }

      //查看宿舍 数据  
 
      $scope.DormInfodoRefresh = function () {
          $scope.cwdata = DormBedChoice.getList($scope.standard, $scope.stuinfo.gender);
          $scope.$broadcast('scroll.refreshComplete');
      };
      //预约宿舍代码end===================================================================



      // 我的室友代码start===================================================================
      //查找登陆用户的寝室数据    
      $timeout(function () {
          $learunTriggerRefresh.triggerRefresh('Roommates-content');
      }, 450);
      $scope.MyRoommatesdoRefresh = function () {
          MyRoommatesList.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          }, $scope.stuinfo.stuInfoId);

      };
      $scope.MyRoommatesdoLoadMore = function () {
          MyRoommatesList.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          }, $scope.stuinfo.stuInfoId);
      };
      //我的室友代码end===================================================================

      // 我的同学代码start===================================================================
      //刷新 查看同班同学 数据  
      $timeout(function () {
          $learunTriggerRefresh.triggerRefresh('classmates-content');
      }, 450);
      $scope.ClassmatesdoRefresh = function () {
          listClassmates.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          }, $scope.stuinfo.classNo);
      };
      $scope.ClassmatesdoLoadMore = function () {
          listClassmates.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          }, $scope.stuinfo.classNo);
      };
      //我的同学代码end===================================================================


      //我要咨询代码start===================================================================
      //我要咨询



      $scope.Question = {};
      $scope.submitMyQuestion = function () {
          var res = $learunDataIsAll.isAll($scope.Question, MyQuestion.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.Question.stuName = $scope.stuinfo.stuName;
              $scope.Question.qAOther1 = $scope.stuinfo.identityCardNo;
              $scope.Question.stuInfoId = $scope.stuinfo.stuInfoId;
              $scope.Question.qtime = new Date();
              MyQuestion.editSubmit($scope.Question, function () {
                  $ionicLoading.hide();
                  $scope.editModal.remove();
                  $learunTriggerRefresh.triggerRefresh('MyQuestionHandle');
              });
          }
      }

      //刷新页面
      $timeout(function () {
          $learunTriggerRefresh.triggerRefresh('Roommates-content');
      }, 450);
      $scope.MyQuestiondoRefresh = function () {
          MyQuestion.update(function () {
              $scope.$broadcast('scroll.refreshComplete');
          }, $scope.stuinfo.identityCardNo);

      };
      $scope.MyQuestiondoLoadMore = function () {
          MyQuestion.add(function () {
              $scope.$broadcast('scroll.infiniteScrollComplete');
          }, $scope.stuinfo.identityCardNo);
      };


      //我要咨询代码end===================================================================




    
      //推迟报到代码start===================================================================
      //推迟报到保存
      $scope.editData = {};
      $scope.submitTuiChi = function () {
          var res = $learunDataIsAll.isAll($scope.editData, TuiChiBaoDao.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.stuNo = $scope.stuinfo.stuNo;
              $scope.editData.identityCardNo = $scope.stuinfo.identityCardNo;
              $scope.editData.tuiChiOther = new Date();
              $scope.editData.tuiChiOther1 = $scope.stuinfo.classNo;
              $scope.editData.tuiChiOther2 = $scope.stuinfo.className;
              TuiChiBaoDao.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.detailsModal.remove();
                  $learunTriggerRefresh.triggerRefresh('TuiChiBaodaolist-content');
              });
          }
      }
      //推迟报到代码end===================================================================



      //绿色通道代码start===================================================================
      $scope.editData = {};
      $scope.submitLvseTongdao = function () {
          var res = $learunDataIsAll.isAll($scope.editData, LvseTongdao.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.stuInfoId = $scope.stuinfo.stuInfoId;
              $scope.editData.stuName = $scope.stuinfo.stuName;
              $scope.editData.LvseOther = new Date();
              LvseTongdao.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.detailsModal.remove();
                  $learunTriggerRefresh.triggerRefresh('LvseTongdaoInfo-content');
              });
          }
      }

      $timeout(function () {
          $learunTriggerRefresh.triggerRefresh('LvseTongdaoInfo-content');
      }, 450);
      $scope.LvseTongdaodoRefresh = function () {
              $scope.$broadcast('scroll.refreshComplete');
      };
      //绿色通道代码end==================================================================


      //学生请假代码start=================================================================
      //保存学生请假信息
      $scope.editData = {};
      $scope.submitStuLeave = function () {
          var res = $learunDataIsAll.isAll($scope.editData, StuLeave.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.stuNo = $scope.stuinfo.stuNo;
              $scope.editData.stuId = $scope.stuinfo.stuInfoId;
              $scope.editData.stuName = $scope.stuinfo.stuName;
              $scope.editData.telephone = $scope.stuinfo.telephone;
              $scope.editData.beAllow = '0';
              $scope.editData.beCancel = '0';

              StuLeave.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.detailsModal.remove();
                  $learunTriggerRefresh.triggerRefresh('StuLeave-content');
              });
          }
      }


      //学生请假代码end===================================================================

      //学生操行考勤start=================================================================
      //保存操行扣分信息
      $scope.editData = {};
      $scope.submitBehaviorRecode = function () {
          var res = $learunDataIsAll.isAll($scope.editData, BehaviorRecode.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.isCanceled = '0';
              $scope.editData.appCancel = '0';
              $scope.editData.submiter = $scope.stuinfo.stuName;

              BehaviorRecode.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.detailsModal.remove();
                  $learunTriggerRefresh.triggerRefresh('BehaviorRecodeDetails-content');
              });
          }
      }
      
      //保存操行申请撤销
      $scope.editData = {};
      $scope.submitCancelApp = function () {
          var res = $learunDataIsAll.isAll($scope.editData, CancelApp.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.appId = $scope.MyBreachBehaviorInfo.iD;
              $scope.editData.checker = $scope.stuinfo.stuName;
              $scope.editData.roleName = "学生";
              $scope.editData.checkerTime = new Date();
              $scope.editData.checkState = '申请撤消';

              CancelApp.editSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.detailsModal.remove();
                  $learunTriggerRefresh.triggerRefresh('CancelApp-content');
              });
          }
      }

      //保存学生会是否同意撤销违规信息
      $scope.editData = {};
      $scope.submitReviewCancelApp = function () {
          var res = $learunDataIsAll.isAll($scope.editData, CancelApp.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.appId = $scope.cancelAppInfo.appId;
              $scope.editData.checker = $scope.stuinfo.stuName;
              $scope.editData.roleName = "学生会";
              $scope.editData.checkerTime = new Date();

              CancelApp.editReviewSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.detailsModal.remove();
                  $learunTriggerRefresh.triggerRefresh('ReviewCancelApp-content');
              });
          }
      }


      //学生操行考勤end===============================================================


      //床位交换start===============================================================
      //选中房间标准后
      $scope.submitDormExchangeStandard = function (standard) {
          $scope.exchangestandard = standard;
          $learunTopAlert.show({ text: "已提交房间标准：" + standard });
          $scope.dormexchange = {};
          //根据标准找出符合的床位 standard=800,本专业的
          var queryData = { "MajorId": $scope.stuinfo.majorNo, "Price": standard, "DormFloorsType": $scope.stuinfo.gender + '生' ,"StuId":$scope.stuinfo.stuInfoId};
          $learunHttp.post({
              "url": ApiUrl.dormExchangeBedListApi,
              "data": { "queryData": JSON.stringify(queryData) },
              "success": function (data) {
                  $scope.dormexchange = data;
              }
          });


          $scope.openDormSelectModal('DormExchangeSelect.html', 'right', standard);//跳转到详细页面
      }
      $scope.ExchangeDormInfodoRefresh = function () {
          $scope.$broadcast('scroll.refreshComplete');
      };


      $scope.openDormExchangeDetailsModal = function (viewpage, direction, a,b){//交换申请页面信息
          if (viewpage == "DormExchangeDetails.html") {
              $scope.OldBedId = {};
              $scope.exchangedorminfo = {};
              var queryData = { "StuId": $scope.stuinfo.stuInfoId };
              $learunHttp.post({
                  "url": ApiUrl.SelectOldBedIdApi,
                  "data": { "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      $scope.OldBedId = data;
                      $scope.exchangedorminfo.oldBedId = $scope.OldBedId.result.bedId;
                  }
              });
              $scope.exchangedorminfo = a;
              $scope.exchangedorminfo.dormName = b;



              var queryData = { "StuNo": $scope.stuinfo.stuNo };//查询修改
              $learunHttp.post({
                  "url": ApiUrl.AppChangeBedApi,
                  "data": { "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      if (data.result != undefined) {
                      $scope.exchangedorminfo.iD = data.result.iD;
                      $scope.exchangedorminfo.appRemark = data.result.appRemark;
                          $scope.stuexchangedorm.appRemark = data.result.appRemark;
                          $scope.stuexchangedorm.iD = data.result.iD;
                      }
                  }
              });

          }

          if ($scope.detailsModal != null) {
              $scope.detailsModal.remove();
          }
          $ionicModal.fromTemplateUrl('templates/homeApps/baodao/' + viewpage, {
              scope: $scope,
              animation: 'slide-in-' + direction,//left,right,up,down
          }).then(function (modal) {
              $scope.detailsModal = modal;
              $scope.detailsModal.show();
          });
      };
      $scope.closeDormExchangeDetailsModal = function () {
          $scope.detailsModal.remove();
      };
      $scope.dormExchangeInputActive = function (name) {
          return ($scope.exchangedorminfo[name] != null && $scope.exchangedorminfo[name] != "" && $scope.exchangedorminfo[name] != undefined);
      };




      $scope.stuexchangedorm = {};
      $scope.saveExchangeDorm = function () {// 保存交换申请
          var res = $learunDataIsAll.isAll($scope.stuexchangedorm, ExchangeDorm.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.stuexchangedorm.appStuId = $scope.stuinfo.stuInfoId;
              $scope.stuexchangedorm.appClassId = $scope.stuinfo.classNo;
              $scope.stuexchangedorm.appStuNo = $scope.stuinfo.stuNo;
              $scope.stuexchangedorm.appStuName = $scope.stuinfo.stuName;
              $scope.stuexchangedorm.appStuPhone = $scope.stuinfo.telephone;
              $scope.stuexchangedorm.oldBedId = $scope.exchangedorminfo.oldBedId;//原床位id号
              $scope.stuexchangedorm.targetStuId = $scope.exchangedorminfo.stuInfoId;
              $scope.stuexchangedorm.targetClassId = $scope.exchangedorminfo.classNo;
              $scope.stuexchangedorm.targetStuNo = $scope.exchangedorminfo.stuNo;
              $scope.stuexchangedorm.targetStuName = $scope.exchangedorminfo.stuName;
              $scope.stuexchangedorm.targetStuPhone = $scope.exchangedorminfo.telephone;
              $scope.stuexchangedorm.newBedId = $scope.exchangedorminfo.bedId;
              $scope.stuexchangedorm.targetPassed = "0";
              $scope.stuexchangedorm.passed = "1";
              $scope.stuexchangedorm.AppDatetime = new Date();

              ExchangeDorm.editSubmit($scope.stuexchangedorm, function () {
                  $ionicLoading.hide();
                  $scope.detailsModal.remove();
                  $learunTriggerRefresh.triggerRefresh('DormExchange-content');
              });
          }
      }
      
      $scope.saveExchangeDormTargetPassed = function () {// 保存学生是否同意交换申请
          var res = $learunDataIsAll.isAll($scope.editData, ExchangeDorm.getEditDataEx());
          if (res != null) {
              $learunTopAlert.show({ text: res.name + "不能为空" });
          } else {
              $ionicLoading.show();
              $scope.editData.iD = $scope.GetMyExchangeList.iD;

              ExchangeDorm.editTargetPassedSubmit($scope.editData, function () {
                  $ionicLoading.hide();
                  $scope.detailsModal.remove();
                  $learunTriggerRefresh.triggerRefresh('DormExchangeTargetPassed-content');
              });
          }
      }



     
      //床位交换end===============================================================



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
          $scope.stuinfo = lrmCustomers.get(customerId);
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
