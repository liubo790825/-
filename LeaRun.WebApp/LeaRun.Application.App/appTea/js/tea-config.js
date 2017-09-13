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
    chanceListApi: rootUrl + '/customerManage/chanceList',
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

      //报到预约
      baodaoYuyueListApi: rootUrl + '/BaodaoYuyueManage/baodaoYuyueList',

      //新生列表
      freshStuListApi: rootUrl + '/StuInfoManage/freshStuList',

      //推迟报到
      TuiChiInfoListApi: rootUrl + '/baodaoYuyueManage/GetTuiChiBaoDaoInfo',
      //军训服
      JunXunFuListApi: rootUrl + '/baodaoYuyueManage/TeaGetJunXunFuInfo',
      //绿色通道
      LvseTongdaoListApi: rootUrl + '/baodaoYuyueManage/TeaGetLvseTongdaoInfo',
      //宿舍入组信息
      RuZhuListApi: rootUrl + '/baodaoYuyueManage/TeaGetDormListAndChildList',
      //我要咨询
      TeaQuestionListApi: rootUrl + '/baodaoYuyueManage/TeaQuestionList',
      TeaQStuListApi: rootUrl + '/baodaoYuyueManage/TeaQStuList',
      saveAnswerApi: rootUrl + '/baodaoYuyueManage/SaveAnswer',
      TeaAnswerListApi: rootUrl + '/baodaoYuyueManage/TeaStuAnswerList',
      //新生管理各记录数
      TeaJiezhanNumberApi: rootUrl + '/baodaoYuyueManage/TeaJiezhanNumber',//接站信息
      TeaJunxunfuNumberApi: rootUrl + '/baodaoYuyueManage/TeaJunxunfuNumber',//军训服装
      TeaLvsetongdaoNumberApi: rootUrl + '/baodaoYuyueManage/TeaLvsetongdaoNumber',//军训服装
      TeaTuichibaodaoNumberApi: rootUrl + '/baodaoYuyueManage/TeaTuichibaodaoNumber',//推迟报到
      TeaZixunhuifuNumberApi: rootUrl + '/baodaoYuyueManage/TeaZixunhuifuNumber',//咨询回复
      TeaXinshengzhusuNumberApi: rootUrl + '/baodaoYuyueManage/TeaXinshengruzhuNumber',//新生入住
      //请假
      LeaveStuListApi: rootUrl + '/baodaoYuyueManage/TeaGetStuLeaveList',//获取请假学生列表
      TeaGetNotReviewStuLeaveListApi: rootUrl + '/baodaoYuyueManage/TeaGetNotReviewStuLeaveList',//获取未审核学生请假列表
      TeaGetReviewStuLeaveListApi: rootUrl + '/baodaoYuyueManage/TeaGetReviewStuLeaveList',//获取已审核学生请假列表
      TeaGetStuLeaveMajorClassInfoApi: rootUrl + '/baodaoYuyueManage/TeaGetStuLeaveMajorClassInfo',//获取请假学生班级专业信息
      saveTeaLeaveshenpiApi: rootUrl + '/baodaoYuyueManage/saveTeaLeaveshenpi',//保存请假审批信息
      //操行扣分申请撤销
      TeaGetReviewStuCaoxingKoufenListApi: rootUrl + '/baodaoYuyueManage/TeaGetReviewStuCaoxingKoufenList',//审核撤销申请
      saveTeaCancelAppReviewApi: rootUrl + '/baodaoYuyueManage/saveTeaCancelAppReview',//保存教师审核信息

      //工作办理记录数
      TeaStuLeaveNumberApi: rootUrl + '/baodaoYuyueManage/TeaStuLeaveNumber',//请假
      TeaCancelAppNumberApi: rootUrl + '/baodaoYuyueManage/TeaCancelAppNumber',//操行扣分申请撤销

      //宿舍交换
      TeaGetDormExchangeListApi: rootUrl + '/baodaoYuyueManage/TeaGetDormExchangeList',//获取交换宿舍申请
      TeaDormExchangeApi: rootUrl + '/baodaoYuyueManage/TeaDormExchangeNumber',//教师端获取宿舍交换申请记录数
      TeaGetDormExchangeStuInfoApi: rootUrl + '/baodaoYuyueManage/TeaGetDormExchangeStuInfo',//宿舍交换双方学生信息
      SaveDormExchangePassedApi: rootUrl + '/baodaoYuyueManage/saveTeaDormExchangeReview',//保存教师审核是否通过
  };
  return apiUrl;
});
