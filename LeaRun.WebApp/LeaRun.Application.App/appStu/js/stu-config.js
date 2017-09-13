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

        //数据字典列表接口
        dataItemListApi: rootUrl + '/dataItem/list',
        //通知公告列表
        noticeListApi: rootUrl + '/publicInfoManage/noticeList',
        //区域列表接口
        areaListApi: rootUrl + '/area/list',
        //基础信息接口
        baseDataApi: rootUrl + '/BaseData/getBaseData',

        //学生登陆
        loginApi: rootUrl + "/login/stuLogin",
        //loginApi: rootUrl + "/login/checkLogin",

        //退出
        outLoginApi: rootUrl + '/login/outLogin',



        //报到预约
        savebaodaoYuyueApi: rootUrl + '/BaodaoYuyueManage/SaveBaodaoYuyue',
        YuyueListApi: rootUrl + '/BaodaoYuyueManage/getYuyueInfo',
        //同班同学信息
        classmatesListApi: rootUrl + '/BaodaoYuyueManage/classmatesList',
        //宿舍预约
        dormBedListApi: rootUrl + '/baodaoYuyueManage/getDormListAndChildList',
        saveStuToBedApi: rootUrl + '/baodaoYuyueManage/SaveStuToBed',
        //寝室室友信息
        MyRoommatesListApi: rootUrl + '/baodaoYuyueManage/MyRoommates',
        //军训服装预约
        saveJunXunFuApi: rootUrl + '/baodaoYuyueManage/SaveJunxunfu',
        junXunFuListApi: rootUrl + '/baodaoYuyueManage/GetJunxunfuInfo',
        //我的咨询
        saveMyQuestionApi: rootUrl + '/baodaoYuyueManage/SaveMyQuestion',
        MyQuestionListApi: rootUrl + '/baodaoYuyueManage/MyQuestionList',
        StuAnswerListApi: rootUrl + '/baodaoYuyueManage/TeaStuAnswerList',
        //推迟报到
        saveTuiChiBaoDaoApi: rootUrl + '/baodaoYuyueManage/SaveTuiChiBaoDao',
        TuiChiBaoDaoListApi: rootUrl + '/baodaoYuyueManage/StuGetTuiChiBaoDaoInfo',
        //绿色通道
        saveLvseTongdaoApi: rootUrl + '/baodaoYuyueManage/SaveLvseTongdao',
        LvseTongdaoListApi: rootUrl + '/baodaoYuyueManage/GetLvseTongdaoInfo',
        //学生请假
        saveStuLeaveApi: rootUrl + '/baodaoYuyueManage/saveStuLeave',
        StuLeaveListApi: rootUrl + '/baodaoYuyueManage/StuLeaveInfo',
        StuLeaveResultListApi: rootUrl + '/baodaoYuyueManage/StuLeaveResultInfo',
        //综合学分
        QualityScoreListApi: rootUrl + '/baodaoYuyueManage/QualityScoreList',
        //操行扣分
        SaveBehaviorRecodeApi: rootUrl + '/baodaoYuyueManage/saveBehaviorRecode',
        GetMyBreachBehaviorListApi: rootUrl + '/baodaoYuyueManage/StuGetMyBehaviorRecodeList',
        SaveCancelAppApi: rootUrl + '/baodaoYuyueManage/saveCancelApp',
        GetcancelAppListApi: rootUrl + '/baodaoYuyueManage/StuGetCancelAppList',
        SaveStuReviewCancelAppApi: rootUrl + '/baodaoYuyueManage/saveReviewCancelApp',
        StuCaoXingCheXiaoNumberApi: rootUrl + '/baodaoYuyueManage/StuCancelAppNumber',
        //宿舍交换
        dormExchangeBedListApi: rootUrl + '/baodaoYuyueManage/GetExchangeDormListAndChildList',
        SelectOldBedIdApi: rootUrl + '/baodaoYuyueManage/SelectOldBedId',
        SaveAppRemarkApi: rootUrl + '/baodaoYuyueManage/saveDormExchangeAppRemark',
        AppChangeBedApi: rootUrl + '/baodaoYuyueManage/SelectAppChangeBed',
        SelectMyDromExchagngeApi: rootUrl + '/baodaoYuyueManage/SelectMyDromExchagnge',
        GetMyExchangeListApi: rootUrl + '/baodaoYuyueManage/StuGetMyExchangeList',
  };
  return apiUrl;
});
