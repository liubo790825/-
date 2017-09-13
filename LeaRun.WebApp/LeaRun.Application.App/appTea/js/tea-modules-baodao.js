/*
* 创建者：LearunChen
* 时间：  2016-06-08
* 描述：  数据模型存放js，统一处理数据交互和后台
* */
AngModule//angular.module('starter.modules', [])
//主页应用列表


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
    ////新生列表
    //var freshStuList = {
    //    records: 0,
    //    page: 1,
    //    total: 1,
    //    moredata: false,
    //    freshStudents: []
    //};
    //var freshStuListSearch = {};      
            
    ////方法函数
    //function translateData(data, obj) {
    //    for (var i in data) {
    //        var item = data[i];

    //        //if (item.custIndustryId == null) {
    //        //    data[i].custIndustryName = "未知业";
    //        //    data[i].custIndustrybgColor = "dark-bg";
    //        //}
    //        //else {
    //        //    data[i].custIndustryName = custTrade[item.custIndustryId].itemName;
    //        //    data[i].custIndustrybgColor = custTrade[item.custIndustryId].bgColor;
    //        //}

    //        //data[i].custLevelName = custLevel[item.custLevelId].itemName;
    //        //data[i].custTypeName = custType[item.custTypeId].itemName;
    //        //data[i].custDegreeName = custDegree[item.custDegreeId].itemName;

    //        //if (data[i].province != null) {
    //        //    data[i].provinceName = AreaInfo.getProvinceName(item.province);
    //        //    if (data[i].city != null) {
    //        //        data[i].cityName = AreaInfo.getCityName(item.province, item.city);
    //        //    }
    //        //}
    //        //data[i].lastDate = item.modifyDate == null ? $learunFormatDate(item.createDate, 'MM-dd') : $learunFormatDate(item.modifyDate, 'MM-dd');
    //        //data[i].createDate = $learunFormatDate(item.createDate, 'yyyy-MM-dd hh:mm');
    //        //data[i].modifyDate = $learunFormatDate(item.modifyDate, 'yyyy-MM-dd hh:mm');
    //        obj.push(data[i]);
    //    }
    //};
    ////获取数据
    //function getData(page, queryData, obj, callback) {
    //    var queryData = { "ClassNo": '234234412' };
    //    $learunHttp.post({
    //        "url": ApiUrl.freshStuListApi,
    //        //"data": { "page": page, "rows": 10, "sidx": "RegisterStatus", "sord": "desc", "queryData": JSON.stringify(queryData) },
    //        "data": {"queryData": JSON.stringify(queryData) },
    //        "isverify": true,
    //        "success": function (data) {
    //            if (page == 1) {
    //                obj.freshStudents = [];
    //            }
    //            translateData(data.result, obj.freshStudents);
    //            //obj.records = data.result.records;
    //            //obj.page = data.result.page;
    //            //obj.total = data.result.total;
    //            //if (data.result.page == data.result.total || data.result.total == 0) {
    //            //    obj.moredata = false;
    //            //}
    //            //else {
    //            //    obj.moredata = true;
    //            //}
    //            //obj.page = obj.page + 1;
    //        },
    //        "error": function () {
    //            $learunTopAlert.show({ text: "刷新失败" });
    //        },
    //        "finally": function () {
    //            callback();
    //        }
    //    });
    //}
    ////返回
    //return {          
    //    getList: function () {
    //        return freshStuList;
    //    },
    //    update: function (callback) {
    //        getData(1, {}, freshStuList, callback);
    //    },
    //    add: function (callback) {
    //        getData(freshStuList.page, {}, freshStuList, callback);
    //    },
    //    get: function (stuid) {
    //        for (var i = 0; i < freshStuList.freshStudents.length; i++) {
    //            if (freshStuList.freshStudents[i].stuInfoId === stuid) {
    //                return freshStuList.freshStudents[i];
    //            }
    //        }
    //        for (var i = 0; i < freshStuListSearch.freshStudents.length; i++) {
    //            if (freshStuListSearch.freshStudents[i].stuInfoId === stuid) {
    //                return freshStuListSearch.freshStudents[i];
    //            }
    //        }
    //        return null;
    //    },
    //    getSearchList: function () {
    //        freshStuListSearch = {
    //            records: 0,
    //            page: 1,
    //            total: 1,
    //            moredata: false,
    //            freshStudents: [],
    //            keyword: ""
    //        };
    //        return custListSearch;
    //    },
    //    searchData: function () {
    //        if (freshStuListSearch.keyword == "") {
    //            return false;
    //        }
    //        getData(1, { "condition": "All", "keyword": freshStuListSearch.keyword }, freshStuListSearch, function () { });
    //    },
    //    searchDataAdd: function (callback) {
    //        if (freshStuListSearch.keyword == "") {
    //            return false;
    //        }
    //        getData(freshStuListSearch.page, { "condition": "All", "keyword": freshStuListSearch.keyword }, freshStuListSearch, callback);
    //    }
          
    //    };
    return null;
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

//咨询回复
.factory('AQuestions', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert) {
    
    var editDataEx = [
      {
          "name": "序号",
          "id": "aId",
          "isRequire": false
      },
      {
          "name": "学生信息ID",
          "id": "stuInfoId",
          "isRequire": false
      },
      {
          "name": "回复",
          "id": "answer",
          "isRequire": true
      },
      {
          "name": "回复时间",
          "id": "atime",
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
        getEditDataEx: function () {
            return editDataEx;
        },
        editSubmit: function (editData, callback) {
            $learunHttp.post({
                "url": ApiUrl.saveAnswerApi,
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


//学生请假
.factory('StuLeave', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', 'UserInfo', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert, UserInfo) {

    var stuinfo = UserInfo.get();
    var editDataEx = [
      {
          "name": "序号Id",
          "id": "iD",
          "isRequire": false
      },
      {
          "name": "学生学生ID号",
          "id": "stuId",
          "isRequire": false
      },
      {
          "name": "学号",
          "id": "stuNo",
          "isRequire": false
      },
      {
          "name": "姓名",
          "id": "stuName",
          "isRequire": false
      },
      {
          "name": "预留电话",
          "id": "telephone",
          "isRequire": false
      },
      {
          "name": "请假类型ID号",
          "id": "leaveTypeId",
          "isRequire": false
      },
      {
          "name": "请假类型",
          "id": "leaveType",
          "isRequire": false
      },
      {
          "name": "开始时间",
          "id": "beginTime",
          "isRequire": false
      },
      {
          "name": "结束时间",
          "id": "endTime",
          "isRequire": false
      },
      {
          "name": "天数",
          "id": "days",
          "isRequire": false
      },
      {
          "name": "请假原因",
          "id": "leaveRemark",
          "isRequire": false
      },
      {
          "name": "是否允许，0为未审核，1允许，2不允许",
          "id": "beAllow",
          "isRequire": false
      },
      {
          "name": "是否消假，0未消假，1已消假",
          "id": "beCancel",
          "isRequire": false
      },
      {
          "name": "消假时间",
          "id": "beCancelDate",
          "isRequire": false
      },
      {
          "name": "不允许原因",
          "id": "notBeAllowRemarkable",
          "isRequire": true
      },
      {
          "name": "CreateDate",
          "id": "createDate",
          "isRequire": false
      },
      {
          "name": "CreateUserId",
          "id": "createUserId",
          "isRequire": false
      },
      {
          "name": "CreateUserName",
          "id": "createUserName",
          "isRequire": false
      },
      {
          "name": "ModifyDate",
          "id": "modifyDate",
          "isRequire": false
      },
      {
          "name": "ModifyUserId",
          "id": "modifyUserId",
          "isRequire": false
      },
      {
          "name": "ModifyUserName",
          "id": "modifyUserName",
          "isRequire": false
      }


    ];//编辑数据字段

    //返回
    return {
        editSubmit: function (editData, callback) {
            $learunHttp.post({
                "url": ApiUrl.saveTeaLeaveshenpiApi,
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
        getEditDataEx: function () {
            return editDataEx;
        }
    };
}])


//操行扣分申请撤销审核记录
.factory('CancelApp', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', 'UserInfo', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert, UserInfo) {

    var stuinfo = UserInfo.get();
    var editDataEx = [
      {
          "name": "序号Id",
          "id": "iD",
          "isRequire": false
      },
      {
          "name": "申请要撤消的ID号",
          "id": "appId",
          "isRequire": false
      },
      {
          "name": "审核人或申请人",
          "id": "checker",
          "isRequire": false
      },
      {
          "name": "申请时间或审核时间",
          "id": "checkerTime",
          "isRequire": false
      },
      {
          "name": "状态",
          "id": "checkState",
          "isRequire": false
      },
      {
          "name": "备注或说明",
          "id": "remark",
          "isRequire": true
      }


    ];//编辑数据字段

    //返回
    return {
        editSubmit: function (editData, callback) {
            $learunHttp.post({
                "url": ApiUrl.saveTeaCancelAppReviewApi,
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
        getEditDataEx: function () {
            return editDataEx;
        }
    };
}])

//宿舍交换
.factory('ExchangeDorm', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', 'UserInfo', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert, UserInfo) {

    var stuinfo = UserInfo.get();
    var editDataEx = [
      {
          "name": "序号Id",
          "id": "iD",
          "isRequire": false
      },
      {
          "name": "申请学生ID号",
          "id": "appStuId",
          "isRequire": false
      },
      {
          "name": "申请人班级ID号",
          "id": "appClassId",
          "isRequire": false
      },
      {
          "name": "申请人学号",
          "id": "appStuNo",
          "isRequire": false
      },
      {
          "name": "申请人姓名",
          "id": "appStuName",
          "isRequire": false
      },
      {
          "name": "申请人电话",
          "id": "appStuPhone",
          "isRequire": false
      },
      {
          "name": "原床位",
          "id": "oldBedId",
          "isRequire": false
      },
      {
          "name": "目标学生ID号，可能为空",
          "id": "targetStuId",
          "isRequire": false
      },
      {
          "name": "目标学生班级ID号，可能为空",
          "id": "targetClassId",
          "isRequire": false
      },
      {
          "name": "目标学生号，可能为空",
          "id": "targetStuNo",
          "isRequire": false
      },
      {
          "name": "目标学生姓名，可能为空",
          "id": "targetStuName",
          "isRequire": false
      },
      {
          "name": "目标学生电话",
          "id": "targetStuPhone",
          "isRequire": false
      },
      {
          "name": "目标说明不同意说明",
          "id": "targetRemark",
          "isRequire": false
      },
      {
          "name": "目标床位ID号",
          "id": "newBedId",
          "isRequire": false
      },
      {
          "name": "目标学生是否同意，0未查看，1同意，2不同意",
          "id": "targetPassed",
          "isRequire": false
      },
      {
          "name": "是否通过，1申请中，0未通过，2通过",
          "id": "passed",
          "isRequire": false
      },
      {
          "name": "通过时间",
          "id": "passedTime",
          "isRequire": false
      },
      {
          "name": "申请时间",
          "id": "appDatetime",
          "isRequire": false
      },
      {
          "name": "申请原因",
          "id": "appRemark",
          "isRequire": false
      },
      {
          "name": "是否取消申请，0未取消，1取消",
          "id": "deleteMark",
          "isRequire": false
      },
      {
          "name": "联合取消申请使用，1未取消，0取消",
          "id": "enableMark",
          "isRequire": false
      },
      {
          "name": "取消时间",
          "id": "cancelTime",
          "isRequire": false
      }


    ];//编辑数据字段

    //返回
    return {
        editSubmit: function (stuexchangedorm, callback) {
            $learunHttp.post({
                "url": ApiUrl.SaveDormExchangePassedApi,
                "data": stuexchangedorm,
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
        getEditDataEx: function () {
            return editDataEx;
        }
    };
}])

;
