using LeaRun.Application.Entity.CollegeMIS;
using LeaRun.Application.Busines.CollegeMIS;
using LeaRun.Util;
using LeaRun.Util.WebControl;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using LeaRun.Util.Extension;
using LeaRun.Application.Code;

namespace LeaRun.Application.Web.Areas.CollegeMIS.Controllers
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创 建：admin
    /// 日 期：2017-06-06 09:47
    /// 描 述：新生数据导入      报到确认后的学生数据导入到此表中      同时分班（分配班号） 、学号
    /// </summary>
    public class BK_StuInfoController : MvcControllerBase
    {
        private BK_StuInfoBLL bk_stuinfobll = new BK_StuInfoBLL();

        #region 视图功能
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 新生报到列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BDIndex()
        {
            return View();
        }

        /// <summary>
        /// 打印通知书列表页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PNoticeIndex()
        {
            return View();
        }


        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Form()
        {
            return View();
        }

        /// <summary>
        /// 打印学生通知书
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult PrintForm()
        {
            return View();
        }
        /// <summary>
        /// 学生分床位
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult BedForm()
        {
            return View();
        }
        /// <summary>
        /// 新生报到统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult NewStuRegCountForMajorIndex()
        {
            return View();
        }

        #endregion

        #region 获取数据
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetPageListJson(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bk_stuinfobll.GetPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            return ToJsonResult(jsonData);
        }
        /// <summary>
        /// 获取一定时间内的新生报到列表
        /// </summary>
        /// <param name="pagination">分页参数</param>
        /// <param name="queryJson">查询参数</param>
        /// <returns>返回分页列表Json</returns>
        [HttpGet]
        public ActionResult GetStuCountList(Pagination pagination, string queryJson)
        {
            var watch = CommonHelper.TimerStart();
            var data = bk_stuinfobll.GetNewStuCountPageList(pagination, queryJson);
            var jsonData = new
            {
                rows = data,
                total = pagination.total,
                page = pagination.page,
                records = pagination.records,
                costtime = CommonHelper.TimerEnd(watch)
            };
            var temp = ToJsonResult(jsonData);
            return temp;
        }

        /// <summary>
        /// 获取实体 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson(string keyValue)
        {
            var data = bk_stuinfobll.GetEntity(keyValue);
            var childData = bk_stuinfobll.GetDetails(keyValue);
            var jsonData = new
            {
                entity = data,
                childEntity = childData
            };
            return ToJsonResult(jsonData);
        }

        /// <summary>
        /// 获取实体 
        /// 只获取学生信息部分
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJson2(string keyValue)
        {
            var data = bk_stuinfobll.GetEntity(keyValue);            
            return ToJsonResult(data);
        }

        /// <summary>
        /// 获取实体 
        /// 只获取学生信息部分
        /// </summary>
        /// <param name="queryJson">查询条件</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetFormJsonByWhere(string queryJson)
        {
            var data = bk_stuinfobll.GetEntityByWhere(queryJson);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 获取实体 
        /// 只获取学生信息部分
        /// </summary>
        /// <param name="queryJson">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetEntityList(string queryJson)
        {
            var data = bk_stuinfobll.GetTablePageList(null, queryJson).Rows;//.GetList(queryJson);
            var temp = ToJsonResult(data);
            return temp;
        }


        /// <summary>
        /// 获取子表详细信息 
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetDetailsJson(string keyValue)
        {
            var data = bk_stuinfobll.GetDetails(keyValue);
            return ToJsonResult(data);
        }

        /// <summary>
        /// 获取学生详细信息 
        /// </summary>
        /// <param name="stuids">学生ID号</param>
        /// <returns>返回对象Json</returns>
        [HttpGet]
        public ActionResult GetStuInfoListByStuIds(string stuids)
        {
            string[] stuidlist = stuids.Split(',');
            List<BK_StuInfoEntity> stulist = new List<BK_StuInfoEntity>();
            string uname = OperatorProvider.Provider.Current().UserName;
            foreach (var stuid in stuidlist)
            {
                var stuinfo = bk_stuinfobll.GetEntity(stuid);
                if (stuinfo!=null)
                {
                    if (stuinfo.PrintNotice != null)
                    {
                        stuinfo.PrintNotice += 1;
                    }
                    else
                    {
                        stuinfo.PrintNotice = 1;
                    }

                    stuinfo.LastPrintTime = DateTime.Now;
                    stuinfo.WhoPrint = uname;
                    bk_stuinfobll.SaveForm(stuinfo.stuInfoId, stuinfo, null);//修改通知书打印的信息

                    stulist.Add(stuinfo);
                }
            }
            return ToJsonResult(stulist);
        }

        #endregion

        #region 提交数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult RemoveForm(string keyValue)
        {
            bk_stuinfobll.RemoveForm(keyValue);
            return Success("删除成功。");
        }
        /// <summary>
        /// 保存表单（新增、修改）
        /// </summary>
        /// <param name="keyValue">主键值</param>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        public ActionResult SaveForm(string keyValue, string strEntity,string strChildEntitys)
        {
            strEntity = strEntity.Replace("&nbsp;", "");
            var entity = strEntity.ToObject<BK_StuInfoEntity>(); //
            if (string.IsNullOrEmpty(keyValue))
            {//表示为添加数据，添加数据时要添加默认密码
                entity.StuOther = "未分班"; //分班标志
                entity.GuiDangMark = "未归档";//只有新生才没有归档
                entity.TransMark = "0";//只有新生才没有归档
                if (!string.IsNullOrEmpty(entity.IdentityCardNo))
                {
                    string pwd = entity.IdentityCardNo.Substring(12);
                    entity.StuPwd = Md5Helper.MD5(pwd, 16);//增加学生默认密码，密码为身份证号码后6位
                }
            }
            var childEntitys = strChildEntitys.ToList<BK_StuSocRelaEntity>();
            bk_stuinfobll.SaveForm(keyValue, entity, childEntitys);
            return Success("操作成功。");
        }

        /// <summary>
        /// 新生报到
        /// </summary>
        /// <param name="keyValue">新生ID号</param>
        /// <returns></returns>
        public ActionResult NewStuBaodao(string keyValue)
        {
            var student = bk_stuinfobll.GetEntity(keyValue);
            if (student!=null && student.NewStuReport==0)
            {
                student.NewStuReport = 1;
                student.GuiDangMark = "已归档";
                student.TransMark = "1";//表示归档
                student.NewStuReportDatetime = DateTime.Now;
                bk_stuinfobll.SaveForm(keyValue, student, null);
            }
            else
            {
                return Error("报到失败。");
            }

            return Success("报到成功。");
        }
            
        #endregion
    }
}
