/*
* 创建者：LearunChen
* 时间：  2016-06-08
* 描述：  数据模型存放js，统一处理数据交互和后台
* */
//学生宿舍床位列表数据
var AngModule = angular.module('starter.modules', []);
AngModule//angular.module('starter.modules', [])
//主页应用列表
  .factory('HomeApps', function () {
      var homeApps = [{
          name: "移动门户",
          icon: "ion-ios-paperplane-outline",
          color: "bgcolor_a",
          viewid: 'home-web.html'
      }
      //, {
      //    name: "我的课表",
      //    icon: "ion-ios-people-outline",
      //    color: "bgcolor_b",
      //    viewid: 'mylesson.html',
      //}, {
      //    name: "在线选课",
      //    icon: "ion-ios-list-outline",
      //    color: "bgcolor_c",
      //    viewid: 'MyXuanKe.html',
      //}, {
      //    name: "费用信息",
      //    icon: "ion-ios-paper-outline",
      //    color: "bgcolor_d",
      //    viewid: 'home-caiwu.html',
      //}, {
      //    name: "学业成绩",
      //    icon: "ion-ios-pulse",
      //    color: "bgcolor_e",
      //    viewid: 'home-xueye.html',
      //}
      //,{
      //    name: "奖惩信息",
      //    icon: "ion-ios-pie-outline",
      //    color: "bgcolor_a",
      //    viewid: 'home-jiangcheng.html',
      //}

      , {
          name: "迎新报到",
          icon: "ion-ios-person-outline",
          color: "bgcolor_c",
          viewid: 'home-baodao.html',
      }
  //     , {
  //        name: "顶岗实习",
  //        icon: "ion-ios-toggle-outline",
  //        color: "bgcolor_f",
  //        viewid: 'home-shixi.html',
  //    }
  //, {
  //        name: "毕业离校",
  //        icon: "ion-ios-browsers-outline",
  //        color: "bgcolor_f",
  //        viewid: 'home-lixiao.html'
  //    }, {
  //        name: "即时通信",
  //        icon: "ion-ios-chatboxes-outline",
  //        color: "bgcolor_g",
  //        viewid: 'home-chat.html',
  //    }, {
  //        name: "在线学习",
  //        icon: "ion-ios-book",
  //        color: "bgcolor_b",
  //        viewid: 'home-study.html',
  //    }, {
  //        name: "教学评价",
  //        icon: "ion-ios-pricetag-outline",
  //        color: "bgcolor_e",
  //        viewid: 'home-pingjia.html',
  //    }
      , {
          name: "考勤管理",
          icon: "ion-ios-people-outline",
          color: "bgcolor_b",
          viewid: 'home-kaoqin.html',
      }
      , {
          name: "事务办理",
          icon: "ion-ios-people-outline",
          color: "bgcolor_b",
          viewid: 'home-ShiwuBanli.html',
      }
      //, {
  //        name: "",
  //        icon: "",
  //        color: "",
  //        viewid: '',
  //    }











      ];

      return {
          all: function () {
              return homeApps;
          },
          remove: function (homeApps) {
              homeApps.splice(homeApps.indexOf(homeApps), 1);
          },
          get: function (homeAppId) {
              for (var i = 0; i < homeApps.length; i++) {
                  if (homeApps[i].id === parseInt(homeAppId)) {
                      return homeApps[i];
                  }
              }
              return null;
          }
      };
  })

//*/首页公告
  .factory('Announces', ['$learunHttp', 'ApiUrl', function ($learunHttp, ApiUrl) {

      /*
     var announces = [{
         id: 0,
         name: '界面不好看，工作都白干，客户重颜值，内涵放一边',
         icon: 'ion-ios-list-outline',
         bgcolor: 'positive-bg',
         viewid: 'templates/notices/noticeDetails.html',//templates/notices/noticeDetails.html
     },{
         id: 0,
         name: '号外！号外！泉江开发APP不用美工了',
         icon: 'ion-ios-list-outline',
         bgcolor: 'positive-bg',
         viewid: 'noticeDetails.html',
     }, {
         id: 1,
         name: '泉江全栈开发工程师培养计划',
         icon: 'ion-ios-list-outline',
         bgcolor: 'positive-bg',
         viewid: 'list',
     }, {
         id: 2,
         name: '前端后台一把抓，开发不再要美工！',
         icon: 'ion-ios-list-outline',
         bgcolor: 'positive-bg',
         viewid: 'list',
     }, {
         id: 3,
         name: '现在的客户重颜值，一定要把界面弄好看！！',
         icon: 'ion-ios-list-outline',
         bgcolor: 'positive-bg',
         viewid: 'list',
     }];
     //*/
      var announces = {};



      return {
          all: function () {
              $learunHttp.post({
                  "url": ApiUrl.noticeListApi,
                  "data": { "page": 1, "rows": 10, "sidx": "SortCode,ReleaseTime", "sord": "desc", "queryData": null },//{},为空要出问题
                  "success": function (data) {
                      announces = data.result.rows;
                      return announces;
                  }
              });
          },
          getlist: function () {
              return announces;
          },
          //remove: function (announces) {
          //    announces.splice(announces.indexOf(announces), 1);
          //},
          get: function (announceId) {
              for (var i = 0; i < announces.length; i++) {
                  if (announces[i].newsId == announceId) {
                      return announces[i];
                  }
              }
              return null;
          }
      };
  }])//*/

    //*/通知
  .factory('Notices', ['$learunHttp', 'ApiUrl', function ($learunHttp, ApiUrl) {

      var Notices = {};
      return {
          all: function () {
              Notices = {
                  "btnNoRead": [],//未读
                  "btnRead": []//已读
              };
              $learunHttp.post({
                  "url": ApiUrl.noticeListApi,
                  "data": { "page": 1, "rows": 3, "sidx": "SortCode,ReleaseTime", "sord": "desc", "queryData": null },//{},为空要出问题
                  "success": function (data) {
                      var readdata = data.result.rows;
                      for (var i in readdata) {
                          var item = readdata[i];
                          Notices.btnNoRead.push(item);
                      }
                  }
              });
              $learunHttp.post({
                  "url": ApiUrl.noticeListApi,
                  "data": { "page": 1, "rows": 5, "sidx": "NewsId", "sord": "desc", "queryData": null },//{},为空要出问题
                  "success": function (data) {
                      var unreaddata = data.result.rows;
                      for (var i in unreaddata) {
                          var item = unreaddata[i];
                          Notices.btnRead.push(item);
                      }
                  }
              });
              return Notices;

          },
          getlist: function () {
              return Notices;
          },
          get: function (noticeId) {
              for (var i = 0; i < $scope.notices.length; i++) {
                  if ($scope.notices[i].newsId == noticeId) {
                      return $scope.notices[i];
                  }
              }
              return null;
          }
      };
  }])//*/

//我的账号信息
  .factory('UserInfo', ['$learunLocals', function ($learunLocals) {
      var userInfo = {
          //userid: "",
          //account: "",
          //password: "",
          //realname: "",
          //headicon: "img/logo.png",
          //gender: "",
          //organizeid: "",
          //organizename: "",
          //departmentid: "",
          //departmentname: "",
          //dutyid: "",
          //dutyname: "",
          //postid: "",
          //postname: "",
          //roleid: "",
          //rolename: "",
          //managerid: "",
          //manager: "",
          //description: "",
          //mobile: "",
          //telephone: "",
          //email: "",
          //oicq: "",
          //wechat: "",
          //msn: "",
          deptName: "",
          majorName: "",
          className: "",
          token: "",
          isLogin: false,
      };
      return {
          get: function () {
              var newUserInfo = $learunLocals.getObject('userInfo');
              if (newUserInfo.isLogin == undefined) {
                  userInfo.isLogin = false;
                  userInfo.token = "";
              }
              ionic.extend(userInfo, userInfo, newUserInfo || {});
              return userInfo;
          },
          set: function (data, token, isLogin) {
              data.headicon = "img/logo.png";//(data.headicon == undefined ? userInfo.headicon : data.headicon);
              ionic.extend(userInfo, userInfo, data || {});
              ionic.extend(userInfo, data.entity, data || {});
              userInfo.token = token;
              userInfo.isLogin = isLogin;
              $learunLocals.setObject('userInfo', userInfo);
          },
          clear: function () {
              userInfo.isLogin = false;
              userInfo.token = "";
              $learunLocals.setObject('userInfo', {});
          }
          //,
          ////获取基础数据
          //getBaseData: function (callback) {
          //    $learunHttp.post({
          //        "url": ApiUrl.baseDataApi,
          //        "data": {},
          //        "success": function (data) {
          //            var ob=data.result;
          //        },
          //        "error": function () {
          //            $learunTopAlert.show({ text: "获取基础数据失败" });
          //        },
          //        "finally": function () {
          //            callback();
          //        }
          //    });
          //}

      };


      //方法函数
      //function translateData(data) {

      //    data.deptNo = getDeptName(data.deptNo);
      //    data.majorNo = getMajorName(data.majorNo);
      //    data.classNo = getClassName(data.classNo);
      //    data.birthday = $learunFormatDate(data.birthday, 'yyyy-MM-dd');//item.modifyDate == null ? $learunFormatDate(item.createDate, 'MM-dd') : $learunFormatDate(item.modifyDate, 'MM-dd');
      //    return data;
      //};


  }])
//行政区域数据
  .factory('AreaInfo', ['$learunHttp', 'ApiUrl', function ($learunHttp, ApiUrl) {
      var areaInfo = {};
      return {
          init: function () {
              $learunHttp.post({
                  "url": ApiUrl.areaListApi,
                  "isverify": true,
                  "success": function (data) {
                      areaInfo = data.result;
                  }
              });
          },
          getProvinceName: function (provinceId) {
              return areaInfo[provinceId].areaName;
          },
          getCityName: function (provinceId, cityId) {
              return areaInfo[provinceId].children[cityId];
          }
      };
  }])


;

