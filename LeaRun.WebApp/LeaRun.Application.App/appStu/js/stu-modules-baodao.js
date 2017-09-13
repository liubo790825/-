/*
* 创建者：LearunChen
* 时间：  2016-06-08
* 描述：  数据模型存放js，统一处理数据交互和后台
* */
//学生宿舍床位列表数据

AngModule//angular.module('starter.modules', [])


//报到预约信息
//抵校登记
  .factory('Dxdj', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', 'UserInfo', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert, UserInfo) {

      var stuinfo = UserInfo.get();

      var arrivalMode = {};//来校方式
      var arrivalPosition = {};//到站名称
      var editDataEx = [
        {
            "name": "新生姓名",
            "id": "stuName",
            "isRequire": false
        },
        {
            "name": "学号",
            "id": "stuNo",
            "isRequire": false
        },
        {
            "name": "身份证号",
            "id": "baodaoOther1",
            "isRequire": false
        },
        {
            "name": "预约ID",
            "id": "yuyueId",
            "isRequire": false
        },
        {
            "name": "所乘车次",
            "id": "baodaoOther2",
            "isRequire": false
        },
        {
            "name": "到校方式",//来校方式：火车，飞机，轮船，公交车,自驾车
            "id": "arrivalMode",
            "isRequire": false
        },
        {
            "name": "到校时间",
            "id": "arrivalDate",
            "isRequire": true
        },
        {
            "name": "到站名称",
            "id": "arrivalPosition",
            "isRequire": false
        },
        {
            "name": "随同人数",
            "id": "number",
            "isRequire": true
        },
        {
            "name": "联系电话",
            "id": "telephone",
            "isRequire": true
        },
        {
            "name": "备用电话",
            "id": "spareTelephone",
            "isRequire": false
        },
        {
            "name": "附言",
            "id": "massage",
            "isRequire": false
        }
      ];//编辑数据字段



      //返回
      return {
          baseInit: function () {
              $learunGetDataItem({
                  "itemName": 'ArriveType',
                  "callback": function (data) {
                      arrivalMode = data;
                  }
              });
              $learunGetDataItem({
                  "itemName": 'StationName',
                  "callback": function (data) {
                      arrivalPosition = data;
                  }
              });
          },
          editSubmit: function (editData, callback) {
              $learunHttp.post({
                  "url": ApiUrl.savebaodaoYuyueApi,
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
          
          get: function (dxdjId) {

              return null;
          },
          getArrivalMode: function () {
              return arrivalMode;
          },
          getArrivalPosition: function () {
              return arrivalPosition;
          },
          getEditDataEx: function () {
              //var queryData = { "BaodaoOther1": userinfo.identityCardNo };
              //editDataEx = YuyueInfo.get(queryData);;//获得已有报到预约取数据
              
              return editDataEx;
          },
         

      };
  }])


  .factory('YuyueInfo', ['$learunHttp','$learunFormatDate', 'ApiUrl', function ($learunHttp,$learunFormatDate, ApiUrl) {
      var yuyueInfo = {};
      //var queryData = { "BaodaoOther1": "142232199601157755" };

      //获取数据,测试用-----------------------------------------
      function getData(queryData,obj) {
          $learunHttp.post({
              "url": ApiUrl.YuyueListApi,
              "data": { "queryData": JSON.stringify(queryData) },
              "success": function (data) {
                  yuyueInfo = data.result;
                  if (yuyueInfo != null)
                      yuyueInfo.arrivalDate = yuyueInfo.arrivalDate == null ? "" : $learunFormatDate(yuyueInfo.arrivalDate, 'yyyy-MM-dd hh:mm'); //格式化日期
                  obj = yuyueInfo;
                  //return yuyueInfo;
              },
              "error": function () {
                  $learunTopAlert.show({ text: "获取失败" });
              },
              "finally": function () {
                  //callback();
              }
          });
      }//测试用-----------------------------------------

      return {
          init: function (queryData) {
              $learunHttp.post({
                  "url": ApiUrl.YuyueListApi,
                  "data": { "queryData": JSON.stringify(queryData) },
                  "success": function (data) {
                      yuyueInfo = data.result;
                      if (yuyueInfo != null)
                          yuyueInfo.arrivalDate = yuyueInfo.arrivalDate == null ? "" : $learunFormatDate(yuyueInfo.arrivalDate, 'yyyy-MM-dd hh:mm'); //格式化日期
                      return yuyueInfo;
                  }
              });
          },
          get: function () {//获得单个学生预约信息
              return yuyueInfo;
          },

          //测试用-----------------------------------------
          getEntity: function () {
              var queryData = { "BaodaoOther1": "142232199601157755" };
              var obj = {};
              getData(queryData, obj);
              return obj;
          }//测试用-----------------------------------------
      };
  }])

//查询宿舍中的床位
.factory('DormBedChoice', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert) {

    var dormBedList = [];

   
    return {
        //getList: function (majorNo,standard, gender) {

        //    if (standard != undefined) {
        //        var queryData = { "MajorId": majorNo, "Price": standard, "DormFloorsType": gender + '生' };
        //   //var queryData = { "MajorId": '12', "Price": standard, "DormFloorsType": '男' + '生' };
        //    // var queryData = { "MajorId": '12', "Price": '500', "DormFloorsType":''+'男'+'生' };
        //            $learunHttp.post({
        //                "url": ApiUrl.dormBedListApi,
        //                "data": { "queryData": JSON.stringify(queryData) },
        //                "success": function (data) {
        //                    dormBedList = data;
        //                }
        //            });
        //    }
                
        //     return dormBedList;
        //},
        //保存选择的床位信息
        saveSubmit: function (choicebed, stuNO, callback) {
            var queryData = { "BedId": choicebed, "stuId": stuNO }
            $learunHttp.post({
                "url": ApiUrl.saveStuToBedApi,
                "data": { "queryData": JSON.stringify(queryData) },
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
        }


    };



}])


//获取登陆用户寝室信息
.factory('MyRoommatesList', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert) {
    //学生列表数据
    var businessList = {
        records: 0,
        page: 1,
        total: 1,
        moredata: false,
        businesss: []
    };

    //方法函数(数据遍历转化)
    function translateData(data, obj) {
        for (var i in data) {
            var item = data[i];
            obj.push(data[i]);
        }
    };
    //获取数据方法
    function getData(page, stuInfoId, obj, callback) {
        var queryData = { "stuInfoId": stuInfoId };
        //var queryData = stuInfoId;
        $learunHttp.post({
            "url": ApiUrl.MyRoommatesListApi,
            "data": { "page": page, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": JSON.stringify(queryData) },
            "isverify": true,
            "success": function (data) {
                if (page == 1) {
                    obj.businesss = [];
                }
                translateData(data.result.rows, obj.businesss);
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
    return {
        init: function () {//初始化信息
            $learunGetDataItem({
                "itemName": 'Client_ChancePhase',
                "callback": function (data) {
                    chancePhases = data;
                }
            });
            $learunGetDataItem({
                "itemName": 'Client_ChanceSource',
                "callback": function (data) {
                    chanceSource = data;
                    console.log(chanceSource);
                }
            });
        },
        getList: function () {
            return businessList;
        },
        update: function (callback, stuInfoId) {//刷新数据
            getData(1, stuInfoId, businessList, callback);
        },
        add: function (callback, stuInfoId) {
            getData(businessList.page, stuInfoId, businessList, callback);
        }
    };
}])


//同班同学信息
.factory('listClassmates', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert) {
    //学生列表数据
    var businessList = {
        records: 0,
        page: 1,
        total: 1,
        moredata: false,
        businesss: []
    };

    //方法函数(数据遍历转化)
    function translateData(data, obj) {
        for (var i in data) {
            var item = data[i];
            obj.push(data[i]);
        }
    };
    //获取数据方法
    function getData(page, classno, obj, callback) {
        if (classno != null && classno.toString() != "") {
            var queryData = { "ClassNo": classno };
                $learunHttp.post({
                "url": ApiUrl.classmatesListApi,
                "data": { "page": page, "rows": 10, "sidx": "StuName", "sord": "desc", "queryData": JSON.stringify(queryData) },
                "isverify": true,
                "success": function (data) {
                    if (page == 1) {
                        obj.businesss = [];
                    }
                    translateData(data.result.rows, obj.businesss);
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
       
    }
    return {
        init: function () {//初始化信息
            $learunGetDataItem({
                "itemName": 'Client_ChancePhase',
                "callback": function (data) {
                    chancePhases = data;
                }
            });
            $learunGetDataItem({
                "itemName": 'Client_ChanceSource',
                "callback": function (data) {
                    chanceSource = data;
                    console.log(chanceSource);
                }
            });
        },
        getList: function () {
            return businessList;
        },
        update: function (callback, classno) {//刷新数据
            getData(1, classno, businessList, callback);
        },
        add: function (callback, classno) {
            getData(businessList.page, classno, businessList, callback);
        }
        
        
    };
}])


//军训服装
  .factory('JunXunFu', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', 'UserInfo', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert, UserInfo) {

      var stuinfo = UserInfo.get();

      var arrivalMode = {};//来校方式
      var arrivalPosition = {};//到站名称
      var editDataEx = [
        {
            "name": "服装ID",
            "id": "fuzhuangId",
            "isRequire": false
        },
        {
            "name": "学号",
            "id": "stuNo",
            "isRequire": false
        },
        {
            "name": "身高",
            "id": "height",
            "isRequire": false
        },
        {
            "name": "体重",
            "id": "bodyWeight",
            "isRequire": false
        },
        {
            "name": "腰围",
            "id": "waistline",
            "isRequire": false
        },
        {
            "name": "头围",
            "id": "headWaistline",
            "isRequire": false
        },
        {
            "name": "衣服尺寸",
            "id": "clothSize",
            "isRequire": true
        },
        {
            "name": "裤子尺寸",
            "id": "pantsSize",
            "isRequire": true
        },
        {
            "name": "鞋子尺寸",
            "id": "shoesSize",
            "isRequire": true
        },
        {
            "name": "身份证号",
            "id": "baodaoOther1",
            "isRequire": false
        }

      ];//编辑数据字段

      //返回
      return {
          editSubmit: function (editData, callback) {
              $learunHttp.post({
                  "url": ApiUrl.saveJunXunFuApi,
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


//我要咨询
  .factory('MyQuestion', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', 'UserInfo', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert, UserInfo) {

      var stuinfo = UserInfo.get();

      var arrivalMode = {};//来校方式
      var arrivalPosition = {};//到站名称
      var editDataEx = [
        {
            "name": "问题ID",
            "id": "qAId",
            "isRequire": false
        },
        {
            "name": "学生信息ID",
            "id": "stuInfoId",
            "isRequire": false
        },
        {
            "name": "学号",
            "id": "stuNo",
            "isRequire": false
        },
        {
            "name": "问题",
            "id": "questions",
            "isRequire": true
        },
        {
            "name": "提问时间",
            "id": "qtime",
            "isRequire": false
        },
        {
            "name": "身份证号",
            "id": "qAOther1",
            "isRequire": false
        }

      ];//编辑数据字段

      //我的问题列表数据
      var businessList = {
          records: 0,
          page: 1,
          total: 1,
          moredata: false,
          businesss: []
      };
      //方法函数(数据遍历转化)
      function translateData(data, obj) {
          for (var i in data) {
              var item = data[i];
              obj.push(data[i]);
          }
      };
      //获取数据方法
      function getData(page, identityCardNo, obj, callback) {
          var queryData = { "QAOther1": identityCardNo };
          //var queryData = stuInfoId;
          $learunHttp.post({
              "url": ApiUrl.MyQuestionListApi,
              "data": { "page": page, "rows": 10, "sidx": "QAOther1", "sord": "desc", "queryData": JSON.stringify(queryData) },
              "isverify": true,
              "success": function (data) {
                  if (page == 1) {
                      obj.businesss = [];
                  }
                  translateData(data.result.rows, obj.businesss);
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
          editSubmit: function (Question, callback) {
              $learunHttp.post({
                  "url": ApiUrl.saveMyQuestionApi,
                  "data": Question,
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
          },
          init: function () {//初始化信息
              $learunGetDataItem({
                  "itemName": 'Client_ChancePhase',
                  "callback": function (data) {
                      chancePhases = data;
                  }
              });
              $learunGetDataItem({
                  "itemName": 'Client_ChanceSource',
                  "callback": function (data) {
                      chanceSource = data;
                      console.log(chanceSource);
                  }
              });
          },
          getList: function () {
              return businessList;
          },
          update: function (callback, identityCardNo) {//刷新数据
              getData(1, identityCardNo, businessList, callback);
          },
          add: function (callback, identityCardNo) {
              getData(businessList.page, identityCardNo, businessList, callback);
          }


      };
  }])



//推迟报到
  .factory('TuiChiBaoDao', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', 'UserInfo', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert, UserInfo) {

      var stuinfo = UserInfo.get();
      var editDataEx = [
        {
            "name": "推迟ID",
            "id": "tuiChiId",
            "isRequire": false
        },
        {
            "name": "学号",
            "id": "stuNo",
            "isRequire": false
        },
        {
            "name": "身份证号",
            "id": "identityCardNo",
            "isRequire": false
        },
        {
            "name": "推迟报到原因",
            "id": "reason",
            "isRequire": true
        },
        {
            "name": "推迟报到时间",
            "id": "tuiChiTime",
            "isRequire": true
        },
        {
            "name": "提交时间",
            "id": "tuiChiOther",
            "isRequire": false
        },
        {
            "name": "班级号",
            "id": "tuiChiOther1",
            "isRequire": false
        },
        {
            "name": "班级名",
            "id": "tuiChiOther2",
            "isRequire": false
        }


      ];//编辑数据字段

      //返回
      return {
          editSubmit: function (editData, callback) {
              $learunHttp.post({
                  "url": ApiUrl.saveTuiChiBaoDaoApi,
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

//绿色通道
  .factory('LvseTongdao', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', 'UserInfo', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert, UserInfo) {

      var stuinfo = UserInfo.get();
      var editDataEx = [
        {
            "name": "序号Id",
            "id": "lvseId",
            "isRequire": false
        },
        {
            "name": "学生ID",
            "id": "stuInfoId",
            "isRequire": false
        },
        {
            "name": "学生姓名",
            "id": "stuName",
            "isRequire": false
        },
        {
            "name": "户籍类别",
            "id": "hujiLeibie",
            "isRequire": true
        },
        {
            "name": "家庭类型",
            "id": "familyType",
            "isRequire": true
        },
        {
            "name": "姓名1",
            "id": "name1",
            "isRequire": true
        },
        {
            "name": "关系1",
            "id": "relationship1",
            "isRequire": true
        },
        {
            "name": "政治面貌1",
            "id": "zhengZhiMianMao1",
            "isRequire": true
        },
        {
            "name": "工作单位1",
            "id": "gongZuoDanWei1",
            "isRequire": true
        },
        {
            "name": "职位1",
            "id": "position1",
            "isRequire": true
        },
        {
            "name": "姓名2",
            "id": "name2",
            "isRequire": true
        },
        {
            "name": "关系2",
            "id": "relationship2",
            "isRequire": true
        },
        {
            "name": "政治面貌2",
            "id": "zhengZhiMianMao2",
            "isRequire": true
        },
        {
            "name": "工作单位2",
            "id": "gongZuoDanWei2",
            "isRequire": true
        },
        {
            "name": "职位2",
            "id": "position2",
            "isRequire": true
        },
        {
            "name": "家庭总人数",
            "id": "familyNumber",
            "isRequire": true
        },
        {
            "name": "家庭月收入",
            "id": "familyMonthIncome",
            "isRequire": true
        },
        {
            "name": "人均月收入",
            "id": "oneMonthIncome",
            "isRequire": true
        },
        {
            "name": "家庭经济困难说明",
            "id": "jingjiKunnan",
            "isRequire": true
        },
        {
            "name": "生源地贷款银行",
            "id": "loanBank",
            "isRequire": true
        },
        {
            "name": "贷款金额",
            "id": "loanAmount",
            "isRequire": true
        },
        {
            "name": "回执单或证明函件图片",
            "id": "proveImg",
            "isRequire": false
        },
        {
            "name": "国开行回执校验码",
            "id": "huiZhiMa",
            "isRequire": true
        },
        {
            "name": "备用",
            "id": "lvseOther",
            "isRequire": false
        },
        {
            "name": "备用",
            "id": "lvseOther1",
            "isRequire": false
        },
        {
            "name": "备用",
            "id": "lvseOther2",
            "isRequire": false
        },
        {
            "name": "备用",
            "id": "lvseOther3",
            "isRequire": false
        },
        {
            "name": "备用",
            "id": "lvseOther4",
            "isRequire": false
        }


      ];//编辑数据字段

      //返回
      return {
          baseInit: function () {
              $learunGetDataItem({
                  "itemName": 'ArriveType',
                  "callback": function (data) {
                      hujiLeibie = data;
                  }
              });
              $learunGetDataItem({
                  "itemName": 'StationName',
                  "callback": function (data) {
                      familyType = data;
                  }
              });
              $learunGetDataItem({
                  "itemName": 'StationName',
                  "callback": function (data) {
                      loanBank = data;
                  }
              });
          },
          editSubmit: function (editData, callback) {
              $learunHttp.post({
                  "url": ApiUrl.saveLvseTongdaoApi,
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
          getHujiLeibie: function () {
              return hujiLeibie;
          },
          getFamilyType: function () {
              return familyType;
          },
          getLoanBank: function () {
              return loanBank;
          },
          getEditDataEx: function () {
              return editDataEx;
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
          "isRequire": true
      },
      {
          "name": "开始时间",
          "id": "beginTime",
          "isRequire": true
      },
      {
          "name": "结束时间",
          "id": "endTime",
          "isRequire": true
      },
      {
          "name": "天数",
          "id": "days",
          "isRequire": true
      },
      {
          "name": "请假原因",
          "id": "leaveRemark",
          "isRequire": true
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
          "isRequire": false
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
        baseInit: function () {
            $learunGetDataItem({
                "itemName": 'DM-XJLX',
                "callback": function (data) {
                    leaveType = data;
                }
            });
        },
        editSubmit: function (editData, callback) {
            $learunHttp.post({
                "url": ApiUrl.saveStuLeaveApi,
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
        getLeaveType: function () {
            return leaveType;
        },
        getEditDataEx: function () {
            return editDataEx;
        }
    };
}])

//操行扣分
.factory('BehaviorRecode', ['$learunFormatDate', '$learunGetDataItem', '$learunHttp', 'ApiUrl', '$learunTopAlert', 'UserInfo', function ($learunFormatDate, $learunGetDataItem, $learunHttp, ApiUrl, $learunTopAlert, UserInfo) {

    var stuinfo = UserInfo.get();
    var editDataEx = [
      {
          "name": "序号Id",
          "id": "iD",
          "isRequire": false 
      },
      {
          "name": "学号",
          "id": "stuNo",
          "isRequire": true
      },
      {
          "name": "姓名",
          "id": "stuName",
          "isRequire": true
      },
      {
          "name": "操行类型ID号",
          "id": "behaviorTypeId",
          "isRequire": false
      },
      {
          "name": "违反的操行",
          "id": "breachBehavior",
          "isRequire": true
      },
      {
          "name": "违反时间",
          "id": "breachTime",
          "isRequire": true
      },
      {
          "name": "提交者",
          "id": "submiter",
          "isRequire": false
      },
      {
          "name": "是否撤消，0未撤消，1撤消申请中，2撤消",
          "id": "isCanceled",
          "isRequire": false
      },
      {
          "name": "申请撤消的次数，如果申请撤消次数达3次以上者，不可再次申请",
          "id": "appCancel",
          "isRequire": false
      },
      {
          "name": "是否可以申请撤消，如果申请撤消次数达3次以上者，不可再次申请",
          "id": "canCancel",
          "isRequire": false
      }


    ];//编辑数据字段

    //返回
    return {
        baseInit: function () {
            $learunGetDataItem({//违规类型
                "itemName": 'behavior',
                "callback": function (data) {
                    breachBehavior = data;
                }
            });
        },
        editSubmit: function (editData, callback) {
            $learunHttp.post({
                "url": ApiUrl.SaveBehaviorRecodeApi,
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
        getBehaviorRecodeType: function () {
            return breachBehavior;
        },
        getEditDataEx: function () {
            return editDataEx;
        }
    };
}])

//操行扣分申请撤销
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
                "url": ApiUrl.SaveCancelAppApi,
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
        editReviewSubmit: function (editData, callback) {
            $learunHttp.post({
                "url": ApiUrl.SaveStuReviewCancelAppApi,
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
        editSubmit: function (editData, callback) {
            $learunHttp.post({
                "url": ApiUrl.SaveCancelAppApi,
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
        }
    };
}])


;

