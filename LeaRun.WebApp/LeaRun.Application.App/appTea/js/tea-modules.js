/*
* 创建者：LearunChen
* 时间：  2016-06-08
* 描述：  数据模型存放js，统一处理数据交互和后台
* */
var AngModule=angular.module('starter.modules', []);
AngModule
//主页应用列表
  .factory('HomeApps', function () {
    var homeApps = [{
        name: "移动门户",
        icon: "ion-ios-paperplane-outline",
        color: "bgcolor_a",
        viewid: 'home-web.html'
    }
    , {
        name: "教务教学",
        icon: "ion-ios-people-outline",
        color: "bgcolor_b",
        viewid: 'home-jiaowu.html',
    }, {
        name: "学生工作",
        icon: "ion-ios-list-outline",
        color: "bgcolor_c",
        viewid: 'home-xuegong.html',
    }, {
        name: "财务收费",
        icon: "ion-ios-paper-outline",
        color: "bgcolor_d",
        viewid: 'home-caiwu.html',
    }, {
        name: "宿舍管理",
        icon: "ion-ios-pulse",
        color: "bgcolor_e",
        viewid: 'home-sushe.html',
    }, {
        name: "报表中心",
        icon: "ion-ios-pie-outline",
        color: "bgcolor_a",
        viewid: 'home-baobiao.html',
    }

    , {
        name: "迎新报到",
        icon: "ion-ios-person-outline",
        color: "bgcolor_c",
        viewid: 'home-baodao-daoyuan.html',
    }
     , {
        name: "顶岗实习",
        icon: "ion-ios-toggle-outline",
        color: "bgcolor_f",
        viewid: 'home-shixi.html',
    }
, {
        name: "毕业离校",
        icon: "ion-ios-browsers-outline",
        color: "bgcolor_f",
        viewid: 'home-lixiao.html'
    }, {
        name: "即时通信",
        icon: "ion-ios-chatboxes-outline",
        color: "bgcolor_g",
        viewid: 'home-chat.html',
    }, {
        name: "人事管理",
        icon: "ion-ios-book",
        color: "bgcolor_b",
        viewid: 'home-renshi.html',
    }, {
        name: "工作办理",
        icon: "ion-ios-pricetag-outline",
        color: "bgcolor_e",
        viewid: 'home-work.html',
    },{
        name: "服务大厅",
        icon: "ion-ios-person-outline",
      color: "bgcolor_c",
      viewid: 'home-service.html',
    }
    , {
        name: "校园卡申请",
        icon: "ion-ios-person-outline",
        color: "bgcolor_c",
        viewid: 'home-customers.html',//'cardbanli.html'
    }
    


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
//实例列表信息
  .factory('Cases', function () {
    var cases = [{
        id: 0,
        name: '列表',
        icon: 'ion-ios-list-outline',
        bgcolor: 'positive-bg',
        viewid: 'case-list.html'
    }, {
        id: 1,
        name: '表单',
        icon: 'ion-ios-paper-outline',
        bgcolor: 'bgcolor_b',
        viewid: 'case-form.html'
    }, {
        id: 2,
        name: '按钮',
        icon: 'ion-ios-circle-filled',
        bgcolor: 'bgcolor_c',
        viewid: 'case-button.html'
    }, {
        id: 3,
        name: '选择相册图片',
        icon: 'ion-ios-cloud-upload',
        bgcolor: 'bgcolor_d',
        viewid: 'case-picture.html'
    }, {
        id: 4,
        name: '拍照',
        icon: 'ion-ios-camera',
        bgcolor: 'bgcolor_e',
        viewid: 'case-camera.html'
    }, {
        id: 5,
        name: '扫描条码',
        icon: 'ion-ios-barcode-outline',
        bgcolor: 'royal-bg',
        viewid: 'case-barcode.html'
    }, {
        id: 6,
        name: '通讯录',
        icon: 'ion-person-stalker',
        bgcolor: 'calm-bg',
        viewid: 'case-contact.html'
    }, {
        id: 7,
        name: '打电话',
        icon: 'ion-ios-telephone',
        bgcolor: 'assertive-bg',
        viewid: 'case-tel.html'
    }, {
        id: 8,
        name: '地理位置',
        icon: 'ion-ios-location',
        bgcolor: 'dark-bg',
        viewid: 'case-location.html'
    }];

    return {
        all: function () {
            return cases;
        },
        remove: function (cases) {
            cases.splice(cases.indexOf(cases), 1);
        },
        get: function (caseId) {
            for (var i = 0; i < cases.length; i++) {
                if (cases[i].id === parseInt(caseId)) {
                    return cases[i];
                }
            }
            return null;
        }
    };
})

//*/首页公告
  .factory('Announces', ['$learunHttp', 'ApiUrl', function ($learunHttp, ApiUrl) {

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
  .factory('UserInfo',['$learunLocals',function ($learunLocals) {
    var userInfo = {
        userid: "",
        account: "",
        password: "",
        realname: "",
        headicon: "img/logo.png",
        gender: "",
        organizeid: "",
        organizename: "",
        departmentid: "",
        departmentname: "",
        dutyid: "",
        dutyname: "",
        postid: "",
        postname: "",
        roleid: "",
        rolename: "",
        managerid: "",
        manager: "",
        description: "",
        mobile: "",
        telephone: "",
        email: "",
        oicq: "",
        wechat: "",
        msn: "",

        token: "",
        isLogin:false,
    };
    return {
        get: function () {
            var newUserInfo = $learunLocals.getObject('userInfo');
            if (newUserInfo.isLogin == undefined)
            {
                userInfo.isLogin = false;
                userInfo.token = "";
            }
            ionic.extend(userInfo, userInfo, newUserInfo || {});
            return userInfo;
        },
        set: function (data, token, isLogin) {
            data.headicon = "img/logo.png";//(data.headicon == undefined ? userInfo.headicon : data.headicon);
            ionic.extend(userInfo, userInfo, data || {});
            userInfo.token = token;
            userInfo.isLogin = isLogin;
            $learunLocals.setObject('userInfo', userInfo);
        },
        clear: function ()
        {
            userInfo.isLogin = false;
            userInfo.token = "";
            $learunLocals.setObject('userInfo', {});
        }
    };
}])
//行政区域数据
  .factory('AreaInfo', ['$learunHttp','ApiUrl',function ($learunHttp, ApiUrl) {
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
      getCityName: function (provinceId, cityId)
      {
        return areaInfo[provinceId].children[cityId];
      }
    };
}])
//基础信息
  .factory('lrmBaseInfo',['$learunHttp','ApiUrl', function ($learunHttp,ApiUrl) {
    var baseInfo ={
      userListInfo:[]//用户列表
    };
    return{
      init:function(){
        $learunHttp.post({
          "url": ApiUrl.getUserListApi,
          "isverify": true,
          "success": function (data) {
            baseInfo.userListInfo = data.result;
          }
        });
      },
      getUserInfoList:function(depId){
        var data = [];
        for(var i in baseInfo.userListInfo)
        {
          var item = baseInfo.userListInfo[i];
          if(item.departmentId == depId) {
            data.push(item);
          }
        }
        return data;
      }
    };
  }])

/*


    //报到预约信息
  .factory('listBaodaoYuyue', ['$learunFormatDate', 'AreaInfo', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', function ($learunFormatDate, AreaInfo, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert) {
      //教师列表
      var baodaoYuyueList = {
          records: 0,
          page: 1,
          total: 1,
          moredata: false,
          yuyueStudents: []
      };
      var baodaoYuyueListSearch = {};

      var arriveType = {};  //抵校方式：火车，飞机，轮船，公交车,自驾车
      var stationName = {}; //到站名称，根据学校的接站设定

      //编辑数据字段
      var editDataEx = [
        {
            "name": "新生姓名",//学生姓名,到校方式,到校时间,到站名称,随同人数,联系电话,备用电话,附言
            "id": "stuName",
            "isRequire": true
        },
        {
            "name": "报到院系",
            "id": "baodaoDept",
            "isRequire": true
        },
        {
            "name": "抵校方式",//来校方式：火车，飞机，轮船，公交车,自驾车
            "id": "arriveType",
            "isRequire": true
        },
        {
            "name": "到站名称",//到站名称：根据学校的接站设定
            "id": "stationName",
            "isRequire": true
        },
        {
            "name": "所乘车次",
            "id": "companyName",
            "isRequire": true
        },
        {
            "name": "到校时间",
            "id": "arriveTime",
            "isRequire": true
        },
        {
            "name": "来校人数",
            "id": "parteners",
            "isRequire": true
        },
        {
            "name": "联系电话",
            "id": "mobile",
            "isRequire": true
        },
        {
            "name": "备用电话",
            "id": "mobile2",
            "isRequire": true
        },
        {
            "name": "附言",
            "id": "words",
            "isRequire": false
        }
      ];//编辑数据字段
      //方法函数
      function translateData(data, obj) {
          for (var i in data) {
              var item = data[i];

              if (item.custIndustryId == null) {
                  data[i].custIndustryName = "未知业";
                  data[i].custIndustrybgColor = "dark-bg";
              }
              else {
                  data[i].custIndustryName = custTrade[item.custIndustryId].itemName;
                  data[i].custIndustrybgColor = custTrade[item.custIndustryId].bgColor;
              }

              data[i].custLevelName = custLevel[item.custLevelId].itemName;
              data[i].custTypeName = custType[item.custTypeId].itemName;
              data[i].custDegreeName = custDegree[item.custDegreeId].itemName;

              if (data[i].province != null) {
                  data[i].provinceName = AreaInfo.getProvinceName(item.province);
                  if (data[i].city != null) {
                      data[i].cityName = AreaInfo.getCityName(item.province, item.city);
                  }
              }
              data[i].lastDate = item.modifyDate == null ? $learunFormatDate(item.createDate, 'MM-dd') : $learunFormatDate(item.modifyDate, 'MM-dd');
              data[i].createDate = $learunFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
              data[i].modifyDate = $learunFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
              obj.push(data[i]);
          }
      };
      //获取数据
      function getData(page, queryData, obj, callback) {
          $learunHttp.post({
              "url": ApiUrl.baodaoYuyueListApi,
              "data": { "page": page, "rows": 10, "sidx": "ArrivalDate", "sord": "desc", "queryData": JSON.stringify(queryData) },
              "isverify": true,
              "success": function (data) {
                  if (page == 1) {
                      obj.yuyueStudents = [];
                  }
                  translateData(data.result.rows, obj.yuyueStudents);
                  obj.records = data.result.records;
                  obj.page = data.result.page;
                  obj.total = data.result.total;
                  if (data.result.page == data.result.total || data.result.total == 0) {
                      obj.moredata = false;
                  }
                  else {
                      obj.moredata = true;
                  }
                  obj.page = obj.page + 1;
              },
              "error": function () {
                  $learunTopAlert.show({ text: "刷新失败" });
              },
              "finally": function () {
                  callback();
              }
          });
      }
      //返回
      return {
          baseInit: function () {
              $learunGetDataItem({
                  "itemName": 'ArriveType',
                  "callback": function (data) {
                      arriveType = data;
                  }
              });
              $learunGetDataItem({
                  "itemName": 'StationName',
                  "callback": function (data) {
                      stationName = data;
                  }
              });
              
          },
          getList: function () {
              return baodaoYuyueList;
          },
          update: function (callback) {
              getData(1, {}, baodaoYuyueList, callback);
          },
          add: function (callback) {
              getData(baodaoYuyueList.page, {}, baodaoYuyueList, callback);
          },
          get: function (YuyueId) {
              for (var i = 0; i < baodaoYuyueList.yuyueStudents.length; i++) {
                  if (baodaoYuyueList.yuyueStudents[i].YuyueId === YuyueId) {
                      return baodaoYuyueList.yuyueStudents[i];
                  }
              }
              for (var i = 0; i < baodaoYuyueListSearch.yuyueStudents.length; i++) {
                  if (baodaoYuyueListSearch.yuyueStudents[i].YuyueId === YuyueId) {
                      return baodaoYuyueListSearch.yuyueStudents[i];
                  }
              }
              return null;
          },
          getSearchList: function () {
              baodaoYuyueListSearch = {
                  records: 0,
                  page: 1,
                  total: 1,
                  moredata: false,
                  customers: [],
                  keyword: ""
              };
              return baodaoYuyueListSearch;
          },
          searchData: function () {
              if (baodaoYuyueListSearch.keyword == "") {
                  return false;
              }
              getData(1, { "condition": "All", "keyword": baodaoYuyueListSearch.keyword }, baodaoYuyueListSearch, function () { });
          },
          searchDataAdd: function (callback) {
              if (baodaoYuyueListSearch.keyword == "") {
                  return false;
              }
              getData(baodaoYuyueListSearch.page, { "condition": "All", "keyword": baodaoYuyueListSearch.keyword }, baodaoYuyueListSearch, callback);
          },
         
          editSubmit: function (editData, callback) {
              $learunHttp.post({
                  "url": ApiUrl.saveBaodaoYuyueApi,
                  "data": editData,
                  "isverify": true,
                  "success": function (data) {
                      $learunTopAlert.show({ text: "保存成功！" });
                  },
                  "error": function () {
                      $learunTopAlert.show({ text: "保存失败！" });
                  },
                  "finally": function () {
                      callback();
                  }
              });
          },
          getArriveType: function () {
              return arriveType;
          },
          getStationName: function () {
              return stationName;
          },

          getEditDataEx: function () {
              return editDataEx;
          }
      };
  }])


//新生列表信息
.factory('listFreshStuInfo', ['$learunFormatDate', 'AreaInfo', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', function ($learunFormatDate, AreaInfo, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert) {
    //新生列表
    var freshStuList = {
        records: 0,
        page: 1,
        total: 1,
        moredata: false,
        freshStudents: []
    };
    var freshStuListSearch = {};      
            
    //方法函数
    function translateData(data, obj) {
        for (var i in data) {
            var item = data[i];

            //if (item.custIndustryId == null) {
            //    data[i].custIndustryName = "未知业";
            //    data[i].custIndustrybgColor = "dark-bg";
            //}
            //else {
            //    data[i].custIndustryName = custTrade[item.custIndustryId].itemName;
            //    data[i].custIndustrybgColor = custTrade[item.custIndustryId].bgColor;
            //}

            //data[i].custLevelName = custLevel[item.custLevelId].itemName;
            //data[i].custTypeName = custType[item.custTypeId].itemName;
            //data[i].custDegreeName = custDegree[item.custDegreeId].itemName;

            //if (data[i].province != null) {
            //    data[i].provinceName = AreaInfo.getProvinceName(item.province);
            //    if (data[i].city != null) {
            //        data[i].cityName = AreaInfo.getCityName(item.province, item.city);
            //    }
            //}
            //data[i].lastDate = item.modifyDate == null ? $learunFormatDate(item.createDate, 'MM-dd') : $learunFormatDate(item.modifyDate, 'MM-dd');
            //data[i].createDate = $learunFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
            //data[i].modifyDate = $learunFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
            obj.push(data[i]);
        }
    };
    //获取数据
    function getData(page, queryData, obj, callback) {
        $learunHttp.post({
            "url": ApiUrl.freshStuListApi,
            "data": { "page": page, "rows": 10, "sidx": "RegisterStatus", "sord": "desc", "queryData": JSON.stringify(queryData) },
            "isverify": true,
            "success": function (data) {
                if (page == 1) {
                    obj.freshStudents = [];
                }
                translateData(data.result.rows, obj.freshStudents);
                obj.records = data.result.records;
                obj.page = data.result.page;
                obj.total = data.result.total;
                if (data.result.page == data.result.total || data.result.total == 0) {
                    obj.moredata = false;
                }
                else {
                    obj.moredata = true;
                }
                obj.page = obj.page + 1;
            },
            "error": function () {
                $learunTopAlert.show({ text: "刷新失败" });
            },
            "finally": function () {
                callback();
            }
        });
    }
    //返回
    return {          
        getList: function () {
            return freshStuList;
        },
        update: function (callback) {
            getData(1, {}, freshStuList, callback);
        },
        add: function (callback) {
            getData(freshStuList.page, {}, freshStuList, callback);
        },
        get: function (stuid) {
            for (var i = 0; i < freshStuList.freshStudents.length; i++) {
                if (freshStuList.freshStudents[i].stuInfoId === stuid) {
                    return freshStuList.freshStudents[i];
                }
            }
            for (var i = 0; i < freshStuListSearch.freshStudents.length; i++) {
                if (freshStuListSearch.freshStudents[i].stuInfoId === stuid) {
                    return freshStuListSearch.freshStudents[i];
                }
            }
            return null;
        },
        getSearchList: function () {
            freshStuListSearch = {
                records: 0,
                page: 1,
                total: 1,
                moredata: false,
                freshStudents: [],
                keyword: ""
            };
            return custListSearch;
        },
        searchData: function () {
            if (freshStuListSearch.keyword == "") {
                return false;
            }
            getData(1, { "condition": "All", "keyword": freshStuListSearch.keyword }, freshStuListSearch, function () { });
        },
        searchDataAdd: function (callback) {
            if (freshStuListSearch.keyword == "") {
                return false;
            }
            getData(freshStuListSearch.page, { "condition": "All", "keyword": freshStuListSearch.keyword }, freshStuListSearch, callback);
        }
          
    };
}])


//抵校登记
//列表信息
  .factory('Dxdj', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert) {
      //学生列表数据
      //var dxdjList = {
      //    records: 0,
      //    page: 1,
      //    total: 1,
      //    moredata: false,
      //    businesss: []
      //};
      //var dxdjListSearch = {};//搜索列表数据
      var arriveType = {};//来校方式
      var baodaoDept = {};//报到院系
      var stationName = {};//到站名称
      var editDataEx = [
        {
            "name": "新生姓名",
            "id": "stuName",
            "isRequire": true
        },
        {
            "name": "报到院系",
            "id": "baodaoDept",
            "isRequire": true
        },
        {
            "name": "抵校方式",//来校方式：火车，飞机，轮船，公交车,自驾车
            "id": "arriveType",
            "isRequire": true
        },
        {
            "name": "到站名称",//到站名称：根据学校的接站设定
            "id": "stationName",
            "isRequire": true
        },
        {
            "name": "所乘车次",
            "id": "companyName",
            "isRequire": true
        },
        {
            "name": "到校时间",
            "id": "arriveTime",
            "isRequire": true
        },
        {
            "name": "来校人数",
            "id": "parteners",
            "isRequire": true
        },
        {
            "name": "联系电话",
            "id": "mobile",
            "isRequire": true
        },
        {
            "name": "备用电话",
            "id": "mobile2",
            "isRequire": true
        },
        {
            "name": "附言",
            "id": "words",
            "isRequire": false
        }
      ];//编辑数据字段

      //方法函数(数据遍历转化)
      function translateData(data, obj) {
          for (var i in data) {
              var item = data[i];
              data[i].arriveTime = $learunFormatDate(item.arriveTime, 'yyyy-MM-dd hh:mm');
              obj.push(data[i]);
          }
      };
      
      return {
          init: function () {//初始化信息
              $learunGetDataItem({
                  "itemName": 'arriveType',
                  "callback": function (data) {
                      arriveType = data;
                  }
              });
              $learunGetDataItem({
                  "itemName": 'baodaoDept',
                  "callback": function (data) {
                      baodaoDept = data;
                      console.log(baodaoDept);
                  }
              });
              $learunGetDataItem({
                  "itemName": 'stationName',
                  "callback": function (data) {
                      stationName = data;
                      console.log(stationName);
                  }
              });
          }, 
          
          get: function (dxdjId) {
              //for (var i = 0; i < businessList.businesss.length; i++) {
              //    if (businessList.businesss[i].chanceId === chanceId) {
              //        return businessList.businesss[i];
              //    }
              //}
              //for (var i = 0; i < businessListSearch.businesss.length; i++) {
              //    if (businessListSearch.businesss[i].chanceId === chanceId) {
              //        return businessListSearch.businesss[i];
              //    }
              //}
              return null;
          },
          getArriveType: function () {
              return arriveType;
          },
          getBaodaoDept: function () {
              return baodaoDept;
          },
          getStationName: function () {
              return stationName;
          },
          getEditDataEx: function () {
              return editDataEx;
          },          
          editSubmit: function (editData, callback) {
              $learunHttp.post({
                  "url": ApiUrl.saveDxdjApi,
                  "data": editData,
                  "isverify": true,
                  "success": function (data) {
                      $learunTopAlert.show({ text: "保存成功!" });
                  },
                  "error": function () {
                      $learunTopAlert.show({ text: "保存失败！" });
                  },
                  "finally": function () {
                      callback();
                  }
              });
          }

      };
  }])
  */



;
