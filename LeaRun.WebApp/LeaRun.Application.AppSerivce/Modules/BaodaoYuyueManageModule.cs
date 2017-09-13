using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Application.Busines.CustomerManage;
using LeaRun.Application.Busines.SystemManage;
using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Entity.CustomerManage;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using Nancy.Responses.Negotiation;
using System;
using System.Collections.Generic;
using LeaRun.Application.AppSerivce.Modules;

namespace LeaRun.Application.AppSerivce
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技
    /// 创建人：XX
    /// 日 期：2017.07.12 13:57
    /// 描 述:客户管理接口
    /// </summary>
    public class BaodaoYuyueManage : BaseModule
    {
        private BK_StuInfoBLL stuinfoBLL = new BK_StuInfoBLL();
        private BK_BaodaoYuyueBLL bdyyBLL = new BK_BaodaoYuyueBLL();
        private BK_DormBLL dorminfoBLL = new BK_DormBLL();
        private BK_DormBedBLL dormBedBLL = new BK_DormBedBLL();
        private BK_StuBedDwellBLL dwellbll = new BK_StuBedDwellBLL();
        private BK_JunxunFuzhuangBLL jxfzBLL = new BK_JunxunFuzhuangBLL();
        private BK_AdvisoryBLL QABLL = new BK_AdvisoryBLL();
        private BK_TuiChiBaoDaoBLL TCBLL = new BK_TuiChiBaoDaoBLL();
        private BK_LvseTongdaoBLL LvseBLL = new BK_LvseTongdaoBLL();
        private BK_AdvisoryAnswerBLL answerBLL = new BK_AdvisoryAnswerBLL();
        private BK_StuLeaveBLL stuleaveBLL = new BK_StuLeaveBLL();
        private BK_StuQSBLL stuqsBLL = new BK_StuQSBLL();
        private BK_BehaviorRecodeBLL BehaviorRecodeBll = new BK_BehaviorRecodeBLL();
        private BK_CancelAppBLL CancelAppBll = new BK_CancelAppBLL();
        private BK_AppChangeBedBLL AppChangeBedBLL = new BK_AppChangeBedBLL();


        public BaodaoYuyueManage()
            : base("/learun/api")
        {
            #region 教师端用
            //教师端用
            Post["/baodaoYuyueManage/baodaoYuyueList"] = BaodaoYuyueList;//对应learun-config.js中的配置路径       
            Post["/baodaoYuyueManage/GetTuiChiBaoDaoInfo"] = GetTuiChiBaoDaoInfo;//查询推迟报到学生信息
            Post["/baodaoYuyueManage/TeaGetJunXunFuInfo"] = TeaGetJunXunFuInfo;//获取军训服信息
            Post["/baodaoYuyueManage/TeaGetLvseTongdaoInfo"] = TeaGetLvseTongdaoInfo;//获取绿色通道信息
            Post["/baodaoYuyueManage/TeaGetDormListAndChildList"] = TeaGetDormListAndChildList; //获取宿舍入住信息
            Post["/baodaoYuyueManage/TeaQuestionList"] = TeaQuestionList;//获取咨询问题信息
            Post["/baodaoYuyueManage/TeaQStuList"] = TeaQStuList;//获取咨询学生信息
            Post["/baodaoYuyueManage/SaveAnswer"] = SaveAnswer; //保存咨询回复信息
            Post["/baodaoYuyueManage/TeaStuAnswerList"] = TeaStuAnswerList;//教师端与学生端获取回复信息

            //新生管理各记录数
            Post["/baodaoYuyueManage/TeaJiezhanNumber"] = TeaJiezhanNumber;//接站信息
            Post["/baodaoYuyueManage/TeaJunxunfuNumber"] = TeaJunxunfuNumber;//军训服装
            Post["/baodaoYuyueManage/TeaLvsetongdaoNumber"] = TeaLvsetongdaoNumber;//绿色通道
            Post["/baodaoYuyueManage/TeaTuichibaodaoNumber"] = TeaTuichibaodaoNumber;//推迟报到
            Post["/baodaoYuyueManage/TeaZixunhuifuNumber"] = TeaZixunhuifuNumber;//咨询回复
            Post["/baodaoYuyueManage/TeaXinshengruzhuNumber"] = TeaXinshengruzhuNumber;//新生入住

            //请假
            Post["/baodaoYuyueManage/TeaGetStuLeaveList"] = TeaGetStuLeaveList;//获取请假学生列表
            Post["/baodaoYuyueManage/TeaStuLeaveInfoList"] = TeaStuLeaveInfoList;//获取单个学生请假列表
            Post["/baodaoYuyueManage/TeaGetNotReviewStuLeaveList"] = TeaGetNotReviewStuLeaveList;//获取未审核学生请假列表
            Post["/baodaoYuyueManage/TeaGetReviewStuLeaveList"] = TeaGetReviewStuLeaveList;//获取已审核学生请假列表
            Post["/baodaoYuyueManage/TeaGetStuLeaveMajorClassInfo"] = TeaGetStuLeaveMajorClassInfo;//获取请假学生的专业班级
            Post["/baodaoYuyueManage/saveTeaLeaveshenpi"] = saveTeaLeaveshenpi;//保存请假审批信息
            Post["/baodaoYuyueManage/TeaGetReviewStuCaoxingKoufenList"] = TeaGetReviewStuCaoxingKoufenList;//保存操行扣分审核信息
            Post["/baodaoYuyueManage/saveTeaCancelAppReview"] = saveTeaCancelAppReview;//保存教师审核操行扣分撤销申请

            //工作办理
            Post["/baodaoYuyueManage/TeaStuLeaveNumber"] = TeaStuLeaveNumber;//获取请假记录数
            Post["/baodaoYuyueManage/TeaCancelAppNumber"] = TeaCancelAppNumber;//获取操行撤销记录数
            Post["/baodaoYuyueManage/TeaGetDormExchangeList"] = TeaGetDormExchangeList;//教师端获取交换申请
            Post["/baodaoYuyueManage/TeaDormExchangeNumber"] = TeaDormExchangeNumber;//教师端获取宿舍交换申请记录数
            Post["/baodaoYuyueManage/TeaGetDormExchangeStuInfo"] = TeaGetDormExchangeStuInfo;//宿舍交换双方学生信息
            Post["/baodaoYuyueManage/saveTeaDormExchangeReview"] = saveTeaDormExchangeReview;// 保存教师宿舍交换审核信息
            #endregion


            #region 学生端用
            //学生端用
            Post["/baodaoYuyueManage/getYuyueInfo"] = GetYuyueInfo;//获取报到预约信息
            Post["/baodaoYuyueManage/saveBaodaoYuyue"] = SaveBaodaoYuyue;//保存报到预约信息
            Post["/baodaoYuyueManage/classmatesList"] = ClassmatesList;//查询同班同学
            Post["/baodaoYuyueManage/getDormListAndChildList"] =GetDormListAndChildList;//查询出所有床位信息
            Post["/baodaoYuyueManage/SaveStuToBed"] = SaveStuToBed;//保存选择的床位
            Post["/baodaoYuyueManage/MyRoommates"] = MyRoommates;//查询我的室友
            Post["/baodaoYuyueManage/SaveJunxunfu"] = SaveJunxunfu;//保存军训服装信息  
            Post["/baodaoYuyueManage/GetJunxunfuInfo"] = GetJunxunfuInfo;//获取军训服装信息
            Post["/baodaoYuyueManage/SaveMyQuestion"] = SaveMyQuestion;//保存我的咨询问题
            Post["/baodaoYuyueManage/MyQuestionList"] = MyQuestionList;//获取我的咨询问题列表
            Post["/baodaoYuyueManage/SaveTuiChiBaoDao"] = SaveTuiChiBaoDao;//保存推迟报到信息
            Post["/baodaoYuyueManage/StuGetTuiChiBaoDaoInfo"] = StuGetTuiChiBaoDaoInfo;//获取推迟报到信息
            Post["/baodaoYuyueManage/SaveLvseTongdao"] = SaveLvseTongdao;//保存绿色通道信息
            Post["/baodaoYuyueManage/GetLvseTongdaoInfo"] = GetLvseTongdaoInfo;//获取绿色通道信息
            Post["/baodaoYuyueManage/saveStuLeave"] = saveStuLeave;//保存学生请假信息
            Post["/baodaoYuyueManage/StuLeaveInfo"] = StuLeaveInfo;//获取学生请假信息
            Post["/baodaoYuyueManage/StuLeaveResultInfo"] = StuLeaveResultInfo;//获取单条请假信息记录
            Post["/baodaoYuyueManage/QualityScoreList"] = QualityScoreList;//获取综合学分信息
            Post["/baodaoYuyueManage/saveBehaviorRecode"] = saveBehaviorRecode;//保存学生操行扣分
            Post["/baodaoYuyueManage/StuGetMyBehaviorRecodeList"] = StuGetMyBehaviorRecodeList;//获取我的操行扣分记录
            Post["/baodaoYuyueManage/saveCancelApp"] = saveCancelApp;//保存撤销操行违规记录申请
            Post["/baodaoYuyueManage/StuGetCancelAppList"] = StuGetCancelAppList;//获取操行扣分撤销申请记录列表
            Post["/baodaoYuyueManage/saveReviewCancelApp"] = saveReviewCancelApp;//保存学生会撤消申请审核信息
            Post["/baodaoYuyueManage/StuCancelAppNumber"] = StuCancelAppNumber;//获取操行扣分申请撤销记录数
            Post["/baodaoYuyueManage/GetExchangeDormListAndChildList"] = GetExchangeDormListAndChildList;//交换宿舍房间与床位
            Post["/baodaoYuyueManage/SelectOldBedId"] = SelectOldBedId;//获取原床位信息
            Post["/baodaoYuyueManage/saveDormExchangeAppRemark"] = saveDormExchangeAppRemark;//保存宿舍交换申请信息
            Post["/baodaoYuyueManage/SelectAppChangeBed"] = SelectAppChangeBed;//获取宿舍交换记录信息
            Post["/baodaoYuyueManage/SelectMyDromExchagnge"] = SelectMyDromExchagnge;//查询我的宿舍交换记录信息
            Post["/baodaoYuyueManage/StuGetMyExchangeList"] = StuGetMyExchangeList;//对我的交换申请

            #endregion
        }

        #region 教师端用
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator BaodaoYuyueList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();//开始计时
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);//看是否登录
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = bdyyBLL.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<BK_BaodaoYuyueEntity>> dataPageList = new DataPageList<IEnumerable<BK_BaodaoYuyueEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<BK_BaodaoYuyueEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch(System.Exception e)
            {
                /*The entity type BK_BaodaoYuyueEntity is not part of the model for the current context.
                 * 测试了一通之后，问题解决的方法也异常的简单：

在NopCommerce中有一个插件机制，应该来说这是这个开源项目的特色功能之一（Plugins目录上的所有项目），当然在插件项目中也需要引用Core和services项目的，

我再去看web项目发现当中有引用一个插件项目，这就是问题所在：

Plugins依赖：Core,data,services

web项目依赖：Core,data,Plugins,sevices

Plugins插件：会生成到另外一个单独的目录

所以，生成之后的web项目的Core,data,services与Plugins插件生的目录中的Core,data,services不一致才造成了问题的发生。

解决方法：
1.删除所有无须引用的依赖项目，更不能存在递归依赖的情况。
2.重新编译所有项目。
3.重新发布。
                 * */
                return this.SendData(ResponseType.Fail, "异常"+e.Message);
            }

        }


        /// <summary>
        /// 获取军训服装信息列表2017-8-7
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Negotiator TeaGetJunXunFuInfo(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();//开始计时
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);//看是否登录
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = jxfzBLL.GetJunXunFuList(pagination);
                    DataPageList<IEnumerable<M_BK_JunxunFuzhuangEntity>> dataPageList = new DataPageList<IEnumerable<M_BK_JunxunFuzhuangEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<M_BK_JunxunFuzhuangEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }

        }

        //获取绿色通道信息
        private Negotiator TeaGetLvseTongdaoInfo(dynamic _)
        {
            try
            {

                var watch = CommonHelper.TimerStart();//开始计时
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);//看是否登录
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = LvseBLL.GetLvseInfo(pagination);
                    DataPageList<IEnumerable<BK_LvseTongdaoEntity>> dataPageList = new DataPageList<IEnumerable<BK_LvseTongdaoEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<BK_LvseTongdaoEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }


        /// <summary>
        /// 获取推迟报到学生信息列表2017-7-20 唐世杰
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Negotiator GetTuiChiBaoDaoInfo(dynamic _)
        {
            try
            {

                var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
                var data = TCBLL.GetTuiChiClass();
                List<TuiChi> TuiChiList = new List<TuiChi>();
                foreach (var TuiChi in data)
                {
                    var childData = TCBLL.GetTuiChiInfo(TuiChi.TuiChiOther1); //      
                    TuiChi d = new TuiChi();
                    d.entity = TuiChi;
                    d.childEntity = childData;
                    TuiChiList.Add(d);
                }
                var temp = this.SendData(TuiChiList, recdata.userid, recdata.token, ResponseType.Success);
                return temp;
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }

        /// <summary>
        //教师端查询宿舍入住信息
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public Negotiator TeaGetDormListAndChildList(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
                var data = dorminfoBLL.GetDormId();
                List<TeaDorm> dormList = new List<TeaDorm>();
                foreach (var dorm in data)
                {
                    var childData = dorminfoBLL.TeaGetDormBed(dorm.DormId); //得到所有的床位信息      
                    TeaDorm d = new TeaDorm();
                    d.entity = dorm;
                    d.childEntity = childData;
                    dormList.Add(d);
                }
                var temp = this.SendData(dormList, recdata.userid, recdata.token, ResponseType.Success);
                return temp;
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }


        /// <summary>
        /// 教师端获取我咨询的问题列表2017-7-20
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator TeaQuestionList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                //if (!resValidation)
                //{
                //    return this.SendData(ResponseType.Fail, "后台无登录信息");
                //}
                //else
                //{
                Pagination pagination = new Pagination
                {
                    page = recdata.data.page,
                    rows = recdata.data.rows,
                    sidx = recdata.data.sidx,
                    sord = recdata.data.sord
                };
                var data = QABLL.TeaGetPageList(pagination,recdata.data.queryData);
                DataPageList<IEnumerable<BK_AdvisoryEntity>> dataPageList = new DataPageList<IEnumerable<BK_AdvisoryEntity>>
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return this.SendData<DataPageList<IEnumerable<BK_AdvisoryEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                //}
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }

        /// <summary>
        /// 教师端获取咨询的学生列表2017-8-9
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator TeaQStuList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                //if (!resValidation)
                //{
                //    return this.SendData(ResponseType.Fail, "后台无登录信息");
                //}
                //else
                //{
                Pagination pagination = new Pagination
                {
                    page = recdata.data.page,
                    rows = recdata.data.rows,
                    sidx = recdata.data.sidx,
                    sord = recdata.data.sord
                };
                var data = QABLL.TeaGetStuList(pagination);
                DataPageList<IEnumerable<BK_AdvisoryEntity>> dataPageList = new DataPageList<IEnumerable<BK_AdvisoryEntity>>
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return this.SendData<DataPageList<IEnumerable<BK_AdvisoryEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                //}
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }
        /// <summary>
        ///保存 咨询回复信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator SaveAnswer(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_AdvisoryAnswerEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    answerBLL.SaveForm(recdata.data.AId, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }


        //教师端与学生端查看回复
        private Negotiator TeaStuAnswerList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                //if (!resValidation)
                //{
                //    return this.SendData(ResponseType.Fail, "后台无登录信息");
                //}
                //else
                //{
                Pagination pagination = new Pagination
                {
                    page = recdata.data.page,
                    rows = recdata.data.rows,
                    sidx = recdata.data.sidx,
                    sord = recdata.data.sord
                };
                var data = answerBLL.GetMyAnswer(pagination, recdata.data.queryData);
                DataPageList<IEnumerable<BK_AdvisoryAnswerEntity>> dataPageList = new DataPageList<IEnumerable<BK_AdvisoryAnswerEntity>>
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return this.SendData<DataPageList<IEnumerable<BK_AdvisoryAnswerEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                //}
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }



        //迎新管理记录数start——————————————————————

        //接站信息
        private Negotiator TeaJiezhanNumber(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = bdyyBLL.Number();
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }
        //军训服信息
        private Negotiator TeaJunxunfuNumber(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = jxfzBLL.Number();
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }

        //绿色通道
        private Negotiator TeaLvsetongdaoNumber(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = LvseBLL.Number();
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }

        //推迟报到
        private Negotiator TeaTuichibaodaoNumber(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = TCBLL.Number();
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }

        //咨询回复
        private Negotiator TeaZixunhuifuNumber(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = QABLL.Number();
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }

        //新生入住信息
        private Negotiator TeaXinshengruzhuNumber(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = dormBedBLL.Number();
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }


        //迎新管理记录数end——————————————————————


        /// <summary>
        /// 获取请假学生列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        public Negotiator TeaGetStuLeaveList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();//开始计时
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);//看是否登录
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = stuleaveBLL.GetStuLeaveList(pagination);
                    DataPageList<IEnumerable<BK_StuLeaveEntity>> dataPageList = new DataPageList<IEnumerable<BK_StuLeaveEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<BK_StuLeaveEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }

        }

        /// <summary>
        /// 获取单个学生请假列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator TeaStuLeaveInfoList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();//开始计时
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);//看是否登录
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = stuleaveBLL.GetPageList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<BK_StuLeaveEntity>> dataPageList = new DataPageList<IEnumerable<BK_StuLeaveEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<BK_StuLeaveEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (System.Exception e)
            {
                return this.SendData(ResponseType.Fail, "异常" + e.Message);
            }
        }

        /// <summary>
        /// 获取未审核学生请假列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator TeaGetNotReviewStuLeaveList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();//开始计时
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);//看是否登录
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = stuleaveBLL.GetNotReviewStuLeaveList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<BK_StuLeaveEntity>> dataPageList = new DataPageList<IEnumerable<BK_StuLeaveEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<BK_StuLeaveEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (System.Exception e)
            {
                return this.SendData(ResponseType.Fail, "异常" + e.Message);
            }
        }

        /// <summary>
        /// 获取已审核学生请假列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator TeaGetReviewStuLeaveList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();//开始计时
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);//看是否登录
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = stuleaveBLL.GetReviewStuLeaveList(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<BK_StuLeaveEntity>> dataPageList = new DataPageList<IEnumerable<BK_StuLeaveEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<BK_StuLeaveEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (System.Exception e)
            {
                return this.SendData(ResponseType.Fail, "异常" + e.Message);
            }
        }

        //请假学生班级专业信息
        private Negotiator TeaGetStuLeaveMajorClassInfo(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = stuleaveBLL.GetStuLeaveMajorClassInfo(recdata.data.queryData);
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }



        /// <summary>
        /// 保存学生请假信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator saveTeaLeaveshenpi(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_StuLeaveEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    stuleaveBLL.SaveForm(recdata.data.ID, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }


        /// <summary>
        /// 获取操行违规扣分撤销申请记录
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator TeaGetReviewStuCaoxingKoufenList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();//开始计时
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);//看是否登录
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = CancelAppBll.TeaGetCancelAppList(pagination);
                    DataPageList<IEnumerable<M_BK_CancelAppEntity>> dataPageList = new DataPageList<IEnumerable<M_BK_CancelAppEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<M_BK_CancelAppEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (System.Exception e)
            {
                return this.SendData(ResponseType.Fail, "异常" + e.Message);
            }
        }


        /// <summary>
        /// 保存教师审核操行扣分撤销申请信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator saveTeaCancelAppReview(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_CancelAppEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    CancelAppBll.SaveForm2(recdata.data.ID, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }

        //获取请假记录数
        private Negotiator TeaStuLeaveNumber(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = stuleaveBLL.Number();
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }


        //获取操行撤销申请记录数
        private Negotiator TeaCancelAppNumber(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = CancelAppBll.TeaNumber();
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }


        /// <summary>
        /// 教师端获取交换申请
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator TeaGetDormExchangeList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();//开始计时
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);//看是否登录
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = AppChangeBedBLL.TeaGetDormExchangeList(pagination);
                    DataPageList<IEnumerable<M_BK_AppChangeBedEntity>> dataPageList = new DataPageList<IEnumerable<M_BK_AppChangeBedEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<M_BK_AppChangeBedEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (System.Exception e)
            {
                return this.SendData(ResponseType.Fail, "异常" + e.Message);
            }
        }


        //教师端获取宿舍交换申请记录数
        private Negotiator TeaDormExchangeNumber(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = AppChangeBedBLL.TeaNumber();
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }

        //宿舍交换双方学生信息
        private Negotiator TeaGetDormExchangeStuInfo(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = AppChangeBedBLL.DormExchangeStuInfo(recdata.data.queryData);
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_AppChangeBedEntity>();
                    M_BK_AppChangeBedEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_AppChangeBedEntity();

                    return this.SendData<M_BK_AppChangeBedEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }


        /// <summary>
        /// 保存教师宿舍交换审核信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator saveTeaDormExchangeReview(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_AppChangeBedEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    AppChangeBedBLL.SaveForm(recdata.data.ID, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }

        #endregion 教师端用

        #region 学生端用

        /// <summary>
        ///保存 添加/编辑预约报到信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator SaveBaodaoYuyue(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_BaodaoYuyueEntity>>();
                //string moduleId = "1d3797f6-5cd2-41bc-b769-27f2513d61a9";//管理模块
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    bdyyBLL.SaveForm(recdata.data.YuyueId, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }
        //获取预约报到信息
        private Negotiator GetYuyueInfo(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            //var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
            //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = bdyyBLL.GetList(recdata.data.queryData);
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.BK_BaodaoYuyueEntity>();
                    BK_BaodaoYuyueEntity stuEntity =q.Count>=1? q[0]:new BK_BaodaoYuyueEntity();

                    return this.SendData<BK_BaodaoYuyueEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);//注意recdata.userid, recdata.token 传值用于后续模块的登录判定
                    //return this.SendData<BK_BaodaoYuyueEntity>(stuEntity, stuEntity.BaodaoOther1, stuEntity.YuyueId, ResponseType.Success);
                }                
            }
            catch (Exception ex)//报错很有可能是生成的map没有包含进项目
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }

        /// <summary>
        ///保存 添加/编辑军训服装信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator SaveJunxunfu(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_JunxunFuzhuangEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    jxfzBLL.SaveForm(recdata.data.FuzhuangId, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }

        //获取军训服装信息
        private Negotiator GetJunxunfuInfo(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = jxfzBLL.GetList(recdata.data.queryData);
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.BK_JunxunFuzhuangEntity>();
                    BK_JunxunFuzhuangEntity stuEntity = q.Count >= 1 ? q[0] : new BK_JunxunFuzhuangEntity();

                    return this.SendData<BK_JunxunFuzhuangEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }




        /// <summary>
        /// 根据专业和性别得到所有的宿舍和宿舍下面的床位
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public Negotiator GetDormListAndChildList(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
                var data = dorminfoBLL.GetDormName(recdata.data.queryData);
                List<Dorm> dormList = new List<Dorm>();
                foreach (var dorm in data)
                {
                    var childData = dorminfoBLL.GetDormBed(dorm.DormId); //得到所有的床位信息      
                    Dorm d = new Dorm();
                    d.entity = dorm;
                    d.childEntity = childData;
                    dormList.Add(d);
                }
                var temp = this.SendData(dormList, recdata.userid, recdata.token,  ResponseType.Success);
                return temp;
           }
          catch
          {
                return this.SendData(ResponseType.Fail, "出现异常");
          }

        }

        //保存选择的宿舍与床位信息
        public Negotiator SaveStuToBed(dynamic _)
        {
            try
            {
                
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            string bedids =  "";//床位ID号
            string stuinfoid = "";//学生ID号
            string qp = recdata.data.queryData;
            Dictionary<string, string> queryParam = qp.ToObject<Dictionary<string, string>>();
            foreach (var item in queryParam)
            {
                if (item.Key.Equals("BedId"))
                {
                    bedids = item.Value;
                }
                if (item.Key.Equals("stuId"))
                {
                    stuinfoid = item.Value;
                }
            }

                BK_StuInfoBLL sbll = new BK_StuInfoBLL();
                BK_DormBLL dbll = new BK_DormBLL();

                lock (this)
                {
                    BK_StuInfoEntity student = sbll.GetEntity(stuinfoid);
                    List<BK_DormBedEntity> studormlist = dormBedBLL.GetList(new { StuId = stuinfoid }.ToJson());
                    if (studormlist.Count == 0)
                    {
                        List<BK_DormBedEntity> bedlist = new List<BK_DormBedEntity>();

                        BK_DormBedEntity bedentity = dormBedBLL.GetEntity(bedids);
                        if (bedentity.IsUsed == 0) //只有在没有使用的情况下才能入住
                        {
                            bedentity.IsUsed = 1;
                            bedentity.StuId = stuinfoid;
                            bedentity.StuName = student.StuName;

                            BK_DormEntity dorm = dbll.GetEntity(bedentity.DormId);
                            dorm.UsedBeds += 1;//修改已使用床位数量
                            dorm.NotUseBeds -= 1;//修改未使用床位数量

                            string queryjson = new { StuId = stuinfoid, BedId = bedids }.ToJson();
                            BK_StuBedDwellEntity beddwell = dwellbll.GetEntityByWhere(queryjson);//查询是否已经入住了，如果没有入住就增加入住
                            if (beddwell == null)
                            {
                                beddwell = new BK_StuBedDwellEntity();
                                beddwell.StuId = stuinfoid;
                                beddwell.BedId = bedids;
                            }
                            beddwell.EnterDate = DateTime.Now;
                            beddwell.EnterRemark = "新生入住";

                            dwellbll.SaveForm(beddwell.ID, beddwell);
                            bedlist.Add(bedentity);
                            dbll.SaveForm(dorm.DormId, dorm, bedlist);
                        }
                    }
                    else
                    {
                        return this.SendData(ResponseType.Fail, "你已经选择了其它床位，不能再次选择！");
                    }
                }
            }
            catch (System.Exception ex)
            {
             return this.SendData(ResponseType.Fail, "出现异常");

            }
            return this.SendData(ResponseType.Success, "占用床位成功");
        }



        /// <summary>
        /// 获取自己寝室信息2017-7-20 唐世杰
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator MyRoommates(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                //if (!resValidation)
                //{
                //    return this.SendData(ResponseType.Fail, "后台无登录信息");
                //}
                //else
                //{
                Pagination pagination = new Pagination
                {
                    page = recdata.data.page,
                    rows = recdata.data.rows,
                    sidx = recdata.data.sidx,
                    sord = recdata.data.sord
                };
                var data = stuinfoBLL.GetMyDormers(recdata.data.queryData);
                DataPageList<IEnumerable<M_BK_DormStuInfoEntity>> dataPageList = new DataPageList<IEnumerable<M_BK_DormStuInfoEntity>>
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return this.SendData<DataPageList<IEnumerable<M_BK_DormStuInfoEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                //}
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }


        /// <summary>
        /// 获取同班学生列表2017-7-20 唐世杰
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator ClassmatesList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                //if (!resValidation)
                //{
                //    return this.SendData(ResponseType.Fail, "后台无登录信息");
                //}
                //else
                //{
                Pagination pagination = new Pagination
                {
                    page = recdata.data.page,
                    rows = recdata.data.rows,
                    sidx = recdata.data.sidx,
                    sord = recdata.data.sord
                };
                var data = stuinfoBLL.GetMyClassmatesList(pagination, recdata.data.queryData);
                DataPageList<IEnumerable<BK_StuInfoEntity>> dataPageList = new DataPageList<IEnumerable<BK_StuInfoEntity>>
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return this.SendData<DataPageList<IEnumerable<BK_StuInfoEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                //}
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }


        /// <summary>
        /// 保存我的咨询问题2017-8-2 唐世杰
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator SaveMyQuestion(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_AdvisoryEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    QABLL.SaveForm(recdata.data.QAId, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }
        /// <summary>
        /// 获取我咨询的问题列表2017-7-20
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator MyQuestionList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                //if (!resValidation)
                //{
                //    return this.SendData(ResponseType.Fail, "后台无登录信息");
                //}
                //else
                //{
                Pagination pagination = new Pagination
                {
                    page = recdata.data.page,
                    rows = recdata.data.rows,
                    sidx = recdata.data.sidx,
                    sord = recdata.data.sord
                };
                var data = QABLL.GetPageList(pagination, recdata.data.queryData);
                DataPageList<IEnumerable<BK_AdvisoryEntity>> dataPageList = new DataPageList<IEnumerable<BK_AdvisoryEntity>>
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return this.SendData<DataPageList<IEnumerable<BK_AdvisoryEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                //}
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }


        /// <summary>
        /// 保存推迟报到信息2017-8-2 唐世杰
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator SaveTuiChiBaoDao(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_TuiChiBaoDaoEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    TCBLL.SaveForm(recdata.data.TuiChiId, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }

        //获取推迟报到信息
        private Negotiator StuGetTuiChiBaoDaoInfo(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = TCBLL.GetList(recdata.data.queryData);
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.BK_TuiChiBaoDaoEntity>();
                    BK_TuiChiBaoDaoEntity stuEntity = q.Count >= 1 ? q[0] : new BK_TuiChiBaoDaoEntity();

                    return this.SendData<BK_TuiChiBaoDaoEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }


        
        /// <summary>
        /// 保存绿色通道信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator SaveLvseTongdao(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_LvseTongdaoEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    LvseBLL.SaveForm(recdata.data.LvseId, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }
        //获取绿色通道信息
        private Negotiator GetLvseTongdaoInfo(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = LvseBLL.GetList(recdata.data.queryData);
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.BK_LvseTongdaoEntity>();
                    BK_LvseTongdaoEntity stuEntity = q.Count >= 1 ? q[0] : new BK_LvseTongdaoEntity();

                    return this.SendData<BK_LvseTongdaoEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }


        /// <summary>
        /// 保存学生请假信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator saveStuLeave(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_StuLeaveEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    stuleaveBLL.SaveForm(recdata.data.ID, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }


        /// <summary>
        /// 获取请假信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator StuLeaveInfo(dynamic _)
        {
            try
            {

                var watch = CommonHelper.TimerStart();//开始计时
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);//看是否登录
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = stuleaveBLL.GetStuLeaveInfo(pagination, recdata.data.queryData);
                    DataPageList<IEnumerable<BK_StuLeaveEntity>> dataPageList = new DataPageList<IEnumerable<BK_StuLeaveEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<BK_StuLeaveEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }
        /// <summary>
        /// 获取单条请假记录详细信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator StuLeaveResultInfo(dynamic _)
        {
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = stuleaveBLL.GetStuLeaveResultInfo(recdata.data.queryData);
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.BK_StuLeaveEntity>();
                    BK_StuLeaveEntity stuEntity = q.Count >= 1 ? q[0] : new BK_StuLeaveEntity();

                    return this.SendData<BK_StuLeaveEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }


        /// <summary>
        /// 获取综合学分听取讲座记录信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator QualityScoreList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                //if (!resValidation)
                //{
                //    return this.SendData(ResponseType.Fail, "后台无登录信息");
                //}
                //else
                //{
                Pagination pagination = new Pagination
                {
                    page = recdata.data.page,
                    rows = recdata.data.rows,
                    sidx = recdata.data.sidx,
                    sord = recdata.data.sord
                };
                var data = stuqsBLL.GetPageList(pagination, recdata.data.queryData);
                DataPageList<IEnumerable<BK_StuQSEntity>> dataPageList = new DataPageList<IEnumerable<BK_StuQSEntity>>
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return this.SendData<DataPageList<IEnumerable<BK_StuQSEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                //}
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }


        /// <summary>
        /// 保存学生操行扣分信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator saveBehaviorRecode(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_BehaviorRecodeEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    BehaviorRecodeBll.SaveForm(recdata.data.ID, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }



        /// <summary>
        /// 获取我的操行违规扣分记录列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator StuGetMyBehaviorRecodeList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                //if (!resValidation)
                //{
                //    return this.SendData(ResponseType.Fail, "后台无登录信息");
                //}
                //else
                //{
                Pagination pagination = new Pagination
                {
                    page = recdata.data.page,
                    rows = recdata.data.rows,
                    sidx = recdata.data.sidx,
                    sord = recdata.data.sord
                };
                var data = BehaviorRecodeBll.GetMyBehaviorRecodeList(pagination, recdata.data.queryData);
                DataPageList<IEnumerable<BK_BehaviorRecodeEntity>> dataPageList = new DataPageList<IEnumerable<BK_BehaviorRecodeEntity>>
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return this.SendData<DataPageList<IEnumerable<BK_BehaviorRecodeEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                //}
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }

        /// <summary>
        /// 保存申请撤销操行扣分记录信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator saveCancelApp(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_CancelAppEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    CancelAppBll.SaveForm2(recdata.data.ID, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }


        /// <summary>
        /// 保存申请撤销学生会审核信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator saveReviewCancelApp(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_CancelAppEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    CancelAppBll.SaveForm2(recdata.data.ID, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }



        /// <summary>
        /// 获取操行扣分撤销申请记录列表
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator StuGetCancelAppList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    Pagination pagination = new Pagination
                    {
                        page = recdata.data.page,
                        rows = recdata.data.rows,
                        sidx = recdata.data.sidx,
                        sord = recdata.data.sord
                    };
                    var data = CancelAppBll.StuGetCancelAppList(pagination);
                    DataPageList<IEnumerable<M_BK_CancelAppEntity>> dataPageList = new DataPageList<IEnumerable<M_BK_CancelAppEntity>>
                    {
                        rows = data,
                        total = pagination.total,
                        page = pagination.page,
                        records = pagination.records,
                        costtime = CommonHelper.TimerEnd(watch)
                    };
                    return this.SendData<DataPageList<IEnumerable<M_BK_CancelAppEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }


        //学生申请撤销记录数
        private Negotiator StuCancelAppNumber(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = CancelAppBll.Number();
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_NumberEntity>();
                    M_BK_NumberEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_NumberEntity();

                    return this.SendData<M_BK_NumberEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }

        /// <summary>
        /// 宿舍交换根据专业和性别得到所有的宿舍和宿舍下面的床位
        /// </summary>
        /// <param name="queryJson"></param>
        /// <returns></returns>
        public Negotiator GetExchangeDormListAndChildList(dynamic _)
        {
            try
            {
                var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
                var data = dorminfoBLL.GetDormName(recdata.data.queryData);
                List<Dorm> dormList = new List<Dorm>();
                foreach (var dorm in data)
                {
                    var childData = dorminfoBLL.GetExchangeDormBed(dorm.DormId,recdata.data.queryData); //得到所有的床位信息      
                    Dorm d = new Dorm();
                    d.entity = dorm;
                    d.childEntity = childData;
                    dormList.Add(d);
                }
                var temp = this.SendData(dormList, recdata.userid, recdata.token, ResponseType.Success);
                return temp;
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }

        }

        //查询原床位号
        private Negotiator SelectOldBedId(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = dormBedBLL.SelectOldBedId(recdata.data.queryData);
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.BK_DormBedEntity>();
                    BK_DormBedEntity stuEntity = q.Count >= 1 ? q[0] : new BK_DormBedEntity();

                    return this.SendData<BK_DormBedEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }

        /// <summary>
        /// 保存宿舍交换申请信息
        /// </summary>
        /// <param name="_"></param>
        /// <returns></returns>
        private Negotiator saveDormExchangeAppRemark(dynamic _)
        {
            try
            {
                //获得页面提交的数据
                var recdata = this.GetModule<ReceiveModule<BK_AppChangeBedEntity>>();
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    AppChangeBedBLL.SaveForm(recdata.data.ID, recdata.data);
                    return this.SendData(ResponseType.Success);
                }
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "异常");
            }
        }


        //查询宿舍交换记录信息或取已有记录id
        private Negotiator SelectAppChangeBed(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = AppChangeBedBLL.SelectAppChangeBed(recdata.data.queryData);
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.BK_AppChangeBedEntity>();
                    BK_AppChangeBedEntity stuEntity = q.Count >= 1 ? q[0] : new BK_AppChangeBedEntity();

                    return this.SendData<BK_AppChangeBedEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }


        //查询我的宿舍交换记录信息
        private Negotiator SelectMyDromExchagnge(dynamic _)
        {
            var watch = CommonHelper.TimerStart();//开始计时
            var recdata = this.GetModule<ReceiveModule<QueryWhere>>();
            try
            {
                bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                if (!resValidation)
                {
                    return this.SendData(ResponseType.Fail, "后台无登录信息");
                }
                else
                {
                    var data = AppChangeBedBLL.DormExchangeGetMyInfo(recdata.data.queryData);
                    var q = data.ToJson().ToList<LeaRun.Application.Entity.CollegeMIS.M_BK_AppChangeBedEntity>();
                    M_BK_AppChangeBedEntity stuEntity = q.Count >= 1 ? q[0] : new M_BK_AppChangeBedEntity();

                    return this.SendData<M_BK_AppChangeBedEntity>(stuEntity, recdata.userid, recdata.token, ResponseType.Success);
                }
            }
            catch (Exception ex)
            {
                return this.SendData(ResponseType.Fail, ex.Message);
            }
        }

        //对我的交换申请
        private Negotiator StuGetMyExchangeList(dynamic _)
        {
            try
            {
                var watch = CommonHelper.TimerStart();
                var recdata = this.GetModule<ReceiveModule<PaginationModule>>();
                //bool resValidation = this.DataValidation(recdata.userid, recdata.token);
                //if (!resValidation)
                //{
                //    return this.SendData(ResponseType.Fail, "后台无登录信息");
                //}
                //else
                //{
                Pagination pagination = new Pagination
                {
                    page = recdata.data.page,
                    rows = recdata.data.rows,
                    sidx = recdata.data.sidx,
                    sord = recdata.data.sord
                };
                var data = AppChangeBedBLL.GetMyExchangeList(pagination, recdata.data.queryData);
                DataPageList<IEnumerable<M_BK_AppChangeBedEntity>> dataPageList = new DataPageList<IEnumerable<M_BK_AppChangeBedEntity>>
                {
                    rows = data,
                    total = pagination.total,
                    page = pagination.page,
                    records = pagination.records,
                    costtime = CommonHelper.TimerEnd(watch)
                };
                return this.SendData<DataPageList<IEnumerable<M_BK_AppChangeBedEntity>>>(dataPageList, recdata.userid, recdata.token, ResponseType.Success);
                //}
            }
            catch
            {
                return this.SendData(ResponseType.Fail, "出现异常");
            }
        }

        #endregion 学生端用
    }

    public class Dorm
    {
        public BK_DormEntity entity { get; set; }
        public IEnumerable<M_BK_DormEntity> childEntity { get; set; }
    }
    public class TeaDorm
    {
        public BK_DormEntity entity { get; set; }
        public IEnumerable<M_BK_DormStuInfoEntity> childEntity { get; set; }
    }
    public class TuiChi
    {
        public BK_TuiChiBaoDaoEntity entity { get; set; }
        public IEnumerable<M_BK_TuiChiBaoDaoEntity> childEntity { get; set; }
    }
}