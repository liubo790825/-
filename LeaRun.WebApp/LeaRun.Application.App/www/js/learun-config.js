/**
 * Created by cbb on 16/6/3.
 */
//接口地址信息
angular.module('starter.config', [])
.factory('ApiUrl', function () {
    //注意切换本地调试和布署上服务器后的地址变化
    var rootUrl = "http://localhost:62831/learun/api";//192.168.0.101
    //var rootUrl = "http://127.0.0.1:8078/appservice/learun/api";//192.168.0.5
    //var rootUrl = "http://oa.bjquanjiang.com/learun/api";
  var apiUrl = {
    loginApi: rootUrl + "/login/checkLogin",
    //退出
    outLoginApi: rootUrl + '/login/outLogin',
    //获取员工列表
    getUserListApi:rootUrl +'/user/getUserList',
    //学生列表
    chanceListApi: rootUrl + '/customerManage/chanceList',//对应CustomerManageModule中的方法
    //教师列表
    customerListApi: rootUrl + '/customerManage/customerList',
    //数据字典列表接口
    dataItemListApi: rootUrl + '/dataItem/list',
    //学生添加
    saveChanceApi: rootUrl + '/customerManage/saveChance',
    //教师添加
    saveCustomerApi: rootUrl + '/customerManage/saveCustomer',
    //通知公告列表
    noticeListApi: rootUrl + '/publicInfoManage/noticeList',
    //区域列表接口
    areaListApi: rootUrl + '/area/list',
    //学生删除
    deleteChanceApi: rootUrl + '/customerManage/deleteChance',
    //教师删除
    deleteCustomerApi: rootUrl + '/customerManage/deleteCustomer',


      //抵校登记
      dxdjApi:rootUrl+'/dxdjManage/addToCollage',
      saveDxdjApi: rootUrl + '/dxdjManage/saveDxdj',

  };
  return apiUrl;
});
